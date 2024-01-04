public partial class Factory : IDisposable
{
    internal static class CharacterEnum
    {
        private static NPC CreateCharacter(params string[] names)
        {
            var retval = new NPC();
            retval.Names.UnionWith(names);
            return retval;
        }
        public readonly static NPC Clarke = CreateCharacter("Clarke");
        public readonly static NPC Phillips = CreateCharacter("Phillips");
        public readonly static NPC DoctorAugustus = CreateCharacter("Doctor Augustus");
        public readonly static NPC NurseRoberts = CreateCharacter("Nurse Roberts");
        public readonly static NPC HowardAshton = CreateCharacter("Howard Ashton");

        public readonly static NPC CountStrahd = CreateCharacter("Count Strahd von Zarovich");
        public readonly static NPC IreenaKolyana = CreateCharacter("Ireena Kolyana");
        public readonly static NPC Tatyana = CreateCharacter("Tatyana");
        public readonly static NPC FatherDonavich = CreateCharacter("Father Donavich");
        public readonly static NPC KingBarov = CreateCharacter("King Barov von Zarovich");
        public readonly static NPC Ravenovia = CreateCharacter("Queen Ravenovia von Zarovich");
        public readonly static NPC Sergei = CreateCharacter("Sergei von Zarovich");
        public readonly static NPC MadamEva = CreateCharacter("Madam Eva");
        public readonly static NPC LiefLipsiege = CreateCharacter("Lief Lipsiege");
        public readonly static NPC Helga = CreateCharacter("Helga");
        public readonly static NPC CyrusBelview = CreateCharacter("Cyrus Belview");
        public readonly static NPC SpectreAbCenteer = CreateCharacter("Spectre Ab-Centeer");
        public readonly static NPC ArtistaDeSlop = CreateCharacter("Artista DeSlop");
        public readonly static NPC LadyIsoldeYunk = CreateCharacter("Lady Isolde Yunk", "Isolde the Incredible");
        public readonly static NPC AerialDuPlumette = CreateCharacter("Aerial the Heavy", "Prince Aerial Du Plumette");
        public readonly static NPC ArtankSwilovich = CreateCharacter("Artank Swilovich");
        public readonly static NPC DorfniyaDilisny = CreateCharacter("Duchess Dorfniya Dilisnya");
        public readonly static NPC Pidlwik = CreateCharacter("Pidlwik");
        public readonly static NPC LeanneTriksky = CreateCharacter("Sir Lee the Crusher", "Sir Leanne Triksky");
        public readonly static NPC TashaPetrovna = CreateCharacter("Tasha Petrovna");
        public readonly static NPC KingToisky = CreateCharacter("King Toisky");
        public readonly static NPC KingIntreeKatsky = CreateCharacter("Katsky the Bright", "King Intree Katsky");
        public readonly static NPC StahbalIndiBhak = CreateCharacter("Stahbal Indi-Bhak");
        public readonly static NPC Khazan = CreateCharacter("Khazan");
        public readonly static NPC ElsaFallona = CreateCharacter("Elsa Fallona");
        public readonly static NPC SedrikSpinwitovich = CreateCharacter("Admiral Spinwitovich", "Sir Sedrik Spinwitovich");
        public readonly static NPC Animus = CreateCharacter("Animus");
        public readonly static NPC ErikVonderbucks = CreateCharacter("Sir Erik Vonderbucks");
        public readonly static NPC IvanDeRose = CreateCharacter("Ivan DeRose");
        public readonly static NPC StephanGregorovich = CreateCharacter("Stephan Gregorovich");
        public readonly static NPC IntreeSikValoo = CreateCharacter("Intree Sik-Valoo");
        public readonly static NPC ArdentPallette = CreateCharacter("Ardent Pallette");
        public readonly static NPC IvanIvanovich = CreateCharacter("Ivan Ivanovich");
        public readonly static NPC CirilRomulich = CreateCharacter("Prefect Ciril Romulich");
        public readonly static NPC Dollars = CreateCharacter("$$");
        public readonly static NPC Finderway = CreateCharacter("St. Finderway");
        public readonly static NPC Dostron = CreateCharacter("King Dostron");
        public readonly static NPC GralmoreNimblenobs = CreateCharacter("Gralmore Nimblenobs");
        public readonly static NPC AmericoStandardski = CreateCharacter("Americo Standardski");
        public readonly static NPC Beucephalus = CreateCharacter("Beucephalus");
        public readonly static NPC TatsaulEris = CreateCharacter("Tatsaul Eris");
        public readonly static NPC AnnaPetrovna = CreateCharacter("AnnaPetrovna");
        public readonly static NPC Arik = CreateCharacter("Arik");
        public readonly static NPC MaryaMarkovia = CreateCharacter("Marya Markovia");
        public readonly static NPC Endorovich = CreateCharacter("Endorovich the Terrible");

        public readonly static NPC GuardianOfSorrow = CreateCharacter("Guardian of Sorrow");
        public readonly static NPC BabaLysaga = CreateCharacter("Baba Lysaga");
        public readonly static NPC Mikhash = CreateCharacter("Mikhash");
        public readonly static NPC JerenSureblade = CreateCharacter("Jeren Sureblade");
    }
}