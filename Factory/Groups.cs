public partial class Factory : IDisposable
{
    internal static class GroupEnum
    {
        static GroupEnum()
        {
            Vistani.ExtraInfo = "Vistani didn't exist in 1e, and were known as gypsies. I'm using the term here for accuracy.";
            BurgomasterOfBarovia.ExtraInfo = "The specific burgomaster for the village of Barovia.";
        }
        private static Group CreateGroup(params string[] names)
        {
            var retval = new Group();
            retval.Names.UnionWith(names);
            return retval;
        }
        public readonly static Group Vistani = CreateGroup("Vistani", "Gypsy");

        public readonly static Group Burgomaster = CreateGroup("Burgomaster");
        public readonly static Group BurgomasterOfBarovia = CreateGroup("Burgomaster of Barovia");
        public readonly static Group BarovianWine = CreateGroup("Barovian Wine Distillers Brotherhood");
        public readonly static Group BridesOfStrahd = CreateGroup("Brides of Strahd");
        public readonly static Group Tatyana = CreateGroup("Reincarnations of Tatyana");
        public readonly static Group HighPriestRavenloft = CreateGroup("High Priest of Ravenloft");
        public readonly static Group HighPriestMostHoly = CreateGroup("High Priest of the Most Holy Order");
    }
}