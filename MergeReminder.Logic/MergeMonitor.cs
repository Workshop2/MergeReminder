using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace MergeReminder.Logic
{
    public delegate void StatusChange(Dictionary<BranchStore, List<MergeCandidate>> requiredMerges);
    public class MergeMonitor
    {
        private Thread ThreadRunner { get; set; }
        private Db DbSession { get; set; }
        private TimeSpan SleepSpan { get; set; }
        public event StatusChange OnMergesFound;
        private List<BranchStore> BranchesToProcess { get; set; }
        private SystemConfiguration CurrentConfig { get; set; }

        public MergeMonitor(Db dbSession, TimeSpan sleepSpan)
        {
            DbSession = dbSession;
            SleepSpan = sleepSpan;
        }

        public void StartThread()
        {
            StopThread();

            ThreadRunner = new Thread(Runner) { Name = "MergeMonitor" };
            ThreadRunner.Start();
        }

        public void StopThread()
        {
            if (ThreadRunner != null)
            {
                try
                {
                    ThreadRunner.Abort();
                }
                finally
                {
                    ThreadRunner = null;
                }
            }
        }

        private void Runner()
        {
            while (true)
            {
                try
                {
                    if (BranchesToProcess == null)
                        BranchesToProcess = DbSession.Branches.ToList();

                    if (CurrentConfig == null)
                    {
                        CurrentConfig = DbSession.SystemConfiguration.FirstOrDefault();
                        if (CurrentConfig == null)
                            return;
                    }

                    var results = new Dictionary<BranchStore, List<MergeCandidate>>();

                    foreach (var branch in BranchesToProcess)
                    {
                        var tpc = CurrentConfig.GenerateTfsConnection();
                        var vcs = (VersionControlServer)tpc.GetService(typeof(VersionControlServer));
                        var mergeCandidates = vcs.GetMergeCandidates(branch.Value, branch.MergeTo, RecursionType.Full).ToList();

                        mergeCandidates = FilterMerges(mergeCandidates);

                        if (mergeCandidates.Count > 0)
                            results.Add(branch, mergeCandidates);
                    }

                    if (results.Count > 0)
                        MergesFound(results);
                }
                catch
                {
                }

                Thread.Sleep(SleepSpan);
            }

        }

        private List<MergeCandidate> FilterMerges(List<MergeCandidate> mergeCandidates)
        {
            var rtnVal = new List<MergeCandidate>();
            var currentUser = (CurrentConfig.TfsUsernameDomain + "\\" + CurrentConfig.TfsUsername).ToUpper();
            var eSightDevUser = "EEG\\ESIGHTDEV";

            foreach (var candidate in mergeCandidates)
            {
                var addCandidate = true;
                var comment = candidate.Changeset.Comment;

                //To handle checkins like "DO NOT" or "DONT"
                if (comment.ToUpper().StartsWith("DO"))
                    continue;

                //Only go into this if we are filtering by user. If we arn't we expect to use everything so
                //ignore the bit about eSightDev user
                if (CurrentConfig.FilterUser)
                {
                    var candidateUser = candidate.Changeset.Owner.ToUpper();

                    if (CurrentConfig.FilterEsightDev)
                    {
                        if (eSightDevUser != candidateUser)
                            addCandidate = false;
                    }

                    if (CurrentConfig.FilterUser && (!addCandidate || !CurrentConfig.FilterEsightDev))
                    {
                        addCandidate = candidateUser == currentUser;
                    }
                }

                if (addCandidate)
                    rtnVal.Add(candidate);
            }

            return rtnVal;
        }

        public void ResetBranches()
        {
            BranchesToProcess = null;
            CurrentConfig = null;
        }

        public void MergesFound(Dictionary<BranchStore, List<MergeCandidate>> requiredMerges)
        {
            var handler = OnMergesFound;
            if (handler != null) handler(requiredMerges);
        }
    }
}