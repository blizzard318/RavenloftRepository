using System.Collections.Generic;

internal static class AddToDatabase
{
    public static void Add (RavenloftContext db) 
    {
        T Add <T>(T input) where T : class => db.Add(input).Entity;
        Relationship AddRel (Source source, NPC first, NPC second, Relationship.RelationshipType type)
        {
            var retval = db.Add(new Relationship(first, second, type)).Entity;
            Cross.Add(source, retval);
            return retval;
        }

        #region Universal Traits
        //Editions
        var e0  = Add(new Trait("Editionless"  , "Edition"));
        e0.ExtraInfo = "Everything here are official products that do not belong to any edition of D&D.";
        var e1  = Add(new Trait("1st Edition"  , "Edition"));
        var e2  = Add(new Trait("2nd Edition"  , "Edition"));
        var e3  = Add(new Trait("3rd Edition"  , "Edition"));
        var e35 = Add(new Trait("3.5th Edition", "Edition"));
        var e4  = Add(new Trait("4th Edition"  , "Edition"));
        var e5  = Add(new Trait("5th Edition"  , "Edition"));

        //Canonicity
        var pc = Add(new Trait("Potentially Canon", "Canon"));
        var nc = Add(new Trait("Not Canon"        , "Canon"));
        nc.ExtraInfo = pc.ExtraInfo = "Unless explicity stated as 'Potentially Canon' or 'Not Canon', everything else is treated Canon.";

        //Source types
        var comic      = Add(new Trait("Comic"      , "Media"));
        var module     = Add(new Trait("Module"     , "Media"));
        var novel      = Add(new Trait("Novel"      , "Media"));
        var gamebook   = Add(new Trait("Gamebook"   , "Media"));
        var sourcebook = Add(new Trait("Sourcebook" , "Media"));
        var magazine   = Add(new Trait("Magazine"   , "Media"));
        var videogame  = Add(new Trait("Video Game" , "Media"));
        var boardgame  = Add(new Trait("Board Game" , "Media"));

        //Exclusive to Ravenloft Types
        var Darklord = Add(new Trait("Darklord", "NPC,Location"));
        Darklord.ExtraInfo = "Locations tagged as Darklord are their Lairs.";
        var Vistani  = Add(new Trait("Vistani", "Group,NPC,Location,Item"));
        var Raunie   = Add(new Trait("Raunie", "NPC"));

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

        //Trait
        var Deceased = Add(new Trait("Deceased", "NPC"));

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

        //Item Types
        var Tarokka = Add(new Item("Tarokka"));
        Cross.Add(Tarokka, Mundane);
        Cross.Add(Tarokka, Vistani);

        var Sunsword = Add(new Item("Sunsword"));
        Cross.Add(Sunsword, Magical);
        Cross.Add(Sunsword, Melee);

        var IconOfRavenloft = Add(new Item("Icon of Ravenloft"));
        Cross.Add(IconOfRavenloft, Magical);
        Cross.Add(IconOfRavenloft, LG);

        var HolySymbolOfRavenkind = Add(new Item("Holy Symbol of Ravenkind"));
        Cross.Add(HolySymbolOfRavenkind, Magical);
        Cross.Add(HolySymbolOfRavenkind, LG);

        var TomeOfStrahd = Add(new Item("Tome of Strahd"));
        Cross.Add(TomeOfStrahd, Mundane);
        #endregion

        AddI6Ravenloft();
        void AddI6Ravenloft()
        {
            var I6Ravenloft = Add(new Source("I6: Ravenloft"));
            I6Ravenloft.Traits.AddRange(new List<Trait> { e1, module });
            I6Ravenloft.ReleaseDate = new DateTime(1983, 11, 1);
            I6Ravenloft.Contributors = "Authors: Tracy Hickman and Laura Hickman\nEditor: Curtis Smith\n";
            I6Ravenloft.Contributors += "Graphic Designer: Debra Stubbe\nIllustrator: Clyde Caldwell";
            I6Ravenloft.ExtraInfo = "'ModuleInfo':'An adventure for 6-8 characters of levels 5-7'";

            var Barovia = Add(new Domain("Barovia"));
            Add(new Appearance(I6Ravenloft, Barovia));
            Add(new Appearance(I6Ravenloft, Vampire));
            Add(new Appearance(I6Ravenloft, Human));
            Cross.Add(Barovia, Vampire);

            var Strahd = Add(new NPC("Count Strahd von Zarovich"));
            Add(new Appearance(I6Ravenloft, Strahd));
            Cross.Add(Strahd, CE);
            Cross.Add(Strahd, Human);
            Cross.Add(Strahd, MagicUser);
            Cross.Add(Strahd, Barovia);
            Cross.Add(Strahd, Darklord);
            Cross.Add(Strahd, Vampire);
            Strahd.ExtraInfo = "'ClosedBorders':'No one has left Barovia for centuries. This is because of the trapping fog that exists everywhere in Barovia. Once it is breathed, it infuses itself around a character's vital organs as a neutralized poison. The fog does not taste or smell any different than normal fog. It does not harm characters as long as they continue to breathe the air in Barovia. However, when they leave Barovia, the poison becomes active. Characters must save vs. poison or start to choke. Unless choking characters reenter Barovia within 24 hours, they die. The choking stops as soon as they breathe the fog again.  The fog is magically produced by Strahd and disappears entirely upon his destruction.'";

            var MadamEva = Add(new NPC("Madam Eva"));
            Add(new Appearance(I6Ravenloft, MadamEva, 1, 6));
            Cross.Add(MadamEva, CN);
            Cross.Add(MadamEva, Human);
            Cross.Add(MadamEva, Barovia);
            Cross.Add(MadamEva, Cleric);
            Cross.Add(MadamEva, Raunie);
            Cross.Add(MadamEva, Vistani);

            var KolyanIndirovich = Add(new NPC("Kolyan Indirovich"));
            Add(new Appearance(I6Ravenloft, KolyanIndirovich, 7, 8, 9));
            Cross.Add(KolyanIndirovich, Deceased);
            Cross.Add(KolyanIndirovich, Human);
            Cross.Add(KolyanIndirovich, Barovia);
            Cross.Add(KolyanIndirovich, Fighter);

            var IreenaKolyana = Add(new NPC("Ireena Kolyana"));
            Add(new Appearance(I6Ravenloft, IreenaKolyana));
            Cross.Add(IreenaKolyana, LG);
            Cross.Add(IreenaKolyana, Human);
            Cross.Add(IreenaKolyana, Barovia);
            Cross.Add(IreenaKolyana, Fighter);

            var Bildrath = Add(new NPC("Bildrath"));
            Add(new Appearance(I6Ravenloft, Bildrath, 8));
            Cross.Add(Bildrath, LN);
            Cross.Add(Bildrath, Human);
            Cross.Add(Bildrath, Barovia);
            Cross.Add(Bildrath, Fighter);

            var Parriwimple = Add(new NPC("Parriwimple"));
            Add(new Appearance(I6Ravenloft, Parriwimple, 8));
            Cross.Add(Bildrath, LN);
            Cross.Add(Parriwimple, Human);
            Cross.Add(Parriwimple, Barovia);
            Cross.Add(Parriwimple, Fighter);

            var Arik = Add(new NPC("Arik"));
            Add(new Appearance(I6Ravenloft, Arik, 8));
            Cross.Add(Arik, CN);
            Cross.Add(Arik, Human);
            Cross.Add(Arik, Barovia);
            Cross.Add(Arik, Fighter);

            var Ismark = Add(new NPC("Ismark the Lesser"));
            Add(new Appearance(I6Ravenloft, Arik, 8, 9));
            Cross.Add(Ismark, LG);
            Cross.Add(Ismark, Human);
            Cross.Add(Ismark, Barovia);

            var Sergei = Add(new NPC("Sergei von Zarovich"));
            Add(new Appearance(I6Ravenloft, Sergei, 1, 4, 30, 31));
            Cross.Add(Sergei, Deceased);
            Cross.Add(Sergei, Human);
            Cross.Add(Sergei, Barovia);

            var Ravenovia = Add(new NPC("Queen Ravenovia"));
            Add(new Appearance(I6Ravenloft, Ravenovia, 5, 30));
            Cross.Add(Sergei, Deceased);
            Cross.Add(Sergei, Human);
            Cross.Add(Sergei, Barovia);

            var MadMary = Add(new NPC("Mad Mary"));
            Add(new Appearance(I6Ravenloft, MadMary, 9, 19));
            Cross.Add(MadMary, CN);
            Cross.Add(MadMary, Human);
            Cross.Add(MadMary, Barovia);
            Cross.Add(MadMary, Fighter);

            var Gertruda = Add(new NPC("Gertruda"));
            Add(new Appearance(I6Ravenloft, Gertruda, 9, 19));
            Cross.Add(Gertruda, NG);
            Cross.Add(Gertruda, Human);
            Cross.Add(Gertruda, Barovia);

            var Donavich = Add(new NPC("Donavich"));
            Add(new Appearance(I6Ravenloft, Donavich, 9));
            Cross.Add(Donavich, LG);
            Cross.Add(Donavich, Human);
            Cross.Add(Donavich, Barovia);
            Cross.Add(Donavich, Cleric);

            var GuardianOfSorrow = Add(new NPC("Guardian of Sorrow"));
            Add(new Appearance(I6Ravenloft, GuardianOfSorrow, 16));
            Cross.Add(GuardianOfSorrow, NE);
            Cross.Add(GuardianOfSorrow, Barovia);

            var LiefLipsiege = Add(new NPC("Lief Lipsiege"));
            Add(new Appearance(I6Ravenloft, LiefLipsiege, 17));
            Cross.Add(LiefLipsiege, CE);
            Cross.Add(LiefLipsiege, Human);
            Cross.Add(LiefLipsiege, Barovia);
            Cross.Add(LiefLipsiege, Fighter);

            var Helga = Add(new NPC("Helga"));
            Add(new Appearance(I6Ravenloft, Helga, 18));
            Cross.Add(Helga, CE);
            Cross.Add(Helga, Human);
            Cross.Add(Helga, Barovia);
            Cross.Add(Helga, Vampire);

            var CyrusBelview = Add(new NPC("Cyrus Belview"));
            Add(new Appearance(I6Ravenloft, CyrusBelview, 23));
            Cross.Add(CyrusBelview, CN);
            Cross.Add(CyrusBelview, Human);
            Cross.Add(CyrusBelview, Barovia);
            Cross.Add(CyrusBelview, Fighter);

            var SpectreAbCenteer = Add(new NPC("Spectre Ab-Centeer"));
            Add(new Appearance(I6Ravenloft, SpectreAbCenteer, 27));
            Cross.Add(SpectreAbCenteer, Deceased);
            Cross.Add(SpectreAbCenteer, Barovia);

            var ArtistaDeSlop = Add(new NPC("Artista DeSlop"));
            Add(new Appearance(I6Ravenloft, ArtistaDeSlop, 27));
            Cross.Add(ArtistaDeSlop, Deceased);
            Cross.Add(ArtistaDeSlop, Barovia);

            var IsoldeYunk = Add(new NPC("Lady Isolde Yunk"));
            IsoldeYunk.ExtraInfo = "Also known as 'Isolde the Incredible'.";
            Add(new Appearance(I6Ravenloft, IsoldeYunk, 27));
            Cross.Add(IsoldeYunk, Deceased);
            Cross.Add(IsoldeYunk, Barovia);

            var AeialDuPlumette = Add(new NPC("Prince Aeial Du Plumette"));
            AeialDuPlumette.ExtraInfo = "Also known as 'Aerial the Heavy'.";
            Add(new Appearance(I6Ravenloft, AeialDuPlumette, 27));
            Cross.Add(AeialDuPlumette, LE);
            Cross.Add(AeialDuPlumette, Human);
            Cross.Add(AeialDuPlumette, Ghost);
            Cross.Add(AeialDuPlumette, Barovia);

            var MaryaMarkovia = Add(new NPC("Marya Markovia"));
            Add(new Appearance(I6Ravenloft, MaryaMarkovia, 27, 28));
            Cross.Add(MaryaMarkovia, Deceased);
            Cross.Add(MaryaMarkovia, Barovia);

            var Endorovich = Add(new NPC("Endorovich the Terrible"));
            Add(new Appearance(I6Ravenloft, Endorovich, 27, 28));
            Cross.Add(Endorovich, LE);
            Cross.Add(Endorovich, Spectre);
            Cross.Add(Endorovich, Barovia);

            var DorfniyaDilisnya = Add(new NPC("Duchess Dorfniya Dilisnya"));
            Add(new Appearance(I6Ravenloft, DorfniyaDilisnya, 28));
            Cross.Add(DorfniyaDilisnya, Deceased);
            Cross.Add(DorfniyaDilisnya, Barovia);

            var Pidlwik = Add(new NPC("Pidlwik"));
            Add(new Appearance(I6Ravenloft, Pidlwik, 28));
            Cross.Add(Pidlwik, Deceased);
            Cross.Add(Pidlwik, Barovia);

            var LeanneTriksky = Add(new NPC("Sir Leanne Triksky"));
            LeanneTriksky.ExtraInfo = "Sir Lee the Crusher";
            Add(new Appearance(I6Ravenloft, LeanneTriksky, 28));
            Cross.Add(LeanneTriksky, Deceased);
            Cross.Add(LeanneTriksky, Barovia);

            var TashaPetrovna = Add(new NPC("Tasha Petrovna"));
            Add(new Appearance(I6Ravenloft, TashaPetrovna, 28));
            Cross.Add(TashaPetrovna, Deceased);
            Cross.Add(TashaPetrovna, Barovia);

            var KingToisky = Add(new NPC("King Toisky"));
            Add(new Appearance(I6Ravenloft, KingToisky, 28));
            Cross.Add(KingToisky, Deceased);
            Cross.Add(KingToisky, Barovia);

            var IntreeKatsky = Add(new NPC("King Intree Katsky"));
            IntreeKatsky.ExtraInfo = "Katsky the Bright";
            Add(new Appearance(I6Ravenloft, IntreeKatsky, 28));
            Cross.Add(IntreeKatsky, Deceased);
            Cross.Add(IntreeKatsky, Barovia);

            var StahbalIndiBhak = Add(new NPC("Stahbal Indi-Bhak"));
            Add(new Appearance(I6Ravenloft, StahbalIndiBhak, 28));
            Cross.Add(StahbalIndiBhak, LE);
            Cross.Add(StahbalIndiBhak, Wight);
            Cross.Add(StahbalIndiBhak, Barovia);

            var Khazan = Add(new NPC("Khazan"));
            Add(new Appearance(I6Ravenloft, Khazan, 28));
            Cross.Add(Khazan, Deceased);
            Cross.Add(Khazan, Barovia);

            var ElsaFallona = Add(new NPC("Elsa Fallona"));
            Add(new Appearance(I6Ravenloft, ElsaFallona, 28));
            Cross.Add(ElsaFallona, Deceased);
            Cross.Add(ElsaFallona, Barovia);

            var SedrikSpinwitovich = Add(new NPC("Sir Sedrik Spinwitovich"));
            SedrikSpinwitovich.ExtraInfo = "Admiral Spinwitovich";
            Add(new Appearance(I6Ravenloft, SedrikSpinwitovich, 28));
            Cross.Add(SedrikSpinwitovich, Deceased);
            Cross.Add(SedrikSpinwitovich, Barovia);

            var Animus = Add(new NPC("Animus"));
            Add(new Appearance(I6Ravenloft, Animus, 28));
            Cross.Add(Animus, Deceased);
            Cross.Add(Animus, Barovia);

            var SashaIvliskova = Add(new NPC("Sasha Ivliskova"));
            Add(new Appearance(I6Ravenloft, SashaIvliskova, 28));
            Cross.Add(SashaIvliskova, CE);
            Cross.Add(SashaIvliskova, Human);
            Cross.Add(SashaIvliskova, Vampire);
            Cross.Add(SashaIvliskova, Barovia);
                
            var PatrinaVelikovna = Add(new NPC("Patrina Velikovna"));
            Add(new Appearance(I6Ravenloft, PatrinaVelikovna, 28));
            Cross.Add(PatrinaVelikovna, CE);
            Cross.Add(PatrinaVelikovna, Elf);
            Cross.Add(PatrinaVelikovna, Banshee);
            Cross.Add(PatrinaVelikovna, Vistani);
            Cross.Add(PatrinaVelikovna, Barovia);

            var ErikVonderbucks = Add(new NPC("Sir Erik Vonderbucks"));
            Add(new Appearance(I6Ravenloft, ErikVonderbucks, 28));
            Cross.Add(ErikVonderbucks, Deceased);
            Cross.Add(ErikVonderbucks, Barovia);

            var IvanDeRose = Add(new NPC("Ivan DeRose"));
            Add(new Appearance(I6Ravenloft, IvanDeRose, 28));
            Cross.Add(IvanDeRose, Deceased);
            Cross.Add(IvanDeRose, Barovia);

            var StephanGregorovich = Add(new NPC("Stephan Gregorovich"));
            Add(new Appearance(I6Ravenloft, StephanGregorovich, 28));
            Cross.Add(StephanGregorovich, Deceased);
            Cross.Add(StephanGregorovich, Barovia);

            var IntreeSikValoo = Add(new NPC("Intree Sik-Valoo"));
            Add(new Appearance(I6Ravenloft, IntreeSikValoo, 28));
            Cross.Add(IntreeSikValoo, Deceased);
            Cross.Add(IntreeSikValoo, Barovia);

            var ArdentPallette = Add(new NPC("Ardent Pallette"));
            Add(new Appearance(I6Ravenloft, ArdentPallette, 28));
            Cross.Add(ArdentPallette, Deceased);
            Cross.Add(ArdentPallette, Barovia);

            var IvanIvanovich = Add(new NPC("Ivan Ivanovich"));
            Add(new Appearance(I6Ravenloft, IvanIvanovich, 28));
            Cross.Add(IvanIvanovich, Deceased);
            Cross.Add(IvanIvanovich, Barovia);

            var AnnaPetrovna = Add(new NPC("Anna Petrovna"));
            Add(new Appearance(I6Ravenloft, AnnaPetrovna, 28));

            var CirilRomulich = Add(new NPC("Prefect Ciril Romulich"));
            Add(new Appearance(I6Ravenloft, CirilRomulich, 28));
            Cross.Add(CirilRomulich, Deceased);
            Cross.Add(CirilRomulich, Barovia);

            var KingBarov = Add(new NPC("King Barov"));
            Add(new Appearance(I6Ravenloft, KingBarov, 28, 30));
            Cross.Add(KingBarov, Deceased);
            Cross.Add(KingBarov, Barovia);

            var Dollarsigns = Add(new NPC("$$"));
            Add(new Appearance(I6Ravenloft, Dollarsigns, 29));
            Cross.Add(Dollarsigns, Deceased);
            Cross.Add(Dollarsigns, Barovia);

            var Stfinderway = Add(new NPC("St. Finderway"));
            Add(new Appearance(I6Ravenloft, Stfinderway, 29));
            Cross.Add(Stfinderway, Deceased);
            Cross.Add(Stfinderway, Barovia);

            var KingDostron = Add(new NPC("King Dostron"));
            Add(new Appearance(I6Ravenloft, KingDostron, 29));
            Cross.Add(KingDostron, Deceased);
            Cross.Add(KingDostron, Barovia);

            var GralmoreNimblenobs = Add(new NPC("Gralmore Nimblenobs"));
            Add(new Appearance(I6Ravenloft, GralmoreNimblenobs, 29));
            Cross.Add(GralmoreNimblenobs, Deceased);
            Cross.Add(GralmoreNimblenobs, Barovia);

            var AmericoStandardski = Add(new NPC("Americo Standardski"));
            Add(new Appearance(I6Ravenloft, AmericoStandardski, 29));
            Cross.Add(AmericoStandardski, Deceased);
            Cross.Add(AmericoStandardski, Barovia);

            var Beucephalus = Add(new NPC("Beucephalus"));
            Add(new Appearance(I6Ravenloft, Beucephalus, 29, 30));
            Cross.Add(Beucephalus, Deceased);
            Cross.Add(Beucephalus, Barovia);
            Cross.Add(Beucephalus, Horse);
            Cross.Add(Beucephalus, Nightmare);
            Cross.Add(Beucephalus, Strahd);

            var TatsaulEris = Add(new NPC("Tatsaul Eris"));
            Add(new Appearance(I6Ravenloft, TatsaulEris, 30));
            Cross.Add(TatsaulEris, Deceased);
            Cross.Add(TatsaulEris, Barovia);

            var Tatyana = Add(new NPC("Tatyana"));
            Add(new Appearance(I6Ravenloft, Tatyana, 1, 30, 31));
            Cross.Add(Tatyana, Deceased);
            Cross.Add(Tatyana, Barovia);

            var BildrathParents = new NPC(string.Empty);
            var BildrathSibling = new NPC(string.Empty);

            AddRel(I6Ravenloft,BildrathParents, Bildrath, Relationship.RelationshipType.Parent);
            AddRel(I6Ravenloft,BildrathParents, BildrathSibling, Relationship.RelationshipType.Parent);
            AddRel(I6Ravenloft,BildrathSibling, Parriwimple, Relationship.RelationshipType.Parent);

            AddRel(I6Ravenloft,MadMary, Gertruda, Relationship.RelationshipType.Parent);

            AddRel(I6Ravenloft,KolyanIndirovich, IreenaKolyana, Relationship.RelationshipType.Parent);
            AddRel(I6Ravenloft,KolyanIndirovich, Ismark, Relationship.RelationshipType.Parent);

            AddRel(I6Ravenloft,KingBarov, Strahd, Relationship.RelationshipType.Parent);
            AddRel(I6Ravenloft,KingBarov, Sergei, Relationship.RelationshipType.Parent);
            AddRel(I6Ravenloft,Ravenovia, Strahd, Relationship.RelationshipType.Parent);
            AddRel(I6Ravenloft,Ravenovia, Sergei, Relationship.RelationshipType.Parent);
            AddRel(I6Ravenloft,Ravenovia, KingBarov, Relationship.RelationshipType.Spouse);

            AddRel(I6Ravenloft,Strahd, SashaIvliskova, Relationship.RelationshipType.Spouse);
            AddRel(I6Ravenloft,Strahd, PatrinaVelikovna, Relationship.RelationshipType.Spouse);

            AddRel(I6Ravenloft,Sergei, Tatyana, Relationship.RelationshipType.Spouse);

            var OldSvalichRoad = Add(new Location("The Old Svalich Road"));
            Add(new Appearance(I6Ravenloft, OldSvalichRoad, 7));
            Cross.Add(OldSvalichRoad, Barovia);

            var GatesOfBarovia = Add(new Location("The Gates of Barovia"));
            Add(new Appearance(I6Ravenloft, GatesOfBarovia, 7));
            Cross.Add(GatesOfBarovia, Barovia);

            var SvalichWoods = Add(new Location("The Svalich Woods"));
            Add(new Appearance(I6Ravenloft, SvalichWoods, 1, 6, 7, 8));
            Cross.Add(SvalichWoods, Barovia);

            var RiverIvlis = Add(new Location("The River Ivlis"));
            Add(new Appearance(I6Ravenloft, RiverIvlis, 8));
            Cross.Add(RiverIvlis, Barovia);

            var VillageOfBarovia = Add(new Location("Village of Barovia"));
            Add(new Appearance(I6Ravenloft, VillageOfBarovia, 1, 6, 7));
            Cross.Add(VillageOfBarovia, Barovia);
            Cross.Add(VillageOfBarovia, IreenaKolyana);
            Cross.Add(VillageOfBarovia, KolyanIndirovich);
            Cross.Add(VillageOfBarovia, Bildrath);

            var BildrathsMercantile = Add(new Location("Bildrath's Mercantile"));
            Add(new Appearance(I6Ravenloft, BildrathsMercantile, 8));
            Cross.Add(BildrathsMercantile, Barovia);
            Cross.Add(BildrathsMercantile, VillageOfBarovia);
            Cross.Add(BildrathsMercantile, Bildrath);
            Cross.Add(BildrathsMercantile, Parriwimple);

            var BloodOfTheVineTavern = Add(new Location("Blood of the Vine Tavern"));
            BloodOfTheVineTavern.ExtraInfo = "Also known as Blood on the Vine";
            Add(new Appearance(I6Ravenloft, BloodOfTheVineTavern, 8, 9));
            Cross.Add(BloodOfTheVineTavern, Barovia);
            Cross.Add(BloodOfTheVineTavern, VillageOfBarovia);
            Cross.Add(BloodOfTheVineTavern, Arik);
            Cross.Add(BloodOfTheVineTavern, Ismark);

            var MadMaryTownhouse = Add(new Location("Mad Mary's Townhouse"));
            Add(new Appearance(I6Ravenloft, MadMaryTownhouse, 9));
            Cross.Add(MadMaryTownhouse, Barovia);
            Cross.Add(MadMaryTownhouse, VillageOfBarovia);
            Cross.Add(MadMaryTownhouse, MadMary);
            Cross.Add(MadMaryTownhouse, Gertruda);

            var BurgomasterHome = Add(new Location("Burgomaster's Home"));
            Add(new Appearance(I6Ravenloft, BurgomasterHome, 1, 9));
            Cross.Add(BurgomasterHome, Barovia);
            Cross.Add(BurgomasterHome, VillageOfBarovia);
            Cross.Add(BurgomasterHome, KolyanIndirovich);
            Cross.Add(BurgomasterHome, IreenaKolyana);

            var GuestHouse = Add(new Location("Burgomaster's Guest House"));
            Add(new Appearance(I6Ravenloft, GuestHouse, 9));
            Cross.Add(GuestHouse, Barovia);
            Cross.Add(GuestHouse, VillageOfBarovia);

            var BarovianChurch = Add(new Location("Church of Barovia"));
            Add(new Appearance(I6Ravenloft, BarovianChurch, 9, 10));
            Cross.Add(BarovianChurch, Barovia);
            Cross.Add(BarovianChurch, VillageOfBarovia);
            Cross.Add(BarovianChurch, Donavich);

            var BarovianCemetery = Add(new Location("Cemetery of Barovia"));
            Add(new Appearance(I6Ravenloft, BarovianCemetery, 9, 11));
            Cross.Add(BarovianCemetery, Barovia);
            Cross.Add(BarovianCemetery, VillageOfBarovia);
            Cross.Add(BarovianCemetery, Ghost);

            var RoadJunction = Add(new Location("Road Junction"));
            Add(new Appearance(I6Ravenloft, RoadJunction, 11));
            Cross.Add(RoadJunction, Barovia);

            var TserPoolEncampment = Add(new Location("Tser Pool Encampment"));
            Add(new Appearance(I6Ravenloft, TserPoolEncampment, 1));
            Cross.Add(TserPoolEncampment, Barovia);
            Cross.Add(TserPoolEncampment, Vistani);

            var MadamEvaTent = Add(new Location("Madam Eva's Tent"));
            Add(new Appearance(I6Ravenloft, MadamEvaTent, 1));
            Cross.Add(MadamEvaTent, Barovia);
            Cross.Add(MadamEvaTent, Vistani);
            Cross.Add(MadamEvaTent, MadamEva);

            var TserFalls = Add(new Location("Tser Falls"));
            Add(new Appearance(I6Ravenloft, TserFalls, 1));
            Cross.Add(TserFalls, Barovia);

            var GatesOfRavenloft = Add(new Location("The Gates of Ravenloft"));
            Add(new Appearance(I6Ravenloft, GatesOfRavenloft, 11, 12));
            Cross.Add(GatesOfRavenloft, Barovia);

            var CastleRavenloft = Add(new Location("Castle Ravenloft"));
            Add(new Appearance(I6Ravenloft, CastleRavenloft, 1));
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

            Add(new Appearance(I6Ravenloft, Spirit, 11, 12, 19));
            Cross.Add(Spirit, Barovia);
            Cross.Add(Spirit, BarovianCemetery);
            Cross.Add(Spirit, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, RedDragon, 13));
            Cross.Add(RedDragon, Barovia);
            Cross.Add(RedDragon, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, ShadowDemon, 24));
            Cross.Add(ShadowDemon, Barovia);
            Cross.Add(ShadowDemon, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Nightmare, 29, 30));
            Cross.Add(Nightmare, Barovia);
            Cross.Add(Nightmare, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, GiantSpider, 12, 19));
            Cross.Add(GiantSpider, Barovia);
            Cross.Add(GiantSpider, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, HugeSpider, 28));
            Cross.Add(HugeSpider, Barovia);
            Cross.Add(HugeSpider, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Skeleton, 23));
            Cross.Add(Skeleton, Barovia);
            Cross.Add(Skeleton, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Banshee, 28));
            Cross.Add(Banshee, Barovia);
            Cross.Add(Banshee, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Trapper, 29));
            Cross.Add(Trapper, Barovia);
            Cross.Add(Trapper, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, KeeningSpirit, 12));
            Cross.Add(KeeningSpirit, Barovia);
            Cross.Add(KeeningSpirit, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Gargoyles, 12, 13));
            Cross.Add(Gargoyles, Barovia);
            Cross.Add(Gargoyles, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, RustMonster, 12));
            Cross.Add(RustMonster, Barovia);
            Cross.Add(RustMonster, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, GuardianPortrait, 21));
            Cross.Add(GuardianPortrait, Barovia);
            Cross.Add(GuardianPortrait, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Spectre, 12, 27, 28));
            Cross.Add(Spectre, Barovia);
            Cross.Add(Spectre, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, GreenSlime, 12));
            Cross.Add(GreenSlime, Barovia);
            Cross.Add(GreenSlime, GatesOfRavenloft);

            Add(new Appearance(I6Ravenloft, Horse, 11, 29, 30));
            Cross.Add(Horse, Strahd);
            Cross.Add(Horse, Barovia);

            Add(new Appearance(I6Ravenloft, Wight, 6, 28));
            Cross.Add(Wight, Barovia);
            Cross.Add(Wight, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Wraith, 6, 12, 18));
            Cross.Add(Wraith, Barovia);
            Cross.Add(Wraith, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Ghost, 6, 27));
            Cross.Add(Ghost, Barovia);
            Cross.Add(Ghost, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Ghoul, 6));
            Cross.Add(Ghoul, Barovia);

            Add(new Appearance(I6Ravenloft, Worg, 1, 3, 6, 8));
            Cross.Add(Worg, Barovia);
            Cross.Add(Zombie, Strahd);

            Add(new Appearance(I6Ravenloft, Bat, 1, 3, 6, 12, 27));
            Cross.Add(Bat, Barovia);
            Cross.Add(Bat, Strahd);
            Cross.Add(Bat, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Zombie, 6, 23));
            Cross.Add(Zombie, Barovia);
            Cross.Add(Zombie, Strahd);

            Add(new Appearance(I6Ravenloft, StrahdZombie, 3, 12, 17, 24));
            Cross.Add(StrahdZombie, Barovia);
            Cross.Add(StrahdZombie, Strahd);
            Cross.Add(StrahdZombie, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Cat, 21));
            Cross.Add(Cat, Barovia);
            Cross.Add(Cat, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Witch, 21, 22));
            Cross.Add(Witch, Barovia);
            Cross.Add(Witch, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Hellhound, 29));
            Cross.Add(Hellhound, Barovia);
            Cross.Add(Hellhound, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Werewolf, 24));
            Cross.Add(Werewolf, Barovia);
            Cross.Add(Werewolf, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, IronGolem, 26));
            Cross.Add(IronGolem, Barovia);
            Cross.Add(IronGolem, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, Tarokka, 1, 4, 5));
            Cross.Add(Tarokka, Barovia);
            Cross.Add(Tarokka, MadamEva);
            Cross.Add(Tarokka, MadamEvaTent);

            Add(new Appearance(I6Ravenloft, Sunsword, 5, 31));
            Cross.Add(Sunsword, Barovia);
            Cross.Add(IconOfRavenloft, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, IconOfRavenloft, 14));
            Cross.Add(IconOfRavenloft, Barovia);
            Cross.Add(IconOfRavenloft, CastleRavenloft);

            Add(new Appearance(I6Ravenloft, HolySymbolOfRavenkind, 17, 30));
            Cross.Add(HolySymbolOfRavenkind, Barovia);
            Cross.Add(HolySymbolOfRavenkind, CastleRavenloft);
        }

        //db.SaveChanges();

        /*#region 2e
        var E2Canon = Add(new Canon("2e Canon"));
        #region Clusters
        var Core = Add(new Cluster("Core"));
        var CorePreGC = Add(new Cluster("Core (Pre-Grand Conjuction)"));
        var Shadowlands = Add(new Cluster("The Shadowlands"));
        var AmberWastes = Add(new Cluster("Amber Wastes"));
        var BurningPeaks = Add(new Cluster("Burning Peaks"));
        var FrozenReaches = Add(new Cluster("Frozen Reaches"));
        var VerdurousLands = Add(new Cluster("Verdurous Lands"));
        var Zherisia = Add(new Cluster("Zherisia"));
        #endregion
        #region Mistways
        var HereticsEgress = Add(new Mistway("Heretic's Egress"));
        var ShroudedWay = Add(new Mistway("Shrouded Way"));
        var ViaCorona = Add(new Mistway("Via Corona"));
        var RoadOfSecrets = Add(new Mistway("Road of a Thousand Secrets"));
        var ShatterPassage = Add(new Mistway("Shattered Passage"));
        var JackalsRuse = Add(new Mistway("Jackal's Ruse"));
        var WakeOfTheLoa = Add(new Mistway("Wake of the Loa"));
        var WayfarerPath = Add(new Mistway("Wayfarer's Path"));
        var VenomousTears = Add(new Mistway("Way of Venomous Tears"));
        var EmeraldStream = Add(new Mistway("Emerald Stream"));
        var LeviathanClutch = Add(new Mistway("Leviathan's Clutches"));
        var PathOfInnocence = Add(new Mistway("Path of Innocence"));
        #endregion
        #region Domains
        var Barovia = Add(new Domain("Barovia"));
        var Bluetspur = Add(new Domain("Bluetspur"));
        var Borca = Add(new Domain("Borca"));
        var LMorai = Add(new Domain("L'Morai", "The Carnival"));
        var Darkon = Add(new Domain("Darkon"));
        var Dementlieu = Add(new Domain("Dementlieu"));
        var Falkovnia = Add(new Domain("Falkovnia"));
        var HarAkir = Add(new Domain("Har'Akir"));
        var Hazlan = Add(new Domain("Hazlan"));
        var ICath = Add(new Domain("I'Cath"));
        var SriRaji = Add(new Domain("Sri Raji", "Kalakeri"));
        var Kartakass = Add(new Domain("Kartakass"));
        var Lamordia = Add(new Domain("Lamordia"));
        var Mordent = Add(new Domain("Mordent"));
        var Richemulot = Add(new Domain("Richemulot"));
        var Tepest = Add(new Domain("Tepest"));
        var Valachan = Add(new Domain("Valachan"));
        var Forlorn = Add(new Domain("Forlorn"));
        var Ghastria = Add(new Domain("Ghastria"));
        var Ghenna = Add(new Domain("G'Henna"));
        var Invidia = Add(new Domain("Invidia"));
        var Keening = Add(new Domain("Keening"));
        var Markovia = Add(new Domain("Markovia"));
        var NightmareLands = Add(new Domain("Nightmare Lands"));
        var NovaVaasa = Add(new Domain("Nova Vaasa"));
        var Odiare = Add(new Domain("Odiare", "Odaire"));
        var WindingRoad = Add(new Domain("Winding Road", "Endless Road", "Rider's Bridge"));
        var Risibilos = Add(new Domain("Risibilos"));
        var Scaena = Add(new Domain("Scaena"));
        var SeaOfSorrows = Add(new Domain("Sea of Sorrows"));
        var Blaustein = Add(new Domain("Blaustein"));
        var Dominia = Add(new Domain("Dominia"));
        var IsleOfTheRavens = Add(new Domain("Isle of the Ravens"));
        var Lighthouse = Add(new Domain("L'ile de le Tempete, The Lighthouse"));
        var ShadowbornManor = Add(new Domain("Shadowborn Manor", "Shadowlands"));
        var Souragne = Add(new Domain("Souragne"));
        var StauntonBluffs = Add(new Domain("Staunton Bluffs"));
        var Tovag = Add(new Domain("Tovag"));
        var Paridon = Add(new Domain("Paridon", "Zherisia"));
        var HouseOfLament = Add(new Domain("House of Lament"));
        var Demise = Add(new Domain("Demise"));
        var Kalidnay = Add(new Domain("Kalidnay"));
        var Sithicus = Add(new Domain("Sithicus"));
        var Cavitius = Add(new Domain("Cavitius"));
        var Aggarath = Add(new Domain("Aggarath"));
        var Avonleigh = Add(new Domain("Avonleigh"));
        var CastleIsland = Add(new Domain("Castle Island"));
        var Daglan = Add(new Domain("Daglan"));
        var Davion = Add(new Domain("Davion"));
        var Liffe = Add(new Domain("Liffe"));
        var Nebligtode = Add(new Domain("Nebligtode", "Nocturnal Sea"));
        var Necropolis = Add(new Domain("Necropolis"));
        var Nidala = Add(new Domain("Nidala"));
        var Nosos = Add(new Domain("Nosos"));
        var Pharazia = Add(new Domain("Pharazia"));
        var Rokushima = Add(new Domain("Rokushima Taiyoo"));
        var Sanguinia = Add(new Domain("Sanguinia"));
        var Saragross = Add(new Domain("Saragross"));
        var Sebua = Add(new Domain("Sebua"));
        var ShadowRift = Add(new Domain("Shadow Rift"));
        var TheEyrie = Add(new Domain("The Eyrie"));
        var TheIsle = Add(new Domain("The Isle"));
        var TheWildlands = Add(new Domain("The Wildlands"));
        var Timor = Add(new Domain("Timor"));
        var Vechor = Add(new Domain("Vechor"));
        var Verbrek = Add(new Domain("Verbrek"));
        var Vorostokov = Add(new Domain("Vorostokov"));
        var LeederiksTower = Add(new Domain("Leederik's Tower"));
        var Farelle = Add(new Domain("Farelle"));
        var RichtenHaus = Add(new Domain("Richten Haus"));

        var Malosia = Add(new Domain("Malosia"));
        var MithrasCourt = Add(new Domain("Mithras Court"));
        var Riverbend = Add(new Domain("Riverbend"));
        var Kislova = Add(new Domain("Kislova"));
        var Estrangia = Add(new Domain("Estrangia"));
        var AlKathos = Add(new Domain("Al-Kathos"));
        var Maridrar = Add(new Domain("Maridrar"));
        var DonskoysLand = Add(new Domain("Donskoy's Land"));
        var Arak = Add(new Domain("Arak"));
        var Arkandale = Add(new Domain("Arkandale"));
        var Dorvinia = Add(new Domain("Dorvinia"));
        var Gundarak = Add(new Domain("Gundarak"));
        #endregion
        #endregion

        #region 2e Potential
        var E2CanonPot = Add(new Canon("2e Potential Canon"));
        #region Mistways
        var BleakRoad = Add(new Mistway("Bleak Road"));
        var OutlandersGate = Add(new Mistway("Outlander's Gate"));
        var SerpentsCoils = Add(new Mistway("Serpent's Coils"));
        var MtFrostAnhalla = Add(new Mistway("Mount Frost-Anhalla"));
        var OakOfScreams = Add(new Mistway("Oak of Screams"));
        Cross.Add(E2CanonPot, BleakRoad, OutlandersGate, SerpentsCoils, MtFrostAnhalla, OakOfScreams);
        #endregion
        #endregion

        #region 2e Not Canon
        var E2CanonNot = Add(new Canon("2e Not Canon"));
        #endregion

        #region 3.5e Canon
        var E35Canon = Add(new Canon("3.5e Canon"));
        #endregion

        #region 4e Canon
        var E4Canon = Add(new Canon("4e Canon"));
        #region Domains
        var Graefmotte = Add(new Domain("Graefmotte"));
        var Histaven = Add(new Domain("Histaven"));
        var Monadhan = Add(new Domain("Monadhan"));
        var Sunderheart = Add(new Domain("Sunderheart"));
        var Timbergorge = Add(new Domain("Timbergorge"));
        var Bakumora = Add(new Domain("Bakumora"));
        var Darani = Add(new Domain("Darani"));
        #endregion
        #endregion

        #region 5e Canon
        var E5Canon = Add(new Canon("5e Canon"));
        #region Domains
        var Cyre1313 = Add(new Domain("Cyre 1313", "The Mourning Rail"));
        var Klorr = Add(new Domain("Klorr"));
        var Niranjan = Add(new Domain("Niranjan"));
        var VhageAgency = Add(new Domain("Vhage Agency"));
        var VigilantsBluff = Add(new Domain("Vigilant's Bluff"));
        #endregion
        #endregion

        #region Netbook
        var Netbook = Add(new Canon("Netbook"));
        #region Mistways
        var CallOfTheClaw = Add(new Mistway("Call of the Claw"));
        var SomnambulistPath = Add(new Mistway("Somnambulist's Path"));
        var RoyalChannel = Add(new Mistway("Royal Channel"));
        var TheWindingJaws = Add(new Mistway("Way of the Winding Jaws"));
        var UrchinsPath = Add(new Mistway("Urchin's Path"));
        var SleepOfReason = Add(new Mistway("Sleep of Reason"));
        var IronWay = Add(new Mistway("Iron Way"));
        Cross.Add(Netbook, CallOfTheClaw, SomnambulistPath, RoyalChannel, TheWindingJaws, UrchinsPath, SleepOfReason, IronWay);
        #endregion
        #endregion

        #region Homebrew
        var Homebrew = Add(new Canon("Homebrew"));
        #endregion




        #region Sources
        #endregion

        #region Locations
        #endregion

        #region Items
        #endregion

        #region Darklords
        var Strahd         = Add(new Darklord("Count Strahd von Zarovich", "The Devil Strahd", "Lord Vasili von Holtz", "Strahd XI", "Vladislav"));
        var Diederic       = Add(new Darklord("Sir Diederic de Wyndt"));
        var Lucius         = Add(new Darklord("Lord Lucius Knight", "Colonel Lucius Merriwether"));
        var Alistair       = Add(new Darklord("Doctor Alistair Weldon"));
        var Magroth        = Add(new Darklord("Emperor Magroth the Mad"));
        var Ilsabet        = Add(new Darklord("Baroness Ilsabet Obour"));
        var Whelm          = Add(new Darklord("Friar Whelm"));
        var Malbus         = Add(new Darklord("Malbus"));
        var Velkaarn       = Add(new Darklord("Lord Velkaarn"));
        var Milos          = Add(new Darklord("Lord Milos Donskoy"));
        var GodBrain       = Add(new Darklord("The Illithid God-Brain"));
        var Ivan           = Add(new Darklord("Ivan Dilisnya"));
        var Ivana          = Add(new Darklord("Ivana Boritsi"));
        var RubyPendant    = Add(new Darklord("RubyPendant"));
        var Nepenthe       = Add(new Darklord("Nepenthe"));
        var AzalinRex      = Add(new Darklord("Azalin Rex", "Firan Darcalus Zal'honan"));
        var Dominic        = Add(new Darklord("Dominic d'Honaire"));
        var Saidra         = Add(new Darklord("Saidra d'Honaire"));
        var Vlad           = Add(new Darklord("Vlad Drakov"));
        var Vladeska       = Add(new Darklord("Vladeska Drakov"));
        var Ankhtepot      = Add(new Darklord("Ankhtepot"));
        var Hazlik         = Add(new Darklord("Hazlik"));
        var TsienChiang    = Add(new Darklord("Empress Tsien Chiang"));
        var Arijani        = Add(new Darklord("Maharaja Arijani"));
        var Ramya          = Add(new Darklord("Ramya Vasavadan"));
        var HarkonLukas    = Add(new Darklord("Meistersinger Harkon Lukas"));
        var Adam           = Add(new Darklord("Adam"));
        var Viktra         = Add(new Darklord("Doctor Viktra Mordenheim"));
        var Wilfred        = Add(new Darklord("Wilfred Godefroy"));
        var Jacqueline     = Add(new Darklord("Jacqueline Renier"));
        var Mindefisk      = Add(new Darklord("The Sisters Mindefisk", "The Three Hags of Tepest", "Three Sisters"));
        var Lorinda        = Add(new Darklord("Mother Lorinda"));
        var UrikVonKarkov  = Add(new Darklord("Urik von Kharkov"));
        var Chakuna        = Add(new Darklord("Chakuna"));
        var TristenApBlanc = Add(new Darklord("Tristen ApBlanc", "The Solleyder"));
        var StezenDPolarno = Add(new Darklord("Marquis Stezen D'Polarno"));
        var YagnoPetrovna  = Add(new Darklord("Yagno Petrovna"));
        var Gabrielle      = Add(new Darklord("Gabrielle Aderre"));
        var Tristessa      = Add(new Darklord("Tristessa"));
        var Frantisek      = Add(new Darklord("Doctor Frantisek Markov"));
        var NigtmareMan    = Add(new Darklord("The Nigtmare Man"));
        var Hypnos         = Add(new Darklord("Hypnos"));
        var Mullonga       = Add(new Darklord("Mullonga"));
        var GhostDancer    = Add(new Darklord("The Ghost Dancer"));
        var Morpheus       = Add(new Darklord("Morpheus"));
        var RainbowSerpent = Add(new Darklord("The Rainbow Serpent"));
        var RedheadedChild = Add(new Darklord("The Redheaded Child"));
        var Malken         = Add(new Darklord("Tristen Hiregaard","Malken"));
        var Malkan         = Add(new Darklord("Myar Hiregaard" ," Malkan"));
        var Maligno        = Add(new Darklord("Maligno", "Figlio"));
        var Horseman       = Add(new Darklord("Headless Horseman"));
        var EliVanHassen   = Add(new Darklord("Eli van Hassen"));
        var Doerdon        = Add(new Darklord("King Doerdon"));
        var Puncheron      = Add(new Darklord("Puncheron"));
        var LemotSediam    = Add(new Darklord("Lemot Sediam Juste"));
        var PieterVanRiese = Add(new Darklord("Captain Pieter van Riese"));
        var PietraVanRiese = Add(new Darklord("Captain Pietra van Riese"));
        var Bluebeard      = Add(new Darklord("Bluebeard"));
        var Daclaud        = Add(new Darklord("Doctor Daclaud Heinfroth"));
        var LadyOfRavens   = Add(new Darklord("Lady of Ravens"));
        var AlainMonette   = Add(new Darklord("Captain Alain Monette"));
        var Ebonbane       = Add(new Darklord("Ebonbane"));
        var AntonMisroi    = Add(new Darklord("Anton Misroi"));
        var Torrence       = Add(new Darklord("Torrence Bleysmith"));
        var Teresa         = Add(new Darklord("Teresa Bleysmith"));
        var Kas            = Add(new Darklord("Kas the Destroyer", "Kas of Tycheron", "Kas the Terrible", "Kas the Bloody-Handed", "Kas the Hateful", "Kas the Betrayer"));
        var Sodo           = Add(new Darklord("Sodo"));
        var HouseOfLamentDL= Add(new Darklord("House of Lament"));
        var Althea         = Add(new Darklord("Althea"));
        var ThakokAn       = Add(new Darklord("Thakok-An"));
        var Soth           = Add(new Darklord("Lord Loren Soth", "Knight of the Black Rose"));
        var InzaMagdova    = Add(new Darklord("Inza Magdova Kulchevich"));
        var Vecna          = Add(new Darklord("Vecna"));
        var Chardath       = Add(new Darklord("Chardath Spulzeer"));
        var Morgoroth      = Add(new Darklord("Morgoroth the Black"));
        var LadyOfTheLake  = Add(new Darklord("Lady of the Lake"));
        var Radaga         = Add(new Darklord("Radaga"));
        var DavionTheMad   = Add(new Darklord("Davion the Mad"));
        var LyronEvensong  = Add(new Darklord("Lyron Evensong"));
        var Meredoth       = Add(new Darklord("Meredoth"));
        var Lowellyn       = Add(new Darklord("Death", "Lowellyn Dachine"));
        var ElenaFaithHold = Add(new Darklord("Elena Faith-hold"));
        var MalusSceleris  = Add(new Darklord("Malus Sceleris"));
        var Diamabel       = Add(new Darklord("Diamabel"));
        var HakiShinpi     = Add(new Darklord("Haki Shinpi"));
        var LadislavMircea = Add(new Darklord("Prince Ladislav Mircea"));
        var DragaSaltbiter = Add(new Darklord("Draga Saltbiter"));
        var Tiyet          = Add(new Darklord("Tiyet"));
        var Gwydion        = Add(new Darklord("Gwydion"));
        var TheBaron       = Add(new Darklord("The Baron"));
        var BlakeRamsay    = Add(new Darklord("Dr. Blake Ramsay"));
        var KingCrocodile  = Add(new Darklord("King Crocodile"));
        var HiveQueen      = Add(new Darklord("Hive Queen"));
        var EasanTheMad    = Add(new Darklord("Easan the Mad"));
        var AlfredTimothy  = Add(new Darklord("Alfred Timothy"));
        var NathanTimothy  = Add(new Darklord("Captain Nathan Timothy"));
        var GregorZolnik   = Add(new Darklord("Boyar Gregor Zolnik"));
        var Leederik       = Add(new Darklord("Leederik", "The Phantom Lover"));
        var JackKarn       = Add(new Darklord("Jack Karn"));
        var Radanavich     = Add(new Darklord("Madame Radanavich"));
        var DurvenGraef    = Add(new Darklord("Lord Durven Graef"));
        var RagMan         = Add(new Darklord("Rag Man"));
        var Arantor        = Add(new Darklord("Arantor"));
        var IvaniaDreygu   = Add(new Darklord("Lady Ivania Dreygu"));
        var Ghoul          = Add(new Darklord("The Ghoul", "Vorno Kahnebor"));
        var Silvermaw      = Add(new Darklord("Silvermaw"));
        var Fotari         = Add(new Darklord("Fotari"));
        var LastPassenger  = Add(new Darklord("Last Passenger"));
        var KlorrDL        = Add(new Darklord("Klorr"));
        var Sarthak        = Add(new Darklord("Sarthak"));
        var FlimiraVhage   = Add(new Darklord("Detective Flimira Vhage"));
        var UndeadPaladin  = Add(new Darklord("Unnamed Undead Paladin"));
        var NharovGundar   = Add(new Darklord("Duke Nharov Gundar"));
        #endregion

        #region NPCs
        #endregion

        #region CreatureTraits
        #endregion

        #region Events
        #endregion

        #region Not bound by Canon

        var Unknown = Add(new Domain("Unknown")); //Special Entry
        var OutsideWorld = Add(new Domain("Outside of Ravenloft")); //Special Entry

        #region Location.Traits
        #endregion
        #region Domain.Traits
        var PocketDomains = Add(new Domain.Trait("Pocket Domains"));
        var IslandsOfTerror = Add(new Domain.Trait("Islands of Terror"));
        var Shadowfell = Add(new Domain.Trait("Shadowfell"));
        var Desert = Add(new Domain.Trait("Desert"));
        var Frozen = Add(new Domain.Trait("Frozen"));
        var Coastal = Add(new Domain.Trait("Coastal"));
        var MostlyWater = Add(new Domain.Trait("Coastal"));
        var NovelOnly = Add(new Domain.Trait("NovelOnly"));
        #endregion
        #region Item.Traits
        var MistTalisman = Add(new Item.Trait("Mist Talisman"));
        #endregion
        #endregion

        #region Add Domains to Clusters
        Cross.Add(Core, Barovia, Blaustein, Borca, Darkon, Necropolis, Dementlieu, Demise, Dominia, Falkovnia, Forlorn);
        Cross.Add(Core, Ghastria, Hazlan, Invidia, IsleOfTheRavens, Kartakass, Keening, Lamordia, Liffe, Lighthouse, Markovia);
        Cross.Add(Core, Mordent, Nebligtode, NovaVaasa, Richemulot, SeaOfSorrows, ShadowRift, Sithicus, Tepest, CastleIsland);
        Cross.Add(Core, TheIsle, Valachan, Vechor, Verbrek, VigilantsBluff, HouseOfLament);

        Cross.Add(CorePreGC, Barovia, SeaOfSorrows, Demise, Lamordia, Dementlieu, Mordent, Darkon, Ghenna, Keening, Tepest, Arak);
        Cross.Add(CorePreGC, Markovia, Dorvinia, Richemulot, Borca, NovaVaasa, NightmareLands, Hazlan, Verbrek, Invidia, Forlorn);
        Cross.Add(CorePreGC, Kartakass, Bluetspur, Sithicus, Valachan, Daglan);

        Cross.Add(Shadowlands, Avonleigh, ShadowbornManor, Nidala);
        Cross.Add(AmberWastes, HarAkir, Sebua, Pharazia, Kalidnay);
        Cross.Add(BurningPeaks, Tovag, Cavitius);
        Cross.Add(FrozenReaches, Sanguinia, Vorostokov);
        Cross.Add(VerdurousLands, Saragross, SriRaji, Niranjan, TheWildlands);
        Cross.Add(Zherisia, Paridon, Timor);
        #endregion

        #region Add DomainTraits to Domains
        Cross.Add(PocketDomains, HouseOfLament, CastleIsland, Davion, Aggarath, LMorai, WindingRoad, Scaena, TheEyrie, Cyre1313);
        Cross.Add(PocketDomains, VhageAgency, LeederiksTower);

        Cross.Add(IslandsOfTerror, Bluetspur, ICath, Ghenna, Kalidnay, Klorr, NightmareLands, Nosos, Odiare, Risibilos, Rokushima);
        Cross.Add(IslandsOfTerror, Souragne, StauntonBluffs, Paridon, AlKathos, Darani, DonskoysLand, Estrangia, Kislova, Malosia);
        Cross.Add(IslandsOfTerror, Maridrar, MithrasCourt, Riverbend);

        Cross.Add(Coastal,SriRaji, Souragne, Demise, Lamordia, Dementlieu, Mordent, Darkon, Rokushima, Dominia, Markovia, Ghastria);
        Cross.Add(Coastal, Blaustein, IsleOfTheRavens, Nebligtode, Lighthouse, Liffe, Vechor, NovaVaasa);

        Cross.Add(NovelOnly, AlKathos, Darani, DonskoysLand, Estrangia, Kislova, Malosia, Maridrar, MithrasCourt, Riverbend);
        Cross.Add(Shadowfell, Bakumora, Graefmotte, Histaven, Monadhan, Sunderheart, Timbergorge, Darani);
        Cross.Add(Desert, HarAkir, Sebua, Pharazia);
        Cross.Add(Frozen, Sanguinia, Vorostokov, Lamordia);
        Cross.Add(MostlyWater, SeaOfSorrows, Nebligtode, Saragross, CastleIsland, VigilantsBluff);
        #endregion

        Cross.Add(E2Canon, Core, CorePreGC, Shadowlands, AmberWastes, BurningPeaks, FrozenReaches, VerdurousLands);
        #region Add Canon Mistways 
        Cross.Add(E2Canon, EmeraldStream, HereticsEgress, JackalsRuse, LeviathanClutch, PathOfInnocence, RoadOfSecrets);
        Cross.Add(E2Canon, ShatterPassage, ShroudedWay, ViaCorona, WakeOfTheLoa, VenomousTears, WayfarerPath);

        Cross.Add(E2CanonPot, BleakRoad, OutlandersGate, SerpentsCoils, MtFrostAnhalla, OakOfScreams);
        Cross.Add(Netbook, CallOfTheClaw, SomnambulistPath, RoyalChannel, TheWindingJaws, UrchinsPath, SleepOfReason, IronWay);
        #endregion
        #region Add Canon Domains 
        Cross.Add(E2Canon, Barovia);
        Cross.Add(E2Canon, Bluetspur);
        Cross.Add(E2Canon, Borca);
        Cross.Add(E2Canon, LMorai);
        Cross.Add(E2Canon, Darkon);
        Cross.Add(E2Canon, Dementlieu);
        Cross.Add(E2Canon, Falkovnia);
        Cross.Add(E2Canon, HarAkir);
        Cross.Add(E2Canon, Hazlan);
        Cross.Add(E2Canon, ICath);
        Cross.Add(E2Canon, SriRaji);
        Cross.Add(E2Canon, Kartakass);
        Cross.Add(E2Canon, Lamordia);
        Cross.Add(E2Canon, Mordent);
        Cross.Add(E2Canon, Richemulot);
        Cross.Add(E2Canon, Tepest);
        Cross.Add(E2Canon, Valachan);
        Cross.Add(E2Canon, Forlorn);
        Cross.Add(E2Canon, Ghastria);
        Cross.Add(E2Canon, Ghenna);
        Cross.Add(E2Canon, Invidia);
        Cross.Add(E2Canon, Keening);
        Cross.Add(E2Canon, Markovia);
        Cross.Add(E2Canon, NightmareLands);
        Cross.Add(E2Canon, NovaVaasa);
        Cross.Add(E2Canon, Odiare);
        Cross.Add(E2Canon, WindingRoad);
        Cross.Add(E2Canon, Risibilos);
        Cross.Add(E2Canon, Scaena);
        Cross.Add(E2Canon, SeaOfSorrows);
        Cross.Add(E2Canon, Blaustein);
        Cross.Add(E2Canon, Dominia);
        Cross.Add(E2Canon, IsleOfTheRavens);
        Cross.Add(E2Canon, Lighthouse);
        Cross.Add(E2Canon, ShadowbornManor);
        Cross.Add(E2Canon, Souragne);
        Cross.Add(E2Canon, StauntonBluffs);
        Cross.Add(E2Canon, Tovag);
        Cross.Add(E2Canon, Paridon);
        Cross.Add(E2Canon, HouseOfLament);
        Cross.Add(E2Canon, Demise);
        Cross.Add(E2Canon, Kalidnay);
        Cross.Add(E2Canon, Sithicus);
        Cross.Add(E2Canon, Cavitius);
        Cross.Add(E2Canon, Aggarath);
        Cross.Add(E2Canon, Avonleigh);
        Cross.Add(E2Canon, CastleIsland);
        Cross.Add(E2Canon, Daglan);
        Cross.Add(E2Canon, Davion);
        Cross.Add(E2Canon, Liffe);
        Cross.Add(E2Canon, Nebligtode);
        Cross.Add(E2Canon, Necropolis);
        Cross.Add(E2Canon, Nidala);
        Cross.Add(E2Canon, Nosos);
        Cross.Add(E2Canon, Pharazia);
        Cross.Add(E2Canon, Rokushima);
        Cross.Add(E2Canon, Sanguinia);
        Cross.Add(E2Canon, Saragross);
        Cross.Add(E2Canon, Sebua);
        Cross.Add(E2Canon, ShadowRift);
        Cross.Add(E2Canon, TheEyrie);
        Cross.Add(E2Canon, TheIsle);
        Cross.Add(E2Canon, TheWildlands);
        Cross.Add(E2Canon, Timor);
        Cross.Add(E2Canon, Vechor);
        Cross.Add(E2Canon, Verbrek);
        Cross.Add(E2Canon, Vorostokov);
        Cross.Add(E2Canon, LeederiksTower);
        Cross.Add(E2Canon, Farelle);
        Cross.Add(E2Canon, RichtenHaus);
        Cross.Add(E2Canon, Graefmotte);
        Cross.Add(E2Canon, Histaven);
        Cross.Add(E2Canon, Monadhan);
        Cross.Add(E2Canon, Sunderheart);
        Cross.Add(E2Canon, Timbergorge);
        Cross.Add(E2Canon, Bakumora);
        Cross.Add(E2Canon, Cyre1313);
        Cross.Add(E2Canon, Klorr);
        Cross.Add(E2Canon, Niranjan);
        Cross.Add(E2Canon, VhageAgency);
        Cross.Add(E2Canon, VigilantsBluff);
        Cross.Add(E2Canon, Malosia);
        Cross.Add(E2Canon, MithrasCourt);
        Cross.Add(E2Canon, Riverbend);
        Cross.Add(E2Canon, Darani);
        Cross.Add(E2Canon, Kislova);
        Cross.Add(E2Canon, Estrangia);
        Cross.Add(E2Canon, AlKathos);
        Cross.Add(E2Canon, Maridrar);
        Cross.Add(E2Canon, DonskoysLand);
        Cross.Add(E2Canon, Arak);
        Cross.Add(E2Canon, Arkandale);
        Cross.Add(E2Canon, Dorvinia);
        Cross.Add(E2Canon, Gundarak);
        #endregion
        #region Add Canon Source
        #endregion
        #region Add Canon Location
        #endregion
        #region Add Canon Item
        #endregion
        #region Add Canon Darklord
        #endregion
        #region Add Canon NPC
        #endregion
        #region Add Canon CreatureTrait
        #endregion
        #region Add Canon Event
        #endregion

        #region Add Darklord to Domain
        Cross.Add(Odiare, Maligno);
        Cross.Add(Barovia, Strahd);
        #endregion

        #region Add Darklord trait to Darklord
        var Darklord = Add(new CreatureTrait("Darklord"));
        Cross.Add(Darklord, Strahd, Maligno);
        #endregion*/
    }
}
