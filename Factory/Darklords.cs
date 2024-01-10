using static Domain;
public partial class Factory : IDisposable
{
    internal static class DarklordEnum
    {
        private static Darklord CreateDarklord(params string[] names)
        {
            var retval = new Darklord(names);
            Ravenloftdb.Characters.Add(retval);
            return retval;
        }
        public readonly static Darklord CountStrahd      = CreateDarklord("Count Strahd von Zarovich");
        public readonly static Darklord Bluebeard        = CreateDarklord("Bluebeard");
        public readonly static Darklord IvanaBoritsi     = CreateDarklord("Ivana Boritsi");
        public readonly static Darklord Vecna            = CreateDarklord("Vecna");
        public readonly static Darklord Daglan           = CreateDarklord("Daglan");
        public readonly static Darklord AzalinRex        = CreateDarklord("Azalin Rex");
        public readonly static Darklord VladDrakov       = CreateDarklord("Vlad Drakov");
        public readonly static Darklord YagnoPetrovna    = CreateDarklord("Yagno Petrovna");
        public readonly static Darklord LordGundar       = CreateDarklord("Lord Gundar");
        public readonly static Darklord StezenDPolarno   = CreateDarklord("Stezen D`Polarno");
        public readonly static Darklord Anhktepot        = CreateDarklord("Anhktepot");
        public readonly static Darklord Hazlik           = CreateDarklord("Hazlik");
        public readonly static Darklord GabrielleAderre  = CreateDarklord("Gabrielle Aderre");
        public readonly static Darklord HarkonLukas      = CreateDarklord("Harkon Lukas");
        public readonly static Darklord Klorr            = CreateDarklord("Klorr");
        public readonly static Darklord Adam             = CreateDarklord("Adam");
        public readonly static Darklord LyronEvensong    = CreateDarklord("Baron Lyron Evensong");
        public readonly static Darklord FrantisekMarkov  = CreateDarklord("Frantisek Markov");
        public readonly static Darklord WilfredGodefroy  = CreateDarklord("Lord Wilfred Godefroy");
        public readonly static Darklord Meredoth         = CreateDarklord("Meredoth");
        public readonly static Darklord TristenHiregaard = CreateDarklord("Sir Tristen Hiregaard");
        public readonly static Darklord JacquelineRenier = CreateDarklord("Jacqueline Renier");
        public readonly static Darklord Tiyet            = CreateDarklord("Tiyet");
        public readonly static Darklord LordSoth         = CreateDarklord("Lord Loren Soth");
        public readonly static Darklord Arijani          = CreateDarklord("Arijani");
        public readonly static Darklord AntonMisroi      = CreateDarklord("Anton Misroi");
        public readonly static Darklord UrikVonKharkov   = CreateDarklord("Baron Urik von Kharkov");
        public readonly static Darklord HeadlessHorseman = CreateDarklord("The Headless Horseman");
    }
}