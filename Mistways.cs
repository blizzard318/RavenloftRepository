public partial class Factory : IDisposable
{
    private static void SetUpMistways()
    {
        foreach (var mistway in Enum.GetValues<MistwayEnum>())
        {
            MistwayToString.TryGetValue(mistway, out var mistwayNames);
            mistwayNames ??= new[] { mistway.ToString() };

            var ToAdd = new Mistway();
            foreach (var mistwayName in mistwayNames) ToAdd.Names.Add(mistwayName);

            Ravenloftdb.Mistways.Add(mistway, ToAdd);
        }
    }

    public enum MistwayEnum
    {

    }
    private static readonly Dictionary<MistwayEnum, string[]> MistwayToString = new Dictionary<MistwayEnum, string[]>()
    {
    };
    public Entity TrackMistway(ClusterEnum Name, string pageNumbers, Domain First, Domain Second)
    {
        var retval = Ravenloftdb.Clusters[Name]; //All domains already pregenerated

        retval.Appearances.Add(Source, new InSource<Entity>(retval, Source, pageNumbers));
        retval.editions |= Source.editions;

        retval.Domains.TryAdd(Source, new());
        retval.Domains[Source].Add(First);
        retval.Domains[Source].Add(Second);

        First.Mistways.TryAdd(Source, new());
        First.Mistways[Source].Add(retval);

        Second.Mistways.TryAdd(Source, new());
        Second.Mistways[Source].Add(retval);

        return retval;
    }
    public void AddDomainsToMistway(ClusterEnum clusterEnum, params Domain[] domains)
    {
        var Cluster = Ravenloftdb.Clusters[clusterEnum];
        Cluster.Domains.TryAdd(Source, new());
        foreach (var domain in domains)
        {
            Cluster.Domains[Source].Add(domain);
            domain.Clusters.TryAdd(Source, new());
            domain.Clusters[Source].Add(Cluster);
        }
    }
}
