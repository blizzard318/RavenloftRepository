interface IHasEntity<T> { T Entity { get; set; } }
interface IHasDomains { HashSet<Domain> Domains { get; set; } };
interface IHasLocations { HashSet<Location> Locations { get; set; } };
interface IHasItems { HashSet<Item> Items { get; set; } };
interface IHasNPCs { HashSet<NPC> NPCs { get; set; } };
interface IHasGroups { HashSet<Group> Groups { get; set; } };