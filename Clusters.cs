public partial class Factory : IDisposable
{
    private static void SetUpClusters() //Important, call this one after SetUpDomains()
    {
        foreach (var cluster in Enum.GetValues<ClusterEnum>())
        {
            ClusterToString.TryGetValue(cluster, out var clusterNames);
            clusterNames ??= new[] { cluster.ToString() };

            var ToAdd = new Cluster();
            foreach (var clusterName in clusterNames) ToAdd.Names.Add(clusterName);

            Ravenloftdb.Clusters.Add(cluster, ToAdd);
        }
        Ravenloftdb.Clusters[ClusterEnum.IslandsOfTerror].ExtraInfo = "These domains have never or used to be part of a cluster but not any longer.";
        Ravenloftdb.Clusters[ClusterEnum.Core].ExtraInfo = "Core and Core (Post Grand Conjuction) are identical.";
        Ravenloftdb.Clusters[ClusterEnum.NovelOnlyDomains].ExtraInfo = "These domains have only ever appeared in the Ravenloft novels.";
        Ravenloftdb.Clusters[ClusterEnum.FormerDomains].ExtraInfo = "These domains have either been destroyed or absorbed into another domain.";
    }
    public enum ClusterEnum
    {
        IslandsOfTerror, Core, PreGCCore, AmberWastes, BurningPeaks, FrozenReaches,
        VerdurousLands, Shadowlands, Zherisia, NovelOnlyDomains, FormerDomains,
        MobileDomains, Shadowfell, SeaOfSorrows, Kalakeri //Are pocket domains worth tracking?
    }
    public static readonly Dictionary<ClusterEnum, string[]> ClusterToString = new Dictionary<ClusterEnum, string[]>()
    {
        { ClusterEnum.IslandsOfTerror , new[] { "Islands of Terror"                     }},
        { ClusterEnum.Core            , new[] { "Core", "Core (Post Grand Conjunction)" }},
        { ClusterEnum.PreGCCore       , new[] { "Core (Pre Grand Conjunction)"  }},
        { ClusterEnum.AmberWastes     , new[] { "Amber Wastes"                          }},
        { ClusterEnum.BurningPeaks    , new[] { "Burning Peaks"                         }},
        { ClusterEnum.FrozenReaches   , new[] { "Frozen Reaches"                        }},
        { ClusterEnum.VerdurousLands  , new[] { "Verdurous Lands"                       }},
        { ClusterEnum.NovelOnlyDomains, new[] { "Novel only Domains"                    }},
        { ClusterEnum.FormerDomains   , new[] { "Former Domains"                        }},
        { ClusterEnum.MobileDomains   , new[] { "Mobile Domains"                        }},
        { ClusterEnum.Shadowfell      , new[] { "Shadowfell Domains"                    }},
    };
    public Cluster TrackCluster(ClusterEnum Name, string pageNumbers)
    {
        var retval = Ravenloftdb.Clusters[Name]; //All domains already pregenerated

        retval.Appearances.Add(Source, new InSource<Cluster>(retval, Source, pageNumbers));
        retval.editions |= Source.editions;

        return retval;
    }
    public void AddDomainsToCluster(ClusterEnum clusterEnum, params Domain[] domains)
    {
        var Cluster = Ravenloftdb.Clusters[clusterEnum];
        Cluster.DomainsPerSource.TryAdd(Source, new());
        foreach (var domain in domains)
        {
            Cluster.DomainsPerSource[Source].Add(domain);
            domain.Clusters.TryAdd(Source, new());
            domain.Clusters[Source].Add(Cluster);
        }
    }
}
