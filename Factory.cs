//This script is for creating stuff to the database
//Adding stuff to the newly created stuff is handled in CrossAdd.cs

using static Factory;

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

    public void AddDomain(DomainEnum denum, string pageNumbers = "Throughout")
    {
        var original = Ravenloftdb.Domains[denum];
        var tracker = new TrackPage<Domain>(original, Source, pageNumbers);

        original.Appearances.Add(Source, tracker);
        Source.Domains.Add(tracker);
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

    public void Bind<T, U> (T entity, params U[] array) where T : UseVariableName where U : UseVariableName
    {
        var list = GetSetFromArray();
        foreach (var set in list) set.Add(Source, entity);

        var otherlist = GetSetFromEntity();
        foreach (var instance in array) otherlist.Add(Source, instance);

        IEnumerable<ToTrack<T>>? GetSetFromArray()
        {
            var type = typeof(T);
            if (type == typeof(Location)) return array.Select(t => t.Locations ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Domain  )) return array.Select(t => t.Domains   ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(NPC     )) return array.Select(t => t.Characters) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Item    )) return array.Select(t => t.Items     ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Group   )) return array.Select(t => t.Groups    ) as IEnumerable<ToTrack<T>>;
            throw new NotImplementedException();
        }
        ToTrack<U> GetSetFromEntity()
        {
            var type = typeof(U);
            if (type == typeof(Location)) return entity.Locations  as ToTrack<U>;
            if (type == typeof(Domain  )) return entity.Domains    as ToTrack<U>;
            if (type == typeof(NPC     )) return entity.Characters as ToTrack<U>;
            if (type == typeof(Item    )) return entity.Items      as ToTrack<U>;
            if (type == typeof(Group   )) return entity.Groups     as ToTrack<U>;
            throw new NotImplementedException();
        }
    }

    public void BindCreatures(DomainEnum denum, params Trait[] creatures) => BindCreatures(Ravenloftdb.Domains[denum], creatures);
    public void BindCreatures<T> (T Entity, params Trait[] creatures) where T : UseVariableName
    {
        Ravenloftdb.Creatures.UnionWith(creatures);
        Entity.Creatures.Add(Source, creatures);
        Source.Creatures.UnionWith(creatures);
    }    
    public void BindCreatures (NPC Character, params Trait[] creatures)
    {
        Ravenloftdb.Creatures.UnionWith(creatures);
        Character.Creatures.Add(Source, creatures);
        Source.Creatures.UnionWith(creatures);
        foreach (var creature in creatures) Ravenloftdb.CharactersPerCreature[creature].Add(Character);
    }
    public void BindRelatedCreatures (NPC character, params Trait[] creatures)
    {
        Ravenloftdb.Creatures.UnionWith(creatures);
        character.RelatedCreatures.Add(Source, creatures);
        Source.Creatures.UnionWith(creatures);
    }

    public void BindAlignment (NPC character, Alignment alignment) => character.AlignmentPerSource[Source] = alignment;
    public void BindAlignment (Item item, Alignment alignment) => item.AlignmentPerSource[Source] = alignment;

    public void CreateRelationship(NPC primary, string RelationshipType, NPC other)
    {
        var relationship = new NPC.Relationship(primary, RelationshipType, other);
        primary.Relationships[Source].Add(relationship);
        other.Relationships[Source].Add(relationship);
    }
}
