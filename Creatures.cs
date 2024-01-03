public partial class Factory : IDisposable
{
    internal static class Creature
    {
        private static Trait CreateCreature(params string[] names) => new Trait(names);
        public readonly static Trait Human = CreateCreature("Human");
        public readonly static Trait Elf = CreateCreature("Elf");
        public readonly static Trait GoldenElf = CreateCreature("Golden Elf");
        public readonly static Trait HighElf = CreateCreature("High Elf");
        public readonly static Trait HalfElf = CreateCreature("Half-Elf");
        public readonly static Trait Dwarf = CreateCreature("Dwarf");
        public readonly static Trait HillDwarf = CreateCreature("Hill Dwarf");
        public readonly static Trait Halfling = CreateCreature("Halfling");
        public readonly static Trait Kender = CreateCreature("Kender");
        public readonly static Trait Gnome = CreateCreature("Gnome");
        public readonly static Trait Drow = CreateCreature("Drow");
        public readonly static Trait Orc = CreateCreature("Orc");
        public readonly static Trait HalfOrc = CreateCreature("Half-Orc");

        public readonly static Trait Vulture = CreateCreature("Vulture");
        public readonly static Trait Horse = CreateCreature("Horse");
        public readonly static Trait Dog = CreateCreature("Dog");
        public readonly static Trait Fox = CreateCreature("Fox");
        public readonly static Trait Rat = CreateCreature("Rat");
        public readonly static Trait Pig = CreateCreature("Pig");
        public readonly static Trait Snake = CreateCreature("Snake");
        public readonly static Trait Tiger = CreateCreature("Tiger");
        public readonly static Trait Raven = CreateCreature("Raven");
        public readonly static Trait Panther = CreateCreature("Panther");
        public readonly static Trait Mouse = CreateCreature("Mouse");
        public readonly static Trait Deer = CreateCreature("Deer");
        public readonly static Trait Rabbit = CreateCreature("Rabbit");
        public readonly static Trait Squirrel = CreateCreature("Squirrel");
        public readonly static Trait Skunk = CreateCreature("Skunk");

        public readonly static Trait BlackCat = CreateCreature("Black Cat");

        public readonly static Trait GiantRat = CreateCreature("Giant Rat");
        public readonly static Trait GiantToad = CreateCreature("Giant Toad");

        public readonly static Trait Wolf = CreateCreature("Wolf");
        public readonly static Trait DireWolf = CreateCreature("Dire Wolf");

        public readonly static Trait Bat = CreateCreature("Bat");
        public readonly static Trait VampireBat = CreateCreature("Vampire Bat");

        public readonly static Trait GiantSpider = CreateCreature("Giant Spider");
        public readonly static Trait HugeSpider = CreateCreature("Huge Spider");
        public readonly static Trait Spider = CreateCreature("Spider");

        public readonly static Trait Stirge = CreateCreature("Stirge");
        public readonly static Trait Maggot = CreateCreature("Maggot");

        public readonly static Trait Goblyn = CreateCreature("Goblyn");
        public readonly static Trait GreenSlime = CreateCreature("Green Slime");
        public readonly static Trait Gargoyle = CreateCreature("Gargoyle");
        public readonly static Trait RustMonster = CreateCreature("Rust Monster");
        public readonly static Trait Trapper = CreateCreature("Trapper");
        public readonly static Trait LurkerAbove = CreateCreature("Lurker Above");

        public readonly static Trait Unicorn = CreateCreature("Unicorn");
        public readonly static Trait Worg = CreateCreature("Worg");
        public readonly static Trait Griffon = CreateCreature("Griffon");
        public readonly static Trait Nightmare = CreateCreature("Nightmare");
        public readonly static Trait ShadowMastiff = CreateCreature("Shadow Mastiff");
        public readonly static Trait DisplacerBeast = CreateCreature("Displacer Beast");
        public readonly static Trait SkeletonSteed = CreateCreature("Skeleton Steed", "Skeletal Steed");
        public readonly static Trait SkeletalSteed = SkeletonSteed;

        public readonly static Trait Hellhound = CreateCreature("Hellhound");
        public readonly static Trait Succubus = CreateCreature("Succubus");
        public readonly static Trait AssassinImp = CreateCreature("Assassin Imp");
        public readonly static Trait ShadowDemon = CreateCreature("Shadow Demon", "Shadow Fiend");
        public readonly static Trait ShadowFiend = ShadowDemon;
        public readonly static Trait Quasit = CreateCreature("Quasit", "Quazit");
        public readonly static Trait Quazit = Quasit;

        public readonly static Trait Dragon = CreateCreature("Dragon");
        public readonly static Trait RedDragon = CreateCreature("Red Dragon");
        public readonly static Trait GoldDragon = CreateCreature("Gold Dragon");

        public readonly static Trait BrokenOne = CreateCreature("Broken One");
        public readonly static Trait Doppelganger = CreateCreature("Doppelganger");
        public readonly static Trait InvisibleStalker = CreateCreature("Invisible Stalker");

        public readonly static Trait Shade = CreateCreature("Shade");
        public readonly static Trait Shadow = CreateCreature("Shadow");

        public readonly static Trait Spirit = CreateCreature("Spirit");
        public readonly static Trait Ghost = CreateCreature("Ghost");
        public readonly static Trait Wraith = CreateCreature("Wraith");
        public readonly static Trait Spectre = CreateCreature("Spectre");
        public readonly static Trait Banshee = CreateCreature("Banshee");
        public readonly static Trait GrimReaper = CreateCreature("Grim Reaper");
        public readonly static Trait Bussengeist = CreateCreature("Bussengeist");
        public readonly static Trait Odem = CreateCreature("Odem");
        public readonly static Trait Geist = CreateCreature("Geist");
        public readonly static Trait Haunt = CreateCreature("Haunt");
        public readonly static Trait Drelb = CreateCreature("Drelb");
        public readonly static Trait WillOWisp = CreateCreature("Will-o-Wisp");
        public readonly static Trait KeeningSpirit = CreateCreature("Keening Spirit", "Groaning Spirit");
        public readonly static Trait GroaningSpirit = KeeningSpirit;
        public readonly static Trait VampiricMist = CreateCreature("Vampiric Mist", "Crimson Death");
        public readonly static Trait CrimsonDeath = VampiricMist;

        public readonly static Trait StrahdZombie = CreateCreature("Strahd Zombie");
        public readonly static Trait StrahdSkeleton = CreateCreature("Strahd Skeleton");
        public readonly static Trait StrahdSteed = CreateCreature("Strahd's Skeletal Steed", "Strahd Skeleton Steed");

        public readonly static Trait Zombie = CreateCreature("Zombie");
        public readonly static Trait SeaZombie = CreateCreature("Sea Zombie");
        public readonly static Trait Skeleton = CreateCreature("Skeleton");
        public readonly static Trait Bodak = CreateCreature("Bodak");

        public readonly static Trait GraveElemental = CreateCreature("Grave Elemental");
        public readonly static Trait AnimatedRock = CreateCreature("Animated Rock");
        public readonly static Trait LivingWall = CreateCreature("Living Wall");
        public readonly static Trait GuardianPortrait = CreateCreature("Guardian Portrait");
        public readonly static Trait DoomGuard = CreateCreature("Doom Guard");
        public readonly static Trait Mimic = CreateCreature("Mimic");

        public readonly static Trait IronGolem = CreateCreature("Iron Golem");
        public readonly static Trait StoneGolem = CreateCreature("Stone Golem");
        public readonly static Trait BoneGolem = CreateCreature("Bone Golem");
        public readonly static Trait FleshGolem = CreateCreature("Flesh Golem");

        public readonly static Trait QuasiElementalLightning = CreateCreature("Quasi-Elemental Lightning");
        public readonly static Trait Mihstu = CreateCreature("Mihstug");

        public readonly static Trait Vampyre = CreateCreature("Vampyre");
        public readonly static Trait Vampire = CreateCreature("Vampire");
        public readonly static Trait Nosferatu = CreateCreature("Nosferatu");
        public readonly static Trait Mummy = CreateCreature("Mummy");
        public readonly static Trait GreaterMummy = CreateCreature("Greater Mummy");
        public readonly static Trait Ghoul = CreateCreature("Ghoul");
        public readonly static Trait GhoulLord = CreateCreature("Ghoul Lord");
        public readonly static Trait Ghast = CreateCreature("Ghast");
        public readonly static Trait Wight = CreateCreature("Wight");
        public readonly static Trait Lich = CreateCreature("Lich");
        public readonly static Trait Revenant = CreateCreature("Revenant");
        public readonly static Trait DeathKnight = CreateCreature("Death Knight");

        public readonly static Trait Hag = CreateCreature("Hag");
        public readonly static Trait Witch = CreateCreature("Witch");
        public readonly static Trait Harpy = CreateCreature("Harpy");
        public readonly static Trait Ogre = CreateCreature("Ogre");

        public readonly static Trait MindFlayer = CreateCreature("Illithid", "Mind Flayer");
        public readonly static Trait Illithid = MindFlayer;

        public readonly static Trait Werewolf = CreateCreature("Werewolf");
        public readonly static Trait Wolfwere = CreateCreature("Wolfwere");
        public readonly static Trait Werebat = CreateCreature("Werebat");
        public readonly static Trait LoupGarou = CreateCreature("Loup-Garou");
        public readonly static Trait GreaterWolfwere = CreateCreature("Greater Wolfwere");

        public readonly static Trait GhostShip = CreateCreature("Ghost Ship");
        public readonly static Trait Reaver = CreateCreature("Reaver");

        public readonly static Trait Quickwood = CreateCreature("Quickwood");
    }
}