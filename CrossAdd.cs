internal static class Cross  
{
    public static void Add(Trait[] traits = null, Location[] locations = null, NPC[] npcs = null, Domain[] domains = null, Item[] items = null)
    {
        traits ??= new Trait[0];
        locations ??= new Location[0];
        npcs ??= new NPC[0];
        domains ??= new Domain[0];
        items ??= new Item[0];

        foreach (var trait in traits)
        {
            trait.Locations.AddRange(locations);
            trait.NPCs.AddRange(npcs);
            trait.Domains.AddRange(domains);
            trait.Items.AddRange(items);
        }
        foreach (var location in locations)
        {
            location.Traits.AddRange(traits);
            location.NPCs.AddRange(npcs);
            location.Domain = domains[0];
            location.Items.AddRange(items);
        }
        foreach (var npc in npcs)
        {
            npc.Locations.AddRange(locations);
            npc.Traits.AddRange(traits);
            npc.Domains.AddRange(domains);
            npc.Items.AddRange(items);
        }
        foreach (var domain in domains)
        {
            domain.Locations.AddRange(locations);
            domain.NPCs.AddRange(npcs);
            domain.Traits.AddRange(traits);
            domain.Items.AddRange(items);
        }
        foreach (var item in items)
        {
            item.Locations.AddRange(locations);
            item.NPCs.AddRange(npcs);
            item.Domains.AddRange(domains);
            item.Traits.AddRange(traits);
        }
    }
}
