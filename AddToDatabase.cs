﻿using static Relationship;

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
                .AddLocations(
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

            ctx.CreateNPC("Madam Eva", "1, 6, 11, 32").AddTraits(Traits.Creature.Human, Traits.Alignment.CN)
                .AddLocations(
                    ctx.CreateLocation("Tser Pool Encampment", "11").AddDomains(Barovia).AddTraits(Traits.Location.Settlement, Traits.Settlement.TserPoolEncampment),
                    ctx.CreateLocation("Madam Eva's Tent", "11").AddDomains(Barovia).AddTraits(Traits.Settlement.TserPoolEncampment)
                );

            var CastleRavenloft = ctx.CreateLocation("Castle Ravenloft","1, 6, 8, 9, 12-30").AddDomains(Barovia)
                .AddNPCs(
                    ctx.CreateNPC("Guardian Of Sorrow", "16").AddTraits(Traits.Alignment.NE),
                    ctx.CreateNPC("Lief Lipsiege", "17").AddTraits(Traits.Alignment.CE, Traits.Creature.Human),
                    ctx.CreateNPC("Helga", "18").AddTraits(Traits.Alignment.CE, Traits.Creature.Human, Traits.Creature.Vampire),
                    ctx.CreateNPC("Cyrus Belview", "23").AddTraits(Traits.Alignment.CN, Traits.Creature.Human),

                    ctx.CreateNPC("Spectre Ab-Centeer", "27").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Artista DeSlop", "27").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Lady Isolde Yunk", "27").AddGroups(ctx.Deceased).AddInfo("Also known as 'Isolde the Incredible'."),
                    ctx.CreateNPC("Prince Aerial Du Plumette", "27").AddTraits(Traits.Alignment.LE, Traits.Creature.Ghost).AddInfo("Also known as 'Aerial the Heavy'."),
                    ctx.CreateNPC("Artank Swilovich", "27").AddGroups(ctx.Deceased, ctx.CreateGroup("Barovian Wine Distillers Brotherhood", "27")),

                    ctx.CreateNPC("Duchess Dorfniya Dilisnya", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Pidlwik", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Sir Leanne Triksky", "28").AddGroups(ctx.Deceased).AddInfo("Also known as 'Sir Lee the Crusher'."),
                    ctx.CreateNPC("Tasha Petrovna", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("King Toisky", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("King Intree Katsky", "28").AddGroups(ctx.Deceased).AddInfo("Also known as 'Katsky the Bright'."),
                    ctx.CreateNPC("Stahbal Indi-Bhak", "28").AddTraits(Traits.Alignment.LE, Traits.Creature.Wight),
                    ctx.CreateNPC("Khazan", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Elsa Fallona", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Sir Sedrik Spinwitovich", "28").AddGroups(ctx.Deceased).AddInfo("Also known as 'Admiral Spinwitovich'"),
                    ctx.CreateNPC("Animus", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Sir Erik Vonderbucks", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Ivan DeRose", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Stephan Gregorovich", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Intree Sik-Valoo", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Ardent Pallette", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Ivan Ivanovich", "28").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Prefect Ciril Romulich", "28").AddGroups(ctx.Deceased),

                    ctx.CreateNPC("$$", "29").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("St. Finderway", "29").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("King Dostron", "29").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Gralmore Nimblenobs", "29").AddGroups(ctx.Deceased),
                    ctx.CreateNPC("Americo Standardski", "29").AddGroups(ctx.Deceased),

                    ctx.CreateNPC("Beucephalus", "29, 30").AddTraits(Traits.Creature.Horse, Traits.Creature.Nightmare),
                    ctx.CreateNPC("Tatsaul Eris", "30").AddGroups(ctx.Deceased)
                ).AddItems(
                    ctx.CreateItem("Sunsword", "5, 31").AddDomains(ctx.OutsideRavenloft),
                    ctx.CreateItem("Icon of Ravenloft", "14"),
                    ctx.CreateItem("Holy Symbol of Ravenkind", "17, 30").AddTraits(Traits.Creature.Vampire)
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

            ctx.CreateNPC("Anna Petrovna", "28").AddDomains(ctx.OutsideRavenloft).AddInfo("Probably deceased but they never explicitly said so.");
            ctx.CreateNPC("Arik", "8").AddTraits(Traits.Alignment.CN, Traits.Creature.Human).AddLocations(VillageOfBarovia, BloodVineTavern);
            ctx.CreateNPC("Donavich", "9").AddTraits(Traits.Alignment.LG, Traits.Creature.Human).AddLocations(VillageOfBarovia, BarovianChurch);

            var Strahd = ctx.CreateNPC("Count Strahd von Zarovich")
                .AddTraits(Traits.Creature.Vampire, Traits.Creature.Human, Traits.Alignment.CE, Traits.Creature.Wolf, Traits.Creature.Worg, Traits.Creature.Bat, Traits.Creature.StrahdZombie, Traits.Creature.Zombie)
                .AddLocations(CastleRavenloft)
                .AddItems(ctx.CreateItem("Tome of Strahd", "11, 31"))
                .AddInfo("'ClosedBorders':'No one has left Barovia for centuries. This is because of the trapping fog that exists everywhere in Barovia. Once it is breathed, it infuses itself around a character's vital organs as a neutralized poison. The fog does not taste or smell any different than normal fog. It does not harm characters as long as they continue to breathe the air in Barovia. However, when they leave Barovia, the poison becomes active. Characters must save vs. poison or start to choke. Unless choking characters reenter Barovia within 24 hours, they die. The choking stops as soon as they breathe the fog again.  The fog is magically produced by Strahd and disappears entirely upon his destruction.'");

            var Sergei = ctx.CreateNPC("Sergei von Zarovich", "1, 4, 30, 31").AddTraits(Traits.Creature.Human).AddLocations(CastleRavenloft).AddGroups(ctx.Deceased);

            var KingBarov = ctx.CreateNPC("King Barov", "28, 30").AddTraits(Traits.Creature.Human).AddLocations(CastleRavenloft).AddGroups(ctx.Deceased);
            var Ravenovia = ctx.CreateNPC("Queen Ravenovia", "5, 28, 30").AddTraits(Traits.Creature.Human).AddLocations(CastleRavenloft).AddGroups(ctx.Deceased);

            ctx.CreateRelationship(KingBarov, "Spouse", Ravenovia);
            ctx.CreateRelationship(KingBarov, "Parent", Strahd);
            ctx.CreateRelationship(KingBarov, "Parent", Sergei);
            ctx.CreateRelationship(Ravenovia, "Parent", Strahd);
            ctx.CreateRelationship(Ravenovia, "Parent", Sergei);

            var Marya = ctx.CreateNPC("Marya Markovia", "27, 28").AddGroups(ctx.Deceased).AddLocations(CastleRavenloft);
            var Endorovich = ctx.CreateNPC("Endorovich the Terrible", "27, 28").AddTraits(Traits.Alignment.LE, Traits.Creature.Spectre).AddLocations(CastleRavenloft);
            ctx.CreateRelationship(Endorovich, "Loves", Marya);
            ctx.CreateRelationship(Endorovich, "Accidentally Murdered", Marya);

            var SashaIvliskova = ctx.CreateNPC("Sasha Ivliskova", "28").AddTraits(Traits.Alignment.CE, Traits.Creature.Human, Traits.Creature.Vampire).AddLocations(CastleRavenloft);
            var PatrinaVelikovna = ctx.CreateNPC("Patrina Velikovna", "28").AddTraits(Traits.Alignment.CE, Traits.Creature.Elf, Traits.Creature.Banshee).AddLocations(CastleRavenloft);
            ctx.CreateRelationship(Strahd, "Spouse", SashaIvliskova);
            ctx.CreateRelationship(Strahd, "Spouse", PatrinaVelikovna);

            var ReincarnationsOfTatyana = ctx.CreateGroup("Reincarnations of Tatyana", "30, 31");
            var Tatyana = ctx.CreateNPC("Tatyana", "1, 30, 31").AddDomains(Barovia).AddGroups(ctx.Deceased, ReincarnationsOfTatyana);
            ctx.CreateRelationship(Sergei, "Spouse", Tatyana);



            var KolyanIndirovich = ctx.CreateNPC("Kolyan Indirovich", "7, 8, 9").AddTraits(Traits.Creature.Human).AddLocations(VillageOfBarovia, BurgomasterHome).AddGroups(ctx.Deceased);
            var IreenaKolyana = ctx.CreateNPC("Ireena Kolyana").AddTraits(Traits.Alignment.LG, Traits.Creature.Human).AddLocations(VillageOfBarovia, BurgomasterHome).AddGroups(ReincarnationsOfTatyana);
            var Ismark = ctx.CreateNPC("Ismark the Lesser", "8, 9").AddTraits(Traits.Alignment.LG, Traits.Creature.Human).AddLocations(VillageOfBarovia, BurgomasterHome, BloodVineTavern);
            ctx.CreateRelationship(KolyanIndirovich, "Adopted", IreenaKolyana);
            ctx.CreateRelationship(KolyanIndirovich, "Parent", Ismark);



            var MadMary = ctx.CreateNPC("Mad Mary", "9, 19").AddTraits(Traits.Alignment.CN, Traits.Creature.Human).AddLocations(VillageOfBarovia, MaryHouse);
            var Gertruda = ctx.CreateNPC("Gertruda", "9, 19").AddTraits(Traits.Alignment.NG, Traits.Creature.Human).AddLocations(VillageOfBarovia, CastleRavenloft, MaryHouse);
            ctx.CreateRelationship(MadMary, "Parent", Gertruda);
            ctx.CreateRelationship(Gertruda, "Daughter", MadMary);

            var Bildrath = ctx.CreateNPC("Bildrath", "8").AddTraits(Traits.Alignment.LG, Traits.Creature.Human).AddLocations(VillageOfBarovia, BildrathMercantile);
            var Parriwimple = ctx.CreateNPC("Parriwimple", "8").AddTraits(Traits.Alignment.LN, Traits.Creature.Human).AddLocations(VillageOfBarovia, BildrathMercantile);

            ctx.CreateRelationship(Bildrath, "Uncle", Parriwimple);
            ctx.CreateRelationship(Parriwimple, "Nephew", Bildrath);
        }
        void AddBeforeIWake()
        {
            var releaseDate = "31/10/2007";
            string ExtraInfo = "<br/>&emsp;Author: Air Marmell";
            using var ctx = Factory.CreateSource("Before I Wake", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.novel);
            if (ctx == null) return;

            var Bluetspur = ctx.CreateDomain("Bluetspur").AddNPCs(
                ctx.CreateNPC("Clarke").AddTraits(Traits.Creature.Human),
                ctx.CreateNPC("Phillips").AddTraits(Traits.Creature.Human).AddGroups(ctx.Deceased),
                ctx.CreateNPC("God-Brain")
                );

            var Darkon = ctx.CreateDomain("Darkon").AddLocations(ctx.CreateLocation("Nartok").AddTraits(Traits.Location.Settlement));
            ctx.CreateLocation("Mills of Nartok").AddTraits(Traits.Settlement.Nartok).AddDomains(Darkon).ExtraInfo = "For Darkonian Lumber";

            var Lamordia = ctx.CreateDomain("Lamordia");

            var DharlaethAsylum = ctx.CreateLocation("Dharlaeth Asylum").AddDomains(Lamordia).AddNPCs(
                ctx.CreateNPC("Doctor Augustus").AddTraits(Traits.Creature.Human),
                ctx.CreateNPC("Nurse Roberts").AddTraits(Traits.Creature.Human)
                );
            DharlaethAsylum.ExtraInfo = "Whilst not stated in the story, Ari Marmell said the Asylum is located in Lamordia.<a href='https://bsky.app/profile/mouseferatu.bsky.social/post/3kelemhzy2l2n'>Bluesky Link</a>";

            ctx.CreateNPC("Howard Ashton").AddTraits(Traits.Creature.Human).AddDomains(Darkon, Bluetspur, Lamordia).AddLocations(DharlaethAsylum);
        }
        void AddCommanderLegendsBattleforBaldursGate()
        {
            var releaseDate = "10/06/2022";
            string ExtraInfo = "<br/>&emsp;Illustrator: Slawomir Maniak";
            ExtraInfo += "<br/>&emsp;A Magic the Gathering Deck";
            using var ctx = Factory.CreateSource("Commander Legends: Battle for Baldur's Gate", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
            if (ctx == null) return;

            ctx.CreateDomain("Barovia").AddNPCs(ctx.CreateNPC("Baba Lysaga").AddTraits(Traits.Creature.Human, Traits.Creature.Witch));
        }
        void AddDiceMastersStrahd()
        {
            var releaseDate = "8/10/2016";
            var ExtraInfo = string.Empty;
            using var ctx = Factory.CreateSource("Dice Masters: Strahd", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
            if (ctx == null) return;

            ctx.InsideRavenloft.AddLocations(ctx.CreateLocation("Castle Ravenloft")).AddNPCs(ctx.CreateNPC("Count Strahd von Zarovich"));
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

            AddMilleniumSet();
            AddConquestSet();

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

                ctx.CreateLocation("Castle Ravenloft", "16/100").AddDomains(ctx.InsideRavenloft);
                var AzalinGraveyard = ctx.CreateLocation("Azalin's Graveyard", "17/100").AddTraits(Traits.Creature.Zombie).AddDomains(ctx.InsideRavenloft);
                ctx.CreateLocation("Kargat Mausoleum", "18/100").AddGroups(ctx.CreateGroup("The Kargat", "18/100")).AddDomains(ctx.InsideRavenloft);

                ctx.CreateDomain("Paridon", "19/100").AddTraits(Traits.Creature.Doppelganger); //WHY IS PARIDON MISSING DOPPELGANGERS

                ctx.CreateLocation("Pharaoh's Rest", "20/100").AddDomains(ctx.InsideRavenloft);

                ctx.CreateGroup("Dark Powers", "22/100").AddDomains(ctx.InsideRavenloft);
                ctx.CreateItem("Spell Book of Drawmji", "29/100").AddTraits(Traits.CampaignSetting.Greyhawk).AddDomains(ctx.InsideRavenloft);

                ctx.InsideRavenloft.AddTraits(
                    Traits.Creature.GraveElemental, // 35/100
                    Traits.Creature.Shade // 47/100
                ).AddItems(
                    ctx.CreateItem("Tarokka Deck", "56/100"),
                    ctx.CreateItem("Timepiece of Klorr", "57/100"),
                    ctx.CreateItem("Ring of Regeneration", "58/100"),
                    ctx.CreateItem("Sun Sword", "Sunsword", "59/100"),
                    ctx.CreateItem("Blood Coin", "60/100"),
                    ctx.CreateItem("Staff of Mimicry", "61/100"),
                    ctx.CreateItem("Soul Searcher Medallion", "62/100"),
                    ctx.CreateItem("Ring of Reversion", "63/100"),
                    ctx.CreateItem("Amulet of the Beast", "64/100"),
                    ctx.CreateItem("Cat of Felkovic", "65/100"),
                    ctx.CreateItem("Apparatus", "66/100"),
                    ctx.CreateItem("Crown of Souls", "67/100"),
                    ctx.CreateItem("Holy Symbol of Ravenkind", "68/100"),
                    ctx.CreateItem("Tapestry of Dark Souls", "69/100"),
                    ctx.CreateItem("Fang of the Nosferatu", "70/100")
                ).AddTraits(
                    Traits.Creature.Vampire, // 71/100
                    Traits.Creature.Wolf, // 72/100
                    Traits.Creature.FleshGolem, // 73/100
                    Traits.Creature.GhostShip, // 74/100
                    Traits.Creature.StrahdZombie, // 75/100
                    Traits.Creature.Spectre // 77/100
                ).AddGroups(
                    ctx.CreateGroup("Vistani", "78/100")
                ).AddTraits(
                    Traits.Creature.LoupGarou, // 79/100
                    Traits.Creature.Werebat //90/100
                ).AddNPCs(
                    ctx.CreateNPC("Azalin", "Azalin Rex", "82/100").AddLocations(AzalinGraveyard),
                    ctx.CreateNPC("Adam", "83/100"),
                    ctx.CreateNPC("Ankhtepot", "84/100"),
                    ctx.CreateNPC("Ireena Kolyana", "85/100"),
                    ctx.CreateNPC("Dr. Rudolph Van Richten", "86/100"),
                    ctx.CreateNPC("Harkon Lukas", "87/100"),
                    ctx.CreateNPC("Headless Horseman", "88/100").AddTraits(Traits.Creature.Horse),
                    ctx.CreateNPC("Arijani", "89/100"),
                    ctx.CreateNPC("Wilfred Godefroy", "90/100"),
                    ctx.CreateNPC("Tiyet", "91/100"),
                    ctx.CreateNPC("Sir Tristen Hiregaard", "92/100"),
                    ctx.CreateNPC("Gabrielle Aderre", "93/100")
                ).AddGroups(
                    ctx.CreateGroup("Hags Of Tepest", "94/100").AddTraits(Traits.Creature.Hag)
                ).AddNPCs(
                    ctx.CreateNPC("Sir Edmund Bloodsworth", "95/100").AddTraits(Traits.Creature.Doppelganger),
                    ctx.CreateNPC("High Master Illithid", "96/100").AddTraits(Traits.Creature.MindFlayer.Item1, Traits.Creature.MindFlayer.Item2),
                    ctx.CreateNPC("Dr. Victor Mordenheim", "97/100"),
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

                ctx.CreateItem("Seal of Lost Arak", "12/100").AddDomains(ctx.InsideRavenloft);
                ctx.CreateItem("Crystal of the Ebon Flame", "13/100").AddDomains(ctx.InsideRavenloft);

                ctx.CreateNPC("Yagno Petrovna", "82/100").AddDomains(ctx.InsideRavenloft);
                ctx.CreateDomain("Bluet Spur", "Bluetspur", "88/100");
                ctx.CreateDomain("Kalidnay", "92/100").AddTraits(Traits.CampaignSetting.DarkSun);

                ctx.CreateItem("Death Rock", "2/20").AddDomains(ctx.InsideRavenloft);

                ctx.CreateNPC("Count Strahd von Zarovich", "8/20").AddDomains(ctx.InsideRavenloft);
                ctx.CreateNPC("Ghostly Piper", "10/20").AddDomains(ctx.InsideRavenloft);
            }
            void Add3rdEditionSet()
            {
                var releaseDate = "01/10/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, 3rd Edition Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.CreateItem("Tapestry of the Stag", "426/440").AddTraits(Traits.Creature.VampireBat, Traits.CampaignSetting.Greyhawk).AddDomains(ctx.InsideRavenloft);
            }
            void AddUnderdarkSet()
            {
                var releaseDate = "01/12/1995";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Underdark Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.InsideRavenloft.AddLocations(
                    ctx.CreateLocation("UnderDread", "9/100"),
                    ctx.CreateLocation("The Dread Chamber", "18/100")
                ).AddNPCs(
                    ctx.CreateNPC("The Red Death", "68/100"),
                    ctx.CreateNPC("Chantal the Banshee", "97/100").AddTraits(Traits.Creature.Banshee),
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

                ctx.CreateDomain("Arak", "60/500").AddTraits(Traits.Creature.Drow);
                ctx.CreateDomain("Bluet Spur", "Bluetspur", "59/500");
                ctx.CreateDomain("Borca", "61/500");
                ctx.CreateDomain("Gundarak", "62/500").AddGroups(
                    ctx.CreateGroup("Darklord", "62/500").AddNPCs(ctx.CreateNPC("Lord Gundar", "62/500").AddTraits(Traits.Creature.Ghost))
                );
                ctx.CreateDomain("Sithicus", "63/500");
                ctx.CreateDomain("Nightmare Lands", "64/500");

                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Red Jack", "113/500"),
                    ctx.CreateNPC("Red Tide", "114/500").AddTraits(Traits.Creature.Vampire),

                    ctx.CreateNPC("Pearl", "304/500"),
                    ctx.CreateNPC("Amber", "305/500"),
                    ctx.CreateNPC("Aquamarina", "306/500"),

                    ctx.CreateNPC("Ting Ling", "354/500"),

                    ctx.CreateNPC("Bride of Malice", "357/500").AddTraits(Traits.Creature.Vampire, Traits.Creature.Dragon),
                    ctx.CreateNPC("Vulture of the Core", "358/500").AddTraits(Traits.Creature.Vulture),
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

                ctx.CreateLocation("Haunted Graveyard", "11/100").AddTraits(Traits.Creature.Ghost).AddDomains(ctx.InsideRavenloft);

                ctx.InsideRavenloft.AddNPCs(
                    ctx.CreateNPC("Jacqueline Renier", "32/100"),
                    ctx.CreateNPC("Ratik Ubel", "33/100"),
                    ctx.CreateNPC("Julio, Master Thief of Haslic", "34/100"),
                    ctx.CreateNPC("Nemon Hotep", "67/100"),
                    ctx.CreateNPC("Shera the Wise", "68/100"),
                    ctx.CreateNPC("Varney the Vampire", "16/25").AddTraits(Traits.Creature.Vampire),
                    ctx.CreateNPC("Gib Lhadsemlo", "18/25").AddTraits(Traits.Creature.FleshGolem)
                );

                ctx.CreateLocation("Mad Scientist's Laboratory", "25/25").AddDomains(ctx.InsideRavenloft);
            }
            void AddDungeonsSet()
            {
                var releaseDate = "01/10/1997";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Dungeons Set", releaseDate, ExtraInfo, Traits.Edition.e0, Traits.Media.boardgame);
                if (ctx == null) return;

                ctx.InsideRavenloft.AddLocations(
                    ctx.CreateLocation("Castle Strahd", "Castle Ravenloft", "7/100").AddTraits(Traits.Creature.VampireBat),
                    ctx.CreateLocation("The Ruins of Lololia", "32/100")
                ).AddItems(ctx.CreateItem("Borer", "61/100"));
            }
            void AddMilleniumSet()
            {
                var releaseDate = "01/03/2002";
                var AddedExtraInfo = ExtraInfo + Environment.NewLine + "This set was made by fans, but was still using Spellfire trademark.";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Millenium Set", releaseDate, AddedExtraInfo, Traits.Edition.e0, Traits.Media.boardgame, Traits.Canon.NotCanon);
                if (ctx == null) return;

                ctx.CreateItem("Strahd's Medallion", "23/99").AddTraits(Traits.Creature.Vampire).AddDomains(ctx.InsideRavenloft);
            }
            void AddConquestSet()
            {
                var releaseDate = "01/08/2004";
                var AddedExtraInfo = ExtraInfo + Environment.NewLine + "This set was made by fans, but was still using Spellfire trademark.";
                using var ctx = Factory.CreateSource("Spellfire: Master the Magic, Conquest Set", releaseDate, AddedExtraInfo, Traits.Edition.e0, Traits.Media.boardgame, Traits.Canon.NotCanon);
                if (ctx == null) return;

                ctx.CreateLocation("Castle Strahd", "Castle Ravenloft", "73/81").AddTraits(Traits.Creature.VampireBat).AddDomains(ctx.InsideRavenloft);
            }
        }
        Factory.db.SaveChanges();
    }
}
