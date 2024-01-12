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
        public readonly static Location TserPoolEncampnent = CreateSettlement("Tser Pool Encampment");
        #endregion

        #region Darkon
        public readonly static Location IlAluk = CreateSettlement("Il Aluk");
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

        #region Darkon
        public readonly static Location PortaLucine = CreateSettlement("Port-a-Lucine");
        public readonly static Location Chateaufaux = CreateSettlement("Chateaufaux");
        #endregion

        #region Dementlieu
        public readonly static Location Levkarest = CreateSettlement("Levkarest");
        public readonly static Location Sturben = CreateSettlement("Sturben");
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
        #endregion

        #region G'Henna
        public readonly static Location Zukar = CreateSettlement("Zukar");
        #endregion

        #region Gundarak
        public readonly static Location Teufeldorf = CreateSettlement("Teufeldorf");
        public readonly static Location Zeidenburg = CreateSettlement("Zeidenburg");
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

        #region Mordent
        public readonly static Location Mordentshire = CreateSettlement("Mordentshire");
        #endregion
    }
}