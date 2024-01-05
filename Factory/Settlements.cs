public partial class Factory : IDisposable
{
    internal static class Settlement
    {
        private static Location CreateSettlement(params string[] names)
        {
            var retval = new Location();
            retval.Names.UnionWith(names);
            return retval;
        }
        public readonly static Location Nartok = CreateSettlement("Nartok");
        public readonly static Location Barovia = CreateSettlement("Barovia", "Village of Barovia");
        public readonly static Location Mordentshire = CreateSettlement("Mordentshire");
        public readonly static Location TserPoolEncampnent = CreateSettlement("Tser Pool Encampment");
    }
}