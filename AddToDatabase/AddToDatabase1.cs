using static Factory;
internal static partial class AddToDatabase
{
    public static void Add1()
    {
        AddCommanderLegendsBattleforBaldursGate();
        AddDiceMastersStrahd();
        AddSpellfireMastertheMagic();
        AddTSRCollectorCards();

        void AddCommanderLegendsBattleforBaldursGate()
        {
            var releaseDate = "10/06/2022";
            string ExtraInfo = "<br/>&emsp;Illustrator: Slawomir Maniak";
            ExtraInfo += "<br/>&emsp;A Magic the Gathering Deck";
            using var ctx = CreateSource("Commander Legends: Battle for Baldur's Gate", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

            DomainEnum.Barovia.Appeared();
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.BabaLysaga).BindCreatures(Creature.Human, Creature.Witch);
        }
        void AddDiceMastersStrahd()
        {
            var releaseDate = "8/10/2016";
            var ExtraInfo = string.Empty;
            using var ctx = CreateSource("Dice Masters: Strahd", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

            DomainEnum.Barovia.Appeared();
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.CountStrahd);
            DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft).BindCharacters(CharacterEnum.CountStrahd);
        }
        void AddSpellfireMastertheMagic()
        {
            const string ExtraInfo = "Cards not listed are either not related to Ravenloft or too generic to add.";
            AddRavenloftSet();
            AddArtifactsSet();
            Add3rdEditionSet();
            AddUnderdarkSet();
            AddRunesNRuinsSet();
            Add4thEditionSet();
            AddNightstalkersSet();
            AddDungeonsSet();

            AddInquisitionSet();
            AddMilleniumSet();
            AddConquestSet();

            void AddRavenloftSet()
            {
                var releaseDate = "01/08/1994";
                using var ctx = CreateSource("Spellfire: Master the Magic, Ravenloft Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.Barovia.Appeared("1/100");
                DomainEnum.Darkon.Appeared("2/100");
                DomainEnum.Lamordia.Appeared("3/100");
                DomainEnum.Mordent.Appeared("4/100");
                DomainEnum.Kartakass.Appeared("5/100");
                DomainEnum.Keening.Appeared("6/100");
                DomainEnum.Tepest.Appeared("7/100");
                DomainEnum.Verbrek.Appeared("8/100").BindCreatures(Creature.Wolf);
                DomainEnum.Invidia.Appeared("9/100");
                DomainEnum.NovaVaasa.Appeared("10/100");
                DomainEnum.Dementlieu.Appeared("11/100");
                DomainEnum.Valachan.Appeared("12/100");
                DomainEnum.HarAkir.Appeared("13/100");
                DomainEnum.Souragne.Appeared("14/100");
                DomainEnum.SriRaji.Appeared("15/100");

                DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft, "16/100");

                DomainEnum.Darkon.AddLocation(LocationEnum.AzalinsGraveyard, "17/100").BindCreatures(Creature.Zombie);

                DomainEnum.Darkon.AddGroup(GroupEnum.TheKargat, "18/100").BindLocations(LocationEnum.KargatMausoleum);
                DomainEnum.Darkon.AddLocation(LocationEnum.KargatMausoleum, "18/100");

                DomainEnum.Paridon.Appeared("19/100").BindCreatures(Creature.Doppelganger);

                DomainEnum.HarAkir.AddLocation(LocationEnum.PharaohsRest, "20/100");

                DomainEnum.InsideRavenloft.AddGroup(GroupEnum.DarkPowers, "22/100");

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Book.SpellBookDrawmij, "29/100").Setting = CampaignSetting.Greyhawk;

                DomainEnum.InsideRavenloft.BindCreatures(
                    Creature.GraveElemental, // 35/100
                    Creature.Shade // 47/100
                );

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.TarokkaDeck, "56/100");

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Klorr, "57/100").BindItems(ItemEnum.TimepieceOfKlorr);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.TimepieceOfKlorr, "57/100");

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Ring.Regen, "58/100");
                DomainEnum.Barovia.AddItem(ItemEnum.Sunsword, "59/100");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.BloodCoin, "60/100");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Staff.Mimicry, "61/100");
                DomainEnum.Mordent.AddItem(ItemEnum.SoulSearcher, "62/100");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Ring.Reverse, "63/100");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Amulet.Beast, "64/100");

                DomainEnum.Valachan.AddLivingCharacter(CharacterEnum.Felkovic, "65/100");
                DomainEnum.Valachan.AddItem(ItemEnum.CatOfFelkovic, "65/100").BindCharacters(CharacterEnum.Felkovic);

                DomainEnum.Mordent.AddItem(ItemEnum.Apparatus, "66/100");
                DomainEnum.Daglan.AddItem(ItemEnum.CrownOfSouls, "67/100");
                DomainEnum.Barovia.AddItem(ItemEnum.SymbolOfRaven, "68/100");
                DomainEnum.NightmareLands.AddItem(ItemEnum.TapestryOfDarkSouls, "69/100");
                DomainEnum.Markovia.AddItem(ItemEnum.TapestryOfDarkSouls, "69/100");
                DomainEnum.NovaVaasa.AddItem(ItemEnum.TapestryOfDarkSouls, "69/100");
                DomainEnum.Tepest.AddItem(ItemEnum.TapestryOfDarkSouls, "69/100");
                DomainEnum.Valachan.AddItem(ItemEnum.FangOfTheNosferatu, "70/100");
                DomainEnum.Paridon.AddItem(ItemEnum.FangOfTheNosferatu, "70/100");

                DomainEnum.InsideRavenloft.BindCreatures(
                    Creature.Vampire, // 71/100
                    Creature.Wolf, // 72/100
                    Creature.FleshGolem, // 73/100
                    Creature.GhostShip, // 74/100
                    Creature.StrahdZombie, // 75/100
                    Creature.Spectre // 77/100
                );
                DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Vistani, "78/100");

                DomainEnum.InsideRavenloft.BindCreatures(
                    Creature.LoupGarou, // 79/100
                    Creature.Werebat //90/100
                );

                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.AzalinRex, "82/100").BindLocations(LocationEnum.AzalinsGraveyard);

                DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.Adam, "83/100");
                DomainEnum.HarAkir.AddLivingCharacter(CharacterEnum.Anhktepot, "84/100");
                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.IreenaKolyana, "85/100");
                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.DoctorRudolphVanRichten, "86/100");
                DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.HarkonLukas, "87/100");
                DomainEnum.WindingRoad.AddLivingCharacter(CharacterEnum.HeadlessHorseman, "88/100").BindRelatedCreatures(Creature.Horse);
                DomainEnum.SriRaji.AddLivingCharacter(CharacterEnum.Arijani, "89/100");
                DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LordWilfredGodefroy, "90/100");
                DomainEnum.Sebua.AddLivingCharacter(CharacterEnum.Tiyet, "91/100");
                DomainEnum.NovaVaasa.AddLivingCharacter(CharacterEnum.SirTristenHiregaard, "92/100");
                DomainEnum.Invidia.AddLivingCharacter(CharacterEnum.GabrielleAderre, "93/100");

                DomainEnum.Tepest.AddGroup(GroupEnum.HagsOfTepest, "94/100").BindCreatures(Creature.Hag);

                DomainEnum.Paridon.AddLivingCharacter(CharacterEnum.SirEdmundBloodsworth, "95/100").BindCreatures(Creature.Doppelganger);
                DomainEnum.Bluetspur.AddLivingCharacter(CharacterEnum.HighMasterIllithid, "96/100").BindCreatures(Creature.MindFlayer);
                DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.DoctorVictorMordenheim, "97/100");
                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Sergei, "98/100");
                DomainEnum.Sithicus.AddLivingCharacter(CharacterEnum.LordLorenSoth, "99/100");
                DomainEnum.Sithicus.AddLivingCharacter(CharacterEnum.CountStrahd, "100/100");
            }
            void AddArtifactsSet()
            {
                var releaseDate = "01/05/1995";
                using var ctx = CreateSource("Spellfire: Master the Magic, Artifacts Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.Arak.Appeared("12/100");
                DomainEnum.Arak.AddItem(ItemEnum.SealOfLostArak, "12/100");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.CrystalEbonFlame, "13/100").Setting = CampaignSetting.Greyhawk;
                DomainEnum.InsideRavenloft.BindCreatures(Creature.InvisibleStalker); //80/100
                DomainEnum.GHenna.AddLivingCharacter(CharacterEnum.YagnoPetrovna, "82/100");
                DomainEnum.Bluetspur.Appeared("88/100");
                DomainEnum.Kalidnay.Appeared("92/100").Setting = CampaignSetting.DarkSun;

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.DeathRock, "2/20");
                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.CountStrahd, "8/20");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.DeathRock, "2/20");
                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.GhostlyPiper, "10/20");
            }
            void Add3rdEditionSet()
            {
                var releaseDate = "01/10/1995";
                using var ctx = CreateSource("Spellfire: Master the Magic, 3rd Edition Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.TapestryOfTheStag, "426/440").Setting = CampaignSetting.Greyhawk;
            }
            void AddUnderdarkSet()
            {
                var releaseDate = "01/12/1995";
                using var ctx = CreateSource("Spellfire: Master the Magic, Underdark Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.InsideRavenloft.AddLocation(LocationEnum.UnderDread, "9/100");
                DomainEnum.InsideRavenloft.AddLocation(LocationEnum.DreadChamber, "18/100");

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.TheRedDeath, "68/100");
                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.ChantalBanshee, "97/100");
                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Iseult, "99/100");
            }
            void AddRunesNRuinsSet()
            {
                var releaseDate = "01/02/1996";
                using var ctx = CreateSource("Spellfire: Master the Magic, Runes & Ruins Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.InsideRavenloft.AddLocation(LocationEnum.TowerOfSpirits, "15/25");
            }
            void Add4thEditionSet()
            {
                var releaseDate = "01/07/1996";
                using var ctx = CreateSource("Spellfire: Master the Magic, 4th Edition Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.Bluetspur.Appeared("59/500");
                DomainEnum.Arak.Appeared("60/500").BindCreatures(Creature.Drow);
                DomainEnum.Borca.Appeared("61/500");

                DomainEnum.Gundarak.Appeared("62/500");
                DomainEnum.Gundarak.AddLivingDarklord(CharacterEnum.LordGundar, "62/500").BindCreatures(Creature.Ghost);

                ctx.CreateDomain("Sithicus", "63/500");
                ctx.CreateDomain("Nightmare Lands", "64/500");

                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Red Jack", "113/500"),
                    ctx.CreateNPC("Red Tide", "114/500").BindCreatures(Creature.Vampire),

                    ctx.CreateNPC("Pearl", "304/500"),
                    ctx.CreateNPC("Amber", "305/500"),
                    ctx.CreateNPC("Aquamarina", "306/500")
                );
                ctx.InsideRavenloft.BindCreatures(
                    Creature.Mummy, //352/500
                    Creature.Ghoul //353/500
                );
                ctx.InsideRavenloft.AddNPCs(ctx.CreateNPC("Ting Ling", "354/500"));
                ctx.InsideRavenloft.AddLocations(ctx.CreateLocation("The Death Ship", "355/500"));
                //Creature.Mummy, //356/500
                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Bride of Malice", "357/500").BindCreatures(Creature.Vampire, Creature.Dragon),
                    ctx.CreateNPC("Vulture of the Core", "358/500").BindCreatures(Creature.Vulture),
                    ctx.CreateNPC("The Bog Monster", "360/500")
                );
            }
            void AddNightstalkersSet()
            {
                var releaseDate = "01/09/1996";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Nightstalkers Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateDomain("Falkovnia", "5/100");
                ctx.CreateDomain("Richemulot", "6/100");

                ctx.CreateLocation("Haunted Graveyard", "11/100").BindCreatures(Creature.Ghost).AddDomains(ctx.InsideRavenloft);

                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Jacqueline Renier", "32/100"),
                    ctx.CreateNPC("Ratik Ubel", "33/100"),
                    ctx.CreateNPC("Julio, Master Thief of Haslic", "34/100"),
                    ctx.CreateNPC("Nemon Hotep", "67/100"),
                    ctx.CreateNPC("Shera the Wise", "68/100"),
                    ctx.CreateNPC("Varney the Vampire", "16/25").BindCreatures(Creature.Vampire),
                    ctx.CreateNPC("Gib Lhadsemlo", "18/25").BindCreatures(Creature.FleshGolem)
                );

                ctx.CreateLocation("Mad Scientist's Laboratory", "25/25").AddDomains(ctx.InsideRavenloft);
            }
            void AddDungeonsSet()
            {
                var releaseDate = "01/10/1997";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Dungeons Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.InsideRavenloft.AddLocations(
                    ctx.CreateLocation("Castle Strahd", "Castle Ravenloft", "7/100").BindCreatures(Creature.VampireBat),
                    ctx.CreateLocation("The Ruins of Lololia", "32/100")
                );
                ctx.InsideRavenloft.AddItems(ctx.CreateItem("Borer", "61/100"));
            }
            void AddInquisitionSet()
            {
                var releaseDate = "01/03/2001";
                var AddedExtraInfo = ExtraInfo + "<br/>This set was made by fans, but was still using Spellfire trademark.";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Inquisition Set", releaseDate, AddedExtraInfo, Traits.Edition.e0, Traits.Media.boardgame, Traits.Canon.NotCanon);
                if (ctx == null) return;

                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Lord Soth", "87/99"),
                    ctx.CreateNPC("Soth's Steed", "87/99").BindCreatures(Creature.Horse)
                );
            }
            void AddMilleniumSet()
            {
                var releaseDate = "01/03/2002";
                var AddedExtraInfo = ExtraInfo + "<br/>This set was made by fans, but was still using Spellfire trademark.";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Millenium Set", releaseDate, AddedExtraInfo, Traits.Edition.e0, Traits.Media.boardgame, Traits.Canon.NotCanon);
                if (ctx == null) return;

                var Strahd = ctx.CreateNPC("Count Strahd von Zarovich", "23/99");
                ctx.InsideRavenloft.AddNPCs(Strahd);
                var Medallion = ctx.CreateItem("Strahd's Medallion", "23/99").BindCreatures(Creature.Vampire);
                ctx.InsideRavenloft.AddItems(Medallion);
            }
            void AddConquestSet()
            {
                var releaseDate = "01/08/2004";
                var AddedExtraInfo = ExtraInfo + "<br/>This set was made by fans, but was still using Spellfire trademark.";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Conquest Set", releaseDate, AddedExtraInfo, Traits.Edition.e0, Traits.Media.boardgame, Traits.Canon.NotCanon);
                if (ctx == null) return;

                ctx.CreateLocation("Castle Strahd", "Castle Ravenloft", "73/81").BindCreatures(Creature.VampireBat).AddDomains(ctx.InsideRavenloft);
            }
        }
        void AddTSRCollectorCards()
        {
            const string ExtraInfo = "Cards not listed are either not related to Ravenloft or too generic to add.";

            Add1991Cards();
            Add1992Cards();
            Add1992PromoCards();
            Add1993Cards();
            Add1993PromoCards();

            void Add1991Cards()
            {
                var releaseDate = "01/01/1991";
                using var ctx = CreateSource("TSR Collector Cards, 1991 Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.Nebligtode.AddLivingCharacter(CharacterEnum.Meredoth, "381/750")
                    .BindCreatures(Creature.Human).BindAlignment(Alignment.CE)
                    .BindItems(ItemEnum.Cloak.Prot, ItemEnum.BracersOfDefense, ItemEnum.Ring.Shoot, ItemEnum.Rod.Smite, ItemEnum.Staff.TheSerpent);
                DomainEnum.Nebligtode.AddItem(ItemEnum.Cloak.Prot, "381/750");
                DomainEnum.Nebligtode.AddItem(ItemEnum.BracersOfDefense, "381/750");
                DomainEnum.Nebligtode.AddItem(ItemEnum.Ring.Shoot, "381/750");
                DomainEnum.Nebligtode.AddItem(ItemEnum.Rod.Smite, "381/750");
                DomainEnum.Nebligtode.AddItem(ItemEnum.Staff.TheSerpent, "381/750");

                DomainEnum.InsideRavenloft.BindCreatures(
                    Creature.GrimReaper, //382/750
                    Creature.Werebat, //383/750
                    Creature.VampireBat, //383/750
                    Creature.Bat, //383/750
                    Creature.Bussengeist //384/750
                    );

                DomainEnum.Invidia.AddLivingDarklord(CharacterEnum.GabrielleAderre, "481/750")
                    .BindCreatures(Creature.Human).BindAlignment(Alignment.NE)
                    .BindGroups(GroupEnum.HalfVistani, GroupEnum.Vistani);
                DomainEnum.Invidia.Appeared("481/750").BindGroups(GroupEnum.HalfVistani, GroupEnum.Vistani);
                DomainEnum.Invidia.AddGroup(GroupEnum.Vistani, "481/750");
                DomainEnum.Invidia.AddGroup(GroupEnum.HalfVistani, "481/750");

                DomainEnum.Darkon.Appeared("482/482");
                DomainEnum.Darkon.AddLivingDarklord(CharacterEnum.AzalinRex, "482/750")
                    .BindCreatures(Creature.Human, Creature.Lich).BindAlignment(Alignment.LE);

                DomainEnum.Falkovnia.Appeared("483/482")
                    .BindItems(ItemEnum.Ring.FreeAct, ItemEnum.Rod.Flail, ItemEnum.GauntletsOfOgrePower);
                DomainEnum.Falkovnia.AddLivingDarklord(CharacterEnum.VladDrakov, "483/750")
                    .BindCreatures(Creature.Human).BindAlignment(Alignment.NE)
                    .BindItems(ItemEnum.Ring.FreeAct, ItemEnum.Rod.Flail, ItemEnum.GauntletsOfOgrePower)
                    .Setting = CampaignSetting.Dragonlance;
                DomainEnum.Falkovnia.AddItem(ItemEnum.Ring.FreeAct, "483/750");
                DomainEnum.Falkovnia.AddItem(ItemEnum.Rod.Flail, "483/750");
                DomainEnum.Falkovnia.AddItem(ItemEnum.GauntletsOfOgrePower, "483/750");

                DomainEnum.Mordent.Appeared("484/750");
                DomainEnum.Mordent.AddLocation(LocationEnum.GryphonHill, "484/750");
                DomainEnum.Mordent.AddLocation(LocationEnum.GryphonHillMansion, "484/750").BindLocations(LocationEnum.GryphonHill);
                DomainEnum.Mordent.AddLivingDarklord(CharacterEnum.LordWilfredGodefroy, "484/750")
                    .BindLocations(LocationEnum.GryphonHill, LocationEnum.GryphonHillMansion)
                    .BindCreatures(Creature.Human, Creature.Ghost).BindAlignment(Alignment.CE);

                DomainEnum.Hazlan.Appeared("485/750");
                DomainEnum.Hazlan.AddLivingDarklord(CharacterEnum.Hazlik, "485/750")
                    .BindCreatures(Creature.Human).BindAlignment(Alignment.CE).Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.Hazlan.AddGroup(GroupEnum.RedWizard, "485/750")
                    .BindCharacters(CharacterEnum.Hazlik);
                DomainEnum.OutsideRavenloft.AddGroup(GroupEnum.RedWizard, "485/750")
                    .Setting = CampaignSetting.ForgottenRealms;

                DomainEnum.Barovia.Appeared("486/750, 488/750, 489/750, 611/750");
                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.HarkonLukas, "486/750");
                DomainEnum.Kartakass.Appeared("486/750");
                DomainEnum.Kartakass.AddLivingDarklord(CharacterEnum.HarkonLukas, "486/750")
                    .BindCreatures(Creature.Human, Creature.Wolfwere)
                    .BindItems(ItemEnum.CursedBerserker, ItemEnum.Elixir.Mad)
                    .BindAlignment(Alignment.NE);
                DomainEnum.Kartakass.AddItem(ItemEnum.CursedBerserker, "486/750");
                DomainEnum.Kartakass.AddItem(ItemEnum.Elixir.Mad, "486/750");

                DomainEnum.Markovia.Appeared("487/750");
                DomainEnum.Markovia.AddLivingCharacter(CharacterEnum.Ludmilla, "487/750")
                    .BindCreatures(Creature.Human)
                    .BindRelatedCreatures(Creature.Pig);
                DomainEnum.Markovia.AddLivingDarklord(CharacterEnum.FrantisekMarkov, "487/750")
                    .BindCreatures(Creature.Human)
                    .BindRelatedCreatures(Creature.Pig)
                    .BindAlignment(Alignment.LE)
                    .BindCharacters(CharacterEnum.Ludmilla);

                DomainEnum.GHenna.Appeared("488/750");
                DomainEnum.GHenna.AddGroup(GroupEnum.Zhakata, "488/750").BindGroups(GroupEnum.Religion);
                DomainEnum.GHenna.AddLivingCharacter(CharacterEnum.Zhakata, "488/750")
                    .BindGroups(GroupEnum.Deity, GroupEnum.Zhakata);
                DomainEnum.GHenna.AddLivingDarklord(CharacterEnum.YagnoPetrovna, "488/750")
                    .BindGroups(GroupEnum.Zhakata)
                    .BindCharacters(CharacterEnum.Zhakata)
                    .BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.LE);
                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.YagnoPetrovna);

                DomainEnum.Barovia.AddGroup(GroupEnum.Tatyana, "489/750, 611/750");
                DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Tatyana, "489/750, 611/750")
                    .BindGroups(GroupEnum.Tatyana);
                DomainEnum.Barovia.AddLivingDarklord(CharacterEnum.CountStrahd, "489/750, 611/750")
                    .BindCreatures(Creature.Human, Creature.Vampire)
                    .BindCharacters(CharacterEnum.Tatyana)
                    .BindItems(ItemEnum.Cloak.Prot, ItemEnum.Amulet.Proof)
                    .BindAlignment(Alignment.LE);
                DomainEnum.Barovia.AddItem(ItemEnum.Amulet.Proof, "489/750, 611/750");
                DomainEnum.Barovia.AddItem(ItemEnum.Cloak.Prot, "489/750, 611/750");

                DomainEnum.InsideRavenloft.AddLivingDarklord(CharacterEnum.EleazerClyde, "680/750")
                    .BindCreatures(Creature.Vampire, Creature.Human)
                    .BindItems(ItemEnum.Ring.SpellStoring, ItemEnum.Staff.ThunderAndLightning, ItemEnum.TalismanOfUltimateEvil)
                    .BindAlignment(Alignment.LE);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Ring.SpellStoring, "680/750");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Staff.ThunderAndLightning, "680/750");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.TalismanOfUltimateEvil, "680/750");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Cloak.Prot, "680/750");

                DomainEnum.OutsideRavenloft.AddGroup(GroupEnum.RoseKnights, "710/750");
                DomainEnum.OutsideRavenloft.AddGroup(GroupEnum.Solamnia, "710/750");
                DomainEnum.Sithicus.AddGroup(GroupEnum.RoseKnights, "710/750").Setting = CampaignSetting.Dragonlance;
                DomainEnum.Sithicus.AddGroup(GroupEnum.Solamnia, "710/750").Setting = CampaignSetting.Dragonlance;
                GroupEnum.Solamnia.BindGroups(GroupEnum.RoseKnights);
                DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Kitiara, "710/750").Setting = CampaignSetting.Dragonlance;
                DomainEnum.Sithicus.AddLivingCharacter(CharacterEnum.LordLorenSoth, "710/750").BindAlignment(Alignment.CE)
                    .BindCreatures(Creature.Human, Creature.DeathKnight).BindGroups(GroupEnum.RoseKnights, GroupEnum.Solamnia)
                    .BindCharacters(CharacterEnum.Kitiara).Setting = CampaignSetting.Dragonlance;

                DomainEnum.InsideRavenloft.AddLivingDarklord(CharacterEnum.TLaan, "723/750").BindAlignment(Alignment.CE)
                    .BindCreatures(Creature.Vampire).Setting = CampaignSetting.Spelljammer;
            }
            void Add1992Cards()
            {
                var releaseDate = "01/01/1992";
                using var ctx = CreateSource("TSR Collector Cards, 1992 Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.TarlVanovitch, "23/750").BindItems(ItemEnum.TarlVanovitchSunBlade);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.TarlVanovitchSunBlade, "23/750").BindAlignment(Alignment.NG).BindCreatures(Creature.Vampire);

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Quebe, "51/750").ExtraInfo = "No details about this character other than name.";
                DomainEnum.InsideRavenloft.AddLocation(LocationEnum.QuebeHauntedMansion, "51/750").BindCreatures(Creature.Ghoul, Creature.Vampire, Creature.Snake);

                DomainEnum.InsideRavenloft.BindCreatures(Creature.LivingWall); //53/750

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.HoelgarArnutsson, "61/750")
                    .BindAlignment(Alignment.CE).BindCreatures(Creature.Human, Creature.GoldDragon).BindItems(ItemEnum.DragonSlayer);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.DragonSlayer, "61/750");

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.RafeWillowand, "68/750")
                    .BindAlignment(Alignment.CN).BindCreatures(Creature.HalfElf).BindItems(ItemEnum.Brooch.ProtMagMiss, ItemEnum.BracersOfDefense);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Brooch.ProtMagMiss, "68/750");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.BracersOfDefense, "68/750");

                DomainEnum.Darkon.Appeared("86/750, 149/750, 151/750, 199/750, 326/750");
                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.MarionRobinsdottir, "86/750, 149/750")
                    .BindAlignment(Alignment.CG).BindCreatures(Creature.Human, Creature.Zombie)
                    .BindItems(ItemEnum.IncenseOfMed, ItemEnum.Ring.FreeAct, ItemEnum.BracersOfDefense);
                DomainEnum.Darkon.AddItem(ItemEnum.IncenseOfMed, "86/750");
                DomainEnum.Darkon.AddItem(ItemEnum.Ring.FreeAct, "86/750");
                DomainEnum.Darkon.AddItem(ItemEnum.BracersOfDefense, "86/750");

                DomainEnum.Falkovnia.Appeared("90/750");
                DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.SymbukTorul, "90/750")
                    .BindAlignment(Alignment.TN).BindCreatures(Creature.Human, Creature.Tiger)
                    .BindItems(ItemEnum.ArmorOfBlend, ItemEnum.EarringSetWithPeriapt);
                DomainEnum.Falkovnia.AddItem(ItemEnum.ArmorOfBlend, "90/750, 462/750");
                DomainEnum.Falkovnia.AddItem(ItemEnum.EarringSetWithPeriapt, "90/750");

                DomainEnum.Darkon.AddItem(ItemEnum.Robe.Marion, "86/750, 149/750").BindCharacters(CharacterEnum.MarionRobinsdottir);

                DomainEnum.Darkon.AddLivingDarklord(CharacterEnum.AzalinRex, "151/750, 326/750").BindCreatures(Creature.Lich);
                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.Mazrikoth, "151/750, 326/750");
                DomainEnum.Darkon.AddItem(ItemEnum.Scarab.Mazrikoth, "151/750").BindCharacters(CharacterEnum.AzalinRex, CharacterEnum.Mazrikoth);

                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.AlanikRay, "199/750").BindAlignment(Alignment.LN).BindCreatures(Creature.Elf);

                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.DorothaKenig, "200/750").BindAlignment(Alignment.LG).BindCreatures(Creature.HalfElf);
                DomainEnum.Darkon.AddSettlement(Settlement.Viaki, "200/750").BindCharacters(CharacterEnum.DorothaKenig);

                DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Lathander, "262/750").Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.OutsideRavenloft.AddGroup(GroupEnum.Lathander, "262/750");
                DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Lathander, "262/750")
                    .BindGroups(GroupEnum.Lathander, GroupEnum.Deity).Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Almen, "262/750").BindGroups(GroupEnum.Lathander);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Wand.Almen, "262/750").BindGroups(GroupEnum.Lathander)
                    .BindCharacters(CharacterEnum.Lathander, CharacterEnum.Almen);

                //ctx.Darklords = ctx.CreateGroup("Darklord", "285/750, 326/750");

                DomainEnum.Barovia.Appeared("285/750");
                DomainEnum.Barovia.AddLivingDarklord(CharacterEnum.CountStrahd, "285/750")
                    .BindCreatures(Creature.Human, Creature.Vampire).BindAlignment(Alignment.LE);

                DomainEnum.InsideRavenloft.BindCreatures(
                    Creature.Nosferatu, //286/750
                    Creature.Dwarf,     //287/750
                    Creature.Halfling,  //288/750
                    Creature.Kender,    //289/750
                    Creature.Elf,       //290/750
                    Creature.Gnome,     //291/750
                    Creature.Vampyre    //292/750
                    );

                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.JanderSunstar, "293/750").BindAlignment(Alignment.TN)
                    .BindCreatures(Creature.Elf, Creature.GoldenElf, Creature.Vampire);

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Leilana, "296/750").BindAlignment(Alignment.LG)
                    .BindCreatures(Creature.Elf).BindRelatedCreatures(Creature.Unicorn);

                DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.Killeen, "312/750").BindAlignment(Alignment.NG)
                    .BindCreatures(Creature.Elf).BindItems(ItemEnum.Robe.Blend, ItemEnum.Wand.SecretDoor);
                DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.VladDrakov, "312/750");
                DomainEnum.Falkovnia.AddItem(ItemEnum.Robe.Blend, "312/750");
                DomainEnum.Falkovnia.AddItem(ItemEnum.Wand.SecretDoor, "312/750");

                DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.Kevlin, "320/750").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.NE).BindItems(ItemEnum.Ring.HumanInfluence, ItemEnum.Ring.VampRegen)
                    .BindGroups(GroupEnum.IronCrown);
                DomainEnum.Falkovnia.AddItem(ItemEnum.Ring.HumanInfluence, "320/750");
                DomainEnum.Falkovnia.AddItem(ItemEnum.Ring.VampRegen, "320/750");
                DomainEnum.Falkovnia.AddGroup(GroupEnum.IronCrown, "320/750");

                CharacterEnum.Mazrikoth.BindCreatures(Creature.Human).BindAlignment(Alignment.LE)
                    .BindItems(ItemEnum.Staff.ThunderAndLightning, ItemEnum.Book.VileDarkness, ItemEnum.TalismanOfUltimateEvil);
                DomainEnum.Darkon.AddItem(ItemEnum.Staff.ThunderAndLightning, "326/750");
                DomainEnum.Darkon.AddItem(ItemEnum.Book.VileDarkness, "326/750");
                DomainEnum.Darkon.AddItem(ItemEnum.TalismanOfUltimateEvil, "326/750");

                DomainEnum.Cavitius.AddDeadCharacter(CharacterEnum.Vecna, "405/750").BindCreatures(Creature.Lich)
                    .BindItems(ItemEnum.EyeOfVecna, ItemEnum.HandOfVecna);
                DomainEnum.OutsideRavenloft.AddItem(ItemEnum.EyeOfVecna, "405/750").BindAlignment(Alignment.NE);
                DomainEnum.OutsideRavenloft.AddItem(ItemEnum.HandOfVecna, "405/750").BindAlignment(Alignment.NE);

                DomainEnum.Daglan.AddLivingCharacter(CharacterEnum.Daglan, "410/750")
                    .BindCreatures(Creature.Wight).BindItems(ItemEnum.CrownOfSouls);
                DomainEnum.Daglan.AddItem(ItemEnum.CrownOfSouls, "410/750").BindCreatures(Creature.Wight);

                DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.KatrinaVonBrandthofen, "424/750").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.LN).BindItems(ItemEnum.NecklaceOfAdaptation).BindCharacters(CharacterEnum.DoctorVictorMordenheim);
                DomainEnum.Lamordia.AddItem(ItemEnum.NecklaceOfAdaptation, "424/750");
                DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.DoctorVictorMordenheim, "424/750").BindCreatures(Creature.Human);

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.BrightGaelea, "441/750")
                    .BindCreatures(Creature.Human, Creature.Succubus).BindAlignment(Alignment.LG | Alignment.NE);

                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Bilkon, "456/750").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.CG).BindItems(ItemEnum.Ring.Prot, ItemEnum.Cloak.Prot, ItemEnum.Staff.ThunderAndLightning);
                DomainEnum.Barovia.AddItem(ItemEnum.Ring.Prot, "456/750, 576/750");
                DomainEnum.Barovia.AddItem(ItemEnum.Cloak.Prot, "456/750");
                DomainEnum.Barovia.AddItem(ItemEnum.Staff.ThunderAndLightning, "456/750");

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.ThaedranMeridian, "461/750").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.NE);
                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.DevanCory, "461/750");

                DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.Knightengale, "462/750").BindCreatures(Creature.Human)
                    .BindItems(ItemEnum.ArmorOfBlend, ItemEnum.FerroniereOfBrilliance, ItemEnum.HolyAvenger)
                    .BindAlignment(Alignment.LG).Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.Gondegal, "462/750").Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.Falkovnia.AddItem(ItemEnum.FerroniereOfBrilliance, "462/750");
                DomainEnum.Falkovnia.AddItem(ItemEnum.HolyAvenger, "462/750");

                DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Darkling, "485/750");

                DomainEnum.InsideRavenloft.BindCreatures(
                    Creature.Goblyn, //486/750
                    Creature.BoneGolem, //487/750
                    Creature.ShadowDemon //488/750
                    );

                DomainEnum.Kartakass.Appeared("546/750");
                DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Nhalvaen, "546/750").BindCreatures(Creature.Elf)
                    .BindItems(ItemEnum.Cloak.Disp, ItemEnum.Wand.MagMiss, ItemEnum.HarpOfCharm)
                    .BindAlignment(Alignment.NE).BindRelatedCreatures(Creature.Fox);
                DomainEnum.Kartakass.AddItem(ItemEnum.Cloak.Disp, "546/750");
                DomainEnum.Kartakass.AddItem(ItemEnum.Wand.MagMiss, "546/750");
                DomainEnum.Kartakass.AddItem(ItemEnum.HarpOfCharm, "546/750");

                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Burganet, "576/750").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.NE | Alignment.LG).BindItems(ItemEnum.Ring.Prot);
                DomainEnum.Barovia.AddItem(ItemEnum.Ring.Prot, "576/750");

                DomainEnum.InsideRavenloft.BindCreatures(
                    Creature.BrokenOne, //601/750
                    Creature.DoomGuard, //602/750
                    Creature.GhoulLord, //603/750
                    Creature.Ghast, //603/750
                    Creature.AssassinImp, //604/750
                    Creature.Quickwood, //605/750
                    Creature.Reaver, //606/750
                    Creature.StrahdSteed, //608/750
                    Creature.Horse, //608/750
                    Creature.GreaterWolfwere, //609/750
                    Creature.SeaZombie //620/750
                    );

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Ring.Reverse, "628/750");

                DomainEnum.HarAkir.AddLivingCharacter(CharacterEnum.Anhktepot, "645/750").BindCreatures(Creature.GreaterMummy);

                DomainEnum.InsideRavenloft.BindCreatures(
                    Creature.Skeleton, //646/750
                    Creature.Odem, //647/750
                    Creature.Wight, //648/750
                    Creature.Wraith, //649/750
                    Creature.Geist, //650/750
                    Creature.Shadow, //651/750
                    Creature.Ghost, //652/750
                    Creature.Lich //653/750
                    );

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.MasterEliasSturn, "678/750").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.CG).BindItems(ItemEnum.Ring.HumanInfluence);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Ring.HumanInfluence, "678/750");
            }
            void Add1992PromoCards()
            {
                var releaseDate = "01/01/1992";
                using var ctx = CreateSource("TSR Collector Cards, 1992 GenCon Promo Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.InsideRavenloft.BindCreatures(Creature.Zombie); //10/11
            }
            void Add1993Cards()
            {
                var releaseDate = "01/01/1993";
                using var ctx = CreateSource("TSR Collector Cards, 1993 Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.InsideRavenloft.BindCreatures(Creature.Ghost); //4/495

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Tavelia, "15/495").BindAlignment(Alignment.CE)
                    .BindCreatures(Creature.Human, Creature.Vampire).BindItems(ItemEnum.GirdleManyPounches);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.GirdleManyPounches, "15/495");

                DomainEnum.Souragne.Appeared("18/495");
                DomainEnum.Souragne.AddLivingDarklord(CharacterEnum.AntonMisroi, "18/495");
                DomainEnum.Souragne.AddLivingDarklord(CharacterEnum.LarissaSnowmane, "18/495").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.NG);

                DomainEnum.Borca.AddItem(ItemEnum.Amulet.Vadarin, "21/495, 49/495");

                DomainEnum.Darkon.Appeared("31/495, 173/495, 178/495, 311/495, 319/495");
                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.GilesBowman, "31/495").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.NG).BindItems(ItemEnum.BootsOfTheNorth, ItemEnum.Ring.Prot, ItemEnum.ArrowOfWerewolfSlay);
                DomainEnum.Darkon.AddItem(ItemEnum.BootsOfTheNorth, "31/495");
                DomainEnum.Darkon.AddItem(ItemEnum.Ring.Prot, "31/495, 311/495");
                DomainEnum.Darkon.AddItem(ItemEnum.ArrowOfWerewolfSlay, "31/495");

                DomainEnum.Borca.Appeared("48/495, 49/495");
                DomainEnum.Borca.AddLivingCharacter(CharacterEnum.DuralIronHills, "48/495").BindCreatures(Creature.HillDwarf)
                    .BindAlignment(Alignment.NG).BindCharacters(CharacterEnum.Vadarin);
                DomainEnum.Borca.AddItem(ItemEnum.AxeOfHurl, "48/495");

                DomainEnum.Borca.AddLivingCharacter(CharacterEnum.Vadarin, "49/495").BindCreatures(Creature.HighElf)
                    .BindAlignment(Alignment.NE).BindItems(ItemEnum.BracersOfDefense, ItemEnum.Amulet.Vadarin);
                DomainEnum.Borca.AddItem(ItemEnum.BracersOfDefense, "49/495, 474/495");

                DomainEnum.InsideRavenloft.AddGroup(GroupEnum.PaladinsOfTheRaven, "87/495, 252/495, 417/495, 474/495");
                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.MelykurionRaven, "87/495, 252/495, 417/495").BindAlignment(Alignment.LG)
                    .BindCreatures(Creature.Human).BindGroups(GroupEnum.PaladinsOfTheRaven).BindLocations(LocationEnum.CastleBloodmere);
                DomainEnum.InsideRavenloft.AddLocation(LocationEnum.CastleBloodmere, "87/495, 252/495, 351/495");

                DomainEnum.Barovia.Appeared("101/495, 108/495");
                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.TheodoricTheBook, "101/495").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.LG);

                DomainEnum.Kartakass.Appeared("108/495");
                DomainEnum.Gundarak.Appeared("108/495");
                DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.BonnieLee, "108/495");
                DomainEnum.Gundarak.AddLivingCharacter(CharacterEnum.BonnieLee, "108/495");
                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.BonnieLee, "108/495").BindCreatures(Creature.HalfElf)
                    .BindAlignment(Alignment.NG).BindItems(ItemEnum.Potion.Speed);
                DomainEnum.Kartakass.AddItem(ItemEnum.Potion.Speed, "108/495");
                DomainEnum.Gundarak.AddItem(ItemEnum.Potion.Speed, "108/495");
                DomainEnum.Barovia.AddItem(ItemEnum.Potion.Speed, "108/495");

                DomainEnum.InsideRavenloft.AddGroup(GroupEnum.DarkPowers, "146/495");
                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.StefanDyreth, "146/495").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.LE).BindItems(ItemEnum.Cloak.Prot);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Cloak.Prot, "146/495, 311/495");

                DomainEnum.HarAkir.Appeared("153/495");
                DomainEnum.HarAkir.AddLivingCharacter(CharacterEnum.Senmet, "153/495").BindCreatures(Creature.Human, Creature.GreaterMummy)
                    .BindAlignment(Alignment.LE).BindCharacters(CharacterEnum.Anhktepot);

                DomainEnum.HarAkir.AddLivingCharacter(CharacterEnum.Trisler, "154/495").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.LG).BindGroups(GroupEnum.Vistani, GroupEnum.HalfVistani, GroupEnum.Darkling)
                    .BindItems(ItemEnum.AnkletProtFire, ItemEnum.NecklacePrayerBeads);
                DomainEnum.HarAkir.AddGroup(GroupEnum.Vistani, "154/495");
                DomainEnum.HarAkir.AddGroup(GroupEnum.HalfVistani, "154/495");
                DomainEnum.HarAkir.AddGroup(GroupEnum.Darkling, "154/495");
                DomainEnum.HarAkir.AddItem(ItemEnum.AnkletProtFire, "154/495");
                DomainEnum.HarAkir.AddItem(ItemEnum.NecklacePrayerBeads, "154/495");

                DomainEnum.Lamordia.Appeared("172/495");
                DomainEnum.Lamordia.AddLivingDarklord(CharacterEnum.Adam, "172/495").BindLocations(LocationEnum.IsleOfAgony)
                    .BindCharacters(CharacterEnum.DoctorVictorMordenheim, CharacterEnum.Eva).BindAlignment(Alignment.CE);
                DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.DoctorVictorMordenheim, "172/495")
                    .BindCharacters(CharacterEnum.Eva);
                DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.Eva, "172/495");
                DomainEnum.Lamordia.AddLocation(LocationEnum.IsleOfAgony, "172/495");

                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.RatikUbel, "173/495").BindAlignment(Alignment.TN)
                    .BindCreatures(Creature.Human, Creature.Revenant).BindLocations(Settlement.IlAluk);
                DomainEnum.Darkon.AddSettlement(Settlement.IlAluk, "173/495");

                DomainEnum.Arkandale.Appeared("174/495");
                DomainEnum.Arkandale.AddLivingCharacter(CharacterEnum.NataliaVhorishkova, "174/495").BindAlignment(Alignment.CE)
                    .BindCreatures(Creature.Human, Creature.Werewolf).BindCharacters(CharacterEnum.DoctorRudolphVanRichten);
                DomainEnum.Arkandale.AddLivingCharacter(CharacterEnum.DoctorRudolphVanRichten, "174/495");

                DomainEnum.HarAkir.AddLivingCharacter(CharacterEnum.Anhktepot, "153/495, 175/495").BindAlignment(Alignment.CE)
                    .BindCreatures(Creature.Human, Creature.GreaterMummy); //175/495

                DomainEnum.Blaustein.AddLivingCharacter(CharacterEnum.Bluebeard, "176/495").BindAlignment(Alignment.LE)
                    .BindCreatures(Creature.Human);

                DomainEnum.WindingRoad.AddLivingCharacter(CharacterEnum.HeadlessHorseman, "177/495").BindAlignment(Alignment.CE)
                    .BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Horse).BindCharacters(CharacterEnum.IvanaBoritsi);
                DomainEnum.Borca.AddLivingCharacter(CharacterEnum.IvanaBoritsi, "177/495");

                DomainEnum.OutsideRavenloft.AddGroup(GroupEnum.RedWizard, "178/495");
                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.BaronUrikVonKharkov, "178/495").BindAlignment(Alignment.LE)
                    .BindCreatures(Creature.Human, Creature.Nosferatu, Creature.Panther);
                DomainEnum.Darkon.AddGroup(GroupEnum.TheKargat, "178/495").BindCreatures(Creature.Nosferatu, Creature.Vampire);

                DomainEnum.Ghastria.AddLivingCharacter(CharacterEnum.StezenDPolarno, "179/495").BindCreatures(Creature.Human)
                    .BindAlignment(Alignment.NE | Alignment.CE);

                DomainEnum.Sebua.AddLivingCharacter(CharacterEnum.Tiyet, "180/495").BindAlignment(Alignment.NE)
                    .BindCreatures(Creature.Human, Creature.Mummy);

                DomainEnum.Liffe.AddItem(ItemEnum.LyronHarpsichordCommanding, "190/495").BindCharacters(CharacterEnum.BaronLyronEvensong);

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.HannibilRaven, "87/495, 252/495, 417/495")
                    .BindAlignment(Alignment.LG).BindCreatures(Creature.Human).BindGroups(GroupEnum.PaladinsOfTheRaven)
                    .BindItems(ItemEnum.Potion.Heal).BindCharacters(CharacterEnum.MelykurionRaven);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Potion.Heal, "252/495");

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.CastellanPietor, "252/495, 351/495, 417/495");
                LocationEnum.CastleBloodmere.BindCharacters(CharacterEnum.HannibilRaven, CharacterEnum.CastellanPietor);

                DomainEnum.Liffe.AddLivingCharacter(CharacterEnum.BaronLyronEvensong, "190/495, 262/495")
                    .BindAlignment(Alignment.NE).BindCreatures(Creature.Human).Setting = CampaignSetting.Dragonlance;

                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.AzalinRex, "311/495, 319/495");
                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.KaleenCorigrave, "311/495").BindAlignment(Alignment.NG)
                    .BindItems(ItemEnum.Amulet.ProtUnd, ItemEnum.Cloak.Prot, ItemEnum.Ring.Prot)
                    .BindCreatures(Creature.Human).Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.Darkon.AddItem(ItemEnum.Amulet.ProtUnd, "311/495");
                DomainEnum.Darkon.AddItem(ItemEnum.Cloak.Prot, "311/495");
                DomainEnum.Darkon.AddItem(ItemEnum.Ring.Prot, "311/495");

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.KaraliJenei, "313/495").BindAlignment(Alignment.CE)
                    .BindCreatures(Creature.Human).BindGroups(GroupEnum.Vistani, GroupEnum.Darkling, GroupEnum.Dukkar)
                    .BindItems(ItemEnum.Ring.Invis, ItemEnum.Cloak.Arachnida);
                DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Dukkar, "313/495");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Ring.Invis, "313/495");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Cloak.Arachnida, "313/495");

                DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Tyr, "319/495")
                    .BindGroups(GroupEnum.Deity, GroupEnum.Tyr).Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.OutsideRavenloft.AddGroup(GroupEnum.Tyr, "319/495").Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.Darkon.AddGroup(GroupEnum.Tyr, "319/495");
                DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.LatislavOfDarkon, "319/495").BindCreatures(Creature.Human)
                    .BindItems(ItemEnum.Staff.Curing, ItemEnum.Amulet.LifeProt, ItemEnum.MaceOfDisrupt).BindCharacters(CharacterEnum.AzalinRex)
                    .BindGroups(GroupEnum.Tyr).BindAlignment(Alignment.LG).Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.Darkon.AddItem(ItemEnum.Staff.Curing, "319/495");
                DomainEnum.Darkon.AddItem(ItemEnum.Amulet.LifeProt, "319/495");
                DomainEnum.Darkon.AddItem(ItemEnum.MaceOfDisrupt, "319/495");

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.IconOfTheRaven, "351/495, 484/495")
                    .BindGroups(GroupEnum.PaladinsOfTheRaven).BindAlignment(Alignment.NG);

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.TimeBomb, "353/495, 490/495");

                DomainEnum.Markovia.Appeared("361/495");
                DomainEnum.Markovia.AddLivingCharacter(CharacterEnum.FrantisekMarkov, "361/495");
                DomainEnum.Markovia.AddLivingCharacter(CharacterEnum.JurgenVastish, "361/495")
                    .BindAlignment(Alignment.NG).BindCreatures(Creature.Human).BindItems(ItemEnum.BlessedBolt);
                DomainEnum.Markovia.AddItem(ItemEnum.BlessedBolt, "361/495");

                DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.WeeJas, "373/495")
                    .BindGroups(GroupEnum.Deity, GroupEnum.WeeJas).Setting = CampaignSetting.Greyhawk;
                DomainEnum.InsideRavenloft.AddGroup(GroupEnum.WeeJas, "373/495").Setting = CampaignSetting.Greyhawk;
                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Vashtar, "373/495").BindAlignment(Alignment.LE)
                    .BindCreatures(Creature.Human).BindGroups(GroupEnum.WeeJas).Setting = CampaignSetting.Greyhawk;

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Scarab.Prot, "408/495, 417/495");
                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.MarkRaven, "87/495, 252/495, 408/495, 417/495")
                    .BindItems(ItemEnum.Scarab.Mark, ItemEnum.HolyAvenger).BindCreatures(Creature.Human).BindAlignment(Alignment.LG)
                    .BindCharacters(CharacterEnum.HannibilRaven, CharacterEnum.MelykurionRaven).BindGroups(GroupEnum.PaladinsOfTheRaven);

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.HolyAvenger, "417/495");

                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Wand.Tithion, "467/495, 474/495");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.BracersOfDefense, "467/495, 474/495");
                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Tithion, "467/495, 474/495").BindAlignment(Alignment.LE)
                    .BindCreatures(Creature.Human).BindLocations(LocationEnum.CastleBloodmere).BindItems(ItemEnum.Wand.Tithion, ItemEnum.BracersOfDefense);

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Seldain, "483/495").BindAlignment(Alignment.LE)
                    .BindCreatures(Creature.Human).BindLocations(LocationEnum.CastleBloodmere);

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.PatronArabel, "351/495, 484/495").BindAlignment(Alignment.LG)
                    .BindCreatures(Creature.Human).BindGroups(GroupEnum.PaladinsOfTheRaven).BindItems(ItemEnum.IconOfRaven, ItemEnum.Staff.Strike);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Staff.Strike, "484/495");

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.Brindletople, "353/495, 490/495").BindAlignment(Alignment.LN)
                    .BindCreatures(Creature.Gnome).BindItems(ItemEnum.GemOfInsight, ItemEnum.TimeBomb);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.GemOfInsight, "490/495");
            }
            void Add1993PromoCards()
            {
                var releaseDate = "01/01/1993";
                using var ctx = CreateSource("TSR Collector Cards, 1993 GenCon Promo Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                DomainEnum.Kartakass.Appeared("10/60");
                DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Milil, "10/60").BindLocations(LocationEnum.ChurchOfMilil)
                    .BindGroups(GroupEnum.Deity, GroupEnum.Milil).Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.Kartakass.AddGroup(GroupEnum.Milil, "10/60").Setting = CampaignSetting.ForgottenRealms;
                DomainEnum.Kartakass.AddLocation(LocationEnum.ChurchOfMilil, "10/60").BindGroups(GroupEnum.Milil);
                DomainEnum.Kartakass.AddSettlement(Settlement.Harmonia, "10/60");
                DomainEnum.Kartakass.AddLocation(LocationEnum.MeistersingerMansion, "10/60");
                DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.MeistersingerCasimiar, "10/60").BindAlignment(Alignment.NE)
                    .BindCreatures(Creature.Human, Creature.Wolfwere)
                    .BindLocations(LocationEnum.ChurchOfMilil, Settlement.Harmonia, LocationEnum.MeistersingerMansion);

                DomainEnum.Sithicus.Appeared("13/60");
                DomainEnum.Sithicus.AddLivingDarklord(CharacterEnum.LordLorenSoth, "13/60").BindAlignment(Alignment.CE)
                    .BindCreatures(Creature.DeathKnight).Setting = CampaignSetting.Dragonlance;

                DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.CountStrahd, "13/60");

                DomainEnum.Bluetspur.Appeared("15/60");
                DomainEnum.Bluetspur.AddLivingCharacter(CharacterEnum.HighMasterIllithid, "15/60").BindAlignment(Alignment.LE)
                    .BindItems(ItemEnum.Apparatus).BindCreatures(Creature.Illithid).BindRelatedCreatures(Creature.Vampire);
                DomainEnum.Bluetspur.AddItem(ItemEnum.Apparatus, "15/60");

                DomainEnum.InsideRavenloft.AddLivingCharacter(CharacterEnum.JaraqTheDeceiver, "18/60")
                    .BindAlignment(Alignment.CE).BindCreatures(Creature.HalfElf, Creature.Vampire)
                    .BindItems(ItemEnum.Ring.SpellStoring, ItemEnum.LensSpeedRead, ItemEnum.DeckIllusions);
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.Ring.SpellStoring, "18/60");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.LensSpeedRead, "18/60");
                DomainEnum.InsideRavenloft.AddItem(ItemEnum.DeckIllusions, "18/60");
            }
        }
    }
}