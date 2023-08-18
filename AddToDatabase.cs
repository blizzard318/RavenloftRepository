using System.Collections.Generic;
using static Relationship;

internal static class AddToDatabase
{
    public static void Add (RavenloftContext db) 
    {
        T Add <T>(T input) where T : class => db.Add(input).Entity;
        T AddApp<T> (Source source, T input, params int[] pageNumbers)
        {
                 if (typeof(T) == typeof(Trait))
                db.Add(new TraitAppearance   (source, input as Trait,    pageNumbers));

            else if (typeof(T) == typeof(Location))
                db.Add(new LocationAppearance(source, input as Location, pageNumbers));

            else if (typeof(T) == typeof(NPC))
                db.Add(new NPCAppearance     (source, input as NPC,      pageNumbers));

            else if (typeof(T) == typeof(Domain))
                db.Add(new DomainAppearance  (source, input as Domain,   pageNumbers));

            else if (typeof(T) == typeof(Item))
                db.Add(new ItemAppearance    (source, input as Item,     pageNumbers));

            return input;
        }

        #region Universal Traits
        //Editions
        var e0  = Add(new SourceTrait("Editionless"  , "Edition"));
        e0.ExtraInfo = "Everything here are official products that do not belong to any edition of D&D.";
        var e1  = Add(new SourceTrait("1st Edition"  , "Edition"));
        var e2  = Add(new SourceTrait("2nd Edition"  , "Edition"));
        var e3  = Add(new SourceTrait("3rd Edition"  , "Edition"));
        var e35 = Add(new SourceTrait("3.5th Edition", "Edition"));
        var e4  = Add(new SourceTrait("4th Edition"  , "Edition"));
        var e5  = Add(new SourceTrait("5th Edition"  , "Edition"));

        //Canonicity
        var pc = Add(new SourceTrait("Potentially Canon", "Canon"));
        var nc = Add(new SourceTrait("Not Canon"        , "Canon"));
        nc.ExtraInfo = pc.ExtraInfo = "Unless explicity stated as 'Potentially Canon' or 'Not Canon', everything else is treated Canon.";

        //Source types
        var comic      = Add(new SourceTrait("Comic"      , "Media"));
        var module     = Add(new SourceTrait("Module"     , "Media"));
        var novel      = Add(new SourceTrait("Novel"      , "Media"));
        var gamebook   = Add(new SourceTrait("Gamebook"   , "Media"));
        var sourcebook = Add(new SourceTrait("Sourcebook" , "Media"));
        var magazine   = Add(new SourceTrait("Magazine"   , "Media"));
        var videogame  = Add(new SourceTrait("Video Game" , "Media"));
        var boardgame  = Add(new SourceTrait("Board Game" , "Media"));

        //Locations
        var Mistway  = Add(new Trait("Mistway", "Location"));
        var Cluster  = Add(new Trait("Cluster", "Location"));

        //Exclusive to Ravenloft Types
        var Vistani  = Add(new Trait("Vistani" , "Group,Status,Location,Item"));
        var Darklord = Add(new Trait("Darklord", "Status,Location"));
        Darklord.ExtraInfo = "Locations tagged as Darklord are their Lairs.";

        //Alignment
        var LG = Add(new Trait("Lawful Good"    , "Alignment"));
        var NG = Add(new Trait("Neutral Good"   , "Alignment"));
        var CG = Add(new Trait("Chaotic Good"   , "Alignment"));
        var LN = Add(new Trait("Lawful Neutral" , "Alignment"));
        var TN = Add(new Trait("True Neutral"   , "Alignment"));
        var CN = Add(new Trait("Chaotic Neutral", "Alignment"));
        var LE = Add(new Trait("Lawful Evil"    , "Alignment"));
        var NE = Add(new Trait("Neutral Evil"   , "Alignment"));
        var CE = Add(new Trait("Chaotic Evil"   , "Alignment"));

        //Item traits
        var Mundane = Add(new Trait("Mundane", "Item"));
        var Magical = Add(new Trait("Magical", "Item"));
        var Melee   = Add(new Trait("Melee"  , "Item"));
        var Ranged  = Add(new Trait("Ranged" , "Item"));
        var Armor   = Add(new Trait("Armor"  , "Item"));

        //Classes
        var Cleric    = Add(new Trait("Cleric"    , "Class"));
        var Fighter   = Add(new Trait("Fighter"   , "Class"));
        var MagicUser = Add(new Trait("Magic User", "Class"));
        var Thief     = Add(new Trait("Thief"     , "Class"));

        //Status
        var Deceased = Add(new Trait("Deceased", "Status"));
        var Raunie   = Add(new Trait("Raunie"  , "Status"));

        //Languages
        var Common = Add(new Trait("Common", "Language"));

        //Races
        var Human = Add(new Trait("Human", "Race"));
        var Elf   = Add(new Trait("Elf"  , "Race"));

        // ## Add these with to page count.
        //Groups
        var BarovianWineDistillersBrotherhood = Add(new Trait("Barovian Wine Distillers Brotherhood", "Group"));

        //Creature Types
        var Wolf  = Add(new Trait("Wolf" , "Creature"));
        var Bat   = Add(new Trait("Bat"  , "Creature"));
        var Horse = Add(new Trait("Horse", "Creature"));
        var Cat   = Add(new Trait("Cat"  , "Creature"));
        var GiantSpider = Add(new Trait("Giant Spider", "Creature"));
        var HugeSpider  = Add(new Trait("Huge Spider" , "Creature"));

        var Worg = Add(new Trait("Worg", "Creature"));
        var Nightmare = Add(new Trait("Nightmare", "Creature"));
        var Hellhound = Add(new Trait("Hellhound", "Creature"));
        var GreenSlime = Add(new Trait("Green Slime", "Creature"));
        var Gargoyles = Add(new Trait("Gargoyles", "Creature"));
        var RustMonster = Add(new Trait("Rust Monster", "Creature"));
        var RedDragon = Add(new Trait("Red Dragon", "Creature"));
        var GuardianPortrait = Add(new Trait("Guardian Portrait", "Creature"));
        var ShadowDemon = Add(new Trait("Shadow Demon", "Creature"));
        var IronGolem = Add(new Trait("Iron Golem", "Creature"));
        var Trapper = Add(new Trait("Trapper", "Creature"));

        var Spirit      = Add(new Trait("Spirit", "Creature"));
        var Ghost       = Add(new Trait("Ghost", "Creature"));
        var Wraith      = Add(new Trait("Wraith", "Creature"));
        var Spectre     = Add(new Trait("Spectre", "Creature"));
        var Banshee     = Add(new Trait("Banshee", "Creature"));
        var KeeningSpirit = Add(new Trait("Keening Spirit", "Creature"));
        KeeningSpirit.ExtraInfo = "Also known as 'Groaning Spirit'";

        var StrahdZombie = Add(new Trait("Strahd Zombie", "Creature"));
        var Zombie       = Add(new Trait("Zombie", "Creature"));
        var Skeleton     = Add(new Trait("Skeleton", "Creature"));

        var Vampire = Add(new Trait("Vampire", "Creature"));
        var Ghoul   = Add(new Trait("Ghoul"  , "Creature"));
        var Wight   = Add(new Trait("Wight"  , "Creature"));

        var Witch    = Add(new Trait("Witch"   , "Creature"));
        var Werewolf = Add(new Trait("Werewolf", "Creature"));
        #endregion

        #region Mistways
        #endregion

        #region Clusters
        #endregion

        //Domains, NPCs, Items and Locations are Source-locked, but not Traits.

        AddI6Ravenloft();
        void AddI6Ravenloft()
        {
            var I6Ravenloft = Add(new Source("I6: Ravenloft", new[] { e1, module }));
            I6Ravenloft.ReleaseDate = new DateTime(1983, 11, 1);
            I6Ravenloft.ExtraInfo = "Authors: Tracy Hickman and Laura Hickman\nEditor: Curtis Smith\n";
            I6Ravenloft.ExtraInfo += "Graphic Designer: Debra Stubbe\nIllustrator: Clyde Caldwell\n";
            I6Ravenloft.ExtraInfo += "ModuleInfo:An adventure for 6-8 characters of levels 5-7";

            AddApp(I6Ravenloft, Vampire);
            AddApp(I6Ravenloft, Human);

            var Barovia = AddApp(I6Ravenloft, Add(new Domain("Barovia")));
            Cross.Add(
                domains: new[] { Barovia },
                traits: new[] { Vampire, Human }
            );
            return;

            /*var Strahd = AddApp(I6Ravenloft, Add(new NPC("Count Strahd von Zarovich")));
            Cross.Add(
                domains: new[] { Barovia },
                npcs: new[] { Strahd },
                traits: new[] { Vampire, Human, CE, MagicUser, Darklord }
            );
            Strahd.ExtraInfo = "'ClosedBorders':'No one has left Barovia for centuries. This is because of the trapping fog that exists everywhere in Barovia. Once it is breathed, it infuses itself around a character's vital organs as a neutralized poison. The fog does not taste or smell any different than normal fog. It does not harm characters as long as they continue to breathe the air in Barovia. However, when they leave Barovia, the poison becomes active. Characters must save vs. poison or start to choke. Unless choking characters reenter Barovia within 24 hours, they die. The choking stops as soon as they breathe the fog again.  The fog is magically produced by Strahd and disappears entirely upon his destruction.'";

            var MadamEva = AddApp(I6Ravenloft, new NPC("Madam Eva"), 1, 6);
            Cross.Add(
                domains: new[] { Barovia },
                npcs: new[] { MadamEva },
                traits: new[] { Vistani, Human, CN, Cleric, Raunie }
            );

            var KolyanIndirovich = AddApp(I6Ravenloft, new NPC("Kolyan Indirovich"), 7, 8, 9);
            Cross.Add(
                domains: new[] { Barovia },
                npcs: new[] { KolyanIndirovich },
                traits: new[] { Deceased, Human }
            );

            var IreenaKolyana = AddApp(I6Ravenloft, new NPC("Ireena Kolyana"));
            Cross.Add(
                domains: new[] { Barovia },
                npcs: new[] { IreenaKolyana },
                traits: new[] { Fighter, Human, LG }
            );

            var Bildrath = AddApp(I6Ravenloft, new NPC("Bildrath"), 8);
            Cross.Add(
                domains: new[] { Barovia },
                npcs: new[] { Bildrath },
                traits: new[] { Fighter, Human, LG }
            );
            Cross.Add(Bildrath, LN);
            Cross.Add(Bildrath, Human);
            Cross.Add(Bildrath, Barovia);
            Cross.Add(Bildrath, Fighter);

            var Parriwimple = AddApp(I6Ravenloft, new NPC("Parriwimple"), 8);
            Cross.Add(Bildrath, LN);
            Cross.Add(Parriwimple, Human);
            Cross.Add(Parriwimple, Barovia);
            Cross.Add(Parriwimple, Fighter);

            var Arik = AddApp(I6Ravenloft, new NPC("Arik"), 8);
            Cross.Add(Arik, CN);
            Cross.Add(Arik, Human);
            Cross.Add(Arik, Barovia);
            Cross.Add(Arik, Fighter);

            var Ismark = AddApp(I6Ravenloft, new NPC("Ismark the Lesser"), 8, 9);
            Cross.Add(Ismark, LG);
            Cross.Add(Ismark, Human);
            Cross.Add(Ismark, Barovia);

            var Sergei = AddApp(I6Ravenloft, new NPC("Sergei von Zarovich"), 1, 4, 30, 31);
            Cross.Add(Sergei, Deceased);
            Cross.Add(Sergei, Human);
            Cross.Add(Sergei, Barovia);

            var Ravenovia = AddApp(I6Ravenloft, new NPC("Queen Ravenovia"), 5, 30);
            Cross.Add(Sergei, Deceased);
            Cross.Add(Sergei, Human);
            Cross.Add(Sergei, Barovia);

            var MadMary = AddApp(I6Ravenloft, new NPC("Mad Mary"), 9, 19);
            Cross.Add(MadMary, CN);
            Cross.Add(MadMary, Human);
            Cross.Add(MadMary, Barovia);
            Cross.Add(MadMary, Fighter);

            var Gertruda = AddApp(I6Ravenloft, new NPC("Gertruda"), 9, 19);
            Cross.Add(Gertruda, NG);
            Cross.Add(Gertruda, Human);
            Cross.Add(Gertruda, Barovia);

            var Donavich = AddApp(I6Ravenloft, new NPC("Donavich"), 9);
            Cross.Add(Donavich, LG);
            Cross.Add(Donavich, Human);
            Cross.Add(Donavich, Barovia);
            Cross.Add(Donavich, Cleric);

            var GuardianOfSorrow = AddApp(I6Ravenloft, new NPC("Guardian of Sorrow"), 16);
            Cross.Add(GuardianOfSorrow, NE);
            Cross.Add(GuardianOfSorrow, Barovia);

            var LiefLipsiege = AddApp(I6Ravenloft, new NPC("Lief Lipsiege"), 17);
            Cross.Add(LiefLipsiege, CE);
            Cross.Add(LiefLipsiege, Human);
            Cross.Add(LiefLipsiege, Barovia);
            Cross.Add(LiefLipsiege, Fighter);

            var Helga = AddApp(I6Ravenloft, new NPC("Helga"), 18);
            Cross.Add(Helga, CE);
            Cross.Add(Helga, Human);
            Cross.Add(Helga, Barovia);
            Cross.Add(Helga, Vampire);

            var CyrusBelview = AddApp(I6Ravenloft, new NPC("Cyrus Belview"), 23);
            Cross.Add(CyrusBelview, CN);
            Cross.Add(CyrusBelview, Human);
            Cross.Add(CyrusBelview, Barovia);
            Cross.Add(CyrusBelview, Fighter);

            var SpectreAbCenteer = AddApp(I6Ravenloft, new NPC("Spectre Ab-Centeer"), 27);
            Cross.Add(SpectreAbCenteer, Deceased);
            Cross.Add(SpectreAbCenteer, Barovia);

            var ArtistaDeSlop = AddApp(I6Ravenloft, new NPC("Artista DeSlop"), 27);
            Cross.Add(ArtistaDeSlop, Deceased);
            Cross.Add(ArtistaDeSlop, Barovia);

            var IsoldeYunk = AddApp(I6Ravenloft, new NPC("Lady Isolde Yunk"), 27);
            IsoldeYunk.ExtraInfo = "Also known as 'Isolde the Incredible'.";
            Cross.Add(IsoldeYunk, Deceased);
            Cross.Add(IsoldeYunk, Barovia);

            var AeialDuPlumette = Add(new NPC("Prince Aeial Du Plumette"));
            AeialDuPlumette.ExtraInfo = "Also known as 'Aerial the Heavy'.";
            AddApp(I6Ravenloft, AeialDuPlumette, 27);
            Cross.Add(AeialDuPlumette, LE);
            Cross.Add(AeialDuPlumette, Human);
            Cross.Add(AeialDuPlumette, Ghost);
            Cross.Add(AeialDuPlumette, Barovia);

            var MaryaMarkovia = Add(new NPC("Marya Markovia"));
            AddApp(I6Ravenloft, MaryaMarkovia, 27, 28);
            Cross.Add(MaryaMarkovia, Deceased);
            Cross.Add(MaryaMarkovia, Barovia);

            var Endorovich = Add(new NPC("Endorovich the Terrible"));
            AddApp(I6Ravenloft, Endorovich, 27, 28);
            Cross.Add(Endorovich, LE);
            Cross.Add(Endorovich, Spectre);
            Cross.Add(Endorovich, Barovia);

            var DorfniyaDilisnya = Add(new NPC("Duchess Dorfniya Dilisnya"));
            AddApp(I6Ravenloft, DorfniyaDilisnya, 28);
            Cross.Add(DorfniyaDilisnya, Deceased);
            Cross.Add(DorfniyaDilisnya, Barovia);

            var Pidlwik = Add(new NPC("Pidlwik"));
            AddApp(I6Ravenloft, Pidlwik, 28);
            Cross.Add(Pidlwik, Deceased);
            Cross.Add(Pidlwik, Barovia);

            var LeanneTriksky = Add(new NPC("Sir Leanne Triksky"));
            LeanneTriksky.ExtraInfo = "Sir Lee the Crusher";
            AddApp(I6Ravenloft, LeanneTriksky, 28);
            Cross.Add(LeanneTriksky, Deceased);
            Cross.Add(LeanneTriksky, Barovia);

            var TashaPetrovna = Add(new NPC("Tasha Petrovna"));
            AddApp(I6Ravenloft, TashaPetrovna, 28);
            Cross.Add(TashaPetrovna, Deceased);
            Cross.Add(TashaPetrovna, Barovia);

            var KingToisky = Add(new NPC("King Toisky"));
            AddApp(I6Ravenloft, KingToisky, 28);
            Cross.Add(KingToisky, Deceased);
            Cross.Add(KingToisky, Barovia);

            var IntreeKatsky = Add(new NPC("King Intree Katsky"));
            IntreeKatsky.ExtraInfo = "Katsky the Bright";
            AddApp(I6Ravenloft, IntreeKatsky, 28);
            Cross.Add(IntreeKatsky, Deceased);
            Cross.Add(IntreeKatsky, Barovia);

            var StahbalIndiBhak = Add(new NPC("Stahbal Indi-Bhak"));
            AddApp(I6Ravenloft, StahbalIndiBhak, 28);
            Cross.Add(StahbalIndiBhak, LE);
            Cross.Add(StahbalIndiBhak, Wight);
            Cross.Add(StahbalIndiBhak, Barovia);

            var Khazan = Add(new NPC("Khazan"));
            AddApp(I6Ravenloft, Khazan, 28);
            Cross.Add(Khazan, Deceased);
            Cross.Add(Khazan, Barovia);

            var ElsaFallona = Add(new NPC("Elsa Fallona"));
            AddApp(I6Ravenloft, ElsaFallona, 28);
            Cross.Add(ElsaFallona, Deceased);
            Cross.Add(ElsaFallona, Barovia);

            var SedrikSpinwitovich = Add(new NPC("Sir Sedrik Spinwitovich"));
            SedrikSpinwitovich.ExtraInfo = "Admiral Spinwitovich";
            AddApp(I6Ravenloft, SedrikSpinwitovich, 28);
            Cross.Add(SedrikSpinwitovich, Deceased);
            Cross.Add(SedrikSpinwitovich, Barovia);

            var Animus = Add(new NPC("Animus"));
            AddApp(I6Ravenloft, Animus, 28);
            Cross.Add(Animus, Deceased);
            Cross.Add(Animus, Barovia);

            var SashaIvliskova = Add(new NPC("Sasha Ivliskova"));
            AddApp(I6Ravenloft, SashaIvliskova, 28);
            Cross.Add(SashaIvliskova, CE);
            Cross.Add(SashaIvliskova, Human);
            Cross.Add(SashaIvliskova, Vampire);
            Cross.Add(SashaIvliskova, Barovia);
                
            var PatrinaVelikovna = Add(new NPC("Patrina Velikovna"));
            AddApp(I6Ravenloft, PatrinaVelikovna, 28);
            Cross.Add(PatrinaVelikovna, CE);
            Cross.Add(PatrinaVelikovna, Elf);
            Cross.Add(PatrinaVelikovna, Banshee);
            Cross.Add(PatrinaVelikovna, Vistani);
            Cross.Add(PatrinaVelikovna, Barovia);

            var ErikVonderbucks = Add(new NPC("Sir Erik Vonderbucks"));
            AddApp(I6Ravenloft, ErikVonderbucks, 28);
            Cross.Add(ErikVonderbucks, Deceased);
            Cross.Add(ErikVonderbucks, Barovia);

            var IvanDeRose = Add(new NPC("Ivan DeRose"));
            AddApp(I6Ravenloft, IvanDeRose, 28);
            Cross.Add(IvanDeRose, Deceased);
            Cross.Add(IvanDeRose, Barovia);

            var StephanGregorovich = Add(new NPC("Stephan Gregorovich"));
            AddApp(I6Ravenloft, StephanGregorovich, 28);
            Cross.Add(StephanGregorovich, Deceased);
            Cross.Add(StephanGregorovich, Barovia);

            var IntreeSikValoo = Add(new NPC("Intree Sik-Valoo"));
            AddApp(I6Ravenloft, IntreeSikValoo, 28);
            Cross.Add(IntreeSikValoo, Deceased);
            Cross.Add(IntreeSikValoo, Barovia);

            var ArdentPallette = Add(new NPC("Ardent Pallette"));
            AddApp(I6Ravenloft, ArdentPallette, 28);
            Cross.Add(ArdentPallette, Deceased);
            Cross.Add(ArdentPallette, Barovia);

            var IvanIvanovich = Add(new NPC("Ivan Ivanovich"));
            AddApp(I6Ravenloft, IvanIvanovich, 28);
            Cross.Add(IvanIvanovich, Deceased);
            Cross.Add(IvanIvanovich, Barovia);

            var AnnaPetrovna = Add(new NPC("Anna Petrovna"));
            AddApp(I6Ravenloft, AnnaPetrovna, 28);

            var CirilRomulich = Add(new NPC("Prefect Ciril Romulich"));
            AddApp(I6Ravenloft, CirilRomulich, 28);
            Cross.Add(CirilRomulich, Deceased);
            Cross.Add(CirilRomulich, Barovia);

            var KingBarov = Add(new NPC("King Barov"));
            AddApp(I6Ravenloft, KingBarov, 28, 30);
            Cross.Add(KingBarov, Deceased);
            Cross.Add(KingBarov, Barovia);

            var Dollarsigns = Add(new NPC("$$"));
            AddApp(I6Ravenloft, Dollarsigns, 29);
            Cross.Add(Dollarsigns, Deceased);
            Cross.Add(Dollarsigns, Barovia);

            var Stfinderway = Add(new NPC("St. Finderway"));
            AddApp(I6Ravenloft, Stfinderway, 29);
            Cross.Add(Stfinderway, Deceased);
            Cross.Add(Stfinderway, Barovia);

            var KingDostron = Add(new NPC("King Dostron"));
            AddApp(I6Ravenloft, KingDostron, 29);
            Cross.Add(KingDostron, Deceased);
            Cross.Add(KingDostron, Barovia);

            var GralmoreNimblenobs = Add(new NPC("Gralmore Nimblenobs"));
            AddApp(I6Ravenloft, GralmoreNimblenobs, 29);
            Cross.Add(GralmoreNimblenobs, Deceased);
            Cross.Add(GralmoreNimblenobs, Barovia);

            var AmericoStandardski = Add(new NPC("Americo Standardski"));
            AddApp(I6Ravenloft, AmericoStandardski, 29);
            Cross.Add(AmericoStandardski, Deceased);
            Cross.Add(AmericoStandardski, Barovia);

            var Beucephalus = Add(new NPC("Beucephalus"));
            AddApp(I6Ravenloft, Beucephalus, 29, 30);
            Cross.Add(Beucephalus, Deceased);
            Cross.Add(Beucephalus, Barovia);
            Cross.Add(Beucephalus, Horse);
            Cross.Add(Beucephalus, Nightmare);
            Cross.Add(Beucephalus, Strahd);

            var TatsaulEris = Add(new NPC("Tatsaul Eris"));
            AddApp(I6Ravenloft, TatsaulEris, 30);
            Cross.Add(TatsaulEris, Deceased);
            Cross.Add(TatsaulEris, Barovia);

            var Tatyana = Add(new NPC("Tatyana"));
            AddApp(I6Ravenloft, Tatyana, 1, 30, 31);
            Cross.Add(Tatyana, Deceased);
            Cross.Add(Tatyana, Barovia);

            var BildrathParents = new NPC(string.Empty);
            var BildrathSibling = new NPC(string.Empty);

            AddRel(I6Ravenloft,BildrathParents, Bildrath, RelationshipType.Parent);
            AddRel(I6Ravenloft,BildrathParents, BildrathSibling, RelationshipType.Parent);
            AddRel(I6Ravenloft,BildrathSibling, Parriwimple, RelationshipType.Parent);

            AddRel(I6Ravenloft,MadMary, Gertruda, RelationshipType.Parent);

            AddRel(I6Ravenloft,KolyanIndirovich, IreenaKolyana, RelationshipType.Parent);
            AddRel(I6Ravenloft,KolyanIndirovich, Ismark, RelationshipType.Parent);

            AddRel(I6Ravenloft,KingBarov, Strahd, RelationshipType.Parent);
            AddRel(I6Ravenloft,KingBarov, Sergei, RelationshipType.Parent);
            AddRel(I6Ravenloft,Ravenovia, Strahd, RelationshipType.Parent);
            AddRel(I6Ravenloft,Ravenovia, Sergei, RelationshipType.Parent);
            AddRel(I6Ravenloft,Ravenovia, KingBarov, RelationshipType.Spouse);

            AddRel(I6Ravenloft,Strahd, SashaIvliskova, RelationshipType.Spouse);
            AddRel(I6Ravenloft,Strahd, PatrinaVelikovna, RelationshipType.Spouse);

            AddRel(I6Ravenloft,Sergei, Tatyana, RelationshipType.Spouse);

            var OldSvalichRoad = Add(new Location("The Old Svalich Road"));
            AddApp(I6Ravenloft, OldSvalichRoad, 7);
            Cross.Add(OldSvalichRoad, Barovia);

            var GatesOfBarovia = Add(new Location("The Gates of Barovia"));
            AddApp(I6Ravenloft, GatesOfBarovia, 7);
            Cross.Add(GatesOfBarovia, Barovia);

            var SvalichWoods = Add(new Location("The Svalich Woods"));
            AddApp(I6Ravenloft, SvalichWoods, 1, 6, 7, 8);
            Cross.Add(SvalichWoods, Barovia);

            var RiverIvlis = Add(new Location("The River Ivlis"));
            AddApp(I6Ravenloft, RiverIvlis, 8);
            Cross.Add(RiverIvlis, Barovia);

            var VillageOfBarovia = Add(new Location("Village of Barovia"));
            AddApp(I6Ravenloft, VillageOfBarovia, 1, 6, 7);
            Cross.Add(VillageOfBarovia, Barovia);
            Cross.Add(VillageOfBarovia, IreenaKolyana);
            Cross.Add(VillageOfBarovia, KolyanIndirovich);
            Cross.Add(VillageOfBarovia, Bildrath);

            var BildrathsMercantile = Add(new Location("Bildrath's Mercantile"));
            AddApp(I6Ravenloft, BildrathsMercantile, 8);
            Cross.Add(BildrathsMercantile, Barovia);
            Cross.Add(BildrathsMercantile, VillageOfBarovia);
            Cross.Add(BildrathsMercantile, Bildrath);
            Cross.Add(BildrathsMercantile, Parriwimple);

            var BloodOfTheVineTavern = Add(new Location("Blood of the Vine Tavern"));
            BloodOfTheVineTavern.ExtraInfo = "Also known as Blood on the Vine";
            AddApp(I6Ravenloft, BloodOfTheVineTavern, 8, 9);
            Cross.Add(BloodOfTheVineTavern, Barovia);
            Cross.Add(BloodOfTheVineTavern, VillageOfBarovia);
            Cross.Add(BloodOfTheVineTavern, Arik);
            Cross.Add(BloodOfTheVineTavern, Ismark);

            var MadMaryTownhouse = Add(new Location("Mad Mary's Townhouse"));
            AddApp(I6Ravenloft, MadMaryTownhouse, 9);
            Cross.Add(MadMaryTownhouse, Barovia);
            Cross.Add(MadMaryTownhouse, VillageOfBarovia);
            Cross.Add(MadMaryTownhouse, MadMary);
            Cross.Add(MadMaryTownhouse, Gertruda);

            var BurgomasterHome = Add(new Location("Burgomaster's Home"));
            AddApp(I6Ravenloft, BurgomasterHome, 1, 9);
            Cross.Add(BurgomasterHome, Barovia);
            Cross.Add(BurgomasterHome, VillageOfBarovia);
            Cross.Add(BurgomasterHome, KolyanIndirovich);
            Cross.Add(BurgomasterHome, IreenaKolyana);

            var GuestHouse = Add(new Location("Burgomaster's Guest House"));
            AddApp(I6Ravenloft, GuestHouse, 9);
            Cross.Add(GuestHouse, Barovia);
            Cross.Add(GuestHouse, VillageOfBarovia);

            var BarovianChurch = Add(new Location("Church of Barovia"));
            AddApp(I6Ravenloft, BarovianChurch, 9, 10);
            Cross.Add(BarovianChurch, Barovia);
            Cross.Add(BarovianChurch, VillageOfBarovia);
            Cross.Add(BarovianChurch, Donavich);

            var BarovianCemetery = Add(new Location("Cemetery of Barovia"));
            AddApp(I6Ravenloft, BarovianCemetery, 9, 11);
            Cross.Add(BarovianCemetery, Barovia);
            Cross.Add(BarovianCemetery, VillageOfBarovia);
            Cross.Add(BarovianCemetery, Ghost);

            var RoadJunction = Add(new Location("Road Junction"));
            AddApp(I6Ravenloft, RoadJunction, 11);
            Cross.Add(RoadJunction, Barovia);

            var TserPoolEncampment = Add(new Location("Tser Pool Encampment"));
            AddApp(I6Ravenloft, TserPoolEncampment, 1);
            Cross.Add(TserPoolEncampment, Barovia);
            Cross.Add(TserPoolEncampment, Vistani);

            var MadamEvaTent = Add(new Location("Madam Eva's Tent"));
            AddApp(I6Ravenloft, MadamEvaTent, 1);
            Cross.Add(MadamEvaTent, Barovia);
            Cross.Add(MadamEvaTent, Vistani);
            Cross.Add(MadamEvaTent, MadamEva);

            var TserFalls = Add(new Location("Tser Falls"));
            AddApp(I6Ravenloft, TserFalls, 1);
            Cross.Add(TserFalls, Barovia);

            var GatesOfRavenloft = Add(new Location("The Gates of Ravenloft"));
            AddApp(I6Ravenloft, GatesOfRavenloft, 11, 12);
            Cross.Add(GatesOfRavenloft, Barovia);

            var CastleRavenloft = Add(new Location("Castle Ravenloft"));
            AddApp(I6Ravenloft, CastleRavenloft, 1);
            Cross.Add(CastleRavenloft, Barovia);
            Cross.Add(CastleRavenloft, Darklord);
            Cross.Add(CastleRavenloft, Strahd);
            Cross.Add(CastleRavenloft, GuardianOfSorrow);
            Cross.Add(CastleRavenloft, LiefLipsiege);
            Cross.Add(CastleRavenloft, Helga);
            Cross.Add(CastleRavenloft, CyrusBelview);
            Cross.Add(CastleRavenloft, SpectreAbCenteer);
            Cross.Add(CastleRavenloft, ArtistaDeSlop);
            Cross.Add(CastleRavenloft, IsoldeYunk);
            Cross.Add(CastleRavenloft, AeialDuPlumette);
            Cross.Add(CastleRavenloft, MaryaMarkovia);
            Cross.Add(CastleRavenloft, Endorovich);
            Cross.Add(CastleRavenloft, DorfniyaDilisnya);
            Cross.Add(CastleRavenloft, Pidlwik);
            Cross.Add(CastleRavenloft, LeanneTriksky);
            Cross.Add(CastleRavenloft, TashaPetrovna);
            Cross.Add(CastleRavenloft, KingToisky);
            Cross.Add(CastleRavenloft, IntreeKatsky);
            Cross.Add(CastleRavenloft, StahbalIndiBhak);
            Cross.Add(CastleRavenloft, Khazan);
            Cross.Add(CastleRavenloft, ElsaFallona);
            Cross.Add(CastleRavenloft, SedrikSpinwitovich);
            Cross.Add(CastleRavenloft, Animus);
            Cross.Add(CastleRavenloft, SashaIvliskova);
            Cross.Add(CastleRavenloft, PatrinaVelikovna);
            Cross.Add(CastleRavenloft, ErikVonderbucks);
            Cross.Add(CastleRavenloft, IvanDeRose);
            Cross.Add(CastleRavenloft, StephanGregorovich);
            Cross.Add(CastleRavenloft, IntreeSikValoo);
            Cross.Add(CastleRavenloft, ArdentPallette);
            Cross.Add(CastleRavenloft, IvanIvanovich);
            Cross.Add(CastleRavenloft, CirilRomulich);
            Cross.Add(CastleRavenloft, Dollarsigns);
            Cross.Add(CastleRavenloft, Stfinderway);
            Cross.Add(CastleRavenloft, KingDostron);
            Cross.Add(CastleRavenloft, GralmoreNimblenobs);
            Cross.Add(CastleRavenloft, AmericoStandardski);
            Cross.Add(CastleRavenloft, Beucephalus);
            Cross.Add(CastleRavenloft, TatsaulEris);
            Cross.Add(CastleRavenloft, Sergei);
            Cross.Add(CastleRavenloft, Ravenovia);
            Cross.Add(CastleRavenloft, KingBarov);

            Cross.Add(Vistani, SvalichWoods);
            Cross.Add(Vistani, VillageOfBarovia);

            AddApp(I6Ravenloft, Spirit, 11, 12, 19);
            Cross.Add(Spirit, Barovia);
            Cross.Add(Spirit, BarovianCemetery);
            Cross.Add(Spirit, CastleRavenloft);

            AddApp(I6Ravenloft, RedDragon, 13);
            Cross.Add(RedDragon, Barovia);
            Cross.Add(RedDragon, CastleRavenloft);

            AddApp(I6Ravenloft, ShadowDemon, 24);
            Cross.Add(ShadowDemon, Barovia);
            Cross.Add(ShadowDemon, CastleRavenloft);

            AddApp(I6Ravenloft, Nightmare, 29, 30);
            Cross.Add(Nightmare, Barovia);
            Cross.Add(Nightmare, CastleRavenloft);

            AddApp(I6Ravenloft, GiantSpider, 12, 19);
            Cross.Add(GiantSpider, Barovia);
            Cross.Add(GiantSpider, CastleRavenloft);

            AddApp(I6Ravenloft, HugeSpider, 28);
            Cross.Add(HugeSpider, Barovia);
            Cross.Add(HugeSpider, CastleRavenloft);

            AddApp(I6Ravenloft, Skeleton, 23);
            Cross.Add(Skeleton, Barovia);
            Cross.Add(Skeleton, CastleRavenloft);

            AddApp(I6Ravenloft, Banshee, 28);
            Cross.Add(Banshee, Barovia);
            Cross.Add(Banshee, CastleRavenloft);

            AddApp(I6Ravenloft, Trapper, 29);
            Cross.Add(Trapper, Barovia);
            Cross.Add(Trapper, CastleRavenloft);

            AddApp(I6Ravenloft, KeeningSpirit, 12);
            Cross.Add(KeeningSpirit, Barovia);
            Cross.Add(KeeningSpirit, CastleRavenloft);

            AddApp(I6Ravenloft, Gargoyles, 12, 13);
            Cross.Add(Gargoyles, Barovia);
            Cross.Add(Gargoyles, CastleRavenloft);

            AddApp(I6Ravenloft, RustMonster, 12);
            Cross.Add(RustMonster, Barovia);
            Cross.Add(RustMonster, CastleRavenloft);

            AddApp(I6Ravenloft, GuardianPortrait, 21);
            Cross.Add(GuardianPortrait, Barovia);
            Cross.Add(GuardianPortrait, CastleRavenloft);

            AddApp(I6Ravenloft, Spectre, 12, 27, 28);
            Cross.Add(Spectre, Barovia);
            Cross.Add(Spectre, CastleRavenloft);

            AddApp(I6Ravenloft, GreenSlime, 12);
            Cross.Add(GreenSlime, Barovia);
            Cross.Add(GreenSlime, GatesOfRavenloft);

            AddApp(I6Ravenloft, Horse, 11, 29, 30);
            Cross.Add(Horse, Strahd);
            Cross.Add(Horse, Barovia);

            AddApp(I6Ravenloft, Wight, 6, 28);
            Cross.Add(Wight, Barovia);
            Cross.Add(Wight, CastleRavenloft);

            AddApp(I6Ravenloft, Wraith, 6, 12, 18);
            Cross.Add(Wraith, Barovia);
            Cross.Add(Wraith, CastleRavenloft);

            AddApp(I6Ravenloft, Ghost, 6, 27);
            Cross.Add(Ghost, Barovia);
            Cross.Add(Ghost, CastleRavenloft);

            AddApp(I6Ravenloft, Ghoul, 6);
            Cross.Add(Ghoul, Barovia);

            AddApp(I6Ravenloft, Worg, 1, 3, 6, 8);
            Cross.Add(Worg, Barovia);
            Cross.Add(Zombie, Strahd);

            AddApp(I6Ravenloft, Bat, 1, 3, 6, 12, 27);
            Cross.Add(Bat, Barovia);
            Cross.Add(Bat, Strahd);
            Cross.Add(Bat, CastleRavenloft);

            AddApp(I6Ravenloft, Zombie, 6, 23);
            Cross.Add(Zombie, Barovia);
            Cross.Add(Zombie, Strahd);

            AddApp(I6Ravenloft, StrahdZombie, 3, 12, 17, 24);
            Cross.Add(StrahdZombie, Barovia);
            Cross.Add(StrahdZombie, Strahd);
            Cross.Add(StrahdZombie, CastleRavenloft);

            AddApp(I6Ravenloft, Cat, 21);
            Cross.Add(Cat, Barovia);
            Cross.Add(Cat, CastleRavenloft);

            AddApp(I6Ravenloft, Witch, 21, 22);
            Cross.Add(Witch, Barovia);
            Cross.Add(Witch, CastleRavenloft);

            AddApp(I6Ravenloft, Hellhound, 29);
            Cross.Add(Hellhound, Barovia);
            Cross.Add(Hellhound, CastleRavenloft);

            AddApp(I6Ravenloft, Werewolf, 24);
            Cross.Add(Werewolf, Barovia);
            Cross.Add(Werewolf, CastleRavenloft);

            AddApp(I6Ravenloft, IronGolem, 26);
            Cross.Add(IronGolem, Barovia);
            Cross.Add(IronGolem, CastleRavenloft);
            
            var Tarokka = Add(new Item("Tarokka"));
            AddApp(I6Ravenloft, Tarokka, 1, 4, 5);
            Cross.Add(
                items: new[] { Tarokka },
                domains: new[] { Barovia },
                npcs: new[] { MadamEva },
                locations: new[] { MadamEvaTent },
                traits: new[] { Mundane, Vistani }
            );

            var Sunsword = Add(new Item("Sunsword"));
            AddApp(I6Ravenloft, Sunsword, 5, 31);
            Cross.Add(
                items: new[] { Sunsword },
                domains: new[] { Barovia },
                locations: new[] { CastleRavenloft },
                traits: new[] { Magical, Melee }
            );
            
            var IconOfRavenloft = Add(new Item("Icon of Ravenloft"));
            AddApp(I6Ravenloft, IconOfRavenloft, 14);
            Cross.Add(
                items: new[] { IconOfRavenloft },
                domains: new[] { Barovia },
                locations: new[] { CastleRavenloft },
                traits: new[] { Magical, LG }
            );
            
            var HolySymbolOfRavenkind = Add(new Item("Holy Symbol of Ravenkind"));
            AddApp(I6Ravenloft, HolySymbolOfRavenkind, 17, 30);
            Cross.Add(
                items: new[] { HolySymbolOfRavenkind },
                domains: new[] { Barovia },
                locations: new[] { CastleRavenloft },
                traits: new[] { Magical, LG }
            );

            var TomeOfStrahd = Add(new Item("Tome of Strahd"));
            AddApp(I6Ravenloft, TomeOfStrahd, 11, 31);
            Cross.Add(
                items: new[] { TomeOfStrahd },
                domains: new[] { Barovia },
                npcs: new[] { Strahd },
                locations: new[] { CastleRavenloft },
                traits: new[] { Mundane }
            );*/
        }

        db.SaveChanges();
    }
}
