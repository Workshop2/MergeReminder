using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MergeReminder
{
    public delegate void TreeEvent(TreeView sender, TreeViewCancelEventArgs e);
    public partial class BranchingTree : UserControl
    {
        public BranchingTree()
        {
            InitializeComponent();
        }

        public bool CheckBoxes
        {
            get { return uxTreeView.CheckBoxes; }
            set { uxTreeView.CheckBoxes = value; }
        }

        public void Bind(IEnumerable<TreeNode> nodes)
        {
            //Clean out the old crap
            while (uxTreeView.Nodes.Count > 0)
                uxTreeView.Nodes.Remove(uxTreeView.Nodes[0]);

            //Add the newer crap :)
            if (nodes != null)
                foreach (var treeNode in nodes)
                    uxTreeView.Nodes.Add(treeNode);
        }

        public TreeNodeCollection Nodes { get { return uxTreeView.Nodes; } }
        
        public event TreeEvent BeforeCheck;
        private void uxTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            var handler = BeforeCheck;
            if (handler != null) handler(uxTreeView, e);
        }

        public TreeNode SelectedNode
        {
            get { return uxTreeView.SelectedNode; }
            set { uxTreeView.SelectedNode = value; }
        }
    }
}
