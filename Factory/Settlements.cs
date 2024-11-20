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
        #region Barovia
        public readonly static Location Barovia = CreateSettlement("Barovia", "Village of Barovia");
        public readonly static Location Vallaki = CreateSettlement("Vallaki");
        public readonly static Location TserPoolEncampnent = CreateSettlement("Tser Pool Encampment", "Gypsy Camp");
        public readonly static Location Krezk = CreateSettlement("Krezk");
        public readonly static Location Immol = CreateSettlement("Immol");
        #endregion

        #region Borca
        public readonly static Location Levkarest = CreateSettlement("Levkarest");
        public readonly static Location Sturben = CreateSettlement("Sturben");
        #endregion

        #region Daglan
        public readonly static Location Homlock = CreateSettlement("Homlock", "Homloch");
        #endregion

        #region Darkon
        public readonly static Location IlAluk = CreateSettlement("Il Aluk");
        public readonly static Location Despondia = CreateSettlement("Despondia");
        public readonly static Location Decimus = CreateSettlement("Decimus");
        public readonly static Location Desolatus = CreateSettlement("Desolatus");

        public readonly static Location MartiraBay = CreateSettlement("Martira Bay");
        public readonly static Location Karg = CreateSettlement("Karg");
        public readonly static Location Viaki = CreateSettlement("Viaka", "Viaki");
        public readonly static Location Nartok = CreateSettlement("Nartok");
        public readonly static Location Rivalis = CreateSettlement("Rivalis");
        public readonly static Location Corvia = CreateSettlement("Corvia");
        public readonly static Location TempeFalls = CreateSettlement("Tempe Falls");
        public readonly static Location Neblus = CreateSettlement("Neblus");
        public readonly static Location Maykle = CreateSettlement("Maykle");
        public readonly static Location Mayvin = CreateSettlement("Mayvin");
        public readonly static Location Delagia = CreateSettlement("Delagia");
        public readonly static Location NevucharSprings = CreateSettlement("Nevuchar Springs");
        public readonly static Location Sidnar = CreateSettlement("Sidnar");
        #endregion

        #region Dementlieu
        public readonly static Location PortaLucine = CreateSettlement("Port-a-Lucine");
        public readonly static Location Chateaufaux = CreateSettlement("Chateaufaux");
        #endregion

        #region Dorvinia
        public readonly static Location Lechberg = CreateSettlement("Lechberg");
        public readonly static Location Ilvin = CreateSettlement("Ilvin");
        public readonly static Location VorZiyden = CreateSettlement("VorZiyden");
        #endregion

        #region Falkovnia
        public readonly static Location Lekar = CreateSettlement("Lekar");
        public readonly static Location Stangengrad = CreateSettlement("Stangengrad");
        public readonly static Location Silbervas = CreateSettlement("Silbervas");
        public readonly static Location Aerie = CreateSettlement("Aerie");
        public readonly static Location Morfenzi = CreateSettlement("Morfenzi");
        #endregion

        #region Farelle
        public readonly static Location Kaynis = CreateSettlement("Kaynis");
        public readonly static Location Mortilis = CreateSettlement("Mortilis");
        #endregion

        #region G'Henna
        public readonly static Location Zukar = CreateSettlement("Zukar");
        public readonly static Location Dervich = CreateSettlement("Dervich");
        #endregion

        #region Ghastria
        public readonly static Location EastRiding = CreateSettlement("East Riding");
        #endregion

        #region Gundarak
        public readonly static Location Teufeldorf = CreateSettlement("Teufeldorf");
        public readonly static Location Zeidenburg = CreateSettlement("Zeidenburg");
        #endregion

        #region Har'akir
        public readonly static Location Muhar = CreateSettlement("Muhar", "Mudar");
        #endregion

        #region Hazlan
        public readonly static Location Toyalis = CreateSettlement("Toyalis");
        public readonly static Location SlyVar = CreateSettlement("Sly-Var");
        #endregion

        #region Invidia
        public readonly static Location Karina = CreateSettlement("Karina");
        #endregion

        #region Kartakass
        public readonly static Location Harmonia = CreateSettlement("Harmonia");
        public readonly static Location Skald = CreateSettlement("Skald");
        #endregion

        #region Keening
        public readonly static Location CityOfTheDead = CreateSettlement("City of the Dead");
        #endregion

        #region Lamordia
        public readonly static Location Ludendorf = CreateSettlement("Ludendorf");
        public readonly static Location Neufurchtenburg = CreateSettlement("Neufurchtenburg");
        #endregion

        #region Liffe
        public readonly static Location Moondale = CreateSettlement("Moondale");
        public readonly static Location Claveria = CreateSettlement("Claveria");
        public readonly static Location Armeikos = CreateSettlement("Armeikos");
        #endregion

        #region Markovia
        public readonly static Location Monastery = CreateSettlement("Monastery");
        #endregion

        #region Mordent
        public readonly static Location Mordentshire = CreateSettlement("Mordentshire");
        #endregion

        #region Nebligtode
        public readonly static Location Graben = CreateSettlement("Graben");
        public readonly static Location Seeheim = CreateSettlement("Seeheim");
        public readonly static Location Kirchenheim = CreateSettlement("Kirchenheim");
        public readonly static Location Meerdorf = CreateSettlement("Meerdorf");
        #endregion

        #region Nova Vaasa
        public readonly static Location Kantora = CreateSettlement("Kantora");
        public readonly static Location Liara = CreateSettlement("Liara");
        public readonly static Location Egertus = CreateSettlement("Egertus");
        public readonly static Location Bergovitsa = CreateSettlement("Bergovitsa");
        public readonly static Location Arbora = CreateSettlement("Arbora");
        #endregion

        #region Sanguinia
        public readonly static Location Tirgo = CreateSettlement("Tirgo");
        public readonly static Location Fagarus = CreateSettlement("Fagarus");
        public readonly static Location Kosova = CreateSettlement("Kosova");
        #endregion

        #region Sebua
        public readonly static Location RuinedVillage = CreateSettlement("Ruined Village");
        public readonly static Location Anhalla = CreateSettlement("Anhalla");
        #endregion

        #region Sithicus
        public readonly static Location MalErek = CreateSettlement("Mal-Erek");
        public readonly static Location Hroth = CreateSettlement("Hroth");
        public readonly static Location HarThelen = CreateSettlement("Har-Thelen");
        #endregion

        #region Souragne
        public readonly static Location PortdElhour = CreateSettlement("Port d`Elhour");
        #endregion

        #region Sri Raji / Kalakeri
        public readonly static Location Muladi = CreateSettlement("Muladi");
        public readonly static Location Pakat = CreateSettlement("Pakat");
        public readonly static Location Tvashsti = CreateSettlement("Tvashsti");
        #endregion

        #region Staunton Bluffs
        public readonly static Location Willisford = CreateSettlement("Willisford");
        #endregion

        #region Tepest
        public readonly static Location Viktal = CreateSettlement("Viktal");
        public readonly static Location Kellee = CreateSettlement("Kellee");
        #endregion

        #region Richemulot
        public readonly static Location PontaMuseau = CreateSettlement("Pont-a-Museau");
        public readonly static Location StRonges = CreateSettlement("St. Ronges");
        public readonly static Location Mortigny = CreateSettlement("Mortigny");
        #endregion

        #region Valachan
        public readonly static Location Ungrad = CreateSettlement("Ungrad");
        public readonly static Location Rotwald = CreateSettlement("Rotwald");
        public readonly static Location Habelnik = CreateSettlement("Habelnik");
        #endregion

        #region Vechor
        public readonly static Location Abdok = CreateSettlement("Abdok");
        #endregion

        #region Vorostokov
        public readonly static Location Vorostokov = CreateSettlement("Vorostokov");
        public readonly static Location Kirova = CreateSettlement("Kirova");
        public readonly static Location Torgov = CreateSettlement("Torgov");
        public readonly static Location Nordvik = CreateSettlement("Nordvik");
        public readonly static Location Kargo = CreateSettlement("Kargo");
        public readonly static Location Voronina = CreateSettlement("Voronina");
        public readonly static Location Oneka = CreateSettlement("Oneka");
        public readonly static Location Novayalenk = CreateSettlement("Novayalenk");
        public readonly static Location Siberski = CreateSettlement("Siberski");
        #endregion

        #region Paridon / Zherisia
        public readonly static Location Paridon = CreateSettlement("Paridon");
        #endregion

        #region Inside Ravenloft
        public readonly static Location Aferdale = CreateSettlement("Aferdale");
        #endregion
    }
}