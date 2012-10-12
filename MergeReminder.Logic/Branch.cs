using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace MergeReminder.Logic
{
    public class Branch : TreeNode
    {
        public string MergeTo { get; set; }
        public static List<Branch> GetBranches(TfsTeamProjectCollection tfs)
        {
            var rtnVal = new List<Branch>();
            using (tfs)
            {
                var vcs = tfs.GetService<VersionControlServer>();
                var bos = vcs.QueryRootBranchObjects(RecursionType.OneLevel);


                rtnVal.AddRange(bos.Select(branchObject => RecursivelyProcessBranch(branchObject, vcs)));
            }
            return rtnVal;
        }

        private static Branch RecursivelyProcessBranch(BranchObject bo, VersionControlServer vcs)
        {
            var rtnVal = new Branch {Name = bo.Properties.RootItem.Item, Text = bo.Properties.RootItem.Item};

            var childBos = vcs.QueryBranchObjects(bo.Properties.RootItem, RecursionType.OneLevel);

            foreach (var branchObject in childBos)
            {
                if (branchObject.Properties.RootItem.Item != bo.Properties.RootItem.Item)
                    rtnVal.Nodes.Add(RecursivelyProcessBranch(branchObject, vcs));
            }

            return rtnVal;
        }
    }

    public class BranchStore
    {
        [Key]
        public string Value { get; set; }

        public string MergeTo { get; set; }

        public static IEnumerable<BranchStore> ToList(List<Branch> inputList)
        {
            return inputList.Select(treeNode => new BranchStore {Value = treeNode.Text, MergeTo = treeNode.MergeTo}).ToList();
        }
    }
}