using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MergeReminder.Logic;
using MergeReminder.Properties;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace MergeReminder
{
    public delegate void MergeInvoker(Dictionary<BranchStore, List<MergeCandidate>> foundMerges);
    public partial class Index : Form
    {
        private Db DbSession { get; set; }
        private SystemConfiguration CurrentConfig { get; set; }
        private BranchingTree uxBranchesTree { get; set; }
        private MergeMonitor Monitor { get; set; }

        public Index()
        {
            InitializeComponent();
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;

            DbSession = new Db();

            SetupTree();

            TryGetConfigFromDb();
        }

        private void SetupTree()
        {
            uxBranchesTree = new BranchingTree { Dock = DockStyle.Fill };
            uxBranchesTree.BeforeCheck += new TreeEvent(uxBranchesTree_BeforeCheck);
            uxBranchesPanel.Controls.Add(uxBranchesTree);
        }

        private void TryGetConfigFromDb()
        {
            try
            {
                var config = DbSession.SystemConfiguration.FirstOrDefault();

                if (config != null)
                {
                    CurrentConfig = config;
                    uxTfsServer.Text = config.TfsServer;
                    uxUsername.Text = config.TfsUsername;
                    uxPassword.Text = config.TfsPassword;
                    uxDomain.Text = config.TfsUsernameDomain;
                    uxFilter.Checked = config.FilterUser;
                    uxFilterDevChanges.Checked = config.FilterEsightDev;
                    PopulateTree(CurrentConfig);
                }
                else
                {
                    _loadFired = true;
                    _allowVisible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.ErrorGettingDb + ex.Message);
            }
        }

        private bool _allowVisible;     // ContextMenu's Show command used
        private bool _allowClose;       // ContextMenu's Exit command used
        private bool _loadFired;        // Form was shown once

        protected override void SetVisibleCore(bool value)
        {
            if (!_allowVisible) value = false;
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_allowClose)
            {
                Hide();
                e.Cancel = true;
            }
            else
            {
                DbSession.Dispose();

                if (Monitor != null)
                {
                    Monitor.StopThread();
                }
            }

            base.OnFormClosing(e);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allowVisible = true;
            _loadFired = true;
            Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allowClose = _allowVisible = true;
            if (!_loadFired) Show();
            Close();
        }
        
        private void uxTest_Click(object sender, EventArgs e)
        {
            var testSystemConfig = new SystemConfiguration
            {
                TfsServer = uxTfsServer.Text,
                TfsUsername = uxUsername.Text,
                TfsUsernameDomain = uxDomain.Text,
                TfsPassword = uxPassword.Text
            };

            PopulateTree(testSystemConfig);
        }

        private void PopulateTree(SystemConfiguration systemConfig)
        {
            uxLoginPane.Enabled = false;

            try
            {
                uxBranchesTree.CheckBoxes = true;

                var toCheck = DbSession.Branches.ToList();
                var branches = systemConfig.ListTfsBranches();

                ProcessBranchesState(branches, toCheck);

                uxBranchesTree.Bind(branches);

                foreach (var configuration in DbSession.SystemConfiguration)
                    DbSession.SystemConfiguration.Remove(configuration);
                DbSession.SaveChanges();

                DbSession.SystemConfiguration.Add(systemConfig);
                DbSession.SaveChanges();

                CurrentConfig = systemConfig;

                uxBranchesPanel.Enabled = true;

                StartMergeMonitor();

            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.ErrorWhileListingBranches + ex.Message);
                uxLoginPane.Enabled = true;
            }
        }

        private void StartMergeMonitor()
        {
            if (Monitor == null)
            {
                Monitor = new MergeMonitor(DbSession, new TimeSpan(0, 10, 0));
                Monitor.OnMergesFound += new StatusChange(Monitor_OnMergesFound);
                Monitor.StartThread();
            }
            else
            {
                Monitor.ResetBranches();
            }

        }

        void Monitor_OnMergesFound(Dictionary<BranchStore, List<MergeCandidate>> requiredMerges)
        {
            var title = "Un-merged changes found";
            var message = "{0} un-merged changes have been found over {1} branch(es). Go and merge these now";

            var total = requiredMerges.Sum(pair => pair.Value.Count);
            message = string.Format(message, total, requiredMerges.Count);

            notifyIcon1.ShowBalloonTip(1000000, title, message, ToolTipIcon.Warning);
        }

        private static void ProcessBranchesState(IEnumerable<Branch> branches, List<BranchStore> toCheck)
        {
            foreach (var newBranch in branches)
                ProcessBranchState(newBranch, toCheck);
        }

        private static void ProcessBranchState(TreeNode node, List<BranchStore> toCheck)
        {
            node.Checked = toCheck.Any(x => x.Value == node.Text);

            foreach (TreeNode childNode in node.Nodes)
                ProcessBranchState(childNode, toCheck);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentConfig.FilterUser = uxFilter.Checked;
                CurrentConfig.FilterEsightDev = uxFilterDevChanges.Checked;
                CurrentConfig.SaveBranches(uxBranchesTree.Nodes, DbSession);
                StartMergeMonitor();

                MessageBox.Show(Resources.SavedMessage);
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.ErrorWhileSaving + ex.Message);
            }
        }

        void uxBranchesTree_BeforeCheck(TreeView sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Checked) return;

            using (var tmpForm = new MergeTo(CurrentConfig.ListTfsBranches()))
            {
                tmpForm.ShowDialog();

                if (tmpForm.Selected)
                {
                    if (tmpForm.SelectedNode.Text != e.Node.Text)
                    {
                        var casted = (Branch)e.Node;
                        casted.MergeTo = tmpForm.SelectedNode.Text;
                    }
                    else
                        e.Cancel = true;
                }
                else
                    e.Cancel = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.About);
        }
    }
}
