public partial class Factory : IDisposable
{
    internal static class ItemEnum
    {
        private static Item CreateItem(params string[] names)
        {
            var retval = new Item(names);
            Ravenloftdb.Items.Add(retval);
            return retval;
        }
        public readonly static Item Chosen = CreateItem("Chosen");
        public readonly static Item Sunsword = CreateItem("Sunsword");
        public readonly static Item SymbolOfRaven = CreateItem("Holy Medallion of Ravenkind", "Holy Symbol of Ravenkind");
        public readonly static Item IconOfRaven = CreateItem("Icon of Ravenloft");
        public readonly static Item TomeOfStrahd = CreateItem("Tome of Strahd");

        public readonly static Item Luckstone = CreateItem("Luckstone");
        public readonly static Item CursedBerserker = CreateItem("Sword Cursed Berserker");
        public readonly static Item Decanter = CreateItem("Decanter of Endless Water");
        public readonly static Item VialOfHolyWater = CreateItem("Vial of Holy Water");
        public readonly static Item GauntletsOfOgrePower = CreateItem("Gauntlets of Ogre Power");

        public readonly static Item TalismanOfUltimateEvil = CreateItem("Talisman of Ultimate Evil");

        public readonly static Item AmuletOfLight = CreateItem("Amulet of Light");
        public readonly static Item AmuletOfProof = CreateItem("Amulet of Proof against Detection and Location");

        public readonly static Item CloakOfProtection = CreateItem("Cloak of Protection");

        public readonly static Item BracersOfDefense = CreateItem("Bracers of Defense");

        public readonly static Item RodOfSmite = CreateItem("Rod of Smiting");
        public readonly static Item RodOfFlail = CreateItem("Rod of Flailing");

        public readonly static Item StaffOfTheSerpent = CreateItem("Staff of the Serpent");
        public readonly static Item StaffOfThunderAndLightning = CreateItem("Staff of Thunder and Lightning");

        public readonly static Item RingOfShoot = CreateItem("Ring of Shooting Stars");
        public readonly static Item RingOfFreeAct = CreateItem("Ring of Free Action");
        public readonly static Item RingOfSpellStoring = CreateItem("Ring of Spell Storing");

        public readonly static Item WandOfMM = CreateItem("Wand of Magic Missiles");

        public readonly static Item PotOfHeal = CreateItem("Potion of Healing");
        public readonly static Item ElixirOfMadness = CreateItem("Elixir of Madness");

        public readonly static Item EmbalmTheLostArt = CreateItem("Embalming, The Lost Art");
        public readonly static Item LifeAmongUndead = CreateItem("Life Among the Undead: Learning to Cope");
        public readonly static Item IdentifyBloodTypes = CreateItem("Identifying Blood Types: A Beginners' Handbook");
        public readonly static Item MasonryWoodwork = CreateItem("Masonry and Woodworking");
    }
}