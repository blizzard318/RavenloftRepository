internal static class Traits
{
    //Trait Types: Edition, Canon, Media, Location, Status, Item, Group, Alignment, Item, Class, Race, Creature, Language, Mistway, Cluster
    public static Trait NoLink = Factory.CreateTrait("NoLink", "NoLink"); //Do not generate a link or a reference.

    #region Universal Traits
    internal static class Edition
    {
        static Edition() => e0.ExtraInfo = "Everything here are official products that do not belong to any edition of D&D.";
        public static Source.Trait e0  = Factory.CreateSourceTrait("Editionless"  , "Edition");
        public static Source.Trait e1  = Factory.CreateSourceTrait("1st Edition"  , "Edition");
        public static Source.Trait e2  = Factory.CreateSourceTrait("2nd Edition"  , "Edition");
        public static Source.Trait e3  = Factory.CreateSourceTrait("3rd Edition"  , "Edition");
        public static Source.Trait e35 = Factory.CreateSourceTrait("3.5th Edition", "Edition");
        public static Source.Trait e4  = Factory.CreateSourceTrait("4th Edition"  , "Edition");
        public static Source.Trait e5  = Factory.CreateSourceTrait("5th Edition"  , "Edition");
    }

    internal static class Canon
    {
        static Canon() => nc.ExtraInfo = pc.ExtraInfo = "Unless explicity stated as 'Potentially Canon' or 'Not Canon', everything else is treated Canon.";
        public static Source.Trait pc = Factory.CreateSourceTrait("Potentially Canon", "Canon");
        public static Source.Trait nc = Factory.CreateSourceTrait("Not Canon"        , "Canon");
    }

    internal static class Media
    {
        public static Source.Trait comic      = Factory.CreateSourceTrait("Comic"     , "Media");
        public static Source.Trait module     = Factory.CreateSourceTrait("Module"    , "Media");
        public static Source.Trait novel      = Factory.CreateSourceTrait("Novel"     , "Media");
        public static Source.Trait gamebook   = Factory.CreateSourceTrait("Gamebook"  , "Media");
        public static Source.Trait sourcebook = Factory.CreateSourceTrait("Sourcebook", "Media");
        public static Source.Trait magazine   = Factory.CreateSourceTrait("Magazine"  , "Media");
        public static Source.Trait videogame  = Factory.CreateSourceTrait("Video Game", "Media");
        public static Source.Trait boardgame  = Factory.CreateSourceTrait("Board Game", "Media");
    }

    internal static class Location
    {
        public static Trait Mistway    = Factory.CreateTrait("Mistway"   , "Location");
        public static Trait Cluster    = Factory.CreateTrait("Cluster"   , "Location");
        public static Trait Settlement = Factory.CreateTrait("Settlement", "Location");
        public static Trait Darklord => Status.Darklord;
        public static Trait Vistani => Status.Vistani;
    }

    internal static class Status
    {
        static Status() => Darklord.ExtraInfo = "Locations tagged as Darklord are their Lairs.";
        public static Trait Raunie   = Factory.CreateTrait("Raunie"  , "Status");
        public static Trait Deceased = Factory.CreateTrait("Deceased", "Status");
        public static Trait Vistani  = Factory.CreateTrait("Vistani" , "Group,Status,Location,Item");
        public static Trait Darklord = Factory.CreateTrait("Darklord", "Status,Location");
    }

    internal static class Alignment
    {
        public static Trait LG = Factory.CreateTrait("Lawful Good"    , "Alignment");
        public static Trait NG = Factory.CreateTrait("Neutral Good"   , "Alignment");
        public static Trait CG = Factory.CreateTrait("Chaotic Good"   , "Alignment");
        public static Trait LN = Factory.CreateTrait("Lawful Neutral" , "Alignment");
        public static Trait TN = Factory.CreateTrait("True Neutral"   , "Alignment");
        public static Trait CN = Factory.CreateTrait("Chaotic Neutral", "Alignment");
        public static Trait LE = Factory.CreateTrait("Lawful Evil"    , "Alignment");
        public static Trait NE = Factory.CreateTrait("Neutral Evil"   , "Alignment");
        public static Trait CE = Factory.CreateTrait("Chaotic Evil"   , "Alignment");
    }
    #endregion

    #region Domain-Tracked Traits
    internal static class Language
    {
        public static Trait Common = Factory.CreateTrait("Common", "Language");
    }

    internal static class Race
    {
        public static Trait Human = Factory.CreateTrait("Human", "Race");
        public static Trait Elf   = Factory.CreateTrait("Elf"  , "Race");
    }

    internal static class Group
    {
        public static Trait Vistani => Status.Vistani;
        public static Trait BarovianWineDistillersBrotherhood = Factory.CreateTrait("Barovian Wine Distillers Brotherhood", "Group");
    }

    internal static class Settlement //Everything here has to use Location.Settlement.Key
    {
        public static Trait VillageOfBarovia   = Factory.CreateTrait("Village of Barovia"  , Location.Settlement.Key);
        public static Trait TserPoolEncampment = Factory.CreateTrait("Tser Pool Encampment", Location.Settlement.Key);
    }

    internal static class Mistway //Everything here has to use Location.Mistway.Key
    {

    }
    internal static class Cluster //Everything here has to use Location.Cluster.Key
    {

    }

    internal static class Creature
    {
        static Creature()
        {
            KeeningSpirit.ExtraInfo = "Also known as 'Groaning Spirit'";
        }
        public static Trait Wolf  = Factory.CreateTrait("Wolf" , "Creature");
        public static Trait Bat   = Factory.CreateTrait("Bat"  , "Creature");
        public static Trait Horse = Factory.CreateTrait("Horse", "Creature");
        public static Trait Cat   = Factory.CreateTrait("Cat"  , "Creature");
        public static Trait GiantSpider = Factory.CreateTrait("Giant Spider", "Creature");
        public static Trait HugeSpider  = Factory.CreateTrait("Huge Spider", "Creature");

        public static Trait Worg        = Factory.CreateTrait("Worg"        , "Creature");
        public static Trait Nightmare   = Factory.CreateTrait("Nightmare"   , "Creature");
        public static Trait Hellhound   = Factory.CreateTrait("Hellhound"   , "Creature");
        public static Trait GreenSlime  = Factory.CreateTrait("Green Slime" , "Creature");
        public static Trait Gargoyle    = Factory.CreateTrait("Gargoyle"    , "Creature");
        public static Trait RustMonster = Factory.CreateTrait("Rust Monster", "Creature");
        public static Trait RedDragon   = Factory.CreateTrait("Red Dragon"  , "Creature");
        public static Trait ShadowDemon = Factory.CreateTrait("Shadow Demon", "Creature");
        public static Trait IronGolem   = Factory.CreateTrait("Iron Golem"  , "Creature");
        public static Trait Trapper     = Factory.CreateTrait("Trapper"     , "Creature");
        public static Trait GuardianPortrait = Factory.CreateTrait("Guardian Portrait", "Creature");

        public static Trait Spirit  = Factory.CreateTrait("Spirit" , "Creature");
        public static Trait Ghost   = Factory.CreateTrait("Ghost"  , "Creature");
        public static Trait Wraith  = Factory.CreateTrait("Wraith" , "Creature");
        public static Trait Spectre = Factory.CreateTrait("Spectre", "Creature");
        public static Trait Banshee = Factory.CreateTrait("Banshee", "Creature");
        public static Trait KeeningSpirit = Factory.CreateTrait("Keening Spirit", "Creature");

        public static Trait StrahdZombie = Factory.CreateTrait("Strahd Zombie", "Creature");
        public static Trait Zombie       = Factory.CreateTrait("Zombie"       , "Creature");
        public static Trait Skeleton     = Factory.CreateTrait("Skeleton"     , "Creature");

        public static Trait Vampire = Factory.CreateTrait("Vampire", "Creature");
        public static Trait Ghoul   = Factory.CreateTrait("Ghoul"  , "Creature");
        public static Trait Wight   = Factory.CreateTrait("Wight"  , "Creature");

        public static Trait Witch    = Factory.CreateTrait("Witch"   , "Creature");
        public static Trait Werewolf = Factory.CreateTrait("Werewolf", "Creature");
    }
    #endregion
}
