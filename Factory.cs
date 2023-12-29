//This script is for creating stuff to the database
//Adding stuff to the newly created stuff is handled in CrossAdd.cs

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
                case EntityType.Domain  : return Ravenloftdb.Domains    as SortedDictionary<string, T>;
                case EntityType.Location: return Ravenloftdb.Locations  as SortedDictionary<string, T>;
                case EntityType.Item    : return Ravenloftdb.Items      as SortedDictionary<string, T>;
                case EntityType.NPC     : return Ravenloftdb.Characters as SortedDictionary<string, T>;
                case EntityType.Group   : return Ravenloftdb.Groups     as SortedDictionary<string, T>;
            }
            throw new NotImplementedException();
        }
    }

    public UseVariableName CreateLocation(string originalName, string pageNumbers = "Throughout") => Create<Location>(EntityType.Location, originalName, pageNumbers);

    public NPC CreateNPC(string originalName, string pageNumbers = "Throughout") => Create<NPC>(EntityType.NPC, originalName, pageNumbers);

    public UseVariableName CreateItem(string originalName, string pageNumbers = "Throughout") => Create<Item>(EntityType.Item, originalName, pageNumbers);

    public UseVariableName CreateGroup(string originalName, string pageNumbers = "Throughout") => Create<Group>(EntityType.Group, originalName, pageNumbers);

    public void CreateRelationship(NPC primary, string RelationshipType, NPC other)
    {
        var relationship = new NPC.Relationship(primary, RelationshipType, other);
        primary.Relationships[Source].Add(relationship);
        other.Relationships[Source].Add(relationship);
    }
}
