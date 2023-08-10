using System.Numerics;
using System.Threading.Channels;

namespace Ravenloft
{
    internal static class AddToDatabase
    {
        public static void Add (RavenloftContext db) 
        {
            T Add <T> (T input) where T : Base 
            {
                var retval = db.Find(typeof(T), input.Name) as T;
                if (retval == null) return db.Add(input).Entity;
                else return retval;
            }

            #region Canons
            var Canon     = Add(new Canon("Canon"    ));
            var SoftCanon = Add(new Canon("SoftCanon"));
            var NonCanon  = Add(new Canon("NonCanon" ));
            var Homebrew  = Add(new Canon("Homebrew" ));
            var Netbook   = Add(new Canon("Netbook"));
            #endregion

            #region Editions
            var e1   = Add(new Edition("1e"    ));
            var e2   = Add(new Edition("2e"    ));
            var e3   = Add(new Edition("3e"    ));
            var e3GC = Add(new Edition("3eGC"  )); //post-Grand Conjuction
            var e4   = Add(new Edition("4e"    ));
            var e5   = Add(new Edition("5e"    ));
            var nDnD = Add(new Edition("NotDnD")); //Videogame & novel characters
            #endregion

            #region Clusters
            var Core            = Add(new Cluster("Core"             ));
            var Shadowlands     = Add(new Cluster("The Shadowlands"  ));
            var AmberWastes     = Add(new Cluster("Amber Wastes"     ));
            var BurningPeaks    = Add(new Cluster("Burning Peaks"    ));
            var FrozenReaches   = Add(new Cluster("Frozen Reaches"   ));
            var VerdurousLands  = Add(new Cluster("Verdurous Lands"  ));
            var PocketDomains   = Add(new Cluster("Pocket Domains"   ));
            var IslandsOfTerror = Add(new Cluster("Islands of Terror"));
            var Shadowfell      = Add(new Cluster("Shadowfell"       ));
            #endregion

            #region Domains
            var Barovia         = Add(new Domain("Barovia"));
            var Bluetspur       = Add(new Domain("Bluetspur"));
            var Borca           = Add(new Domain("Borca"));
            var LMorai          = Add(new Domain("L'Morai", "The Carnival"));
            var Darkon          = Add(new Domain("Darkon"));
            var Dementlieu      = Add(new Domain("Dementlieu"));
            var Falkovnia       = Add(new Domain("Falkovnia"));
            var HarAkir         = Add(new Domain("Har'Akir"));
            var Hazlan          = Add(new Domain("Hazlan"));
            var ICath           = Add(new Domain("I'Cath"));
            var SriRaji         = Add(new Domain("Sri Raji", "Kalakeri"));
            var Kartakass       = Add(new Domain("Kartakass"));
            var Lamordia        = Add(new Domain("Lamordia"));
            var Mordent         = Add(new Domain("Mordent"));
            var Richemulot      = Add(new Domain("Richemulot"));
            var Tepest          = Add(new Domain("Tepest"));
            var Valachan        = Add(new Domain("Valachan"));
            var Forlorn         = Add(new Domain("Forlorn"));
            var Ghastria        = Add(new Domain("Ghastria"));
            var Ghenna          = Add(new Domain("G'Henna"));
            var Invidia         = Add(new Domain("Invidia"));
            var Keening         = Add(new Domain("Keening"));
            var Markovia        = Add(new Domain("Markovia"));
            var NightmareLAnds  = Add(new Domain("Nightmare Lands"));
            var NovaVaasa       = Add(new Domain("Nova Vaasa"));
            var Odiare          = Add(new Domain("Odiare", "Odaire"));
            var WindingRoad     = Add(new Domain("Winding Road", "Endless Road", "Rider's Bridge"));
            var Risibilos       = Add(new Domain("Risibilos"));
            var Scaena          = Add(new Domain("Scaena"));
            var SeaOfSorrows    = Add(new Domain("Sea of Sorrows"));
            var Blaustein       = Add(new Domain("Blaustein"));
            var Dominia         = Add(new Domain("Dominia"));
            var IsleOfTheRavens = Add(new Domain("Isle of the Ravens"));
            var Lighthouse      = Add(new Domain("L'ile de le Tempete, The Lighthouse"));
            var ShadowbornManor = Add(new Domain("Shadowborn Manor", "Shadowlands"));
            var Souragne        = Add(new Domain("Souragne"));
            var StauntonBluffs  = Add(new Domain("Staunton Bluffs"));
            var Tovag           = Add(new Domain("Tovag"));
            var Paridon         = Add(new Domain("Paridon", "Zherisia"));
            var HouseOfLament   = Add(new Domain("House of Lament"));
            var Demise          = Add(new Domain("Demise"));
            var Kalidnay        = Add(new Domain("Kalidnay"));
            var Sithicus        = Add(new Domain("Sithicus"));
            var Cavitius        = Add(new Domain("Cavitius"));
            var Aggarath        = Add(new Domain("Aggarath"));
            var Avonleigh       = Add(new Domain("Avonleigh"));
            var CastleIsland    = Add(new Domain("Castle Island"));
            var Daglan          = Add(new Domain("Daglan"));
            var Davion          = Add(new Domain("Davion"));
            var Liffe           = Add(new Domain("Liffe"));
            var Nebligtode      = Add(new Domain("Nebligtode", "Nocturnal Sea"));
            var Necropolis      = Add(new Domain("Necropolis"));
            var Nidala          = Add(new Domain("Nidala"));
            var Nosos           = Add(new Domain("Nosos"));
            var Pharazia        = Add(new Domain("Pharazia"));
            var Rokushima       = Add(new Domain("Rokushima Taiyoo"));
            var Sanguinia       = Add(new Domain("Sanguinia"));
            var Saragross       = Add(new Domain("Saragross"));
            var Sebua           = Add(new Domain("Sebua"));
            var ShadowRift      = Add(new Domain("Shadow Rift"));
            var TheEyrie        = Add(new Domain("The Eyrie"));
            var TheIsle         = Add(new Domain("The Isle"));
            var TheWildlands    = Add(new Domain("The Wildlands"));
            var Timor           = Add(new Domain("Timor"));
            var Vechor          = Add(new Domain("Vechor"));
            var Verbrek         = Add(new Domain("Verbrek"));
            var Vorostokov      = Add(new Domain("Vorostokov"));
            var LeederiksTower  = Add(new Domain("Leederik's Tower"));
            var Farelle         = Add(new Domain("Farelle"));
            var RichtenHaus     = Add(new Domain("Richten Haus"));
            var Graefmotte      = Add(new Domain("Graefmotte"));
            var Histaven        = Add(new Domain("Histaven"));
            var Monadhan        = Add(new Domain("Monadhan"));
            var Sunderheart     = Add(new Domain("Sunderheart"));
            var Timbergorge     = Add(new Domain("Timbergorge"));
            var Bakumora        = Add(new Domain("Bakumora"));
            var Cyre1313        = Add(new Domain("Cyre 1313", "The Mourning Rail"));
            var Klorr           = Add(new Domain("Klorr"));
            var Niranjan        = Add(new Domain("Niranjan"));
            var VhageAgency     = Add(new Domain("Vhage Agency"));
            var VigilantsBluff  = Add(new Domain("Vigilant's Bluff"));
            var Malosia         = Add(new Domain("Malosia"));
            var MithrasCourt    = Add(new Domain("Mithras Court"));
            var Riverbend       = Add(new Domain("Riverbend"));
            var Darani          = Add(new Domain("Darani"));
            var Kislova         = Add(new Domain("Kislova"));
            var Estrangia       = Add(new Domain("Estrangia"));
            var AlKathos        = Add(new Domain("Al-Kathos"));
            var Maridrar        = Add(new Domain("Maridrar"));
            var DonskoysLand    = Add(new Domain("Donskoy's Land"));
            var Arak            = Add(new Domain("Arak"));
            var Arkandale       = Add(new Domain("Arkandale"));
            var Dorvinia        = Add(new Domain("Dorvinia"));
            var Gundarak        = Add(new Domain("Gundarak"));
            #endregion

            #region Mistways
            var HereticsEgress   = Add(new Mistway("Heretic's Egress"));
            var ShroudedWay      = Add(new Mistway("Shrouded Way"));
            var ViaCorona        = Add(new Mistway("Via Corona"));
            var RoadOfSecrets    = Add(new Mistway("Road of a Thousand Secrets"));
            var ShatterPassage   = Add(new Mistway("Shattered Passage"));
            var JackalsRuse      = Add(new Mistway("Jackal's Ruse"));
            var WakeOfTheLoa     = Add(new Mistway("Wake of the Loa"));
            var WayfarerPath     = Add(new Mistway("Wayfarer's Path"));
            var CallOfTheClaw    = Add(new Mistway("Call of the Claw"));
            var BleakRoad        = Add(new Mistway("Bleak Road"));
            var SerpentsCoils    = Add(new Mistway("Serpent's Coils"));
            var UrchinsPath      = Add(new Mistway("Urchin's Path"));
            var VenomousTears    = Add(new Mistway("Way of Venomous Tears"));
            var RoyalChannel     = Add(new Mistway("Royal Channel"));
            var EmeraldStream    = Add(new Mistway("Emerald Stream"));
            var LeviathanClutch  = Add(new Mistway("Leviathan's Clutches"));
            var PathOfInnocence  = Add(new Mistway("Path of Innocence"));
            var SomnambulistPath = Add(new Mistway("Somnambulist's Path"));
            var SleepOfReason    = Add(new Mistway("Sleep of Reason"));
            var OutlandersGate   = Add(new Mistway("Outlander's Gate"));
            var OakOfScreams     = Add(new Mistway("Oak of Screams"));
            var MtFrostAnhalla   = Add(new Mistway("Mount Frost-Anhalla"));
            var IronWay          = Add(new Mistway("Iron Way"));
            var TheWindingJaws   = Add(new Mistway("Way of the Winding Jaws"));
            #endregion

            #region Sources
            #endregion

            #region Darklords
            var Strahd  = Add(new NPC("Count Strahd von Zarovich", "The Devil Strahd", "Lord Vasili von Holtz", "Strahd XI", "Vladislav"));
            var Diederic = Add(new NPC("Sir Diederic de Wyndt"));
            var Lucius = Add(new NPC("Lord Lucius Knight"));
            var Alistair = Add(new NPC("Doctor Alistair Weldon"));
            var Magroth = Add(new NPC("Emperor Magroth the Mad"));
            var Ilsabet = Add(new NPC("Baroness Ilsabet Obour"));
            var Whelm = Add(new NPC("Friar Whelm"));
            var Malbus = Add(new NPC("Malbus"));
            var Velkaarn = Add(new NPC("Lord Velkaarn"));
            var Milos = Add(new NPC("Lord Milos Donskoy"));
            var Maligno = Add(new NPC("Maligno", "Figlio"));
            #endregion

            var MistTalisman = Add(new ItemTrait("Mist Talisman"));

            #region Add Clusters Canon
            Cross.Add(Canon, Core);
            Cross.Add(Canon, Shadowlands);
            Cross.Add(Canon, AmberWastes);
            Cross.Add(Canon, BurningPeaks);
            Cross.Add(Canon, FrozenReaches);
            Cross.Add(Canon, VerdurousLands);
            Cross.Add(Canon, PocketDomains);
            Cross.Add(Canon, IslandsOfTerror);
            Cross.Add(Canon, Shadowfell);
            #endregion

            #region Add Domains Canon
            Cross.Add(Canon, Barovia);
            Cross.Add(Canon, Bluetspur);
            Cross.Add(Canon, Borca);
            Cross.Add(Canon, LMorai);
            Cross.Add(Canon, Darkon);
            Cross.Add(Canon, Dementlieu);
            Cross.Add(Canon, Falkovnia);
            Cross.Add(Canon, HarAkir);
            Cross.Add(Canon, Hazlan);
            Cross.Add(Canon, ICath);
            Cross.Add(Canon, SriRaji);
            Cross.Add(Canon, Kartakass);
            Cross.Add(Canon, Lamordia);
            Cross.Add(Canon, Mordent);
            Cross.Add(Canon, Richemulot);
            Cross.Add(Canon, Tepest);
            Cross.Add(Canon, Valachan);
            Cross.Add(Canon, Forlorn);
            Cross.Add(Canon, Ghastria);
            Cross.Add(Canon, Ghenna);
            Cross.Add(Canon, Invidia);
            Cross.Add(Canon, Keening);
            Cross.Add(Canon, Markovia);
            Cross.Add(Canon, NightmareLAnds);
            Cross.Add(Canon, NovaVaasa);
            Cross.Add(Canon, Odiare);
            Cross.Add(Canon, WindingRoad);
            Cross.Add(Canon, Risibilos);
            Cross.Add(Canon, Scaena);
            Cross.Add(Canon, SeaOfSorrows);
            Cross.Add(Canon, Blaustein);
            Cross.Add(Canon, Dominia);
            Cross.Add(Canon, IsleOfTheRavens);
            Cross.Add(Canon, Lighthouse);
            Cross.Add(Canon, ShadowbornManor);
            Cross.Add(Canon, Souragne);
            Cross.Add(Canon, StauntonBluffs);
            Cross.Add(Canon, Tovag);
            Cross.Add(Canon, Paridon);
            Cross.Add(Canon, HouseOfLament);
            Cross.Add(Canon, Demise);
            Cross.Add(Canon, Kalidnay);
            Cross.Add(Canon, Sithicus);
            Cross.Add(Canon, Cavitius);
            Cross.Add(Canon, Aggarath);
            Cross.Add(Canon, Avonleigh);
            Cross.Add(Canon, CastleIsland);
            Cross.Add(Canon, Daglan);
            Cross.Add(Canon, Davion);
            Cross.Add(Canon, Liffe);
            Cross.Add(Canon, Nebligtode);
            Cross.Add(Canon, Necropolis);
            Cross.Add(Canon, Nidala);
            Cross.Add(Canon, Nosos);
            Cross.Add(Canon, Pharazia);
            Cross.Add(Canon, Rokushima);
            Cross.Add(Canon, Sanguinia);
            Cross.Add(Canon, Saragross);
            Cross.Add(Canon, Sebua);
            Cross.Add(Canon, ShadowRift);
            Cross.Add(Canon, TheEyrie);
            Cross.Add(Canon, TheIsle);
            Cross.Add(Canon, TheWildlands);
            Cross.Add(Canon, Timor);
            Cross.Add(Canon, Vechor);
            Cross.Add(Canon, Verbrek);
            Cross.Add(Canon, Vorostokov);
            Cross.Add(Canon, LeederiksTower);
            Cross.Add(Canon, Farelle);
            Cross.Add(Canon, RichtenHaus);
            Cross.Add(Canon, Graefmotte);
            Cross.Add(Canon, Histaven);
            Cross.Add(Canon, Monadhan);
            Cross.Add(Canon, Sunderheart);
            Cross.Add(Canon, Timbergorge);
            Cross.Add(Canon, Bakumora);
            Cross.Add(Canon, Cyre1313);
            Cross.Add(Canon, Klorr);
            Cross.Add(Canon, Niranjan);
            Cross.Add(Canon, VhageAgency);
            Cross.Add(Canon, VigilantsBluff);
            Cross.Add(Canon, Malosia);
            Cross.Add(Canon, MithrasCourt);
            Cross.Add(Canon, Riverbend);
            Cross.Add(Canon, Darani);
            Cross.Add(Canon, Kislova);
            Cross.Add(Canon, Estrangia);
            Cross.Add(Canon, AlKathos);
            Cross.Add(Canon, Maridrar);
            Cross.Add(Canon, DonskoysLand);
            Cross.Add(Canon, Arak);
            Cross.Add(Canon, Arkandale);
            Cross.Add(Canon, Dorvinia);
            Cross.Add(Canon, Gundarak);
            #endregion

            #region Add Mistways Canon
            Cross.Add(Canon, EmeraldStream);
            Cross.Add(Canon, HereticsEgress);
            Cross.Add(Canon, JackalsRuse);
            Cross.Add(Canon, LeviathanClutch);
            Cross.Add(Canon, PathOfInnocence);
            Cross.Add(Canon, RoadOfSecrets);
            Cross.Add(Canon, ShatterPassage);
            Cross.Add(Canon, ShroudedWay);
            Cross.Add(Canon, ViaCorona);
            Cross.Add(Canon, WakeOfTheLoa);
            Cross.Add(Canon, VenomousTears);
            Cross.Add(Canon, WayfarerPath);

            Cross.Add(SoftCanon, BleakRoad);
            Cross.Add(SoftCanon, OutlandersGate);
            Cross.Add(SoftCanon, SerpentsCoils);
            Cross.Add(SoftCanon, MtFrostAnhalla);
            Cross.Add(SoftCanon, OakOfScreams);

            Cross.Add(Netbook, CallOfTheClaw);
            Cross.Add(Netbook, SomnambulistPath);
            Cross.Add(Netbook, RoyalChannel);
            Cross.Add(Netbook, TheWindingJaws);
            Cross.Add(Netbook, UrchinsPath);
            Cross.Add(Netbook, SleepOfReason);
            Cross.Add(Canon, IronWay);
            #endregion

            #region Add Darklord to Domain
            Cross.Add(Odiare, Maligno);
            Cross.Add(Barovia, Strahd);
            #endregion

            #region Add Darklord trait to Darklord
            var Darklord = Add(new CreatureTrait("Darklord"));
            Cross.Add(Strahd, Darklord);
            Cross.Add(Maligno, Darklord);
            #endregion

            db.SaveChanges();
        }
    }
}