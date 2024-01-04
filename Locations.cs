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

        public readonly static Location CastleRavenloft = CreateLocation("Castle Ravenloft");
        public readonly static Location BaroviaChurch = CreateLocation("Church of Barovia");
        public readonly static Location BildrathMercantile = CreateLocation("Bildrath's Mercantile");
        public readonly static Location BloodVineTavern = CreateLocation("Blood of the Vine Tavern", "Blood on the Vine Tavern");
        public readonly static Location MaryHouse = CreateLocation("Mad Mary's Townhouse");
        public readonly static Location BurgomasterHome = CreateLocation("Burgomaster's Home");
        public readonly static Location BurgomasterGuestHouse = CreateLocation("Burgomaster's Guest House");
        public readonly static Location BaroviaCemetery = CreateLocation("Cemetery of Barovia");
        public readonly static Location MadamEvasTent = CreateLocation("Madam Eva's Tent");
    }
}