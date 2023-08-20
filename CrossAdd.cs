internal static class Cross
{
    public static Location AddTraits (this Location location, params Trait[] traits)
    {
        location.Traits.AddRange(traits);
        foreach (var trait in traits) trait.Locations.Add(location);
        return location;
    }
    public static Location AddNPCs (this Location location, params NPC[] npcs)
    {
        location.NPCs.AddRange(npcs);
        foreach (var npc in npcs) npc.Locations.Add(location);
        return location;
    }
    public static Location AddDomains (this Location location, params Domain[] domains)
    {
        location.Domains.AddRange(domains);
        foreach (var domain in domains) domain.Locations.Add(location);
        return location;
    }
    public static Location AddInfo (this Location location, string ExtraInfo)
    {
        location.ExtraInfo = ExtraInfo;
        return location;
    }
    


    public static NPC AddTraits (this NPC npc, params Trait[] traits)
    {
        npc.Traits.AddRange(traits);
        foreach (var trait in traits) trait.NPCs.Add(npc);
        return npc;
    }
    public static NPC AddLocations (this NPC npc, params Location[] locations)
    {
        npc.Locations.AddRange(locations);
        foreach (var location in locations) location.NPCs.Add(npc);
        return npc;
    }
    public static NPC AddDomains (this NPC npc, params Domain[] domains)
    {
        npc.Domains.AddRange(domains);
        foreach (var domain in domains) domain.NPCs.Add(npc);
        return npc;
    }
    public static NPC AddInfo(this NPC npc, string ExtraInfo)
    {
        npc.ExtraInfo = ExtraInfo;
        return npc;
    }



    public static Domain AddTraits (this Domain domain, params Trait[] traits)
    {
        domain.Traits.AddRange(traits);
        foreach (var trait in traits) trait.Domains.Add(domain);
        return domain;
    }
    public static Domain AddLocations (this Domain domain, params Location[] locations)
    {
        domain.Locations.AddRange(locations);
        foreach (var location in locations) location.Domains.Add(domain);
        return domain;
    }
    public static Domain AddNPCs (this Domain domain, params NPC[] npcs)
    {
        domain.NPCs.AddRange(npcs);
        foreach (var npc in npcs) npc.Domains.Add(domain);
        return domain;
    }
    public static Domain AddItems (this Domain domain, params Item[] items)
    {
        domain.Items.AddRange(items);
        foreach (var item in items) item.Domains.Add(domain);
        return domain;
    }
    public static Domain AddInfo(this Domain domain, string ExtraInfo)
    {
        domain.ExtraInfo = ExtraInfo;
        return domain;
    }



    public static Item AddTraits (this Item item, params Trait[] traits)
    {
        item.Traits.AddRange(traits);
        foreach (var trait in traits) trait.Items.Add(item);
        return item;
    }
    public static Item AddDomains (this Item item, params Domain[] domains)
    {
        item.Domains.AddRange(domains);
        foreach (var domain in domains) domain.Items.Add(item);
        return item;
    }
    public static Item AddInfo(this Item item, string ExtraInfo)
    {
        item.ExtraInfo = ExtraInfo;
        return item;
    }
}
