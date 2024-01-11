using static Factory;

internal static partial class AddToDatabase
{
    public static void Add0 () 
    {
        //Domains, Characters, Items and Locations are Source-locked, but not Traits.
        //Consider not making new instances within Create, so that adding can be better structured.
        AddI6Ravenloft();
        AddI10TheHouseOnGryphonHill();

        void AddI6Ravenloft()
        {
            var releaseDate = "01/11/1983";
            string ExtraInfo = "<br/>&emsp;Authors: Tracy Hickman and Laura Hickman";
            ExtraInfo += "<br/>&emsp;Editor: Curtis Smith";
            ExtraInfo += "<br/>&emsp;Graphic Designer: Debra Stubbe";
            ExtraInfo += "<br/>&emsp;Illustrator: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 6-8 characters of levels 5-7";
            using var ctx = CreateSource("I6: Ravenloft", releaseDate, ExtraInfo, Edition.e1, Media.module);
            if (ctx == null) return;

            DomainEnum.Barovia.Appeared().BindCreatures(Creature.Ghoul);

            #region Locations
            DomainEnum.Barovia.AddSettlement(Settlement.Barovia, "1, 6, 7")
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia)
                .BindCharacters(CharacterEnum.Arik, CharacterEnum.FatherDonavich, CharacterEnum.KolyanIndirovich, CharacterEnum.Ismark,
                                CharacterEnum.IreenaKolyana, CharacterEnum.SashaIvliskova, CharacterEnum.MadMary, CharacterEnum.Gertruda,
                                CharacterEnum.Bildrath, CharacterEnum.Parriwimple);
            DomainEnum.Barovia.AddLocation(LocationEnum.OldSvalichRoad, "7");
            DomainEnum.Barovia.AddLocation(LocationEnum.GatesOfBarovia, "7").BindCreatures(Creature.GreenSlime);
            DomainEnum.Barovia.AddLocation(LocationEnum.SvalichWoods, "1, 6-8").BindCreatures(Creature.Worg);
            DomainEnum.Barovia.AddLocation(LocationEnum.RiverIvlis, "8");
            DomainEnum.Barovia.AddLocation(LocationEnum.BildrathMercantile, "8")
                .BindCharacters(CharacterEnum.Bildrath, CharacterEnum.Parriwimple);
            DomainEnum.Barovia.AddLocation(LocationEnum.BloodVineTavern, "8, 9")
                .BindCharacters(CharacterEnum.Arik, CharacterEnum.Ismark);
            DomainEnum.Barovia.AddLocation(LocationEnum.MaryHouse, "9")
                .BindCharacters(CharacterEnum.MadMary, CharacterEnum.Gertruda);
            DomainEnum.Barovia.AddLocation(LocationEnum.BurgomasterHome, "1, 9")
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia)
                .BindCharacters(CharacterEnum.KolyanIndirovich, CharacterEnum.Ismark, CharacterEnum.IreenaKolyana);
            DomainEnum.Barovia.AddLocation(LocationEnum.BaroviaChurch, "9, 10")
                .BindCharacters(CharacterEnum.FatherDonavich);
            DomainEnum.Barovia.AddLocation(LocationEnum.BurgomasterGuestHouse, "9")
                .BindGroups(GroupEnum.Burgomaster, GroupEnum.BurgomasterOfBarovia)
                .BindCharacters(CharacterEnum.KolyanIndirovich);
            DomainEnum.Barovia.AddLocation(LocationEnum.BaroviaCemetery, "9, 11").BindCreatures(Creature.Spirit);

            DomainEnum.Barovia.AddSettlement(Settlement.TserPoolEncampnent, "11");
            DomainEnum.Barovia.AddLocation(LocationEnum.TserPool, "11");
            DomainEnum.Barovia.AddLocation(LocationEnum.MadamEvasTent, "11");
            DomainEnum.Barovia.AddLocation(LocationEnum.RoadJunction, "11");
            DomainEnum.Barovia.AddLocation(LocationEnum.TserFalls, "11");
            DomainEnum.Barovia.AddLocation(LocationEnum.GatesOfRavenloft, "11, 12");

            DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft, "1, 6, 8, 9, 12-30")
                .BindCreatures(Creature.RedDragon, Creature.ShadowDemon, Creature.Trapper, Creature.GiantSpider,
                                                            Creature.HugeSpider, Creature.Skeleton, Creature.Horse, Creature.Nightmare,
                                                            Creature.Banshee, Creature.Gargoyle, Creature.RustMonster, Creature.GuardianPortrait,
                                                            Creature.Spectre, Creature.Spirit, Creature.Wight, Creature.Wraith, Creature.Ghost,
                                                            Creature.Bat, Creature.StrahdZombie, Creature.BlackCat, Creature.Witch, Creature.Hellhound,
                                                            Creature.Werewolf, Creature.IronGolem)
                .BindCharacters(CharacterEnum.GuardianOfSorrow, CharacterEnum.LiefLipsiege, CharacterEnum.Helga, CharacterEnum.CyrusBelview,
                                DarklordEnum.CountStrahd, CharacterEnum.SpectreAbCenteer, CharacterEnum.ArtistaDeSlop, CharacterEnum.LadyIsoldeYunk,
                                CharacterEnum.AerialDuPlumette, CharacterEnum.ArtankSwilovich, CharacterEnum.DorfniyaDilisny, CharacterEnum.Pidlwik,
                                CharacterEnum.LeanneTriksky, CharacterEnum.TashaPetrovna, CharacterEnum.KingToisky, CharacterEnum.KingIntreeKatsky,
                                CharacterEnum.StahbalIndiBhak, CharacterEnum.Khazan, CharacterEnum.ElsaFallona, CharacterEnum.SedrikSpinwitovich,
                                CharacterEnum.Animus, CharacterEnum.ErikVonderbucks, CharacterEnum.IvanDeRose, CharacterEnum.StephanGregorovich,
                                CharacterEnum.IntreeSikValoo, CharacterEnum.ArdentPallette, CharacterEnum.IvanIvanovich, CharacterEnum.CirilRomulich,
                                CharacterEnum.Dollars, CharacterEnum.Finderway, CharacterEnum.Dostron, CharacterEnum.GralmoreNimblenobs,
                                CharacterEnum.AmericoStandardski, CharacterEnum.Beucephalus, CharacterEnum.TatsaulEris, CharacterEnum.Sergei,
                                CharacterEnum.KingBarov, CharacterEnum.Ravenovia, CharacterEnum.MaryaMarkovia, CharacterEnum.Endorovich,
                                CharacterEnum.SashaIvliskova, CharacterEnum.PatrinaVelikovna, CharacterEnum.Gertruda)
                .BindItems(ItemEnum.Sunsword, ItemEnum.Book.TomeOfStrahd, ItemEnum.IconOfRaven, ItemEnum.SymbolOfRaven, ItemEnum.Book.EmbalmTheLostArt,
                           ItemEnum.Book.LifeAmongUndead, ItemEnum.Book.IdentifyBloodTypes, ItemEnum.Book.MasonryWoodwork)
                .BindGroups(GroupEnum.BridesOfStrahd, GroupEnum.HighPriestRavenloft, GroupEnum.HighPriestMostHoly);
            #endregion

            #region Characters
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.MadamEva,"1, 6, 11, 32")
                .BindLocations(Settlement.TserPoolEncampnent, LocationEnum.MadamEvasTent)
                .BindGroups(GroupEnum.Vistani, GroupEnum.Raunie)
                .BindCreatures(Creature.Human)
                .BindAlignment(Alignment.CN);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.GuardianOfSorrow, "16")
                .BindAlignment(Alignment.NE);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.LiefLipsiege, "17")
                .BindCreatures(Creature.Human)
                .BindCharacters(DarklordEnum.CountStrahd)
                .BindAlignment(Alignment.CE);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Helga, "18")
                .BindCreatures(Creature.Human, Creature.Vampire)
                .BindCharacters(DarklordEnum.CountStrahd)
                .BindAlignment(Alignment.CE);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.CyrusBelview, "23")
                .BindCreatures(Creature.Human)
                .BindCharacters(DarklordEnum.CountStrahd)
                .BindAlignment(Alignment.CN);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.SpectreAbCenteer, "27");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ArtistaDeSlop, "27");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.LadyIsoldeYunk, "27");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.AerialDuPlumette, "27").BindCreatures(Creature.Ghost).BindAlignment(Alignment.LE);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ArtankSwilovich, "27");

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.DorfniyaDilisny, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Pidlwik, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.LeanneTriksky, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.TashaPetrovna, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingToisky, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingIntreeKatsky, "28");
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.StahbalIndiBhak, "28").BindCreatures(Creature.Wight).BindAlignment(Alignment.LE);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Khazan, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ElsaFallona, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.SedrikSpinwitovich, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Animus, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ErikVonderbucks, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.IvanDeRose, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.StephanGregorovich, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.IntreeSikValoo, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ArdentPallette, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.IvanIvanovich, "28");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.CirilRomulich, "28");

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Dollars, "29");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Finderway, "29");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Dostron, "29");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.GralmoreNimblenobs, "29");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.AmericoStandardski, "29");

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Beucephalus, "29, 30")
                .BindCharacters(DarklordEnum.CountStrahd).BindCreatures(Creature.Horse, Creature.Nightmare);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.TatsaulEris, "30");

            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.AnnaPetrovna, "28").ExtraInfo = "Probably deceased.";

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Arik, "8").BindCreatures(Creature.Human).BindAlignment(Alignment.CN);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.FatherDonavich, "9").BindCreatures(Creature.Human).BindAlignment(Alignment.LG);

            DomainEnum.Barovia.AddLivingCharacter(DarklordEnum.CountStrahd)
                .BindItems(ItemEnum.Book.TomeOfStrahd)
                .BindCreatures(Creature.Human, Creature.Vampire, Creature.Bat, Creature.Wolf)
                .BindRelatedCreatures(Creature.Worg, Creature.StrahdZombie, Creature.Zombie)
                .BindAlignment(Alignment.CE)
                .BindCharacters(CharacterEnum.KingBarov, CharacterEnum.Ravenovia, CharacterEnum.Sergei);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Sergei, "1, 4, 30, 31").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.KingBarov, CharacterEnum.Ravenovia);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingBarov, "28, 30").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.Ravenovia);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Ravenovia, "5, 28, 30").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.KingBarov);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.MaryaMarkovia, "27, 28")
                .BindCharacters(CharacterEnum.Endorovich);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Endorovich, "27, 28")
                .BindCharacters(CharacterEnum.MaryaMarkovia)
                .BindCreatures(Creature.Spectre).BindAlignment(Alignment.LE);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.SashaIvliskova, "28")
                .BindCharacters(DarklordEnum.CountStrahd)
                .BindCreatures(Creature.Human, Creature.Vampire).BindAlignment(Alignment.CE);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.PatrinaVelikovna, "28")
                .BindCharacters(DarklordEnum.CountStrahd)
                .BindCreatures(Creature.Elf, Creature.Banshee).BindAlignment(Alignment.CE);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Tatyana, "1, 30, 31").BindCreatures(Creature.Human)
                .BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.Sergei);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KolyanIndirovich, "7, 8, 9").BindCreatures(Creature.Human)
                .BindCharacters(CharacterEnum.IreenaKolyana, CharacterEnum.Ismark);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.IreenaKolyana).BindCreatures(Creature.Human).BindAlignment(Alignment.LG)
                .BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.Ismark);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Ismark, "8, 9").BindCreatures(Creature.Human).BindAlignment(Alignment.LG);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.MadMary, "9, 19").BindCreatures(Creature.Human).BindAlignment(Alignment.CN)
                .BindCharacters(CharacterEnum.Gertruda);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Gertruda, "9, 19").BindCreatures(Creature.Human).BindAlignment(Alignment.NG);

            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Bildrath, "8").BindCreatures(Creature.Human).BindAlignment(Alignment.LN)
                .BindCharacters(CharacterEnum.Parriwimple);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.Parriwimple, "8").BindCreatures(Creature.Human).BindAlignment(Alignment.LN);
            #endregion

            #region Items
            DomainEnum.Barovia.AddItem(ItemEnum.Sunsword, "5, 31").BindDomains(DomainEnum.OutsideRavenloft);

            DomainEnum.Barovia.AddItem(ItemEnum.IconOfRaven, "14");
            DomainEnum.Barovia.AddItem(ItemEnum.SymbolOfRaven, "17, 30").BindCreatures(Creature.Vampire);
            DomainEnum.Barovia.AddItem(ItemEnum.Book.TomeOfStrahd, "9, 11, 31");

            DomainEnum.Barovia.AddItem(ItemEnum.Book.EmbalmTheLostArt, "21").ExtraInfo = "Mundane Book";
            DomainEnum.Barovia.AddItem(ItemEnum.Book.LifeAmongUndead, "21").ExtraInfo = "Mundane Book";
            DomainEnum.Barovia.AddItem(ItemEnum.Book.IdentifyBloodTypes, "21").ExtraInfo = "Mundane Book";
            DomainEnum.Barovia.AddItem(ItemEnum.Book.MasonryWoodwork, "21").ExtraInfo = "Mundane Book";
            #endregion

            #region Groups
            DomainEnum.Barovia.AddGroup(GroupEnum.BarovianWine, "27").BindCharacters(CharacterEnum.ArtankSwilovich);
            DomainEnum.Barovia.AddGroup(GroupEnum.BridesOfStrahd, "28")
                .BindCreatures(Creature.Vampire)
                .BindCharacters(CharacterEnum.SashaIvliskova, CharacterEnum.PatrinaVelikovna)
                .ExtraInfo = "Count Strahd has collected a few partners over the years.";
            DomainEnum.Barovia.AddGroup(GroupEnum.Tatyana, "30, 31").BindCharacters(CharacterEnum.Tatyana, CharacterEnum.IreenaKolyana);
            DomainEnum.Barovia.AddGroup(GroupEnum.Vistani, "1, 4, 7, 11, 28").BindLocations(Settlement.TserPoolEncampnent, LocationEnum.MadamEvasTent);
            DomainEnum.Barovia.AddGroup(GroupEnum.Burgomaster, "1, 7, 8, 9").BindCharacters(CharacterEnum.KolyanIndirovich);
            DomainEnum.Barovia.AddGroup(GroupEnum.BurgomasterOfBarovia, "1, 7, 8, 9").BindCharacters(CharacterEnum.KolyanIndirovich);
            DomainEnum.Barovia.AddGroup(GroupEnum.HighPriestMostHoly, "28").BindCharacters(CharacterEnum.CirilRomulich);
            DomainEnum.Barovia.AddGroup(GroupEnum.HighPriestRavenloft, "30").BindItems(ItemEnum.SymbolOfRaven);
            GroupEnum.Burgomaster.BindGroups(GroupEnum.BurgomasterOfBarovia);
            #endregion

            Settlement.Barovia.PopulateSettlement(LocationEnum.BildrathMercantile, LocationEnum.BloodVineTavern, LocationEnum.MaryHouse, LocationEnum.BurgomasterHome,
                                                  LocationEnum.BurgomasterGuestHouse, LocationEnum.BaroviaChurch, LocationEnum.BaroviaChurch);
            Settlement.TserPoolEncampnent.PopulateSettlement(LocationEnum.TserPool, LocationEnum.MadamEvasTent);
        }
        void AddI10TheHouseOnGryphonHill()
        {
            var releaseDate = "01/11/1983";
            string ExtraInfo = "<br/>&emsp;Authors: Tracy Hickman and Laura Hickman";
            ExtraInfo += "<br/>&emsp;Design Team: David Cook, Jeff Grubb, Tracy & Laura Hickman, Harold Johnson, and Douglas Niles";
            ExtraInfo += "<br/>&emsp;Editor: Harold Johnson";
            ExtraInfo += "<br/>&emsp;Cover Artist: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Interior Artist: Jeff Easley";
            ExtraInfo += "<br/>&emsp;Cartographer: David S. LaForce";
            ExtraInfo += "<br/>&emsp;Typograper: Betty Elmore & Kim Lindau";
            ExtraInfo += "<br/>&emsp;Keyliner: Linda Bakk";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 4-6 characters of levels 8-10";
            using var ctx = CreateSource("I10: Ravenloft II: The House on Gryphon Hill", releaseDate, ExtraInfo, Edition.e1, Media.module);

            DomainEnum.Barovia.Appeared("2, 5, 41");
            DomainEnum.Mordent.Appeared();

            #region Locations
            DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft, "5, 12").BindItems(ItemEnum.Book.MissingEntry)
                .BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.Tatyana, CharacterEnum.Sergei);

            DomainEnum.Mordent.AddSettlement(Settlement.Mordentshire)
                .BindCreatures(Creature.CrimsonDeath, Creature.Drelb, Creature.InvisibleStalker, Creature.LurkerAbove, Creature.ShadowMastiff, Creature.Spectre, Creature.Wraith, Creature.Lich, Creature.GroaningSpirit, Creature.Human, Creature.Ghast, Creature.BlackCat, Creature.Wight, Creature.Dog, Creature.Raven)
                .BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.LadyWeathermay, CharacterEnum.OldLadyWeathermay, CharacterEnum.LordWeathermay, CharacterEnum.MistressArdent, CharacterEnum.Germain, CharacterEnum.Marion, CharacterEnum.Dominic, CharacterEnum.Luker, CharacterEnum.CavelWarden, CharacterEnum.KedarKlienan, CharacterEnum.Justinian, CharacterEnum.Honorius, CharacterEnum.Carlisle, CharacterEnum.BrennaRaven, CharacterEnum.TabbFinhallen, CharacterEnum.KirkTerrinton, CharacterEnum.MayorMalvinHeatherby, CharacterEnum.TylerSmythy, CharacterEnum.GregorBoyd, DarklordEnum.AzalinRex, CharacterEnum.GlennaWarden, CharacterEnum.Gwydion, CharacterEnum.GastonHedgewick, CharacterEnum.ArianaBartel, CharacterEnum.CarinaLoch, CharacterEnum.DarcyPease, CharacterEnum.BathildaSud, CharacterEnum.IdaHobson, CharacterEnum.KynaSmythy, CharacterEnum.SolitaMaravan, CharacterEnum.UstisMaravan, CharacterEnum.SterlingToddburry, CharacterEnum.EthanToddburry, CharacterEnum.ChristinaBartel, CharacterEnum.EricaToddburry, CharacterEnum.FatherJoshuaTalbot, CharacterEnum.NormalKervil, CharacterEnum.NeolaCaraway, CharacterEnum.SilasArcher, CharacterEnum.VioletArcher, CharacterEnum.PenelopeArcher, CharacterEnum.ElwinHobson, CharacterEnum.TildaMayberry, CharacterEnum.FreedaMayberry, CharacterEnum.BerwinHedgewick, CharacterEnum.LenorHedgewick, CharacterEnum.LobeliaTarner, CharacterEnum.RaeSoddenter, CharacterEnum.ParvisSoddenter, CharacterEnum.LeeHeatherby, CharacterEnum.MargaretHeatherby, CharacterEnum.TobaisKenkiny, CharacterEnum.DesmaKenkiny, DarklordEnum.WilfredGodefroy, CharacterEnum.LadyEstelleWeathermayGodefroy, CharacterEnum.LiliaGodefroy, CharacterEnum.GoodmanMorris, CharacterEnum.LordRenier, CharacterEnum.VoglerKervil, CharacterEnum.Marston, CharacterEnum.Ellie, CharacterEnum.AxtelBartel, CharacterEnum.BarthKleinen, CharacterEnum.PercivalSud, CharacterEnum.HargelGrummsh, CharacterEnum.EismanKhargug, CharacterEnum.CoriemonHandlet, CharacterEnum.GorbaghSnarltooth, CharacterEnum.GastonImrad, CharacterEnum.SheclkeDuskman, CharacterEnum.ArlieEsterbridge, CharacterEnum.CarlRamm, CharacterEnum.TandleCoreystal, CharacterEnum.EllenStinworthy, CharacterEnum.KarenEdgerton, CharacterEnum.Sshhisthulhuu, CharacterEnum.WinifredKleinen, CharacterEnum.BridgetDumas, CharacterEnum.BaronFielders, CharacterEnum.BaronessFielders, CharacterEnum.LadyFielders, CharacterEnum.Lucifer, CharacterEnum.EmmaKelley, CharacterEnum.Tintantilus, CharacterEnum.CharityBliss, CharacterEnum.ThadeusMontBreezar, CharacterEnum.MystiTokana, CharacterEnum.AmarBoriSandflinger, CharacterEnum.RogoldGildenman, CharacterEnum.Barnabas, CharacterEnum.PhillipeDelamana, CharacterEnum.Rembrania, CharacterEnum.BrendaCrimsonBlade, CharacterEnum.Sugartooth, CharacterEnum.BrotherSummer, CharacterEnum.Muffin, CharacterEnum.TGRedanto, CharacterEnum.Apricot, CharacterEnum.MikhailYelkif, CharacterEnum.Trellgaard, CharacterEnum.MasterIlmen, CharacterEnum.CaareyGelthik, CharacterEnum.SeanTimothy, CharacterEnum.JerimyEstmore, CharacterEnum.MasterTangle, CharacterEnum.WrenThims, CharacterEnum.SharonTeece, CharacterEnum.MollyGrayswit, CharacterEnum.Stelwaard, CharacterEnum.ThinnBalder, CharacterEnum.BadderGhastling, CharacterEnum.EstherTimothy, CharacterEnum.GeamPelstap, CharacterEnum.MaquirLoft, CharacterEnum.MirandaLangstry, CharacterEnum.KelmanOsterlaker, CharacterEnum.FionaMatheson, CharacterEnum.Fanerath, CharacterEnum.Hellinken, CharacterEnum.KattleLisbury, CharacterEnum.EmoryMaus, CharacterEnum.MarcusLithe, CharacterEnum.NendrumSintel, CharacterEnum.ThellactinMianns, CharacterEnum.KellyDuncan, CharacterEnum.CheldonIllcome, CharacterEnum.Mythrel, CharacterEnum.MillicentHodgson, CharacterEnum.NatterlyKnutnor, CharacterEnum.EowinTimothy, CharacterEnum.MomsinAlenny, CharacterEnum.ShingolTann, CharacterEnum.LarsonChelf, CharacterEnum.YettergunFolie, CharacterEnum.LeslieKale)
                .BindItems(ItemEnum.Apparatus, ItemEnum.Rod.Rastinon, ItemEnum.SoulSearcher, ItemEnum.Ring.Reverse, ItemEnum.Book.AlchemistDiary, ItemEnum.Book.MissingEntry, ItemEnum.Sunsword, ItemEnum.Scroll.NegPlaneProt, ItemEnum.LocketOfSealing, ItemEnum.Potion.Climb, ItemEnum.Potion.ExtraHeal, ItemEnum.Potion.Speed, ItemEnum.Potion.SuperHero, ItemEnum.Scroll.HolySymbol, ItemEnum.Scroll.InvisToUndead, ItemEnum.Scroll.ProtEvil, ItemEnum.Scroll.Restore, ItemEnum.Potion.ClairAud, ItemEnum.Potion.Dim, ItemEnum.Elixir.Mad, ItemEnum.MirrorOfLaw, ItemEnum.Book.TheInnerSoul, ItemEnum.IncenseOfMed, ItemEnum.Book.THENATUREOFTHESOUL, ItemEnum.SunBlade, ItemEnum.SwordOfWound, ItemEnum.Ring.DetGood, ItemEnum.Rope.Entangle, ItemEnum.MedallionOfProt, ItemEnum.FlashGrenade, ItemEnum.Cloak.Prot, ItemEnum.Ring.Regen, ItemEnum.GemOfLight, ItemEnum.Scroll.Storing, ItemEnum.Scroll.ProtUnd, ItemEnum.Brooch.ProtGood, ItemEnum.Ring.ProtNM, ItemEnum.Ring.Aim, ItemEnum.Potion.Heal, ItemEnum.Cloak.Disp, ItemEnum.Ring.Prot, ItemEnum.Elixir.Health, ItemEnum.Scroll.Calling, ItemEnum.BracersOfDefense, ItemEnum.DartOfHoming, ItemEnum.DaggerOfVenom, ItemEnum.Staff.ThunderAndLightning, ItemEnum.PowderOfHaste, ItemEnum.Elixir.Displace, ItemEnum.Potion.CSNW, ItemEnum.Rod.Flail, ItemEnum.Scroll.ProtWnS, ItemEnum.Staff.Strike, ItemEnum.AlchemyJug, ItemEnum.StoneOfControlEarth, ItemEnum.Scroll.ProtDev, ItemEnum.Scroll.ProtDem, ItemEnum.Scroll.ProtPet, ItemEnum.Ring.WaterWalk, ItemEnum.DragonSlayer, ItemEnum.HornOfValhalla, ItemEnum.ArrowOfDirect, ItemEnum.TrollCleaver, ItemEnum.PhylacteryOfFaith, ItemEnum.SwordOfLifeSteal, ItemEnum.Rope.Climb, ItemEnum.Scarab.Prot);

            DomainEnum.Mordent.AddLocation(LocationEnum.SaulbridgeSanitarium, "6, 13, 23, 24, Cargo Roster")
                .BindCharacters(CharacterEnum.Germain, CharacterEnum.Marion, CharacterEnum.Luker, CharacterEnum.Marston, CharacterEnum.Ellie, CharacterEnum.AxtelBartel, CharacterEnum.BarthKleinen);

            DomainEnum.Mordent.AddLocation(LocationEnum.GryphonHill, "1, 2, 7, 16, 19, 22, 23, 25, 26, 28, 32, 41, 44-47, Cargo Roster, Event Chart")
                .BindItems(ItemEnum.Sunsword);
            DomainEnum.Mordent.AddLocation(LocationEnum.GryphonHillMansion, "1, 2, 7, 16, 19, 22, 23, 26, 28-31, 44, 47, 48")
                .BindCreatures(Creature.Vampire, Creature.GroaningSpirit, Creature.Gargoyle, Creature.StoneGolem, Creature.Spirit, Creature.Ghost, Creature.Mouse, Creature.GiantSpider, Creature.Shade, Creature.Haunt, Creature.Drelb, Creature.Stirge, Creature.LurkerAbove, Creature.QuasiElementalLightning, Creature.GreenSlime)
                .BindLocations(LocationEnum.GryphonHill)
                .BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.LordRenier, DarklordEnum.WilfredGodefroy, CharacterEnum.LadyEstelleWeathermayGodefroy, CharacterEnum.LiliaGodefroy, CharacterEnum.GastonImrad, CharacterEnum.SheclkeDuskman, CharacterEnum.ArlieEsterbridge, CharacterEnum.CarlRamm, CharacterEnum.TandleCoreystal, CharacterEnum.EllenStinworthy, CharacterEnum.KarenEdgerton, CharacterEnum.Sshhisthulhuu)
                .BindItems(ItemEnum.Sunsword, ItemEnum.Book.TheInnerSoul, ItemEnum.IncenseOfMed, ItemEnum.Apparatus);

            DomainEnum.Mordent.AddLocation(LocationEnum.HeatherHouse, "1, 3, 10, 13, 15, 16, 19, 24, 26, 32-39, 41, 44, 45, 47, Cargo Roster")
                .BindCreatures(Creature.GiantToad, Creature.Stirge, Creature.GreenSlime, Creature.Vampire, Creature.InvisibleStalker, Creature.Haunt, Creature.Shade, Creature.GroaningSpirit, Creature.Banshee, Creature.Horse, Creature.SkeletalSteed, Creature.Maggot, Creature.StrahdZombie, Creature.StoneGolem, Creature.Gargoyle, Creature.Raven, Creature.Doppelganger, Creature.StrahdSkeleton, Creature.ShadowMastiff, Creature.Trapper)
                .BindCharacters(CharacterEnum.LordWeathermay, CharacterEnum.LadyWeathermay, CharacterEnum.OldLadyWeathermay, CharacterEnum.LordRenier, CharacterEnum.MistressArdent, DarklordEnum.CountStrahd, CharacterEnum.LeeHeatherby, CharacterEnum.MargaretHeatherby, CharacterEnum.WinifredKleinen, CharacterEnum.BridgetDumas, CharacterEnum.EmmaKelley)
                .BindItems(ItemEnum.Book.THENATUREOFTHESOUL, ItemEnum.Apparatus, ItemEnum.Rod.Rastinon, ItemEnum.SoulSearcher, ItemEnum.Ring.Reverse, ItemEnum.Book.MissingEntry);

            DomainEnum.Mordent.AddLocation(LocationEnum.WeathermayMausoleum, "1, 15, 32, 38, 39, 45, 48, Event Chart")
                .BindCreatures(Creature.Spectre, Creature.Wraith).BindItems(ItemEnum.SunBlade, ItemEnum.Apparatus)
                .BindCharacters(DarklordEnum.AzalinRex, DarklordEnum.WilfredGodefroy, CharacterEnum.Tintantilus, CharacterEnum.LordRenier);
            DomainEnum.Mordent.AddLocation(LocationEnum.BlackardInn, "14, 19, 20, Cargo Roster").BindCreatures(Creature.Spider)
                .BindCharacters(CharacterEnum.Dominic, CharacterEnum.Gwydion);
            DomainEnum.Mordent.AddLocation(LocationEnum.Livery, "14")
                .BindCharacters(CharacterEnum.TylerSmythy, CharacterEnum.KynaSmythy);
            DomainEnum.Mordent.AddLocation(LocationEnum.Garrison, "14").BindCreatures(Creature.GiantRat)
                .BindCharacters(CharacterEnum.TylerSmythy, CharacterEnum.Justinian, CharacterEnum.KedarKlienan, CharacterEnum.Carlisle);
            DomainEnum.Mordent.AddLocation(LocationEnum.BurnedChurch, "14, 22, Cargo Roster")
                .BindCharacters(CharacterEnum.FatherJoshuaTalbot)
                .BindItems(ItemEnum.Rod.Rastinon, ItemEnum.SoulSearcher, ItemEnum.Ring.Reverse, ItemEnum.Book.MissingEntry);
            DomainEnum.Mordent.AddLocation(LocationEnum.Smithy, "14, 22, Cargo Roster")
                .BindCharacters(CharacterEnum.ElwinHobson, CharacterEnum.IdaHobson);
            DomainEnum.Mordent.AddLocation(LocationEnum.MayorsHouse, "1, 14, 23").BindCharacters(CharacterEnum.MayorMalvinHeatherby);
            DomainEnum.Mordent.AddLocation(LocationEnum.KervilsShop, "14, 23").BindCharacters(CharacterEnum.VoglerKervil);
            DomainEnum.Mordent.AddLocation(LocationEnum.Marketplace, "14")
                .BindCharacters(CharacterEnum.BerwinHedgewick, CharacterEnum.LenorHedgewick, CharacterEnum.LobeliaTarner, CharacterEnum.BathildaSud, CharacterEnum.RaeSoddenter, CharacterEnum.ParvisSoddenter, CharacterEnum.EricaToddburry);
            DomainEnum.Mordent.AddLocation(LocationEnum.Warehouse, "15, 21");
            DomainEnum.Mordent.AddLocation(LocationEnum.SouthRoad, "15, 25");
            DomainEnum.Mordent.AddLocation(LocationEnum.KeeldevilPoint, "17");
            DomainEnum.Mordent.AddLocation(LocationEnum.FishermanAlley, "17, 24, Cargo Roster")
                .BindCreatures(Creature.Doppelganger).BindCharacters(CharacterEnum.MikhailYelkif);
            DomainEnum.Mordent.AddLocation(LocationEnum.ShippingHouse, "21").BindCharacters(CharacterEnum.CavelWarden);
            DomainEnum.Mordent.AddLocation(LocationEnum.SeventhSea, "21, 42")
                .BindCharacters(CharacterEnum.KirkTerrinton, CharacterEnum.CharityBliss);
            DomainEnum.Mordent.AddLocation(LocationEnum.TravelersInn, "21, Cargo Roster")
                .BindCharacters(CharacterEnum.SolitaMaravan, CharacterEnum.TabbFinhallen, CharacterEnum.UstisMaravan);
            DomainEnum.Mordent.AddLocation(LocationEnum.AnchorStreet, "21");
            DomainEnum.Mordent.AddLocation(LocationEnum.ShoreLane, "21");
            DomainEnum.Mordent.AddLocation(LocationEnum.MillRoad, "21");
            DomainEnum.Mordent.AddLocation(LocationEnum.MillBridge, "21").BindCreatures(Creature.BlackCat)
                .BindCharacters(CharacterEnum.ChristinaBartel, CharacterEnum.ArianaBartel);
            DomainEnum.Mordent.AddLocation(LocationEnum.ArdenRiver, "21, 25, Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.OldMill, "21")
                .BindCharacters(CharacterEnum.SterlingToddburry, CharacterEnum.EthanToddburry, CharacterEnum.EricaToddburry);
            DomainEnum.Mordent.AddLocation(LocationEnum.Churchyard, "22").BindCharacters(CharacterEnum.NormalKervil);
            DomainEnum.Mordent.AddLocation(LocationEnum.OldSaltHouse, "22, Cargo Roster").BindCharacters(CharacterEnum.NeolaCaraway);
            DomainEnum.Mordent.AddLocation(LocationEnum.SaltyDogTavern, "22").BindCharacters(CharacterEnum.BrennaRaven);
            DomainEnum.Mordent.AddLocation(LocationEnum.Butcher, "22, Cargo Roster")
                .BindCharacters(CharacterEnum.SilasArcher, CharacterEnum.VioletArcher, CharacterEnum.PenelopeArcher);
            DomainEnum.Mordent.AddLocation(LocationEnum.Bakery, "22")
                .BindCharacters(CharacterEnum.TildaMayberry, CharacterEnum.FreedaMayberry);
            DomainEnum.Mordent.AddLocation(LocationEnum.Groundskeeper, "23").BindCharacters(CharacterEnum.LeeHeatherby, CharacterEnum.MargaretHeatherby);
            DomainEnum.Mordent.AddLocation(LocationEnum.OldBooks, "23").BindCharacters(CharacterEnum.TobaisKenkiny, CharacterEnum.DesmaKenkiny);
            DomainEnum.Mordent.AddLocation(LocationEnum.Wharf, "9, 21, 23").BindCreatures(Creature.GroaningSpirit);
            DomainEnum.Mordent.AddLocation(LocationEnum.Farms, "24")
                .BindCharacters(CharacterEnum.LobeliaTarner, CharacterEnum.PercivalSud, CharacterEnum.BathildaSud, CharacterEnum.GastonHedgewick, CharacterEnum.LenorHedgewick, CharacterEnum.BerwinHedgewick, CharacterEnum.ParvisSoddenter, CharacterEnum.RaeSoddenter);
            DomainEnum.Mordent.AddLocation(LocationEnum.ArdentBay, "24").BindCreatures(Creature.StrahdZombie);

            DomainEnum.Mordent.AddLocation(LocationEnum.WindwandAvenue, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.GlenRoad, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.MarketStreet, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.Barracks, "Map").BindLocations(LocationEnum.Gaol);
            DomainEnum.Mordent.AddLocation(LocationEnum.Gaol, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.HeatherWay, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.MaddingRoad, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.Backwater, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.ButcherLane, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.WoodHollow, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.Cliffedge, "Map");
            DomainEnum.Mordent.AddLocation(LocationEnum.Scrimshaw, "Map");

            DomainEnum.Mordent.AddLocation(LocationEnum.NorthRoad, "25");
            DomainEnum.Mordent.AddLocation(LocationEnum.Moors, "1, 3, 12, 16, 23-26, 43")
                .BindCreatures(Creature.Human, Creature.StrahdZombie, Creature.Griffon, Creature.Harpy, Creature.Hellhound, Creature.Orc, Creature.Ogre, Creature.QuasiElementalLightning, Creature.Raven, Creature.GiantSpider, Creature.Stirge, Creature.Vulture, Creature.DireWolf, Creature.Bodak, Creature.Ghast, Creature.GroaningSpirit, Creature.ShadowMastiff, Creature.Nightmare, Creature.Skeleton, Creature.SkeletonSteed, Creature.Wraith, Creature.WillOWisp, Creature.CrimsonDeath, Creature.Doppelganger, Creature.DisplacerBeast, Creature.StrahdSkeleton)
                .BindCharacters(CharacterEnum.Marston);
            DomainEnum.Mordent.AddLocation(LocationEnum.NorthMoors, "25, 42").BindCreatures(Creature.Harpy)
                .BindItems(ItemEnum.Scroll.NegPlaneProt, ItemEnum.LocketOfSealing);
            DomainEnum.Mordent.AddLocation(LocationEnum.Cliffs, "25").BindCreatures(Creature.Orc, Creature.Ogre, Creature.Ghast)
                .BindCharacters(CharacterEnum.HargelGrummsh, CharacterEnum.EismanKhargug)
                .BindItems(ItemEnum.Potion.Climb, ItemEnum.Potion.ExtraHeal, ItemEnum.Potion.Speed, ItemEnum.Potion.SuperHero, ItemEnum.Scroll.HolySymbol, ItemEnum.Scroll.InvisToUndead, ItemEnum.Scroll.ProtEvil, ItemEnum.Scroll.Restore);
            DomainEnum.Mordent.AddLocation(LocationEnum.DarkWoods, "25, 26, 31").BindCreatures(Creature.GiantSpider, Creature.Ogre, Creature.Vulture)
                .BindCharacters(CharacterEnum.CoriemonHandlet, CharacterEnum.GorbaghSnarltooth)
                .BindItems(ItemEnum.Potion.ClairAud, ItemEnum.Potion.Dim, ItemEnum.Elixir.Mad, ItemEnum.MirrorOfLaw);

            DomainEnum.Mordent.AddLocation(LocationEnum.GryphonRoad, "26");
            DomainEnum.Mordent.AddLocation(LocationEnum.Bog, "26").BindCreatures(Creature.CrimsonDeath);
            DomainEnum.Mordent.AddLocation(LocationEnum.MordentshireCemetery, "26").BindCreatures(Creature.StrahdZombie, Creature.StrahdSkeleton);

            DomainEnum.Mordent.AddLocation(LocationEnum.HiddenTrack, "26").BindCreatures(Creature.Mihstu, Creature.Werewolf);
            DomainEnum.Mordent.AddLocation(LocationEnum.HeatherHousePoint, "32").BindCreatures(Creature.DisplacerBeast, Creature.ShadowMastiff, Creature.Wraith, Creature.Hellhound, Creature.Skeleton, Creature.Raven, Creature.StrahdZombie, Creature.GiantSpider);
            DomainEnum.Mordent.AddLocation(LocationEnum.Heatherwood, "32, 33").BindCreatures(Creature.DisplacerBeast, Creature.ShadowMastiff, Creature.Wraith, Creature.Hellhound, Creature.Skeleton, Creature.Raven, Creature.StrahdZombie, Creature.GiantSpider, Creature.Deer, Creature.Rabbit, Creature.Squirrel, Creature.Skunk);
            DomainEnum.Mordent.AddLocation(LocationEnum.HeatherRoad, "33");
            #endregion

            #region Characters
            DomainEnum.Mordent.AddLivingCharacter(DarklordEnum.CountStrahd)
                .BindAlignment(Alignment.CE | Alignment.NG).BindDomains(DomainEnum.Barovia)
                .BindCreatures(Creature.Human, Creature.Vampire, Creature.Bat, Creature.Wolf)
                .BindRelatedCreatures(Creature.Banshee, Creature.StrahdZombie, Creature.StrahdSkeleton, Creature.DireWolf, Creature.Hellhound, Creature.ShadowMastiff, Creature.Raven, Creature.VampireBat, Creature.Rat, Creature.Bat, Creature.Quasit, Creature.Werewolf, Creature.Harpy, Creature.Ogre, Creature.Vulture, Creature.Nightmare, Creature.BlackCat, Creature.StrahdSteed)
                .BindItems(ItemEnum.SwordOfWound, ItemEnum.Ring.DetGood, ItemEnum.Rope.Entangle, ItemEnum.MedallionOfProt, ItemEnum.FlashGrenade, ItemEnum.Cloak.Prot, ItemEnum.Ring.Regen, ItemEnum.GemOfLight, ItemEnum.Scroll.Storing)
                .ExtraInfo = "Referred to here as either 'Alchemist' or 'Creature'";

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Sergei, "5").BindCreatures(Creature.Human)
                .BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.Tatyana);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Tatyana, "5, 47").BindCharacters(DarklordEnum.CountStrahd);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LadyWeathermay, "3, 6-9, 32, 33, 36, 40, 44, 45, Cargo Roster")
                .BindCreatures(Creature.Human).BindAlignment(Alignment.LG)
                .BindCharacters(CharacterEnum.OldLadyWeathermay, CharacterEnum.LordWeathermay, DarklordEnum.CountStrahd, CharacterEnum.MistressArdent)
                .BindItems(ItemEnum.Ring.Prot, ItemEnum.Elixir.Health, ItemEnum.Scroll.Calling, ItemEnum.BracersOfDefense);

            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.OldLadyWeathermay, "35, 36, 38")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.LordWeathermay);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LordWeathermay, "3, 6, 8-10, 12-14, 17, 32-36, 44, 45")
                .BindCreatures(Creature.Human).BindAlignment(Alignment.LG)
                .BindItems(ItemEnum.Ring.Aim, ItemEnum.Potion.Heal, ItemEnum.Cloak.Disp);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MistressArdent, "3, 6, 9, 32, 35, 44, Cargo Roster")
                .BindCreatures(Creature.Human).BindAlignment(Alignment.CG)
                .BindItems(ItemEnum.Scroll.ProtUnd, ItemEnum.Brooch.ProtGood, ItemEnum.Ring.ProtNM);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Germain, "3, 6, 7, 10, 13, 20, 24, Cargo Roster")
                .BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Marion, "13").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Dominic, "13, 20, Cargo Roster, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Luker, "13, 14, 24").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CavelWarden, "15, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.GlennaWarden);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GlennaWarden, "19, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KedarKlienan, "16, 17, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Justinian, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Honorius, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Carlisle, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BrennaRaven, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TabbFinhallen, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KirkTerrinton, "16, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MayorMalvinHeatherby, "16, 17, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.LeeHeatherby, CharacterEnum.MargaretHeatherby);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LeeHeatherby, "23, 34, 35, Cargo Roster, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Horse).BindCharacters(CharacterEnum.MargaretHeatherby);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MargaretHeatherby, "23, 34, 35, Cargo Roster, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TylerSmythy, "16, 20, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GregorBoyd, "17").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(DarklordEnum.AzalinRex, "17, 38, 39, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human, Creature.Lich, Creature.Quasit, Creature.Horse).BindAlignment(Alignment.NE)
                .BindCharacters(CharacterEnum.Tintantilus)
                .BindItems(ItemEnum.DartOfHoming, ItemEnum.DaggerOfVenom, ItemEnum.Staff.ThunderAndLightning, ItemEnum.PowderOfHaste, ItemEnum.Elixir.Displace, ItemEnum.Potion.CSNW);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Tintantilus, "42, 45").BindCreatures(Creature.Quasit, Creature.Bat, Creature.Wolf);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Gwydion, "19, 20, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GastonHedgewick, "19, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.BerwinHedgewick, CharacterEnum.LenorHedgewick);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BerwinHedgewick, "23, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.LenorHedgewick);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LenorHedgewick, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CarinaLoch, "19, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.DarcyPease, "19, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BathildaSud, "19, 23, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.PercivalSud);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.PercivalSud, "24, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.IdaHobson, "19, 22, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.ElwinHobson);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ElwinHobson, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KynaSmythy, "20, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.SolitaMaravan, "21, Cargo Roster, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.UstisMaravan);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.UstisMaravan, "21").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.SterlingToddburry, "21, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.EthanToddburry, CharacterEnum.EricaToddburry);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EthanToddburry, "21, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.EricaToddburry);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EricaToddburry, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.FatherJoshuaTalbot, "22, 28, Cargo Roster, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.NormalKervil, "22").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.NeolaCaraway, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.SilasArcher, "22, Cargo Roster, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.VioletArcher, CharacterEnum.PenelopeArcher);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.VioletArcher, "22, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.PenelopeArcher);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.PenelopeArcher, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TildaMayberry, "22, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.FreedaMayberry);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.FreedaMayberry, "22, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LobeliaTarner, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.RaeSoddenter, "23, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.ParvisSoddenter);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ParvisSoddenter, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TobaisKenkiny, "23, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.DesmaKenkiny);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.DesmaKenkiny, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(DarklordEnum.WilfredGodefroy, "23, 28, 31, 39, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human, Creature.Haunt).BindAlignment(Alignment.CN);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LadyEstelleWeathermayGodefroy, "23, 28, 29, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human, Creature.Ghost);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LiliaGodefroy, "23, 29, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human, Creature.Haunt);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GoodmanMorris, "23").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LordRenier, "23, 39, 45").BindCreatures(Creature.Human).BindItems(ItemEnum.SunBlade);
            CharacterEnum.GoodmanMorris.ExtraInfo = CharacterEnum.LordRenier.ExtraInfo = "Probably deceased";

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.VoglerKervil, "23, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.CyrusBelview, "24").BindCreatures(Creature.Human).BindCharacters(DarklordEnum.CountStrahd);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Marston, "24").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Ellie, "24").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ArianaBartel, "19, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.ChristinaBartel, CharacterEnum.AxtelBartel);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ChristinaBartel, "21, Transpossession Rosters Handout")
                .BindCreatures(Creature.Human).BindCharacters(CharacterEnum.AxtelBartel);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.AxtelBartel, "24, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BarthKleinen, "24, Transpossession Rosters Handout").BindCreatures(Creature.Human);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.HargelGrummsh, "25").BindCreatures(Creature.Orc).BindRelatedCreatures(Creature.Ogre, Creature.Ghast);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EismanKhargug, "25").BindCreatures(Creature.Orc);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CoriemonHandlet, "26, Transpossession Rosters Handout").BindCreatures(Creature.Bodak).BindRelatedCreatures(Creature.Ogre, Creature.Vulture, Creature.Wight);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GorbaghSnarltooth, "26").BindCreatures(Creature.Ogre);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GastonImrad, "29, Transpossession Rosters Handout").BindCreatures(Creature.Shade);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.SheclkeDuskman, "29, Transpossession Rosters Handout").BindCreatures(Creature.Shade);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ArlieEsterbridge, "29").BindCreatures(Creature.Vampire);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CarlRamm, "31, Transpossession Rosters Handout").BindCreatures(Creature.Mummy);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TandleCoreystal, "31, Transpossession Rosters Handout").BindCreatures(Creature.Shade);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EllenStinworthy, "31, Transpossession Rosters Handout").BindCreatures(Creature.Mummy);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KarenEdgerton, "31, Transpossession Rosters Handout").BindCreatures(Creature.Wight);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Sshhisthulhuu, "31, Transpossession Rosters Handout").BindCreatures(Creature.Mihstu);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.WinifredKleinen, "35, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BridgetDumas, "35, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BaronFielders, "3, 33, 35, 36, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BaronessFielders, "3, 33, 35, 36, Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LadyFielders, "3, 33, 35, 36").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Lucifer, "36").BindCreatures(Creature.Raven);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EmmaKelley, "37, Transpossession Rosters Handout").BindCreatures(Creature.Vampire);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CharityBliss, "42, Transpossession Rosters Handout").BindCreatures(Creature.Vampire);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ThadeusMontBreezar, "47, Card Handout")
                .BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Horse).BindAlignment(Alignment.TN)
                .BindCharacters(CharacterEnum.MystiTokana)
                .BindItems(ItemEnum.Ring.Prot, ItemEnum.Cloak.Disp, ItemEnum.Staff.Strike, ItemEnum.AlchemyJug, ItemEnum.StoneOfControlEarth, ItemEnum.Scroll.ProtDev, ItemEnum.Scroll.ProtDem, ItemEnum.Scroll.ProtPet, ItemEnum.Ring.WaterWalk)
                .BindLanguages(Language.Common, Language.MountainGiant, Language.Orc, Language.RedDragon, Language.Treant, Language.Illithid, Language.Drow, Language.KuoToan);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MystiTokana, "48, Card Handout")
                .BindCreatures(Creature.HalfElf).BindRelatedCreatures(Creature.Elf).BindAlignment(Alignment.CG).BindItems(ItemEnum.Scarab.Prot)
                .BindLanguages(Language.Common, Language.Elf, Language.Gnome, Language.Halfling, Language.Goblin, Language.Hobgoblin, Language.Orc, Language.Gnoll);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.AmarBoriSandflinger, "48, Card Handout")
                .BindCreatures(Creature.Gnome).BindAlignment(Alignment.TN)
                .BindLanguages(Language.Common, Language.Dwarf, Language.Gnome, Language.Halfling, Language.Goblin, Language.BurrowingMammals, Language.Elf, Language.DesertNomad);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.RogoldGildenman, "Card Handout")
                .BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Horse).BindAlignment(Alignment.LG)
                .BindLanguages(Language.Common, Language.Elf, Language.Gnome, Language.HillGiant, Language.Ogre)
                .BindItems(ItemEnum.Rod.Flail, ItemEnum.Scroll.ProtWnS);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Barnabas, "Card Handout")
                .BindCreatures(Creature.Horse).BindCharacters(CharacterEnum.RogoldGildenman)
                .ExtraInfo = "Bay Mare (Medium Horse)";

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.PhillipeDelamana, "Card Handout")
                .BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Horse).BindAlignment(Alignment.LG)
                .BindLanguages(Language.Common, Language.Elf, Language.Dwarf)
                .BindItems(ItemEnum.DragonSlayer, ItemEnum.HornOfValhalla);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Rembrania, "Card Handout")
                .BindCreatures(Creature.Horse).BindCharacters(CharacterEnum.PhillipeDelamana)
                .ExtraInfo = "White Paladin`s Mount";

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BrendaCrimsonBlade, "Card Handout")
                .BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Horse).BindAlignment(Alignment.NG)
                .BindLanguages(Language.Common, Language.Troll)
                .BindItems(ItemEnum.ArrowOfDirect, ItemEnum.Potion.Heal, ItemEnum.TrollCleaver);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Sugartooth, "Card Handout")
                .BindCreatures(Creature.Horse).BindCharacters(CharacterEnum.BrendaCrimsonBlade)
                .ExtraInfo = "Grey Charger (Heavy War Horse)";

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BrotherSummer, "Card Handout")
                .BindCreatures(Creature.HalfOrc).BindRelatedCreatures(Creature.Horse, Creature.Orc).BindAlignment(Alignment.LN)
                .BindLanguages(Language.Common, Language.Orc, Language.DesertNomad)
                .BindItems(ItemEnum.IncenseOfMed, ItemEnum.PhylacteryOfFaith);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Muffin, "Card Handout")
                .BindCreatures(Creature.Horse).BindCharacters(CharacterEnum.BrotherSummer)
                .ExtraInfo = "Roan Clydesdale (Heavy Horse)";

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TGRedanto, "Card Handout")
                .BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Horse).BindAlignment(Alignment.TN)
                .BindLanguages(Language.Common, Language.Elf, Language.Halfling, Language.Orc, Language.Drow)
                .BindItems(ItemEnum.SwordOfLifeSteal, ItemEnum.Rope.Climb, ItemEnum.BracersOfDefense);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Apricot, "Card Handout")
                .BindCreatures(Creature.Horse).BindCharacters(CharacterEnum.TGRedanto)
                .ExtraInfo = "Brown Gelding (Light Horse)";

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MikhailYelkif, "Card Handout");

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Trellgaard, "Transpossession Rosters Handout").BindCreatures(Creature.Gargoyle);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MasterIlmen, "Transpossession Rosters Handout").BindCreatures(Creature.StrahdZombie);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CaareyGelthik, "Transpossession Rosters Handout").BindCreatures(Creature.Ghast);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.SeanTimothy, "Transpossession Rosters Handout").BindCreatures(Creature.Werewolf);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.JerimyEstmore, "Transpossession Rosters Handout").BindCreatures(Creature.Wight);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MasterTangle, "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.WrenThims, "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.SharonTeece, "Transpossession Rosters Handout").BindCreatures(Creature.GroaningSpirit);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MollyGrayswit, "Transpossession Rosters Handout").BindCreatures(Creature.Vampire);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Stelwaard, "Transpossession Rosters Handout").BindCreatures(Creature.Gargoyle);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ThinnBalder, "Transpossession Rosters Handout").BindCreatures(Creature.Zombie);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BadderGhastling, "Transpossession Rosters Handout").BindCreatures(Creature.Ghast);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EstherTimothy, "Transpossession Rosters Handout").BindCreatures(Creature.Werewolf);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GeamPelstap, "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MaquirLoft, "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MirandaLangstry, "Transpossession Rosters Handout").BindCreatures(Creature.GroaningSpirit);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KelmanOsterlaker, "Transpossession Rosters Handout").BindCreatures(Creature.Spectre);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.FionaMatheson, "Transpossession Rosters Handout").BindCreatures(Creature.Human);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Fanerath, "Transpossession Rosters Handout").BindCreatures(Creature.Gargoyle);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Hellinken, "Transpossession Rosters Handout").BindCreatures(Creature.Doppelganger);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KattleLisbury, "Transpossession Rosters Handout").BindCreatures(Creature.Wight);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EmoryMaus, "Transpossession Rosters Handout").BindCreatures(Creature.Wight);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MarcusLithe, "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.NendrumSintel, "Transpossession Rosters Handout").BindCreatures(Creature.Drelb);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ThellactinMianns, "Transpossession Rosters Handout").BindCreatures(Creature.Spectre);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.KellyDuncan, "Transpossession Rosters Handout").BindCreatures(Creature.GroaningSpirit);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CheldonIllcome, "Transpossession Rosters Handout").BindCreatures(Creature.Bodak);

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Mythrel, "Transpossession Rosters Handout").BindCreatures(Creature.Gargoyle);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MillicentHodgson, "Transpossession Rosters Handout").BindCreatures(Creature.Zombie);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.NatterlyKnutnor, "Transpossession Rosters Handout").BindCreatures(Creature.Ghast);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EowinTimothy, "Transpossession Rosters Handout").BindCreatures(Creature.Werewolf);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MomsinAlenny, "Transpossession Rosters Handout").BindCreatures(Creature.Wight);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ShingolTann, "Transpossession Rosters Handout").BindCreatures(Creature.Wraith);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LarsonChelf, "Transpossession Rosters Handout").BindCreatures(Creature.Drelb);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.YettergunFolie, "Transpossession Rosters Handout").BindCreatures(Creature.Spectre);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LeslieKale, "Transpossession Rosters Handout").BindCreatures(Creature.GroaningSpirit);
            #endregion

            #region Items
            DomainEnum.Mordent.AddItem(ItemEnum.Apparatus, "3, 4, 6, 8, 10, 14, 19, 26, 30-32, 34-41, 43-48, Adventure Plot")
                .BindDomains(DomainEnum.Barovia);
            DomainEnum.Mordent.AddItem(ItemEnum.Rod.Rastinon, "3, 4, 6, 8, 10, 17, 30, 40, 46, Adventure Plot")
                .BindDomains(DomainEnum.Barovia).BindItems(ItemEnum.Apparatus);
            DomainEnum.Mordent.AddItem(ItemEnum.SoulSearcher, "3, 6, 7, 10, 14, 46, Adventure Plot");
            DomainEnum.Mordent.AddItem(ItemEnum.Ring.Reverse, "3, 6, 7, 10, 14, 26, 46, Adventure Plot").BindAlignment(Alignment.NG);

            DomainEnum.Mordent.AddItem(ItemEnum.Book.AlchemistDiary, "7, 10, 41, 47, Adventure Plot").BindCharacters(DarklordEnum.CountStrahd);
            DomainEnum.Mordent.AddItem(ItemEnum.Book.MissingEntry, "3, 6, 10, 41, 47, Adventure Plot").BindCharacters(DarklordEnum.CountStrahd)
                .BindItems(ItemEnum.Book.AlchemistDiary).ExtraInfo = "Missing entry/entries of the Alchemist`s Diary.";

            DomainEnum.Mordent.AddItem(ItemEnum.Sunsword, "12, 41").BindDomains(DomainEnum.Barovia);
            DomainEnum.Mordent.AddItem(ItemEnum.IconOfRaven, "12").BindDomains(DomainEnum.Barovia);

            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.NegPlaneProt, "25");
            DomainEnum.Mordent.AddItem(ItemEnum.LocketOfSealing, "25");

            DomainEnum.Mordent.AddItem(ItemEnum.Potion.Climb, "25");
            DomainEnum.Mordent.AddItem(ItemEnum.Potion.ExtraHeal, "25");
            DomainEnum.Mordent.AddItem(ItemEnum.Potion.Speed, "25");
            DomainEnum.Mordent.AddItem(ItemEnum.Potion.SuperHero, "25");

            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.HolySymbol, "25");
            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.InvisToUndead, "25");
            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.ProtEvil, "25");
            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.Restore, "25");

            DomainEnum.Mordent.AddItem(ItemEnum.Potion.ClairAud, "26");
            DomainEnum.Mordent.AddItem(ItemEnum.Potion.Dim, "26");
            DomainEnum.Mordent.AddItem(ItemEnum.Elixir.Mad, "26");
            DomainEnum.Mordent.AddItem(ItemEnum.MirrorOfLaw, "26").BindAlignment(Alignment.LG | Alignment.LN | Alignment.LE)
                .ExtraInfo = "The mirror doesn't have a name in the module, this is a placeholder title.";

            DomainEnum.Mordent.AddItem(ItemEnum.Book.TheInnerSoul, "29").ExtraInfo = "Mundane Book";
            DomainEnum.Mordent.AddItem(ItemEnum.IncenseOfMed, "30, Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.Book.THENATUREOFTHESOUL, "34").ExtraInfo = "Mundane Book";

            DomainEnum.Mordent.AddItem(ItemEnum.SunBlade, "39");
            DomainEnum.Mordent.AddItem(ItemEnum.SwordOfWound, "42");
            DomainEnum.Mordent.AddItem(ItemEnum.Ring.DetGood, "42");
            DomainEnum.Mordent.AddItem(ItemEnum.Rope.Entangle, "42");
            DomainEnum.Mordent.AddItem(ItemEnum.MedallionOfProt, "42");

            DomainEnum.Mordent.AddItem(ItemEnum.FlashGrenade, "44");
            DomainEnum.Mordent.AddItem(ItemEnum.Cloak.Prot, "44");
            DomainEnum.Mordent.AddItem(ItemEnum.Ring.Regen, "44");
            DomainEnum.Mordent.AddItem(ItemEnum.GemOfLight, "44");
            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.Storing, "44");

            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.ProtUnd, "44");
            DomainEnum.Mordent.AddItem(ItemEnum.Brooch.ProtGood, "44");
            DomainEnum.Mordent.AddItem(ItemEnum.Ring.ProtNM, "44");

            DomainEnum.Mordent.AddItem(ItemEnum.Ring.Aim, "45");
            DomainEnum.Mordent.AddItem(ItemEnum.Potion.Heal, "45, Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.Cloak.Disp, "45, Card Handout");

            DomainEnum.Mordent.AddItem(ItemEnum.Ring.Prot, "45, Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.Elixir.Health, "45");
            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.Calling, "45");
            DomainEnum.Mordent.AddItem(ItemEnum.BracersOfDefense, "45, Card Handout");

            DomainEnum.Mordent.AddItem(ItemEnum.DartOfHoming, "45");
            DomainEnum.Mordent.AddItem(ItemEnum.DaggerOfVenom, "45");
            DomainEnum.Mordent.AddItem(ItemEnum.Staff.ThunderAndLightning, "45");
            DomainEnum.Mordent.AddItem(ItemEnum.PowderOfHaste, "45");
            DomainEnum.Mordent.AddItem(ItemEnum.Elixir.Displace, "45");
            DomainEnum.Mordent.AddItem(ItemEnum.Potion.CSNW, "45");

            DomainEnum.Mordent.AddItem(ItemEnum.Rod.Flail, "Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.ProtWnS, "Card Handout").BindCreatures(Creature.Wraith, Creature.Spectre);

            DomainEnum.Mordent.AddItem(ItemEnum.Staff.Strike, "Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.AlchemyJug, "Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.StoneOfControlEarth, "Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.ProtDev, "Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.ProtDem, "Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.Scroll.ProtPet, "Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.Ring.WaterWalk, "Card Handout");

            DomainEnum.Mordent.AddItem(ItemEnum.DragonSlayer, "Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.HornOfValhalla, "Card Handout");

            DomainEnum.Mordent.AddItem(ItemEnum.ArrowOfDirect, "Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.TrollCleaver, "Card Handout");

            DomainEnum.Mordent.AddItem(ItemEnum.PhylacteryOfFaith, "Card Handout");

            DomainEnum.Mordent.AddItem(ItemEnum.SwordOfLifeSteal, "Card Handout");
            DomainEnum.Mordent.AddItem(ItemEnum.Rope.Climb, "Card Handout");

            DomainEnum.Mordent.AddItem(ItemEnum.Scarab.Prot, "Card Handout");
            #endregion

            #region Groups
            DomainEnum.Mordent.AddGroup(GroupEnum.HighFaithOsterton, "10, Card Handout").BindDomains(DomainEnum.OutsideRavenloft)
                .BindCharacters(CharacterEnum.ThadeusMontBreezar, CharacterEnum.RogoldGildenman, CharacterEnum.AmarBoriSandflinger, CharacterEnum.PhillipeDelamana, CharacterEnum.BrotherSummer, CharacterEnum.BrendaCrimsonBlade, CharacterEnum.MystiTokana, CharacterEnum.TGRedanto);
            #endregion

            Settlement.Mordentshire.PopulateSettlement(LocationEnum.SaulbridgeSanitarium, LocationEnum.GryphonHill, LocationEnum.GryphonHillMansion, LocationEnum.BlackardInn, LocationEnum.Livery, LocationEnum.Garrison, LocationEnum.BurnedChurch, LocationEnum.Smithy, LocationEnum.MayorsHouse, LocationEnum.KervilsShop, LocationEnum.Marketplace, LocationEnum.Warehouse, LocationEnum.SouthRoad, LocationEnum.KeeldevilPoint, LocationEnum.FishermanAlley, LocationEnum.ShippingHouse, LocationEnum.SeventhSea, LocationEnum.TravelersInn, LocationEnum.AnchorStreet, LocationEnum.ShoreLane, LocationEnum.MillRoad, LocationEnum.MillBridge, LocationEnum.ArdenRiver, LocationEnum.OldMill, LocationEnum.Churchyard, LocationEnum.OldSaltHouse, LocationEnum.SaltyDogTavern, LocationEnum.Butcher, LocationEnum.Bakery, LocationEnum.Groundskeeper, LocationEnum.OldBooks, LocationEnum.Wharf, LocationEnum.Farms, LocationEnum.ArdentBay, LocationEnum.WindwandAvenue, LocationEnum.GlenRoad, LocationEnum.MarketStreet, LocationEnum.Barracks, LocationEnum.Gaol, LocationEnum.HeatherWay, LocationEnum.MaddingRoad, LocationEnum.Backwater, LocationEnum.ButcherLane, LocationEnum.WoodHollow, LocationEnum.Cliffedge, LocationEnum.Scrimshaw);

            LocationEnum.Moors.PopulateSettlement(LocationEnum.NorthRoad, LocationEnum.NorthMoors, LocationEnum.Cliffs, LocationEnum.SouthRoad, LocationEnum.DarkWoods, LocationEnum.HeatherHouse, LocationEnum.WeathermayMausoleum, LocationEnum.HiddenTrack, LocationEnum.GryphonRoad, LocationEnum.Bog, LocationEnum.MordentshireCemetery, LocationEnum.HeatherHousePoint, LocationEnum.Heatherwood, LocationEnum.HeatherRoad);

            Settlement.Mordentshire.PopulateSettlement(LocationEnum.Moors.Locations);
        }
    }
}