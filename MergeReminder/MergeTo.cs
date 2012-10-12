using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MergeReminder.Logic;

namespace MergeReminder
{
    public partial class MergeTo : Form
    {
        private BranchingTree uxBranchesTree { get; set; }
        public bool Selected { get; set; }
        public TreeNode SelectedNode { get { return uxBranchesTree.SelectedNode; } }

        public MergeTo(IEnumerable<Branch> branches)
        {
            InitializeComponent();

            SetupTree();
            uxBranchesTree.Bind(branches);
        }


        private void SetupTree()
        {
            uxBranchesTree = new BranchingTree { Dock = DockStyle.Fill };
            uxBranchesPanel.Controls.Add(uxBranchesTree);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Selected = (uxBranchesTree.SelectedNode != null);
            Close();
        }

    }
}
