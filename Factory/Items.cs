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
        public readonly static Item Apparatus = CreateItem("Apparatus");
        public readonly static Item SoulSearcher = CreateItem("Soul Searcher Medallion", "Soul Searcher Orb");
        public readonly static Item MirrorOfLaw = CreateItem("Mirror Of Lawful Alignment");

        public readonly static Item Chosen = CreateItem("Chosen");
        public readonly static Item Sunsword = CreateItem("Sunsword");
        public readonly static Item SymbolOfRaven = CreateItem("Holy Medallion of Ravenkind", "Holy Symbol of Ravenkind");
        public readonly static Item IconOfRaven = CreateItem("Icon of Ravenloft");

        public readonly static Item Luckstone = CreateItem("Luckstone");
        public readonly static Item Decanter = CreateItem("Decanter of Endless Water");
        public readonly static Item VialOfHolyWater = CreateItem("Vial of Holy Water");
        public readonly static Item GauntletsOfOgrePower = CreateItem("Gauntlets of Ogre Power");
        public readonly static Item LocketOfSealing = CreateItem("Locket of Sealing");
        public readonly static Item BracersOfDefense = CreateItem("Bracers of Defense");
        public readonly static Item IncenseOfMed = CreateItem("Incense of Meditation");
        public readonly static Item TalismanOfUltimateEvil = CreateItem("Talisman of Ultimate Evil");
        public readonly static Item MedallionOfProt = CreateItem("Medallion of Protection: Good");
        public readonly static Item FlashGrenade = CreateItem("Flash Grenade");
        public readonly static Item GemOfLight = CreateItem("Gem of Light");
        public readonly static Item BroochOfProt = CreateItem("Brooch of Protection: Good");
        public readonly static Item PowderOfHaste = CreateItem("Powder of Haste");
        public readonly static Item AlchemyJug = CreateItem("Alchemy Jug");
        public readonly static Item StoneOfControlEarth = CreateItem("Stone of Controlling Earth Elementals");
        public readonly static Item HornOfValhalla = CreateItem("Bronze Horn of Valhalla");
        public readonly static Item PhylacteryOfFaith = CreateItem("Phylactery of Faithfulness");
        public readonly static Item ScarabOfProt = CreateItem("Scarab of Protection");

        public readonly static Item ArrowOfDirect = CreateItem("Arrow of Direction");
        public readonly static Item DartOfHoming = CreateItem("Dart of Homing");
        public readonly static Item DaggerOfVenom = CreateItem("Dagger of Venom");
        public readonly static Item SunBlade = CreateItem("Sun Blade");
        public readonly static Item DragonSlayer = CreateItem("Dragon Slayer");
        public readonly static Item TrollCleaver = CreateItem("Troll-Cleaver");
        public readonly static Item CursedBerserker = CreateItem("Sword Cursed Berserker");
        public readonly static Item SwordOfWound = CreateItem("Sword of Wounding");
        public readonly static Item SwordOfLifeSteal = CreateItem("Sword of Life Stealing");

        internal static class Rope
        {
            public readonly static Item Entangle = CreateItem("Rope of Entangling");
            public readonly static Item Climb = CreateItem("Rope of Climbing");
        }

        internal static class Cloak
        {
            public readonly static Item Prot = CreateItem("Cloak of Protection");
            public readonly static Item Disp = CreateItem("Cloak of Displacement");
        }

        internal static class Amulet
        {
            public readonly static Item Light = CreateItem("Amulet of Light");
            public readonly static Item Proof = CreateItem("Amulet of Proof against Detection and Location");
        }

        internal static class Rod
        {
            public readonly static Item Smite = CreateItem("Rod of Smiting");
            public readonly static Item Flail = CreateItem("Rod of Flailing");
            public readonly static Item Rastinon = CreateItem("Rod of Rastinon");
        }

        internal static class Staff
        {
            public readonly static Item TheSerpent = CreateItem("Staff of the Serpent");
            public readonly static Item Strike = CreateItem("Staff of Striking");
            public readonly static Item ThunderAndLightning = CreateItem("Staff of Thunder and Lightning");
        }

        internal static class Scroll
        {
            public readonly static Item NegPlaneProt = CreateItem("Scroll of Negative Plane Protection");
            public readonly static Item HolySymbol = CreateItem("Scroll of Holy Symbol");
            public readonly static Item InvisToUndead = CreateItem("Scroll of Invisiblity to Undead");
            public readonly static Item Restore = CreateItem("Scroll of Restoration");
            public readonly static Item Storing = CreateItem("Scroll of Storing");
            public readonly static Item Calling = CreateItem("Scroll of Calling");
            public readonly static Item ProtEvil = CreateItem("Scroll of Protection From Evil, 10` Radius");
            public readonly static Item ProtUnd = CreateItem("Scroll of Protection From Undead");
            public readonly static Item ProtWnS = CreateItem("Scroll of Protection From Wraiths and Spectres");
            public readonly static Item ProtDev = CreateItem("Scroll of Protection From Devils");
            public readonly static Item ProtDem = CreateItem("Scroll of Protection From Demons");
            public readonly static Item ProtPet = CreateItem("Scroll of Protection From Petrification");
        }

        internal static class Ring
        {
            public readonly static Item Shoot = CreateItem("Ring of Shooting Stars");
            public readonly static Item FreeAct = CreateItem("Ring of Free Action");
            public readonly static Item SpellStoring = CreateItem("Ring of Spell Storing");
            public readonly static Item Reverse = CreateItem("Ring of Reversion");
            public readonly static Item DetGood = CreateItem("Ring of Detect Good");
            public readonly static Item Regen = CreateItem("Ring of Regeneration");
            public readonly static Item Prot = CreateItem("Ring of Protection");
            public readonly static Item ProtNM = CreateItem("Ring of Protection from Normal Missiles");
            public readonly static Item Aim = CreateItem("Ring of Aiming");
            public readonly static Item WaterWalk = CreateItem("Ring of Water Walking");
        }

        internal static class Wand
        {
            public readonly static Item MagMiss = CreateItem("Wand of Magic Missiles");
        }

        internal static class Potion
        {
            public readonly static Item Heal = CreateItem("Potion of Healing");
            public readonly static Item ExtraHeal = CreateItem("Potion of Extra-Healing");
            public readonly static Item Climb = CreateItem("Potion of Climbing");
            public readonly static Item Speed = CreateItem("Potion of Speed");
            public readonly static Item SuperHero = CreateItem("Potion of SuperHeroism");
            public readonly static Item ClairAud = CreateItem("Potion of Clairaudience");
            public readonly static Item Dim = CreateItem("Potion of Diminution");
            public readonly static Item CSNW = CreateItem("Potion of Cure Serious Negative Wounds");
        }

        internal static class Elixir
        {
            public readonly static Item Mad = CreateItem("Elixir of Madness");
            public readonly static Item Health = CreateItem("Elixir of Health");
            public readonly static Item Displace = CreateItem("Elixir of Displacement");
        }

        internal static class Book
        {
            public readonly static Item MissingEntry = CreateItem("Missing Entry", "Missing Entries");
            public readonly static Item AlchemistDiary = CreateItem("Alchemist`s Diary");
            public readonly static Item TheInnerSoul = CreateItem("The Inner Soul");
            public readonly static Item THENATUREOFTHESOUL = CreateItem("THE NATURE OF THE SOUL: Portion or Totality of the Man");

            public readonly static Item TomeOfStrahd = CreateItem("Tome of Strahd");
            public readonly static Item EmbalmTheLostArt = CreateItem("Embalming, The Lost Art");
            public readonly static Item LifeAmongUndead = CreateItem("Life Among the Undead: Learning to Cope");
            public readonly static Item IdentifyBloodTypes = CreateItem("Identifying Blood Types: A Beginners' Handbook");
            public readonly static Item MasonryWoodwork = CreateItem("Masonry and Woodworking");
        }
    }
}