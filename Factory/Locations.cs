public partial class Factory : IDisposable
{
    internal static class LocationEnum
    {
        private static Location CreateLocation(params string[] names)
        {
            var retval = new Location();
            retval.Names.UnionWith(names);
            Ravenloftdb.Locations.Add(retval);
            return retval;
        }
        public readonly static Location MillsOfNartok = CreateLocation("Lumber Mills (Nartok)");
        public readonly static Location DharlaethAsylum = CreateLocation("Dharlaeth Asylum");

        public readonly static Location CastleRavenloft = CreateLocation("Castle Ravenloft");
        public readonly static Location BaroviaChurch = CreateLocation("Church (Barovia)");
        public readonly static Location BildrathMercantile = CreateLocation("Bildrath's Mercantile");
        public readonly static Location BloodVineTavern = CreateLocation("Blood of the Vine Tavern", "Blood on the Vine Tavern");
        public readonly static Location MaryHouse = CreateLocation("Mad Mary's Townhouse");
        public readonly static Location BurgomasterHome = CreateLocation("Burgomaster's Home");
        public readonly static Location BurgomasterGuestHouse = CreateLocation("Burgomaster's Guest House");
        public readonly static Location BaroviaCemetery = CreateLocation("Cemetery (Barovia)");
        public readonly static Location MadamEvasTent = CreateLocation("Madam Eva's Tent");
        public readonly static Location OldSvalichRoad = CreateLocation("Old Svalich Road");
        public readonly static Location GatesOfBarovia = CreateLocation("Gates of Barovia");
        public readonly static Location SvalichWoods = CreateLocation("Svalich Woods");
        public readonly static Location RiverIvlis = CreateLocation("River Ivlis");
        public readonly static Location RoadJunction = CreateLocation("Road Junction (Barovia)");
        public readonly static Location TserFalls = CreateLocation("Tser Falls");
        public readonly static Location GatesOfRavenloft = CreateLocation("Gates of Ravenloft");

        public readonly static Location SaulbridgeSanitarium = CreateLocation("Saulbridge Sanitarium");
        public readonly static Location GryphonHill = CreateLocation("Gryphon Hill");
        public readonly static Location GryphonHillMansion = CreateLocation("Gryphon Hill Mansion");
        public readonly static Location HeatherHouse = CreateLocation("Weathermay Estate", "Heather House");
        public readonly static Location WeathermayEstate = HeatherHouse;
        public readonly static Location WeathermayMausoleum = CreateLocation("Weathermay Mausoleum");
        public readonly static Location BlackardInn = CreateLocation("Blackard Inn");
        public readonly static Location Livery = CreateLocation("Livery (Mordentshire)");
        public readonly static Location Garrison = CreateLocation("Garrison (Mordentshire)");
        public readonly static Location BurnedChurch = CreateLocation("Burned Church (Mordentshire)", "Church of High Faith");
        public readonly static Location Smithy = CreateLocation("Smithy (Mordentshire)");
        public readonly static Location MayorsHouse = CreateLocation("Mayor's House (Mordentshire)");
        public readonly static Location KervilsShop = CreateLocation("Kervil's Shop", "Kervil's General Store");
        public readonly static Location Marketplace = CreateLocation("Marketplace (Mordentshire)");
        public readonly static Location Warehouse = CreateLocation("Warehouse (Mordentshire)");
        public readonly static Location SouthRoad = CreateLocation("South Road (Mordentshire)");
        public readonly static Location KeeldevilPoint = CreateLocation("Keeldevil Point");
        public readonly static Location FishermanAlley = CreateLocation("Fisherman`s Alley");
        public readonly static Location ShippingHouse = CreateLocation("Shipping House (Mordentshire)");
        public readonly static Location SeventhSea = CreateLocation("The Seventh Sea");
        public readonly static Location TravelersInn = CreateLocation("Traveler`s Inn");
        public readonly static Location AnchorStreet = CreateLocation("Anchor Street");
        public readonly static Location ShoreLane = CreateLocation("Shore Lane");
        public readonly static Location MillRoad = CreateLocation("Mill Road");
        public readonly static Location MillBridge = CreateLocation("Mill Bridge");
        public readonly static Location ArdenRiver = CreateLocation("Arden River");
        public readonly static Location OldMill = CreateLocation("Old Mill (Mordentshire)");
        public readonly static Location Churchyard = CreateLocation("Churchyard (Mordentshire)");
        public readonly static Location OldSaltHouse = CreateLocation("Old Salt House");
        public readonly static Location SaltyDogTavern = CreateLocation("Salty Dog Tavern");
        public readonly static Location Butcher = CreateLocation("Butcher (Mordentshire)");
        public readonly static Location Bakery = CreateLocation("Bakery (Mordentshire)");
        public readonly static Location Groundskeeper = CreateLocation("Groundskeeper");
        public readonly static Location OldBooks = CreateLocation("Old Books");
        public readonly static Location Wharf = CreateLocation("Wharf (Mordentshire)");
        public readonly static Location Farms = CreateLocation("Farms (Mordentshire)");
        public readonly static Location ArdentBay = CreateLocation("Ardent Bay");
        public readonly static Location WindwandAvenue = CreateLocation("Windwand Avenue");
        public readonly static Location GlenRoad = CreateLocation("Glen Road");
        public readonly static Location MarketStreet = CreateLocation("Market Street");
        public readonly static Location Barracks = CreateLocation("Barracks (Mordentshire)");
        public readonly static Location Gaol = CreateLocation("Gaol (Mordentshire)");
        public readonly static Location HeatherWay = CreateLocation("Heather Way");
        public readonly static Location MaddingRoad = CreateLocation("Madding Road");
        public readonly static Location Backwater = CreateLocation("Backwater");
        public readonly static Location ButcherLane = CreateLocation("Butcher Lane");
        public readonly static Location WoodHollow = CreateLocation("Wood Hollow");
        public readonly static Location Cliffedge = CreateLocation("Cliffedge (Mordentshire)");
        public readonly static Location Scrimshaw = CreateLocation("Scrimshaw");
        public readonly static Location NorthRoad = CreateLocation("North Road (Mordentshire)");
        public readonly static Location Moors = CreateLocation("Moors (Mordentshire)");
        public readonly static Location NorthMoors = CreateLocation("North Moors");
        public readonly static Location Cliffs = CreateLocation("Cliffs (Mordentshire)");
        public readonly static Location DarkWoods = CreateLocation("Dark Woods (Mordentshire)");
        public readonly static Location GryphonRoad = CreateLocation("Gryphon Road");
        public readonly static Location Bog = CreateLocation("Bog (Mordentshire)");
        public readonly static Location Cemetery = CreateLocation("Cemetery (Mordentshire)");
        public readonly static Location HiddenTrack = CreateLocation("Hidden Track (Gryphon Hill)");
        public readonly static Location HeatherHousePoint = CreateLocation("Heather House Point");
        public readonly static Location Heatherwood = CreateLocation("Heatherwood");
        public readonly static Location HeatherRoad = CreateLocation("Heather Road");
    }
}