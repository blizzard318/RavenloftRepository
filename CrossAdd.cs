using Mono.TextTemplating;
using System.Diagnostics.Metrics;
using static Factory;

public static class CrossAdd
{
    [ThreadStatic] public static Source Source;
    private static readonly List<Domain> domains = new(); //For trait distribution
    private static readonly List<Location> settlements = new(); //For trait distribution

    public static void Dispose()
    {
        foreach (var domain in domains)
        {
            //Do not bother doing this for Darklords cause they're already tracked within Characters.
            //so why does darklords exist? Its a cache cause darklords is referenced so often.
            //AddLanguages(domain.Locations);
            AddLanguages(domain.Characters);
            //AddLanguages(domain.Groups);
            //AddLanguages(domain.Items);
            void AddLanguages<T>(ToTrack<T> entity) where T : UseVariableName
            {
                if (!entity.PerSource.TryGetValue(Source, out var entities)) return;
                var languages = entities.Where(e => e.Languages.PerSource.ContainsKey(Source))
                    .SelectMany(e => e.Languages.PerSource[Source]);
                if (languages.Count() > 0) domain.BindLanguages(languages.ToArray());
            }
            AddCreatures(domain.Locations);
            AddCreatures(domain.Characters); //Do not add related creatures traits
            AddCreatures(domain.Groups);
            //AddCreatures(domain.Items);
            void AddCreatures<T>(ToTrack<T> entity) where T : UseVariableName
            {
                if (!entity.PerSource.TryGetValue(Source, out var entities)) return;
                var creatures = entities.Where(e => e.Creatures.PerSource.ContainsKey(Source))
                    .SelectMany(e => e.Creatures.PerSource[Source]);
                if (creatures.Count() > 0) domain.BindCreatures(creatures.ToArray());
            }
            //Consider doing this for Clusters, Mistways and anything else ToTrack.
            //That's if they ever get traits.
        }
        foreach (var settlement in settlements)
        {
            foreach (var location in settlement.Locations.PerSource[Source])
            {
                if (location.Characters.PerSource.TryGetValue(Source, out var value))
                    settlement.BindCharacters(value.ToArray());
            }
        }
        domains.Clear();
    }
    public static Location TrackMistway(this Location Mistway, string pageNumbers, Domain First, Domain Second)
    {
        Track(Mistway, pageNumbers);

        Mistway.Domains.PerSource.TryAdd(Source, new());
        Mistway.Domains.PerSource[Source].UnionWith(new[] { First, Second });

        First.Mistways.PerSource.TryAdd(Source, new());
        First.Mistways.PerSource[Source].Add(Mistway);

        Second.Mistways.PerSource.TryAdd(Source, new());
        Second.Mistways.PerSource[Source].Add(Mistway);
        return Mistway;
    }
    public static Group TrackCluster(this Group Cluster, string pageNumbers, params Domain[] domains)
    {
        Track(Cluster, pageNumbers);

        Cluster.Domains.PerSource.TryAdd(Source, new());
        foreach (var domain in domains)
        {
            Cluster.Domains.PerSource[Source].Add(domain);
            domain.Clusters.Add(Source, Cluster);
        }
        return Cluster;
    }

    private static TrackPage<T> Track<T> (T entity, string pageNumbers) where T : UseVariableName, IHasAppearances<T>
    {
        entity.Sources.Add(Source);
        entity.editions |= Source.Edition;
        entity.TypesOfSources.TryAdd(Source.Media, new());
        entity.TypesOfSources[Source.Media][Source.Edition]++;

        var tracker = new TrackPage<T>(entity, Source, pageNumbers);
        entity.Appearances.Add(Source, tracker);
        return tracker;
    }    
    public static Domain Appeared(this Domain domain, string pageNumbers = "Throughout")
    {
        domains.Add(domain);
        Ravenloftdb.Domains.Add(domain);
        Source.Domains.Add(Track(domain, pageNumbers));
        return domain;
    }
    public static Location AddSettlement(this Domain domain, Location location, string pageNumbers = "Throughout")
    {
        settlements.Add(location);
        Ravenloftdb.SettlementsPerDomain.TryAdd(domain, new());
        Ravenloftdb.SettlementsPerDomain[domain].Add(location);
        return domain.AddLocation(location, pageNumbers);
    }
    public static Location AddLocation(this Domain domain, Location location, string pageNumbers = "Throughout")
    {
        Source.Locations.Add(Track(location, pageNumbers));

        domain.Locations.Add(Source, location);
        location.Domains.Add(Source, domain);

        Ravenloftdb.LocationsPerDomain.TryAdd(domain, new());
        Ravenloftdb.LocationsPerDomain[domain].Add(location);
        return location;
    }
    private static Character AddCharacter(Domain domain, Character character, string pageNumbers)
    {
        Source.Characters.Add(Track(character, pageNumbers));

        domain.Characters.Add(Source, character);
        character.Domains.Add(Source, domain);

        Ravenloftdb.CharactersPerDomain.TryAdd(domain, new());
        Ravenloftdb.CharactersPerDomain[domain].Add(character);
        return character;
    }
    public static Character AddLivingCharacter(this Domain domain, Character character, string pageNumbers = "Throughout")
    {
        character.Deceased.TryAdd(Source, false);
        return AddCharacter(domain, character, pageNumbers);
    }
    public static Character AddDeadCharacter(this Domain domain, Character character, string pageNumbers = "Throughout")
    {
        character.Deceased.TryAdd(Source, true);
        return AddCharacter(domain, character, pageNumbers);
    }
    public static Domain.Darklord AddLivingDarklord(this Domain domain, Domain.Darklord darklord, string pageNumbers = "Throughout")
    {
        domain.Darklords.Add(Source, darklord);
        AddLivingCharacter(domain, darklord, pageNumbers);
        return darklord;
    }
    public static Domain.Darklord AddDeadDarklord(this Domain domain, Domain.Darklord darklord, string pageNumbers = "Throughout")
    {
        domain.Darklords.Add(Source, darklord);
        AddDeadCharacter(domain, darklord, pageNumbers);
        return darklord;
    }
    public static Item AddItem(this Domain domain, Item item, string pageNumbers = "Throughout")
    {
        Source.Items.Add(Track(item, pageNumbers));

        domain.Items.Add(Source, item);
        item.Domains.Add(Source, domain);

        Ravenloftdb.ItemsPerDomain.TryAdd(domain, new());
        Ravenloftdb.ItemsPerDomain[domain].Add(item);
        return item;
    }
    public static Group AddGroup(this Domain domain, Group group, string pageNumbers = "Throughout")
    {
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
            if (type == typeof(Location )) return array.Select(t => t.Locations ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Character)) return array.Select(t => t.Characters) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Item     )) return array.Select(t => t.Items     ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Group    )) return array.Select(t => t.Groups    ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Domain   )) return array.Select(t => t.Domains   ) as IEnumerable<ToTrack<T>>;
            throw new NotImplementedException();
        }
        ToTrack<U>? GetSetFromEntity()
        {
            var type = typeof(U);
            if (type == typeof(Location )) return entity.Locations  as ToTrack<U>;
            if (type == typeof(Character)) return entity.Characters as ToTrack<U>;
            if (type == typeof(Item     )) return entity.Items      as ToTrack<U>;
            if (type == typeof(Group    )) return entity.Groups     as ToTrack<U>;
            if (type == typeof(Domain   )) return entity.Domains    as ToTrack<U>;
            throw new NotImplementedException();
        }
    }
    public static T BindDomains   <T>(this T entity, params Domain   [] domains   ) where T : UseVariableName => Bind(entity, domains);
    public static T BindLocations <T>(this T entity, params Location [] locations ) where T : UseVariableName => Bind(entity, locations);
    public static T BindLocations <T>(this T entity, ToTrack<Location> locations ) where T : UseVariableName => Bind(entity, locations.PerSource[Source].ToArray());
    public static T BindCharacters<T>(this T entity, params Character[] characters) where T : UseVariableName => Bind(entity, characters);
    public static T BindItems     <T>(this T entity, params Item     [] items     ) where T : UseVariableName => Bind(entity, items);
    public static T BindGroups    <T>(this T entity, params Group    [] groups    ) where T : UseVariableName => Bind(entity, groups);
    public static void BindDomainsToCluster (this Group Cluster, params Domain[] domains)
    {
        Cluster.Domains.PerSource.TryAdd(Source, new());
        foreach (var domain in domains)
        {
            Cluster.Domains.PerSource[Source].Add(domain);
            domain.Clusters.PerSource.TryAdd(Source, new());
            domain.Clusters.PerSource[Source].Add(Cluster);
        }
    }

    public static T BindCreatures<T>(this T entity, params Trait[] creatures) where T : UseVariableName
    {
        entity.Creatures.Add(Source, creatures);
        Source.Creatures.UnionWith(creatures);
        foreach (var creature in creatures)
        {
            creature.Sources.Add(Source);
            creature.editions |= Source.Edition;
        }

        var list = GetSetFromArray();
        foreach (var set in list) set.Add(Source, entity);

        return entity;

        IEnumerable<ToTrack<T>>? GetSetFromArray()
        {
            var type = typeof(T);
            if (type == typeof(Item     )) return creatures.Select(t => t.Items     ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Group    )) return creatures.Select(t => t.Groups    ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Domain   )) return creatures.Select(t => t.Domains   ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Location )) return creatures.Select(t => t.Locations ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Character)) return creatures.Select(t => t.Characters) as IEnumerable<ToTrack<T>>;
            throw new NotImplementedException();
        }
    }
    public static Domain BindCreatures(this Domain domain, params Trait[] creatures)
    {
        BindCreatures<Domain>(domain, creatures);

        Ravenloftdb.CreaturesPerDomain.TryAdd(domain, new());
        foreach (var creature in creatures)
        {
            Ravenloftdb.CreaturesPerDomain[domain].Add(creature);
            Ravenloftdb.DomainsPerCreature.TryAdd(creature, new());
            Ravenloftdb.DomainsPerCreature[creature].Add(domain);
        }

        return domain;
    }
    //For like underlings, use bindCreatures for direct traits
    public static T BindRelatedCreatures<T>(this T Character, params Trait[] creatures) where T : Character
    {
        Character.RelatedCreatures.Add(Source, creatures);
        Source.Creatures.UnionWith(creatures);
        foreach (var creature in creatures)
        {
            creature.Sources.Add(Source);
            creature.editions |= Source.Edition;
        }
        return Character;
    }
    public static T BindLanguages<T>(this T entity, params Trait[] languages) where T : UseVariableName
    {
        entity.Languages.Add(Source, languages);
        Source.Languages.UnionWith(languages);
        foreach (var language in languages)
        {
            language.editions |= Source.Edition;
            language.Sources.Add(Source);
        }

        var list = GetSetFromArray();
        foreach (var set in list) set.Add(Source, entity);

        return entity;

        IEnumerable<ToTrack<T>>? GetSetFromArray()
        {
            var type = typeof(T);
            if (type == typeof(Trait    )) return languages.Select(t => t.Items     ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Group    )) return languages.Select(t => t.Groups    ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Domain   )) return languages.Select(t => t.Domains   ) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Character)) return languages.Select(t => t.Characters) as IEnumerable<ToTrack<T>>;
            throw new NotImplementedException();
        }
    }
    public static Domain BindLanguages(this Domain domain, params Trait[] languages)
    {
        domain.Languages.Add(Source, languages);
        Source.Languages.UnionWith(languages);

        Ravenloftdb.LanguagesPerDomain.TryAdd(domain, new());
        foreach (var language in languages)
        {
            language.editions |= Source.Edition;
            language.Sources.Add(Source);
            language.Domains.Add(Source, domain);
            Ravenloftdb.LanguagesPerDomain[domain].Add(language);
            Ravenloftdb.DomainsPerLanguage.TryAdd(language, new());
            Ravenloftdb.DomainsPerLanguage[language].Add(domain);
        }
        return domain;
    }

    public static T BindAlignment<T>(this T entity, Alignment alignment) where T : IHasAlignment
    {
        entity.AlignmentPerSource[Source] = alignment;
        return entity;
    }
    public static T BindSetting<T>(this T entity, params Trait[] settings) where T : UseVariableName
    {
        foreach (var item in GetSetFromArray()) item.Add(Source, entity);
        foreach (var setting in settings) setting.Sources.Add(Source);
        entity.Settings.UnionWith(settings);
        return entity;

        IEnumerable<ToTrack<T>>? GetSetFromArray()
        {
            var type = typeof(T);
            if (type == typeof(Item)) return settings.Select(t => t.Items) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Group)) return settings.Select(t => t.Groups) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Domain)) return settings.Select(t => t.Domains) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Location)) return settings.Select(t => t.Locations) as IEnumerable<ToTrack<T>>;
            if (type == typeof(Character)) return settings.Select(t => t.Characters) as IEnumerable<ToTrack<T>>;
            throw new NotImplementedException();
        }
    }

    public static Domain.Darklord BindCloseBorder (this Domain.Darklord darklord, string CloseBorder)
    {
        darklord.CloseBorder.Add(Source, CloseBorder);
        return darklord;
    }
    public static Domain.Darklord BindCurse (this Domain.Darklord darklord, string Curse)
    {
        darklord.Curse.Add(Source, Curse);
        return darklord;
    }
    public static Domain.Darklord BindLair (this Domain.Darklord darklord, Location DarklordLair)
        => Bind(darklord, darklord.DarklordLair = DarklordLair);

    /*public void CreateRelationship(Character primary, string RelationshipType, Character other)
    {
        var relationship = new Character.Relationship(primary, RelationshipType, other);
        primary.Relationships[Source].Add(relationship);
        other.Relationships[Source].Add(relationship);
    }*/
}