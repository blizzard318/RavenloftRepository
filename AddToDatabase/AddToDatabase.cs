using static Factory;

internal static partial class AddToDatabase
{
    public static void Add0 () 
    {
        //Domains, Characters, Items and Locations are Source-locked, but not Traits.
        //Consider not making new instances within Create, so that adding can be better structured.
        AddI6Ravenloft();
        AddI10TheHouseOnGryphonHill();
        AddRealmOfTerror();

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
                                CharacterEnum.Bildrath, CharacterEnum.Parriwimple)
                .BindLocations(LocationEnum.BildrathMercantile, LocationEnum.BloodVineTavern, LocationEnum.MaryHouse, LocationEnum.BurgomasterHome, LocationEnum.BurgomasterGuestHouse, LocationEnum.BaroviaChurch, LocationEnum.BaroviaChurch);
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

            DomainEnum.Barovia.AddSettlement(Settlement.TserPoolEncampnent, "11").BindLocations(LocationEnum.TserPool, LocationEnum.MadamEvasTent);
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
                .BindItems(ItemEnum.Apparatus, ItemEnum.Rod.Rastinon, ItemEnum.SoulSearcher, ItemEnum.Ring.Reverse, ItemEnum.Book.AlchemistDiary, ItemEnum.Book.MissingEntry, ItemEnum.Sunsword, ItemEnum.Scroll.NegPlaneProt, ItemEnum.LocketOfSealing, ItemEnum.Potion.Climb, ItemEnum.Potion.ExtraHeal, ItemEnum.Potion.Speed, ItemEnum.Potion.SuperHero, ItemEnum.Scroll.HolySymbol, ItemEnum.Scroll.InvisToUndead, ItemEnum.Scroll.ProtEvil, ItemEnum.Scroll.Restore, ItemEnum.Potion.ClairAud, ItemEnum.Potion.Dim, ItemEnum.Elixir.Mad, ItemEnum.MirrorOfLaw, ItemEnum.Book.TheInnerSoul, ItemEnum.IncenseOfMed, ItemEnum.Book.THENATUREOFTHESOUL, ItemEnum.SunBlade, ItemEnum.SwordOfWound, ItemEnum.Ring.DetGood, ItemEnum.Rope.Entangle, ItemEnum.MedallionOfProt, ItemEnum.FlashGrenade, ItemEnum.Cloak.Prot, ItemEnum.Ring.Regen, ItemEnum.GemOfLight, ItemEnum.Scroll.Storing, ItemEnum.Scroll.ProtUnd, ItemEnum.Brooch.ProtGood, ItemEnum.Ring.ProtNM, ItemEnum.Ring.Aim, ItemEnum.Potion.Heal, ItemEnum.Cloak.Disp, ItemEnum.Ring.Prot, ItemEnum.Elixir.Health, ItemEnum.Scroll.Calling, ItemEnum.BracersOfDefense, ItemEnum.DartOfHoming, ItemEnum.DaggerOfVenom, ItemEnum.Staff.ThunderAndLightning, ItemEnum.PowderOfHaste, ItemEnum.Elixir.Displace, ItemEnum.Potion.CSNW, ItemEnum.Rod.Flail, ItemEnum.Scroll.ProtWnS, ItemEnum.Staff.Strike, ItemEnum.AlchemyJug, ItemEnum.StoneOfControlEarth, ItemEnum.Scroll.ProtDev, ItemEnum.Scroll.ProtDem, ItemEnum.Scroll.ProtPet, ItemEnum.Ring.WaterWalk, ItemEnum.DragonSlayer, ItemEnum.HornOfValhalla, ItemEnum.ArrowOfDirect, ItemEnum.TrollCleaver, ItemEnum.PhylacteryOfFaith, ItemEnum.SwordOfLifeSteal, ItemEnum.Rope.Climb, ItemEnum.Scarab.Prot)
                .BindLocations(LocationEnum.SaulbridgeSanitarium, LocationEnum.GryphonHill, LocationEnum.GryphonHillMansion, LocationEnum.BlackardInn, LocationEnum.Livery, LocationEnum.Garrison, LocationEnum.BurnedChurch, LocationEnum.Smithy, LocationEnum.MayorsHouse, LocationEnum.KervilsShop, LocationEnum.Marketplace, LocationEnum.Warehouse, LocationEnum.SouthRoad, LocationEnum.KeeldevilPoint, LocationEnum.FishermanAlley, LocationEnum.ShippingHouse, LocationEnum.SeventhSea, LocationEnum.TravelersInn, LocationEnum.AnchorStreet, LocationEnum.ShoreLane, LocationEnum.MillRoad, LocationEnum.MillBridge, LocationEnum.RiverArden, LocationEnum.OldMill, LocationEnum.Churchyard, LocationEnum.OldSaltHouse, LocationEnum.SaltyDogTavern, LocationEnum.Butcher, LocationEnum.Bakery, LocationEnum.Groundskeeper, LocationEnum.OldBooks, LocationEnum.Wharf, LocationEnum.Farms, LocationEnum.ArdentBay, LocationEnum.WindwandAvenue, LocationEnum.GlenRoad, LocationEnum.MarketStreet, LocationEnum.Barracks, LocationEnum.Gaol, LocationEnum.HeatherWay, LocationEnum.MaddingRoad, LocationEnum.Backwater, LocationEnum.ButcherLane, LocationEnum.WoodHollow, LocationEnum.Cliffedge, LocationEnum.Scrimshaw).BindLocations(LocationEnum.Moors.Locations);

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
                .BindCreatures(Creature.GiantToad, Creature.Stirge, Creature.GreenSlime, Creature.Vampire, Creature.InvisibleStalker, Creature.Haunt, Creature.Shade, Creature.GroaningSpirit, Creature.Banshee, Creature.Horse, Creature.SkeletonSteed, Creature.Maggot, Creature.StrahdZombie, Creature.StoneGolem, Creature.Gargoyle, Creature.Raven, Creature.Doppelganger, Creature.StrahdSkeleton, Creature.ShadowMastiff, Creature.Trapper)
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
            DomainEnum.Mordent.AddLocation(LocationEnum.RiverArden, "21, 25, Map");
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
            DomainEnum.Mordent.AddLocation(LocationEnum.Moors, "1, 3, 12, 16, 23-26, 43").BindCharacters(CharacterEnum.Marston)
                .BindCreatures(Creature.Human, Creature.StrahdZombie, Creature.Griffon, Creature.Harpy, Creature.Hellhound, Creature.Orc, Creature.Ogre, Creature.QuasiElementalLightning, Creature.Raven, Creature.GiantSpider, Creature.Stirge, Creature.Vulture, Creature.DireWolf, Creature.Bodak, Creature.Ghast, Creature.GroaningSpirit, Creature.ShadowMastiff, Creature.Nightmare, Creature.Skeleton, Creature.SkeletonSteed, Creature.Wraith, Creature.WillOWisp, Creature.CrimsonDeath, Creature.Doppelganger, Creature.DisplacerBeast, Creature.StrahdSkeleton)
                .BindLocations(LocationEnum.NorthRoad, LocationEnum.NorthMoors, LocationEnum.Cliffs, LocationEnum.SouthRoad, LocationEnum.DarkWoods, LocationEnum.HeatherHouse, LocationEnum.WeathermayMausoleum, LocationEnum.HiddenTrack, LocationEnum.GryphonRoad, LocationEnum.Bog, LocationEnum.MordentshireCemetery, LocationEnum.HeatherHousePoint, LocationEnum.Heatherwood, LocationEnum.HeatherRoad);
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

            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TheCreature)
                .BindAlignment(Alignment.CE).BindCharacters(DarklordEnum.CountStrahd)
                .BindCreatures(Creature.Human, Creature.Vampire, Creature.Bat, Creature.Wolf)
                .BindRelatedCreatures(Creature.Banshee, Creature.StrahdZombie, Creature.StrahdSkeleton, Creature.DireWolf, Creature.Hellhound, Creature.ShadowMastiff, Creature.Raven, Creature.VampireBat, Creature.Rat, Creature.Bat, Creature.Quasit, Creature.Werewolf, Creature.Harpy, Creature.Ogre, Creature.Vulture, Creature.Nightmare, Creature.BlackCat, Creature.StrahdSteed)
                .BindItems(ItemEnum.SwordOfWound, ItemEnum.Ring.DetGood, ItemEnum.Rope.Entangle, ItemEnum.MedallionOfProt, ItemEnum.FlashGrenade, ItemEnum.Cloak.Prot, ItemEnum.Ring.Regen, ItemEnum.GemOfLight, ItemEnum.Scroll.Storing)
                .ExtraInfo = "Evil aspect of Count Strahd.";
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.TheAlchemist)
                .BindAlignment(Alignment.NG).BindCharacters(DarklordEnum.CountStrahd)
                .BindCreatures(Creature.Human, Creature.Vampire, Creature.Bat, Creature.Wolf)
                .BindRelatedCreatures(Creature.Banshee, Creature.StrahdZombie, Creature.StrahdSkeleton, Creature.DireWolf, Creature.Hellhound, Creature.ShadowMastiff, Creature.Raven, Creature.VampireBat, Creature.Rat, Creature.Bat, Creature.Quasit, Creature.Werewolf, Creature.Harpy, Creature.Ogre, Creature.Vulture, Creature.Nightmare, Creature.BlackCat, Creature.StrahdSteed)
                .BindItems(ItemEnum.SwordOfWound, ItemEnum.Ring.DetGood, ItemEnum.Rope.Entangle, ItemEnum.MedallionOfProt, ItemEnum.FlashGrenade, ItemEnum.Cloak.Prot, ItemEnum.Ring.Regen, ItemEnum.GemOfLight, ItemEnum.Scroll.Storing)
                .ExtraInfo = "Good aspect of Count Strahd.";

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
        }
        void AddRealmOfTerror()
        {
            var releaseDate = "01/06/1990";
            string ExtraInfo = "<br/>&emsp;Authors: Bruce Nesmith with Andria Hayday";
            ExtraInfo += "<br/>&emsp;Game Design: Bruce Nesmith";
            ExtraInfo += "<br/>&emsp;'Ghost' Writing & Additional Design: Andria Hayday";
            ExtraInfo += "<br/>&emsp;Cover Art: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Interior Artist: Stephen Fabian";
            ExtraInfo += "<br/>&emsp;Cartographer & Architectural Drawings: David C. Sutherland III (supervisor/designer, artist)";
            ExtraInfo += "<br/>&emsp;Graphic Design: Roy E. Parker";
            ExtraInfo += "<br/>&emsp;Production: Paul Hanchette, Sara Feggestad";
            ExtraInfo += "<br/>&emsp;Typesetting: Angelika Lokotz";
            using var ctx = CreateSource("Realm of Terror", releaseDate, ExtraInfo, Edition.e2, Media.sourcebook);

            #region Domains
            ClusterEnum.PreGCCore.TrackCluster("2, 4, 12, 60, 62-63, 65, 67, 69, 72, 76, 79-80",
                DomainEnum.Arak          .Appeared("2, 9, 61-63").BindCreatures(Creature.Drow, Creature.Spider,Creature.Drider, Creature.Hellhound, Creature.Ettercap),

                DomainEnum.Arkandale     .Appeared("2, 9, 62-63, 73, 89, 111-112, 115").BindCreatures(Creature.Wolf, Creature.Weasel, Creature.Werewolf, Creature.Rat, Creature.Snake, Creature.Spider, Creature.Goblin, Creature.WillOWisp),

                DomainEnum.Barovia       .Appeared("2, 8-9, 12, 14, 35-36, 60, 62-66, 68, 70, 72, 91, 94, 100, 102-103, 109, 116-117, 1421-43").BindGroups(GroupEnum.Vistani).BindLanguages(Language.Balok).BindCreatures(Creature.Wolf, Creature.Vampire, Creature.Deer, Creature.Rabbit, Creature.Rat, Creature.Bear, Creature.Raven, Creature.Hawk, Creature.Songbird, Creature.Owl, Creature.Bat, Creature.StrahdSkeleton, Creature.StrahdZombie, Creature.Skeleton, Creature.Zombie, Creature.Worg, Creature.CrawlingClaw, Creature.Cloaker, Creature.Hellhound, Creature.InvisibleStalker, Creature.Jackalwere, Creature.Werewolf, Creature.WillOWisp, Creature.Snake, Creature.Chipmunk, Creature. Ferret, Creature.Fox, Creature.Hedgehog, Creature.Monkey, Creature.Opossum, Creature.Pig, Creature.Rabbit, Creature.Raccoon, Creature.Squirrel, Creature.Woodchuck),

                DomainEnum.Bluetspur     .Appeared("2, 9, 60, 62, 65, 72-73").BindCreatures(Creature.Illithid),

                DomainEnum.Borca         .Appeared("2, 9, 62, 66, 68-69, 96, 121").BindCreatures(Creature.Bat, Creature.Rat, Creature.Snake, Creature.Spider, Creature.Wolf, Creature.Bear, Creature.Boar, Creature.Ghost, Creature.Haunt, Creature.Poltergeist, Creature.Werewolf, Creature.WillOWisp),

                DomainEnum.Darkon        .Appeared("2, 9, 60-62, 67-69, 75, 90-92, 96, 113-114, 117").BindGroups(GroupEnum.Vistani).BindCreatures(Creature.Bat, Creature.Goblin, Creature.Kobold, Creature.Jermlaine, Creature.Snake, Creature.Spider, Creature.Wolf, Creature.Doppelganger, Creature.Griffon, Creature.Hippogriff, Creature.Imp, Creature.InvisibleStalker, Creature.Werewolf, Creature.Drow, Creature.Leucrotta, Creature.ShamblingMound, Creature.Hag),

                DomainEnum.Dementlieu    .Appeared("2, 9, 62, 68-69, 75, 93, 96, 122").BindCreatures(Creature.Snake, Creature.Spider, Creature.Deer, Creature.Kobold, Creature.Sahuagin, Creature.Doppelganger, Creature.Goblin, Creature.Kelpie, Creature.Boar),

                DomainEnum.Dorvinia      .Appeared("2, 9, 62, 68-69, 93-94, 96").BindCreatures(Creature.Bat, Creature.Rat, Creature.Snake, Creature.Spider, Creature.Boar, Creature.Bear, Creature.GreatCat, Creature.Ghost, Creature.Haunt, Creature.Poltergeist, Creature.Werewolf, Creature.WillOWisp),

                DomainEnum.Falkovnia     .Appeared("2, 9, 62, 67-70, 75, 89, 95-96, 111").BindCreatures(Creature.Hawk, Creature.Boar, Creature.Wolf, Creature.Griffon, Creature.Deer, Creature.Hippogriff, Creature.Kobold, Creature.Jermlaine, Creature.Werewolf, Creature.Satyr, Creature.WillOWisp, Creature.Bear),

                DomainEnum.Forlorn       .Appeared("2, 9, 62, 72").BindCreatures(Creature.Wolf),

                DomainEnum.GHenna        .Appeared("2, 9, 62, 69-71, 96, 109-110").BindCreatures(Creature.Human, Creature.Mongrelman, Creature.GreatCat, Creature.Bat, Creature.Snake, Creature.Kobold, Creature.Werewolf, Creature.Wolf, Creature.Ghoul),

                DomainEnum.Gundarak      .Appeared("2, 9, 62, 71-73").BindCreatures(Creature.Rat, Creature.Bat, Creature.Wolf, Creature.Spider, Creature.Werewolf, Creature.Kobold),

                DomainEnum.Hazlan        .Appeared("2, 9, 60, 62, 72-73, 99-100").BindCreatures(Creature.Bat, Creature.Wolf, Creature.Deer, Creature.Snake, Creature.Berbalang, Creature.Darkenbeast, Creature.CrimsonDeath, Creature.Imp, Creature.Leucrotta, Creature.Mongrelman),

                DomainEnum.Invidia       .Appeared("2, 9, 62, 72-73, 89").BindGroups(GroupEnum.Vistani).BindCreatures(Creature.Wolf, Creature.Deer, Creature.Snake, Creature.Wolfwere, Creature.WillOWisp, Creature.Jermlaine),

                DomainEnum.Kartakass     .Appeared("2, 9, 62, 66, 70, 73-74, 101-102").BindCreatures(Creature.Horse, Creature.Wolf, Creature.DireWolf, Creature.Werewolf, Creature.Wolfwere, Creature.WinterWolf, Creature.Kobold, Creature.Boar, Creature.Wight, Creature.Ghoul, Creature.Goblin, Creature.Leucrotta, Creature.Werefox),

                DomainEnum.Keening       .Appeared("2, 9, 62, 74-75, 79").BindCreatures(Creature.Banshee, Creature.Zombie, Creature.Wight),
                DomainEnum.Lamordia      .Appeared("2, 62, 69, 75-76, 96, 105-109").BindCreatures(Creature.Seabird, Creature.Sheep, Creature.Goat, Creature.FleshGolem, Creature.Wolf, Creature.Caribou, Creature.GiantWeasel, Creature.Boar, Creature.Moose, Creature.Bear, Creature.Seawolf, Creature.GiantLynx),
                DomainEnum.Markovia      .Appeared("2, 9, 62, 76, 78, 102-103").BindGroups(GroupEnum.Vistani, GroupEnum.Diosamblet).BindCreatures(Creature.BeastMen, Creature.Wolf, Creature.Spider, Creature.Snake, Creature.MountainLion, Creature.Bear, Creature.Boar, Creature.Deer),

                DomainEnum.Mordent       .Appeared("2, 9, 62, 69, 76-77, 93, 97-98, 117").BindCharacters(DarklordEnum.CountStrahd).BindItems(ItemEnum.Apparatus).BindGroups(GroupEnum.Vistani).BindCreatures(Creature.Human, Creature.Ghost),

                DomainEnum.NightmareLands.Appeared("2, 60-62, 72, 77-78"),
                DomainEnum.NovaVaasa     .Appeared("2, 9, 36, 60-62, 78").BindCreatures(Creature.Horse, Creature.Snake, Creature.PlainsCat, Creature.Wolf, Creature.Werewolf, Creature.Jermlaine),
                DomainEnum.Sithicus      .Appeared("2, 9, 62, 73, 78-79").BindCreatures(Creature.Elf, Creature.GroaningSpirit, Creature.Banshee, Creature.Deer, Creature.Snake, Creature.Werewolf, Creature.Wolf),
                DomainEnum.Tepest        .Appeared("2, 9, 60-62, 79-80").BindGroups(GroupEnum.HagsOfTepest).BindCreatures(Creature.Bear, Creature.Pig, Creature.Sturgeon, Creature.Goblin, Creature.Deer, Creature.Wolf, Creature.Snake, Creature.Kelpie, Creature.Bear),

                DomainEnum.Richemulot    .Appeared("2, 9, 62, 69, 80, 96, 110-111").BindGroups(GroupEnum.Vistani).BindCreatures(Creature.GiantRat, Creature.Rat, Creature.Goblin, Creature.Wererat, Creature.Snake, Creature.Spider, Creature.Skeleton, Creature.Zombie, Creature.Wight, Creature.Berbalang, Creature.Cloaker, Creature.Werewolf),

                DomainEnum.Valachan      .Appeared("2, 9, 60, 62, 79-81").BindCreatures(Creature.Deer, Creature.Moose, Creature.Boar, Creature.Marten, Creature.Eagle, Creature.Raven, Creature.Bear, Creature.Panther, Creature.Bat, Creature.Spider),
                DomainEnum.Verbrek       .Appeared("2, 9, 62, 73, 81, 111-112").BindGroups(GroupEnum.Vistani).BindCreatures(Creature.Wolf, Creature.Werewolf, Creature.Ghost, Creature.Spectre, Creature.Geist),
                DomainEnum.SeaOfSorrows  .Appeared("60, 62, 67-68, 75, 77")
            );
            ClusterEnum.IslandsOfTerror.TrackCluster("3-4, 12, 82-83",
                DomainEnum.Farelle       .Appeared("3, 83").BindCreatures(Creature.Dog, Creature.Jackal, Creature.Jackalwere, Creature.Deer, Creature.Werewolf, Creature.Boar),
                DomainEnum.HarAkir       .Appeared("3, 83-84").BindCreatures(Creature.AntLion, Creature.Sandling, Creature.Jackal, Creature.Scorpion, Creature.Leopard, Creature.Lion, Creature.Snake),
                DomainEnum.Sanguinia     .Appeared("3, 84").BindCreatures(Creature.BighornSheep, Creature.MountainGoat, Creature.Goblin, Creature.Owl, Creature.Deer, Creature.Elk, Creature.WinterWolf, Creature.Werewolf, Creature.Bear),
                DomainEnum.Souragne      .Appeared("3, 84-85").BindCreatures(Creature.Skeleton, Creature.Zombie, Creature.Crocodile, Creature.Snake, Creature.Leech, Creature.Lizard, Creature.Frog, Creature.Toad, Creature.ShamblingMound, Creature.WillOWisp),
                DomainEnum.SriRaji       .Appeared("3, 85").BindCreatures(Creature.Spider, Creature.Snake, Creature.Monkey, Creature.Naga, Creature.ManEatingPlant, Creature.Elephant, Creature.Tiger, Creature.Weretiger),
                DomainEnum.StauntonBluffs.Appeared("3, 85").BindCreatures(Creature.Human, Creature.Ghost, Creature.Wolf, Creature.Boar, Creature.Deer, Creature.Werewolf),
                DomainEnum.Vechor        .Appeared("3, 86"),
                DomainEnum.Paridon       .Appeared("3, 86")
                );
            DomainEnum.InsideRavenloft.BindCreatures(Creature.Vampire, Creature.Geist, Creature.Gremishka, Creature.Werewolf, Creature.Wolf, Creature.LoupGarou, Creature.Odem, Creature.StrahdSkeleton, Creature.StrahdZombie, Creature.Nosferatu, Creature.Skeleton, Creature.Zombie, Creature.Ghoul, Creature.Shadow, Creature.Wight, Creature.Ghast, Creature.Wraith, Creature.Mummy, Creature.Spectre, Creature.Ghost, Creature.Lich, Creature.Human, Creature.Dwarf, Creature.Halfling, Creature.Elf, Creature.Werefox, Creature.Fox, Creature.Rat, Creature.Wererat, Creature.Werebear, Creature.Bear, Creature.Hellhound, Creature.Rabbit, Creature.Snake, Creature.Chipmunk, Creature.Ferret, Creature.Hedgehog, Creature.Monkey, Creature.Opossum, Creature.Pig, Creature.Raccoon, Creature.Squirrel, Creature.Woodchuck, Creature.GreaterGeist, Creature.MountainLoupGarou, Creature.LowlandLoupGarou, Creature.AerialServant, Creature.UndeadBeast, Creature.BeastMen, Creature.Berbalang, Creature.CrawlingClaw, Creature.Cloaker, Creature.CryptThing, Creature.Darkenbeast, Creature.CrimsonDeath, Creature.Disir, Creature.ShadowDragon, Creature.Dreamshadow, Creature.Dreamwraith, Creature.Fetch, Creature.Goblin, Creature.Gremlin, Creature.Griffon, Creature.GroaningSpirit, Creature.GurikChaahl, Creature.Hag, Creature.Haunt, Creature.KnightHaunt, Creature.Heucuva, Creature.Hippogriff, Creature.Hobgoblin, Creature.NorkerHobgoblin, Creature.Homunculus, Creature.YethHound, Creature.Imp, Creature.BloodSeaImp, Creature.InvisibleStalker, Creature.Jackalwere, Creature.Jermlaine, Creature.KaniDoll, Creature.Kelpie, Creature.DeathKnight, Creature.Kobold, Creature.SonOfKyuss, Creature.Leucrotta, Creature.Lich, Creature.MindFlayer, Creature.VampiricMist, Creature.Mite, Creature.Mummy, Creature.Naga, Creature.Necrophidius, Creature.Pegasus, Creature.Poltergeist, Creature.Rakshasa, Creature.Raven, Creature.Revenant, Creature.Sahuagin, Creature.Satyr, Creature.Scarecrow, Creature.SlowShadow, Creature.ShamblingMound, Creature.SpectralMinion, Creature.Spider, Creature.Unicorn, Creature.WarriorSkeleton, Creature.Wichtlin, Creature.WillOWisp, Creature.MistWolf, Creature.Wolfwere, Creature.Yaggol, Creature.SeaZombie, Creature.YellowMuskCreeper, Creature.YellowMuskZombie, Creature.Lacedeon, Creature.JujuZombie, Creature.Swordwraith, Creature.SoulBeckoner);
            Creature.LowlandLoupGarou.BindCreatures(Creature.Worg);
            Creature.MountainLoupGarou.BindCreatures(Creature.DireWolf);
            Creature.Gremishka.BindCreatures(Creature.Gremlin);
            Creature.GurikChaahl.BindCreatures(Creature.Goblin);
            Creature.Hobgoblin.BindCreatures(Creature.NorkerHobgoblin);
            Creature.Yaggol.BindCreatures(Creature.MindFlayer);
            Creature.YellowMuskCreeper.BindCreatures(Creature.YellowMuskZombie);
            Creature.Wraith.BindCreatures(Creature.Swordwraith, Creature.SoulBeckoner);
            DomainEnum.Barovia.Inspirations.UnionWith(new[] 
            {
                "<i>Dracula</i> by Bram Stoker",
                "<i>Dracula's Guest</i> by Bram Stoker",
                "<i>Carmilla</i> by J. Sheridan Le Fanu",
                "<i>The Vampire</i> by John Polidori",
                "<i>Fragment of a Novel</i> by Lord George Byron"
            });
            DomainEnum.Lamordia.Inspirations.Add("<i>Frankenstein</i> by Mary Shelley");
            DomainEnum.Mordent.Inspirations.Add("<i>The Haunting of Hill House</i> by Shirley Jackson");
            DomainEnum.StauntonBluffs.Inspirations.Add("<i>The Haunting of Hill House</i> by Shirley Jackson");
            DomainEnum.Markovia.Inspirations.Add("<i>The Island of Dr. Moreau</i> by H.G. Wells");
            DomainEnum.NovaVaasa.Inspirations.Add("<i>The Strange Case of Dr. Jekyll and Mr. Hyde</i> by Robert Lewis Stevenson");
            #endregion

            #region Darklords
            DomainEnum.Arkandale.AddLivingDarklord(DarklordEnum.NathanTimothy, "3, 112-113").BindAlignment(Alignment.CE).BindDomains(DomainEnum.Mordent).BindCreatures(Creature.Werewolf, Creature.DireWolf).BindCloseBorder("A wall of dense vegetation 50 feet thick forms at the borders. It grows over and through the waterways. The green wall turns blades aside, and fire cannot burn it.");

            DarklordEnum.Gwydion.BindCloseBorder("When the land is sealed, unscalable slabs of granite rise like monoliths at the borders. A savage wind screams through the crannies in the rock. The wind forces travelers bakc into the domain and prevents any kind of flight.");
            DarklordEnum.GodBrain.BindCloseBorder("Rumored to be sealed with rock.");

            DomainEnum.Borca     .AddDeadDarklord  (DarklordEnum.CamilleDilisnya , "66, 94, 121").BindCharacters(DarklordEnum.IvanaBoritsi, CharacterEnum.LevDilisnya, CharacterEnum.AnnaKurdzeil);
            DomainEnum.Borca     .AddLivingDarklord(DarklordEnum.IvanaBoritsi    , "66, 68, 94, 121").BindCloseBorder("When someone leaves Borca, any drinks whilst within Borca turns into lethal poison, making victims immediately feverish, woozy and will die in a few turns unless he reenters the domain.").BindLair(LocationEnum.BoritsiEstate);

            DomainEnum.Darkon.AddLivingDarklord(DarklordEnum.AzalinRex, "3, 9, 67-68, 90-93, 96, 117").BindAlignment(Alignment.LE).BindCreatures(Creature.Human, Creature.Lich).BindRelatedCreatures(Creature.Vampire, Creature.Drow).BindItems(ItemEnum.Ring.Wizard, ItemEnum.Wand.Frost, ItemEnum.HelmCompreLng, ItemEnum.AzalinPhylactery).BindDomains(DomainEnum.Barovia, DomainEnum.Mordent).BindCharacters(DarklordEnum.CountStrahd).BindCloseBorder("A wall of undead, 20 creatures deep, masses at the border.").BindCurse("He can never rise above the experience level he now holds. And he can never learn more magic than he now knows. Even if presented with a scroll and tutored in the use of new spells upon it, he cannot learn them. Magical information - even that not related to spells - seems to slip through his mind like dust through a net.").BindLair(LocationEnum.AzalinCastle);

            DomainEnum.Dementlieu.AddLivingDarklord(DarklordEnum.DominicdHonaire, "3, 68, 93").BindAlignment(Alignment.NE).BindDomains(DomainEnum.Mordent).BindCharacters(CharacterEnum.Germain, CharacterEnum.Claude).BindCloseBorder("A mirage where a character sees the land of Dementlieu before and behind him. No matter which way he walks, he moves farther into the domain.").BindCurse("The more romantically attracted he becomes to a woman, the uglier she finds him. To others, his appearances is unchanged. To her, he becomes repulsive. The curse makes him bitter and frustrated.");

            DomainEnum.Dorvinia.AddLivingDarklord(DarklordEnum.IvanDilisnya, "3, 68, 93-95").BindAlignment(Alignment.CE).BindCreatures(Creature.Human).BindDomains(DomainEnum.Borca).BindCharacters(CharacterEnum.BorisDilisnya, CharacterEnum.NataliaOlszanik).BindCloseBorder("When someone leaves Dorvinia, any drinks whilst within Dorvinia turns into lethal poison, making victims immediately feverish, woozy and will die in a few turns unless he reenters the domain.").BindCurse("Ivan lost his sense of taste. Now to him, all drinks are like bile, all foods are like dust. He feels the loss keenly, and would sacrifice anyone and virtually anything to regain his palate.").BindLair(LocationEnum.DilisnyaEstate);

            DomainEnum.Falkovnia .AddLivingDarklord(DarklordEnum.VladDrakov      , "3, 9, 69-70, 95-96, 111").BindAlignment(Alignment.NE).BindRelatedCreatures(Creature.Hawk).BindDomains(DomainEnum.Darkon, DomainEnum.Lamordia, DomainEnum.Dementlieu, DomainEnum.Richemulot, DomainEnum.Borca, DomainEnum.Dorvinia, DomainEnum.GHenna).BindItems(ItemEnum.Ring.FreeAct, ItemEnum.Rod.Flail, ItemEnum.GauntletsOfOgrePower).BindGroups(GroupEnum.TalonOfTheHawk).BindSetting(CampaignSetting.Dragonlance).BindCloseBorder("Troops patrol the borders, those caught trying to escape are killed on sight.").BindCurse("Ravenloft gave him what he sought, but not what he truly desired - the respect of other rulers and the strength to instill fear and awe in other lords.").BindLair(LocationEnum.VladDrakovCastle);

            DomainEnum.GHenna.AddLivingDarklord(DarklordEnum.YagnoPetrovna, "3, 70-71, 109-110").BindAlignment(Alignment.LE).BindDomains(DomainEnum.Barovia).BindCharacters(CharacterEnum.Zhakata).BindGroups(GroupEnum.Zhakata).BindRelatedCreatures(Creature.Mongrelman).BindCloseBorder("A wall of jeering animal skulls appears before any character before 100 feet of the border. The wall extends into the heavens. No amount of magic or muscle can move it.").BindLair(LocationEnum.YagnoPetrovnaTemple);

            DomainEnum.Gundarak.AddLivingDarklord(DarklordEnum.LordGundar, "70-71").BindCreatures(Creature.Vampire).BindCloseBorder("The Mists of Ravenloft rise from the soil at the borders. Anyone who walks into them finds himself hopelessly lost, with all routes leading back to Gundarak.").BindLair(LocationEnum.CastleHunadora);

            DomainEnum.Hazlan.AddLivingDarklord(DarklordEnum.Hazlik, "3, 72, 99-100").BindAlignment(Alignment.CE).BindItems(ItemEnum.HazlikPendant).BindGroups(GroupEnum.RedWizard).BindDomains(DomainEnum.NightmareLands).BindCloseBorder("A wall of fire leaps up at the borders.").BindCurse("Each night, he dreams of Thay, and of his humiliation and defeat at the hands of his enmies. In his dreams, he is always weak and cowardly.").BindLair(LocationEnum.HazlikEstate);

            DomainEnum.Invidia   .AddLivingDarklord(DarklordEnum.GabrielleAderre , "3 73, 89-90").BindAlignment(Alignment.NE).BindGroups(GroupEnum.Vistani, GroupEnum.HalfVistani).BindDomains(DomainEnum.Richemulot, DomainEnum.Arkandale).BindCharacters(CharacterEnum.MadamEva, CharacterEnum.Matton, CharacterEnum.Isabella).BindRelatedCreatures(Creature.Werewolf).BindCloseBorder("A ring of fear that is neither visible nor tangible surrounds the domain. Characters who attempt to cross the border find themselves gripped by an unreasoning fear (no save). They flee 100 yards towards the center of the domain before they regain control.").BindCurse("Full-blooded gypsies are completely immune to her powers and spells. She can never wreak the vengeance she seeks.");

            DomainEnum.Kartakass .AddLivingDarklord(DarklordEnum.HarkonLukas     , "3, 9, 73-74, 101-102").BindAlignment(Alignment.NE).BindCreatures(Creature.Wolfwere, Creature.DireWolf).BindRelatedCreatures(Creature.Werewolf, Creature.Wolf, Creature.Vampire, Creature.Human, Creature.Elf).BindCharacters(DarklordEnum.CountStrahd).BindItems(ItemEnum.Elixir.Mad, ItemEnum.CursedBerserker, ItemEnum.HarkonHarp).BindSetting(CampaignSetting.ForgottenRealms).BindDomains(DomainEnum.Barovia).BindCloseBorder("Those who try to leave hear a sweet swong lulling them to sleep. (No spell or saving throw can prevent it)").BindCurse("Harkon's greatest desire is to rule, but his domain is filled with nothing of consequence for him to control. Kartakass has only a few small villages. The forests are filled with normal wildlife. In his eyes, being the lord of Kartakass is a pale shadow of what real rulership means.").BindLair(LocationEnum.KartakanInn);

            DomainEnum.Markovia.AddLivingDarklord(DarklordEnum.FrantisekMarkov, "3, 76, 102-103").BindAlignment(Alignment.LE).BindCharacters(CharacterEnum.Ludmilla).BindDomains(DomainEnum.Barovia).BindRelatedCreatures(Creature.Pig).BindCloseBorder("A mist rises at the borders, unlike other vapors in the core, this one causes excruciating pain to anyone who enters. The pain is incapacitating - leading first to paralysis (over 1d4 rounds), then madness. Only one thing alleviates it: stepping back towards the heart of Markovia.").BindCurse("He must always have the body of a beast, and so, like his creations, he is hideously disformed. Frantisek desperately wants to be a normal human again.").BindLair(LocationEnum.MarkovEstate);

            DomainEnum.Lamordia.AddLivingDarklord(DarklordEnum.Adam, "3, 75-76, 106-109").BindAlignment(Alignment.CE).BindCharacters(CharacterEnum.DoctorVictorMordenheim, CharacterEnum.EliseVonBrandthofen, CharacterEnum.Eva).BindCloseBorder("A driving blizzard hurls back any fool who attempts to leave.").BindCurse("Adam despites Dr. Mordenheim, but cannot bring himself to harm him. The land has bound them together in body and spirit. The monster feels the doctor's physical pain, and the doctor, in turn, shares the monster's eternal anguish.").BindLair(LocationEnum.IsleOfAgony);

            DomainEnum.Mordent.AddLivingDarklord(DarklordEnum.WilfredGodefroy, "3, 76, 97-98").BindAlignment(Alignment.CE).BindCreatures(Creature.Ghost).BindRelatedCreatures(Creature.Haunt).BindCharacters(CharacterEnum.LadyEstelleWeathermayGodefroy).BindCloseBorder("The Mists roll in front the sea and hug the coastline. At other borders, the Mists rise from the soil of Mordent itself, completely sealing the domain. Characters who enter these Mists will discover that every route leads back to Mordent.").BindCurse("Each night, Lady Godefroy and her child hunt down Lord Godefroy. They tear at his incorporeal flesh and curse him for their murders.").BindLair(LocationEnum.GryphonHillMansion);

            DomainEnum.Richemulot.AddLivingDarklord(DarklordEnum.JacquelineRenier, "3, 80, 110-111").BindAlignment(Alignment.CE).BindCreatures(Creature.Wererat).BindRelatedCreatures(Creature.GiantRat).BindCloseBorder("A horde of giant rats encircles the land. They form a border 50 feet thick, hanging from trees and hulking on the ground. It is impossible to fly over them and escape.").BindCurse("Automatically revert to a ratman form when confronting anyone she loves. Normally, this would not affect her; wererats usually do not form bonds of love and marriage. But it also has been Jacqueline's curse to fall in love.").BindLair(LocationEnum.RenierEstate);
            DomainEnum.Richemulot.AddDeadDarklord(DarklordEnum.ClaudeRenier, "111").BindCharacters(DarklordEnum.JacquelineRenier).BindCreatures(Creature.Wererat).BindDomains(DomainEnum.Falkovnia).BindLair(LocationEnum.RenierEstate);

            DomainEnum.Verbrek   .AddLivingDarklord(DarklordEnum.AlfredTimothy   , "3, 81, 111-112").BindAlignment(Alignment.LE).BindCreatures(Creature.Werewolf).BindRelatedCreatures(Creature.Wolf).BindCharacters(DarklordEnum.NathanTimothy).BindCloseBorder("To prevent escape, a large group of wolves and werewolves patrol the borders.");

            DomainEnum.Barovia.AddLivingDarklord(DarklordEnum.CountStrahd, "3, 8-9, 12, 14, 27, 30-31, 33-34, 36, 56, 63-65, 88, 116-119, 142-143").BindAlignment(Alignment.LE)
                .BindCreatures(Creature.Vampire).BindItems(ItemEnum.StrahdCrystalBall, ItemEnum.Amulet.Proof, ItemEnum.Cloak.Prot, ItemEnum.Ring.FireRes).BindRelatedCreatures(Creature.Wolf, Creature.StrahdZombie, Creature.StrahdSkeleton, Creature.Bat, Creature.Rat, Creature.Worg)
                .BindItems(ItemEnum.Book.TomeOfStrahd).BindCloseBorder("A ring of choking fog.").BindLair(LocationEnum.CastleRavenloft);

            DomainEnum.Sithicus.AddLivingDarklord(DarklordEnum.LordSoth, "9, 78-79").BindCreatures(Creature.DeathKnight).BindSetting(CampaignSetting.Dragonlance).BindCloseBorder("In Ravenloft, he can seal his borders by remembering his sins in song. As he sings, he is joined by the voices of other sinners. The sound, rising from the borders, is so horrid that no mortal can withstand it. All must return to Sithicus or become hopelessly mad.").BindLair(LocationEnum.NedragaardKeep);

            DomainEnum.NovaVaasa.AddLivingDarklord(DarklordEnum.TristenHiregaard, "78").BindLair(LocationEnum.HiregaardCastle);

            DarklordEnum.Tristessa.BindCreatures(Creature.Banshee, Creature.Drow).BindCloseBorder("A wall of wind that no one can walk or fly through, and no magic can diminish its force.");
            DomainEnum.Valachan.AddLivingDarklord(DarklordEnum.UrikVonKharkov, "80-81").BindCreatures(Creature.Vampire, Creature.Nosferatu, Creature.Panther).BindCloseBorder("The Mists of Ravenloft encircle the land. Characters who enter the Mists become disoriented; upon leaving them, they find themselves back in Valachan.").BindLair(LocationEnum.CastlePantara);

            DomainEnum.Farelle.AddLivingDarklord(DarklordEnum.JackKarn, "83").BindCreatures(Creature.Jackalwere).BindCloseBorder("His dogs and jackals patrol the border. Their senses are keen and their numbers formidable. Escape is virtually impossible unless Karn allows it.");

            DomainEnum.HarAkir.AddLivingDarklord(DarklordEnum.Anhktepot, "83").BindCreatures(Creature.Mummy).BindCloseBorder("The borders radiate an impenetrable wall of heat. Travelers who attempt to withstand it eventually turn to ash.");

            DomainEnum.Sanguinia.AddLivingDarklord(DarklordEnum.LadislavMircea, "84").BindCreatures(Creature.Vampire).BindCloseBorder("Anyone who enters the Misty Border eventually finds himself back in Sanguinia. The Mists sometimes take the form of a blinding snowstorm, bending the fir and pines.").BindLair(LocationEnum.CastleGuirgiu);

            DomainEnum.Souragne.AddLivingDarklord(DarklordEnum.AntonMisroi, "84").BindCreatures(Creature.Zombie).BindCloseBorder("The Mists direct travelers back into the domain. Anyone who enters the Misty Border eventually finds himself back in Souragne.");

            DomainEnum.SriRaji.AddLivingDarklord(DarklordEnum.Arijani, "85").BindCreatures(Creature.Rakshasa, Creature.Human).BindCloseBorder("A wall of phantasmal killers rises from the borders. The killers cannot be dispelled of disbelieved. Each creature acts in accordance with the phantasmal killer spell, but it attacks only those who are trying to leave.").BindLair(LocationEnum.ArijaniTemple);

            DomainEnum.StauntonBluffs.AddLivingDarklord(DarklordEnum.TorrenceBleysmith, "85").BindCreatures(Creature.Ghost).BindCloseBorder("Anyone who enteres the Misty Border surrounding the land finds that every route leads back into Staunton Bluffs.").BindLair(LocationEnum.CastleStonecrest);

            DomainEnum.Vechor.AddLivingDarklord(DarklordEnum.Easen, "86").BindCloseBorder("A wall of animated trees springs up from the borders. Only a few trees may appear at first. If characters still attempt to escape, more trees appear. The wall of trees is impervious to fire and impossibleto breach. Strange raptors, which are perfected in the branches, ensure that flight is an equally deadly proposition.");

            DomainEnum.Paridon.AddLivingDarklord(DarklordEnum.Sodo, "86").BindCreatures(Creature.Doppelganger).BindCloseBorder("Anyone entering the Mists eventually finds himself back in Zherisia.");

            DarklordEnum.TristenApblanc.BindLair(LocationEnum.CastleTristenoira);
            //DarklordEnum.HagsOfTepest.BindCloseBorder("A violent storm encircles the domain. Stinging rain, snow and bolts of lightning drive travelers inland toward the lake. Magic does not affect the bizarre storm.");
            #endregion

            #region Characters
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.Gondegal, "3, 98").BindAlignment(Alignment.CN).BindSetting(CampaignSetting.ForgottenRealms);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.TaraKolyana, "3, 100-101").BindAlignment(Alignment.CG).BindItems(ItemEnum.Amulet.VsUnd).BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Vampire, Creature.Wolf, Creature.Werewolf, Creature.Ghost).BindDomains(DomainEnum.Hazlan);
            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.DoctorVictorMordenheim, "3, 75-76, 104-108").BindAlignment(Alignment.LE).BindCreatures(Creature.Human).BindRelatedCreatures(Creature.Dog, Creature.Mouse, Creature.Rabbit).BindCharacters(CharacterEnum.EliseVonBrandthofen, CharacterEnum.Eva).BindItems(ItemEnum.Book.JournalOfVictorMordenheim);
            DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.RatikUbel, "3, 113-114").BindAlignment(Alignment.TN | Alignment.CE).BindCreatures(Creature.Revenant).BindDomains(DomainEnum.InsideRavenloft);
            DomainEnum.Darkon.AddLivingCharacter(CharacterEnum.DoctorRudolphVanRichten, "3, 114-115").BindAlignment(Alignment.LG).BindDomains(DomainEnum.InsideRavenloft, DomainEnum.Richemulot, DomainEnum.Mordent).BindRelatedCreatures(Creature.Vampire).BindItems(ItemEnum.VialOfHolyWater);
            DomainEnum.Arkandale.AddLivingCharacter(CharacterEnum.NataliaVhorishkova, "3, 115").BindAlignment(Alignment.CE).BindCreatures(Creature.Human, Creature.Werewolf, Creature.Wolf).BindCharacters(CharacterEnum.DoctorRudolphVanRichten).BindDomains(DomainEnum.InsideRavenloft);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.GeorgeWeathermay, "3, 119, 128").BindAlignment(Alignment.NG).BindRelatedCreatures(Creature.Horse, Creature.Dog).BindDomains(DomainEnum.InsideRavenloft);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Sergei, "8, 116, 127").BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.Tatyana);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Tatyana, "8, 12, 116, 127").BindCharacters(DarklordEnum.CountStrahd);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.MadamEva, "9, 36, 89, 117").BindGroups(GroupEnum.Vistani);
            DomainEnum.Dementlieu.AddLivingCharacter(CharacterEnum.MarcelGuignol, "68").BindCharacters(DarklordEnum.DominicdHonaire);
            DomainEnum.GHenna.AddLivingCharacter(CharacterEnum.Zhakata, "70-71, 109").BindGroups(GroupEnum.Deity, GroupEnum.Zhakata);
            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.BaronVonAubrecker, "75-76, 108");
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Kitiara, "78-79").BindDomains(DomainEnum.Sithicus);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.Kali, "85").BindGroups(GroupEnum.Deity, GroupEnum.Kali);
            DomainEnum.Invidia.AddDeadCharacter(CharacterEnum.Isabella, "89").BindGroups(GroupEnum.Vistani, GroupEnum.HalfVistani).BindRelatedCreatures(Creature.Werewolf).BindDomains(DomainEnum.Falkovnia, DomainEnum.Richemulot, DomainEnum.Arkandale);
            DomainEnum.Invidia.AddDeadCharacter(CharacterEnum.Matton, "90").BindCreatures(Creature.Wolfwere);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.Germain, "93, 122");
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Claude, "93, 122").BindCharacters(CharacterEnum.Germain).BindDomains(DomainEnum.Dementlieu);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.BorisDilisnya, "94").BindCharacters(CharacterEnum.NataliaOlszanik, CharacterEnum.StefaniaSeptow, CharacterEnum.KristinaDilisnya).BindDomains(DomainEnum.Borca).ExtraInfo = "Probably deceased.";
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.NataliaOlszanik, "94").ExtraInfo = "Probably deceased.";
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.StefaniaSeptow, "94").BindCharacters(CharacterEnum.KristinaDilisnya).BindDomains(DomainEnum.Borca);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KristinaDilisnya, "94").BindDomains(DomainEnum.Borca);
            DomainEnum.Dorvinia.AddDeadCharacter(CharacterEnum.Lucretia, "94");
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LadyEstelleWeathermayGodefroy, "97");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Ludmilla, "104-105");
            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.EliseVonBrandthofen, "105-107").BindCharacters(CharacterEnum.Eva);
            DomainEnum.Lamordia.AddLivingCharacter(CharacterEnum.Eva, "107-108");
            DomainEnum.Richemulot.AddLivingCharacter(CharacterEnum.HenriDuBois, "111").BindCharacters(DarklordEnum.JacquelineRenier).BindRelatedCreatures(Creature.Wererat);
            DomainEnum.Verbrek.AddLivingCharacter(CharacterEnum.WolfGod, "112").BindGroups(GroupEnum.Deity, GroupEnum.WolfGod);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.EowinTimothy, "112, 126").BindCreatures(Creature.Werewolf).ExtraInfo = "Living status unknown.";
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Perseus, "119").BindCharacters(CharacterEnum.GoergeWeathermay).BindItems(ItemEnum.VialOfHolyWater).ExtraInfo = "Medium Warhorse";

            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.Dorfniya, "121, 123").BindCharacters(CharacterEnum.GuntherCosco);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.PidlwickDilisnya, "121, 123").BindCharacters(CharacterEnum.GuntherCosco);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.GuntherCosco, "121, 123");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.LeoDilisnya, "121, 123").BindCharacters(CharacterEnum.GuntherCosco, CharacterEnum.Dorfniya, CharacterEnum.PidlwickDilisnya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.LevDilisnya, "121");
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.NikiRomanoff, "121").BindCharacters(CharacterEnum.LevDilisnya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ElenaAlmeida, "121").BindCharacters(CharacterEnum.LevDilisnya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.YakovDilisnya, "121").BindCharacters(CharacterEnum.LevDilisnya, CharacterEnum.ElenaAlmeida);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.OleskaDilisnya, "121").BindCharacters(CharacterEnum.LevDilisnya, CharacterEnum.ElenaAlmeida);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.StepanDilisnya, "121").BindCharacters(CharacterEnum.LevDilisnya, CharacterEnum.ElenaAlmeida);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.AnnaKurdzeil, "121").BindCharacters(CharacterEnum.LevDilisnya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.TadeuszPaldo, "121").BindCharacters(CharacterEnum.AnnaKurdzeil);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.RichtorDilisnya, "121, 126").BindDomains(DomainEnum.Mordent).BindCharacters(CharacterEnum.LevDilisnya, CharacterEnum.AnnaKurdzeil);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.EstherTimothy, "121, 126").BindDomains(DomainEnum.Mordent).BindCharacters(CharacterEnum.RichtorDilisnya).BindCreatures(Creature.Werewolf);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.SiegfriedGrymig, "121").BindCharacters(DarklordEnum.CamilleDilisnya, CharacterEnum.MariaDiazi);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.MariaDiazi, "121").BindCharacters(DarklordEnum.CamilleDilisnya, CharacterEnum.SiegfriedGrymig);
            DomainEnum.Borca.AddDeadCharacter(CharacterEnum.StepanTaroyan, "121").BindCharacters(DarklordEnum.CamilleDilisnya, CharacterEnum.Brunhilda);
            DomainEnum.Borca.AddLivingCharacter(CharacterEnum.Brunhilda, "121").BindCharacters(CharacterEnum.StepanTaroyan).ExtraInfo = "Living status unknown.";
            DomainEnum.Borca.AddDeadCharacter(CharacterEnum.OlehFortich, "121").BindCharacters(DarklordEnum.CamilleDilisnya);
            DomainEnum.Borca.AddDeadCharacter(CharacterEnum.AbelardoLeoni, "121").BindCharacters(DarklordEnum.IvanaBoritsi);
            DomainEnum.Borca.AddDeadCharacter(CharacterEnum.NikoliChesniak, "121").BindCharacters(DarklordEnum.IvanaBoritsi);
            DomainEnum.Borca.AddLivingCharacter(CharacterEnum.AlexanderManduchi, "121").BindCharacters(DarklordEnum.IvanaBoritsi);
            DomainEnum.Borca.AddDeadCharacter(CharacterEnum.KlausBoritsi, "121").BindCharacters(DarklordEnum.CamilleDilisnya, DarklordEnum.IvanaBoritsi);
            DomainEnum.Borca.AddLivingCharacter(CharacterEnum.SuloBoritsi, "121").BindCharacters(DarklordEnum.CamilleDilisnya, CharacterEnum.KlausBoritsi);
            DomainEnum.Borca.AddLivingCharacter(CharacterEnum.LuciaRitter, "121").BindCharacters(CharacterEnum.SuloBoritsi);
            DomainEnum.Borca.AddDeadCharacter(CharacterEnum.AntonBoritsi, "121").BindCharacters(DarklordEnum.CamilleDilisnya, CharacterEnum.KlausBoritsi);
            DomainEnum.Borca.AddLivingCharacter(CharacterEnum.KatarinaPiechota, "121").BindCharacters(CharacterEnum.AntonBoritsi);

            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.AliciaCorgiat, "122").BindCharacters(CharacterEnum.Germain, CharacterEnum.Claude);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.Bernadette, "122").BindCharacters(CharacterEnum.Germain, CharacterEnum.AliciaCorgiat);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.HuguesMousel, "122").BindCharacters(CharacterEnum.Bernadette);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.FrancoisMousel, "122").BindCharacters(CharacterEnum.Bernadette, CharacterEnum.HuguesMousel);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.JoelieFontaine, "122").BindCharacters(CharacterEnum.FrancoisMousel);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MadeleineMousel, "122").BindCharacters(CharacterEnum.Bernadette, CharacterEnum.HuguesMousel);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.RaymondeBiourne, "122").BindCharacters(CharacterEnum.MadeleineMousel);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Maurice, "122").BindCharacters(CharacterEnum.Germain, CharacterEnum.AliciaCorgiat);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.AliciaNorberte, "122").BindCharacters(CharacterEnum.Maurice);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.ErnestinePasier, "122").BindCharacters(CharacterEnum.Claude, DarklordEnum.DominicdHonaire);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.LouisePecquet, "122").BindDomains(DomainEnum.Dementlieu).BindCharacters(DarklordEnum.DominicdHonaire);
            DomainEnum.Dementlieu.AddLivingCharacter(CharacterEnum.DominicdHonaire2, "122").BindCharacters(DarklordEnum.DominicdHonaire, CharacterEnum.LouisePecquet);
            DomainEnum.Dementlieu.AddLivingCharacter(CharacterEnum.LouiseGirod, "122").BindCharacters(DarklordEnum.DominicdHonaire);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BabetteBatista, "122").BindDomains(DomainEnum.Dementlieu).BindCharacters(CharacterEnum.Claude).ExtraInfo = "Living status unknown.";
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.Julienne, "122").BindDomains(DomainEnum.Dementlieu).BindCharacters(CharacterEnum.Claude, CharacterEnum.BabetteBatista);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.BernardLoverde, "122").BindDomains(DomainEnum.Dementlieu).BindCharacters(CharacterEnum.Julienne);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.Gerard, "122").BindDomains(DomainEnum.Dementlieu).BindCharacters(CharacterEnum.Julienne, CharacterEnum.BernardLoverde);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.ReinholdDilisnya, "123").BindCharacters(CharacterEnum.PidlwickDilisnya, CharacterEnum.Dorfniya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.NadiaYakimov, "123").BindCharacters(CharacterEnum.ReinholdDilisnya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.GertudeDilisnya, "123").BindCharacters(CharacterEnum.PidlwickDilisnya, CharacterEnum.Dorfniya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.IvanBuchvold, "123").BindCharacters(CharacterEnum.GertudeDilisnya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.OlekaDilisnya, "123").BindCharacters(CharacterEnum.PidlwickDilisnya, CharacterEnum.Dorfniya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.VictorWachter, "123").BindCharacters(CharacterEnum.OlekaDilisnya);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.LovinaWachter, "123").BindCharacters(CharacterEnum.OlekaDilisnya, CharacterEnum.VictorWachter).ExtraInfo = "Probably deceased.";
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.RomanDilisnya, "123").BindCharacters(CharacterEnum.NataliaOlszanik, CharacterEnum.BorisDilisnya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.AnnaSpachuk, "123").BindCharacters(CharacterEnum.RomanDilisnya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.CamilleYakimov, "123").BindCharacters(CharacterEnum.RomanDilisnya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.NataliaOlszanik, "123").BindCharacters(CharacterEnum.RomanDilisnya);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.FredrikDilisnya, "123").BindCharacters(CharacterEnum.RomanDilisnya, CharacterEnum.NataliaOlszanik);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.TaraYanoff, "123").BindCharacters(CharacterEnum.FredrikDilisnya);
            DomainEnum.Barovia.AddLivingCharacter(CharacterEnum.KatinaDilisnya, "123").BindCharacters(CharacterEnum.FredrikDilisnya, CharacterEnum.TaraYanoff);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.HassligDilisnya, "123").BindCharacters(CharacterEnum.FredrikDilisnya, CharacterEnum.TaraYanoff);
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.EdgarLeskovich, "123").BindCharacters(CharacterEnum.KristinaDilisnya);

            DomainEnum.Falkovnia.AddDeadCharacter(CharacterEnum.LelaDekovan, "124").BindCharacters(DarklordEnum.VladDrakov);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.VladDrakov2, "124").BindCharacters(DarklordEnum.VladDrakov, CharacterEnum.LelaDekovan);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.TatyanaOstevic, "124").BindCharacters(CharacterEnum.VladDrakov2);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.VladDrakov3, "124").BindCharacters(CharacterEnum.VladDrakov2, CharacterEnum.TatyanaOstevic);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.KaraDrakov, "124").BindCharacters(DarklordEnum.VladDrakov, CharacterEnum.LelaDekovan);
            DomainEnum.Falkovnia.AddDeadCharacter(CharacterEnum.DmitriLikarevie, "124").BindCharacters(CharacterEnum.KaraDrakov);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.MirceaDrakov, "124").BindCharacters(DarklordEnum.VladDrakov, CharacterEnum.LelaDekovan);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.AnnaHatziavas, "124").BindCharacters(CharacterEnum.MirceaDrakov);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.TaraFastov, "124").BindCharacters(CharacterEnum.MirceaDrakov);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.SzotaDrakov, "124").BindCharacters(DarklordEnum.VladDrakov, CharacterEnum.LelaDekovan);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.PeterVonBorstel, "124").BindCharacters(CharacterEnum.SzotaDrakov);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.GriseldaZamiara, "124").BindCharacters(DarklordEnum.VladDrakov);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.MikhailDrakov, "124").BindCharacters(DarklordEnum.VladDrakov, CharacterEnum.GriseldaZamiara);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.OlanaCrepeau, "124").BindCharacters(CharacterEnum.MikhailDrakov);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.NatashaDrakov, "124").BindCharacters(DarklordEnum.VladDrakov, CharacterEnum.GriseldaZamiara);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.LevKrenkovich, "124").BindCharacters(CharacterEnum.NatashaDrakov);
            DomainEnum.Falkovnia.AddDeadCharacter(CharacterEnum.NadiaRuzich, "124").BindCharacters(DarklordEnum.VladDrakov);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.IreenaImlach, "124").BindCharacters(DarklordEnum.VladDrakov, CharacterEnum.NadiaRuzich);
            DomainEnum.Falkovnia.AddLivingCharacter(CharacterEnum.YuriMitrovic, "124").BindCharacters(CharacterEnum.IreenaImlach);
            
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.IsabelleMoseau, "125").BindCharacters(DarklordEnum.ClaudeRenier).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.AnaisRenier, "125").BindCharacters(DarklordEnum.ClaudeRenier, CharacterEnum.IsabelleMoseau).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.HenriMilette, "125").BindCharacters(CharacterEnum.AnaisRenier);
            DomainEnum.Richemulot.AddLivingCharacter(CharacterEnum.JoelleMilette, "125").BindCharacters(CharacterEnum.AnaisRenier, CharacterEnum.HenriMilette).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddLivingCharacter(CharacterEnum.GregoireAlairan, "125").BindCharacters(CharacterEnum.JoelleMilette);
            DomainEnum.Richemulot.AddLivingCharacter(CharacterEnum.MauriceMilette, "125").BindCharacters(CharacterEnum.AnaisRenier, CharacterEnum.HenriMilette).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddLivingCharacter(CharacterEnum.EliseDeLauren, "125").BindCharacters(CharacterEnum.MauriceMilette);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.MarieRenier, "125").BindCharacters(DarklordEnum.ClaudeRenier, CharacterEnum.IsabelleMoseau).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.SimonAudaire, "125").BindCharacters(CharacterEnum.MarieRenier);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.AntionetteRenier, "125").BindCharacters(CharacterEnum.MarieRenier, CharacterEnum.SimonAudaire).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.LaurrentHaurie, "125").BindCharacters(CharacterEnum.AntionetteRenier);
            DomainEnum.Richemulot.AddDeadCharacter(DarklordEnum.JacquelineRenier, "125").BindCharacters(CharacterEnum.MarieRenier, CharacterEnum.SimonAudaire).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.DominicSoufel, "125").BindCharacters(CharacterEnum.AntionetteRenier);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.JacquesRenier, "125").BindCharacters(DarklordEnum.JacquelineRenier, CharacterEnum.DominicSoufel).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.LouiseRenier, "125").BindCharacters(CharacterEnum.MarieRenier, CharacterEnum.SimonAudaire).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.RaulRenier, "125").BindCharacters(CharacterEnum.MarieRenier, CharacterEnum.SimonAudaire).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.GertrudeVonZarovich, "125").BindCharacters(CharacterEnum.RaulRenier);
            DomainEnum.Richemulot.AddDeadCharacter(CharacterEnum.EduardoRenier, "125").BindCharacters(DarklordEnum.ClaudeRenier, CharacterEnum.IsabelleMoseau).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddLivingCharacter(CharacterEnum.MargueritePentarde, "125").BindCharacters(CharacterEnum.EduardoRenier);
            DomainEnum.Richemulot.AddLivingCharacter(CharacterEnum.PierreRenier, "125").BindCharacters(CharacterEnum.EduardoRenier, CharacterEnum.MargueritePentarde).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddLivingCharacter(CharacterEnum.GerardRenier, "125").BindCharacters(CharacterEnum.EduardoRenier, CharacterEnum.MargueritePentarde).BindCreatures(Creature.Wererat);
            DomainEnum.Richemulot.AddLivingCharacter(CharacterEnum.SandrineDaugeri, "125").BindCharacters(CharacterEnum.GerardRenier);

            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.CainTimothy, "126").BindCharacters(CharacterEnum.ElizabethTimothy, CharacterEnum.EowinTimothy, CharacterEnum.EstherTimothy).BindCreatures(Creature.Werewolf).BindDomains(DomainEnum.Mordent);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.ElizabethTimothy, "126").BindCharacters(CharacterEnum.EowinTimothy, CharacterEnum.EstherTimothy).BindCreatures(Creature.Werewolf).BindDomains(DomainEnum.Mordent);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.SeanTimothy, "126").BindCharacters(CharacterEnum.ElizabethTimothy, CharacterEnum.CainTimothy).BindCreatures(Creature.Werewolf);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.VirginiaDilisnya, "126").BindCharacters(CharacterEnum.EstherTimothy, CharacterEnum.RichtorDilisnya).BindCreatures(Creature.Werewolf);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.RichardRatcliff, "126").BindCharacters(CharacterEnum.VirginiaDilisnya);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.WinifredRatcliff, "126").BindDomains(DomainEnum.Arkandale, DomainEnum.Verbrek).BindCharacters(CharacterEnum.VirginiaDilisnya, CharacterEnum.RichardRatcliff, DarklordEnum.AlfredTimothy).BindCreatures(Creature.Werewolf);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MichaelRatcliff, "126").BindCharacters(CharacterEnum.VirginiaDilisnya, CharacterEnum.RichardRatcliff).BindCreatures(Creature.Werewolf);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.CharlotteWinchester, "126").BindCharacters(CharacterEnum.MichaelRatcliff);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.CliffordDilisnya, "126").BindCharacters(CharacterEnum.EstherTimothy, CharacterEnum.RichtorDilisnya).BindCreatures(Creature.Werewolf);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.CynthiaHerbert, "126").BindCharacters(CharacterEnum.CliffordDilisnya);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.IreneTimothy, "126").BindCharacters(CharacterEnum.EowinTimothy, CharacterEnum.EmilyGerhardt).BindCreatures(Creature.Werewolf);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.FranklinDodds, "126").BindCharacters(CharacterEnum.IreneTimothy);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.ThomasDodds, "126").BindCharacters(CharacterEnum.IreneTimothy, CharacterEnum.FranklinDodds).BindCreatures(Creature.Werewolf);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.PatriciaRichards, "126").BindCharacters(CharacterEnum.ThomasDodds);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.PriscillaSchilling, "126").BindDomains(DomainEnum.Arkandale).BindCharacters(DarklordEnum.NathanTimothy);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.ArabellaTimothy, "126").BindDomains(DomainEnum.Arkandale).BindCharacters(DarklordEnum.NathanTimothy);
            DomainEnum.Arkandale.AddLivingCharacter(CharacterEnum.WilliamTimothy, "126").BindCharacters(DarklordEnum.NathanTimothy, CharacterEnum.PriscillaSchilling).BindCreatures(Creature.Werewolf);
            DomainEnum.Arkandale.AddLivingCharacter(CharacterEnum.EvelynWesterfield, "126").BindCharacters(CharacterEnum.WilliamTimothy);
            DomainEnum.Arkandale.AddLivingCharacter(CharacterEnum.LawrenceTimothy, "126").BindCharacters(CharacterEnum.EvelynWesterfield, CharacterEnum.WilliamTimothy).BindCreatures(Creature.Werewolf);
            DomainEnum.Arkandale.AddLivingCharacter(CharacterEnum.EsterTimothy, "126").BindCharacters(DarklordEnum.NathanTimothy, CharacterEnum.PriscillaSchilling).BindCreatures(Creature.Werewolf);
            DomainEnum.Arkandale.AddLivingCharacter(CharacterEnum.CharlesNickerson, "126").BindCharacters(CharacterEnum.WilliamTimothy);

            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.KingBarov, "127").BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.Sergei).ExtraInfo = "Listed as within Barovia as the body is within Barovia.";
            DomainEnum.Barovia.AddDeadCharacter(CharacterEnum.Ravenovia, "127").BindCharacters(CharacterEnum.KingBarov, DarklordEnum.CountStrahd, CharacterEnum.Sergei).ExtraInfo = "Listed as within Barovia as the body is within Barovia.";
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.Sturm, "127").BindCharacters(CharacterEnum.KingBarov, CharacterEnum.Ravenovia);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.GisellaFallona, "127").BindCharacters(CharacterEnum.KingBarov, CharacterEnum.Ravenovia);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.AnnaVonZarovich, "127").BindCharacters(CharacterEnum.Sturm, CharacterEnum.GisellaFallona).ExtraInfo = "Fate unknown. Missing.";
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.TodHeitman, "127").BindCharacters(CharacterEnum.AnnaVonZarovich).ExtraInfo = "Fate unknown. Missing.";
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.SiskaVonZarovich, "127").BindCharacters(CharacterEnum.Sturm, CharacterEnum.GisellaFallona);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.IvanReichhardt, "127").BindCharacters(CharacterEnum.SiskaVonZarovich);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.KatarinaVonZarovich, "127").BindCharacters(CharacterEnum.Sturm, CharacterEnum.GisellaFallona);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.HolgarVonZarovich, "127").BindCharacters(CharacterEnum.Sturm, CharacterEnum.GisellaFallona);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.IsoldeVonKoss, "127").BindCharacters(CharacterEnum.HolgarVonZarovich);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.YsildeVonZarovich, "127").BindCharacters(CharacterEnum.HolgarVonZarovich, CharacterEnum.IsoldeVonKoss);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.SergeiVonZarovich2, "127").BindCharacters(CharacterEnum.HolgarVonZarovich, CharacterEnum.IsoldeVonKoss);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.IreenaKolokoff, "127").BindCharacters(CharacterEnum.SergeiVonZarovich2);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.BarovVonZarovich2, "127").BindCharacters(CharacterEnum.SergeiVonZarovich2, CharacterEnum.IreenaKolokoff);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.ElsaDrache, "127").BindCharacters(CharacterEnum.BarovVonZarovich2);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.AndreaVonZarovich, "127").BindCharacters(CharacterEnum.SergeiVonZarovich2, CharacterEnum.IreenaKolokoff);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.KlausVonZarovich, "127").BindCharacters(CharacterEnum.AndreaVonZarovich);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.VictorVonZarovich, "127").BindCharacters(CharacterEnum.SergeiVonZarovich2, CharacterEnum.IreenaKolokoff);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.LisbethVonZarovich, "127").BindCharacters(CharacterEnum.SergeiVonZarovich2, CharacterEnum.IreenaKolokoff);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.VasiliGeistlinger, "127").BindCharacters(CharacterEnum.LisbethVonZarovich);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.MyroslavVonZarovich, "127").BindCharacters(CharacterEnum.SergeiVonZarovich2, CharacterEnum.IreenaKolokoff, CharacterEnum.GertrudeVonZarovich);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.MarlenaLeibnik, "127").BindCharacters(CharacterEnum.MyroslavVonZarovich, CharacterEnum.GertrudeVonZarovich);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.HansVonZarovich, "127").BindCharacters(CharacterEnum.SergeiVonZarovich2, CharacterEnum.IreenaKolokoff);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.NatashaItskovich, "127").BindCharacters(CharacterEnum.HolgarVonZarovich);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.GeierVonZarovich, "127").BindCharacters(CharacterEnum.HolgarVonZarovich, CharacterEnum.NatashaItskovich);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.IvanVonZarovich, "127").BindCharacters(CharacterEnum.HolgarVonZarovich, CharacterEnum.NatashaItskovich);
            DomainEnum.OutsideRavenloft.AddLivingCharacter(CharacterEnum.NataliaAndas, "127").BindCharacters(CharacterEnum.IvanVonZarovich);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.PeterVonZarovich, "127").BindCharacters(CharacterEnum.IvanVonZarovich, CharacterEnum.NataliaAndas);
            DomainEnum.OutsideRavenloft.AddDeadCharacter(CharacterEnum.KatarinaDragus, "127").BindCharacters(CharacterEnum.PeterVonZarovich);

            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.LordWeathermay, "128").BindCharacters(CharacterEnum.OldLadyWeathermay);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.OldLadyWeathermay, "128").ExtraInfo = "Maiden name of Sutherwaite.";
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LadyEstelleWeathermayGodefroy, "128").BindCharacters(DarklordEnum.WilfredGodefroy);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.LiliaGodefroy, "128").BindCharacters(DarklordEnum.WilfredGodefroy, CharacterEnum.LadyEstelleWeathermayGodefroy);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.LadyWeathermay, "128").BindCharacters(CharacterEnum.OldLadyWeathermay, CharacterEnum.LordWeathermay);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.HenryLeighton, "128").BindCharacters(CharacterEnum.LadyWeathermay).ExtraInfo = "Took the Weathermay name in accordance with his father-in-law's wishes.";
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.ElizabethWeathermay, "128").BindCharacters(CharacterEnum.LadyWeathermay, CharacterEnum.HenryLeighton);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.PrudenceWeathermay, "128").BindCharacters(CharacterEnum.LadyWeathermay, CharacterEnum.HenryLeighton);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.TorrenceSeabag, "128").BindCharacters(CharacterEnum.PrudenceWeathermay);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.VivianSeabag, "128").BindCharacters(CharacterEnum.PrudenceWeathermay, CharacterEnum.TorrenceSeabag);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.DonaldSherwood, "128").BindCharacters(CharacterEnum.VivianSeabag);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.HelenSeabag, "128").BindCharacters(CharacterEnum.PrudenceWeathermay, CharacterEnum.TorrenceSeabag);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.JulesWeathermay, "128").BindCharacters(CharacterEnum.LadyWeathermay, CharacterEnum.HenryLeighton, CharacterEnum.GeorgeWeathermay);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.MarthaScoville, "128").BindCharacters(CharacterEnum.JulesWeathermay, CharacterEnum.GeorgeWeathermay);
            DomainEnum.Mordent.AddDeadCharacter(CharacterEnum.AliceWeathermay, "128").BindCharacters(CharacterEnum.JulesWeathermay, CharacterEnum.MarthaScoville);
            DomainEnum.Mordent.AddLivingCharacter(CharacterEnum.DanielFoxgrove, "128").BindCharacters(CharacterEnum.AliceWeathermay);

            DomainEnum.Kartakass.AddLivingCharacter(CharacterEnum.Akriel, "Map");
            DomainEnum.SriRaji.AddLivingCharacter(CharacterEnum.Rudra, "Map");
            DomainEnum.SriRaji.AddLivingCharacter(CharacterEnum.Shiva, "Map");
            DomainEnum.SriRaji.AddLivingCharacter(CharacterEnum.Ravana, "Map");
            #endregion

            #region Locations
            DomainEnum.Barovia.AddLocation(LocationEnum.CastleRavenloft, "8-9, 56, 64-65, 94, 103, 116, 142-143, Map").BindGroups(GroupEnum.VonZarovich).BindItems(ItemEnum.SymbolOfRaven).BindGroups(GroupEnum.HighPriestRavenloft).BindCharacters(DarklordEnum.CountStrahd, CharacterEnum.Sergei, CharacterEnum.ReinholdDilisnya, CharacterEnum.NadiaYakimov);
            MistwayEnum.SteamwallMountains.TrackMistway("11", DomainEnum.InsideRavenloft, DomainEnum.OutsideRavenloft).BindSetting(CampaignSetting.Dragonlance);
            MistwayEnum.XakTsaroth        .TrackMistway("11", DomainEnum.InsideRavenloft, DomainEnum.OutsideRavenloft).BindSetting(CampaignSetting.Dragonlance);
            MistwayEnum.GreycloakHills    .TrackMistway("11", DomainEnum.InsideRavenloft, DomainEnum.OutsideRavenloft).BindSetting(CampaignSetting.ForgottenRealms);
            MistwayEnum.KaraTurIsland     .TrackMistway("11", DomainEnum.InsideRavenloft, DomainEnum.OutsideRavenloft).BindSetting(CampaignSetting.ForgottenRealms);
            MistwayEnum.LortmillMountains .TrackMistway("11", DomainEnum.InsideRavenloft, DomainEnum.OutsideRavenloft).BindSetting(CampaignSetting.Greyhawk);
            MistwayEnum.RuinsOfGreyhawk   .TrackMistway("11", DomainEnum.InsideRavenloft, DomainEnum.OutsideRavenloft).BindSetting(CampaignSetting.Greyhawk);
            DomainEnum.Barovia.AddLocation(LocationEnum.Balinoks, "35, 60-67, 69-73, 76, 78-79, 116. 120")
                .BindLocations(LocationEnum.RiverVuchar, LocationEnum.RiverMusarde, LocationEnum.RiverArden)
                .BindDomains(DomainEnum.Darkon, DomainEnum.Bluetspur, DomainEnum.NovaVaasa, DomainEnum.Hazlan, DomainEnum.Tepest, DomainEnum.Arak);
            DomainEnum.Darkon.AddLocation(LocationEnum.RiverVuchar, "60, 67, 75").BindDomains(DomainEnum.Falkovnia, DomainEnum.Dementlieu, DomainEnum.Lamordia, DomainEnum.SeaOfSorrows).BindLocations(LocationEnum.RiverMusarde, Settlement.Lekar, Settlement.IlAluk);
            DomainEnum.Lamordia.AddLocation(LocationEnum.RiverMusarde, "60, 63-64, 72-73, 112-113").BindDomains(DomainEnum.SeaOfSorrows, DomainEnum.Valachan, DomainEnum.Arkandale, DomainEnum.Barovia);
            DomainEnum.Barovia.AddLocation(LocationEnum.RiverLuna, "60").BindLocations(LocationEnum.RiverMusarde, Settlement.Levkarest);
            DomainEnum.Mordent.AddLocation(LocationEnum.RiverArden, "60, 77").BindDomains(DomainEnum.Valachan);
            DomainEnum.Arak.AddLocation(LocationEnum.MountNyid, "61").BindLocations(LocationEnum.Balinoks);
            DomainEnum.Arak.AddLocation(LocationEnum.MountNirka, "61").BindLocations(LocationEnum.Balinoks);
            DomainEnum.Barovia.AddLocation(LocationEnum.MountBaratak, "63-64").BindLocations(LocationEnum.Balinoks);
            DomainEnum.Barovia.AddLocation(LocationEnum.MountGhakis, "63-64").BindLocations(LocationEnum.Balinoks);
            DomainEnum.Barovia.AddSettlement(Settlement.Barovia, "64, 116, Map").BindCreatures(Creature.Wolf).BindLocations(LocationEnum.OldSvalichRoad);
            DomainEnum.Barovia.AddLocation(LocationEnum.LakeZarovich, "64");
            DomainEnum.Barovia.AddLocation(LocationEnum.SvalichWoods, "64, Map");
            DomainEnum.Barovia.AddLocation(LocationEnum.TepurichForest, "64");
            DomainEnum.Barovia.AddLocation(LocationEnum.OldSvalichRoad, "64, Map").BindLocations(Settlement.Barovia, Settlement.Vallaki, LocationEnum.RiverIvlis);
            DomainEnum.Barovia.AddSettlement(Settlement.Vallaki, "64, 103").BindCharacters(DarklordEnum.FrantisekMarkov);
            DomainEnum.Barovia.AddLocation(LocationEnum.RiverIvlis, "64-65, Map");
            DomainEnum.Borca.AddSettlement(Settlement.Levkarest, "66");
            DomainEnum.Borca.AddSettlement(Settlement.Sturben, "66");
            DomainEnum.Darkon.AddSettlement(Settlement.IlAluk, "67, 113").BindCharacters(CharacterEnum.RatikUbel);
            DomainEnum.Darkon.AddSettlement(Settlement.MartiraBay, "67").BindCreatures(Creature.Human);
            DomainEnum.Darkon.AddSettlement(Settlement.Karg, "67").BindCreatures(Creature.Human);
            DomainEnum.Darkon.AddSettlement(Settlement.Viaki, "67").BindCreatures(Creature.Human);
            DomainEnum.Darkon.AddSettlement(Settlement.Nartok, "67").BindCreatures(Creature.Human);
            DomainEnum.Darkon.AddSettlement(Settlement.Rivalis, "67").BindCreatures(Creature.Halfling);
            DomainEnum.Darkon.AddSettlement(Settlement.Corvia, "67").BindCreatures(Creature.Dwarf);
            DomainEnum.Darkon.AddSettlement(Settlement.TempeFalls, "67").BindCreatures(Creature.Dwarf);
            DomainEnum.Darkon.AddSettlement(Settlement.Neblus, "67").BindCreatures(Creature.Elf);
            DomainEnum.Darkon.AddSettlement(Settlement.Maykle, "67").BindCreatures(Creature.Human);
            DomainEnum.Darkon.AddSettlement(Settlement.Mayvin, "67").BindCreatures(Creature.Gnome);
            DomainEnum.Darkon.AddSettlement(Settlement.Delagia, "67").BindCreatures(Creature.Halfling);
            DomainEnum.Darkon.AddSettlement(Settlement.NevucharSprings, "67").BindCreatures(Creature.Elf);
            DomainEnum.Darkon.AddSettlement(Settlement.Sidnar, "67").BindCreatures(Creature.Elf);
            DomainEnum.Dementlieu.AddSettlement(Settlement.PortaLucine, "68");
            DomainEnum.Dementlieu.AddLocation(LocationEnum.ParnaultBay, "68");
            DomainEnum.Dementlieu.AddSettlement(Settlement.Chateaufaux, "68");
            DomainEnum.Dorvinia.AddLocation(LocationEnum.MountGries, "69");
            DomainEnum.Dorvinia.AddLocation(LocationEnum.DilisnyaEstate, "69, Map").BindCharacters(DarklordEnum.IvanDilisnya);
            DomainEnum.Dorvinia.AddSettlement(Settlement.Lechberg, "69").BindLocations(LocationEnum.DilisnyaEstate);
            DomainEnum.Dorvinia.AddSettlement(Settlement.Ilvin, "69");
            DomainEnum.Dorvinia.AddSettlement(Settlement.VorZiyden, "69");
            DomainEnum.Falkovnia.AddSettlement(Settlement.Lekar, "69");
            DomainEnum.Falkovnia.AddSettlement(Settlement.Stangengrad, "69");
            DomainEnum.Falkovnia.AddSettlement(Settlement.Silbervas, "69, 111").BindCharacters(DarklordEnum.ClaudeRenier);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.LakeKriegvogel, "69, Map").BindLocations(Settlement.Silbervas);
            DomainEnum.Falkovnia.AddSettlement(Settlement.Aerie, "69");
            DomainEnum.Forlorn.AddLocation(LocationEnum.CastleTristenoira, "70, Map").BindCreatures(Creature.Ghost);
            DomainEnum.Forlorn.AddLocation(LocationEnum.LakeRedTears, "70");
            DomainEnum.GHenna.AddLocation(LocationEnum.Outland, "71").BindCreatures(Creature.Mongrelman);
            DomainEnum.GHenna.AddSettlement(Settlement.Zukar, "71");
            DomainEnum.Gundarak.AddSettlement(Settlement.Teufeldorf, "72");
            DomainEnum.Gundarak.AddLocation(LocationEnum.CastleHunadora, "72").BindCharacters(DarklordEnum.LordGundar);
            DomainEnum.Gundarak.AddSettlement(Settlement.Zeidenburg, "72").BindLocations(LocationEnum.CastleHunadora);
            DomainEnum.Hazlan.AddSettlement(Settlement.Toyalis, "72");
            DomainEnum.Hazlan.AddSettlement(Settlement.SlyVar, "72");
            DomainEnum.Hazlan.AddLocation(LocationEnum.TheTables, "72").BindCharacters(DarklordEnum.Hazlik);
            DomainEnum.Invidia.AddSettlement(Settlement.Karina, "73");
            DomainEnum.Kartakass.AddLocation(LocationEnum.KartakanInn, "Map").BindCharacters(DarklordEnum.HarkonLukas, CharacterEnum.Akriel).BindItems(ItemEnum.Drink.Meekulbrau).BindCreatures(Creature.Wolfwere);
            DomainEnum.Kartakass.AddSettlement(Settlement.Skald, "73").BindCreatures(Creature.Sheep, Creature.Nightbird).BindLocations(LocationEnum.KartakanInn);
            DomainEnum.Kartakass.AddSettlement(Settlement.Harmonia, "73").BindCreatures(Creature.Fox, Creature.Wolf);
            DomainEnum.Lamordia.AddLocation(LocationEnum.SleepingBeast, "75-76").BindCharacters(CharacterEnum.BaronVonAubrecker);
            DomainEnum.Lamordia.AddLocation(LocationEnum.IsleOfAgony, "75, 109");
            DomainEnum.Lamordia.AddLocation(LocationEnum.SchlossMordenheim, "75, Map").BindCharacters(CharacterEnum.DoctorVictorMordenheim);
            DomainEnum.Lamordia.AddSettlement(Settlement.Ludendorf, "75").BindLocations(LocationEnum.SchlossMordenheim);
            DomainEnum.Lamordia.AddSettlement(Settlement.Neufurchtenburg, "75");
            DomainEnum.Mordent.AddLocation(LocationEnum.ArdentBay, "77");
            DomainEnum.Mordent.AddLocation(LocationEnum.GryphonHillMansion, "77, 97").BindCharacters(DarklordEnum.WilfredGodefroy).BindGroups(GroupEnum.Weathermay);
            DomainEnum.Mordent.AddLocation(LocationEnum.GryphonHill, "77, 97-98").BindCreatures(Creature.Ghoul, Creature.Haunt, Creature.Poltergeist, Creature.Shadow, Creature.Werewolf, Creature.Snake, Creature.Spider, Creature.Bat, Creature.Hag, Creature.Imp, Creature.Sahuagin, Creature.WillOWisp, Creature.Geist);
            DomainEnum.Mordent.AddLocation(LocationEnum.HeatherHouse, "77, 97");
            DomainEnum.NovaVaasa.AddSettlement(Settlement.Kantora, "78");
            DomainEnum.NovaVaasa.AddSettlement(Settlement.Liara, "78");
            DomainEnum.NovaVaasa.AddSettlement(Settlement.Egertus, "78");
            DomainEnum.NovaVaasa.AddSettlement(Settlement.Bergovitsa, "78");
            DomainEnum.NovaVaasa.AddSettlement(Settlement.Arbora, "78");
            Creature.PlainsCat.ExtraInfo = "A black tailless creature that live in crevices in granite outcroppings and hunt on the plains by night. The females hunt in prides, dragging down horses or other sizeable mammals.";
            DomainEnum.Sithicus.AddLocation(LocationEnum.NedragaardKeep, "79");
            DomainEnum.Tepest.AddLocation(LocationEnum.TimoriRoad, "79");
            DomainEnum.Tepest.AddLocation(LocationEnum.LakeKronov, "79");
            DomainEnum.Tepest.AddSettlement(Settlement.Viktal, "79").BindCreatures(Creature.Goat, Creature.Sheep);
            DomainEnum.Tepest.AddSettlement(Settlement.Kellee, "79").BindCreatures(Creature.Goat, Creature.Sheep);
            DomainEnum.Richemulot.AddSettlement(Settlement.PontaMuseau, "80").BindLocations(LocationEnum.RenierEstate, LocationEnum.RiverMusarde);
            DomainEnum.Richemulot.AddSettlement(Settlement.StRonges, "80");
            DomainEnum.Richemulot.AddSettlement(Settlement.Mortigny, "80");
            DomainEnum.Valachan.AddSettlement(Settlement.Ungrad, "80");
            DomainEnum.Valachan.AddSettlement(Settlement.Rotwald, "80");
            DomainEnum.Valachan.AddSettlement(Settlement.Habelnik, "80");
            DomainEnum.Valachan.AddLocation(LocationEnum.CastlePantara, "80").BindCharacters(DarklordEnum.UrikVonKharkov);
            DomainEnum.Verbrek.AddLocation(LocationEnum.TheCircle, "81");
            DomainEnum.Farelle.AddSettlement(Settlement.Kaynis, "83");
            DomainEnum.Farelle.AddSettlement(Settlement.Mortilis, "83");
            DomainEnum.HarAkir.AddSettlement(Settlement.Muhar, "83");
            DomainEnum.Sanguinia.AddLocation(LocationEnum.MountRadu, "84");
            DomainEnum.Sanguinia.AddSettlement(Settlement.Tirgo, "84");
            DomainEnum.Sanguinia.AddSettlement(Settlement.Fagarus, "84");
            DomainEnum.Sanguinia.AddSettlement(Settlement.Kosova, "84");
            DomainEnum.Sanguinia.AddLocation(LocationEnum.CastleGuirgiu, "84, Map").BindCharacters(DarklordEnum.LadislavMircea);
            DomainEnum.Sanguinia.AddLocation(LocationEnum.LakeArgus, "84");
            DomainEnum.Souragne.AddSettlement(Settlement.PortdElhour, "84");
            DomainEnum.SriRaji.AddLocation(LocationEnum.YamashaMountains, "85");
            DomainEnum.SriRaji.AddLocation(LocationEnum.MountYamatali, "85");
            DomainEnum.StauntonBluffs.AddLocation(LocationEnum.CastleStonecrest, "85");
            DomainEnum.StauntonBluffs.AddSettlement(Settlement.Willisford, "85");
            DomainEnum.Vechor.AddSettlement(Settlement.Abdok, "86");
            DomainEnum.Vechor.AddLocation(LocationEnum.CliffsOfVesani, "86");
            DomainEnum.Paridon.AddSettlement(Settlement.Paridon, "86");
            DomainEnum.Mordent.AddLocation(LocationEnum.WeathermayMausoleum, "97").BindCharacters(DarklordEnum.WilfredGodefroy);
            DomainEnum.Mordent.AddLocation(LocationEnum.GryphonHillCemetery, "97").BindCharacters(CharacterEnum.LadyEstelleWeathermayGodefroy, CharacterEnum.PenelopeGodefroy);
            DomainEnum.Mordent.AddSettlement(Settlement.Mordentshire, "77, 97").BindCharacters(DarklordEnum.CountStrahd, DarklordEnum.AzalinRex, CharacterEnum.DoctorRudolphVanRichten).BindLocations(LocationEnum.HeatherHouse, LocationEnum.GryphonHill, LocationEnum.GryphonHillMansion, LocationEnum.WeathermayMausoleum, LocationEnum.GryphonHillCemetery);

            DomainEnum.Markovia.AddLocation(LocationEnum.Temple, "Map").BindLocations(LocationEnum.Balinoks);
            DomainEnum.Markovia.AddLocation(LocationEnum.Quarters, "Map").BindLocations(LocationEnum.Balinoks);
            DomainEnum.Markovia.AddLocation(LocationEnum.HallOfNecessity, "Map").BindLocations(LocationEnum.Balinoks);
            DomainEnum.Markovia.AddLocation(LocationEnum.Library, "Map").BindLocations(LocationEnum.Balinoks);
            DomainEnum.Markovia.AddLocation(LocationEnum.LiftHouse, "Map").BindLocations(LocationEnum.Balinoks);
            DomainEnum.Markovia.AddLocation(LocationEnum.ContemplationHall, "Map").BindLocations(LocationEnum.Balinoks);
            DomainEnum.Markovia.AddSettlement(Settlement.Monastery, "Map").BindDomains(DomainEnum.Barovia).BindLocations(LocationEnum.Balinoks).BindLocations(LocationEnum.Temple, LocationEnum.Quarters, LocationEnum.HallOfNecessity, LocationEnum.Library, LocationEnum.LiftHouse, LocationEnum.ContemplationHall);

            DomainEnum.GHenna.AddLocation(LocationEnum.YagnoPetrovnaTemple, "Map").BindCharacters(DarklordEnum.YagnoPetrovna, CharacterEnum.Zhakata).BindGroups(GroupEnum.Zhakata).BindCreatures(Creature.Mongrelman);
            DomainEnum.SriRaji.AddLocation(LocationEnum.ArijaniTemple, "Map").BindCharacters(DarklordEnum.Arijani, CharacterEnum.Kali, CharacterEnum.Rudra, CharacterEnum.Shiva, CharacterEnum.Ravana, CharacterEnum.Yama).BindGroups(GroupEnum.Kali, GroupEnum.Rudra, GroupEnum.Shiva, GroupEnum.Ravana, GroupEnum.Yama).BindLocations(LocationEnum.MountYamatali, LocationEnum.YamashaMountains);
            DomainEnum.Hazlan.AddLocation(LocationEnum.HazlikEstate, "Map").BindCharacters(DarklordEnum.Hazlik).BindLocations(Settlement.Toyalis);
            DomainEnum.Darkon.AddLocation(LocationEnum.AzalinCastle, "Map").BindCharacters(DarklordEnum.AzalinRex).BindLocations(Settlement.IlAluk).BindCreatures(Creature.Crow);
            DomainEnum.Darkon.AddLocation(LocationEnum.TheBoneHeap, "Map").BindLocations(Settlement.IlAluk).BindCreatures(Creature.Crow);
            DomainEnum.NovaVaasa.AddLocation(LocationEnum.HiregaardCastle, "Map").BindLocations(Settlement.Kantora).BindCharacters(DarklordEnum.TristenHiregaard);
            DomainEnum.Markovia.AddLocation(LocationEnum.MarkovEstate, "Map").BindGroups(GroupEnum.Dilisnya).BindLocations(LocationEnum.Balinoks).BindCharacters(DarklordEnum.FrantisekMarkov).BindCreatures(Creature.BeastMen);
            DomainEnum.Richemulot.AddLocation(LocationEnum.RenierEstate, "Map").BindGroups(GroupEnum.Renier).BindCharacters(DarklordEnum.JacquelineRenier, DarklordEnum.ClaudeRenier, CharacterEnum.LouiseRenier).BindLocations(Settlement.PontaMuseau, LocationEnum.RiverMusarde, LocationEnum.RiverArden);
            DomainEnum.Borca.AddLocation(LocationEnum.BoritsiEstate, "Map").BindGroups(GroupEnum.Boritsi).BindCharacters(DarklordEnum.IvanaBoritsi).BindLocations(Settlement.Levkarest, LocationEnum.Balinoks);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.VladDrakovCastle, "Map").BindGroups(GroupEnum.Drakov).BindCharacters(DarklordEnum.VladDrakov).BindLocations(Settlement.Lekar, LocationEnum.RiverVuchar);

            DomainEnum.Falkovnia.AddLocation(LocationEnum.BoyarsQuarters, "Map").BindLocations(Settlement.Lekar);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.BastionOfIron, "Map").BindLocations(Settlement.Lekar, LocationEnum.BoyarsQuarters);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.MerchantsQuarters, "Map").BindLocations(Settlement.Lekar);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.DocksLekar, "Map").BindLocations(Settlement.Lekar, LocationEnum.MerchantsQuarters);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.Harbour, "Map").BindLocations(Settlement.Lekar, LocationEnum.MerchantsQuarters);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.LaborersQuarters, "Map").BindLocations(Settlement.Lekar);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.OpenMarket, "Map").BindLocations(Settlement.Lekar, LocationEnum.LaborersQuarters);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.GateOfJustice, "Map").BindLocations(Settlement.Lekar, LocationEnum.LaborersQuarters);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.Slaughterhouse, "Map").BindLocations(Settlement.Lekar, LocationEnum.LaborersQuarters);

            DomainEnum.Dementlieu.AddLocation(LocationEnum.GovernmentQuarter, "Map").BindLocations(Settlement.PortaLucine);
            DomainEnum.Dementlieu.AddLocation(LocationEnum.DocksPortALucine, "Map").BindLocations(Settlement.PortaLucine);
            DomainEnum.Dementlieu.AddLocation(LocationEnum.QuartierMarchard, "Map").BindLocations(Settlement.PortaLucine);
            DomainEnum.Dementlieu.AddLocation(LocationEnum.GuildHalls, "Map").BindLocations(Settlement.PortaLucine);
            DomainEnum.Dementlieu.AddLocation(LocationEnum.RuinsOfSteMeredesLarmes, "Map").BindLocations(Settlement.PortaLucine);
            DomainEnum.Dementlieu.AddLocation(LocationEnum.LaborerTenements, "Map").BindLocations(Settlement.PortaLucine);

            DomainEnum.Falkovnia.AddLocation(LocationEnum.UpperCitySilbervas, "Map").BindLocations(Settlement.Silbervas);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.SummerPalace, "Map").BindLocations(Settlement.Silbervas, LocationEnum.UpperCitySilbervas);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.LowerCitySilbervas, "Map").BindLocations(Settlement.Silbervas);
            DomainEnum.Falkovnia.AddLocation(LocationEnum.NachtfliegenWoods, "Map");

            DomainEnum.Darkon.AddSettlement(Settlement.Despondia, "Map").BindLocations(Settlement.IlAluk);
            DomainEnum.Darkon.AddLocation(LocationEnum.NorthCanal, "Map").BindLocations(Settlement.IlAluk, Settlement.Desolatus, Settlement.Despondia);
            DomainEnum.Darkon.AddLocation(LocationEnum.SouthCanal, "Map").BindLocations(Settlement.IlAluk, Settlement.Decimus);
            DomainEnum.Darkon.AddSettlement(Settlement.Decimus, "Map").BindLocations(Settlement.IlAluk);
            DomainEnum.Darkon.AddSettlement(Settlement.Desolatus, "Map").BindLocations(Settlement.IlAluk);
            DomainEnum.Darkon.AddSettlement(Settlement.Desolatus, "Map").BindLocations(Settlement.IlAluk);

            DomainEnum.Lamordia.AddLocation(LocationEnum.TheFinger, "Map");
            DomainEnum.Lamordia.AddLocation(LocationEnum.BlackRiver, "Map").BindLocations(Settlement.Ludendorf);
            DomainEnum.Lamordia.AddLocation(LocationEnum.OuterWard, "Map").BindLocations(Settlement.Ludendorf);
            DomainEnum.Lamordia.AddLocation(LocationEnum.AubreckerCastle, "Map");
            DomainEnum.Lamordia.AddLocation(LocationEnum.AbandonedEstate, "Map");

            DomainEnum.Darkon.AddLocation(LocationEnum.UpperCityKarg, "Map").BindLocations(Settlement.Karg);
            DomainEnum.Darkon.AddLocation(LocationEnum.MausoleumsKarg, "Map").BindLocations(Settlement.Karg, LocationEnum.UpperCityKarg);
            DomainEnum.Darkon.AddLocation(LocationEnum.LowerCityKarg, "Map").BindLocations(Settlement.Karg);
            DomainEnum.Darkon.AddLocation(LocationEnum.GraveyardKarg, "Map").BindLocations(Settlement.Karg, LocationEnum.LowerCityKarg);

            DomainEnum.Mordent.AddLocation(LocationEnum.BurnedChurch, "Map").BindLocations(Settlement.Mordentshire);
            DomainEnum.Mordent.AddLocation(LocationEnum.OldMill, "Map").BindLocations(Settlement.Mordentshire);
            DomainEnum.Mordent.AddLocation(LocationEnum.MillRoad, "Map").BindLocations(Settlement.Mordentshire, LocationEnum.OldMill, Settlement.Chateaufaux);
            DomainEnum.Mordent.AddLocation(LocationEnum.Barracks, "Map").BindLocations(Settlement.Mordentshire);
            DomainEnum.Mordent.AddLocation(LocationEnum.Gaol, "Map").BindLocations(Settlement.Mordentshire);
            DomainEnum.Mordent.AddLocation(LocationEnum.MayorsHouse, "Map").BindLocations(Settlement.Mordentshire);
            DomainEnum.Mordent.AddLocation(LocationEnum.HiddenTrack, "Map").BindLocations(Settlement.Mordentshire);
            DomainEnum.Mordent.AddLocation(LocationEnum.WeathermayMausoleum, "Map").BindLocations(Settlement.Mordentshire);
            DomainEnum.Mordent.AddLocation(LocationEnum.SaulbridgeSanitarium, "Map").BindLocations(Settlement.Mordentshire);
            DomainEnum.Mordent.AddLocation(LocationEnum.Marketplace, "Map").BindLocations(Settlement.Mordentshire);
            DomainEnum.Mordent.AddLocation(LocationEnum.LostRoad, "Map").BindLocations(Settlement.Mordentshire);

            DomainEnum.Barovia.AddLocation(LocationEnum.BaroviaChurch, "Map").BindLocations(Settlement.Barovia);
            DomainEnum.Barovia.AddLocation(LocationEnum.BurgomasterHome, "Map").BindLocations(Settlement.Barovia);
            DomainEnum.Barovia.AddSettlement(Settlement.TserPoolEncampnent, "Map").BindLocations(LocationEnum.TserPool);
            DomainEnum.Barovia.AddLocation(LocationEnum.TserPool, "Map");
            DomainEnum.Barovia.AddLocation(LocationEnum.GatesOfBarovia, "Map");

            DomainEnum.Borca.AddLocation(LocationEnum.LevkarestFerry, "Map").BindLocations(Settlement.Levkarest, LocationEnum.RiverLuna);
            DomainEnum.Borca.AddLocation(LocationEnum.FenBridge, "Map").BindLocations(Settlement.Levkarest);

            DomainEnum.Falkovnia.AddSettlement(Settlement.Morfenzi, "Map");
            DomainEnum.GHenna.AddSettlement(Settlement.Dervich, "Map");
            DomainEnum.Darkon.AddLocation(LocationEnum.TempeRiver, "Map");
            DomainEnum.Keening.AddLocation(LocationEnum.MountLament, "Map");
            DomainEnum.Sithicus.AddSettlement(Settlement.MalErek, "Map");
            DomainEnum.Sithicus.AddSettlement(Settlement.Hroth, "Map");
            DomainEnum.Sithicus.AddSettlement(Settlement.HarThelen, "Map");

            DomainEnum.StauntonBluffs.AddLocation(LocationEnum.WillisRiver, "Map");
            DomainEnum.Vechor.AddLocation(LocationEnum.NostruRiver, "Map");
            DomainEnum.HarAkir.AddLocation(LocationEnum.PharaohsRest, "Map");
            DomainEnum.Souragne.AddLocation(LocationEnum.Tristepas, "Map");
            DomainEnum.Souragne.AddLocation(LocationEnum.LakeNoir, "Map");
            DomainEnum.SriRaji.AddSettlement(Settlement.Muladi, "Map").BindLocations(LocationEnum.LakeVeda);
            DomainEnum.SriRaji.AddLocation(LocationEnum.LakeVeda, "Map");
            DomainEnum.SriRaji.AddSettlement(Settlement.Pakat, "Map");
            DomainEnum.SriRaji.AddSettlement(Settlement.Tvashsti, "Map");
            DomainEnum.Paridon.AddLocation(LocationEnum.RhastikRiver, "Map");
            DomainEnum.Farelle.AddLocation(LocationEnum.MourfaRiver, "Map");
            #endregion

            #region Items
            DomainEnum.Barovia.AddItem(ItemEnum.Book.TomeOfStrahd, "2, 8, 116");
            DomainEnum.InsideRavenloft.AddItem(ItemEnum.Drink.Aniso, "37").BindGroups(GroupEnum.Vistani).ExtraInfo = "A drink flavoured with aniseed.";
            DomainEnum.InsideRavenloft.AddItem(ItemEnum.Scroll.Return, "55");
            DomainEnum.Barovia.AddItem(ItemEnum.SymbolOfRaven, "56");
            DomainEnum.Mordent.AddItem(ItemEnum.Apparatus, "56-57").BindItems(ItemEnum.Rod.Rastinon);
            DomainEnum.Mordent.AddItem(ItemEnum.Rod.Rastinon, "56-57");
            DomainEnum.Mordent.AddItem(ItemEnum.SoulSearcher, "57");
            DomainEnum.Mordent.AddItem(ItemEnum.Ring.Reverse, "57");
            DomainEnum.Mordent.AddItem(ItemEnum.Amulet.BeastSilver, "57-58");
            DomainEnum.Mordent.AddItem(ItemEnum.Amulet.BeastIvory, "57-58").BindCreatures(Creature.Werewolf);
            DomainEnum.Arak.AddItem(ItemEnum.SwordOfArak, "58").BindDomains(DomainEnum.InsideRavenloft).BindCreatures(Creature.Drow)
                .BindAlignment(Alignment.LE | Alignment.NE | Alignment.CE);
            DomainEnum.Valachan.AddItem(ItemEnum.CatOfFelkovic, "58").BindCreatures(Creature.Smilodon, Creature.HouseCat, Creature.GiantLynx, Creature.Cheetah, Creature.MountainLion, Creature.Leopard, Creature.Jaguar, Creature.Lion, Creature.Tiger, Creature.SpottedLion);
            DomainEnum.Barovia.AddItem(ItemEnum.Drink.Tuika, "64").ExtraInfo = "Brandywine made from plums.";
            DomainEnum.Falkovnia.AddItem(ItemEnum.VigilaDimorta, "69").ExtraInfo = "Special trees.";
            DomainEnum.Kartakass.AddItem(ItemEnum.Food.Meekulbern, "74").BindItems(ItemEnum.Drink.Meekulbrau)
                .ExtraInfo = "Wild berry found in thorny thickets on hills.";
            DomainEnum.Kartakass.AddItem(ItemEnum.Drink.Meekulbrau, "74").ExtraInfo = "Made from Meekulbern berries.";
            DomainEnum.Darkon.AddItem(ItemEnum.Ring.Wizard, "92");
            DomainEnum.Darkon.AddItem(ItemEnum.Wand.Frost, "92");
            DomainEnum.Darkon.AddItem(ItemEnum.HelmCompreLng, "92");
            DomainEnum.Darkon.AddItem(ItemEnum.AzalinPhylactery, "93");
            DomainEnum.Hazlan.AddItem(ItemEnum.HazlikPendant, "99-100");
            DomainEnum.InsideRavenloft.AddItem(ItemEnum.Amulet.VsUnd, "101").BindDomains(DomainEnum.Hazlan);
            DomainEnum.Kartakass.AddItem(ItemEnum.Elixir.Mad, "102");
            DomainEnum.Kartakass.AddItem(ItemEnum.CursedBerserker, "102-103");
            DomainEnum.Kartakass.AddItem(ItemEnum.HarkonHarp, "103").BindCreatures(Creature.DireWolf);
            DomainEnum.Lamordia.AddItem(ItemEnum.Book.JournalOfVictorMordenheim, "106-108");
            DomainEnum.Mordent.AddItem(ItemEnum.VialOfHolyWater, "114, 119");
            DomainEnum.Barovia.AddItem(ItemEnum.StrahdCrystalBall, "118");
            DomainEnum.Barovia.AddItem(ItemEnum.Amulet.Proof, "118");
            DomainEnum.Barovia.AddItem(ItemEnum.Cloak.Prot, "118");
            DomainEnum.Barovia.AddItem(ItemEnum.Ring.FireRes, "118");
            #endregion

            #region Groups
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.Vistani, "2, 4, 9, 35-41, 60, 63, 65, 73, 75-76, 89-90, 114, 117, 120").BindItems(ItemEnum.Drink.Aniso)
                .BindCreatures(Creature.Human, Creature.Horse, Creature.Dog, Creature.Ox, Creature.Goat, Creature.Chicken, Creature.Bear, Creature.VistaChiri);
            Creature.VistaChiri.ExtraInfo = "Tiny gray and white bird.";
            DomainEnum.InsideRavenloft.AddGroup(GroupEnum.DarkPowers, "15, 17-19, 27, 50, 55, 76, 79, 89, 102, 111-112, 116, 118");
            DomainEnum.Barovia.AddGroup(GroupEnum.HighPriestRavenloft, "56").BindItems(ItemEnum.SymbolOfRaven);
            DomainEnum.Barovia.AddGroup(GroupEnum.Burgomaster, "63");
            DomainEnum.Barovia.AddGroup(GroupEnum.Boyar, "63");
            DomainEnum.Darkon.AddGroup(GroupEnum.TheKargat, "67").BindCreatures(Creature.Vampire);
            DomainEnum.GHenna.AddGroup(GroupEnum.Zhakata, "70-71, 109");
            DomainEnum.Kartakass.AddGroup(GroupEnum.Meistersinger, "73-74").BindCharacters(DarklordEnum.HarkonLukas);
            DomainEnum.Markovia.AddGroup(GroupEnum.Diosamblet, "76").BindCreatures(Creature.BeastMen).BindCharacters(DarklordEnum.FrantisekMarkov);
            DomainEnum.Tepest.AddGroup(GroupEnum.HagsOfTepest, "79").BindCreatures(Creature.AnnisHag, Creature.GreenHag, Creature.SeaHag);
            DomainEnum.SriRaji.AddGroup(GroupEnum.Kali, "85, Map").BindDomains(DomainEnum.OutsideRavenloft).BindCharacters(DarklordEnum.Arijani, CharacterEnum.Kali);
            DomainEnum.SriRaji.AddGroup(GroupEnum.Rudra, "Map").BindDomains(DomainEnum.OutsideRavenloft).BindCharacters(DarklordEnum.Arijani, CharacterEnum.Rudra);
            DomainEnum.Falkovnia.AddGroup(GroupEnum.TalonOfTheHawk, "95-96").BindDomains(DomainEnum.OutsideRavenloft, DomainEnum.Darkon).BindSetting(CampaignSetting.Dragonlance);
            DomainEnum.Verbrek.AddGroup(GroupEnum.WolfGod, "112").BindCharacters(DarklordEnum.AlfredTimothy, CharacterEnum.WolfGod);
            DomainEnum.Borca.AddGroup(GroupEnum.Boritsi, "121").BindDomains(DomainEnum.Barovia).BindCharacters(CharacterEnum.Dorfniya, CharacterEnum.GuntherCosco, CharacterEnum.LeoDilisnya, CharacterEnum.LevDilisnya, CharacterEnum.NikiRomanoff, CharacterEnum.ElenaAlmeida, CharacterEnum.YakovDilisnya, CharacterEnum.OleskaDilisnya, CharacterEnum.StepanDilisnya, CharacterEnum.AnnaKurdzeil, CharacterEnum.TadeuszPaldo, CharacterEnum.RichtorDilisnya, DarklordEnum.CamilleDilisnya, CharacterEnum.SiegfriedGrymig, CharacterEnum.MariaDiazi, CharacterEnum.KlausBoritsi, CharacterEnum.StepanTaroyan, CharacterEnum.Brunhilda, CharacterEnum.OlehFortich, DarklordEnum.IvanaBoritsi, CharacterEnum.AbelardoLeoni, CharacterEnum.NikoliChesniak, CharacterEnum.AlexanderManduchi, CharacterEnum.SuloBoritsi, CharacterEnum.LuciaRitter, CharacterEnum.AntonBoritsi, CharacterEnum.KatarinaPiechota);
            DomainEnum.Dementlieu.AddGroup(GroupEnum.Boritsi, "122").BindDomains(DomainEnum.Mordent).BindCharacters(CharacterEnum.Germain, CharacterEnum.AliciaCorgiat, CharacterEnum.Bernadette, CharacterEnum.HuguesMousel, CharacterEnum.FrancoisMousel, CharacterEnum.JoelieFontaine, CharacterEnum.MadeleineMousel, CharacterEnum.RaymondeBiourne, CharacterEnum.Claude, CharacterEnum.ErnestinePasier, CharacterEnum.BabetteBatista, CharacterEnum.Maurice, CharacterEnum.AliciaNorberte, CharacterEnum.Julienne, CharacterEnum.BernardLoverde, CharacterEnum.Gerard, DarklordEnum.DominicdHonaire, CharacterEnum.LouisePecquet, CharacterEnum.LouiseGirod, CharacterEnum.DominicdHonaire2);
            DomainEnum.Dorvinia.AddGroup(GroupEnum.Dilisnya, "123").BindDomains(DomainEnum.Barovia).BindCharacters(CharacterEnum.PidlwickDilisnya, CharacterEnum.Dorfniya, CharacterEnum.GuntherCosco, CharacterEnum.LeoDilisnya, CharacterEnum.ReinholdDilisnya, CharacterEnum.NadiaYakimov, CharacterEnum.GertudeDilisnya, CharacterEnum.IvanBuchvold, CharacterEnum.OlekaDilisnya, CharacterEnum.VictorWachter, CharacterEnum.LovinaWachter, CharacterEnum.AnnaSpachuk, CharacterEnum.RomanDilisnya, CharacterEnum.CamilleYakimov, CharacterEnum.NataliaOlszanik, CharacterEnum.FredrikDilisnya, CharacterEnum.TaraYanoff, CharacterEnum.BorisDilisnya, CharacterEnum.StefaniaSeptow, CharacterEnum.KatinaDilisnya, CharacterEnum.HassligDilisnya, CharacterEnum.KristinaDilisnya, CharacterEnum.EdgarLeskovich, DarklordEnum.IvanDilisnya, CharacterEnum.Lucretia);
            DomainEnum.Falkovnia.AddGroup(GroupEnum.Drakov, "124").BindCharacters(DarklordEnum.VladDrakov, CharacterEnum.NadiaRuzich, CharacterEnum.IreenaImlach, CharacterEnum.YuriMitrovic, CharacterEnum.LelaDekovan, CharacterEnum.GriseldaZamiara, CharacterEnum.MikhailDrakov, CharacterEnum.OlanaCrepeau, CharacterEnum.NatashaDrakov, CharacterEnum.LevKrenkovich, CharacterEnum.VladDrakov2, CharacterEnum.TatyanaOstevic, CharacterEnum.VladDrakov3, CharacterEnum.KaraDrakov, CharacterEnum.DmitriLikarevie, CharacterEnum.MirceaDrakov, CharacterEnum.AnnaHatziavas, CharacterEnum.TaraYanoff, CharacterEnum.SzotaDrakov, CharacterEnum.PeterVonBorstel);
            DomainEnum.Richemulot.AddGroup(GroupEnum.Renier, "125").BindDomains(DomainEnum.Falkovnia).BindCharacters(DarklordEnum.ClaudeRenier, CharacterEnum.IsabelleMoseau, CharacterEnum.AnaisRenier, CharacterEnum.HenriMilette, CharacterEnum.MarieRenier, CharacterEnum.SimonAudaire, CharacterEnum.EduardoRenier, CharacterEnum.MargueritePentarde, CharacterEnum.JoelleMilette, CharacterEnum.GregoireAlairan, CharacterEnum.MauriceMilette, CharacterEnum.EliseDeLauren, CharacterEnum.PierreRenier, CharacterEnum.GerardRenier, CharacterEnum.SandrineDaugeri, CharacterEnum.AntionetteRenier, CharacterEnum.LaurrentHaurie, CharacterEnum.JacquesRenier, CharacterEnum.DominicSoufel, CharacterEnum.JacquesRenier, CharacterEnum.LouiseRenier, CharacterEnum.RaulRenier, CharacterEnum.GertrudeVonZarovich);
            DomainEnum.Arkandale.AddGroup(GroupEnum.Timothy, "126").BindDomains(DomainEnum.Mordent, DomainEnum.Verbrek).BindCharacters(CharacterEnum.CainTimothy, CharacterEnum.ElizabethTimothy, CharacterEnum.SeanTimothy, CharacterEnum.EstherTimothy, CharacterEnum.RichtorDilisnya, CharacterEnum.VirginiaDilisnya, CharacterEnum.RichardRatcliff, CharacterEnum.WinifredRatcliff, CharacterEnum.MichaelRatcliff, CharacterEnum.CharlotteWinchester, CharacterEnum.CliffordDilisnya, CharacterEnum.CynthiaHerbert, CharacterEnum.EowinTimothy, CharacterEnum.EmilyGerhardt, CharacterEnum.IreneTimothy, CharacterEnum.FranklinDodds, CharacterEnum.ThomasDodds, CharacterEnum.PatriciaRichards, DarklordEnum.NathanTimothy, CharacterEnum.PriscillaSchilling, CharacterEnum.ArabellaTimothy, CharacterEnum.WilliamTimothy, CharacterEnum.EvelynWesterfield, CharacterEnum.LawrenceTimothy, CharacterEnum.EsterTimothy, CharacterEnum.CharlesNickerson, DarklordEnum.AlfredTimothy);
            DomainEnum.Barovia.AddGroup(GroupEnum.VonZarovich, "127").BindDomains(DomainEnum.OutsideRavenloft).BindCharacters(CharacterEnum.KingBarov, CharacterEnum.Ravenovia, DarklordEnum.CountStrahd, CharacterEnum.Sturm, CharacterEnum.GisellaFallona, CharacterEnum.Sergei, CharacterEnum.Tatyana, CharacterEnum.AnnaVonZarovich, CharacterEnum.TodHeitman, CharacterEnum.SiskaVonZarovich, CharacterEnum.IvanReichhardt, CharacterEnum.KatarinaVonZarovich, CharacterEnum.HolgarVonZarovich, CharacterEnum.IsoldeVonKoss, CharacterEnum.NatashaItskovich, CharacterEnum.GeierVonZarovich, CharacterEnum.IvanVonZarovich, CharacterEnum.NataliaAndas, CharacterEnum.PeterVonZarovich, CharacterEnum.KatarinaDragus, CharacterEnum.YsildeVonZarovich, CharacterEnum.SergeiVonZarovich2, CharacterEnum.IreenaKolokoff, CharacterEnum.BarovVonZarovich2, CharacterEnum.ElsaDrache, CharacterEnum.AndreaVonZarovich, CharacterEnum.KlausVonZarovich, CharacterEnum.VictorVonZarovich, CharacterEnum.LisbethVonZarovich, CharacterEnum.VasiliGeistlinger, CharacterEnum.MyroslavVonZarovich, CharacterEnum.MarlenaLeibnik, CharacterEnum.GertudeDilisnya, CharacterEnum.RaulRenier, CharacterEnum.HansVonZarovich).ExtraInfo = "Most of them are outside of Ravenloft.";
            DomainEnum.Mordent.AddGroup(GroupEnum.Weathermay, "128").BindCharacters(CharacterEnum.LordWeathermay, CharacterEnum.OldLadyWeathermay, CharacterEnum.LadyWeathermay, CharacterEnum.LadyEstelleWeathermayGodefroy, DarklordEnum.WilfredGodefroy, CharacterEnum.LiliaGodefroy, CharacterEnum.HenryLeighton, CharacterEnum.ElizabethWeathermay, CharacterEnum.PrudenceWeathermay, CharacterEnum.TorrenceSeabag, CharacterEnum.VivianSeabag, CharacterEnum.DonaldSherwood, CharacterEnum.HelenSeabag, CharacterEnum.JulesWeathermay, CharacterEnum.MarthaScoville, CharacterEnum.AliceWeathermay, CharacterEnum.DanielFoxgrove, CharacterEnum.GeorgeWeathermay);
            DomainEnum.SriRaji.AddGroup(GroupEnum.Rudra, "Map").BindDomains(DomainEnum.OutsideRavenloft).BindCharacters(DarklordEnum.Arijani, CharacterEnum.Rudra);
            DomainEnum.SriRaji.AddGroup(GroupEnum.Shiva, "Map").BindDomains(DomainEnum.OutsideRavenloft).BindCharacters(DarklordEnum.Arijani, CharacterEnum.Shiva);
            DomainEnum.SriRaji.AddGroup(GroupEnum.Ravana, "Map").BindDomains(DomainEnum.OutsideRavenloft).BindCharacters(DarklordEnum.Arijani, CharacterEnum.Ravana);
            DomainEnum.SriRaji.AddGroup(GroupEnum.Yama, "Map").BindDomains(DomainEnum.OutsideRavenloft).BindCharacters(DarklordEnum.Arijani, CharacterEnum.Yama);
            #endregion
        }
    }
}