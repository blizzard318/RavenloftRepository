public partial class Factory : IDisposable
{
    internal static class LocationEnum
    {
        private static Location CreateLocation(params string[] names)
        {
            var retval = new Location();
            retval.Names.UnionWith(names);
            return retval;
        }
        public readonly static Location MillsOfNartok = CreateLocation("Mills of Nartok");
        public readonly static Location DharlaethAsylum = CreateLocation("Dharlaeth Asylum");
    }
}