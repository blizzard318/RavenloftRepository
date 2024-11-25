public partial class Factory : IDisposable
{
    public static class CampaignSetting
    {
        private static Trait CreateSetting(params string[] names)
        {
            var retval = new Trait(names);
            Ravenloftdb.CampaignSettings.Add(retval);
            return retval;
        }
        public static readonly Trait Mystara = CreateSetting("Mystara");
        public static readonly Trait Planescape = CreateSetting("Planescape");
        public static readonly Trait Greyhawk = CreateSetting("Greyhawk");
        public static readonly Trait NentirVale = CreateSetting("Nentir Vale", "Points of Light");
        public static readonly Trait ForgottenRealms = CreateSetting("Forgotten Realms");
        public static readonly Trait Spelljammer = CreateSetting("Spelljammer");
        public static readonly Trait DarkSun = CreateSetting("Dark Sun");
        public static readonly Trait Birthright = CreateSetting("Birthright");
        public static readonly Trait Dragonlance = CreateSetting("Dragonlance");
        public static readonly Trait Eberron = CreateSetting("Eberron");
        public static readonly Trait MasqueOfRedDeath = CreateSetting("Masque of Red Death");
    }

    [Flags] public enum Alignment { LG = 1, LN = 1 << 1, LE = 1 << 2, NG = 1 << 3, TN = 1 << 4, NE = 1 << 5, CG = 1 << 6, CN = 1 << 7, CE = 1 << 8 };
    public static string AlignmentToString(Alignment e)
    {
        var retval = new List<string>();
        foreach (var alignment in Enum.GetValues<Alignment>())
            if (e.HasFlag(alignment))
                retval.Add(alignment.ToString());
        return string.Join("/", retval);
    }

    public static class Language
    {
        private static Trait CreateLanguage(params string[] names)
        {
            var retval = new Trait(names);
            Ravenloftdb.Languages.Add(retval);
            return retval;
        }

        public static readonly Trait Common = CreateLanguage("Common");
        public static readonly Trait Halfling = CreateLanguage("Halfling");
        public static readonly Trait Elf = CreateLanguage("Elf", "Elvish");
        public static readonly Trait Gnome = CreateLanguage("Gnome", "Gnomish");
        public static readonly Trait Dwarf = CreateLanguage("Dwarf", "Dwarvish");
        public static readonly Trait Orc = CreateLanguage("Orc", "Orcish");
        public static readonly Trait Kender = CreateLanguage("Kender");

        public static readonly Trait Balok = CreateLanguage("Balok");

        public static readonly Trait Illithid = CreateLanguage("Illithid");
        public static readonly Trait Goblin = CreateLanguage("Goblin");
        public static readonly Trait Hobgoblin = CreateLanguage("Hobgoblin");
        public static readonly Trait Ogre = CreateLanguage("Ogre");
        public static readonly Trait Drow = CreateLanguage("Drow");
        public static readonly Trait Troll = CreateLanguage("Troll");
        public static readonly Trait Gnoll = CreateLanguage("Gnoll");
        public static readonly Trait KuoToan = CreateLanguage("Kuo-Toan");

        public static readonly Trait Treant = CreateLanguage("Treant", "Treantish");
        public static readonly Trait EvilTreant = CreateLanguage("Evil Treant");

        public static readonly Trait HillGiant = CreateLanguage("Hill Giant");
        public static readonly Trait MountainGiant = CreateLanguage("Mountain Giant");

        public static readonly Trait RedDragon = CreateLanguage("Red Dragon");

        public static readonly Trait BurrowingMammals = CreateLanguage("Burrowing Mammals");
        public static readonly Trait DesertNomad = CreateLanguage("Desert Nomad");

        public static readonly Trait AbberNomad = CreateLanguage("Abber Nomad");
        public static readonly Trait Quevari = CreateLanguage("Quevari");
        public static readonly Trait Ravenkin = CreateLanguage("Ravenkin");

        public static readonly Trait Vistani = CreateLanguage("Vistani");
    }
}