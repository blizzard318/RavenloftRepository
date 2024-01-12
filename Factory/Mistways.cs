public partial class Factory : IDisposable
{
    internal static class MistwayEnum
    {
        private static Location CreateMistway(params string[] names)
        {
            var retval = new Location(names);
            Ravenloftdb.Mistways.Add(retval);
            return retval;
        }

        public readonly static Location SteamwallMountains = CreateMistway("Steamwall Mountains Cave Portal");
        public readonly static Location XakTsaroth         = CreateMistway("Xak Tsaroth Wilderness Portal");
        public readonly static Location GreycloakHills     = CreateMistway("Greycloak Hills Pit");
        public readonly static Location KaraTurIsland      = CreateMistway("Kara-Tur Island Shore");
        public readonly static Location LortmillMountains  = CreateMistway("Lortmill Mountains Summit Alcove Opening");
        public readonly static Location RuinsOfGreyhawk    = CreateMistway("Ruins Of Greyhawk Portal");
    }
}
