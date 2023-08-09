namespace Ravenloft
{
    internal static class AddToDatabase
    {
        public static void Add (RavenloftContext db) 
        {
            #region Canon
            var Canon     = db.Add(new Canon("Canon"    )).Entity;
            var SoftCanon = db.Add(new Canon("SoftCanon")).Entity;
            var NonCanon  = db.Add(new Canon("NonCanon" )).Entity;
            var Homebrew  = db.Add(new Canon("Homebrew" )).Entity;
            #endregion

            #region Edition
            var e1      = db.Add(new Edition("1e"   )).Entity;
            var e2      = db.Add(new Edition("2e"   )).Entity;
            var e3      = db.Add(new Edition("3e"   )).Entity;
            //var e3GC  = db.Add(new Edition("3eGC  )).Entity; //pre-Grand Conjuction
            var e4      = db.Add(new Edition("4e"   )).Entity;
            var e5      = db.Add(new Edition("5e"   )).Entity;
            var novel   = db.Add(new Edition("Novel")).Entity;
            #endregion

            #region Clusters
            var Core            = db.Add(new Cluster("Core"             )).Entity;
            var Shadowlands     = db.Add(new Cluster("The Shadowlands"  )).Entity;
            var AmberWastes     = db.Add(new Cluster("Amber Wastes"     )).Entity;
            var BurningPeaks    = db.Add(new Cluster("Burning Peaks"    )).Entity;
            var FrozenReaches   = db.Add(new Cluster("Frozen Reaches"   )).Entity;
            var VerdurousLands  = db.Add(new Cluster("Verdurous Lands"  )).Entity;
            var PocketDomains   = db.Add(new Cluster("Pocket Domains"   )).Entity;
            var IslandsOfTerror = db.Add(new Cluster("Islands of Terror")).Entity;
            #endregion

            #region Domains
            var Barovia         = db.Add(new Domain("Barovia")).Entity;
            var Bluetspur       = db.Add(new Domain("Bluetspur")).Entity;
            var Borca           = db.Add(new Domain ("Borca")).Entity;
            var LMorai          = db.Add(new Domain("L'Morai", "The Carnival")).Entity;
            var Darkon          = db.Add(new Domain("Darkon")).Entity;
            var Dementlieu      = db.Add(new Domain("Dementlieu")).Entity;
            var Falkovnia       = db.Add(new Domain("Falkovnia")).Entity;
            var HarAkir         = db.Add(new Domain("Har'Akir")).Entity;
            var Hazlan          = db.Add(new Domain("Hazlan")).Entity;
            var ICath           = db.Add(new Domain("I'Cath")).Entity;
            var SriRaji         = db.Add(new Domain("Sri Raji", "Kalakeri")).Entity;
            var Kartakass       = db.Add(new Domain("Kartakass")).Entity;
            var Lamordia        = db.Add(new Domain("Lamordia")).Entity;
            var Mordent         = db.Add(new Domain("Mordent")).Entity;
            var Richemulot      = db.Add(new Domain("Richemulot")).Entity;
            var Tepest          = db.Add(new Domain("Tepest")).Entity;
            var Valachan        = db.Add(new Domain("Valachan")).Entity;
            var Forlorn         = db.Add(new Domain("Forlorn")).Entity;
            var Ghastria        = db.Add(new Domain("Ghastria")).Entity;
            var Ghenna          = db.Add(new Domain("G'Henna")).Entity;
            var Invidia         = db.Add(new Domain("Invidia")).Entity;
            var Keening         = db.Add(new Domain("Keening")).Entity;
            var Markovia        = db.Add(new Domain("Markovia")).Entity;
            var NightmareLAnds  = db.Add(new Domain("Nightmare Lands")).Entity;
            var NovaVaasa       = db.Add(new Domain("Nova Vaasa")).Entity;
            var Odiare          = db.Add(new Domain("Odiare", "Odaire")).Entity;
            var WindingRoad     = db.Add(new Domain("Winding Road", "Endless Road", "Rider's Bridge")).Entity;
            var Risibilos       = db.Add(new Domain("Risibilos")).Entity;
            var Scaena          = db.Add(new Domain("Scaena")).Entity;
            var SeaOfSorrows    = db.Add(new Domain("Sea of Sorrows")).Entity;
            var Blaustein       = db.Add(new Domain("Blaustein")).Entity;
            var Dominia         = db.Add(new Domain("Dominia")).Entity;
            var IsleOfTheRavens = db.Add(new Domain("Isle of the Ravens")).Entity;
            var Lighthouse      = db.Add(new Domain("L'ile de le Tempete, The Lighthouse")).Entity;
            var ShadowbornManor = db.Add(new Domain("Shadowborn Manor", "Shadowlands")).Entity;
            var Souragne        = db.Add(new Domain("Souragne")).Entity;
            var StauntonBluffs  = db.Add(new Domain("Staunton Bluffs")).Entity;
            var Tovag           = db.Add(new Domain("Tovag")).Entity;
            var Paridon         = db.Add(new Domain("Paridon", "Zherisia")).Entity;
            var HouseOfLament   = db.Add(new Domain("House of Lament")).Entity;
            var Demise          = db.Add(new Domain("Demise")).Entity;
            var Kalidnay        = db.Add(new Domain("Kalidnay")).Entity;
            var Sithicus        = db.Add(new Domain("Sithicus")).Entity;
            var Cavitius        = db.Add(new Domain("Cavitius")).Entity;
            var Aggarath        = db.Add(new Domain("Aggarath")).Entity;
            var Avonleigh       = db.Add(new Domain("Avonleigh")).Entity;
            var CastleIsland    = db.Add(new Domain("Castle Island")).Entity;
            var Daglan          = db.Add(new Domain("Daglan")).Entity;
            var Davion          = db.Add(new Domain("Davion")).Entity;
            var Liffe           = db.Add(new Domain("Liffe")).Entity;
            var Nebligtode      = db.Add(new Domain("Nebligtode", "Nocturnal Sea")).Entity;
            var Necropolis      = db.Add(new Domain("Necropolis")).Entity;
            var Nidala          = db.Add(new Domain("Nidala")).Entity;
            var Nosos           = db.Add(new Domain("Nosos")).Entity;
            var Pharazia        = db.Add(new Domain("Pharazia")).Entity;
            var Rokushima       = db.Add(new Domain("Rokushima Taiyoo")).Entity;
            var Sanguinia       = db.Add(new Domain("Sanguinia")).Entity;
            var Saragross       = db.Add(new Domain("Saragross")).Entity;
            var Sebua           = db.Add(new Domain("Sebua")).Entity;
            var ShadowRift      = db.Add(new Domain("Shadow Rift")).Entity;
            var TheEyrie        = db.Add(new Domain("The Eyrie")).Entity;
            var TheIsle         = db.Add(new Domain("The Isle")).Entity;
            var TheWildlands    = db.Add(new Domain("The Wildlands")).Entity;
            var Timor           = db.Add(new Domain("Timor")).Entity;
            var Vechor          = db.Add(new Domain("Vechor")).Entity;
            var Verbrek         = db.Add(new Domain("Verbrek")).Entity;
            var Vorostokov      = db.Add(new Domain("Vorostokov")).Entity;
            var LeederiksTower  = db.Add(new Domain("Leederik's Tower")).Entity;
            var Farelle         = db.Add(new Domain("Farelle")).Entity;
            var RichtenHaus     = db.Add(new Domain("Richten Haus")).Entity;
            var Graefmotte      = db.Add(new Domain("Graefmotte")).Entity;
            var Histaven        = db.Add(new Domain("Histaven")).Entity;
            var Monadhan        = db.Add(new Domain("Monadhan")).Entity;
            var Sunderheart     = db.Add(new Domain("Sunderheart")).Entity;
            var Timbergorge     = db.Add(new Domain("Timbergorge")).Entity;
            var Bakumora        = db.Add(new Domain("Bakumora")).Entity;
            var Cyre1313        = db.Add(new Domain("Cyre 1313", "The Mourning Rail")).Entity;
            var Klorr           = db.Add(new Domain("Klorr")).Entity;
            var Niranjan        = db.Add(new Domain("Niranjan")).Entity;
            var VhageAgency     = db.Add(new Domain("Vhage Agency")).Entity;
            var VigilantsBluff  = db.Add(new Domain("Vigilant's Bluff")).Entity;
            var Malosia         = db.Add(new Domain ("Malosia")).Entity;
            var MithrasCourt    = db.Add(new Domain("Mithras Court")).Entity;
            var Riverbend       = db.Add(new Domain("Riverbend")).Entity;
            var Darani          = db.Add(new Domain("Darani")).Entity;
            var Kislova         = db.Add(new Domain("Kislova")).Entity;
            var Estrangia       = db.Add(new Domain("Estrangia")).Entity;
            var AlKathos        = db.Add(new Domain("Al-Kathos")).Entity;
            var Maridrar        = db.Add(new Domain("Maridrar")).Entity;
            var DonskoysLand    = db.Add(new Domain("Donskoy's Land")).Entity;
            #endregion

            #region Darklords
            var Strahd  = db.Add(new NPC("Count Strahd von Zarovich", "The Devil Strahd", "Lord Vasili von Holtz", "Strahd XI", "Vladislav")).Entity;
            var Maligno = db.Add(new NPC("Maligno", "Figlio")).Entity;
            #endregion

            var Darklord = db.Add(new CreatureTrait("Darklord")).Entity;

            var MistTalisman = db.Add(new ItemTrait("Mist Talisman")).Entity;

            #region Add Darklord to Domain
            Cross.Add(Odiare, Maligno);
            Cross.Add(Barovia, Strahd);
            #endregion

            #region Add Darklord trait to Darklord
            Cross.Add(Strahd, Darklord);
            Cross.Add(Maligno, Darklord);
            #endregion

            db.SaveChanges();
        }
    }
}