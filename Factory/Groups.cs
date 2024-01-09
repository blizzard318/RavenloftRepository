﻿public partial class Factory : IDisposable
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

        public readonly static Group Burgomaster = CreateGroup("Burgomaster");
        public readonly static Group BurgomasterOfBarovia = CreateGroup("Burgomaster of Barovia");
        public readonly static Group BarovianWine = CreateGroup("Barovian Wine Distillers Brotherhood");
        public readonly static Group BridesOfStrahd = CreateGroup("Brides of Strahd");
        public readonly static Group Tatyana = CreateGroup("Reincarnations of Tatyana");
        public readonly static Group HighPriestRavenloft = CreateGroup("High Priest of Ravenloft");
        public readonly static Group HighPriestMostHoly = CreateGroup("High Priest of the Most Holy Order");

        public readonly static Group HighFaithOsterton = CreateGroup("Church of the High Faith in Osterton");

        public readonly static Group TheKargat = CreateGroup("The Kargat");
        
        public readonly static Group PaladinsOfTheRaven = CreateGroup("Paladins of the Raven");

        public readonly static Group IronCrown = CreateGroup("Servants of the Iron Crown");

        public readonly static Group HagsOfTepest = CreateGroup("Hags of Tepest");

        public readonly static Group RedWizard = CreateGroup("Red Wizard of Thay");

        public readonly static Group Zhakata = CreateGroup("Religion of Zhakata");
        public readonly static Group Lathander = CreateGroup("Religion of Lathander");
        public readonly static Group Tyr = CreateGroup("Religion of Tyr");
        public readonly static Group Milil = CreateGroup("Religion of Milil");
        public readonly static Group WeeJas = CreateGroup("Religion of Wee Jas");

        public readonly static Group Solamnia = CreateGroup("Knights of Solamnia");
        public readonly static Group RoseKnights = CreateGroup("Knights of the Rose");

    }
}