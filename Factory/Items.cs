public partial class Factory : IDisposable
{
    internal static class ItemEnum
    {
        private static Item CreateItem(params string[] names)
        {
            var retval = new Item();
            retval.Names.UnionWith(names);
            return retval;
        }
        public readonly static Item Chosen = CreateItem("Chosen");
        public readonly static Item Sunsword = CreateItem("Sunsword");
        public readonly static Item AmuletOfLight = CreateItem("Amulet of Light");
        public readonly static Item SymbolOfRaven = CreateItem("Holy Medallion of Ravenkind", "Holy Symbol of Ravenkind");
        public readonly static Item IconOfRaven = CreateItem("Icon of Ravenloft");
        public readonly static Item TomeOfStrahd = CreateItem("Tome of Strahd");

        public readonly static Item Luckstone = CreateItem("Luckstone");
        public readonly static Item Decanter = CreateItem("Decanter of Endless Water");

        public readonly static Item WandOfMM = CreateItem("Wand of Magic Missiles");

        public readonly static Item PotOfHeal = CreateItem("Potion of Healing");

        public readonly static Item VialOfHolyWater = CreateItem("Vial of Holy Water");

        public readonly static Item EmbalmTheLostArt = CreateItem("Embalming, The Lost Art");
        public readonly static Item LifeAmongUndead = CreateItem("Life Among the Undead: Learning to Cope");
        public readonly static Item IdentifyBloodTypes = CreateItem("Identifying Blood Types: A Beginners' Handbook");
        public readonly static Item MasonryWoodwork = CreateItem("Masonry and Woodworking");
    }
}