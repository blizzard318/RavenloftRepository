using static Source;

internal static class Traits
{
    //Trait Types: Edition, Canon, Media, Location, Status, Item, Group, Alignment, Item, Class, Race, Creature, Language, Mistway, Cluster
    public static Trait NoLink = Factory.CreateTrait("NoLink", "NoLink"); //Do not generate a link or a reference.

    #region Universal Traits
    private static Source.Trait Add(this List<Source.Trait> traits, string name, string TraitType)
    {
        var retval = Factory.CreateSourceTrait(name, TraitType);
        traits.Add(retval);
        return retval;
    }
    internal static class Edition
    {
        static Edition() => e0.ExtraInfo = "'Editionless' are official products that do not belong to any edition of Dungeons and Dragons.";
        public static List<Source.Trait> traits = new List<Source.Trait>(7);
        private static Source.Trait CreateEdition(string name) => traits.Add(name, nameof(Edition));
        public static Source.Trait e1  = CreateEdition("1st Ed"  );
        public static Source.Trait e2  = CreateEdition("2nd Ed"  );
        public static Source.Trait e3  = CreateEdition("3rd Ed"  );
        public static Source.Trait e35 = CreateEdition("3.5th Ed");
        public static Source.Trait e4  = CreateEdition("4th Ed"  );
        public static Source.Trait e5  = CreateEdition("5th Ed"  );
        public static Source.Trait e0  = CreateEdition("Editionless");
    }
    internal static class Canon //Annoying to create a page for this, maybe don't.
    {
        static Canon() => NotCanon.ExtraInfo = PotentialCanon.ExtraInfo = "Unless explicity stated as 'Potentially Canon' or 'Not Canon', everything else is treated Canon.";
        public static List<Source.Trait> traits = new List<Source.Trait>(2);
        private static Source.Trait CreateCanon(string name) => traits.Add(name, nameof(Canon));
        public static Source.Trait PotentialCanon = CreateCanon("Potentially Canon");
        public static Source.Trait NotCanon       = CreateCanon("Not Canon"        );
    }
    internal static class Media
    {
        public static List<Source.Trait> traits = new List<Source.Trait>(9);
        private static Source.Trait CreateMedia(string name) => traits.Add(name, nameof(Media));
        public static Source.Trait sourcebook = CreateMedia("Sourcebook");
        public static Source.Trait module     = CreateMedia("Module"    );
        public static Source.Trait magazine   = CreateMedia("Magazine"  );
        public static Source.Trait novel      = CreateMedia("Novel"     );
        public static Source.Trait gamebook   = CreateMedia("Gamebook"  );
        public static Source.Trait audiobook  = CreateMedia("Audiobook" );
        public static Source.Trait videogame  = CreateMedia("Video Game");
        public static Source.Trait comic      = CreateMedia("Comic"     );
        public static Source.Trait boardgame  = CreateMedia("Board Game");
        public static Source.Trait miniature  = CreateMedia("Miniature" );
    }
    private static Trait Add (this List<Trait> traits, string name, string TraitType)
    {
        var retval = Factory.CreateTrait(name, TraitType);
        traits.Add(retval);
        return retval;
    }
    internal static class CampaignSetting //NOT A SOURCE TRAIT. APPLY THIS ON THINGS.
    {
        public static List<Trait> traits = new List<Trait>();
        static CampaignSetting()
        {
            Ravenloft.ExtraInfo = "Assume everything that doesn't have a listed campaign setting belongs here.";
        }
        private static Trait CreateSetting(string name) => traits.Add(name, nameof(CampaignSetting));
        public static Trait Ravenloft = CreateSetting("Ravenloft");
        public static Trait Mystara = CreateSetting("Mystara");
        public static Trait Planescape = CreateSetting("Planescape");
        public static Trait Greyhawk = CreateSetting("Greyhawk");
        public static Trait NentirVale = CreateSetting("Nentir Vale");
        public static Trait ForgottonRealms = CreateSetting("Forgotton Realms");
        public static Trait Spelljammer = CreateSetting("Spelljammer");
        public static Trait DarkSun = CreateSetting("Dark Sun");
        public static Trait Birthright = CreateSetting("Birthright");
        public static Trait Dragonlance = CreateSetting("Dragonlance");
        public static Trait Eberron = CreateSetting("Eberron");
        public static Trait MasqueOfRedDeath = CreateSetting("Masque of Red Death");
    }

    internal static class Location //Seperate them by Mistway,Cluster,Settlement,DarklordLair and else.
    {
        public static List<Trait> traits = new List<Trait>();
        private static Trait CreateLocation(string name) => traits.Add(name, nameof(Location));
        public static Trait Mistway    = CreateLocation(nameof(Traits.Mistway   )); //Subject to removal?
        public static Trait Settlement = CreateLocation(nameof(Traits.Settlement));
    }

    internal static class Status //Includes Groups
    {
        public static List<Trait> traits = new List<Trait>();
        static Status ()
        {
            Darklord.ExtraInfo = "Locations tagged as Darklord are their Lairs.";
            traits.Add(Darklord);
            traits.Add(Vistani);
        }
        private static Trait CreateStatus(string name) => traits.Add(name, nameof(Status));
        public static Trait Vistani = Factory.CreateTrait("Vistani", nameof(Status), nameof(Item));
        public static Trait Darklord = Factory.CreateTrait("Darklord", nameof(Status), nameof(Location));

        public static Trait Deceased = CreateStatus("Deceased");
        public static Trait Tatyana = CreateStatus("Reincarnations of Tatyana");
        public static Trait BarovianWineDistillersBrotherhood = CreateStatus("Barovian Wine Distillers Brotherhood");
        public static Trait TheKargat = CreateStatus("The Kargat");

        public static (Trait, Trait) Raunie = (CreateStatus("Raunie"), Vistani);
    }

    internal static class Alignment //Don't create a page for this.
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
        public static List<Trait> traits = new List<Trait>();
        private static Trait CreateLanguage(string name) => traits.Add(name, nameof(Language));
        public static Trait Common = CreateLanguage("Common");
    }

    internal static class Settlement //Everything here has to use Location.Settlement.Key
    {
        public static List<Trait> traits = new List<Trait>();
        private static Trait CreateSettlement(string name) => traits.Add(name, nameof(Settlement));
        public static Trait VillageOfBarovia   = CreateSettlement("Village of Barovia"  );
        public static Trait TserPoolEncampment = CreateSettlement("Tser Pool Encampment");
        public static Trait Nartok = CreateSettlement("Nartok");
    }

    internal static class Mistway //Everything here has to use Location.Mistway.Key
    {
        public static List<Trait> traits = new List<Trait>(2); //Usually just 2.
        private static Trait CreateMistway(string name) => traits.Add(name, nameof(Mistway));
    }
    internal static class Cluster //Everything here has to use Location.Cluster.Key
    {
        public static List<Trait> traits = new List<Trait>();
        private static Trait CreateCluster(string name) => traits.Add(name, nameof(Cluster));
        public static Trait IslandOfTerror = CreateCluster("Islands of Terror");
    }

    internal static class Creature
    {
        public static List<Trait> traits = new List<Trait>();
        static Creature()
        {
            KeeningSpirit.Item1.ExtraInfo = "Also known as 'Groaning Spirit'";
            KeeningSpirit.Item2.ExtraInfo = "Also known as 'Keening Spirit'";
        }
        private static Trait CreateCreature(string name) => traits.Add(name, nameof(Creature));
        public static Trait Human = CreateCreature("Human");
        public static Trait Elf = CreateCreature("Elf");
        public static Trait Drow = CreateCreature("Drow");

        public static Trait Vulture     = CreateCreature("Vulture"     );
        public static Trait Wolf        = CreateCreature("Wolf"        );
        public static Trait Bat         = CreateCreature("Bat"         );
        public static Trait VampireBat  = CreateCreature("Vampire Bat" );
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

        public static Trait Dragon = CreateCreature("Dragon");

        public static Trait Doppelganger = CreateCreature("Doppelganger");

        public static Trait Spirit        = CreateCreature("Spirit"        );
        public static Trait Ghost         = CreateCreature("Ghost"         );
        public static Trait Wraith        = CreateCreature("Wraith"        );
        public static Trait Spectre       = CreateCreature("Spectre"       );
        public static Trait Banshee       = CreateCreature("Banshee"       );

        public static Trait StrahdZombie = CreateCreature("Strahd Zombie");
        public static Trait Zombie       = CreateCreature("Zombie"       );
        public static Trait Skeleton     = CreateCreature("Skeleton"     );

        public static Trait Vampire    = CreateCreature("Vampire");
        public static Trait Ghoul      = CreateCreature("Ghoul"  );
        public static Trait Wight      = CreateCreature("Wight"  );
        public static Trait FleshGolem = CreateCreature("Flesh Golem");

        public static Trait Hag       = CreateCreature("Hag"     );
        public static Trait Witch     = CreateCreature("Witch"   );
        public static Trait Werewolf  = CreateCreature("Werewolf");

        #region Alternate Names
        public static (Trait, Trait) MindFlayer = (CreateCreature("Illithid"), CreateCreature("Mind Flayer"));
        public static (Trait, Trait) Illithid = (MindFlayer.Item1, MindFlayer.Item2);
        public static (Trait, Trait) KeeningSpirit = (CreateCreature("Keening Spirit"), CreateCreature("Groaning Spirit"));
        public static (Trait, Trait) GroaningSpirit = (KeeningSpirit.Item1, KeeningSpirit.Item2);
        #endregion
    }
    #endregion
}
