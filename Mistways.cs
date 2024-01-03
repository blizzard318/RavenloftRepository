public partial class Factory : IDisposable
{
    private static void SetUpMistways()
    {
        var MistwayToString = new Dictionary<MistwayEnum, string[]>()
        {
        };
        foreach (var mistway in Enum.GetValues<MistwayEnum>())
        {
            MistwayToString.TryGetValue(mistway, out var mistwayNames);
            mistwayNames ??= new[] { mistway.ToString() };

            var ToAdd = new Location();
            foreach (var mistwayName in mistwayNames) ToAdd.Names.Add(mistwayName);

            Ravenloftdb.Mistways.Add(mistway, ToAdd);
        }
    }

    public enum MistwayEnum
    {

    }

    public Location TrackMistway(MistwayEnum Name, string pageNumbers, Domain First, Domain Second)
    {
        var retval = Ravenloftdb.Mistways[Name]; //All domains already pregenerated

        retval.Appearances.Add(Source, new TrackPage<Location>(retval, Source, pageNumbers));
        retval.editions |= Source.editions;

        retval.Domains.PerSource.TryAdd(Source, new());
        retval.Domains.PerSource[Source].Add(First);
        retval.Domains.PerSource[Source].Add(Second);

        First.Mistways.PerSource.TryAdd(Source, new());
        First.Mistways.PerSource[Source].Add(retval);

        Second.Mistways.PerSource.TryAdd(Source, new());
        Second.Mistways.PerSource[Source].Add(retval);

        return retval;
    }
}
