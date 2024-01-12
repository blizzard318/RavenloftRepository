﻿public partial class Factory : IDisposable
{
    internal static class ItemEnum
    {
        private static Item CreateItem(params string[] names)
        {
            var retval = new Item(names);
            Ravenloftdb.Items.Add(retval);
            return retval;
        }
        public readonly static Item VigilaDimorta = CreateItem("Vigila Dimorta", "Sentries of Death");

        public readonly static Item Apparatus = CreateItem("Apparatus");
        public readonly static Item SoulSearcher = CreateItem("Soul Searcher Medallion", "Soul Searcher Orb");
        public readonly static Item MirrorOfLaw = CreateItem("Mirror Of Lawful Alignment");

        public readonly static Item Chosen = CreateItem("Chosen");
        public readonly static Item Sunsword = CreateItem("Sunsword");
        public readonly static Item SymbolOfRaven = CreateItem("Holy Medallion of Ravenkind", "Holy Symbol of Ravenkind");
        public readonly static Item IconOfRaven = CreateItem("Icon of Ravenloft");
        public readonly static Item StrahdMedallion = CreateItem("Strahd's Medallion");

        public readonly static Item SealOfLostArak = CreateItem("Seal of Lost Arak");

        public readonly static Item GemOfLight = CreateItem("Gem of Light");
        public readonly static Item GemOfInsight = CreateItem("Gem of Insight");

        public readonly static Item Borer = CreateItem("Borer");
        public readonly static Item Luckstone = CreateItem("Luckstone");
        public readonly static Item DeathRock = CreateItem("Death Rock");
        public readonly static Item TarokkaDeck = CreateItem("Tarokka Deck");
        public readonly static Item TimepieceOfKlorr = CreateItem("Timepiece of Klorr");
        public readonly static Item Decanter = CreateItem("Decanter of Endless Water");
        public readonly static Item VialOfHolyWater = CreateItem("Vial of Holy Water");
        public readonly static Item IncenseOfMed = CreateItem("Incense of Meditation");
        public readonly static Item PowderOfHaste = CreateItem("Powder of Haste");
        public readonly static Item AlchemyJug = CreateItem("Alchemy Jug");
        public readonly static Item StoneOfControlEarth = CreateItem("Stone of Controlling Earth Elementals");
        public readonly static Item HornOfValhalla = CreateItem("Bronze Horn of Valhalla");
        public readonly static Item HarpOfCharm = CreateItem("Harp of Charming");
        public readonly static Item EyeOfVecna = CreateItem("Eye of Vecna");
        public readonly static Item HandOfVecna = CreateItem("Hand of Vecna");
        public readonly static Item LyronHarpsichordCommanding = CreateItem("Lyron's Harpsichord of Commanding");
        public readonly static Item IconOfTheRaven = CreateItem("Icon of the Raven");
        public readonly static Item LensSpeedRead = CreateItem("Lens of SpeedReading");
        public readonly static Item DeckIllusions = CreateItem("Deck of Illusions");
        public readonly static Item BloodCoin = CreateItem("Blood Coin");
        public readonly static Item CatOfFelkovic = CreateItem("Cat of Felkovic");
        public readonly static Item TapestryOfDarkSouls = CreateItem("Tapestry of Dark Souls", "The Gathering Cloth");
        public readonly static Item TapestryOfTheStag = CreateItem("Tapestry of the Stag");
        public readonly static Item CrystalEbonFlame = CreateItem("Crystal of the Ebon Flame");

        public readonly static Item LocketOfSealing = CreateItem("Locket of Sealing");
        public readonly static Item BracersOfDefense = CreateItem("Bracers of Defense");
        public readonly static Item TalismanOfUltimateEvil = CreateItem("Talisman of Ultimate Evil");
        public readonly static Item MedallionOfProt = CreateItem("Medallion of Protection: Good");
        public readonly static Item PhylacteryOfFaith = CreateItem("Phylactery of Faithfulness");
        public readonly static Item GauntletsOfOgrePower = CreateItem("Gauntlets of Ogre Power");
        public readonly static Item ArmorOfBlend = CreateItem("Armor of Blending");
        public readonly static Item EarringSetWithPeriapt = CreateItem("Earring Set with Periapt of Wound Closure");
        public readonly static Item CrownOfSouls = CreateItem("Crown of Souls");
        public readonly static Item FerroniereOfBrilliance = CreateItem("Ferroniere of Brilliance");
        public readonly static Item GirdleManyPounches = CreateItem("Girdle of Many Pounches");
        public readonly static Item BootsOfTheNorth = CreateItem("Boots of the North");
        public readonly static Item AnkletProtFire = CreateItem("Anklet of Protection from Fire");
        public readonly static Item NecklaceOfAdaptation = CreateItem("Necklace of Adaptation");
        public readonly static Item NecklacePrayerBeads = CreateItem("Necklace of Prayer Beads");

        public readonly static Item TarlVanovitchSunBlade = CreateItem("Tarl Vanovitch`s Sun Blade");
        public readonly static Item ArrowOfDirect = CreateItem("Arrow of Direction");
        public readonly static Item ArrowOfWerewolfSlay = CreateItem("Arrow of Werewolf Slaying");
        public readonly static Item FangOfTheNosferatu = CreateItem("Fang of the Nosferatu");
        public readonly static Item BlessedBolt = CreateItem("Blessed Bolt");
        public readonly static Item TimeBomb = CreateItem("Brindletople's Time Bomb");
        public readonly static Item FlashGrenade = CreateItem("Flash Grenade");
        public readonly static Item DartOfHoming = CreateItem("Dart of Homing");
        public readonly static Item DaggerOfVenom = CreateItem("Dagger of Venom");
        public readonly static Item AxeOfHurl = CreateItem("Axe of Hurling");
        public readonly static Item SunBlade = CreateItem("Sun Blade");
        public readonly static Item DragonSlayer = CreateItem("Dragonslayer", "Dragon Slayer");
        public readonly static Item TrollCleaver = CreateItem("Troll-Cleaver");
        public readonly static Item HolyAvenger = CreateItem("Holy Avenger");
        public readonly static Item CursedBerserker = CreateItem("Sword Cursed Berserker");
        public readonly static Item SwordOfWound = CreateItem("Sword of Wounding");
        public readonly static Item SwordOfLifeSteal = CreateItem("Sword of Life Stealing");
        public readonly static Item SwordOfArak = CreateItem("Sword of Arak");
        public readonly static Item MaceOfDisrupt = CreateItem("Mace of Disruption");

        internal static class Drink
        {
            public readonly static Item Aniso = CreateItem("Aniso");
            public readonly static Item Tuika = CreateItem("Tuika");
            public readonly static Item Meekulbrau = CreateItem("Meekulbrau");
        }
        internal static class Food
        {
            public readonly static Item Meekulbern = CreateItem("Meekulbern");
        }
        internal static class Scarab
        {
            public readonly static Item Prot = CreateItem("Scarab of Protection");
            public readonly static Item Mark = CreateItem("Mark's Scarab of Protection");
            public readonly static Item Mazrikoth = CreateItem("Mazrikoth's Scarab of Death");
        }
        internal static class Robe
        {
            public readonly static Item Marion = CreateItem("Marion Robinsdottir's Robe of Blending");
            public readonly static Item Blend = CreateItem("Robe of Blending");
        }
        internal static class Brooch
        {
            public readonly static Item ProtGood = CreateItem("Brooch of Protection: Good");
            public readonly static Item ProtMagMiss = CreateItem("Brooch of Protection: Magic Missile");
        }
        internal static class Rope
        {
            public readonly static Item Entangle = CreateItem("Rope of Entangling");
            public readonly static Item Climb = CreateItem("Rope of Climbing");
        }
        internal static class Cloak
        {
            public readonly static Item Prot = CreateItem("Cloak of Protection");
            public readonly static Item Disp = CreateItem("Cloak of Displacement");
            public readonly static Item Arachnida = CreateItem("Cloak of Arachnida");
        }
        internal static class Amulet
        {
            public readonly static Item Light = CreateItem("Amulet of Light");
            public readonly static Item Proof = CreateItem("Amulet of Proof against Detection and Location");
            public readonly static Item ProtUnd = CreateItem("Amulet of Protection versus Undead");
            public readonly static Item LifeProt = CreateItem("Amulet of Life Protection");
            public readonly static Item Vadarin = CreateItem("Amulet of Vadarin");
            public readonly static Item BeastSilver = CreateItem("Silver Amulet of the Beast");
            public readonly static Item BeastIvory = CreateItem("Ivory Amulet of the Beast");
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
            public readonly static Item Curing = CreateItem("Staff of Curing");
            public readonly static Item Mimicry = CreateItem("Staff of Mimicry");
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
            public readonly static Item Return = CreateItem("Scroll of Return");
        }
        internal static class Ring
        {
            public readonly static Item Shoot = CreateItem("Ring of Shooting Stars");
            public readonly static Item FreeAct = CreateItem("Ring of Free Action");
            public readonly static Item SpellStoring = CreateItem("Ring of Spell Storing");
            public readonly static Item Reverse = CreateItem("Ring of Reversion");
            public readonly static Item Invis = CreateItem("Ring of Invisibility");
            public readonly static Item DetGood = CreateItem("Ring of Detect Good");
            public readonly static Item Regen = CreateItem("Ring of Regeneration");
            public readonly static Item Prot = CreateItem("Ring of Protection");
            public readonly static Item ProtNM = CreateItem("Ring of Protection from Normal Missiles");
            public readonly static Item Aim = CreateItem("Ring of Aiming");
            public readonly static Item WaterWalk = CreateItem("Ring of Water Walking");
            public readonly static Item HumanInfluence = CreateItem("Ring of Human Influence");
            public readonly static Item VampRegen = CreateItem("Ring of Vampiric Regeneration");
        }
        internal static class Wand
        {
            public readonly static Item MagMiss = CreateItem("Wand of Magic Missiles");
            public readonly static Item Almen = CreateItem("Almen's Wand of Illumination");
            public readonly static Item SecretDoor = CreateItem("Wand of Secret Door and Trap Location");
            public readonly static Item Tithion = CreateItem("Tithion's Wand of Fire");
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

            public readonly static Item VileDarkness = CreateItem("Book of Vile Darkness");
            public readonly static Item SpellBookDrawmij = CreateItem("Spell Book of Drawmij");
        }
    }
}