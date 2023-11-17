using static Relationship;

internal static class AddToDatabase
{
    public static void Add () 
    {
        //Domains, NPCs, Items and Locations are Source-locked, but not Traits.

        AddI6Ravenloft();
        AddBeforeIWake();
        AddCommanderLegendsBattleforBaldursGate();
        AddDiceMastersStrahd();
        AddSpellfireMastertheMagic();

        void AddI6Ravenloft()
        {
            var releaseDate = "01/11/1983";
            string ExtraInfo = "<br/>&emsp;Authors: Tracy Hickman and Laura Hickman";
            ExtraInfo += "<br/>&emsp;Editor: Curtis Smith";
            ExtraInfo += "<br/>&emsp;Graphic Designer: Debra Stubbe";
            ExtraInfo += "<br/>&emsp;Illustrator: Clyde Caldwell";
            ExtraInfo += "<br/>&emsp;Module Info: An adventure for 6-8 characters of levels 5-7";
            ExtraInfo += "<br/>&emsp;Personal Notes: The term 'Vistani' had not been coined yet, instead the term 'gypsy' was used in this book. I've used 'Vistani' in its place.";
            using var ctx = Factory.CreateSource("I6: Ravenloft", releaseDate, ExtraInfo, Traits.Edition.e1, Traits.Media.module);
            if (ctx == null) return;

            var Barovia = ctx.CreateDomain("Barovia")
                .AddItems(
                    ctx.CreateItem("Tarokka Deck", "1, 4, 5").AddTraits(Traits.Status.Vistani),
                    ctx.CreateItem("Sunsword", "5, 31"),
                    ctx.CreateItem("Icon of Ravenloft", "14"),
                    ctx.CreateItem("Holy Symbol of Ravenkind", "17, 30"),
                    ctx.CreateItem("Tome of Strahd", "11, 31")
                ).AddLocations(
                    ctx.CreateLocation("The Old Svalich Road", "7"),
                    ctx.CreateLocation("The Gates of Barovia", "7").AddTraits(Traits.Creature.GreenSlime),
                    ctx.CreateLocation("The Svalich Woods", "1, 6-8").AddTraits(Traits.Creature.Worg),
                    ctx.CreateLocation("The River Ivlis", "8"),
                    ctx.CreateLocation("Burgomaster's Guest House", "9").AddTraits(Traits.Settlement.VillageOfBarovia),
                    ctx.CreateLocation("Cemetery of Barovia", "9, 11").AddTraits(Traits.Settlement.VillageOfBarovia, Traits.Creature.Spirit),
                    ctx.CreateLocation("Road Junction", "11"),
                    ctx.CreateLocation("Tser Falls", "11"),
                    ctx.CreateLocation("The Gates of Ravenloft", "11, 12")
                ).AddTraits(Traits.Creature.Ghoul);

            var VillageOfBarovia = ctx.CreateLocation("Village of Barovia", "1, 6, 7").AddDomains(Barovia).AddTraits(Traits.Location.Settlement, Traits.Settlement.VillageOfBarovia);
            var BildrathMercantile = ctx.CreateLocation("Bildrath's Mercantile", "8").AddDomains(Barovia).AddTraits(Traits.Settlement.VillageOfBarovia);
            var BloodVineTavern = ctx.CreateLocation("Blood of the Vine Tavern", "8, 9").AddDomains(Barovia).AddTraits(Traits.Settlement.VillageOfBarovia).AddInfo("Also known as 'Blood on the Vine' Tavern.");
            var MaryHouse = ctx.CreateLocation("Mad Mary's Townhouse", "9").AddDomains(Barovia).AddTraits(Traits.Settlement.VillageOfBarovia);
            var BurgomasterHome = ctx.CreateLocation("Burgomaster's Home", "1, 9").AddDomains(Barovia).AddTraits(Traits.Settlement.VillageOfBarovia);
            var BarovianChurch = ctx.CreateLocation("Church of Barovia", "9, 10").AddDomains(Barovia).AddTraits(Traits.Settlement.VillageOfBarovia);

            ctx.CreateNPC("Madam Eva","1, 6, 11, 32").AddTraits(Traits.Creature.Human, Traits.Alignment.CN, Traits.Status.Raunie.Item1, Traits.Status.Raunie.Item2)
                .AddLocations(
                    ctx.CreateLocation("Tser Pool Encampment", "11").AddDomains(Barovia).AddTraits(Traits.Location.Settlement, Traits.Settlement.TserPoolEncampment),
                    ctx.CreateLocation("Madam Eva's Tent", "11").AddDomains(Barovia).AddTraits(Traits.Settlement.TserPoolEncampment)
                );

            var CastleRavenloft = ctx.CreateLocation("Castle Ravenloft","1, 6, 8, 9, 12-30").AddDomains(Barovia).AddTraits(Traits.Status.Darklord)
                .AddNPCs(
                    ctx.CreateNPC("Guardian Of Sorrow", "16").AddTraits(Traits.Alignment.NE),
                    ctx.CreateNPC("Lief Lipsiege", "17").AddTraits(Traits.Alignment.CE, Traits.Creature.Human),
                    ctx.CreateNPC("Helga", "18").AddTraits(Traits.Alignment.CE, Traits.Creature.Human, Traits.Creature.Vampire),
                    ctx.CreateNPC("Cyrus Belview", "23").AddTraits(Traits.Alignment.CN, Traits.Creature.Human),

                    ctx.CreateNPC("Spectre Ab-Centeer", "27").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Artista DeSlop", "27").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Lady Isolde Yunk", "27").AddTraits(Traits.Status.Deceased).AddInfo("Also known as 'Isolde the Incredible'."),
                    ctx.CreateNPC("Prince Aerial Du Plumette", "27").AddTraits(Traits.Alignment.LE, Traits.Creature.Ghost).AddInfo("Also known as 'Aerial the Heavy'."),
                    ctx.CreateNPC("Artank Swilovich", "27").AddTraits(Traits.Status.Deceased, Traits.Status.BarovianWineDistillersBrotherhood),

                    ctx.CreateNPC("Marya Markovia", "27, 28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Endorovich the Terrible", "27, 28").AddTraits(Traits.Alignment.LE, Traits.Creature.Spectre),

                    ctx.CreateNPC("Duchess Dorfniya Dilisnya", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Pidlwik", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Sir Leanne Triksky", "28").AddTraits(Traits.Status.Deceased).AddInfo("Also known as 'Sir Lee the Crusher'."),
                    ctx.CreateNPC("Tasha Petrovna", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("King Toisky", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("King Intree Katsky", "28").AddTraits(Traits.Status.Deceased).AddInfo("Also known as 'Katsky the Bright'."),
                    ctx.CreateNPC("Stahbal Indi-Bhak", "28").AddTraits(Traits.Alignment.LE, Traits.Creature.Wight),
                    ctx.CreateNPC("Khazan", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Elsa Fallona", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Sir Sedrik Spinwitovich", "28").AddTraits(Traits.Status.Deceased).AddInfo("Also known as 'Admiral Spinwitovich'"),
                    ctx.CreateNPC("Animus", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Sir Erik Vonderbucks", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Ivan DeRose", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Stephan Gregorovich", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Intree Sik-Valoo", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Ardent Pallette", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Ivan Ivanovich", "28").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Prefect Ciril Romulich", "28").AddTraits(Traits.Status.Deceased),

                    ctx.CreateNPC("$$", "29").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("St. Finderway", "29").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("King Dostron", "29").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Gralmore Nimblenobs", "29").AddTraits(Traits.Status.Deceased),
                    ctx.CreateNPC("Americo Standardski", "29").AddTraits(Traits.Status.Deceased),

                    ctx.CreateNPC("Beucephalus", "29, 30").AddTraits(Traits.Creature.Horse, Traits.Creature.Nightmare),
                    ctx.CreateNPC("Tatsaul Eris", "30").AddTraits(Traits.Status.Deceased)
                ).AddTraits(
                    Traits.Creature.RedDragon, 
                    Traits.Creature.ShadowDemon, 
                    Traits.Creature.GiantSpider, 
                    Traits.Creature.HugeSpider,
                    Traits.Creature.Skeleton,
                    Traits.Creature.Horse,
                    Traits.Creature.Nightmare,
                    Traits.Creature.Banshee, 
                    Traits.Creature.Trapper, 
                    Traits.Creature.KeeningSpirit.Item1,
                    Traits.Creature.KeeningSpirit.Item2,
                    Traits.Creature.Gargoyle, 
                    Traits.Creature.RustMonster, 
                    Traits.Creature.GuardianPortrait, 
                    Traits.Creature.Spectre, 
                    Traits.Creature.Spirit, 
                    Traits.Creature.Wight, 
                    Traits.Creature.Wraith, 
                    Traits.Creature.Ghost, 
                    Traits.Creature.Bat, 
                    Traits.Creature.StrahdZombie, 
                    Traits.Creature.Cat, 
                    Traits.Creature.Witch, 
                    Traits.Creature.Hellhound, 
                    Traits.Creature.Werewolf, 
                    Traits.Creature.IronGolem
                );

            ctx.CreateNPC("Anna Petrovna", "28").AddDomains(Factory.OutsideRavenloft);
            ctx.CreateNPC("Arik", "8").AddTraits(Traits.Alignment.CN, Traits.Creature.Human).AddLocations(VillageOfBarovia, BloodVineTavern);
            ctx.CreateNPC("Donavich", "9").AddTraits(Traits.Alignment.LG, Traits.Creature.Human).AddLocations(VillageOfBarovia, BarovianChurch);

            var Strahd = ctx.CreateNPC("Count Strahd von Zarovich").AddTraits(Traits.Creature.Vampire, Traits.Creature.Human, Traits.Alignment.CE, Traits.Status.Darklord, Traits.Creature.Wolf, Traits.Creature.Worg, Traits.Creature.Bat, Traits.Creature.StrahdZombie, Traits.Creature.Zombie).AddLocations(CastleRavenloft).AddInfo("'ClosedBorders':'No one has left Barovia for centuries. This is because of the trapping fog that exists everywhere in Barovia. Once it is breathed, it infuses itself around a character's vital organs as a neutralized poison. The fog does not taste or smell any different than normal fog. It does not harm characters as long as they continue to breathe the air in Barovia. However, when they leave Barovia, the poison becomes active. Characters must save vs. poison or start to choke. Unless choking characters reenter Barovia within 24 hours, they die. The choking stops as soon as they breathe the fog again.  The fog is magically produced by Strahd and disappears entirely upon his destruction.'");

            var Sergei = ctx.CreateNPC("Sergei von Zarovich", "1, 4, 30, 31").AddTraits(Traits.Status.Deceased, Traits.Creature.Human).AddLocations(CastleRavenloft);

            var KingBarov = ctx.CreateNPC("King Barov", "28, 30").AddTraits(Traits.Status.Deceased, Traits.Creature.Human).AddLocations(CastleRavenloft);
            var Ravenovia = ctx.CreateNPC("Queen Ravenovia", "5, 28, 30").AddTraits(Traits.Status.Deceased, Traits.Creature.Human).AddLocations(CastleRavenloft);

            ctx.CreateRelationship(KingBarov, RelationshipType.Spouse, Ravenovia);
            ctx.CreateRelationship(KingBarov, RelationshipType.Parent, Strahd);
            ctx.CreateRelationship(KingBarov, RelationshipType.Parent, Sergei);
            ctx.CreateRelationship(Ravenovia, RelationshipType.Parent, Strahd);
            ctx.CreateRelationship(Ravenovia, RelationshipType.Parent, Sergei);


            var SashaIvliskova = ctx.CreateNPC("Sasha Ivliskova", "28").AddTraits(Traits.Alignment.CE, Traits.Creature.Human, Traits.Creature.Vampire).AddLocations(CastleRavenloft);
            var PatrinaVelikovna = ctx.CreateNPC("Patrina Velikovna", "28").AddTraits(Traits.Alignment.CE, Traits.Creature.Elf, Traits.Creature.Banshee).AddLocations(CastleRavenloft);
            ctx.CreateRelationship(Strahd, RelationshipType.Spouse, SashaIvliskova);
            ctx.CreateRelationship(Strahd, RelationshipType.Spouse, PatrinaVelikovna);

            var Tatyana = ctx.CreateNPC("Tatyana", "1, 30, 31").AddTraits(Traits.Status.Deceased, Traits.Status.Tatyana).AddDomains(Barovia);
            ctx.CreateRelationship(Sergei, RelationshipType.Spouse, Tatyana);



            var KolyanIndirovich = ctx.CreateNPC("Kolyan Indirovich", "7, 8, 9").AddTraits(Traits.Status.Deceased, Traits.Creature.Human).AddLocations(VillageOfBarovia, BurgomasterHome);
            var IreenaKolyana = ctx.CreateNPC("Ireena Kolyana").AddTraits(Traits.Alignment.LG, Traits.Creature.Human, Traits.Status.Tatyana).AddLocations(VillageOfBarovia, BurgomasterHome);
            var Ismark = ctx.CreateNPC("Ismark the Lesser", "8, 9").AddTraits(Traits.Alignment.LG, Traits.Creature.Human).AddLocations(VillageOfBarovia, BurgomasterHome, BloodVineTavern);
            ctx.CreateRelationship(KolyanIndirovich, RelationshipType.Adopted, IreenaKolyana);
            ctx.CreateRelationship(KolyanIndirovich, RelationshipType.Parent, Ismark);



            var MadMary = ctx.CreateNPC("Mad Mary", "9, 19").AddTraits(Traits.Alignment.CN, Traits.Creature.Human).AddLocations(VillageOfBarovia, MaryHouse);
            var Gertruda = ctx.CreateNPC("Gertruda", "9, 19").AddTraits(Traits.Alignment.NG, Traits.Creature.Human).AddLocations(VillageOfBarovia, CastleRavenloft, MaryHouse);
            ctx.CreateRelationship(MadMary, RelationshipType.Parent, Gertruda);



            var Bildrath = ctx.CreateNPC("Bildrath", "8").AddTraits(Traits.Alignment.LG, Traits.Creature.Human).AddLocations(VillageOfBarovia, BildrathMercantile);
            var Parriwimple = ctx.CreateNPC("Parriwimple", "8").AddTraits(Traits.Alignment.LN, Traits.Creature.Human).AddLocations(VillageOfBarovia, BildrathMercantile);
            var BildrathParents = ctx.CreateNPC("Bildrath Parents", string.Empty).AddTraits(Traits.NoLink);
            var BildrathSibling = ctx.CreateNPC("Bildrath Sibling", string.Empty).AddTraits(Traits.NoLink);
            ctx.CreateRelationship(BildrathParents, RelationshipType.Parent, Bildrath);
            ctx.CreateRelationship(BildrathParents, RelationshipType.Parent, BildrathSibling);
            ctx.CreateRelationship(BildrathSibling, RelationshipType.Parent, Parriwimple);
        }
        void AddBeforeIWake()
        {
            var releaseDate = "31/10/2007";
            string ExtraInfo = "<br/>&emsp;Author: Air Marmell";
            using var ctx = Factory.CreateSource("Before I Wake", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.novel);
            if (ctx == null) return;

            var Bluetspur = ctx.CreateDomain("Bluetspur").AddNPCs(
                ctx.CreateNPC("Clarke").AddTraits(Traits.Creature.Human),
                ctx.CreateNPC("Phillips").AddTraits(Traits.Creature.Human, Traits.Status.Deceased),
                ctx.CreateNPC("God-Brain").AddTraits(Traits.Status.Darklord)
                );

            var Darkon = ctx.CreateDomain("Darkon").AddLocations(ctx.CreateLocation("Nartok").AddTraits(Traits.Location.Settlement));
            ctx.CreateLocation("Mills of Nartok").AddTraits(Traits.Settlement.Nartok).AddDomains(Darkon).ExtraInfo = "For Darkonian Lumber";

            ctx.CreateDomain("Lamordia");

            var DharlaethAsylum = ctx.CreateLocation("Dharlaeth Asylum").AddDomains(Factory.InsideRavenloft).AddNPCs(
                ctx.CreateNPC("Doctor Augustus").AddTraits(Traits.Creature.Human),
                ctx.CreateNPC("Nurse Roberts").AddTraits(Traits.Creature.Human)
                );

            ctx.CreateNPC("Howard Ashton").AddTraits(Traits.Creature.Human).AddDomains(Darkon, Bluetspur).AddLocations(DharlaethAsylum);
        }
        void AddCommanderLegendsBattleforBaldursGate()
        {
            var releaseDate = "10/06/2022";
            string ExtraInfo = "<br/>&emsp;Illustrator: Slawomir Maniak";
            ExtraInfo += "<br/>&emsp;A Magic the Gathering Deck";
            using var ctx = Factory.CreateSource("Commander Legends: Battle for Baldur's Gate", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
            if (ctx == null) return;

            var Barovia = ctx.CreateDomain("Barovia").AddNPCs(
                ctx.CreateNPC("Baba Lysaga").AddTraits(Traits.Creature.Human, Traits.Creature.Witch)
                );
        }
        void AddDiceMastersStrahd()
        {
            var releaseDate = "8/10/2016";
            var ExtraInfo = string.Empty;
            using var ctx = Factory.CreateSource("Dice Masters: Strahd", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
            if (ctx == null) return;

            ctx.CreateNPC("Count Strahd von Zarovich").AddLocations(ctx.CreateLocation("Castle Ravenloft"));
        }
        void AddSpellfireMastertheMagic()
        {
            const string ExtraInfo = "Any missing cards are either not related to Ravenloft or too generic to add.";
            AddRavenloftSet();
            AddArtifactsSet();
            Add3rdEditionSet();
            AddUnderdarkSet();
            AddRunesNRuinsSet();
            Add4thEditionSet();
            AddNightstalkersSet();
            AddDungeonsSet();

            AddConquestSet();
            AddMilleniumSet();

            void AddRavenloftSet()
            {
                var releaseDate = "01/08/1994";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Ravenloft Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateDomain("Barovia", "1/100");
                ctx.CreateDomain("Darkon", "2/100");
                ctx.CreateDomain("Lamordia", "3/100");
                ctx.CreateDomain("Mordent", "4/100");
                ctx.CreateDomain("Kartakass", "5/100");
                ctx.CreateDomain("Keening", "6/100");
                ctx.CreateDomain("Tepest", "7/100");
                ctx.CreateDomain("Verbrek", "8/100").AddTraits(Traits.Creature.Wolf);
                ctx.CreateDomain("Invidia", "9/100");
                ctx.CreateDomain("Nova Vaasa", "10/100");
                ctx.CreateDomain("Dementlieu", "11/100");
                ctx.CreateDomain("Valachan", "12/100");
                ctx.CreateDomain("Har'Akir", "13/100");
                ctx.CreateDomain("Souragne", "14/100");
                ctx.CreateDomain("Sri Raji", "15/100");

                ctx.CreateLocation("Castle Ravenloft", "16/100");
                var AzalinGraveyard = ctx.CreateLocation("Azalin's Graveyard", "17/100").AddTraits(Traits.Creature.Zombie);
                ctx.CreateLocation("Kargat Mausoleum", "18/100").AddTraits(Traits.Status.TheKargat);

                ctx.CreateDomain("Paridon", "19/100").AddTraits(Traits.Creature.Doppelganger);

                ctx.CreateLocation("Pharaoh's Rest", "20/100");

                ctx.CreateItem("Spell Book of Drawmji", "29/100");
                ctx.CreateItem("Tarokka Deck", "56/100");
                ctx.CreateItem("Timepiece of Klorr", "57/100");
                ctx.CreateItem("Ring of Regeneration", "58/100");
                ctx.CreateItem("Sun Sword", "59/100");
                ctx.CreateItem("Blood Coin", "60/100");
                ctx.CreateItem("Staff of Mimicry", "61/100");
                ctx.CreateItem("Soul Searcher Medallion", "62/100");
                ctx.CreateItem("Ring of Reversion", "63/100");
                ctx.CreateItem("Amulet of the Beast", "64/100");

                ctx.CreateItem("Cat of Felkovic", "65/100");
                ctx.CreateItem("Apparatus", "66/100");
                ctx.CreateItem("Crown of Souls", "67/100");
                ctx.CreateItem("Holy Symbol of Ravenkind", "68/100");
                ctx.CreateItem("Tapestry of Dark Souls", "69/100");
                ctx.CreateItem("Fang of the Nosferatu", "70/100");

                ctx.CreateNPC("Azalin", "Azalin Rex", "82/100").AddLocations(AzalinGraveyard);
                ctx.CreateNPC("Adam", "83/100");
                ctx.CreateNPC("Ankhtepot", "84/100");
                ctx.CreateNPC("Ireena Kolyana", "85/100");
                ctx.CreateNPC("Dr. Rudolph Van Richten", "86/100");
                ctx.CreateNPC("Harkon Lukas", "87/100");
                ctx.CreateNPC("Headless Horseman", "88/100").AddTraits(Traits.Creature.Horse);
                ctx.CreateNPC("Arijani", "89/100");
                ctx.CreateNPC("Wilfred Godefroy", "90/100");
                ctx.CreateNPC("Tiyet", "91/100");
                ctx.CreateNPC("Sir Hiregaard", "Sir Tristen Hiregaard", "92/100");
                ctx.CreateNPC("Gabrielle Aderre", "93/100");
                ctx.CreateNPC("Hags of Tepest", "94/100").AddTraits(Traits.Creature.Hag);
                ctx.CreateNPC("Sir Edmund Bloodsworth", "95/100").AddTraits(Traits.Creature.Doppelganger);
                ctx.CreateNPC("High Master Illithid", "96/100").AddTraits(Traits.Creature.MindFlayer.Item1, Traits.Creature.MindFlayer.Item2);
                ctx.CreateNPC("Dr. Mordenheim", "Dr. Victor Mordenheim", "97/100");
                ctx.CreateNPC("Sergei Von Zarovich", "98/100");
                ctx.CreateNPC("Lord Soth", "99/100");
                ctx.CreateNPC("Strahd Von Zarovich", "Count Strahd von Zarovich", "100/100");
            }
            void AddArtifactsSet()
            {
                var releaseDate = "01/05/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Artifacts Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);

                ctx.CreateItem("Seal of Lost Arak", "12/100");
                ctx.CreateItem("Crystal of the Ebon Flame", "13/100");
                ctx.CreateNPC("Yagno Petrovna", "82/100");
                ctx.CreateDomain("Bluet Spur", "Bluetspur", "88/100");
                ctx.CreateDomain("Ancient Kalidnay", "Kalidnay", "92/100");
                ctx.CreateItem("Death Rock", "2/20");
                ctx.CreateNPC("Young Strahd", "Count Strahd von Zarovich", "8/20");
                ctx.CreateNPC("Ghostly Piper", "10/20");
                if (ctx == null) return;
            }
            void Add3rdEditionSet()
            {
                var releaseDate = "01/10/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, 3rd Edition Set ", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);

                ctx.CreateItem("Tapestry of the Stag", "426/440").AddTraits(Traits.Creature.VampireBat);
            }
            void AddUnderdarkSet()
            {
                var releaseDate = "01/12/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Underdark Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);

                ctx.CreateLocation("UnderDread", "9/100");
                ctx.CreateLocation("The Dread Chamber", "18/100");
                ctx.CreateNPC("The Red Death", "68/100");
                ctx.CreateNPC("Chantal the Banshee", "97/100").AddTraits(Traits.Creature.Banshee);
                ctx.CreateNPC("Iseult", "99/100");
            }
            void AddRunesNRuinsSet()
            {
                var releaseDate = "01/02/1996";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Runes & Ruins Set ", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);

                ctx.CreateLocation("Tower of Spirits", "15/25");
            }
            void Add4thEditionSet()
            {
                var releaseDate = "01/07/1996";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, 4th Edition Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);

                ctx.CreateDomain("Arak", "60/500").AddTraits(Traits.Creature.Drow);
                ctx.CreateDomain("Bluet Spur", "Bluetspur", "59/500");
                ctx.CreateDomain("Borca", "61/500");
                ctx.CreateDomain("Gundarak", "62/500").AddNPCs(
                    ctx.CreateNPC("Lord Gundar", "62/500").AddTraits(Traits.Creature.Ghost, Traits.Status.Darklord)
                    );
                ctx.CreateDomain("Sithicus", "63/500");
                ctx.CreateDomain("Nightmare Lands", "64/500");

                ctx.CreateNPC("Red Jack", "113/500");
                ctx.CreateNPC("Red Tide", "114/500").AddTraits(Traits.Creature.Vampire);

                ctx.CreateNPC("Pearl", "304/500");
                ctx.CreateNPC("Amber", "305/500");
                ctx.CreateNPC("Aquamarina", "306/500");

                ctx.CreateNPC("Ting Ling", "354/500");

                ctx.CreateNPC("Bride of Malice", "357/500").AddTraits(Traits.Creature.Vampire, Traits.Creature.Dragon);
                ctx.CreateNPC("Vulture of the Core", "358/500").AddTraits(Traits.Creature.Vulture);
                ctx.CreateNPC("The Bog Monster", "360/500");
            }
            void AddNightstalkersSet()
            {
                var releaseDate = "01/09/1996";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Nightstalkers Set ", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);

                ctx.CreateDomain("Falkovnia", "5/100");
                ctx.CreateDomain("Richemulot", "6/100");
                ctx.CreateLocation("Haunted Graveyard", "11/100").AddTraits(Traits.Creature.Ghost);
                ctx.CreateNPC("Jacqueline Renier", "32/100");
                ctx.CreateNPC("Ratik Ubel", "33/100");
                ctx.CreateNPC("Julio, Master Thief of Haslic", "34/100");
                ctx.CreateNPC("Nemon Hotep", "67/100");
                ctx.CreateNPC("Shera the Wise", "68/100");
                ctx.CreateNPC("Varney the Vampire", "16/25").AddTraits(Traits.Creature.Vampire);
                ctx.CreateNPC("Gib Lhadsemlo", "18/25").AddTraits(Traits.Creature.FleshGolem);
                ctx.CreateLocation("Mad Scientist's Laboratory", "25/25");
            }
            void AddDungeonsSet()
            {
                var releaseDate = "01/10/1997";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Dungeons Set ", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);

                ctx.CreateLocation("Castle Strahd", "Castle Ravenloft", "7/100").AddTraits(Traits.Creature.VampireBat);
                ctx.CreateLocation("The Ruins of Lololia", "32/100");
                ctx.CreateItem("Borer", "61/100");
            }
            void AddMilleniumSet()
            {
                var releaseDate = "01/03/2002";
                var AddedExtraInfo = ExtraInfo + Environment.NewLine + "This set was made by fans, but was still using Spellfire trademark.";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Millenium Set ", releaseDate, AddedExtraInfo, Traits.Edition.e0, Traits.Media.boardgame, Traits.Canon.NotCanon);

                ctx.CreateItem("Strahd's Medallion", "23/99").AddTraits(Traits.Creature.Vampire);
            }
            void AddConquestSet()
            {
                var releaseDate = "01/08/2004";
                var AddedExtraInfo = ExtraInfo + Environment.NewLine + "This set was made by fans, but was still using Spellfire trademark.";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Conquest Set ", releaseDate, AddedExtraInfo, Traits.Edition.e0, Traits.Media.boardgame, Traits.Canon.NotCanon);

                ctx.CreateLocation("Castle Strahd", "Castle Ravenloft", "73/81").AddTraits(Traits.Creature.VampireBat);
            }
        }
        Factory.db.SaveChanges();
    }
}
