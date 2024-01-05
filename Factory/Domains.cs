public partial class Factory : IDisposable
{
    public void Dispose() => CrossAdd.Dispose();
    internal static class DomainEnum
    {
        static DomainEnum()
        {
            Estrangia.ExtraInfo = AlKathos.ExtraInfo = "It's never explicitly stated that these are domains, but due to convenience they have been designated as such.";

            LMorai.ExtraInfo = "The Carnival was never explicitly stated to be a domain, nor did it have an obvious Darklord. This was changed in 5e. For convience of seeing the 2e/3e version, it will be considered a domain.";

            InsideRavenloft.ExtraInfo = "This is for things that do not have a stated domain.";
            OutsideRavenloft.ExtraInfo = "These are for things outside of Ravenloft but have some relation to it.";
        }
        public readonly static Domain Barovia = new Domain("Barovia");
        public readonly static Domain Bluetspur = new Domain("Bluetspur");
        public readonly static Domain Borca = new Domain("Borca");
        public readonly static Domain LMorai = new Domain("L`Morai", "The Carnival");
        public readonly static Domain Darkon = new Domain("Darkon");
        public readonly static Domain Dementlieu = new Domain("Dementlieu");
        public readonly static Domain Falkovnia = new Domain("Falkovnia");
        public readonly static Domain HarAkir = new Domain("Har`Akir");
        public readonly static Domain Hazlan = new Domain("Hazlan");
        public readonly static Domain ICath = new Domain("I`Cath");
        public readonly static Domain SriRaji = new Domain("SriRaji", "Kalakeri");
        public readonly static Domain Kartakass = new Domain("Kartakass");
        public readonly static Domain Lamordia = new Domain("Lamordia");
        public readonly static Domain Mordent = new Domain("Mordent");
        public readonly static Domain Richemulot = new Domain("Richemulot");
        public readonly static Domain Tepest = new Domain("Tepest");
        public readonly static Domain Valachan = new Domain("Valachan");
        public readonly static Domain Forlorn = new Domain("Forlorn");
        public readonly static Domain Ghastria = new Domain("Ghastria");
        public readonly static Domain GHenna = new Domain("G`Henna");
        public readonly static Domain Invidia = new Domain("Invidia");
        public readonly static Domain Keening = new Domain("Keening");
        public readonly static Domain Markovia = new Domain("Markovia");
        public readonly static Domain NightmareLands = new Domain("Nightmare Lands");
        public readonly static Domain NovaVaasa = new Domain("Nova Vaasa");
        public readonly static Domain Odiare = new Domain("Odiare", "Odaire");
        public readonly static Domain WindingRoad = new Domain("Winding Road", "Rider`s Bridge", "Endless Road");
        public readonly static Domain Risibilos = new Domain("Risibilos");
        public readonly static Domain Scaena = new Domain("Scaena");
        public readonly static Domain SeaOfSorrows = new Domain("Sea of Sorrows");
        public readonly static Domain Blaustein = new Domain("Blaustein");
        public readonly static Domain Dominia = new Domain("Dominia");
        public readonly static Domain IsleOfTheRavens = new Domain("Isle of the Ravens");
        public readonly static Domain TheLighthouse = new Domain("The Lighthouse", "L`ile de la Tempete");
        public readonly static Domain ShadowbornManor = new Domain("Shadowborn Manor", "Shadowlands");
        public readonly static Domain Souragne = new Domain("Souragne");
        public readonly static Domain StauntonBluffs = new Domain("Staunton Bluffs");
        public readonly static Domain Tovag = new Domain("Tovag");
        public readonly static Domain Paridon = new Domain("Paridon", "Zherisia");
        public readonly static Domain HouseOfLament = new Domain("House of Lament");
        public readonly static Domain Demise = new Domain("Demise");
        public readonly static Domain Sithicus = new Domain("Sithicus");
        public readonly static Domain Cavitius = new Domain("Cavitius");
        public readonly static Domain Cyre1313 = new Domain("Cyre 1313", "The Mourning Rail");
        public readonly static Domain Klorr = new Domain("Klorr");
        public readonly static Domain Niranjan = new Domain("Niranjan");
        public readonly static Domain VhageAgency= new Domain("Vhage Agency");
        public readonly static Domain VigilantsBluff= new Domain("Vigilant`s Bluff");
        public readonly static Domain Kalidnay= new Domain("Kalidnay");
        public readonly static Domain Graefmotte= new Domain("Graefmotte");
        public readonly static Domain Histaven= new Domain("Histaven");
        public readonly static Domain Monadhan= new Domain("Monadhan");
        public readonly static Domain Sunderheart= new Domain("Sunderheart");
        public readonly static Domain Timbergorge= new Domain("Timbergorge");
        public readonly static Domain TheBakumora= new Domain("The Bakumora");
        public readonly static Domain Aggarath= new Domain("Aggarath");
        public readonly static Domain Avonleigh= new Domain("Avonleigh");
        public readonly static Domain CastleIsland= new Domain("Castle Island");
        public readonly static Domain Daglan= new Domain("Daglan");
        public readonly static Domain Davion= new Domain("Davion");
        public readonly static Domain Liffe= new Domain("Liffe");
        public readonly static Domain Nebligtode= new Domain("Nebligtode", "Nocturnal Sea");
        public readonly static Domain Necropolis= new Domain("Necropolis");
        public readonly static Domain Nidala= new Domain("Nidala");
        public readonly static Domain Nosos= new Domain("Nosos");
        public readonly static Domain Pharazia= new Domain("Pharazia");
        public readonly static Domain RokushimaTaiyoo= new Domain("Rokushima Taiyoo");
        public readonly static Domain Sanguinia= new Domain("Sanguinia");
        public readonly static Domain Saragross= new Domain("Saragross");
        public readonly static Domain Sebua= new Domain("Sebua");
        public readonly static Domain ShadowRift= new Domain("Shadow Rift");
        public readonly static Domain TheEyrie= new Domain("The Eyrie");
        public readonly static Domain TheIsle= new Domain("The Isle");
        public readonly static Domain TheWildlands= new Domain("The Wildlands");
        public readonly static Domain Timor= new Domain("Timor");
        public readonly static Domain Vechor= new Domain("Vechor");
        public readonly static Domain Verbrek= new Domain("Verbrek");
        public readonly static Domain Vorostokov= new Domain("Vorostokov");
        public readonly static Domain LeederiksTower= new Domain("Leederik`s Tower");
        public readonly static Domain Farelle= new Domain("Farelle");
        public readonly static Domain RichtenHaus= new Domain("Richten Haus");
        public readonly static Domain Malosia= new Domain("Malosia");
        public readonly static Domain MithrasCourt= new Domain("Mithras Court");
        public readonly static Domain Riverbend= new Domain("Riverbend");
        public readonly static Domain Darani= new Domain("Darani");
        public readonly static Domain Kislova= new Domain("Kislova");
        public readonly static Domain Maridrar= new Domain("Maridrar");
        public readonly static Domain DonskoysLand= new Domain("Donskoy`s Land");
        public readonly static Domain Estrangia= new Domain("Estrangia");
        public readonly static Domain AlKathos= new Domain("Al-Kathos");
        public readonly static Domain Arak= new Domain("Arak");
        public readonly static Domain Gundarak= new Domain("Gundarak");
        public readonly static Domain Dorvinia= new Domain("Dorvinia");
        public readonly static Domain Arkandale= new Domain("Arkandale");
        public readonly static Domain InsideRavenloft= new Domain("Inside Ravenloft");
        public readonly static Domain OutsideRavenloft = new Domain("Outside Ravenloft");
    }
}