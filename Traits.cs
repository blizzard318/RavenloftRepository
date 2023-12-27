internal static class Traits
{
    private enum TraitType { CampaignSetting, Language, Creature, Alignment };
    private static Trait CreateTrait(TraitType type, string name, string ExtraInfo = "")
    {
        var retval = new Trait(name, ExtraInfo);
        GetList(type).Add(retval);
        return retval;

        List<Trait> GetList (TraitType type)
        {
            switch (type)
            {
                case TraitType.CampaignSetting: return Ravenloftdb.CampaignSettings;
                case TraitType.Language       : return Ravenloftdb.Languages;
                case TraitType.Creature       : return Ravenloftdb.Creatures;
                case TraitType.Alignment      : return Ravenloftdb.Alignments;
            }
            throw new NotImplementedException();
        }
    }

    private static Trait CreateCampaignSettingTrait(string name) => CreateTrait(TraitType.CampaignSetting, name);
    private static Trait CreateCreatureTrait(string name) => CreateTrait(TraitType.Creature, name);
    private static Trait CreateAlignmentTrait(string name) => CreateTrait(TraitType.Alignment, name);
    private static Trait CreateLanguageTrait(string name) => CreateTrait(TraitType.Language, name);

    //Trait Types: Edition, Canon, Media, Location, Status, Alignment, Item, Creature, Language, Mistway, Cluster
    public static Trait NoLink = Factory.CreateTrait("NoLink", "NoLink"); //Do not generate a link or a reference.
    public static Trait Deceased = Factory.CreateTrait("Deceased", "Deceased");
    public static Trait Deity = Factory.CreateTrait("Deity", "Deity");

    #region Universal Traits
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
        public static Trait Ravenloft        = CreateSetting("Ravenloft"          );
        public static Trait Mystara          = CreateSetting("Mystara"            );
        public static Trait Planescape       = CreateSetting("Planescape"         );
        public static Trait Greyhawk         = CreateSetting("Greyhawk"           );
        public static Trait NentirVale       = CreateSetting("Nentir Vale"        );
        public static Trait ForgottonRealms  = CreateSetting("Forgotton Realms"   );
        public static Trait Spelljammer      = CreateSetting("Spelljammer"        );
        public static Trait DarkSun          = CreateSetting("Dark Sun"           );
        public static Trait Birthright       = CreateSetting("Birthright"         );
        public static Trait Dragonlance      = CreateSetting("Dragonlance"        );
        public static Trait Eberron          = CreateSetting("Eberron"            );
        public static Trait MasqueOfRedDeath = CreateSetting("Masque of Red Death");
    }

    internal static class Location //Seperate them by Mistway,Cluster,Settlement,DarklordLair and else.
    {
        public static List<Trait> traits = new List<Trait>();
        private static Trait CreateLocation(string name) => traits.Add(name, nameof(Location));
        public static Trait Mistway    = CreateLocation("Mistway"  );
        public static Trait Cluster    = CreateLocation("Cluster"  );
        public static Trait Settlement = CreateLocation("Settlment");
        public static Trait Darklord   = CreateLocation("Darklord" );
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
        public static (Trait, Trait) Elf = (CreateLanguage("Elf"), CreateLanguage("Elvish"));
        public static (Trait, Trait) Elvish = (Elf.Item1, Elf.Item2);
        public static (Trait, Trait) Gnome = (CreateLanguage("Gnome"), CreateLanguage("Gnomish"));
        public static (Trait, Trait) Gnomish = (Gnome.Item1, Gnome.Item2);
        public static Trait Dwarvish = CreateLanguage("Dwarvish");
        public static Trait Halfling = CreateLanguage("Halfling");

        public static Trait Illithid = CreateLanguage("Illithid");
        public static Trait Orcish = CreateLanguage("Orcish");
        public static Trait Goblin = CreateLanguage("Goblin");
        public static Trait Hobgoblin = CreateLanguage("Hobgoblin");
        public static Trait Ogre = CreateLanguage("Ogre");
        public static Trait Drow = CreateLanguage("Drow");
        public static Trait Troll = CreateLanguage("Troll");
        public static Trait Gnoll = CreateLanguage("Gnoll");
        public static Trait KuoToan = CreateLanguage("Kuo-Toan");

        public static Trait Treantish = CreateLanguage("Treantish");

        public static Trait HillGiant = CreateLanguage("Hill Giant");
        public static Trait MountainGiant = CreateLanguage("Mountain Giant");

        public static Trait RedDragon = CreateLanguage("Red Dragon");

        public static Trait BurrowingMammals = CreateLanguage("Burrowing Mammals");
        public static Trait DesertNomad = CreateLanguage("Desert Nomad");
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
        public static Trait Human     = CreateCreature("Human");
        public static Trait Elf       = CreateCreature("Elf");
        public static Trait GoldenElf = CreateCreature("Golden Elf");
        public static Trait HighElf   = CreateCreature("High Elf");
        public static Trait HalfElf   = CreateCreature("Half-Elf");
        public static Trait Dwarf     = CreateCreature("Dwarf");
        public static Trait HillDwarf = CreateCreature("Hill Dwarf");
        public static Trait Halfling  = CreateCreature("Halfling");
        public static Trait Kender    = CreateCreature("Kender");
        public static Trait Gnome     = CreateCreature("Gnome");
        public static Trait Drow      = CreateCreature("Drow");
        public static Trait Orc       = CreateCreature("Orc");
        public static Trait HalfOrc   = CreateCreature("Half-Orc");

        public static Trait Vulture  = CreateCreature("Vulture" );
        public static Trait Horse    = CreateCreature("Horse"   );
        public static Trait Dog      = CreateCreature("Dog"     );
        public static Trait Fox      = CreateCreature("Fox"     );
        public static Trait Rat      = CreateCreature("Rat"     );
        public static Trait Pig      = CreateCreature("Pig"     );
        public static Trait Snake    = CreateCreature("Snake"   );
        public static Trait Tiger    = CreateCreature("Tiger"   );
        public static Trait Raven    = CreateCreature("Raven"   );
        public static Trait Panther  = CreateCreature("Panther" );
        public static Trait Mouse    = CreateCreature("Mouse"   );
        public static Trait Deer     = CreateCreature("Deer"    );
        public static Trait Rabbit   = CreateCreature("Rabbit"  );
        public static Trait Squirrel = CreateCreature("Squirrel");
        public static Trait Skunk    = CreateCreature("Skunk"   );

        public static Trait BlackCat = CreateCreature("Black Cat");

        public static Trait GiantRat  = CreateCreature("Giant Rat" );
        public static Trait GiantToad = CreateCreature("Giant Toad");

        public static Trait Wolf     = CreateCreature("Wolf"     );
        public static Trait DireWolf = CreateCreature("Dire Wolf");

        public static Trait Bat        = CreateCreature("Bat"        );
        public static Trait VampireBat = CreateCreature("Vampire Bat");

        public static Trait GiantSpider = CreateCreature("Giant Spider");
        public static Trait HugeSpider  = CreateCreature("Huge Spider" );
        public static Trait Spider      = CreateCreature("Spider"      );

        public static Trait Stirge = CreateCreature("Stirge");
        public static Trait Maggot = CreateCreature("Maggot");

        public static Trait Goblyn      = CreateCreature("Goblyn"      );
        public static Trait GreenSlime  = CreateCreature("Green Slime" );
        public static Trait Gargoyle    = CreateCreature("Gargoyle"    );
        public static Trait RustMonster = CreateCreature("Rust Monster");
        public static Trait Trapper     = CreateCreature("Trapper"     );
        public static Trait LurkerAbove = CreateCreature("Lurker Above");

        public static Trait Unicorn        = CreateCreature("Unicorn"        );
        public static Trait Worg           = CreateCreature("Worg"           );
        public static Trait Griffon        = CreateCreature("Griffon"        );
        public static Trait Nightmare      = CreateCreature("Nightmare"      );
        public static Trait ShadowMastiff  = CreateCreature("Shadow Mastiff" );
        public static Trait DisplacerBeast = CreateCreature("Displacer Beast");

        public static Trait Hellhound   = CreateCreature("Hellhound"   );
        public static Trait Succubus    = CreateCreature("Succubus"    );
        public static Trait AssassinImp = CreateCreature("Assassin Imp");

        public static Trait Dragon     = CreateCreature("Dragon"     );
        public static Trait RedDragon  = CreateCreature("Red Dragon" );
        public static Trait GoldDragon = CreateCreature("Gold Dragon");

        public static Trait BrokenOne        = CreateCreature("Broken One"       );
        public static Trait Doppelganger     = CreateCreature("Doppelganger"     );
        public static Trait InvisibleStalker = CreateCreature("Invisible Stalker");

        public static Trait Shade  = CreateCreature("Shade" );
        public static Trait Shadow = CreateCreature("Shadow");

        public static Trait Spirit      = CreateCreature("Spirit"     );
        public static Trait Ghost       = CreateCreature("Ghost"      );
        public static Trait Wraith      = CreateCreature("Wraith"     );
        public static Trait Spectre     = CreateCreature("Spectre"    );
        public static Trait Banshee     = CreateCreature("Banshee"    );
        public static Trait GrimReaper  = CreateCreature("Grim Reaper");
        public static Trait Bussengeist = CreateCreature("Bussengeist");
        public static Trait Odem        = CreateCreature("Odem"       );
        public static Trait Geist       = CreateCreature("Geist"      );
        public static Trait Haunt       = CreateCreature("Haunt"      );
        public static Trait Drelb       = CreateCreature("Drelb"      );
        public static Trait WillOWisp   = CreateCreature("Will-o-Wisp");

        public static Trait StrahdZombie   = CreateCreature("Strahd Zombie"  );
        public static Trait StrahdSkeleton = CreateCreature("Strahd Skeleton");

        public static Trait Zombie         = CreateCreature("Zombie"        );
        public static Trait SeaZombie      = CreateCreature("Sea Zombie"    );
        public static Trait Skeleton       = CreateCreature("Skeleton"      );
        public static Trait Bodak          = CreateCreature("Bodak"         );

        public static Trait GraveElemental   = CreateCreature("Grave Elemental"  );
        public static Trait AnimatedRock     = CreateCreature("Animated Rock"    );
        public static Trait LivingWall       = CreateCreature("Living Wall"      );
        public static Trait GuardianPortrait = CreateCreature("Guardian Portrait");
        public static Trait DoomGuard        = CreateCreature("Doom Guard"       );
        public static Trait Mimic            = CreateCreature("Mimic"            );

        public static Trait IronGolem  = CreateCreature("Iron Golem" );
        public static Trait StoneGolem = CreateCreature("Stone Golem");
        public static Trait BoneGolem  = CreateCreature("Bone Golem" );
        public static Trait FleshGolem = CreateCreature("Flesh Golem");

        public static Trait QuasiElementalLightning = CreateCreature("Quasi-Elemental Lightning");
        public static Trait Mihstu = CreateCreature("Mihstug");

        public static Trait Vampyre   = CreateCreature("Vampyre");
        public static Trait Vampire   = CreateCreature("Vampire");
        public static Trait Nosferatu = CreateCreature("Nosferatu");
        public static Trait Mummy        = CreateCreature("Mummy");
        public static Trait GreaterMummy = CreateCreature("Greater Mummy");
        public static Trait Ghoul     = CreateCreature("Ghoul");
        public static Trait GhoulLord = CreateCreature("Ghoul Lord");
        public static Trait Ghast     = CreateCreature("Ghast");
        public static Trait Wight     = CreateCreature("Wight");
        public static Trait Lich      = CreateCreature("Lich" );
        public static Trait Revenant  = CreateCreature("Revenant");
        public static Trait DeathKnight = CreateCreature("Death Knight");

        public static Trait Hag       = CreateCreature("Hag"     );
        public static Trait Witch     = CreateCreature("Witch"   );
        public static Trait Harpy     = CreateCreature("Harpy"   );
        public static Trait Ogre      = CreateCreature("Ogre");

        public static Trait Werewolf  = CreateCreature("Werewolf");
        public static Trait Wolfwere  = CreateCreature("Wolfwere");
        public static Trait Werebat   = CreateCreature("Werebat");
        public static Trait LoupGarou = CreateCreature("Loup-Garou");
        public static Trait GreaterWolfwere = CreateCreature("Greater Wolfwere");

        public static Trait GhostShip  = CreateCreature("Ghost Ship");
        public static Trait Reaver = CreateCreature("Reaver");

        public static Trait Quickwood = CreateCreature("Quickwood");

        #region Alternate Names
        public static (Trait, Trait) MindFlayer = (CreateCreature("Illithid"), CreateCreature("Mind Flayer"));
        public static (Trait, Trait) Illithid = (MindFlayer.Item1, MindFlayer.Item2);

        public static (Trait, Trait) KeeningSpirit = (CreateCreature("Keening Spirit"), CreateCreature("Groaning Spirit"));
        public static (Trait, Trait) GroaningSpirit = (KeeningSpirit.Item1, KeeningSpirit.Item2);

        public static (Trait,Trait) ShadowDemon = (CreateCreature("Shadow Demon"), CreateCreature("Shadow Fiend"));
        public static (Trait,Trait) ShadowFiend = (ShadowDemon.Item1, ShadowDemon.Item2);

        public static (Trait,Trait) VampiricMist = (CreateCreature("Vampiric Mist"), CreateCreature("Crimson Death"));
        public static (Trait,Trait) CrimsonDeath = (VampiricMist.Item1, VampiricMist.Item2);

        public static (Trait, Trait) SkeletonSteed = (CreateCreature("Skeleton Steed"), CreateCreature("Skeletal Steed"));
        public static (Trait, Trait) SkeletalSteed = (SkeletonSteed.Item1, SkeletonSteed.Item2);

        public static (Trait, Trait) Quasit = (CreateCreature("Quasit"), CreateCreature("Quazit"));
        public static (Trait, Trait) Quazit = (Quasit.Item1, Quasit.Item2);

        public static (Trait, Trait) StrahdSteed = (CreateCreature("Strahd's Skeletal Steed"), CreateCreature("Strahd Skeleton Steed"));
        #endregion
    }
    #endregion
}
