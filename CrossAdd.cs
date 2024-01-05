using static Factory;

public static class CrossAdd
{
    public static Source Source;
    private static readonly List<Domain> domains = new(); //For trait distribution

    public static void Dispose()
    {
        foreach (var domain in domains)
        {
            //Do not bother doing this for Darklords cause they're already tracked within Characters.
            //so why does darklords exist? Its a cache cause darklords is referenced so often.
            AddLanguages(domain.Locations);
            AddLanguages(domain.Characters);
            AddLanguages(domain.Groups);
            AddLanguages(domain.Items);
            void AddLanguages<T>(ToTrack<T> entity) where T : UseVariableName
            {
                var languages = entity.PerSource[Source].SelectMany(e => e.Languages.PerSource[Source]);
                domain.Languages.Add(Source, languages);
                foreach (var language in languages)
                {
                    Ravenloftdb.DomainsPerLanguage[language].Add(domain);
                    Ravenloftdb.LanguagesPerDomain[domain].Add(language);
                }
            }

            AddCreatures(domain.Locations);
            AddCreatures(domain.Characters); //Do not add related creatures traits
            AddCreatures(domain.Groups);
            AddCreatures(domain.Items);
            void AddCreatures<T>(ToTrack<T> entity) where T : UseVariableName
            {
                var creatures = entity.PerSource[Source].SelectMany(e => e.Creatures.PerSource[Source]);
                domain.Creatures.Add(Source, creatures);
                foreach (var creature in creatures)
                {
                    Ravenloftdb.DomainsPerCreature[creature].Add(domain);
                    Ravenloftdb.CreaturesPerDomain[domain].Add(creature);
                }
            }
            //Consider doing this for Clusters, Mistways and anything else ToTrack.
            //That's if they ever get traits.
        }
        domains.Clear();
    }

    public static void TrackMistway(this Location Mistway, string pageNumbers, Domain First, Domain Second)
    {
        Mistway.Appearances.Add(Source, new TrackPage<Location>(Mistway, Source, pageNumbers));
        Mistway.editions |= Source.editions;

        Mistway.Domains.PerSource.TryAdd(Source, new());
        Mistway.Domains.PerSource[Source].Add(First);
        Mistway.Domains.PerSource[Source].Add(Second);

        First.Mistways.PerSource.TryAdd(Source, new());
        First.Mistways.PerSource[Source].Add(Mistway);

        Second.Mistways.PerSource.TryAdd(Source, new());
        Second.Mistways.PerSource[Source].Add(Mistway);
    }
    public static void TrackCluster(this Group Cluster, string pageNumbers, params Domain[] domains)
    {
        Cluster.Appearances.Add(Source, new TrackPage<Group>(Cluster, Source, pageNumbers));
        Cluster.editions |= Source.editions;

        Cluster.Domains.PerSource.TryAdd(Source, new());
        foreach (var domain in domains)
        {
            Cluster.Domains.PerSource[Source].Add(domain);
            domain.Clusters.Add(Source, Cluster);
        }
    }

    private static TrackPage<T> Track<T> (T entity, string pageNumbers) where T : UseVariableName, IHasAppearances<T>
    {
        entity.editions |= Source.editions;

        var tracker = new TrackPage<T>(entity, Source, pageNumbers);
        entity.Appearances.Add(Source, tracker);
        return tracker;
    }    
    public static Domain Appeared(this Domain domain, string pageNumbers = "Throughout")
    {
        Ravenloftdb.Domains.Add(domain);
        Source.Domains.Add(Track(domain, pageNumbers));
        return domain;
    }
    public static Location AddSettlement(this Domain domain, Location location, string pageNumbers = "Throughout")
    {
        Ravenloftdb.SettlementsPerDomain.TryAdd(domain, new());
        Ravenloftdb.SettlementsPerDomain[domain].Add(location);
        return domain.AddLocation(location, pageNumbers);
    }
    public static Location AddLocation(this Domain domain, Location location, string pageNumbers = "Throughout")
    {
        Ravenloftdb.Locations.Add(location);
        Source.Locations.Add(Track(location, pageNumbers));

        domain.Locations.Add(Source, location);
        location.Domains.Add(Source, domain);

        Ravenloftdb.LocationsPerDomain.TryAdd(domain, new());
        Ravenloftdb.LocationsPerDomain[domain].Add(location);
        return location;
    }
    private static NPC AddCharacter(Domain domain, NPC character, string pageNumbers)
    {
        Ravenloftdb.Characters.Add(character);
        Source.Characters.Add(Track(character, pageNumbers));

        domain.Characters.Add(Source, character);
        character.Domains.Add(Source, domain);

        Ravenloftdb.CharactersPerDomain.TryAdd(domain, new());
        Ravenloftdb.CharactersPerDomain[domain].Add(character);
        return character;
    }
    public static NPC AddLivingCharacter(this Domain domain, NPC character, string pageNumbers = "Throughout")
    {
        character.Deceased.TryAdd(Source, false);
        return AddCharacter(domain, character, pageNumbers);
    }
    public static NPC AddDeadCharacter(this Domain domain, NPC character, string pageNumbers = "Throughout")
    {
        character.Deceased.TryAdd(Source, true);
        return AddCharacter(domain, character, pageNumbers);
    }
    public static Item AddItem(this Domain domain, Item item, string pageNumbers = "Throughout")
    {
        Ravenloftdb.Items.Add(item);
        Source.Items.Add(Track(item, pageNumbers));

        domain.Items.Add(Source, item);
        item.Domains.Add(Source, domain);

        Ravenloftdb.ItemsPerDomain.TryAdd(domain, new());
        Ravenloftdb.ItemsPerDomain[domain].Add(item);
        return item;
    }
    public static Group AddGroup(this Domain domain, Group group, string pageNumbers = "Throughout")
    {
        Ravenloftdb.Groups.Add(group);
        Source.Groups.Add(Track(group, pageNumbers));

        domain.Groups.Add(Source, group);
        group.Domains.Add(Source, domain);

        Ravenloftdb.GroupsPerDomain.TryAdd(domain, new());
        Ravenloftdb.GroupsPerDomain[domain].Add(group);
        return group;
    }

    private static T Bind<T, U>(T entity, params U[] array) where T : UseVariableName where U : UseVariableName
    {
        var list = GetSetFromArray();
        foreach (var set in list) set.Add(Source, entity);

        var otherlist = GetSetFromEntity();
        foreach (var instance in array) otherlist.Add(Source, instance);
        return entity;

        IEnumerable<ToTrack<T>>? GetSetFromArray()
        {
            var type = typeof(T);
            if (type == typeof(Domain)) return array.Select(t => t.Domains) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Location)) return array.Select(t => t.Locations) as IEnumerable<ToTrack<T>>;
            if (type == typeof(NPC)) return array.Select(t => t.Characters) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Item)) return array.Select(t => t.Items) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Group)) return array.Select(t => t.Groups) as IEnumerable<ToTrack<T>>;
            throw new NotImplementedException();
        }
        ToTrack<U>? GetSetFromEntity()
        {
            var type = typeof(U);
            if (type == typeof(Domain)) return entity.Domains as ToTrack<U>;
            if (type == typeof(Location)) return entity.Locations as ToTrack<U>;
            if (type == typeof(NPC)) return entity.Characters as ToTrack<U>;
            if (type == typeof(Item)) return entity.Items as ToTrack<U>;
            if (type == typeof(Group)) return entity.Groups as ToTrack<U>;
            throw new NotImplementedException();
        }
    }
    public static T BindDomains   <T>(this T entity, params Domain  [] domains   ) where T : UseVariableName => Bind(entity, domains);
    public static T BindLocations <T>(this T entity, params Location[] locations ) where T : UseVariableName => Bind(entity, locations);
    public static T BindCharacters<T>(this T entity, params NPC     [] characters) where T : UseVariableName => Bind(entity, characters);
    public static T BindItems     <T>(this T entity, params Item    [] items     ) where T : UseVariableName => Bind(entity, items);
    public static T BindGroups    <T>(this T entity, params Group   [] groups    ) where T : UseVariableName => Bind(entity, groups);
    public static void BindDomains (this Group Cluster, params Domain[] domains)
    {
        Cluster.Domains.PerSource.TryAdd(Source, new());
        foreach (var domain in domains)
        {
            Cluster.Domains.PerSource[Source].Add(domain);
            domain.Clusters.PerSource.TryAdd(Source, new());
            domain.Clusters.PerSource[Source].Add(Cluster);
        }
    }

    public static T BindCreatures<T>(this T Entity, params Trait[] creatures) where T : UseVariableName
    {
        Ravenloftdb.Creatures.UnionWith(creatures);
        Entity.Creatures.Add(Source, creatures);
        Source.Creatures.UnionWith(creatures);
        return Entity;
    }
    public static NPC BindLanguages(this NPC Character, params Trait[] languages)
    {
        Ravenloftdb.Languages.UnionWith(languages);
        Character.Languages.Add(Source, languages);
        Source.Languages.UnionWith(languages);
        return Character;
    }
    public static NPC BindRelatedCreatures(this NPC Character, params Trait[] creatures)
    {
        Ravenloftdb.Creatures.UnionWith(creatures);
        Character.RelatedCreatures.Add(Source, creatures);
        Source.Creatures.UnionWith(creatures);
        return Character;
    }

    public static T BindAlignment<T>(this T entity, Alignment alignment) where T : IHasAlignment
    {
        entity.AlignmentPerSource[Source] = alignment;
        return entity;
    }

    public static void PopulateSettlement (this Location Settlement, params Location[] locations)
    {
        Settlement.BindLocations(locations);
        foreach (var location in locations) Settlement.BindCharacters(location.Characters.PerSource[Source].ToArray());
    }

    /*public void CreateRelationship(NPC primary, string RelationshipType, NPC other)
    {
        var relationship = new NPC.Relationship(primary, RelationshipType, other);
        primary.Relationships[Source].Add(relationship);
        other.Relationships[Source].Add(relationship);
    }*/
}