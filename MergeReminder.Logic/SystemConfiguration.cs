using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace MergeReminder.Logic
{
    public class SystemConfiguration
    {
        [Key]
        public string TfsServer { get; set; }
        public string TfsUsername { get; set; }
        public string TfsUsernameDomain { get; set; }
        public string TfsPassword { get; set; }
        public bool FilterUser { get; set; }
        public bool FilterEsightDev { get; set; }

        public NetworkCredential GetNetworkCredential()
        {
            return new NetworkCredential(TfsUsername, TfsPassword, TfsUsernameDomain);
        }

        public Uri GetTfsUri()
        {
            return new Uri(TfsServer);
        }

        public Dictionary<string, string> ListTfsProjects()
        {
            var rtnVal = new Dictionary<string, string>();

            using (var tfs = GenerateTfsConnection())
            {
                var workStore = new WorkItemStore(tfs);

                foreach (Project prj in workStore.Projects)
                    rtnVal.Add(prj.Id.ToString(CultureInfo.InvariantCulture), prj.Name);
            }

            return rtnVal;
        }

        public TfsTeamProjectCollection GenerateTfsConnection()
        {
            var tfs= new TfsTeamProjectCollection(GetTfsUri(), GetNetworkCredential());
            tfs.Authenticate();
            tfs.Connect(new ConnectOptions());

            return tfs;
        }

        public List<Branch> ListTfsBranches()
        {
           return Branch.GetBranches(GenerateTfsConnection());
        }


        public void SaveBranches(TreeNodeCollection treeNodes, Db dbSession)
        {
            var currentBranches = dbSession.Branches;
            var hasBeenChecked = GetAllCheckedNodes(treeNodes);
            var toSave = hasBeenChecked.Cast<Branch>().Where(x => !currentBranches.Any(y => y.Value == x.Text)).ToList();
            dbSession.SaveChanges();


            foreach (var node in toSave)
                dbSession.Branches.Add(new BranchStore { Value = node.Text, MergeTo = node.MergeTo});

            foreach (var currentBranch in currentBranches)
            {
                if (hasBeenChecked.FirstOrDefault(x => x.Text == currentBranch.Value) == null)
                    dbSession.Branches.Remove(currentBranch);
            }


            foreach (var configuration in dbSession.SystemConfiguration)
                dbSession.SystemConfiguration.Remove(configuration);
            dbSession.SaveChanges();

            dbSession.SystemConfiguration.Add(this);
            dbSession.SaveChanges();
        }
        
        private static List<TreeNode> GetAllCheckedNodes(TreeNodeCollection nodes)
        {
            var allNodes = new List<TreeNode>();

            foreach (TreeNode node in nodes)
                allNodes.AddRange(GetCheckedChildren(node));

            return allNodes;
        }

        private static List<TreeNode> GetCheckedChildren(TreeNode node)
        {
            var rtnVal = new List<TreeNode>();

            if (node.Checked)
                rtnVal.Add(node);

            foreach (TreeNode childNode in node.Nodes)
                rtnVal.AddRange(GetCheckedChildren(childNode));

            return rtnVal;
        }
    }
}