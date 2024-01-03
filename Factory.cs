//This script is for creating stuff to the database
//Adding stuff to the newly created stuff is handled in CrossAdd.cs

using System.Xml.Linq;

public partial class Factory : IDisposable
{
    static Factory()
    {
        SetUpSourceTraits();
        SetUpDomains();
        SetUpClusters();
        SetUpMistways();
    }

    private enum EntityType { Domain, Location, Item, NPC, Group };
    private T Create<T>(EntityType type, string Name, string pageNumbers = "Throughout") where T : UseVariableName, IHasAppearances<T>, new()
    {
        var set = GetSet(type);
        set.TryGetValue(Name, out var retval);
        if (retval == null)
        {
            set.Add(Name, retval = new T());
            retval.Names.Add(Name);
        }
        retval.Appearances.Add(Source, new TrackPage<T>(retval, Source, pageNumbers));
        return retval;

        static SortedDictionary<string, T>? GetSet (EntityType type)
        {
            switch (type)
            {
                case EntityType.Location: return Ravenloftdb.Locations  as SortedDictionary<string, T>;
                case EntityType.Item    : return Ravenloftdb.Items      as SortedDictionary<string, T>;
                case EntityType.NPC     : return Ravenloftdb.Characters as SortedDictionary<string, T>;
                case EntityType.Group   : return Ravenloftdb.Groups     as SortedDictionary<string, T>;
            }
            throw new NotImplementedException();
        }
    }

    public Domain AddDomain(DomainEnum denum, string pageNumbers = "Throughout")
    {
        var original = Ravenloftdb.Domains[denum];
        original.Appearances.Add(Source, new TrackPage<Domain>(original, Source, pageNumbers));
        return original;
    }

    public Location CreateLocation(string Name, string pageNumbers = "Throughout") => Create<Location>(EntityType.Location, Name, pageNumbers);
    public Location CreateSettlement(string Name, string pageNumbers = "Throughout")
    {
        var settlement = Create<Location>(EntityType.Location, Name, pageNumbers);
        return settlement;
    }

    public NPC CreateNPC(string Name, string pageNumbers = "Throughout") => Create<NPC>(EntityType.NPC, Name, pageNumbers);

    public Item CreateItem(string Name, string pageNumbers = "Throughout") => Create<Item>(EntityType.Item, Name, pageNumbers);

    public Group CreateGroup(string Name, string pageNumbers = "Throughout") => Create<Group>(EntityType.Group, Name, pageNumbers);

    public void CreateRelationship(NPC primary, string RelationshipType, NPC other)
    {
        var relationship = new NPC.Relationship(primary, RelationshipType, other);
        primary.Relationships[Source].Add(relationship);
        other.Relationships[Source].Add(relationship);
    }
}
