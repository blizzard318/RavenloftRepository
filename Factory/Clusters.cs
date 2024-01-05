public partial class Factory : IDisposable
{
    internal static class ClusterEnum
    {
        static ClusterEnum()
        {
            IslandsOfTerror.ExtraInfo = "These domains have never or used to be part of a cluster but not any longer.";
            Core.ExtraInfo = "Core and Core (Post Grand Conjuction) are identical.";
            NovelOnlyDomains.ExtraInfo = "These domains have only ever appeared in the Ravenloft novels.";
            FormerDomains.ExtraInfo = "These domains have either been destroyed or absorbed into another domain.";
        }
        private static Group CreateCluster(params string[] names)
        {
            var retval = new Group(names);
            Ravenloftdb.Clusters.Add(retval);
            return retval;
        }
        public readonly static Group IslandsOfTerror  = CreateCluster("Islands of Terror");
        public readonly static Group Core             = CreateCluster("Core", "Core (Post Grand Conjunction)");
        public readonly static Group PreGCCore        = CreateCluster("Core (Pre Grand Conjunction)");
        public readonly static Group AmberWastes      = CreateCluster("Amber Wastes");
        public readonly static Group BurningPeaks     = CreateCluster("Burning Peaks");
        public readonly static Group FrozenReaches    = CreateCluster("Frozen Reaches");
        public readonly static Group VerdurousLands   = CreateCluster("Verdurous Lands");
        public readonly static Group Shadowlands      = CreateCluster("Shadowlands");
        public readonly static Group Zherisia         = CreateCluster("Zherisia");
        public readonly static Group NovelOnlyDomains = CreateCluster("Novel only Domains");
        public readonly static Group FormerDomains    = CreateCluster("Former Domains");
        public readonly static Group MobileDomains    = CreateCluster("Mobile Domains");
        public readonly static Group Shadowfell       = CreateCluster("Shadowfell Domains");
        public readonly static Group SeaOfSorrows     = CreateCluster("SeaOfSorrows");
        public readonly static Group Kalakeri         = CreateCluster("Kalakeri");
    }
}
