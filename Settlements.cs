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
    }
}