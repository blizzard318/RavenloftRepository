public partial class Factory : IDisposable
{
    internal static class Settlement
    {
        private static Location CreateSettlement(params string[] names)
        {
            var retval = new Location(names);
            Ravenloftdb.Locations.Add(retval);
            return retval;
        }
        public readonly static Location Harmonia = CreateSettlement("Harmonia");

        public readonly static Location Nartok = CreateSettlement("Nartok");
        public readonly static Location IlAluk = CreateSettlement("Il Aluk");
        public readonly static Location Viaki = CreateSettlement("Viaka", "Viaki");

        public readonly static Location Barovia = CreateSettlement("Barovia", "Village of Barovia");
        public readonly static Location TserPoolEncampnent = CreateSettlement("Tser Pool Encampment");

        public readonly static Location Mordentshire = CreateSettlement("Mordentshire");
    }
}