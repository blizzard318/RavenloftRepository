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
        private static Domain CreateDomain(params string[] names)
        {
            var retval = new Domain(names);
            Ravenloftdb.Domains.Add(retval);
            return retval;
        }
        public readonly static Domain Barovia = CreateDomain("Barovia");
        public readonly static Domain Bluetspur = CreateDomain("Bluetspur");
        public readonly static Domain Borca = CreateDomain("Borca");
        public readonly static Domain LMorai = CreateDomain("L`Morai", "The Carnival");
        public readonly static Domain Darkon = CreateDomain("Darkon");
        public readonly static Domain Dementlieu = CreateDomain("Dementlieu");
        public readonly static Domain Falkovnia = CreateDomain("Falkovnia");
        public readonly static Domain HarAkir = CreateDomain("Har`Akir");
        public readonly static Domain Hazlan = CreateDomain("Hazlan");
        public readonly static Domain ICath = CreateDomain("I`Cath");
        public readonly static Domain SriRaji = CreateDomain("SriRaji", "Kalakeri");
        public readonly static Domain Kartakass = CreateDomain("Kartakass");
        public readonly static Domain Lamordia = CreateDomain("Lamordia");
        public readonly static Domain Mordent = CreateDomain("Mordent");
        public readonly static Domain Richemulot = CreateDomain("Richemulot");
        public readonly static Domain Tepest = CreateDomain("Tepest");
        public readonly static Domain Valachan = CreateDomain("Valachan");
        public readonly static Domain Forlorn = CreateDomain("Forlorn");
        public readonly static Domain Ghastria = CreateDomain("Ghastria");
        public readonly static Domain GHenna = CreateDomain("G`Henna");
        public readonly static Domain Invidia = CreateDomain("Invidia");
        public readonly static Domain Keening = CreateDomain("Keening");
        public readonly static Domain Markovia = CreateDomain("Markovia");
        public readonly static Domain NightmareLands = CreateDomain("Nightmare Lands");
        public readonly static Domain NovaVaasa = CreateDomain("Nova Vaasa");
        public readonly static Domain Odiare = CreateDomain("Odiare", "Odaire");
        public readonly static Domain WindingRoad = CreateDomain("Winding Road", "Rider`s Bridge", "Endless Road");
        public readonly static Domain Risibilos = CreateDomain("Risibilos");
        public readonly static Domain Scaena = CreateDomain("Scaena");
        public readonly static Domain SeaOfSorrows = CreateDomain("Sea of Sorrows");
        public readonly static Domain Blaustein = CreateDomain("Blaustein");
        public readonly static Domain Dominia = CreateDomain("Dominia");
        public readonly static Domain IsleOfTheRavens = CreateDomain("Isle of the Ravens");
        public readonly static Domain TheLighthouse = CreateDomain("The Lighthouse", "L`ile de la Tempete");
        public readonly static Domain ShadowbornManor = CreateDomain("Shadowborn Manor", "Shadowlands");
        public readonly static Domain Souragne = CreateDomain("Souragne");
        public readonly static Domain StauntonBluffs = CreateDomain("Staunton Bluffs");
        public readonly static Domain Tovag = CreateDomain("Tovag");
        public readonly static Domain Paridon = CreateDomain("Paridon", "Zherisia");
        public readonly static Domain HouseOfLament = CreateDomain("House of Lament");
        public readonly static Domain Demise = CreateDomain("Demise");
        public readonly static Domain Sithicus = CreateDomain("Sithicus");
        public readonly static Domain Cavitius = CreateDomain("Cavitius");
        public readonly static Domain Cyre1313 = CreateDomain("Cyre 1313", "The Mourning Rail");
        public readonly static Domain Klorr = CreateDomain("Klorr");
        public readonly static Domain Niranjan = CreateDomain("Niranjan");
        public readonly static Domain VhageAgency= CreateDomain("Vhage Agency");
        public readonly static Domain VigilantsBluff= CreateDomain("Vigilant`s Bluff");
        public readonly static Domain Kalidnay= CreateDomain("Kalidnay");
        public readonly static Domain Graefmotte= CreateDomain("Graefmotte");
        public readonly static Domain Histaven= CreateDomain("Histaven");
        public readonly static Domain Monadhan= CreateDomain("Monadhan");
        public readonly static Domain Sunderheart= CreateDomain("Sunderheart");
        public readonly static Domain Timbergorge= CreateDomain("Timbergorge");
        public readonly static Domain TheBakumora= CreateDomain("The Bakumora");
        public readonly static Domain Aggarath= CreateDomain("Aggarath");
        public readonly static Domain Avonleigh= CreateDomain("Avonleigh");
        public readonly static Domain CastleIsland= CreateDomain("Castle Island");
        public readonly static Domain Daglan= CreateDomain("Daglan");
        public readonly static Domain Davion= CreateDomain("Davion");
        public readonly static Domain Liffe= CreateDomain("Liffe");
        public readonly static Domain Nebligtode= CreateDomain("Nebligtode", "Nocturnal Sea");
        public readonly static Domain Necropolis= CreateDomain("Necropolis");
        public readonly static Domain Nidala= CreateDomain("Nidala");
        public readonly static Domain Nosos= CreateDomain("Nosos");
        public readonly static Domain Pharazia= CreateDomain("Pharazia");
        public readonly static Domain RokushimaTaiyoo= CreateDomain("Rokushima Taiyoo");
        public readonly static Domain Sanguinia= CreateDomain("Sanguinia");
        public readonly static Domain Saragross= CreateDomain("Saragross");
        public readonly static Domain Sebua= CreateDomain("Sebua");
        public readonly static Domain ShadowRift= CreateDomain("Shadow Rift");
        public readonly static Domain TheEyrie= CreateDomain("The Eyrie");
        public readonly static Domain TheIsle= CreateDomain("The Isle");
        public readonly static Domain TheWildlands= CreateDomain("The Wildlands");
        public readonly static Domain Timor= CreateDomain("Timor");
        public readonly static Domain Vechor= CreateDomain("Vechor");
        public readonly static Domain Verbrek= CreateDomain("Verbrek");
        public readonly static Domain Vorostokov= CreateDomain("Vorostokov");
        public readonly static Domain LeederiksTower= CreateDomain("Leederik`s Tower");
        public readonly static Domain Farelle= CreateDomain("Farelle");
        public readonly static Domain RichtenHaus= CreateDomain("Richten Haus");
        public readonly static Domain Malosia= CreateDomain("Malosia");
        public readonly static Domain MithrasCourt= CreateDomain("Mithras Court");
        public readonly static Domain Riverbend= CreateDomain("Riverbend");
        public readonly static Domain Darani= CreateDomain("Darani");
        public readonly static Domain Kislova= CreateDomain("Kislova");
        public readonly static Domain Maridrar= CreateDomain("Maridrar");
        public readonly static Domain DonskoysLand= CreateDomain("Donskoy`s Land");
        public readonly static Domain Estrangia= CreateDomain("Estrangia");
        public readonly static Domain AlKathos= CreateDomain("Al-Kathos");
        public readonly static Domain Arak= CreateDomain("Arak");
        public readonly static Domain Gundarak= CreateDomain("Gundarak");
        public readonly static Domain Dorvinia= CreateDomain("Dorvinia");
        public readonly static Domain Arkandale= CreateDomain("Arkandale");
        public readonly static Domain InsideRavenloft= CreateDomain("Inside Ravenloft");
        public readonly static Domain OutsideRavenloft = CreateDomain("Outside Ravenloft");
    }
}