public partial class Factory : IDisposable
{
    private readonly List<Domain> domains = new(); //For trait distribution

    public void Dispose() //There is a chance I miss stuff out if its nested more than one layer.
    {
        foreach (var domain in domains)
        {
            //Do not bother doing this for Darklords cause they're already tracked within Characters.
            //so why does darklords exist? Its a cache cause darklords is referenced so often.
            AddLanguages(domain.Locations);
            AddLanguages(domain.Characters);
            AddLanguages(domain.Groups);
            AddLanguages(domain.Items);
            void AddLanguages<T> (ToTrack<T> entity) where T : UseVariableName =>
                domain.Languages.Add(Source, entity.PerSource[Source].SelectMany(e => e.Languages.PerSource[Source]));

            AddCreatures(domain.Locations);
            AddCreatures(domain.Characters); //Do not add related creatures traits
            AddCreatures(domain.Groups);
            AddCreatures(domain.Items);
            void AddCreatures<T>(ToTrack<T> entity) where T : UseVariableName =>
                domain.Creatures.Add(Source, entity.PerSource[Source].SelectMany(e => e.Creatures.PerSource[Source]));

            //Consider doing this for Clusters, Mistways, MistTalismans and anything else ToTrack.
            //That's if they ever get traits.
        }
    }
    private static void SetUpDomains()
    {
        var DomainToString = new Dictionary<DomainEnum, string[]>()
        { //Only contain domains that have 2+ words or strange characters in their names
            { DomainEnum.LMorai, new[] {"L`Morai", "The Carnival" } },
            { DomainEnum.HarAkir, new[] { "Har`Akir" }},
            { DomainEnum.ICath, new[] { "I`Cath" }},
            { DomainEnum.SriRaji, new[] { "Sri Raji", "Kalakeri" }},
            { DomainEnum.GHenna, new[] { "G`Henna" }},
            { DomainEnum.NightmareLands, new[] { "Nightmare Lands" }},
            { DomainEnum.NovaVaasa, new[] { "Nova Vaasa" }},
            { DomainEnum.Odiare, new[] { "Odiare", "Odaire" }},
            { DomainEnum.WindingRoad, new[] { "Winding Road", "Rider`s Bridge", "Endless Road" }},
            { DomainEnum.SeaOfSorrows, new[] { "Sea of Sorrows" }},
            { DomainEnum.IsleOfTheRavens, new[] { "Isle of the Ravens" }},
            { DomainEnum.TheLighthouse, new[] { "The Lighthouse", "L`ile de la Tempete" }},
            { DomainEnum.ShadowbornManor, new[] { "Shadowborn Manor", "Shadowlands" }},
            { DomainEnum.StauntonBluffs, new[] { "Staunton Bluffs" }},
            { DomainEnum.Paridon, new[] { "Paridon", "Zherisia" }},
            { DomainEnum.HouseOfLament, new[] { "House of Lament" }},
            { DomainEnum.Cyre1313, new[] { "Cyre 1313", "The Mourning Rail" }},
            { DomainEnum.VhageAgency, new[] { "Vhage Agency" }},
            { DomainEnum.VigilantsBluff, new[] { "Vigilant`s Bluff" }},
            { DomainEnum.TheBakumora, new[] { "The Bakumora" }},
            { DomainEnum.CastleIsland, new[] { "Castle Island" }},
            { DomainEnum.Nebligtode, new[] { "Nebligtode", "Nocturnal Sea" }},
            { DomainEnum.RokushimaTaiyoo, new[] { "Rokushima Taiyoo" }},
            { DomainEnum.ShadowRift, new[] { "Shadow Rift" }},
            { DomainEnum.TheEyrie, new[] { "The Eyrie" }},
            { DomainEnum.TheIsle, new[] { "The Isle" }},
            { DomainEnum.TheWildlands, new[] { "The Wildlands" }},
            { DomainEnum.LeederiksTower, new[] { "Leederik`s Tower" }},
            { DomainEnum.RichtenHaus, new[] { "Richten Haus" }},
            { DomainEnum.MithrasCourt, new[] { "Mithras Court" }},
            { DomainEnum.DonskoysLand, new[] { "Donskoy`s Land" }},
            { DomainEnum.AlKathos, new[] { "Al-Kathos" }},

            { DomainEnum.InsideRavenloft , new[] { "Inside Ravenloft"  }},
            { DomainEnum.OutsideRavenloft, new[] { "Outside Ravenloft" }}
        };

        foreach (var domain in Enum.GetValues<DomainEnum>())
        {
            DomainToString.TryGetValue(domain, out var domainNames);
            domainNames ??= new[] { domain.ToString() };

            Ravenloftdb.Domains.Add(domain, new Domain(domainNames));
        }

        Ravenloftdb.Domains[DomainEnum.Estrangia].ExtraInfo = Ravenloftdb.Domains[DomainEnum.AlKathos].ExtraInfo = "It's never explicitly stated that these are domains, but due to convenience they have been designated as such.";

        Ravenloftdb.Domains[DomainEnum.LMorai].ExtraInfo = "The Carnival was never explicitly stated to be a domain, nor did it have an obvious Darklord. This was changed in 5e. For convience of seeing the 2e/3e version, it will be considered a domain.";

        Ravenloftdb.Domains[DomainEnum.InsideRavenloft].ExtraInfo = "This is for things that do not have a stated domain.";
        Ravenloftdb.Domains[DomainEnum.OutsideRavenloft].ExtraInfo = "These are for things outside of Ravenloft but have some relation to it.";
    }

    public enum DomainEnum
    {
        Barovia, Bluetspur, Borca, LMorai, Darkon,
        Dementlieu, Falkovnia, HarAkir, Hazlan, ICath,
        SriRaji, Kartakass, Lamordia, Mordent, Richemulot,
        Tepest, Valachan, Forlorn, Ghastria, GHenna,
        Invidia, Keening, Markovia, NightmareLands, NovaVaasa,
        Odiare, WindingRoad, Risibilos, Scaena, SeaOfSorrows,
        Blaustein, Dominia, IsleOfTheRavens, TheLighthouse, ShadowbornManor,
        Souragne, StauntonBluffs, Tovag, Paridon, HouseOfLament,
        Demise, Sithicus, Cavitius, Cyre1313, Klorr,
        Niranjan, VhageAgency, VigilantsBluff, Kalidnay, Graefmotte,
        Histaven, Monadhan, Sunderheart, Timbergorge, TheBakumora,
        Aggarath, Avonleigh, CastleIsland, Daglan, Davion,
        Liffe, Nebligtode, Necropolis, Nidala, Nosos,
        Pharazia, RokushimaTaiyoo, Sanguinia, Saragross, Sebua,
        ShadowRift, TheEyrie, TheIsle, TheWildlands, Timor,
        Vechor, Verbrek, Vorostokov, LeederiksTower, Farelle,
        RichtenHaus, Malosia, MithrasCourt, Riverbend, Darani,
        Kislova, Maridrar, DonskoysLand, Estrangia, AlKathos,
        Arak, Gundarak, Dorvinia, Arkandale,

        InsideRavenloft, OutsideRavenloft //Special meta domains
    }
    public Domain TrackDomain(DomainEnum Name, string pageNumbers)
    {
        var retval = Ravenloftdb.Domains[Name]; //All domains already pregenerated

        retval.Appearances.Add(Source, new TrackPage<Domain>(retval, Source, pageNumbers));

        domains.Add(retval); //Important for trait distribution
        return retval;
    }
}