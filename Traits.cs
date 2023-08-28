using System.Xml.Linq;

internal static class Traits
{
    //Trait Types: Edition, Canon, Media, Location, Status, Item, Group, Alignment, Item, Class, Race, Creature, Language, Mistway, Cluster
    public static Trait NoLink = Factory.CreateTrait("NoLink", "NoLink"); //Do not generate a link or a reference.

    #region Universal Traits
    internal static class Edition
    {
        static Edition() => e0.ExtraInfo = "Everything here are official products that do not belong to any edition of Dungeons and Dragons.";
        public static List<Source.Trait> Editions = new List<Source.Trait>(7);
        private static Source.Trait CreateEdition(string name)
        {
            var retval = Factory.CreateSourceTrait(name, nameof(Edition));
            Editions.Add(retval);
            return retval;
        }
        public static Source.Trait e0  = CreateEdition("Editionless"  );
        public static Source.Trait e1  = CreateEdition("1st Edition"  );
        public static Source.Trait e2  = CreateEdition("2nd Edition"  );
        public static Source.Trait e3  = CreateEdition("3rd Edition"  );
        public static Source.Trait e35 = CreateEdition("3.5th Edition");
        public static Source.Trait e4  = CreateEdition("4th Edition"  );
        public static Source.Trait e5  = CreateEdition("5th Edition"  );
    }

    internal static class Canon
    {
        static Canon() => nc.ExtraInfo = pc.ExtraInfo = "Unless explicity stated as 'Potentially Canon' or 'Not Canon', everything else is treated Canon.";
        public static List<Source.Trait> Canons = new List<Source.Trait>(2);
        private static Source.Trait CreateCanon(string name)
        {
            var retval = Factory.CreateSourceTrait(name, nameof(Canon));
            Canons.Add(retval);
            return retval;
        }
        public static Source.Trait pc = CreateCanon("Potentially Canon");
        public static Source.Trait nc = CreateCanon("Not Canon"        );
    }

    internal static class Media
    {
        private static Source.Trait CreateMedia(string name) => Factory.CreateSourceTrait(name, nameof(Media));
        public static Source.Trait comic      = CreateMedia("Comic"     );
        public static Source.Trait module     = CreateMedia("Module"    );
        public static Source.Trait novel      = CreateMedia("Novel"     );
        public static Source.Trait gamebook   = CreateMedia("Gamebook"  );
        public static Source.Trait sourcebook = CreateMedia("Sourcebook");
        public static Source.Trait magazine   = CreateMedia("Magazine"  );
        public static Source.Trait videogame  = CreateMedia("Video Game");
        public static Source.Trait boardgame  = CreateMedia("Board Game");
    }

    internal static class Location
    {
        private static Trait CreateLocation(string name) => Factory.CreateTrait(name, nameof(Location));
        public static Trait Mistway    = CreateLocation(nameof(Traits.Mistway   ));
        public static Trait Cluster    = CreateLocation(nameof(Traits.Cluster   ));
        public static Trait Settlement = CreateLocation(nameof(Traits.Settlement));
        public static Trait Darklord => Status.Darklord;
    }

    internal static class Status
    {
        static Status() => Darklord.ExtraInfo = "Locations tagged as Darklord are their Lairs.";
        private static Trait CreateStatus(string name) => Factory.CreateTrait(name, nameof(Status));
        public static Trait Raunie   = CreateStatus("Raunie"  );
        public static Trait Deceased = CreateStatus("Deceased");
        public static Trait Tatyana  = CreateStatus("Reincarnation of Tatyana");
        public static Trait Vistani  = Factory.CreateTrait("Vistani" , nameof(Status), nameof(Group), nameof(Item));
        public static Trait Darklord = Factory.CreateTrait("Darklord", nameof(Status), nameof(Location));
    }

    internal static class Alignment
    {
        private static Trait CreateAlignment(string name) => Factory.CreateTrait(name, nameof(Alignment));
        public static Trait LG = CreateAlignment("Lawful Good"    );
        public static Trait NG = CreateAlignment("Neutral Good"   );
        public static Trait CG = CreateAlignment("Chaotic Good"   );
        public static Trait LN = CreateAlignment("Lawful Neutral" );
        public static Trait TN = CreateAlignment("True Neutral"   );
        public static Trait CN = CreateAlignment("Chaotic Neutral");
        public static Trait LE = CreateAlignment("Lawful Evil"    );
        public static Trait NE = CreateAlignment("Neutral Evil"   );
        public static Trait CE = CreateAlignment("Chaotic Evil"   );
    }
    #endregion

    #region Domain-Tracked Traits
    internal static class Language
    {
        private static Trait CreateLanguage(string name) => Factory.CreateTrait(name, nameof(Language));
        public static Trait Common = CreateLanguage("Common");
    }

    internal static class Race
    {
        private static Trait CreateRace(string name) => Factory.CreateTrait(name, nameof(Race));
        public static Trait Human = CreateRace("Human");
        public static Trait Elf   = CreateRace("Elf"  );
    }

    internal static class Group
    {
        private static Trait CreateGroup(string name) => Factory.CreateTrait(name, nameof(Group));
        public static Trait Vistani => Status.Vistani;
        public static Trait BarovianWineDistillersBrotherhood = CreateGroup("Barovian Wine Distillers Brotherhood");
    }

    internal static class Settlement //Everything here has to use Location.Settlement.Key
    {
        private static Trait CreateSettlement(string name) => Factory.CreateTrait(name, nameof(Settlement));
        public static Trait VillageOfBarovia   = CreateSettlement("Village of Barovia"  );
        public static Trait TserPoolEncampment = CreateSettlement("Tser Pool Encampment");
    }

    internal static class Mistway //Everything here has to use Location.Mistway.Key
    {
        private static Trait CreateMistway(string name) => Factory.CreateTrait(name, nameof(Mistway));
    }
    internal static class Cluster //Everything here has to use Location.Cluster.Key
    {
        private static Trait CreateCluster(string name) => Factory.CreateTrait(name, nameof(Cluster));
    }

    internal static class Creature
    {
        static Creature()
        {
            KeeningSpirit.ExtraInfo = "Also known as 'Groaning Spirit'";
        }

        private static Trait CreateCreature(string name) => Factory.CreateTrait(name, nameof(Creature));
        public static Trait Wolf        = CreateCreature("Wolf"        );
        public static Trait Bat         = CreateCreature("Bat"         );
        public static Trait Horse       = CreateCreature("Horse"       );
        public static Trait Cat         = CreateCreature("Cat"         );
        public static Trait GiantSpider = CreateCreature("Giant Spider");
        public static Trait HugeSpider  = CreateCreature("Huge Spider" );

        public static Trait Worg             = CreateCreature("Worg"             );
        public static Trait Nightmare        = CreateCreature("Nightmare"        );
        public static Trait Hellhound        = CreateCreature("Hellhound"        );
        public static Trait GreenSlime       = CreateCreature("Green Slime"      );
        public static Trait Gargoyle         = CreateCreature("Gargoyle"         );
        public static Trait RustMonster      = CreateCreature("Rust Monster"     );
        public static Trait RedDragon        = CreateCreature("Red Dragon"       );
        public static Trait ShadowDemon      = CreateCreature("Shadow Demon"     );
        public static Trait IronGolem        = CreateCreature("Iron Golem"       );
        public static Trait Trapper          = CreateCreature("Trapper"          );
        public static Trait GuardianPortrait = CreateCreature("Guardian Portrait");

        public static Trait Spirit        = CreateCreature("Spirit"        );
        public static Trait Ghost         = CreateCreature("Ghost"         );
        public static Trait Wraith        = CreateCreature("Wraith"        );
        public static Trait Spectre       = CreateCreature("Spectre"       );
        public static Trait Banshee       = CreateCreature("Banshee"       );
        public static Trait KeeningSpirit = CreateCreature("Keening Spirit");

        public static Trait StrahdZombie = CreateCreature("Strahd Zombie");
        public static Trait Zombie       = CreateCreature("Zombie"       );
        public static Trait Skeleton     = CreateCreature("Skeleton"     );

        public static Trait Vampire = CreateCreature("Vampire");
        public static Trait Ghoul   = CreateCreature("Ghoul"  );
        public static Trait Wight   = CreateCreature("Wight"  );

        public static Trait Witch    = CreateCreature("Witch"   );
        public static Trait Werewolf = CreateCreature("Werewolf");
    }
    #endregion
}
