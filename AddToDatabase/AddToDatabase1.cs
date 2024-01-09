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
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Ravenloft Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                var Barovia = ctx.CreateDomain("Barovia", "1/100");
                var Darkon = ctx.CreateDomain("Darkon", "2/100");
                ctx.CreateDomain("Lamordia", "3/100");
                ctx.CreateDomain("Mordent", "4/100");
                ctx.CreateDomain("Kartakass", "5/100");
                ctx.CreateDomain("Keening", "6/100");
                var Tepest = ctx.CreateDomain("Tepest", "7/100");
                ctx.CreateDomain("Verbrek", "8/100").BindCreatures(Creature.Wolf);
                ctx.CreateDomain("Invidia", "9/100");
                ctx.CreateDomain("Nova Vaasa", "10/100");
                ctx.CreateDomain("Dementlieu", "11/100");
                ctx.CreateDomain("Valachan", "12/100");
                var HarAkir = ctx.CreateDomain("Har'Akir", "13/100");
                ctx.CreateDomain("Souragne", "14/100");
                ctx.CreateDomain("Sri Raji", "15/100");

                ctx.CreateLocation("Castle Ravenloft", "16/100").AddDomains(Barovia);

                var AzalinGraveyard = ctx.CreateLocation("Azalin's Graveyard", "17/100").BindCreatures(Creature.Zombie);
                var TheKargat = ctx.CreateGroup("The Kargat", "18/100");
                var KargatMausoleum = ctx.CreateLocation("Kargat Mausoleum", "18/100");
                Darkon.AddLocations(AzalinGraveyard, KargatMausoleum);
                Darkon.AddGroups(TheKargat);
                KargatMausoleum.AddGroups(TheKargat);

                ctx.CreateDomain("Paridon", "19/100").BindCreatures(Creature.Doppelganger); //WHY IS PARIDON MISSING DOPPELGANGERS

                ctx.CreateLocation("Pharaoh's Rest", "20/100").AddDomains(HarAkir);

                ctx.InsideRavenloft.AddGroups(ctx.CreateGroup("Dark Powers", "22/100"));
                ctx.InsideRavenloft.AddItems(ctx.CreateItem("Spell Book of Drawmji", "29/100").BindCreatures(Traits.CampaignSetting.Greyhawk));

                ctx.InsideRavenloft.BindCreatures(
                    Creature.GraveElemental, // 35/100
                    Creature.Shade // 47/100
                );

                ctx.InsideRavenloft.AddItems(ctx.CreateItem("Tarokka Deck", "56/100"));

                var Klorr = ctx.CreateNPC("Klorr", "57/100");
                var TimepieceOfKlorr = ctx.CreateItem("Timepiece of Klorr", "57/100");
                TimepieceOfKlorr.AddNPCs(Klorr);

                ctx.InsideRavenloft.AddItems(
                    ctx.CreateItem("Ring of Regeneration", "58/100"),
                    ctx.CreateItem("Sun Sword", "Sunsword", "59/100"),
                    ctx.CreateItem("Blood Coin", "60/100"),
                    ctx.CreateItem("Staff of Mimicry", "61/100"),
                    ctx.CreateItem("Soul Searcher Medallion", "62/100"),
                    ctx.CreateItem("Ring of Reversion", "63/100"),
                    ctx.CreateItem("Amulet of the Beast", "64/100"));

                var Felkovic = ctx.CreateNPC("Felkovic", "65/100");
                var CatOfFelkovic = ctx.CreateItem("Cat of Felkovic", "65/100");
                CatOfFelkovic.AddNPCs(Felkovic);

                ctx.InsideRavenloft.AddNPCs(Klorr, Felkovic);
                ctx.InsideRavenloft.AddItems(TimepieceOfKlorr, CatOfFelkovic);

                ctx.InsideRavenloft.AddItems(
                    ctx.CreateItem("Apparatus", "66/100"),
                    ctx.CreateItem("Crown of Souls", "67/100"),
                    ctx.CreateItem("Holy Symbol of Ravenkind", "68/100"),
                    ctx.CreateItem("Tapestry of Dark Souls", "69/100"),
                    ctx.CreateItem("Fang of the Nosferatu", "70/100")
                );
                ctx.InsideRavenloft.BindCreatures(
                    Creature.Vampire, // 71/100
                    Creature.Wolf, // 72/100
                    Creature.FleshGolem, // 73/100
                    Creature.GhostShip, // 74/100
                    Creature.StrahdZombie, // 75/100
                    Creature.Spectre // 77/100
                );
                ctx.InsideRavenloft.AddGroups(ctx.CreateGroup("Vistani", "78/100"));

                ctx.InsideRavenloft.BindCreatures(
                    Creature.LoupGarou, // 79/100
                    Creature.Werebat //90/100
                );

                var Azalin = ctx.CreateNPC("Azalin Rex", "82/100");
                AzalinGraveyard.AddNPCs(Azalin);

                ctx.InsideRavenloft.AddNPCs(
                    Azalin,
                    ctx.CreateNPC("Adam", "83/100"),
                    ctx.CreateNPC("Ankhtepot", "84/100"),
                    ctx.CreateNPC("Ireena Kolyana", "85/100"),
                    ctx.CreateNPC("Doctor Rudolph Van Richten", "86/100"),
                    ctx.CreateNPC("Harkon Lukas", "87/100"),
                    ctx.CreateNPC("The Headless Horseman", "88/100").BindCreatures(Creature.Horse),
                    ctx.CreateNPC("Arijani", "89/100"),
                    ctx.CreateNPC("Lord Wilfred Godefroy", "90/100"),
                    ctx.CreateNPC("Tiyet", "91/100"),
                    ctx.CreateNPC("Sir Tristen Hiregaard", "92/100"),
                    ctx.CreateNPC("Gabrielle Aderre", "93/100")
                );

                Tepest.AddGroups(ctx.CreateGroup("Hags Of Tepest", "94/100").BindCreatures(Creature.Hag));

                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Sir Edmund Bloodsworth", "95/100").BindCreatures(Creature.Doppelganger),
                    ctx.CreateNPC("High Master Illithid", "96/100").BindCreatures(Creature.MindFlayer.Item1, Creature.MindFlayer.Item2),
                    ctx.CreateNPC("Doctor Victor Mordenheim", "97/100"),
                    ctx.CreateNPC("Sergei Von Zarovich", "98/100"),
                    ctx.CreateNPC("Lord Soth", "99/100"),
                    ctx.CreateNPC("Count Strahd von Zarovich", "100/100")
                );
            }
            void AddArtifactsSet()
            {
                var releaseDate = "01/05/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Artifacts Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateItem("Seal of Lost Arak", "12/100").AddDomains(ctx.CreateDomain("Arak", "12/100"));
                ctx.CreateItem("Crystal of the Ebon Flame", "13/100").BindCreatures(Traits.CampaignSetting.Greyhawk).AddDomains(ctx.InsideRavenloft);

                ctx.CreateGroup("Darklord", "33/100").AddDomains(ctx.InsideRavenloft);

                ctx.InsideRavenloft.BindCreatures(Creature.InvisibleStalker); //80/100

                ctx.CreateNPC("Yagno Petrovna", "82/100").AddDomains(ctx.InsideRavenloft);
                ctx.CreateDomain("Bluet Spur", "Bluetspur", "88/100");
                ctx.CreateDomain("Kalidnay", "92/100").BindCreatures(Traits.CampaignSetting.DarkSun);

                ctx.CreateItem("Death Rock", "2/20").AddDomains(ctx.InsideRavenloft);

                ctx.CreateNPC("Count Strahd von Zarovich", "8/20").AddDomains(ctx.InsideRavenloft);
                ctx.CreateNPC("Ghostly Piper", "10/20").AddDomains(ctx.InsideRavenloft);
            }
            void Add3rdEditionSet()
            {
                var releaseDate = "01/10/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, 3rd Edition Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateItem("Tapestry of the Stag", "426/440").BindCreatures(Creature.VampireBat, Traits.CampaignSetting.Greyhawk).AddDomains(ctx.InsideRavenloft);
            }
            void AddUnderdarkSet()
            {
                var releaseDate = "01/12/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Underdark Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.InsideRavenloft.AddLocations(
                    ctx.CreateLocation("UnderDread", "9/100"),
                    ctx.CreateLocation("The Dread Chamber", "18/100")
                );
                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("The Red Death", "68/100"),
                    ctx.CreateNPC("Chantal the Banshee", "97/100").BindCreatures(Creature.Banshee),
                    ctx.CreateNPC("Iseult", "99/100")
                );

            }
            void AddRunesNRuinsSet()
            {
                var releaseDate = "01/02/1996";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Runes & Ruins Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateLocation("Tower of Spirits", "15/25").AddDomains(ctx.InsideRavenloft);
            }
            void Add4thEditionSet()
            {
                var releaseDate = "01/07/1996";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, 4th Edition Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateDomain("Arak", "60/500").BindCreatures(Creature.Drow);
                ctx.CreateDomain("Bluet Spur", "Bluetspur", "59/500");
                ctx.CreateDomain("Borca", "61/500");

                ctx.Darklords = ctx.CreateGroup("Darklord", "62/500");
                var LordGundar = ctx.CreateNPC("Lord Gundar", "62/500").BindCreatures(Creature.Ghost);
                var Gundarak = ctx.CreateDomain("Gundarak", "62/500");
                ctx.CreateDarklordGroup(Gundarak, LordGundar);

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
                DomainEnum.GHenna.AddGroup(GroupEnum.Zhakata, "488/750");
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

                var KnightsSolamnia = ctx.CreateGroup("Knights of Solamnia", "710/750").BindCreatures(Traits.CampaignSetting.Dragonlance);
                var KnightsRose = ctx.CreateGroup("Knights of the Rose", "710/750").BindCreatures(Traits.CampaignSetting.Dragonlance);
                var Kitiara = ctx.CreateNPC("Kitiara", "710/750").BindCreatures(Traits.CampaignSetting.Dragonlance);
                ctx.OutsideRavenloft.AddNPCs(Kitiara);
                ctx.OutsideRavenloft.AddGroups(KnightsSolamnia, KnightsRose);
                ctx.InsideRavenloft.AddGroups(KnightsSolamnia, KnightsRose);
                var LordSoth = ctx.CreateNPC("Lord Soth", "710/750").BindCreatures(
                    Creature.DeathKnight, Creature.Human, Alignment.CE, Traits.CampaignSetting.Dragonlance
                );
                LordSoth.AddGroups(KnightsSolamnia, KnightsRose);
                ctx.InsideRavenloft.AddNPCs(LordSoth);
                ctx.InsideRavenloft.AddGroups(KnightsSolamnia, KnightsRose);

                ctx.CreateRelationship(LordSoth, "Desires", Kitiara);

                var Tlaan = ctx.CreateNPC("T'Laan", "723/750").BindCreatures(Alignment.CE, Creature.Vampire, Traits.CampaignSetting.Spelljammer);
                ctx.InsideRavenloft.AddNPCs(Tlaan);
            }
            void Add1992Cards()
            {
                var releaseDate = "01/01/1992";
                using var ctx = CreateSource("TSR Collector Cards, 1992 Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                var TarlVanovitch = ctx.CreateNPC("Tarl Vanovitch", "23/750");
                ctx.InsideRavenloft.AddNPCs(TarlVanovitch);
                var SunBlade = ctx.CreateItem("Tarl Vanovitch's Sun Blade", "23/750").BindCreatures(Alignment.NG, Creature.Vampire);
                TarlVanovitch.AddItems(SunBlade);
                ctx.InsideRavenloft.AddItems(TarlVanovitch.Items.ToArray());

                var QuebeHauntedMansion = ctx.CreateLocation("Quebe's Haunted Mansion", "51/750").BindCreatures(Creature.Ghoul, Creature.Vampire, Creature.Snake);
                ctx.InsideRavenloft.AddLocations(QuebeHauntedMansion);

                ctx.InsideRavenloft.BindCreatures(Creature.LivingWall); //53/750

                var HoelgarArnutsson = ctx.CreateNPC("Hoelgar Arnutsson", "61/750").BindCreatures(Alignment.CE, Creature.Human, Creature.GoldDragon);
                ctx.InsideRavenloft.AddNPCs(HoelgarArnutsson);
                var DragonSlayer = ctx.CreateItem("Dragonslayer", "Dragon Slayer", "61/750");
                HoelgarArnutsson.AddItems(DragonSlayer);
                ctx.InsideRavenloft.AddItems(HoelgarArnutsson.Items.ToArray());

                var RafeWillowand = ctx.CreateNPC("Rafe Willowand", "68/750").BindCreatures(Alignment.CN, Creature.HalfElf);
                ctx.InsideRavenloft.AddNPCs(RafeWillowand);
                var BroochOfProt = ctx.CreateItem("Brooch of Protection from Magic Missile", "68/750");
                var BracersOfDefence = ctx.CreateItem("Bracers of Defence", "68/750, 86/750");
                RafeWillowand.AddItems(BroochOfProt, BracersOfDefence);
                ctx.InsideRavenloft.AddItems(RafeWillowand.Items.ToArray());

                var Darkon = ctx.CreateDomain("Darkon", "86/750, 149/750, 151/750, 199/750, 326/750");
                var MarionRobinsdottir = ctx.CreateNPC("Marion Robinsdottir", "86/750, 149/750").BindCreatures(Alignment.CG, Creature.Human, Creature.Zombie);
                Darkon.AddNPCs(MarionRobinsdottir);
                var IncenseOfMed = ctx.CreateItem("Incense of Meditation", "86/750");
                var RingOfFreeAct = ctx.CreateItem("Ring of Free Action", "86/750");
                MarionRobinsdottir.AddItems(BracersOfDefence, IncenseOfMed, RingOfFreeAct);
                Darkon.AddItems(MarionRobinsdottir.Items.ToArray());

                var Falkovnia = ctx.CreateDomain("Falkovnia", "90/750");
                var SymbukTorul = ctx.CreateNPC("Symbuk Torul", "90/750").BindCreatures(Alignment.TN, Creature.Human, Creature.Tiger);
                Falkovnia.AddNPCs(SymbukTorul);
                var ArmorOfBlend = ctx.CreateItem("Armor of Blending", "90/750, 462/750");
                var EarringSetWithPeriapt = ctx.CreateItem("Earring Set with Periapt of Wound Closure", "90/750");
                SymbukTorul.AddItems(ArmorOfBlend, EarringSetWithPeriapt);
                Falkovnia.AddItems(SymbukTorul.Items.ToArray());

                var mrrob = ctx.CreateItem("Marion Robinsdottir's Robe of Blending", "86/750, 149/750");
                mrrob.AddNPCs(MarionRobinsdottir);
                Darkon.AddItems(mrrob);

                var AzalinRex = ctx.CreateNPC("Azalin Rex", "151/750");
                var ScarabOfDeath = ctx.CreateItem("Mazrikoth's Scarab of Death", "151/750");
                AzalinRex.AddItems(ScarabOfDeath);
                Darkon.AddItems(AzalinRex.Items.ToArray());

                var AlanikRay = ctx.CreateNPC("Alanik Ray", "199/750").BindCreatures(Creature.Elf, Alignment.LN);
                Darkon.AddNPCs(AlanikRay);

                var DorothaKenig = ctx.CreateNPC("Dorotha Kenig", "200/750").BindCreatures(Creature.HalfElf, Alignment.LG);
                Darkon.AddNPCs(DorothaKenig);
                (var Viaki, var ViakiGroup) = ctx.CreateSettlement("Viaka", "Viaki", "200/750");
                Darkon.AddLocations(Viaki);
                Darkon.AddGroups(ViakiGroup);
                Viaki.AddNPCs(DorothaKenig);
                ViakiGroup.PopulateSettlement(Viaki);

                var ReligionOfLathander = ctx.CreateGroup("Religion of Lathander", "262/750").BindCreatures(Traits.CampaignSetting.ForgottonRealms);
                var Lathander = ctx.CreateNPC("Lathander", "262/750").BindCreatures(Traits.CampaignSetting.ForgottonRealms, Traits.Deity);
                ReligionOfLathander.AddDomains(ctx.InsideRavenloft, ctx.OutsideRavenloft);
                ctx.OutsideRavenloft.AddNPCs(Lathander);
                var Almen = ctx.CreateNPC("Almen", "262/750");
                ReligionOfLathander.AddNPCs(Lathander, Almen);
                ctx.InsideRavenloft.AddNPCs(Almen);
                var awoi = ctx.CreateItem("Almen's Wand of Illumination", "262/750");
                awoi.AddNPCs(Lathander, Almen);
                ReligionOfLathander.AddItems(awoi);
                ctx.InsideRavenloft.AddItems(Almen.Items.ToArray());

                ctx.Darklords = ctx.CreateGroup("Darklord", "285/750, 326/750");

                var Strahd = ctx.CreateNPC("Count Strahd von Zarovich", "285/750").BindCreatures(Creature.Human, Creature.Vampire, Alignment.LE);
                var Barovia = ctx.CreateDomain("Barovia", "285/750");
                ctx.CreateDarklordGroup(Barovia, Strahd);

                ctx.InsideRavenloft.BindCreatures(
                    Creature.Nosferatu, //286/750
                    Creature.Dwarf,     //287/750
                    Creature.Halfling,  //288/750
                    Creature.Kender,    //289/750
                    Creature.Elf,       //290/750
                    Creature.Gnome,     //291/750
                    Creature.Vampyre    //292/750
                    );

                var JanderSunstar = ctx.CreateNPC("Jander Sunstar", "293/750").BindCreatures(Creature.Elf, Creature.GoldenElf, Creature.Vampire, Alignment.TN);
                Barovia.AddNPCs(JanderSunstar);

                var Leilana = ctx.CreateNPC("Leilana", "296/750").BindCreatures(Creature.Elf, Alignment.LG, Creature.Unicorn);
                ctx.InsideRavenloft.AddNPCs(Leilana);

                var Killeen = ctx.CreateNPC("Killeen", "312/750").BindCreatures(Creature.Elf, Alignment.NG);
                var VladDrakov = ctx.CreateNPC("Vlad Drakov", "312/750");
                Falkovnia.AddNPCs(Killeen, VladDrakov);
                var RobeOfBlending = ctx.CreateItem("Robe of Blending", "312/750");
                var WandOfSecretDoor = ctx.CreateItem("Wand of Secret Door and Trap Location", "312/750");
                Killeen.AddItems(RobeOfBlending, WandOfSecretDoor);
                Falkovnia.AddItems(RobeOfBlending, WandOfSecretDoor);

                var Kevlin = ctx.CreateNPC("Kevlin", "320/750").BindCreatures(Creature.Human, Alignment.NE);
                Falkovnia.AddNPCs(Kevlin);
                var RingOfHumanInfluence = ctx.CreateItem("Ring of Human Influence", "320/750");
                var RingOfVampiricRegeneration = ctx.CreateItem("Ring of Vampiric Regeneration", "320/750");
                Falkovnia.AddItems(RingOfHumanInfluence, RingOfVampiricRegeneration);
                Kevlin.AddItems(RingOfHumanInfluence, RingOfVampiricRegeneration);
                var ServantsOfTheIronCrown = ctx.CreateGroup("Servants of the Iron Crown").BindCreatures(Alignment.NE);
                Falkovnia.AddGroups(ServantsOfTheIronCrown);
                ServantsOfTheIronCrown.AddNPCs(Kevlin);

                var Mazrikoth = ctx.CreateNPC("Mazrikoth", "326/750").BindCreatures(Creature.Human, Alignment.LE);
                Darkon.AddNPCs(Mazrikoth);
                var StaffOfThunderAndLightning = ctx.CreateItem("Staff of Thunder & Lightning", "326/750, 456/750");
                var BookOfVileDarkness = ctx.CreateItem("Book of Vile Darkness", "326/750");
                var TalismanOfUltimateEvil = ctx.CreateItem("Talisman of Ultimate Evil", "326/750");
                Mazrikoth.AddItems(ScarabOfDeath, StaffOfThunderAndLightning, BookOfVileDarkness, TalismanOfUltimateEvil);
                Darkon.AddItems(StaffOfThunderAndLightning, BookOfVileDarkness, TalismanOfUltimateEvil);
                AzalinRex.BindCreatures(Creature.Lich);
                ctx.CreateDarklordGroup(Darkon, AzalinRex);

                var Vecna = ctx.CreateNPC("Vecna", "405/750").BindCreatures(Creature.Lich).BindCreatures(Traits.Deceased);
                ctx.InsideRavenloft.AddNPCs(Vecna);
                var EyeOfVecna = ctx.CreateItem("Eye of Vecna", "405/750").BindCreatures(Alignment.NE);
                var HandOfVecna = ctx.CreateItem("Hand of Vecna", "406/750").BindCreatures(Alignment.NE);
                Vecna.AddItems(EyeOfVecna, HandOfVecna);
                ctx.InsideRavenloft.AddItems(EyeOfVecna, HandOfVecna);

                var Daglan = ctx.CreateNPC("Dagian", "Daglan", "410/750").BindCreatures(Creature.Wight);
                ctx.InsideRavenloft.AddNPCs(Daglan);
                var CrownOfSouls = ctx.CreateItem("Crown of Souls", "410/750").BindCreatures(Creature.Wight);
                Daglan.AddItems(CrownOfSouls);
                ctx.InsideRavenloft.AddItems(CrownOfSouls);

                var Katrina = ctx.CreateNPC("Katrina Von Brandthofen", "424/750").BindCreatures(Creature.Human, Alignment.LN);
                var NecklaceOfAdaptation = ctx.CreateItem("Necklace of Adaptation", "424/750");
                Katrina.AddItems(NecklaceOfAdaptation);
                var Victor = ctx.CreateNPC("Doctor Victor Mordenheim", "424/750");
                ctx.InsideRavenloft.AddNPCs(Katrina, Victor);
                ctx.InsideRavenloft.AddItems(NecklaceOfAdaptation);
                ctx.CreateRelationship(Victor, "Uncle", Katrina);
                ctx.CreateRelationship(Katrina, "Niece", Victor);

                var BrightGaelea = ctx.CreateNPC("Bright Gaelea", "441/750").BindCreatures(Creature.Human, Alignment.LG, Alignment.NE, Creature.Succubus);
                ctx.InsideRavenloft.AddNPCs(BrightGaelea);

                var Bilkon = ctx.CreateNPC("Bilkon", "456/750").BindCreatures(Creature.Human, Alignment.CG);
                Barovia.AddNPCs(Bilkon);
                var RingOfProt = ctx.CreateItem("Ring of Protection", "456/750, 576/750");
                var CloakOfProt = ctx.CreateItem("Cloak of Protection", "456/750");
                Bilkon.AddItems(RingOfProt, StaffOfThunderAndLightning, CloakOfProt);
                Barovia.AddItems(RingOfProt, StaffOfThunderAndLightning, CloakOfProt);

                var ThaedranMeridian = ctx.CreateNPC("Thaedran Meridian", "461/750").BindCreatures(Creature.Human, Alignment.NE);
                var DevanCory = ctx.CreateNPC("Devan Cory", "461/750");
                ctx.InsideRavenloft.AddNPCs(ThaedranMeridian, DevanCory);

                var Knightengale = ctx.CreateNPC("Knightengale", "462/750").BindCreatures(Creature.Human, Alignment.LG, Traits.CampaignSetting.ForgottonRealms);
                var Gondegal = ctx.CreateNPC("Gondegal", "462/750").BindCreatures(Traits.CampaignSetting.ForgottonRealms);
                Falkovnia.AddNPCs(Knightengale, Gondegal);
                var FerroniereOfBrilliance = ctx.CreateItem("Ferroniere of Brilliance", "462/750");
                var HolyAvenger = ctx.CreateItem("Holy Avenger", "462/750");
                Knightengale.AddItems(ArmorOfBlend, FerroniereOfBrilliance, HolyAvenger);
                Falkovnia.AddItems(ArmorOfBlend, FerroniereOfBrilliance, HolyAvenger);

                ctx.InsideRavenloft.AddGroups(ctx.CreateGroup("Darkling", "485/750").BindCreatures(Alignment.CE));

                ctx.InsideRavenloft.BindCreatures(
                    Creature.Goblyn, //486/750
                    Creature.BoneGolem, //487/750
                    Creature.ShadowDemon.Item1, //488/750
                    Creature.ShadowDemon.Item2 //488/750
                    );

                var Nhalvaen = ctx.CreateNPC("Nhalvaen", "546/750").BindCreatures(Creature.Elf, Alignment.NE, Creature.Fox);
                var Kartakass = ctx.CreateDomain("Kartakass", "546/750");
                Kartakass.AddNPCs(Nhalvaen);
                var CloakOfDisplace = ctx.CreateItem("Cloak of Displacement", "546/750");
                var WandOfMagicMissile = ctx.CreateItem("Wand of Magic Missile", "546/750");
                var HarpOfCharm = ctx.CreateItem("Harp of Charming", "546/750");
                Nhalvaen.AddItems(CloakOfDisplace, WandOfMagicMissile, HarpOfCharm);
                Kartakass.AddItems(CloakOfDisplace, WandOfMagicMissile, HarpOfCharm);

                var Burganet = ctx.CreateNPC("Burganet", "576/750").BindCreatures(Creature.Human, Alignment.NE, Alignment.LG);
                Barovia.AddNPCs(Burganet);
                Burganet.AddItems(RingOfProt);
                Barovia.AddItems(RingOfProt);

                ctx.InsideRavenloft.BindCreatures(
                    Creature.BrokenOne, //601/750
                    Creature.DoomGuard, //602/750
                    Creature.GhoulLord, //603/750
                    Creature.Ghast, //603/750
                    Creature.AssassinImp, //604/750
                    Creature.Quickwood, //605/750
                    Creature.Reaver, //606/750
                    Creature.StrahdSteed.Item1, //608/750
                    Creature.StrahdSteed.Item2, //608/750
                    Creature.Horse, //608/750
                    Creature.GreaterWolfwere, //609/750
                    Creature.SeaZombie //620/750
                    );

                ctx.InsideRavenloft.AddItems(ctx.CreateItem("Ring of Reversion", "628/750"));

                ctx.InsideRavenloft.AddNPCs(ctx.CreateNPC("Anhktepot", "645/750").BindCreatures(Creature.GreaterMummy));

                ctx.InsideRavenloft.BindCreatures(
                    Creature.Skeleton, //646/750
                    Creature.Odem, //647/750
                    Creature.Wight, //648/750
                    Creature.Wraith, //649/750
                    Creature.Geist, //650/750
                    Creature.Shadow, //651/750
                    Creature.Ghost, //652/750
                    Creature.Lich //653/750
                    );

                var EliasSturn = ctx.CreateNPC("Master Elias Sturn", "678/750").BindCreatures(Creature.Human, Alignment.CG);
                EliasSturn.AddItems(RingOfHumanInfluence);
                ctx.InsideRavenloft.AddNPCs(EliasSturn);
            }
            void Add1992PromoCards()
            {
                var releaseDate = "01/01/1992";
                using var ctx = CreateSource("TSR Collector Cards, 1992 GenCon Promo Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                ctx.InsideRavenloft.BindCreatures(Creature.Zombie); //10/11
            }
            void Add1993Cards()
            {
                var releaseDate = "01/01/1993";
                using var ctx = CreateSource("TSR Collector Cards, 1993 Set", releaseDate, ExtraInfo, Edition.e0, Media.boardgame);

                ctx.InsideRavenloft.BindCreatures(Creature.Ghost); //4/495

                var Tavelia = ctx.CreateNPC("Tavelia", "15/495").BindCreatures(Creature.Human, Creature.Vampire, Alignment.CE);
                ctx.InsideRavenloft.AddNPCs(Tavelia);
                var GirdleOfManyPouches = ctx.CreateItem("Girdle of Many Pounches", "15/495");
                Tavelia.AddItems(GirdleOfManyPouches);
                ctx.InsideRavenloft.AddItems(GirdleOfManyPouches);

                ctx.Darklords = ctx.CreateGroup("Darklord", "18/495, 172/495");
                var AntonMisroi = ctx.CreateNPC("Anton Misroi", "18/495");
                var Souragne = ctx.CreateDomain("Souragne", "18/495");
                ctx.CreateDarklordGroup(Souragne, AntonMisroi);
                var LarissaSnowmane = ctx.CreateNPC("Larissa Snowmane", "18/495").BindCreatures(Creature.Human, Alignment.NG);
                Souragne.AddNPCs(AntonMisroi, LarissaSnowmane);

                var AmuletOfVadarin = ctx.CreateItem("Amulet of Vadarin", "21/495, 49/495");

                var Giles = ctx.CreateNPC("Giles the Bowman", "31/495").BindCreatures(Creature.Human, Alignment.NG);
                var Darkon = ctx.CreateDomain("Darkon", "31/495, 173/495, 178/495, 311/495, 319/495");
                Darkon.AddNPCs(Giles);
                var BootsOfTheNorth = ctx.CreateItem("Boots of the North", "31/495");
                var RingOfProt = ctx.CreateItem("Ring of Protection", "31/495, 311/495");
                var ArrowOfWerewolfSlay = ctx.CreateItem("Arrow of Werewolf Slaying", "31/495");
                Giles.AddItems(BootsOfTheNorth, RingOfProt, ArrowOfWerewolfSlay);
                Darkon.AddItems(BootsOfTheNorth, RingOfProt, ArrowOfWerewolfSlay);

                var Dural = ctx.CreateNPC("Dural of the Iron Hills", "48/495").BindCreatures(Creature.HillDwarf, Alignment.NG);
                var Borca = ctx.CreateDomain("Borca", "48/495");
                Borca.AddNPCs(Dural);
                var AxeOfHurling = ctx.CreateItem("Axe of Hurling", "48/495");
                Dural.AddItems(AxeOfHurling);
                Borca.AddItems(AxeOfHurling);

                var Vadarin = ctx.CreateNPC("Vadarin", "49/495").BindCreatures(Creature.HighElf, Alignment.NE);
                Borca.AddNPCs(Vadarin);
                var BracersOfDefense = ctx.CreateItem("Bracers of Defense", "49/495, 474/495");
                Vadarin.AddItems(BracersOfDefense, AmuletOfVadarin);
                Borca.AddItems(BracersOfDefense, AmuletOfVadarin);
                ctx.CreateRelationship(Dural, "Hunts", Vadarin);

                var PaladinsOfTheRaven = ctx.CreateGroup("Paladins of the Raven", "87/495, 252/495, 417/495, 474/495").BindCreatures(Alignment.LG);
                ctx.InsideRavenloft.AddGroups(PaladinsOfTheRaven);
                var Melykurion = ctx.CreateNPC("Melykurion of the Raven", "87/495, 252/495, 417/495").BindCreatures(Creature.Human, Alignment.LG);
                ctx.InsideRavenloft.AddNPCs(Melykurion);
                PaladinsOfTheRaven.AddNPCs(Melykurion);
                var CastleBloodmere = ctx.CreateLocation("Castle Bloodmere", "87/495, 252/495, 351/495");
                CastleBloodmere.AddNPCs(Melykurion);
                ctx.InsideRavenloft.AddLocations(CastleBloodmere);

                var Theodoric = ctx.CreateNPC("Theodoric the Book", "101/495").BindCreatures(Creature.Human, Alignment.LG);
                var Barovia = ctx.CreateDomain("Barovia", "101/495, 108/495");
                Barovia.AddNPCs(Theodoric);

                var BonnieLee = ctx.CreateNPC("Bonnie Lee", "108/495").BindCreatures(Creature.HalfElf, Alignment.NG);
                var Kartakass = ctx.CreateDomain("Kartakass", "108/495");
                var Gundarak = ctx.CreateDomain("Gundarak", "108/495");
                BonnieLee.AddDomains(Kartakass, Gundarak, Barovia);
                var PotionOfSpeed = ctx.CreateItem("Potion of Speed", "108/495");
                BonnieLee.AddItems(PotionOfSpeed);
                Kartakass.AddItems(PotionOfSpeed);
                Gundarak.AddItems(PotionOfSpeed);
                Barovia.AddItems(PotionOfSpeed);

                var DarkPowers = ctx.CreateGroup("Dark Powers", "146/495");
                var StefanDyreth = ctx.CreateNPC("Stefan Dyreth", "146/495").BindCreatures(Creature.Human, Alignment.LE);
                ctx.InsideRavenloft.AddNPCs(StefanDyreth);
                var CloakOfProt = ctx.CreateItem("Cloak of Protection", "146/495, 311/495");
                StefanDyreth.AddItems(CloakOfProt);
                ctx.InsideRavenloft.AddItems(CloakOfProt);

                var Senmet = ctx.CreateNPC("Senmet", "153/495").BindCreatures(Creature.Human, Alignment.LE, Creature.GreaterMummy);
                var Anhktepot = ctx.CreateNPC("Anhktepot", "153/495, 175/495");
                var HarAkir = ctx.CreateDomain("Har'Akir", "153/495");
                HarAkir.AddNPCs(Senmet, Anhktepot);
                ctx.CreateRelationship(Senmet, "wants to overthrow", Anhktepot);

                var Trisler = ctx.CreateNPC("Trisler", "154/495").BindCreatures(Creature.Human, Alignment.LG);
                HarAkir.AddNPCs(Trisler);
                var Vistani = ctx.CreateGroup("Vistani", "154/495");
                var HalfVistani = ctx.CreateGroup("Half Vistani", "154/495");
                var Darkling = ctx.CreateGroup("Darkling", "154/495");
                Trisler.AddGroups(Vistani, HalfVistani, Darkling);
                HarAkir.AddGroups(Vistani, HalfVistani, Darkling);
                var AnkletOfProt = ctx.CreateItem("Anklet of Protection from Fire", "154/495");
                var NecklaceOfPrayer = ctx.CreateItem("Necklace of Prayer Beads", "154/495");
                Trisler.AddItems(AnkletOfProt, NecklaceOfPrayer);
                HarAkir.AddItems(AnkletOfProt, NecklaceOfPrayer);

                var Adam = ctx.CreateNPC("Adam", "172/495").BindCreatures(Alignment.CE);
                var Victor = ctx.CreateNPC("Doctor Victor Mordenheim", "172/495");
                var Eva = ctx.CreateNPC("Eva", "172/495");
                var Lamordia = ctx.CreateDomain("Lamordia", "172/495");
                Lamordia.AddNPCs(Victor, Eva);
                var IsleOfAgony = ctx.CreateLocation("Isle of Agony", "172/495");
                Lamordia.AddLocations(IsleOfAgony);
                IsleOfAgony.AddNPCs(Adam);
                ctx.CreateDarklordGroup(Lamordia, Adam);

                var RatikUbel = ctx.CreateNPC("Ratik Ubel", "173/495").BindCreatures(Creature.Human, Creature.Revenant, Alignment.TN);
                Darkon.AddNPCs(RatikUbel);
                (var IlAluk, var IlAlukGroup) = ctx.CreateSettlement("Il Aluk", "173/495");
                Darkon.AddLocations(IlAluk);
                Darkon.AddGroups(IlAlukGroup);
                IlAluk.AddNPCs(RatikUbel);
                IlAlukGroup.PopulateSettlement(IlAluk);

                var NataliaVhorishkova = ctx.CreateNPC("Natalia Vhorishkova", "174/495").BindCreatures(Creature.Human, Creature.Werewolf, Alignment.CE);
                var Arkandale = ctx.CreateDomain("Arkandale", "174/495");
                var RudolphVanRichten = ctx.CreateNPC("Doctor Rudolph Van Richten", "174/495");
                Arkandale.AddNPCs(NataliaVhorishkova, RudolphVanRichten);
                ctx.CreateRelationship(RudolphVanRichten, "almost kills", NataliaVhorishkova);

                Anhktepot.BindCreatures(Creature.Human, Creature.GreaterMummy, Alignment.CE); //175/495

                var Bluebeard = ctx.CreateNPC("Bluebeard", "176/495").BindCreatures(Creature.Human, Alignment.LE);
                ctx.InsideRavenloft.AddNPCs(Bluebeard);

                var HeadlessHorseman = ctx.CreateNPC("The Headless Horseman", "177/495").BindCreatures(Creature.Human, Alignment.CE);
                var IvanaBoritsi = ctx.CreateNPC("Ivana Boritsi", "177/495");
                ctx.InsideRavenloft.AddNPCs(HeadlessHorseman, IvanaBoritsi);
                ctx.CreateRelationship(IvanaBoritsi, "Beheaded", HeadlessHorseman);

                var RedWizard = ctx.CreateGroup("Red Wizard of Thay", "178/495");
                var UrikVonKharkov = ctx.CreateNPC("Baron Urik von Kharkov", "178/495").BindCreatures(Creature.Human, Creature.Nosferatu, Creature.Panther, Alignment.LE);
                Darkon.AddNPCs(UrikVonKharkov);
                var TheKargat = ctx.CreateGroup("The Kargat", "178/495").BindCreatures(Creature.Nosferatu, Creature.Vampire);
                Darkon.AddGroups(TheKargat);

                var Stezen = ctx.CreateNPC("Stezen D'Polarno", "179/495").BindCreatures(Creature.Human, Alignment.NE, Alignment.CE);
                var Tiyet = ctx.CreateNPC("Tiyet", "180/495").BindCreatures(Creature.Human, Creature.Mummy, Alignment.NE);
                ctx.InsideRavenloft.AddNPCs(Stezen, Tiyet);

                var LyronEvensong = ctx.CreateNPC("Baron Lyron Evensong", "190/495, 262/495");
                ctx.InsideRavenloft.AddNPCs(LyronEvensong);
                var HarpsichordOfCommand = ctx.CreateItem("Lyron's Harpsichord of Commanding", "190/495");
                LyronEvensong.AddItems(HarpsichordOfCommand);
                ctx.InsideRavenloft.AddItems(HarpsichordOfCommand);

                var Hannibil = ctx.CreateNPC("Hannibil of the Raven", "87/495, 252/495, 417/495").BindCreatures(Creature.Human, Alignment.LG);
                PaladinsOfTheRaven.AddNPCs(Hannibil);
                var CastellanPietor = ctx.CreateNPC("Castellan Pietor", "252/495, 351/495, 417/495");
                CastleBloodmere.AddNPCs(Hannibil, CastellanPietor);
                ctx.InsideRavenloft.AddNPCs(Hannibil, CastellanPietor);
                var PotionOfHeal = ctx.CreateItem("Potion of Healing", "252/495");
                Hannibil.AddItems(PotionOfHeal);
                ctx.InsideRavenloft.AddItems(PotionOfHeal);
                ctx.CreateRelationship(Melykurion, "Brother", Hannibil);
                ctx.CreateRelationship(Hannibil, "Brother", Melykurion);

                LyronEvensong.BindCreatures(Creature.Human, Alignment.NE, Traits.CampaignSetting.Dragonlance); //262/495

                var Azalin = ctx.CreateNPC("Azalin Rex", "311/495, 319/495");
                var KaleenCorigrave = ctx.CreateNPC("Kaleen Corigrave", "311/495").BindCreatures(Creature.Human, Alignment.NG, Traits.CampaignSetting.ForgottonRealms);
                Darkon.AddNPCs(KaleenCorigrave, Azalin);
                var AmuletOfProtVsUndead = ctx.CreateItem("Amulet of Protection versus Undead", "311/495");
                KaleenCorigrave.AddItems(CloakOfProt, RingOfProt, AmuletOfProtVsUndead);
                Darkon.AddItems(CloakOfProt, RingOfProt, AmuletOfProtVsUndead);

                var KaraliJenei = ctx.CreateNPC("Karali Jenei", "313/495").BindCreatures(Creature.Human, Alignment.CE);
                ctx.InsideRavenloft.AddNPCs(KaraliJenei);
                var Dukkar = ctx.CreateGroup("Dukkar", "313/495");
                ctx.InsideRavenloft.AddGroups(Dukkar);
                KaraliJenei.AddGroups(Darkling, Vistani, Dukkar);
                var RingOfInvis = ctx.CreateItem("Ring of Invisibility", "313/495");
                var CloakOfArachnida = ctx.CreateItem("Cloak of Arachnida", "313/495");
                KaraliJenei.AddItems(RingOfInvis, CloakOfArachnida);
                ctx.InsideRavenloft.AddItems(RingOfInvis, CloakOfArachnida);

                var Tyr = ctx.CreateNPC("Tyr", "319/495").BindCreatures(Traits.CampaignSetting.ForgottonRealms, Traits.Deity);
                ctx.OutsideRavenloft.AddNPCs(Tyr);
                var ReligionOfTyr = ctx.CreateGroup("Religion of Tyr", "319/495").BindCreatures(Traits.CampaignSetting.ForgottonRealms);
                ReligionOfTyr.AddDomains(ctx.InsideRavenloft, ctx.OutsideRavenloft);
                var Latislav = ctx.CreateNPC("Latislav of Darkon", "319/495").BindCreatures(Creature.Human, Alignment.LG, Traits.CampaignSetting.ForgottonRealms);
                ReligionOfTyr.AddNPCs(Tyr, Latislav);
                Darkon.AddNPCs(Latislav);
                var StaffOfCuring = ctx.CreateItem("Staff of Curing", "319/495");
                var AmuletOfLifeProt = ctx.CreateItem("Amulet of Life Protection", "319/495");
                var MaceOfDisrupt = ctx.CreateItem("Mace of Disruption", "319/495");
                Latislav.AddItems(StaffOfCuring, AmuletOfLifeProt, MaceOfDisrupt);
                Darkon.AddItems(StaffOfCuring, AmuletOfLifeProt, MaceOfDisrupt);
                ctx.CreateRelationship(Azalin, "seeks to kill", Latislav);

                var IconOfTheRaven = ctx.CreateItem("Icon of the Raven", "351/495, 484/495").BindCreatures(Alignment.NG);
                ctx.InsideRavenloft.AddItems(IconOfTheRaven);

                var BrindletopleTimeBomb = ctx.CreateItem("Brindletople's Time Bomb", "353/495, 490/495");
                ctx.InsideRavenloft.AddItems(BrindletopleTimeBomb);

                var Markovia = ctx.CreateDomain("Markovia", "361,495");
                var FrantisekMarkov = ctx.CreateNPC("Frantisek Markov", "361,495");
                var JurgenVastish = ctx.CreateNPC("Jurgen Vastish", "361/495").BindCreatures(Creature.Human, Alignment.NG);
                Markovia.AddNPCs(FrantisekMarkov, JurgenVastish);
                var BlessedBolt = ctx.CreateItem("Blessed Bolt", "361/495");
                JurgenVastish.AddItems(BlessedBolt);
                Markovia.AddItems(BlessedBolt);

                var WeeJas = ctx.CreateNPC("Wee Jas", "373/495").BindCreatures(Traits.CampaignSetting.Greyhawk, Traits.Deity);
                ctx.OutsideRavenloft.AddNPCs(WeeJas);
                var ReligionOfWeeJas = ctx.CreateGroup("Religion of Wee Jas", "373/495").BindCreatures(Traits.CampaignSetting.Greyhawk);
                ReligionOfWeeJas.AddDomains(ctx.InsideRavenloft, ctx.OutsideRavenloft);
                var Vashtar = ctx.CreateNPC("Vashtar", "373/495").BindCreatures(Creature.Human, Alignment.LE, Traits.CampaignSetting.Greyhawk);
                ctx.InsideRavenloft.AddNPCs(Vashtar);
                ReligionOfWeeJas.AddNPCs(WeeJas, Vashtar);

                var MarkScarab = ctx.CreateItem("Mark's Scarab of Protection", "408/495, 417/495");
                var Mark = ctx.CreateNPC("Mark of the Raven", "87/495, 252/495, 408/495, 417/495").BindCreatures(Creature.Human, Alignment.LG);
                PaladinsOfTheRaven.AddNPCs(Mark);
                ctx.InsideRavenloft.AddNPCs(Mark);
                var HolyAvenger = ctx.CreateItem("Holy Avenger", "417/495");
                Mark.AddItems(MarkScarab, HolyAvenger);
                ctx.InsideRavenloft.AddItems(MarkScarab, HolyAvenger);
                ctx.CreateRelationship(Mark, "Brother", Hannibil);
                ctx.CreateRelationship(Mark, "Brother", Melykurion);
                ctx.CreateRelationship(Melykurion, "Brother", Mark);
                ctx.CreateRelationship(Hannibil, "Brother", Mark);

                var TithionWand = ctx.CreateItem("Tithion's Wand of Fire", "467/495, 474/495");
                var Tithion = ctx.CreateNPC("Tithion", "467/495, 474/495").BindCreatures(Creature.Human, Alignment.LE);
                ctx.InsideRavenloft.AddNPCs(Tithion);
                CastleBloodmere.AddNPCs(Tithion);
                Tithion.AddItems(BracersOfDefense, TithionWand);
                ctx.InsideRavenloft.AddItems(TithionWand);

                var Seldain = ctx.CreateNPC("Seldain", "483/495").BindCreatures(Creature.Human, Alignment.LE);
                ctx.InsideRavenloft.AddNPCs(Seldain);
                CastleBloodmere.AddNPCs(Seldain);

                var Arabel = ctx.CreateNPC("Patron Arabel", "Father Arabel", "351/495, 484/495").BindCreatures(Creature.Human, Alignment.LG);
                PaladinsOfTheRaven.AddNPCs(Arabel);
                ctx.InsideRavenloft.AddNPCs(Arabel);
                var StaffOfStriking = ctx.CreateItem("Staff of Striking", "484/495");
                Arabel.AddItems(IconOfTheRaven, StaffOfStriking);
                ctx.InsideRavenloft.AddItems(StaffOfStriking);

                var Brindletople = ctx.CreateNPC("Brindletople", "353/495, 490/495").BindCreatures(Creature.Gnome, Alignment.LN);
                ctx.InsideRavenloft.AddNPCs(Brindletople);
                var GemOfInsight = ctx.CreateItem("Gem of Insight");
                Brindletople.AddItems(GemOfInsight, BrindletopleTimeBomb);
                ctx.InsideRavenloft.AddItems(GemOfInsight);
            }
            void Add1993PromoCards()
            {
                var releaseDate = "01/01/1993";
                using var ctx = Factory.CreateSource("TSR Collector Cards, 1993 GenCon Promo Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                var Milil = ctx.CreateNPC("Milil", "10/60").BindCreatures(Traits.Deity);
                ctx.OutsideRavenloft.AddNPCs(Milil);
                var ReligionOfMilil = ctx.CreateGroup("Religion of Milil", "10/60").BindCreatures(Traits.CampaignSetting.ForgottonRealms);
                Milil.AddGroups(ReligionOfMilil);
                var Kartakass = ctx.CreateDomain("Kartkass", "10/60");
                var ChurchOfMilil = ctx.CreateLocation("Church of Milil", "10/60");
                ChurchOfMilil.AddNPCs(Milil);
                ChurchOfMilil.AddGroups(ReligionOfMilil);
                (var Harmonia, var HarmoniaGroup) = ctx.CreateSettlement("Harmonia", "10/60");
                Kartakass.AddGroups(ReligionOfMilil, HarmoniaGroup);
                var MeistersingerMansion = ctx.CreateLocation("Meistersinger Mansion", "10/60");
                Kartakass.AddLocations(ChurchOfMilil, Harmonia, MeistersingerMansion);
                var Casimiar = ctx.CreateNPC("Meistersinger Casimiar of Harmonia", "10/60").BindCreatures(Creature.Human, Creature.Wolfwere, Alignment.NE);
                Kartakass.AddNPCs(Casimiar);
                Casimiar.AddLocations(ChurchOfMilil, Harmonia, MeistersingerMansion);
                HarmoniaGroup.PopulateSettlement(ChurchOfMilil, MeistersingerMansion);

                var Sithicus = ctx.CreateDomain("Sithicus", "13/60");
                var LordSoth = ctx.CreateNPC("Lord Soth", "13/60").BindCreatures(Creature.DeathKnight, Alignment.CE, Traits.CampaignSetting.Dragonlance);
                ctx.Darklords = ctx.CreateGroup("Darklord", "13/60");
                ctx.CreateDarklordGroup(Sithicus, LordSoth);
                ctx.InsideRavenloft.AddNPCs(ctx.CreateNPC("Count Strahd von Zarovich", "13/60"));

                var Bluetspur = ctx.CreateDomain("Bluetspur", "15/60");
                var HighMaster = ctx.CreateNPC("High Master Illithid", "15/60").BindCreatures(Creature.Illithid.Item1, Creature.Illithid.Item2, Alignment.LE, Creature.Vampire);
                Bluetspur.AddNPCs(HighMaster);
                var Apparatus = ctx.CreateItem("Apparatus", "15/60");
                Bluetspur.AddItems(Apparatus);
                HighMaster.AddItems(Apparatus);

                var Jaraq = ctx.CreateNPC("Jaraq the Deceiver", "18/60").BindCreatures(Creature.HalfElf, Alignment.CE, Creature.Vampire);
                ctx.InsideRavenloft.AddNPCs(Jaraq);
                var RingOfSpellStore = ctx.CreateItem("Ring of Spell Storing", "18/60");
                var LensOfSpeedRead = ctx.CreateItem("Lens of SpeedReading", "18/60");
                var DeckOfIllusions = ctx.CreateItem("Deck of Illusions", "18/60");
                Jaraq.AddItems(RingOfSpellStore, LensOfSpeedRead, DeckOfIllusions);
                ctx.InsideRavenloft.AddItems(RingOfSpellStore, LensOfSpeedRead, DeckOfIllusions);
            }
        }
    }
}