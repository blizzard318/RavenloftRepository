public partial class Factory : IDisposable
{
    internal static class GroupEnum
    {
        static GroupEnum()
        {
            Vistani.ExtraInfo = "Vistani didn't exist in 1e, and were known as gypsies. I'm using the term here for accuracy.";
            BurgomasterOfBarovia.ExtraInfo = "The specific burgomaster for the village of Barovia.";

            Religion.BindGroups(Deity);
            Vistani.BindGroups(HalfVistani, Darkling, Dukkar);
        }
        private static Group CreateGroup(params string[] names)
        {
            var retval = new Group(names);
            Ravenloftdb.Groups.Add(retval);
            return retval;
        }
        public readonly static Group DarkPowers = CreateGroup("Dark Powers");

        public readonly static Group Deity = CreateGroup("Deity"); //Use this to hold characters
        public readonly static Group Religion = CreateGroup("Religion"); //Use this to hold groups

        public readonly static Group Vistani = CreateGroup("Vistani", "Gypsy");
        public readonly static Group HalfVistani = CreateGroup("Half-Vistani");
        public readonly static Group Darkling = CreateGroup("Darkling");
        public readonly static Group Dukkar = CreateGroup("Dukkar");
        public readonly static Group Raunie = CreateGroup("Raunie");

        public readonly static Group AishaVistani = CreateGroup("Aisha`s group of Vistani");
        public readonly static Group VincenziaVistani = CreateGroup("Vincenzia`s group of Vistani");

        public readonly static Group Meistersinger = CreateGroup("Meistersinger");
        public readonly static Group EnduranceCrew = CreateGroup("Crew of the Endurance");

        public readonly static Group Boyar = CreateGroup("Boyar");
        public readonly static Group Burgomaster = CreateGroup("Burgomaster");
        public readonly static Group BurgomasterOfBarovia = CreateGroup("Burgomaster of Barovia");
        public readonly static Group BarovianWine = CreateGroup("Barovian Wine Distillers Brotherhood");
        public readonly static Group BridesOfStrahd = CreateGroup("Brides of Strahd");
        public readonly static Group Tatyana = CreateGroup("Reincarnations of Tatyana");
        public readonly static Group HighPriestRavenloft = CreateGroup("High Priest of Ravenloft");
        public readonly static Group HighPriestMostHoly = CreateGroup("High Priest of the Most Holy Order");

        public readonly static Group HighFaithOsterton = CreateGroup("Church of the High Faith in Osterton");

        public readonly static Group AbberNomad = CreateGroup("Abber Nomad");

        public readonly static Group TheKargat = CreateGroup("The Kargat");

        public readonly static Group PaladinsOfTheRaven = CreateGroup("Paladins of the Raven");

        public readonly static Group IronCrown = CreateGroup("Servants of the Iron Crown");
        public readonly static Group TalonOfTheHawk = CreateGroup("Talon of the Hawk");

        public readonly static Group HagsOfTepest = CreateGroup("Hags of Tepest");

        public readonly static Group RedWizard = CreateGroup("Red Wizard of Thay");

        public readonly static Group BluebeardWives = CreateGroup("Wives of Bluebeard");

        public readonly static Group AlecRapacionMilitia = CreateGroup("Militia of Captain Alec Rapacion");

        public readonly static Group Zhakata = CreateGroup("Religion of Zhakata");
        public readonly static Group Lathander = CreateGroup("Religion of Lathander");
        public readonly static Group Tyr = CreateGroup("Religion of Tyr");
        public readonly static Group Milil = CreateGroup("Religion of Milil");
        public readonly static Group WeeJas = CreateGroup("Religion of Wee Jas");
        public readonly static Group Diosamblet = CreateGroup("Religion of Diosamblet");
        public readonly static Group Ra = CreateGroup("Religion of Ra");
        public readonly static Group Kali = CreateGroup("Religion of Kali");
        public readonly static Group Rudra = CreateGroup("Religion of Rudra");
        public readonly static Group Shiva = CreateGroup("Religion of Shiva");
        public readonly static Group Ravana = CreateGroup("Religion of Ravana");
        public readonly static Group Yama = CreateGroup("Religion of Yama");
        public readonly static Group WolfGod = CreateGroup("Religion of the Wolf God");
        public readonly static Group Lolth = CreateGroup("Religion of Lolth");
        public readonly static Group Lendor = CreateGroup("Religion of Lendor");
        public readonly static Group Malar = CreateGroup("Religion of Malar");
        public readonly static Group Weeshy = CreateGroup("Religion of Weeshy");

        public readonly static Group Boritsi = CreateGroup("Boritsi Family");
        public readonly static Group dHonaire = CreateGroup("d`Honaire Family");
        public readonly static Group Dilisnya = CreateGroup("Dilisnya Family");
        public readonly static Group Drakov = CreateGroup("Drakov Family");
        public readonly static Group Renier = CreateGroup("Renier Family");
        public readonly static Group Timothy = CreateGroup("Timothy Family");
        public readonly static Group VonZarovich = CreateGroup("Von Zarovich Family");
        public readonly static Group Weathermay = CreateGroup("Weathermay Family");
        public readonly static Group Graben = CreateGroup("Graben Family");

        public readonly static Group Solamnia = CreateGroup("Knights of Solamnia");
        public readonly static Group RoseKnights = CreateGroup("Knights of the Rose");
    }
}