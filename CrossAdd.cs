internal static class Cross
{
    public static Location AddTraits (this Location location, params Trait[] traits)
    {
        foreach (var trait in traits)
        {
            location.Traits.Add(trait);
            trait.Locations.Add(location);
        }
        return location;
    }
    public static Location AddNPCs (this Location location, params NPC[] npcs)
    {
        foreach (var npc in npcs)
        {
            location.NPCs.Add(npc);
            npc.Locations.Add(location);
        }
        return location;
    }
    public static Location AddDomains (this Location location, params Domain[] domains)
    {
        foreach (var domain in domains)
        {
            location.Domains.Add(domain);
            domain.Locations.Add(location);
        }
        return location;
    }
    public static Location AddInfo (this Location location, string ExtraInfo)
    {
        location.ExtraInfo = ExtraInfo;
        return location;
    }



    public static NPC AddTraits (this NPC npc, params Trait[] traits)
    {
        foreach (var trait in traits)
        {
            npc.Traits.Add(trait);
            trait.NPCs.Add(npc);
        }
        return npc;
    }
    public static NPC AddLocations (this NPC npc, params Location[] locations)
    {
        foreach (var location in locations)
        {
            npc.Locations.Add(location);
            location.NPCs.Add(npc);
        }
        return npc;
    }
    public static NPC AddDomains (this NPC npc, params Domain[] domains)
    {
        foreach (var domain in domains)
        {
            npc.Domains.Add(domain);
            domain.NPCs.Add(npc);
        }
        return npc;
    }
    public static NPC AddInfo(this NPC npc, string ExtraInfo)
    {
        npc.ExtraInfo = ExtraInfo;
        return npc;
    }



    public static Domain AddTraits(this Domain domain, params Trait[] traits)
    {
        foreach (var trait in traits)
        {
            domain.Traits.Add(trait);
            trait.Domains.Add(domain);
        }
        return domain;
    }
    public static Domain AddLocations (this Domain domain, params Location[] locations)
    {
        foreach (var location in locations)
        {
            domain.Locations.Add(location);
            location.Domains.Add(domain);
        }
        return domain;
    }
    public static Domain AddNPCs (this Domain domain, params NPC[] npcs)
    {
        foreach (var npc in npcs)
        {
            domain.NPCs.Add(npc);
            npc.Domains.Add(domain);
        }
        return domain;
    }
    public static Domain AddItems (this Domain domain, params Item[] items)
    {
        foreach (var item in items)
        {
            domain.Items.Add(item);
            item.Domains.Add(domain);
        }
        return domain;
    }
    public static Domain AddInfo(this Domain domain, string ExtraInfo)
    {
        domain.ExtraInfo += ExtraInfo;
        return domain;
    }



    public static Item AddTraits (this Item item, params Trait[] traits)
    {
        foreach (var trait in traits)
        {
            item.Traits.Add(trait);
            trait.Items.Add(item);
        }
        return item;
    }
    public static Item AddDomains (this Item item, params Domain[] domains)
    {
        foreach (var domain in domains)
        {
            item.Domains.Add(domain);
            domain.Items.Add(item);
        }
        return item;
    }
    public static Item AddInfo(this Item item, string ExtraInfo)
    {
        item.ExtraInfo = ExtraInfo;
        return item;
    }

    /*public static Trait AddDomains (this Trait trait, params Domain[] domains)
    {
        foreach (var domain in domains)
        {
            trait.Domains.Add(domain);
            domain.Traits.Add(trait);
        }
        return trait;
    }
    public static Trait AddLocations (this Trait trait, params Location[] locations)
    {
        foreach (var location in locations)
        {
            trait.Locations.Add(location);
            location.Traits.Add(trait);
        }
        return trait;
    }
    public static Trait AddItems (this Trait trait, params Item[] items)
    {
        foreach (var item in items)
        {
            trait.Items.Add(item);
            item.Traits.Add(trait);
        }
        return trait;
    }
    public static Trait AddNPCs (this Trait trait, params NPC[] npcs)
    {
        foreach (var npc in npcs)
        {
            trait.NPCs.Add(npc);
            npc.Traits.Add(trait);
        }
        return trait;
    }*/
}
