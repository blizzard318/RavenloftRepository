﻿using static Domain;
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
        public readonly static Darklord Bluebeard        = CreateDarklord("Lord Bluebeard");
        public readonly static Darklord IvanaBoritsi     = CreateDarklord("Lady Ivana Boritsi");
        public readonly static Darklord CamilleDilisnya  = CreateDarklord("Lady Camille Dilisnya");
        public readonly static Darklord IvanDilisnya     = CreateDarklord("Lord Ivan Dilisnya");
        public readonly static Darklord Vecna            = CreateDarklord("Vecna");
        public readonly static Darklord Daglan           = CreateDarklord("Daglan Daegon");
        public readonly static Darklord Radaga           = CreateDarklord("Radaga");
        public readonly static Darklord AzalinRex        = CreateDarklord("Azalin Rex");
        public readonly static Darklord VladDrakov       = CreateDarklord("Vlad Drakov");
        public readonly static Darklord YagnoPetrovna    = CreateDarklord("Yagno Petrovna");
        public readonly static Darklord LordGundar       = CreateDarklord("Duke Gundar", "Lord Gundar");
        public readonly static Darklord StezenDPolarno   = CreateDarklord("Stezen D`Polarno");
        public readonly static Darklord Anhktepot        = CreateDarklord("Pharaoh Anhktepot");
        public readonly static Darklord Hazlik           = CreateDarklord("Hazlik");
        public readonly static Darklord GabrielleAderre  = CreateDarklord("Gabrielle Aderre");
        public readonly static Darklord HarkonLukas      = CreateDarklord("Harkon Lukas");
        public readonly static Darklord Klorr            = CreateDarklord("Klorr");
        public readonly static Darklord Adam             = CreateDarklord("Adam");
        public readonly static Darklord Davion           = CreateDarklord("Davion, Davion the Mad");
        public readonly static Darklord LyronEvensong    = CreateDarklord("Baron Lyron Evensong");
        public readonly static Darklord FrantisekMarkov  = CreateDarklord("Lord Frantisek Markov", "Frant Markov", "Diosamblet", "Master of Pain");
        public readonly static Darklord WilfredGodefroy  = CreateDarklord("Lord Wilfred Godefroy");
        public readonly static Darklord Meredoth         = CreateDarklord("Meredoth");
        public readonly static Darklord TristenHiregaard = CreateDarklord("Sir Tristen Hiregaard", "Malken");
        public readonly static Darklord TristenApblanc   = CreateDarklord("Tristen Apblanc");
        public readonly static Darklord JacquelineRenier = CreateDarklord("Jacqueline Renier");
        public readonly static Darklord ClaudeRenier     = CreateDarklord("Claude Renier");
        public readonly static Darklord Tiyet            = CreateDarklord("Tiyet");
        public readonly static Darklord LordSoth         = CreateDarklord("Lord Loren Soth");
        public readonly static Darklord Arijani          = CreateDarklord("Maharaja Arijani", "Lord Arijani");
        public readonly static Darklord AntonMisroi      = CreateDarklord("Anton Misroi", "Lord of the Dead");
        public readonly static Darklord UrikVonKharkov   = CreateDarklord("Baron Urik von Kharkov");
        public readonly static Darklord HeadlessHorseman = CreateDarklord("The Headless Horseman");
        public readonly static Darklord DominicdHonaire  = CreateDarklord("Dominic d`Honaire");
        public readonly static Darklord AlfredTimothy    = CreateDarklord("Alfred Timothy");
        public readonly static Darklord NathanTimothy    = CreateDarklord("Captain Nathan Timothy");
        public readonly static Darklord Gwydion          = CreateDarklord("Gwydion");
        public readonly static Darklord GodBrain         = CreateDarklord("GodBrain");
        public readonly static Darklord Tristessa        = CreateDarklord("Tristessa");
        public readonly static Darklord JackKarn         = CreateDarklord("Jack Karn");
        public readonly static Darklord LadislavMircea   = CreateDarklord("Prince Ladislav Mircea");
        public readonly static Darklord Easen            = CreateDarklord("Easen the Mad");
        public readonly static Darklord Sodo             = CreateDarklord("Sodo");
        public readonly static Darklord Dominiani        = CreateDarklord("Doctor Daclaud Heinfroth", "Doctor Dominiani");
        public readonly static Darklord Ebonbane         = CreateDarklord("Ebonbane");
        public readonly static Darklord HouseOfLament    = CreateDarklord("House of Lament");
        public readonly static Darklord PhantomLover     = CreateDarklord("Phantom Lover", "Leederik");
        public readonly static Darklord GregorZolnik     = CreateDarklord("Boyar Gregor Zolnik");
        public readonly static Darklord CaptainMonette   = CreateDarklord("Captain Monette");
        public readonly static Darklord LeticiaMindefisk = CreateDarklord("Leticia Mindefisk");
        public readonly static Darklord LaveedaMindefisk = CreateDarklord("Laveeda Mindefisk");
        public readonly static Darklord LorindaMindefisk = CreateDarklord("Lorinda Mindefisk");
        public readonly static Darklord JesterPuncheron  = CreateDarklord("Jester Puncheron");
        public readonly static Darklord KingDoerdon      = CreateDarklord("King Doerdon");
        public readonly static Darklord TorrenceBleysmith = CreateDarklord("Sir Torrence Bleysmith");
    }
}