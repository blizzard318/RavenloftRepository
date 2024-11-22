public partial class Factory : IDisposable
{
    internal static class Creature
    {
        static Creature()
        {
            GreatCat.Creatures.Total.UnionWith(new[]
            { Panther, GiantLynx, Cheetah, MountainLion, Leopard, Jaguar, Lion, Tiger, SpottedLion, Smilodon });

            BirdsOfPrey.Creatures.Total.UnionWith(new[] { Vulture, Hawk, Owl, Eagle });
            GreatCat.ExtraInfo = BirdsOfPrey.ExtraInfo = "Other applicable animals can still qualify.";

            Hag.Creatures.Total.UnionWith(new[] { AnnisHag, GreenHag, SeaHag });
    }
        private static Trait CreateCreature(params string[] names)
        {
            var retval = new Trait(names);
            Ravenloftdb.Creatures.Add(retval);
            return retval;
        }
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
        public readonly static Trait Goblin = CreateCreature("Goblin");
        public readonly static Trait GurikChaahl = CreateCreature("Gurik Cha'ahl");
        public readonly static Trait Hobgoblin = CreateCreature("Hobgoblin");
        public readonly static Trait NorkerHobgoblin = CreateCreature("Hobgoblin Hobgoblin");
        public readonly static Trait Kobold = CreateCreature("Kobold");
        public readonly static Trait Gith = CreateCreature("Gith");
        public readonly static Trait Githyanki = CreateCreature("Githyanki");
        public readonly static Trait Githzerai = CreateCreature("Githzerai");

        #region Aquatic
        public readonly static Trait GhostShip = CreateCreature("Ghost Ship");
        public readonly static Trait Reaver = CreateCreature("Reaver");
        public readonly static Trait Sahuagin = CreateCreature("Sahuagin");
        public readonly static Trait Trout = CreateCreature("Trout");
        public readonly static Trait Salmon = CreateCreature("Salmon");
        public readonly static Trait Porpoise = CreateCreature("Porpoise");
        public readonly static Trait Dolphin = CreateCreature("Dolphin");
        public readonly static Trait GiantStarfish = CreateCreature("Giant Starfish");
        public readonly static Trait Vodyanoi = CreateCreature("Vodyanoi", "Aquatic Umber Hulk");
        public readonly static Trait SeaSerpent = CreateCreature("Sea Serpent", "Sea Drake");
        public readonly static Trait Jellyfish = CreateCreature("Jellyfish");
        public readonly static Trait FiddlerCrab = CreateCreature("Fiddler Crab");
        #endregion

        #region Birds
        public readonly static Trait BirdsOfPrey = CreateCreature("Birds of Prey");
        public readonly static Trait Vulture = CreateCreature("Vulture");
        public readonly static Trait Eagle = CreateCreature("Eagle");
        public readonly static Trait Hawk = CreateCreature("Hawk");
        public readonly static Trait Raven = CreateCreature("Raven");
        public readonly static Trait GiantRaven = CreateCreature("Giant Raven");
        public readonly static Trait Chicken = CreateCreature("Chicken");
        public readonly static Trait VistaChiri = CreateCreature("Vista-Chiri");
        public readonly static Trait Songbird = CreateCreature("Songbird");
        public readonly static Trait Nightbird = CreateCreature("Nightbird");
        public readonly static Trait Seabird = CreateCreature("Seabird");
        public readonly static Trait Owl = CreateCreature("Owl");
        public readonly static Trait Crow = CreateCreature("Crow");
        public readonly static Trait GiantCrow = CreateCreature("Giant Crow");
        public readonly static Trait SeaGull = CreateCreature("Sea Gull");
        public readonly static Trait Pheasant = CreateCreature("Pheasant");
        public readonly static Trait Quail = CreateCreature("Quail");
        public readonly static Trait Partridge = CreateCreature("Partridge");
        public readonly static Trait Ptarmigan = CreateCreature("Ptarmigan");
        public readonly static Trait Skullbird = CreateCreature("Skullbird");
        public readonly static Trait Goose = CreateCreature("Goose");
        #endregion

        #region Small Mammals
        public readonly static Trait Bat = CreateCreature("Bat");
        public readonly static Trait VampireBat = CreateCreature("Vampire Bat");
        public readonly static Trait LargeBat = CreateCreature("Large Bat");
        public readonly static Trait GiantBat = CreateCreature("Giant Bat");
        public readonly static Trait HugeBat = CreateCreature("Huge Bat");
        public readonly static Trait Mobat = CreateCreature("Mobat");
        public readonly static Trait SentinelBat = CreateCreature("Sentinel Bat");

        public readonly static Trait Rat = CreateCreature("Rat");
        public readonly static Trait GiantRat = CreateCreature("Giant Rat");
        public readonly static Trait Mouse = CreateCreature("Mouse");
        public readonly static Trait Rabbit = CreateCreature("Rabbit");
        public readonly static Trait SnowshoeHare = CreateCreature("Snowshoe Hare");
        public readonly static Trait Squirrel = CreateCreature("Squirrel");
        public readonly static Trait GroundSquirrel = CreateCreature("Ground Squirrel");
        public readonly static Trait Chipmunk = CreateCreature("Chipmunk");
        public readonly static Trait Ferret = CreateCreature("Ferret");
        public readonly static Trait Skunk = CreateCreature("Skunk");
        public readonly static Trait Hedgehog = CreateCreature("Hedgehog");
        public readonly static Trait Opossum = CreateCreature("Opossum");
        public readonly static Trait Woodchuck = CreateCreature("Woodchuck");
        public readonly static Trait Raccoon = CreateCreature("Raccoon");
        public readonly static Trait Marten = CreateCreature("Marten");
        public readonly static Trait Weasel = CreateCreature("Weasel");
        public readonly static Trait GiantWeasel = CreateCreature("Giant Weasel");
        public readonly static Trait PrarieDog = CreateCreature("Prarie Dog");
        public readonly static Trait Otter = CreateCreature("Otter");
        public readonly static Trait Beaver = CreateCreature("Beaver");
        #endregion

        #region Medium Mammals
        public readonly static Trait Dog = CreateCreature("Dog", "Mastiff");
        public readonly static Trait Wolf = CreateCreature("Wolf");
        public readonly static Trait DireWolf = CreateCreature("Dire Wolf");
        public readonly static Trait MistWolf = CreateCreature("Mist Wolf");
        public readonly static Trait WinterWolf = CreateCreature("Winter Wolf");
        public readonly static Trait Fox = CreateCreature("Fox");
        public readonly static Trait Jackal = CreateCreature("Jackal");
        public readonly static Trait Monkey = CreateCreature("Monkey");
        public readonly static Trait Baboon = CreateCreature("Baboon");
        public readonly static Trait Pig = CreateCreature("Pig", "Swine");
        public readonly static Trait Boar = CreateCreature("Boar");
        public readonly static Trait Hyena = CreateCreature("Hyena");
        public readonly static Trait Coyote = CreateCreature("Coyote");
        public readonly static Trait Badger = CreateCreature("Badger");
        #endregion

        #region Large Mammals
        public readonly static Trait Sheep = CreateCreature("Sheep");
        public readonly static Trait BighornSheep = CreateCreature("Bighorn Sheep");
        public readonly static Trait Horse = CreateCreature("Horse", "Pony");
        public readonly static Trait Deer = CreateCreature("Deer");
        public readonly static Trait Goat = CreateCreature("Goat");
        public readonly static Trait MountainGoat = CreateCreature("Mountain Goat");
        public readonly static Trait Ox = CreateCreature("Ox", "Oxen");
        public readonly static Trait Cow = CreateCreature("Cow", "Cattle");
        public readonly static Trait Bear = CreateCreature("Bear");
        public readonly static Trait Caribou = CreateCreature("Caribou");
        public readonly static Trait Elk = CreateCreature("Elk");
        public readonly static Trait Moose = CreateCreature("Moose");
        public readonly static Trait Elephant = CreateCreature("Elephant");
        public readonly static Trait Mule = CreateCreature("Mule");
        public readonly static Trait Kangaroo = CreateCreature("Kangaroo");
        public readonly static Trait Camel = CreateCreature("Camel");
        #endregion

        #region Cats
        public readonly static Trait BlackCat = CreateCreature("Black Cat");
        public readonly static Trait HouseCat = CreateCreature("House Cat");
        public readonly static Trait GreatCat = CreateCreature("Great Cat");
        public readonly static Trait Panther = CreateCreature("Panther");
        public readonly static Trait GiantLynx = CreateCreature("Giant Lynx");
        public readonly static Trait Cheetah = CreateCreature("Cheetah");
        public readonly static Trait MountainLion = CreateCreature("Mountain Lion");
        public readonly static Trait Leopard = CreateCreature("Leopard");
        public readonly static Trait Jaguar = CreateCreature("Jaguar");
        public readonly static Trait Lion = CreateCreature("Lion");
        public readonly static Trait Tiger = CreateCreature("Tiger");
        public readonly static Trait SpottedLion = CreateCreature("Spotted Lion");
        public readonly static Trait Smilodon = CreateCreature("Smilodon");
        public readonly static Trait PlainsCat = CreateCreature("Plains Cat");
        public readonly static Trait Cougar = CreateCreature("Cougar");
        #endregion

        #region Fantasy Animals
        public readonly static Trait Kelpie = CreateCreature("Kelpie");
        public readonly static Trait Leucrotta = CreateCreature("Leucrotta");
        public readonly static Trait Unicorn = CreateCreature("Unicorn");
        public readonly static Trait Pegasus = CreateCreature("Pegasus");
        public readonly static Trait Owlbear = CreateCreature("Owlbear");
        public readonly static Trait Worg = CreateCreature("Worg");
        public readonly static Trait Griffon = CreateCreature("Griffon");
        public readonly static Trait Hippogriff = CreateCreature("Hippogriff");
        public readonly static Trait Nightmare = CreateCreature("Nightmare");
        public readonly static Trait ShadowMastiff = CreateCreature("Shadow Mastiff");
        public readonly static Trait DisplacerBeast = CreateCreature("Displacer Beast");
        public readonly static Trait YethHound = CreateCreature("Yeth Hound");
        public readonly static Trait Bulette = CreateCreature("Bulette");
        #endregion

        #region Non-Mammals
        public readonly static Trait Snake = CreateCreature("Snake");
        public readonly static Trait Asp = CreateCreature("Asp");
        public readonly static Trait Frog = CreateCreature("Frog", "Toad");
        public readonly static Trait Toad = Frog;
        public readonly static Trait GiantToad = CreateCreature("Giant Toad");
        public readonly static Trait Sturgeon = CreateCreature("Sturgeon");
        public readonly static Trait Crocodile = CreateCreature("Crocodile");
        public readonly static Trait Lizard = CreateCreature("Lizard");
        #endregion

        #region Bugs
        public readonly static Trait GiantSpider = CreateCreature("Giant Spider", "Large Spider");
        public readonly static Trait HugeSpider = CreateCreature("Huge Spider");
        public readonly static Trait Spider = CreateCreature("Spider");
        public readonly static Trait Stirge = CreateCreature("Stirge");
        public readonly static Trait Maggot = CreateCreature("Maggot");
        public readonly static Trait AntLion = CreateCreature("Ant Lion");
        public readonly static Trait Scorpion = CreateCreature("Scorpion");
        public readonly static Trait Leech = CreateCreature("Leech");
        public readonly static Trait GiantCentipede = CreateCreature("Giant Centipede");
        public readonly static Trait RotGrub = CreateCreature("Rot Grub");
        public readonly static Trait Beetle = CreateCreature("Beetle");
        public readonly static Trait CarrionCrawler = CreateCreature("Carrion Crawler");
        public readonly static Trait GoblinSpider = CreateCreature("Goblin Spider");
        public readonly static Trait Bee = CreateCreature("Bee");
        public readonly static Trait Fly = CreateCreature("Fly");
        public readonly static Trait Gnat = CreateCreature("Gnat");
        public readonly static Trait Locust = CreateCreature("Locust");
        public readonly static Trait Mosquito = CreateCreature("Mosquito");
        public readonly static Trait Earwig = CreateCreature("Earwig");
        public readonly static Trait Cockroach = CreateCreature("Cockroach");
        #endregion

        public readonly static Trait Mite = CreateCreature("Mite");
        public readonly static Trait Ettercap = CreateCreature("Ettercap");
        public readonly static Trait Gremlin = CreateCreature("Gremlin");
        public readonly static Trait Jermlaine = CreateCreature("Jermlaine", "Banemidge", "Jinxkin");

        public readonly static Trait Goblyn = CreateCreature("Goblyn");
        public readonly static Trait Gargoyle = CreateCreature("Gargoyle");
        public readonly static Trait GreenSlime = CreateCreature("Green Slime");
        public readonly static Trait RustMonster = CreateCreature("Rust Monster");
        public readonly static Trait Trapper = CreateCreature("Trapper");
        public readonly static Trait LurkerAbove = CreateCreature("Lurker Above");
        public readonly static Trait Drider = CreateCreature("Drider");
        public readonly static Trait Cloaker = CreateCreature("Cloaker");
        public readonly static Trait ShamblingMound = CreateCreature("Shambling Mound");
        public readonly static Trait Disir = CreateCreature("Disir");
        public readonly static Trait Ankheg = CreateCreature("Ankheg");

        public readonly static Trait Gremishka = CreateCreature("Gremishka", "Grimishka");
        public readonly static Trait Mongrelman = CreateCreature("Mongrelman");
        public readonly static Trait BrokenOne = CreateCreature("Broken One");
        public readonly static Trait Witch = CreateCreature("Witch");
        public readonly static Trait Harpy = CreateCreature("Harpy");
        public readonly static Trait Ogre = CreateCreature("Ogre");
        public readonly static Trait Satyr = CreateCreature("Satyr");
        public readonly static Trait Rakshasa = CreateCreature("Rakshasa");
        public readonly static Trait Naga = CreateCreature("Naga");
        public readonly static Trait MindFlayer = CreateCreature("Illithid", "Mind Flayer");
        public readonly static Trait Illithid = MindFlayer;
        public readonly static Trait Yaggol = CreateCreature("Yaggol");
        public readonly static Trait YukiOnNa = CreateCreature("Yuki-on-na");
        public readonly static Trait Quevari = CreateCreature("Quevari");
        public readonly static Trait Ravenkin = CreateCreature("Ravenkin");
        public readonly static Trait Medusa = CreateCreature("Medusa");
        public readonly static Trait Maeder = CreateCreature("Maeder", "Maedar");

        public readonly static Trait Doppelganger = CreateCreature("Doppelganger", "Doppleganger");
        public readonly static Trait InvisibleStalker = CreateCreature("Invisible Stalker");
        public readonly static Trait AerialServant = CreateCreature("Aerial Servant");
        public readonly static Trait Dreamshadow = CreateCreature("Dreamshadow");
        public readonly static Trait Dreamwraith = CreateCreature("Dreamwraith");
        public readonly static Trait Fetch = CreateCreature("Fetch");
        public readonly static Trait Homunculus = CreateCreature("Homunculus", "Homoculous");
        public readonly static Trait FireMinion = CreateCreature("Fire Minion");
        public readonly static Trait Ikiryo = CreateCreature("Ikiryo");
        public readonly static Trait Kaluk = CreateCreature("Kaluk");
        public readonly static Trait Allura = CreateCreature("Allura");
        public readonly static Trait Dreamslayer = CreateCreature("Dreamslayer");
        public readonly static Trait Ermordenung = CreateCreature("Ermordenung");
        public readonly static Trait Impersonator = CreateCreature("Impersonator");

        public readonly static Trait Oni = CreateCreature("Oni");
        public readonly static Trait CommonOni = CreateCreature("Common Oni", "Oni Mage", "Ogre Mage");
        public readonly static Trait GoZuOni = CreateCreature("Go-zu Oni", "Go-zu-Oni");
        public readonly static Trait MeZuOni = CreateCreature("Me-zu Oni", "Me-zu-Oni");

        public readonly static Trait Giant = CreateCreature("Giant");
        public readonly static Trait Krakentua = CreateCreature("Krakentua");

        #region Infernal/Fiendish
        public readonly static Trait Imp = CreateCreature("Imp");
        public readonly static Trait AssassinImp = CreateCreature("Assassin Imp");
        public readonly static Trait BloodSeaImp = CreateCreature("Blood Sea Imp", "Vapor Imp");
        public readonly static Trait Hellhound = CreateCreature("Hellhound");
        public readonly static Trait ShadowDemon = CreateCreature("Shadow Demon", "Shadow Fiend");
        public readonly static Trait Quasit = CreateCreature("Quasit", "Quazit");
        public readonly static Trait Berbalang = CreateCreature("Berbalang");
        public readonly static Trait GuardianDaemonLeast = CreateCreature("Least Guardian Daemon");
        public readonly static Trait GuardianDaemonLesser = CreateCreature("Lesser Guardian Daemon");
        public readonly static Trait GuardianDaemonGreater = CreateCreature("Greater Guardian Daemon");
        public readonly static Trait Bebilith = CreateCreature("Bebilith", "Barbed Horror");
        public readonly static Trait Gehreleth = CreateCreature("Gehreleth", "Demodand", "Leth");
        public readonly static Trait Hordling = CreateCreature("Hordling", "Hordeling");
        public readonly static Trait SoulLarva = CreateCreature("Soul Larva");
        public readonly static Trait Vaporighu = CreateCreature("Vaporighu");

        public readonly static Trait Baatezu = CreateCreature("Baatezu");
        public readonly static Trait Abishai = CreateCreature("Abishai");
        public readonly static Trait Spinagon = CreateCreature("Spinagon");
        public readonly static Trait Barbazu = CreateCreature("Barbazu");
        public readonly static Trait Erinyes = CreateCreature("Erinyes");
        public readonly static Trait Hamatula = CreateCreature("Hamatula");
        public readonly static Trait Nupperibo = CreateCreature("Nupperibo");
        public readonly static Trait PitFiend = CreateCreature("Pit Fiend");
        public readonly static Trait Amnizu = CreateCreature("Amnizu");
        public readonly static Trait Gelugon = CreateCreature("Gelugon");
        public readonly static Trait Osyluth = CreateCreature("Osyluth");
        public readonly static Trait Lemure = CreateCreature("Lemure");

        public readonly static Trait TanarRi = CreateCreature("Tanar'ri");
        public readonly static Trait Babau = CreateCreature("Babau");
        public readonly static Trait Chasme = CreateCreature("Chasme");
        public readonly static Trait Nabassu = CreateCreature("Nabassu");
        public readonly static Trait Molydeus = CreateCreature("Molydeus");
        public readonly static Trait Dretch = CreateCreature("Dretch");
        public readonly static Trait Manes = CreateCreature("Manes");
        public readonly static Trait Rutterkin = CreateCreature("Rutterkin");
        public readonly static Trait AluFiend = CreateCreature("Alu-Fiend");
        public readonly static Trait Barlgura = CreateCreature("Barlgura", "Bar -lgura");
        public readonly static Trait Cambion = CreateCreature("Cambion");
        public readonly static Trait Succubus = CreateCreature("Succubus");
        public readonly static Trait Balor = CreateCreature("Balor");
        public readonly static Trait Glabrezu = CreateCreature("Glabrezu");
        public readonly static Trait Hezrou = CreateCreature("Hezrou");
        public readonly static Trait Marilith = CreateCreature("Marilith");
        public readonly static Trait Nalfeshnee = CreateCreature("Nalfeshnee");
        public readonly static Trait Vrock = CreateCreature("Vrock");

        public readonly static Trait Yugoloth = CreateCreature("Yugoloth");
        public readonly static Trait Arcanaloth = CreateCreature("Arcanaloth");
        public readonly static Trait Nycaloth = CreateCreature("Nycaloth");
        public readonly static Trait Ultroloth = CreateCreature("Ultroloth");
        public readonly static Trait Dergholoth = CreateCreature("Dergholoth");
        public readonly static Trait Hydroloth = CreateCreature("Hydroloth");
        public readonly static Trait Mezzoloth = CreateCreature("Mezzoloth");
        public readonly static Trait Piscoloth = CreateCreature("Piscoloth");
        public readonly static Trait Yagnoloth = CreateCreature("Yagnoloth");
        #endregion

        #region Dragon & Dragon-like
        public readonly static Trait Darkenbeast = CreateCreature("Darkenbeast");
        public readonly static Trait Dragon = CreateCreature("Dragon");
        public readonly static Trait RedDragon = CreateCreature("Red Dragon");
        public readonly static Trait GoldDragon = CreateCreature("Gold Dragon");
        public readonly static Trait BlackDragon = CreateCreature("Black Dragon");
        public readonly static Trait ShadowDragon = CreateCreature("Shadow Dragon");
        public readonly static Trait FireLizard = CreateCreature("Fire Lizard");
        #endregion

        #region Hags
        public readonly static Trait Hag = CreateCreature("Hag");
        public readonly static Trait AnnisHag = CreateCreature("Annis Hag");
        public readonly static Trait GreenHag = CreateCreature("Green Hag");
        public readonly static Trait SeaHag = CreateCreature("Sea Hag");
        public readonly static Trait Hannya = CreateCreature("Hannya");
        public readonly static Trait NightHag = CreateCreature("Night Hag");
        #endregion

        #region Undead
        #region Incorporeal
        public readonly static Trait Shade = CreateCreature("Shade");
        public readonly static Trait Shadow = CreateCreature("Shadow");
        public readonly static Trait SlowShadow = CreateCreature("Slow Shadow");
        public readonly static Trait Spirit = CreateCreature("Spirit");
        public readonly static Trait Ghost = CreateCreature("Ghost");
        public readonly static Trait Wraith = CreateCreature("Wraith");
        public readonly static Trait Swordwraith = CreateCreature("Swordwraith", "Sword Wraith");
        public readonly static Trait SoulBeckoner = CreateCreature("Soul Beckoner");
        public readonly static Trait Spectre = CreateCreature("Spectre");
        public readonly static Trait Banshee = CreateCreature("Banshee");
        public readonly static Trait GrimReaper = CreateCreature("Grim Reaper", "Death Spirit");
        public readonly static Trait DeathSpirit = GrimReaper;
        public readonly static Trait Bussengeist = CreateCreature("Bussengeist");
        public readonly static Trait Odem = CreateCreature("Odem");
        public readonly static Trait Geist = CreateCreature("Geist");
        public readonly static Trait GreaterGeist = CreateCreature("Greater Geist");
        public readonly static Trait Haunt = CreateCreature("Haunt");
        public readonly static Trait Drelb = CreateCreature("Drelb");
        public readonly static Trait WillOWisp = CreateCreature("Will-o-Wisp");
        public readonly static Trait KeeningSpirit = CreateCreature("Keening Spirit", "Groaning Spirit");
        public readonly static Trait GroaningSpirit = KeeningSpirit;
        public readonly static Trait VampiricMist = CreateCreature("Vampiric Mist", "Crimson Death");
        public readonly static Trait CrimsonDeath = VampiricMist;
        public readonly static Trait Poltergeist = CreateCreature("Poltergeist");
        public readonly static Trait SpectralMinion = CreateCreature("Spectral Minion");
        public readonly static Trait ChuU = CreateCreature("Chu-u");
        public readonly static Trait ConTinh = CreateCreature("Con-tinh");
        public readonly static Trait Kuei = CreateCreature("Kuei", "Phii ha");
        public readonly static Trait Memedi = CreateCreature("Memedi");
        public readonly static Trait AncientMariner = CreateCreature("Ancient Mariner");
        public readonly static Trait Spiritjam = CreateCreature("Spiritjam");
        public readonly static Trait Bastellus = CreateCreature("Bastellus", "Nightmare Stalker", "Dream Stalker");
        public readonly static Trait Bowlyn = CreateCreature("Bowlyn", "Sailor's Demise");
        #endregion

        #region Corporeal stupid undead
        public readonly static Trait Zombie = CreateCreature("Zombie");
        public readonly static Trait StrahdZombie = CreateCreature("Strahd Zombie");
        public readonly static Trait SeaZombie = CreateCreature("Sea Zombie");
        public readonly static Trait JujuZombie = CreateCreature("Ju-ju Zombie");
        public readonly static Trait YellowMuskZombie = CreateCreature("Yellow Musk Zombie");

        public readonly static Trait Skeleton = CreateCreature("Skeleton");
        public readonly static Trait StrahdSkeleton = CreateCreature("Strahd Skeleton");
        public readonly static Trait WarriorSkeleton = CreateCreature("Warrior Skeleton", "Skeleton Warrior");
        public readonly static Trait GiantSkeleton = CreateCreature("Giant Skeleton");
        public readonly static Trait FireLizardSkeleton = CreateCreature("Fire Lizard Skeleton");
        public readonly static Trait SkeletalShark = CreateCreature("Skeletal Shark");

        public readonly static Trait SkeletonSteed = CreateCreature("Skeleton Steed", "Skeletal Steed");
        public readonly static Trait StrahdSteed = CreateCreature("Strahd's Skeletal Steed", "Strahd Skeleton Steed");
        public readonly static Trait SkeletalBat = CreateCreature("Skeletal Bat");

        public readonly static Trait Bodak = CreateCreature("Bodak");
        public readonly static Trait CrawlingClaw = CreateCreature("Crawling Claw");
        public readonly static Trait UndeadBeast = CreateCreature("Undead Beast");
        public readonly static Trait UndeadBeastStahnk = CreateCreature("Undead Beast (Stahnk)");
        public readonly static Trait UndeadBeastGholor = CreateCreature("Undead Beast (Gholor)");
        public readonly static Trait SpiritWarrior = CreateCreature("Spirit Warrior");
        public readonly static Trait StellarUndead = CreateCreature("Stellar Undead");

        public readonly static Trait TigbanuaBuso = CreateCreature("Tigbanua Buso");
        public readonly static Trait TagamalingBuso = CreateCreature("Tagamaling Buso");
        #endregion

        #region Corporeal smart undead
        public readonly static Trait Vampyre = CreateCreature("Vampyre");
        public readonly static Trait Vampire = CreateCreature("Vampire", "Voishlacka", "Vroklok");
        public readonly static Trait JiangShi = CreateCreature("Jiang Shi", "Oriental Vampire");
        public readonly static Trait Nosferatu = CreateCreature("Nosferatu");
        public readonly static Trait Mummy = CreateCreature("Mummy");
        public readonly static Trait GreaterMummy = CreateCreature("Greater Mummy", "Anhktepot's Children");
        public readonly static Trait Ghoul = CreateCreature("Ghoul");
        public readonly static Trait GhoulLord = CreateCreature("Ghoul Lord");
        public readonly static Trait Ghast = CreateCreature("Ghast");
        public readonly static Trait Lacedeon = CreateCreature("Lacedeon");
        public readonly static Trait Wight = CreateCreature("Wight");
        public readonly static Trait HalfWight = CreateCreature("Half-Wight");
        public readonly static Trait Lich = CreateCreature("Lich");
        public readonly static Trait Wichtlin = CreateCreature("Wichtlin");
        public readonly static Trait Revenant = CreateCreature("Revenant");
        public readonly static Trait DeathKnight = CreateCreature("Death Knight");
        public readonly static Trait CryptThing = CreateCreature("Crypt Thing");
        public readonly static Trait KnightHaunt = CreateCreature("Knight Haunt");
        public readonly static Trait Heucuva = CreateCreature("Heucuva");
        public readonly static Trait SonOfKyuss = CreateCreature("Son of Kyuss");
        public readonly static Trait DeathSkull = CreateCreature("Death Skull");
        public readonly static Trait Lebendtod = CreateCreature("Lebendtod");
        public readonly static Trait Demilich = CreateCreature("Demilich");
        public readonly static Trait FireShadow = CreateCreature("Fire Shadow", "Fireshadow");
        public readonly static Trait Firelich = CreateCreature("Firelich");
        public readonly static Trait Valpurgeist = CreateCreature("Valpurgeist");
        public readonly static Trait ZombieLord = CreateCreature("Zombie Lord");

        public readonly static Trait Gaki = CreateCreature("Gaki", "Nin-chu-ju-gaki");
        public readonly static Trait JikiKetsuGaki = CreateCreature("Jiki-ketsu-gaki");
        public readonly static Trait JikiNikuGaki = CreateCreature("Jiki-niku-gaki");
        public readonly static Trait ShikkiGaki = CreateCreature("Shikki-gaki");
        public readonly static Trait ShinenGaki = CreateCreature("Shinen-gaki");
        #endregion
        #endregion

        public readonly static Trait AnimatedRock = CreateCreature("Animated Rock");
        public readonly static Trait LivingWall = CreateCreature("Living Wall");
        public readonly static Trait LivingWeb = CreateCreature("Living Web");
        public readonly static Trait GuardianPortrait = CreateCreature("Guardian Portrait");
        public readonly static Trait DoomGuard = CreateCreature("Doom Guard");
        public readonly static Trait Mimic = CreateCreature("Mimic");
        public readonly static Trait KaniDoll = CreateCreature("Kani Doll");
        public readonly static Trait Necrophidius = CreateCreature("Necrophidius");
        public readonly static Trait Scarecrow = CreateCreature("Scarecrow");
        public readonly static Trait GoheiPOh = CreateCreature("Gohei P'oh", "P'oh Gohei", "Paper Ghost");
        public readonly static Trait StoneSpirit = CreateCreature("Stone Spirit");
        public readonly static Trait RavenloftScarecrow = CreateCreature("Ravenloft Scarecrow");

        #region Golems
        public readonly static Trait IronGolem = CreateCreature("Iron Golem");
        public readonly static Trait StoneGolem = CreateCreature("Stone Golem");
        public readonly static Trait FleshGolem = CreateCreature("Flesh Golem");
        public readonly static Trait SnowGolem = CreateCreature("Snow Golem");
        public readonly static Trait ClayGolem = CreateCreature("Clay Golem");

        public readonly static Trait RavenloftGolem = CreateCreature("Ravenloft Golem");
        public readonly static Trait ZombieGolem = CreateCreature("Zombie Golem");
        public readonly static Trait BoneGolem = CreateCreature("Bone Golem");
        public readonly static Trait DollGolem = CreateCreature("Doll Golem");
        public readonly static Trait GargoyleGolem = CreateCreature("Gargoyle Golem");
        public readonly static Trait GlassGolem = CreateCreature("Glass Golem");
        public readonly static Trait MechanicalGolem = CreateCreature("Mechanical Golem");
        #endregion

        #region Elementals
        public readonly static Trait QuasiElementalLightning = CreateCreature("Quasi-Elemental Lightning");
        public readonly static Trait Mihstu = CreateCreature("Mihstu");
        public readonly static Trait Sandling = CreateCreature("Sandling");
        public readonly static Trait Dweomerborn = CreateCreature("Dweomerborn");
        public readonly static Trait MistHorror = CreateCreature("Mist Horror");
        public readonly static Trait WanderingHorror = CreateCreature("Wandering Horror");

        public readonly static Trait RavenloftElemental = CreateCreature("Ravenloft Elemental");
        public readonly static Trait PyreElemental = CreateCreature("Pyre Elemental");
        public readonly static Trait BloodElemental = CreateCreature("Blood Elemental");
        public readonly static Trait MistElemental = CreateCreature("Mist Elemental");
        public readonly static Trait GraveElemental = CreateCreature("Grave Elemental");
        #endregion

        #region Animal Shifters
        public readonly static Trait Werewolf = CreateCreature("Werewolf", "Lycanthrope");
        public readonly static Trait Seawolf = CreateCreature("Seawolf");
        public readonly static Trait LoupDuNoir = CreateCreature("Loup Du Noir");
        public readonly static Trait LoupGarou = CreateCreature("Loup-Garou");
        public readonly static Trait LowlandLoupGarou = CreateCreature("Lowland Loup-Garou");
        public readonly static Trait MountainLoupGarou = CreateCreature("Mountain Loup-Garou");
        public readonly static Trait Jackalwere = CreateCreature("Jackalwere");
        public readonly static Trait Wolfwere = CreateCreature("Wolfwere");
        public readonly static Trait GreaterWolfwere = CreateCreature("Greater Wolfwere");
        public readonly static Trait Werebat = CreateCreature("Werebat");
        public readonly static Trait Werefox = CreateCreature("Werefox");
        public readonly static Trait Wererat = CreateCreature("Wererat");
        public readonly static Trait Werebear = CreateCreature("Werebear");
        public readonly static Trait Wereboar = CreateCreature("Wereboar");
        public readonly static Trait Weretiger = CreateCreature("Weretiger");
        public readonly static Trait Wereraven = CreateCreature("Wereraven");
        public readonly static Trait BeastMen = CreateCreature("Beast men");
        public readonly static Trait RedWidow = CreateCreature("Red Widow", "Spider Queen");

        public readonly static Trait GoblinRat = CreateCreature("Goblin Rat");
        public readonly static Trait HuHsien = CreateCreature("Hu Hsien");
        public readonly static Trait Hengeyokai = CreateCreature("Hengeyokai");
        public readonly static Trait FoxHengeyokai = CreateCreature("Fox Hengeyokai");
        public readonly static Trait RacoonDogHengeyokai = CreateCreature("Racoon Dog Hengeyokai");
        public readonly static Trait RatHengeyokai = CreateCreature("Rat Hengeyokai");
        #endregion

        #region Plants
        public readonly static Trait Quickwood = CreateCreature("Quickwood", "Carnivorous Plant", "Spy Tree");
        public readonly static Trait TwigBlight = CreateCreature("Twig Blight");
        public readonly static Trait NeedleBlight = CreateCreature("Needle Blight");
        public readonly static Trait VineBlight = CreateCreature("Vine Blight");
        public readonly static Trait AwakenedShrub = CreateCreature("Awakened Shrub");
        public readonly static Trait ManEatingPlant = CreateCreature("Man-eating plant");
        public readonly static Trait YellowMuskCreeper = CreateCreature("Yellow Musk Creeper");
        public readonly static Trait Kampfult = CreateCreature("Kampfult", "Sinewy Mugger");
        public readonly static Trait DopplegangerPlant = CreateCreature("Doppleganger Plant");
        public readonly static Trait Podling = CreateCreature("Podling");
        public readonly static Trait Treant = CreateCreature("Treant");
        public readonly static Trait EvilTreant = CreateCreature("Evil Treant");
        public readonly static Trait AnimatedTree = CreateCreature("Animated Tree");
        public readonly static Trait UndeadTreant = CreateCreature("Undead Treant");
        #endregion
    }
}