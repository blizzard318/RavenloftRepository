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
        var tracker = new TrackPage<Domain>(original, Source, pageNumbers);

        original.Appearances.Add(Source, tracker);
        Source.Domains.Add(tracker);

        return original;
    }
    public void AddLocation(DomainEnum denum, Location location, string pageNumbers = "Throughout")
    {
        Ravenloftdb.Locations.Add(location);
        var tracker = new TrackPage<Location>(location, Source, pageNumbers);

        var domain = Ravenloftdb.Domains[denum];
        domain.Locations.Add(Source, location);
        location.Domains.Add(Source, domain);

        location.Appearances.Add(Source, tracker);
        Source.Locations.Add(tracker);

        Ravenloftdb.LocationsPerDomain.TryAdd(denum, new ());
        Ravenloftdb.LocationsPerDomain[denum].Add(location);
    }
    public void AddSettlement (DomainEnum denum, Location location, string pageNumbers = "Throughout")
    {
        AddLocation(denum, location, pageNumbers);

        Ravenloftdb.SettlementsPerDomain.TryAdd(denum, new ());
        Ravenloftdb.SettlementsPerDomain[denum].Add(location);
    }

    private void AddCharacter(DomainEnum denum, NPC character, string pageNumbers)
    {
        Ravenloftdb.Characters.Add(character);
        var tracker = new TrackPage<NPC>(character, Source, pageNumbers);

        var domain = Ravenloftdb.Domains[denum];
        domain.Characters.Add(Source, character);
        character.Domains.Add(Source, domain);

        character.Appearances.Add(Source, tracker);
        Source.Characters.Add(tracker);

        Ravenloftdb.CharactersPerDomain.TryAdd(denum, new());
        Ravenloftdb.CharactersPerDomain[denum].Add(character);
    }
    public void AddLivingCharacter(DomainEnum denum, NPC character, string pageNumbers = "Throughout")
    {
        AddCharacter(denum, character, pageNumbers);
        character.Deceased.TryAdd(Source, false);
    }
    public void AddDeadCharacter(DomainEnum denum, NPC character, string pageNumbers = "Throughout")
    {
        AddCharacter(denum, character, pageNumbers);
        character.Deceased.TryAdd(Source, true);
    }

    public void AddItem(DomainEnum denum, Item item, string pageNumbers = "Throughout")
    {
        Ravenloftdb.Items.Add(item);
        var tracker = new TrackPage<Item>(item, Source, pageNumbers);

        var domain = Ravenloftdb.Domains[denum];
        domain.Items.Add(Source, item);
        item.Domains.Add(Source, domain);

        item.Appearances.Add(Source, tracker);
        Source.Items.Add(tracker);

        Ravenloftdb.ItemsPerDomain.TryAdd(denum, new());
        Ravenloftdb.ItemsPerDomain[denum].Add(item);
    }

    public void AddGroup(DomainEnum denum, Group group, string pageNumbers = "Throughout")
    {
        Ravenloftdb.Groups.Add(group);
        var tracker = new TrackPage<Group>(group, Source, pageNumbers);

        var domain = Ravenloftdb.Domains[denum];
        domain.Groups.Add(Source, group);
        group.Domains.Add(Source, domain);

        group.Appearances.Add(Source, tracker);
        Source.Groups.Add(tracker);

        Ravenloftdb.GroupsPerDomain.TryAdd(denum, new());
        Ravenloftdb.GroupsPerDomain[denum].Add(group);
    }

    public void Bind<T, U> (T Entity, params U[] ToAdd) where T : UseVariableName where U : UseVariableName
    {
        ToTrack<U> GetSetFromEntity()
        {
            var type = typeof(U);
            if (type == typeof(Location)) return Entity.Locations  as ToTrack<U>;
            if (type == typeof(Domain  )) return Entity.Domains    as ToTrack<U>;
            if (type == typeof(NPC     )) return Entity.Characters as ToTrack<U>;
            if (type == typeof(Item    )) return Entity.Items      as ToTrack<U>;
            if (type == typeof(Group   )) return Entity.Groups     as ToTrack<U>;
            throw new NotImplementedException();
        }
    }
    public void BindDomains<T> (T Entity, params Domain[] domains) where T : UseVariableName => Entity.Domains.Add(Source, domains);
    public void BindLocations<T> (T Entity, params Location[] locations) where T : UseVariableName => Entity.Locations.Add(Source, locations);
    public void BindItems<T> (T Entity, params Item[] items) where T : UseVariableName => Entity.Items.Add(Source, items);
    public void BindCharacters<T> (T Entity, params NPC[] characters) where T : UseVariableName => Entity.Characters.Add(Source, characters);
    public void BindGroups<T> (T Entity, params Group[] groups) where T : UseVariableName => Entity.Groups.Add(Source, groups);
    public void BindCreatures<T> (T Entity, params Trait[] creatures) where T : UseVariableName
    {
        Ravenloftdb.Creatures.UnionWith(creatures);
        Entity.Creatures.Add(Source, creatures);
        Source.Creatures.UnionWith(creatures);
    }

    public void CreateRelationship(NPC primary, string RelationshipType, NPC other)
    {
        var relationship = new NPC.Relationship(primary, RelationshipType, other);
        primary.Relationships[Source].Add(relationship);
        other.Relationships[Source].Add(relationship);
    }
}
