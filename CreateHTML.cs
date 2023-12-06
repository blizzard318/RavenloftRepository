﻿using Microsoft.EntityFrameworkCore;
using NUglify;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

internal static class CreateHTML
{
    #region PREGENERATED DATA
    private const string WebsiteTitle = "Ravenloft Catalogue";
    private static string InsideRavenloftLink  = CreateLink(nameof(Domain), Factory.InsideRavenloftOriginalName );
    private static string OutsideRavenloftLink = CreateLink(nameof(Domain), Factory.OutsideRavenloftOriginalName);

    private static class Get
    {
        private sealed class Entity
        {
            public readonly string[] Names;
            public readonly string[] Editions;
            public readonly string CombinedLink;
            public Entity(string[] names, string[] editions, string combinedLink) { Names = names; CombinedLink = combinedLink; Editions = editions; }
        }
        private static bool Pregenerated = false;
        private static readonly Dictionary<string, Entity> Domains    = new Dictionary<string, Entity>();
        private static readonly Dictionary<string, Entity> Characters = new Dictionary<string, Entity>();
        private static readonly Dictionary<string, Entity> Locations  = new Dictionary<string, Entity>();
        private static readonly Dictionary<string, Entity> Items      = new Dictionary<string, Entity>();

        public static void Pregenerate() //I don't trust this to be a static constructor. This has to run after the db is filled.
        {
            if (Pregenerated) return;
            Pregenerated = true;

            Fill("Domain"   , Domains   , Factory.db.Domains  , Factory.db.domainAppearances  );
            Fill("Character", Characters, Factory.db.NPCs     , Factory.db.npcAppearances     );
            Fill("Location" , Locations , Factory.db.Locations, Factory.db.locationAppearances);
            Fill("Item"     , Items     , Factory.db.Items    , Factory.db.itemAppearances    );

            void Fill<T, U>(string Subdomain, Dictionary<string, Entity> ToFill, DbSet<T> ToRead, DbSet<U> Appearances) 
                where T : UseVariableName where U : Appearance, IHasEntity<T>
            {
                var All = ToRead.ToHashSet();
                var OriginalNames = ToRead.Select(s => s.OriginalName).ToHashSet();

                foreach (var OriginalName in OriginalNames)
                {
                    var AllVersions = All.Where(d => d.OriginalName == OriginalName);

                    string[] NamesOfSame = AllVersions.Select(s => s.Name).Distinct().ToArray();
                    string combinedLinks;
                    if (AllVersions.SingleOrDefault(a => a.Traits.Contains(Traits.NoLink)) == null)
                    {
                        string[] LinksOfSame = new string[NamesOfSame.Length];
                        for (int i = 0; i < NamesOfSame.Length; i++) LinksOfSame[i] = CreateLink(Subdomain, NamesOfSame[i]);
                        combinedLinks = string.Join("/", LinksOfSame);
                    }
                    else combinedLinks = string.Join("/", NamesOfSame);

                    var Editions = new string[Traits.Edition.traits.Count];
                    var Sources = Appearances.Include(a => a.Source.Traits).Where(a => a.Entity.OriginalName == OriginalName).Select(a => a.Source);
                    foreach (var Source in Sources)
                    {
                        var Edition = Source.Traits.Single(t => t.Type == nameof(Traits.Edition));
                        Editions[Traits.Edition.traits.IndexOf(Edition)] = "X";
                    }

                    ToFill.Add(OriginalName, new Entity(NamesOfSame, Editions, combinedLinks));
                }
            }
        }
        public static string[] AllOriginalsOf (Type type) => GetEntity(type).Keys.ToArray();
        public static string[] TotalNamesOf<T>(T i) where T : UseVariableName => TotalNamesOf<T>(i.OriginalName);
        public static string[] TotalNamesOf<T>(string OriginalName) where T : UseVariableName => GetEntity(typeof(T))[OriginalName].Names;
        public static string LinksOf<T>(T i) where T : UseVariableName => LinksOf<T>(i.OriginalName);
        public static string LinksOf<T>(string OriginalName) where T : UseVariableName => GetEntity(typeof(T))[OriginalName].CombinedLink;
        public static string[] EditionsOf<T>(T i) where T : UseVariableName => EditionsOf<T>(i.OriginalName);
        public static string[] EditionsOf<T>(string OriginalName) where T : UseVariableName => GetEntity(typeof(T))[OriginalName].Editions;

        private static Dictionary<string, Entity> GetEntity (Type type)
        {
                 if (type == typeof(Domain  )) return Domains   ;
            else if (type == typeof(NPC     )) return Characters;
            else if (type == typeof(Location)) return Locations ;
            else if (type == typeof(Item    )) return Items     ;
            return null;
        }
    }
    private static string CreateLink(string subdomain, string name) => $"<a href='/{subdomain}/{FixLink(name)}'>{name}</a>";
    private static string CreateLink(Source entity) => CreateLink(nameof(Source), entity.Key);
    private static string CreateLink(Trait trait)
    {
        string subdomain = string.Empty;
        switch (trait.Type)
        {
            case nameof(Traits.Status): return CreateLink("Group", trait.Key);

            case nameof(Traits.Canon): //Hidden page
            case nameof(Traits.CampaignSetting):
            case nameof(Traits.Language):
            case nameof(Traits.Creature): return CreateLink(trait.Type, trait.Key);

                /*case nameof(Traits.Edition):
                case nameof(Traits.Media):
                case nameof(Traits.Settlement):
                case nameof(Traits.Cluster): //Do we want a cluster page?
                case nameof(Traits.Mistway):
                case nameof(Traits.Alignment):
                case nameof(Traits.Location):*/ //This shouldn't run at all
        }
        throw new Exception();
    }
    private static string FixLink(string link) => link.Replace(":", string.Empty).Replace("'", string.Empty);
    #endregion

    #region PAGE CREATOR
    private static StringBuilder sb = new StringBuilder();
    private enum SortMethod { alphabet, date }
    private static void CreateOfficialHeader(string title, int depth = 0)
    {
        Get.Pregenerate();
        const string DepthText = "../";
        var db = new StringBuilder(DepthText.Length * depth);
        for (int i = 0; i < depth; i++) db.Append(DepthText);

        sb.Clear();
        sb.AppendLine("<!DOCTYPE html>");
        sb.AppendLine("<html>");

        sb.AppendLine("<head>");
        sb.AppendLine("<meta charset='utf-8'>");
        sb.AppendLine($"<title>{title}</title>");
        sb.AppendLine("<meta name='theme-color' content='black'>"); //Always black
        sb.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1'>");
        sb.AppendLine("<meta name='description' content='Ravenloft Repository'>");
        sb.Append("<link rel='stylesheet' href='").Append(db).AppendLine("styles.css'>");
        sb.Append("<link rel='shortcut icon' href='").Append(db).AppendLine("favicon.ico'>");
        sb.Append("<script src='").Append(db).AppendLine("sort.js'></script>");
        sb.AppendLine("</head>");

        sb.AppendLine("<body>");

        sb.AppendLine("<span style='float:right;display:inline-block;height:0px'>");
        sb.AppendLine("<label for='darkmode'>Dark Mode</label>");
        sb.AppendLine("<input type='checkbox' id='darkmode'>");
        sb.AppendLine("</span>");

        sb.AppendLine($"<h1>{WebsiteTitle}</h1><hr/>");

        sb.AppendLine("<h2>");
        sb.Append("<a href='").Append(db).AppendLine("'>Official</a> | ");
        sb.AppendLine("<a href='../3rdParty'>3rd Party</a>");
        sb.AppendLine("</h2><hr />");

        sb.AppendLine("<h2>");
        sb.Append("<a href='").Append(db).AppendLine("Source'>Sources</a> | ");
        sb.Append("<a href='").Append(db).AppendLine("Domain'>Domains</a> | ");
        sb.Append("<a href='").Append(db).AppendLine("Location'>Locations</a> | ");
        sb.Append("<a href='").Append(db).AppendLine("Character'>Characters</a> | ");
        sb.Append("<a href='").Append(db).Append("Item'>Items</a>").AppendLine("<br/>");
        sb.Append("<a href='").Append(db).AppendLine("Creature'>Creatures</a> | ");
        sb.Append("<a href='").Append(db).AppendLine("Group'>Groups</a> | ");
        sb.Append("<a href='").Append(db).AppendLine("Setting'>Campaign Settings</a> | ");
        sb.Append("<a href='").Append(db).AppendLine("Language'>Languages</a>");
        sb.AppendLine("</h2><hr />");
    }
    private static void SaveHTML(params string[] DirectoryNames)
    {
        sb.AppendLine($"<br/><br/><br/><i style='font-size:10px;line-height:0'>Disclaimer: The registered trademarks and other intellectual property related to Ravenloft and owned by TSR, Arthaus, White Wolf SSI, Sony, Hasbro, Ral Partha, Paizo, and/or Wizards of the Coast are used for the purpose of identification only. {WebsiteTitle} is not affiliated with/or endorsed by these manufacturers.</i>");
        sb.AppendLine("</body>").AppendLine("<script>init();");
        Table.SortAllTablesOnPage();
        sb.AppendLine("</script>").AppendLine("</html>");
        var html = sb.ToString();
        //html = Uglify.Html(html).Code; //Compression.

        foreach (var DirectoryName in DirectoryNames)
        {
            string filepath = "index.html";
            if (!string.IsNullOrEmpty(DirectoryName))
            {
                var path = FixLink(DirectoryName);
                var dir = Directory.CreateDirectory(path).ToString();
                filepath = Path.Join(dir, filepath);
            }
            File.WriteAllText(filepath, html);
        }
    }
    private class Table : IDisposable
    {
        private static readonly Dictionary<string, (SortMethod method, int index)> TablesToSort = new Dictionary<string, (SortMethod, int)>();
        public static void SortAllTablesOnPage()
        {
            if (TablesToSort.Count == 0) return;
            foreach (var table in TablesToSort)
            {
                switch (table.Value.method)
                {
                    case SortMethod.alphabet:
                        CreateHTML.sb.AppendLine($"sortTable('{table.Key}',{table.Value.index});");
                        break;
                    case SortMethod.date:
                        CreateHTML.sb.AppendLine($"sortDate('{table.Key}',{table.Value.index});");
                        break;
                }
            }
            TablesToSort.Clear();
        }

        private readonly string TableID;
        private readonly StringBuilder sb;
        public Table(string id, string title, string? caption = null, StringBuilder? stringBuilder = null)
        {
            TablesToSort.Add(TableID = id, (SortMethod.alphabet, 0));
            sb = stringBuilder ?? CreateHTML.sb;
            sb.AppendLine($"<b style='font-size:25px'>{title}</b>");
            sb.AppendLine($"<table cellspacing='0' cellpadding='3' rules='cols' border='1' id='{id}'>");
            if (!string.IsNullOrWhiteSpace(caption)) sb.AppendLine($"<caption>{caption}</caption>");
        }
        public void AdjustSort(SortMethod method, int index) => TablesToSort[TableID] = (method, index);
        public HeaderRow CreateHeaderRow() => new HeaderRow(this);
        public class HeaderRow : IDisposable
        {
            private readonly string TableID;
            private readonly StringBuilder sb;
            private int col = 0;
            public HeaderRow(Table table)
            {
                TableID = table.TableID;
                sb = table.sb;
                sb.AppendLine("<tr style='background-color:var(--header)'>");
            }
            public HeaderRow CreateHeader(params string[] titles)
            {
                foreach (var title in titles)
                {
                    sb.AppendLine("<th scope='col'>");
                    EndHeader(title);
                }
                return this;
            }
            public HeaderRow CreateSortHeader(params string[] titles)
            {
                foreach (var title in titles)
                {
                    sb.AppendLine($"<th scope='col' onclick=\"sortTable('{TableID}',{col})\" style='cursor:pointer'>");
                    EndHeader(title);
                }
                return this;
            }
            public HeaderRow CreateSortDateHeader(params string[] titles)
            {
                foreach (var title in titles)
                {
                    sb.AppendLine($"<th scope='col' onclick=\"sortDate('{TableID}',{col})\" style='cursor:pointer'>");
                    EndHeader(title);
                }
                return this;
            }
            public HeaderRow CreateEditionHeaders()
            {
                foreach (var edition in Traits.Edition.traits)
                    sb.AppendLine($"<th scope='col'>").AppendLine($"<b>{edition.Key}</b>").AppendLine("</th>");
                col += Traits.Edition.traits.Count;
                return this;
            }
            private void EndHeader(string title)
            {
                sb.AppendLine($"<b>{title}</b>").AppendLine("</th>");
                col++;
            }
            public void Dispose() => sb.AppendLine("</tr>");
        }
        public void AddRows(string[] columns, string? HTMLclass = null)
        {
            if (string.IsNullOrEmpty(HTMLclass)) sb.AppendLine("<tr>");
            else sb.AppendLine($"<tr class='{HTMLclass}'>");
            foreach (var column in columns) sb.AppendLine($"<td>{column}</td>");
            sb.AppendLine("</tr>");
        }
        public void Dispose() => sb.AppendLine("</table><br/>");
    }
    private class SubHeader : IDisposable
    {
        private readonly List<Page> pages = new List<Page>();
        public Page CreatePage (string ID)
        {
            var retval = new Page(ID);
            pages.Add(retval);
            return retval;
        }
        public void Dispose()
        {
            sb.AppendLine("<h2>");
            for (int i = 0; i < pages.Count - 1; i++)
                sb.AppendLine($"<input type='button' onclick=\"OpenPage('{pages[i].ID}')\" value='{pages[i].ID}'> | ");
            sb.AppendLine($"<input type='button' onclick=\"OpenPage('{pages[pages.Count -1].ID}')\" value='{pages[pages.Count - 1].ID}'>");
            sb.Append("</h2>").AppendLine("<br/>");

            sb.AppendLine($"<div class='page' id='{pages[0].ID}' style='display:block'>");
            sb.Append(pages[0].contents);
            for (int i = 1; i < pages.Count; i++)
            {
                sb.AppendLine($"<div class='page' id='{pages[i].ID}' style='display:none'>");
                sb.Append(pages[i].contents);
            }
        }
        public class Page : IDisposable
        {
            public readonly string ID;
            public readonly StringBuilder contents = new StringBuilder();
            public int TableInt = 0;
            public Page(string ID) => this.ID = ID;
            public Table CreateTable(string title, string? caption = null) => new Table(ID + (TableInt++).ToString(), title, caption, contents);
            public void SetTable<T>(string title, string? caption, HashSet<string> OriginalNames) where T : UseVariableName
            {
                if (OriginalNames.Count == 0) return;
                using (var table = CreateTable(title, caption))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)").CreateEditionHeaders();

                    var Keys = OriginalNames.ToList();
                    Keys.Reverse(); //Don't ask me, I don't know why.
                    foreach (var original in Keys)
                    {
                        var rowval = new List<string>() { Get.LinksOf<T>(original) };
                        rowval.AddRange(Get.EditionsOf<T>(original));
                        table.AddRows(rowval.ToArray());
                    }
                }
            }
            public void Dispose() => contents.AppendLine("</div>");
            public void AddSection<T>(IEnumerable<T> list, string title, HashSet<string>? ToAddTo = null) where T : UseVariableName => AddSection(list, title, Get.LinksOf, ToAddTo);
            public void AddSection(IEnumerable<Trait> list, string title, HashSet<string>? ToAddTo = null) => AddSection(list, title, CreateLink, ToAddTo);
            private void AddSection<T>(IEnumerable<T> list, string title, Func<T, string> Linkify, HashSet<string>? ToAddTo = null)
            {
                if (list.Count() == 0) return;

                contents.Append($"<b class='darkred'>{title}</b><hr class='darkred'/>");
                foreach (var instance in list)
                {
                    var String = Linkify(instance);
                    ToAddTo?.Add(String);
                    contents.Append($"{String}, ");
                }
                contents.Remove(contents.Length - 2, 2).AppendLine("<br/><br/>");
            }
            public void AddSection (IEnumerable<string> list, string title)
            {
                if (list.Count() != 0) contents.Append($"<b class='darkred'>{title}</b><hr class='darkred'/>").Append(string.Join(", ", list)).AppendLine("<br/><br/>");
            }
        }
    }
    private class UnorderedList : IDisposable
    {
        private readonly StringBuilder contents;
        public UnorderedList (StringBuilder contents) => (this.contents = contents).Append($"<ul>");
        public void Dispose() => contents.Append("</ul>");
    }
    #endregion

    #region BASE PAGES
    public static void CreateHomepage()
    {
        CreateOfficialHeader("Ravenloft");

        sb.AppendLine("<br/>");
        sb.AppendLine("Hi, this is a GM's reference website for the Ravenloft Campaign Setting.<br/><br/>");
        sb.AppendLine("I wanted a list of everything and I figured others would like having this too.<br/>");
        sb.AppendLine("Most things will have a listed source so you can read it further on your own.<br/>");
        sb.AppendLine("(I won't be listing sources outside of Ravenloft material, e.g. I won't link to the Bestiary entry for zombies)<br/>");
        sb.AppendLine("This is not meant to replace <a href='https://www.fraternityofshadows.com/wiki/'>Mistipedia</a> or anyone else's efforts,");
        sb.AppendLine("it is definitely inspired by the <a href='https://www.fraternityofshadows.com/rldb/'>Ravenloft Catalogue</a>.<br/>");

        SaveHTML(string.Empty);
    }

    public static void CreateSourcePage()
    {
        CreateOfficialHeader("Source Materials", 1);

        var MaterialPerEdition = new Dictionary<string, int>(Traits.Edition.traits.Count);
        var MaterialPerMedia = new Dictionary<string, int>(Traits.Media.traits.Count);

        const string MainTableID = "List of Media";
        using (var table = new Table(MainTableID, MainTableID))
        {
            table.AdjustSort(SortMethod.date, 3);
            using (var headerRow = table.CreateHeaderRow())
                headerRow.CreateHeader("Name").CreateSortHeader("Edition", "Media Type").CreateSortDateHeader("Release Date");

            var Sources = Factory.db.Sources.Include(s => s.Traits);
            foreach (var source in Sources)
            {
                var edition = source.Traits.Single(s => s.Type == nameof(Traits.Edition)).Key;
                MaterialPerEdition[edition] = MaterialPerEdition.ContainsKey(edition) ? MaterialPerEdition[edition] + 1 : 1;

                var media = source.Traits.Single(s => s.Type == nameof(Traits.Media)).Key;
                MaterialPerMedia[media] = MaterialPerMedia.ContainsKey(media) ? MaterialPerMedia[media] + 1 : 1;

                table.AddRows(new[] { CreateLink(source), edition, media, source.ReleaseDate});
            }
        }
        const string EditionTableID = "Editions Breakdown";
        using (var table = new Table(EditionTableID, EditionTableID))
        {
            using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Edition", "Source Materials");
            foreach (var edition in Traits.Edition.traits)
            {
                if (!MaterialPerEdition.ContainsKey(edition.Key)) MaterialPerEdition[edition.Key] = 0;
                table.AddRows(new[] { edition.Key, MaterialPerEdition[edition.Key].ToString() });
            }
        }
        const string MediaTableID = "Media Breakdown";
        using (var table = new Table(MediaTableID, MediaTableID))
        {
            using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Type", "Source Materials");
            foreach (var media in Traits.Media.traits)
            {
                if (!MaterialPerMedia.ContainsKey(media.Key)) MaterialPerMedia[media.Key] = 0;
                table.AddRows(new[] { media.Key, MaterialPerMedia[media.Key].ToString() });
            }
        }

        SaveHTML(nameof(Source));
        CreateSourcePages();
    }
    public static void CreateDomainPage()
    {
        CreateOfficialHeader("Domains of Ravenloft", 1);
        sb.AppendLine($"Quick-link for {InsideRavenloftLink} | {OutsideRavenloftLink}");

        var AllDomains = Factory.db.Domains.Include(s => s.Traits).Include(s => s.NPCs).ThenInclude(n => n.Traits);
        var Domains = new Dictionary<string, HashSet<string>>(); //Domain : Darklords
        var Clusters = new Dictionary<string, HashSet<string>>(); //Cluster : Domains
        foreach (var Domain in AllDomains)
        {
            if (Domain.OriginalName == Factory.InsideRavenloftOriginalName || Domain.OriginalName == Factory.OutsideRavenloftOriginalName) continue;
            Domains.TryAdd(Domain.OriginalName, new HashSet<string>());

            var AllDarklords = Domain.NPCs.Where(n => n.Traits.Contains(Traits.Status.Darklord));
            foreach (var Darklord in AllDarklords) Domains[Domain.OriginalName].Add(Get.LinksOf(Darklord));

            var ClustersInDomain = Domain.Traits.Where(t => t.Type == nameof(Traits.Cluster));

            if (ClustersInDomain.Count() == 0) AddToCluster(Traits.Cluster.IslandOfTerror.Key);
            else foreach (var Cluster in ClustersInDomain) AddToCluster(Cluster.Key);

            void AddToCluster(string key)
            {
                Clusters.TryAdd(key, new HashSet<string>());
                Clusters[key].Add(Domain.OriginalName);
            }
        }

        using (var subheader = new SubHeader())
        {
            using (var Domain = subheader.CreatePage("All Domain"))
            {
                using (var table = Domain.CreateTable("List of Domains"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)", "Darklord(s)").CreateEditionHeaders();

                    foreach (var domain in Domains)
                    {
                        var rowval = new List<string>() { Get.LinksOf<Domain>(domain.Key), string.Join(",", domain.Value) };
                        rowval.AddRange(Get.EditionsOf<Domain>(domain.Key));
                        table.AddRows(rowval.ToArray());
                    }
                }
            }
            using (var Group = subheader.CreatePage("By Cluster/Type"))
            {
                using (var table = Group.CreateTable("Domains per Cluster"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name", "Domains");

                    foreach (var cluster in Clusters)
                        table.AddRows(new[] { cluster.Key, cluster.Value.Count().ToString() });
                }
                foreach (var cluster in Clusters)
                {
                    using (var table = Group.CreateTable(cluster.Key))
                    {
                        using (var headerRow = table.CreateHeaderRow())
                            headerRow.CreateHeader(cluster.Key).CreateEditionHeaders();

                        foreach (var domain in cluster.Value)
                        {
                            var rowval = new List<string>() { Get.LinksOf<Domain>(domain) };
                            rowval.AddRange(Get.EditionsOf<Domain>(domain));
                            table.AddRows(rowval.ToArray());
                        }
                    }
                }
            }
        }
        SaveHTML(nameof(Domain));
        CreateDomainPages();
    }
    public static void CreateLocationPage()
    {
        CreateOfficialHeader("Locations of Ravenloft", 1);

        using (var subheader = new SubHeader())
        {
            //Key is domain, entries are all location names
            var LocationsPerDomain   = new Dictionary<string, HashSet<string>>();
            var SettlementsPerDomain = new Dictionary<string, HashSet<string>>();

            var AllLocations = Factory.db.Locations.Include(s => s.Domains).Include(s => s.Traits);
            var DomainlessLocations = new HashSet<string>(); //Catch stragglers
            var DomainedLocations = new HashSet<string>(); //Catch stragglers
            foreach (var location in AllLocations)
            {
                if (location.Domains.Count == 0) DomainlessLocations.Add(location.OriginalName);
                else DomainedLocations.Add(location.OriginalName);
                
                foreach (var domain in location.Domains)
                {
                    LocationsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                    LocationsPerDomain[domain.OriginalName].Add(location.OriginalName);

                    if (location.Traits.Contains(Traits.Location.Settlement))
                    {
                        SettlementsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                        SettlementsPerDomain[domain.OriginalName].Add(location.OriginalName);
                    }
                }
            }
            //Filter out all locations that eventually have domains.
            DomainlessLocations = DomainlessLocations.Except(DomainedLocations).ToHashSet();

            using (var AllPage = subheader.CreatePage("Domains"))
            {
                var Inside = LocationsPerDomain.TryGetValue(Factory.InsideRavenloftOriginalName, out var UnknownDomainLocations);
                if (Inside) LocationsPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table
                var Outside = LocationsPerDomain.TryGetValue(Factory.OutsideRavenloftOriginalName, out var OutsideRavenloftLocations);
                if (Outside) LocationsPerDomain.Remove(Factory.OutsideRavenloftOriginalName); //Last table

                var Keys = LocationsPerDomain.Keys.ToList();
                Keys.Sort();
                foreach (var DomainName in Keys)
                {
                    var link = Get.LinksOf<Domain>(DomainName);
                    AllPage.SetTable<Location>($"Locations of {link}", null, LocationsPerDomain[DomainName]);
                }
                if (Inside)
                    AllPage.SetTable<Location>($"Locations {InsideRavenloftLink}", "The domain of the location is unknown.", UnknownDomainLocations);
                if (Outside)
                    AllPage.SetTable<Location>($"Locations {OutsideRavenloftLink}", "This place is related to Ravenloft somehow.", OutsideRavenloftLocations);
                if (DomainlessLocations.Count > 0) //u dun fukd up
                    AllPage.SetTable<Location>("Unsorted Locations", "Please contact site owner to rectify", DomainlessLocations);
            }

            using (var SettlementPage = subheader.CreatePage("Settlements"))
            {
                var Inside = SettlementsPerDomain.TryGetValue(Factory.InsideRavenloftOriginalName, out var UnknownDomainSettlements);
                if (Inside) SettlementsPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table
                var Outside = SettlementsPerDomain.TryGetValue(Factory.OutsideRavenloftOriginalName, out var OutsideRavenloftSettlements);
                if (Outside) SettlementsPerDomain.Remove(Factory.OutsideRavenloftOriginalName); //Last table

                var Keys = SettlementsPerDomain.Keys.ToList();
                Keys.Sort();
                foreach (var DomainNames in Keys) 
                    SettlementPage.SetTable<Location>($"Settlements of {DomainNames}", null, SettlementsPerDomain[DomainNames]);
                if (Inside)
                    SettlementPage.SetTable<Location>($"Settlements {InsideRavenloftLink}", "The domain of the settlement is unknown.", UnknownDomainSettlements);
                if (Outside)
                    SettlementPage.SetTable<Location>($"Settlements {OutsideRavenloftLink}", "This place is related to Ravenloft somehow.", OutsideRavenloftSettlements);
            }

            using (var LairPage = subheader.CreatePage("Darklord Lairs"))
            {
                using (var table = LairPage.CreateTable($"List of Darklord Lairs"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)", "Domain(s)", "Darklord").CreateEditionHeaders();

                    var DarkLordLairsCopies = Factory.db.Locations.Where(s => s.Traits.Any(s => s == Traits.Status.Darklord)).Include(s => s.Domains).Include(s => s.NPCs).ThenInclude(s => s.Traits).GroupBy(s => s.OriginalName);

                    foreach (var SingleSetOfLairCopies in DarkLordLairsCopies)
                    {
                        var TotalNamesofTotalDomains = new HashSet<string>();
                        var TotalNamesofTotalDarklords = new HashSet<string>();

                        foreach (var CopyOfLair in SingleSetOfLairCopies) //Different sources may have different darklords/domains for same location
                        {
                            foreach (var domain in CopyOfLair.Domains) TotalNamesofTotalDomains.Add(Get.LinksOf(domain));

                            var DomainDarklords = CopyOfLair.NPCs.Where(n => n.Traits.Contains(Traits.Status.Darklord));
                            foreach (var DomainDarklord in DomainDarklords) TotalNamesofTotalDarklords.Add(Get.LinksOf(DomainDarklord));
                        }

                        var rowval = new List<string>() 
                        { 
                            Get.LinksOf<Location>(SingleSetOfLairCopies.Key), 
                            string.Join(",", TotalNamesofTotalDomains),
                            string.Join(",", TotalNamesofTotalDarklords)
                        };
                        rowval.AddRange(Get.EditionsOf<Location>(SingleSetOfLairCopies.Key));

                        table.AddRows(rowval.ToArray());
                    }
                }
            }
            using (var MistwayPage = subheader.CreatePage("Mistways"))
            {
                using (var table = MistwayPage.CreateTable($"List of Mistways"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)", "Domain", "Domain").CreateEditionHeaders();

                    var Mistways = Factory.db.Locations.Where(s => s.Traits.Any(s => s == Traits.Location.Mistway)).Include(s => s.Domains).GroupBy(s => s.OriginalName).Select(s => s.First()); //There is no deviation/variation of mistways. Revise this if that ever happens.
                    foreach (var Mistway in Mistways)
                    {
                        var TotalNamesofTotalDomains = new List<string>(2);
                        foreach (var domain in Mistway.Domains) TotalNamesofTotalDomains.Add(Get.LinksOf(domain));

                        var rowval = new List<string>() { Get.LinksOf(Mistway) };
                        rowval.AddRange(TotalNamesofTotalDomains); //If this goes beyond 2 then the HTML goes fucky-wucky.
                        rowval.AddRange(Get.EditionsOf(Mistway));

                        table.AddRows(rowval.ToArray());
                    }
                }
            } 
        }

        SaveHTML(nameof(Location));
    }
    public static void CreateCharacterPage()
    {
        CreateOfficialHeader("Characters of Ravenloft", 1);

        sb.AppendLine("<label for='showdead'>Show dead characters</label>");
        sb.AppendLine("<input type='checkbox' id='showdead' checked>");

        using (var subheader = new SubHeader())
        {
            const int ALIVE = 0, DEAD = 1;

            var CharactersPerDomain = new Dictionary<string, HashSet<string>[]>();
            var CharactersPerGroup = new Dictionary<string, HashSet<string>[]>();
            var CharactersPerCreature = new Dictionary<string, HashSet<string>[]>();

            var AllCharacters = Factory.db.NPCs.Include(s => s.Domains).Include(s => s.Traits);
            var DomainlessCharacters = new HashSet<string>(); //Catch stragglers
            var DomainedCharacter = new HashSet<string>();
            foreach (var character in AllCharacters)
            {
                var StatusTraits = character.Traits.Where(c => c.Type.Contains(nameof(Traits.Status))).ToList();
                var offset = StatusTraits.Remove(Traits.Status.Deceased) ? DEAD : ALIVE;

                foreach (var statusTrait in StatusTraits)
                {
                    CharactersPerGroup.TryAdd(statusTrait.Key, Init());
                    CharactersPerGroup[statusTrait.Key][offset].Add(character.OriginalName);
                }

                if (character.Domains.Count == 0) DomainlessCharacters.Add(character.OriginalName);
                else DomainedCharacter.Add(character.OriginalName);

                foreach (var domain in character.Domains)
                {
                    CharactersPerDomain.TryAdd(domain.OriginalName, Init());
                    CharactersPerDomain[domain.OriginalName][offset].Add(character.OriginalName);
                }

                var CreatureTraits = character.Traits.Where(c => c.Type.Contains(nameof(Traits.Creature)));
                foreach (var creatureTrait in CreatureTraits)
                {
                    if (creatureTrait == Traits.Creature.Human) continue; //For the sake of spam, I don't think anyone wants to see all humans.
                    CharactersPerCreature.TryAdd(creatureTrait.Key, Init());
                    CharactersPerCreature[creatureTrait.Key][offset].Add(character.OriginalName);
                }
                static HashSet<string>[] Init() => new HashSet<string>[2] { new HashSet<string>(), new HashSet<string>() };
            }
            //Filter out all characters that eventually have domains.
            DomainlessCharacters = DomainlessCharacters.Except(DomainedCharacter).ToHashSet();

            using (var Domain = subheader.CreatePage("By Domain"))
            {
                var Inside = CharactersPerDomain.TryGetValue(Factory.InsideRavenloftOriginalName, out var InsideCharacters);
                if (Inside) CharactersPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table
                var Outside = CharactersPerDomain.TryGetValue(Factory.OutsideRavenloftOriginalName, out var OutsideCharacters);
                if (Outside) CharactersPerDomain.Remove(Factory.OutsideRavenloftOriginalName); //Last table

                var Domains = CharactersPerDomain.Keys.ToList();
                Domains.Sort();
                foreach (var domain in Domains)
                    SetTable($"Characters of {Get.LinksOf<Domain>(domain)}", null, CharactersPerDomain[domain], Domain);
                if (Inside)
                    SetTable($"Characters {InsideRavenloftLink}", "The domain of the character is unknown.", InsideCharacters, Domain);

                if (Outside)
                    SetTable($"Characters {OutsideRavenloftLink}", "They're related to Ravenloft somehow", OutsideCharacters, Domain);

                if (DomainlessCharacters.Count > 0) //u dun fukd up
                    Domain.SetTable<NPC>("Unsorted Characters", "Please contact site owner to rectify", DomainlessCharacters);
            }
            using (var Group = subheader.CreatePage("By Group"))
            {
                var Groups = CharactersPerGroup.Keys.ToList();
                Groups.Sort();
                foreach (var group in Groups)
                    SetTable($"Characters of {CreateLink(nameof(Group), group)}", null, CharactersPerGroup[group], Group);
            }
            using (var Creature = subheader.CreatePage("By Creature Type"))
            {
                var CreatureTypes = CharactersPerCreature.Keys.ToList();
                CreatureTypes.Sort();
                foreach (var CreatureType in CreatureTypes)
                    SetTable($"Characters associated with {CreateLink(nameof(Creature), CreatureType)}", null, CharactersPerCreature[CreatureType], Creature);
            }

            static void SetTable(string title, string? caption, HashSet<string>[] OriginalNames, SubHeader.Page page)
            {
                using (var table = page.CreateTable(title, caption))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)").CreateEditionHeaders();

                    foreach (var character in OriginalNames[ALIVE])
                    {
                        var rowval = new List<string>() { Get.LinksOf<NPC>(character) };
                        rowval.AddRange(Get.EditionsOf<NPC>(character));
                        table.AddRows(rowval.ToArray());
                    }
                    foreach (var character in OriginalNames[DEAD])
                    {
                        var rowval = new List<string>() { Get.LinksOf<NPC>(character) };
                        rowval.AddRange(Get.EditionsOf<NPC>(character));
                        table.AddRows(rowval.ToArray(), "dead");
                    }
                }
            }
        }
        sb.AppendLine("<script>");
        sb.AppendLine("document.getElementById('showdead').addEventListener('change', () => {");
            sb.AppendLine("document.querySelectorAll('.dead').forEach(x => x.style.visibility = document.getElementById('showdead').checked?'visible':'collapse');");
            sb.AppendLine("document.querySelectorAll('table').forEach(x => colorCode(x));");
        sb.AppendLine("});");
        sb.AppendLine("</script>");

        SaveHTML("Character");
    }
    public static void CreateItemPage()
    {
        CreateOfficialHeader("Items of Ravenloft", 1);

        using (var subheader = new SubHeader())
        {
            //Key is domain, entries are all location names
            var ItemsPerDomain = new Dictionary<string, HashSet<string>>();
            var ItemsPerGroup = new Dictionary<string, HashSet<string>>();
            var ItemsPerCreature = new Dictionary<string, HashSet<string>>();

            var AllItems = Factory.db.Items.Include(s => s.Domains).Include(s => s.Traits);
            var DomainlessItems = new HashSet<string>(); //Catch stragglers
            var DomainedItems = new HashSet<string>(); //Catch stragglers
            foreach (var item in AllItems)
            {
                if (item.Domains.Count == 0) DomainlessItems.Add(item.OriginalName);
                else DomainedItems.Add(item.OriginalName);
                foreach (var domain in item.Domains)
                {
                    ItemsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                    ItemsPerDomain[domain.OriginalName].Add(item.OriginalName);
                }

                var StatusTraits = item.Traits.Where(c => c.Type.Contains(nameof(Traits.Status))).ToList();
                foreach (var statusTrait in StatusTraits)
                {
                    ItemsPerGroup.TryAdd(statusTrait.Key, new HashSet<string>());
                    ItemsPerGroup[statusTrait.Key].Add(item.OriginalName);
                }

                var CreatureTraits = item.Traits.Where(c => c.Type.Contains(nameof(Traits.Creature)));
                foreach (var creatureTrait in CreatureTraits)
                {
                    ItemsPerCreature.TryAdd(creatureTrait.Key, new HashSet<string>());
                    ItemsPerCreature[creatureTrait.Key].Add(item.OriginalName);
                }
            }
            //Filter out all items that eventually have domains.
            DomainlessItems = DomainlessItems.Except(DomainedItems).ToHashSet();

            using (var Domain = subheader.CreatePage("By Domain"))
            {
                var Inside = ItemsPerDomain.TryGetValue(Factory.InsideRavenloftOriginalName, out var InsideItems);
                if (Inside) ItemsPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table
                var Outside = ItemsPerDomain.TryGetValue(Factory.InsideRavenloftOriginalName, out var OutsideItems);
                if (Outside) ItemsPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table

                var Keys = ItemsPerDomain.Keys.ToList();
                Keys.Sort();
                foreach (var Key in Keys)
                    Domain.SetTable<Item>($"Items of {Get.LinksOf<Domain>(Key)}", null, ItemsPerDomain[Key]);
                if (Inside)
                    Domain.SetTable<Item>($"Items {InsideRavenloftLink}", "The domain of the item is unknown.", InsideItems);
                if (Outside)
                    Domain.SetTable<Item>($"Items {OutsideRavenloftLink}", "Somehow related.", OutsideItems);
                if (DomainlessItems.Count > 0) //u dun fukd up
                    Domain.SetTable<Item>("Unsorted Items", "Please contact site owner to rectify", DomainlessItems);
            }
            using (var Group = subheader.CreatePage("By Group")) //Status Traits
            {
                var Keys = ItemsPerGroup.Keys.ToList();
                Keys.Sort();
                foreach (var Key in Keys)
                    Group.SetTable<Item>($"Items of {CreateLink(nameof(Group), Key)}", null, ItemsPerGroup[Key]);
            }
            using (var Creature = subheader.CreatePage("By Creature")) //Creature Traits
            {
                var Keys = ItemsPerCreature.Keys.ToList();
                Keys.Sort();
                foreach (var Key in Keys)
                    Creature.SetTable<Item>($"Items of {CreateLink(nameof(Creature), Key)}", null, ItemsPerCreature[Key]);
            }
        }
        SaveHTML(nameof(Item));
        CreateItemPages();
    }

    public static void CreateGroupPage()
    {
        CreateOfficialHeader("Groups/Titles of Ravenloft", 1);

        using (var subheader = new SubHeader())
        {
            var AllCharacters = Factory.db.NPCs.Include(s => s.Domains).Include(s => s.Traits);
            var GroupMembersPerDomain = new Dictionary<string, Dictionary<string, HashSet<string>>>(); //Domain <Group, Members>
            var GroupMembersPerGroup = new Dictionary<string, HashSet<string>>(); //From all domains
            foreach (var character in AllCharacters)
            {
                var StatusTraits = character.Traits.Where(c => c.Type.Contains(nameof(Traits.Status))).ToList();
                StatusTraits.Remove(Traits.Status.Deceased); //I don't see a point tracking the dead.
                foreach (var statusTrait in StatusTraits)
                {
                    GroupMembersPerGroup.TryAdd(statusTrait.Key, new HashSet<string>());
                    GroupMembersPerGroup[statusTrait.Key].Add(character.OriginalName);

                    foreach (var domain in character.Domains)
                    {
                        if (domain.OriginalName == Factory.InsideRavenloftOriginalName || domain.OriginalName == Factory.OutsideRavenloftOriginalName) continue;
                        GroupMembersPerDomain.TryAdd(domain.OriginalName, new Dictionary<string, HashSet<string>>());
                        GroupMembersPerDomain[domain.OriginalName].TryAdd(statusTrait.Key, new HashSet<string>());
                        GroupMembersPerDomain[domain.OriginalName][statusTrait.Key].Add(character.OriginalName);
                    }
                }
            }

            //Considered tracking members in each edition, but maybe reserve that for specific pages?
            using (var Total = subheader.CreatePage("Total")) 
            {
                AddGroupTable(Total, "All Groups/Titles in Ravenloft", GroupMembersPerGroup);
            }
            using (var Domain = subheader.CreatePage("By Domain"))
            {
                var Domains = GroupMembersPerDomain.Keys.ToList();
                Domains.Sort();
                foreach (var domain in Domains)
                    AddGroupTable(Domain, $"Groups/Titles within {Get.LinksOf<Domain>(domain)}", GroupMembersPerDomain[domain]);
            }
            void AddGroupTable (SubHeader.Page page, string title, Dictionary<string, HashSet<string>> groupMembersPerGroup)
            {
                using (var table = page.CreateTable(title))
                {
                    using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Name(s)", "Member Count");
                    foreach (var group in groupMembersPerGroup.Keys)
                    {
                        var GroupMembers = groupMembersPerGroup[group];

                        var link = CreateLink(nameof(Group), group);
                        var number = GroupMembers.Count().ToString();
                        table.AddRows(new[] { link, number });
                    }
                }
            }
        }
        SaveHTML("Group");
    }
    public static void CreateCreaturePage()
    {
        CreateOfficialHeader("Creatures of Ravenloft", 1);

        var AllDomains = Factory.db.Domains.Include(s => s.Traits).Where(c => c.Traits.Any(t => t.Type == nameof(Traits.Creature)));
        var CreaturesPerDomain = new Dictionary<string, Dictionary<string, string[]>>();
        foreach (var domain in AllDomains)
        {
            var Edition = Factory.db.domainAppearances.Single(a => a.EntityId == domain.Key).Source.Traits.Single(t => t.Type == nameof(Traits.Edition));

            CreaturesPerDomain.TryAdd(domain.OriginalName, new Dictionary<string, string[]>());
            var creatures = domain.Traits.Where(t => t.Type == nameof(Traits.Creature)).Select(c => c.Key);
            foreach (var creature in creatures)
            {
                CreaturesPerDomain[domain.OriginalName].TryAdd(creature, new string[Traits.Edition.traits.Count]);
                CreaturesPerDomain[domain.OriginalName][creature][Traits.Edition.traits.IndexOf(Edition)] = "X";
            }
        }
        var Domains = CreaturesPerDomain.Keys.ToList();
        Domains.Sort();
        foreach (var domain in Domains)
        {
            using (var table = new Table(domain, $"Creatures in {Get.LinksOf<Domain>(domain)}"))
            {
                using (var headerRow = table.CreateHeaderRow())
                    headerRow.CreateHeader("Name").CreateEditionHeaders();

                foreach (var creature in CreaturesPerDomain[domain].Keys)
                {
                    var rowval = new List<string>() { CreateLink(nameof(Traits.Creature), creature) };
                    rowval.AddRange(CreaturesPerDomain[domain][creature]);
                    table.AddRows(rowval.ToArray());
                }
            }
        }

        SaveHTML(nameof(Traits.Creature));
    }
    public static void CreateCampaignSettingPage()
    {
        CreateOfficialHeader("Characters and Items from other Campaign Settings in Ravenloft", 1);

        using (var subheader = new SubHeader())
        {
            var AllCharacters = Factory.db.NPCs.Include(s => s.Domains).Include(s => s.Traits).Where(c => c.Traits.Any(t => t.Type == nameof(Traits.CampaignSetting)));
            var CharactersPerSetting = new Dictionary<string, HashSet<string>>();
            foreach (var character in AllCharacters)
            {
                var setting = character.Traits.Single(t => t.Type == nameof(Traits.CampaignSetting)).Key;

                var Edition = Factory.db.npcAppearances.Single(a => a.EntityId == character.Key).Source.Traits.Single(t => t.Type == nameof(Traits.Edition));

                CharactersPerSetting.TryAdd(setting, new HashSet<string>());
                CharactersPerSetting[setting].Add(character.OriginalName);
            }
            using (var Character = subheader.CreatePage("Characters"))
            {
                var Keys = CharactersPerSetting.Keys.ToList();
                Keys.Sort();
                foreach (var Key in Keys)
                    Character.SetTable<NPC>($"Characters of {CreateLink(nameof(Traits.CampaignSetting), Key)}", null, CharactersPerSetting[Key]);
            }

            var AllItems = Factory.db.Items.Include(s => s.Domains).Include(s => s.Traits).Where(c => c.Traits.Any(t => t.Type == nameof(Traits.CampaignSetting)));
            var ItemsPerSetting = new Dictionary<string, HashSet<string>>();
            foreach (var item in AllItems)
            {
                var setting = item.Traits.Single(t => t.Type == nameof(Traits.CampaignSetting)).Key;

                var Edition = Factory.db.itemAppearances.Single(a => a.EntityId == item.Key).Source.Traits.Single(t => t.Type == nameof(Traits.Edition));

                ItemsPerSetting.TryAdd(setting, new HashSet<string>());
                ItemsPerSetting[setting].Add(item.OriginalName);
            }
            using (var Item = subheader.CreatePage("Items"))
            {
                var Keys = ItemsPerSetting.Keys.ToList();
                Keys.Sort();
                foreach (var Key in Keys)
                    Item.SetTable<Item>($"Items of {CreateLink(nameof(Traits.CampaignSetting), Key)}", null, ItemsPerSetting[Key]);
            }
        }

        SaveHTML("Setting");
    }
    public static void CreateLanguagesPage()
    {
        CreateOfficialHeader("Languages of Ravenloft", 1);

        var AllDomains = Factory.db.Domains.Include(s => s.Traits).Where(c => c.Traits.Any(t => t.Type == nameof(Traits.Language)));
        var LanguagesPerDomain = new Dictionary<string, Dictionary<string, string[]>>();
        foreach (var domain in AllDomains)
        {
            var Edition = Factory.db.domainAppearances.Single(a => a.EntityId == domain.Key).Source.Traits.Single(t => t.Type == nameof(Traits.Edition));

            LanguagesPerDomain.TryAdd(domain.OriginalName, new Dictionary<string, string[]>());
            var languages = domain.Traits.Where(t => t.Type == nameof(Traits.Language)).Select(c => c.Key);
            foreach (var language in languages)
            {
                LanguagesPerDomain[domain.OriginalName].TryAdd(language, new string[Traits.Edition.traits.Count]);
                LanguagesPerDomain[domain.OriginalName][language][Traits.Edition.traits.IndexOf(Edition)] = "X";
            }
        }
        var Domains = LanguagesPerDomain.Keys.ToList();
        Domains.Sort();
        foreach (var domain in Domains)
        {
            using (var table = new Table(domain, $"Languages in {Get.LinksOf<Domain>(domain)}"))
            {
                using (var headerRow = table.CreateHeaderRow())
                    headerRow.CreateHeader("Name").CreateEditionHeaders();

                foreach (var language in LanguagesPerDomain[domain].Keys)
                {
                    var rowval = new List<string>() { CreateLink(nameof(Traits.Language), language) };
                    rowval.AddRange(LanguagesPerDomain[domain][language]);
                    table.AddRows(rowval.ToArray());
                }
            }
        }

        SaveHTML(nameof(Traits.Language));
    }
    #endregion

    #region CHILD PAGES
    private static void CreateSourcePages()
    {
        var Sources = Factory.db.Sources;

        foreach (var source in Sources)
        {
            CreateOfficialHeader(source.Key, 2);
            sb.Append($"<h3>{source.Key}");
            var canontrait = source.Traits.SingleOrDefault(t => t.Type == nameof(Traits.Canon));
            if (canontrait != null) sb.Append($" ({canontrait.Key})");
            sb.AppendLine("</h3><br/>");

            sb.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");

            using (var subheader = new SubHeader())
            {
                sb.AppendLine($"<b>Name:</b> {source.Key}<br/>");

                var mediatypes = source.Traits.FindAll(t => t.Type == nameof(Traits.Media)).Select(m => m.Key);
                sb.Append($"<b>Media Type(s):</b> {string.Join(',', mediatypes)}<br/>");

                var editiontrait = source.Traits.Single(t => t.Type == nameof(Traits.Edition));
                if (editiontrait != Traits.Edition.e0) sb.AppendLine($"<b>Edition:</b> {editiontrait.Key}<br/>");

                if (canontrait != null) sb.AppendLine($"<b>Canon:</b> {canontrait.Key}<br/>");

                sb.AppendLine($"<b>Release Date:</b> {source.ReleaseDate}<br/>");
                sb.AppendLine($"<b>Extra Info:</b> {source.ExtraInfo}");

                var Domains    = GetAppearances<DomainAppearance, Domain    >(Factory.db.domainAppearances  );
                var Locations  = GetAppearances<LocationAppearance, Location>(Factory.db.locationAppearances);
                var Characters = GetAppearances<NPCAppearance     , NPC     >(Factory.db.npcAppearances     );
                var Items      = GetAppearances<ItemAppearance    , Item    >(Factory.db.itemAppearances    );
                IQueryable<T> GetAppearances<T, U>(IQueryable<T> dbSet) where T : Appearance, IHasEntity<U> where U : UseVariableName
                    => dbSet.Where(s => s.SourceKey == source.Key);

                using (var Category = subheader.CreatePage("Category"))
                {
                    bool CheckName(DomainAppearance d) => d.Entity.OriginalName != Factory.InsideRavenloftOriginalName && d.Entity.OriginalName != Factory.OutsideRavenloftOriginalName;
                    //Domains, Locations, NPCs, Items, Language, Groups, Creatures
                    var DomainsWithoutMetaDomains = Domains.Where(CheckName).Select(d => d.Entity);
                    Category.AddSection(DomainsWithoutMetaDomains       , nameof(Domains   ));
                    Category.AddSection(Locations .Select(d => d.Entity), nameof(Locations ));
                    Category.AddSection(Characters.Select(d => d.Entity), nameof(Characters));
                    Category.AddSection(Items     .Select(d => d.Entity), nameof(Items     ));

                    GenerateTraits(nameof(Traits.Language), "Languages"    );
                    GenerateTraits(nameof(Traits.Status  ), "Status/Groups");
                    GenerateTraits(nameof(Traits.Creature), "Creatures"    );

                    void GenerateTraits(string TraitType, string title)
                    {
                        var ListofList = Domains.Select(d => d.Entity.Traits.Where(t => t.Type == TraitType));
                        if (ListofList.Count() == 0) return;

                        var multiple = new HashSet<Trait>();
                        foreach (var List in ListofList) multiple.UnionWith(List);

                        Category.AddSection(multiple, title);
                    }
                }
                using (var Cascade = subheader.CreatePage("Cascade"))
                {
                    //Take out inside/outside ravenloft to put behind the domains stuff.
                    var domainAppearances = Domains.Include(d => d.Entity.Traits).ToList();
                    var InsideRavenloft = domainAppearances.SingleOrDefault(d => d.Entity.OriginalName == Factory.InsideRavenloftOriginalName);
                    if (InsideRavenloft != null) domainAppearances.Remove(InsideRavenloft);
                    var OutsideRavenloft = domainAppearances.SingleOrDefault(d => d.Entity.OriginalName == Factory.OutsideRavenloftOriginalName);
                    if (OutsideRavenloft != null) domainAppearances.Remove(OutsideRavenloft);

                    foreach (var domain in domainAppearances) DrawCascade(domain);
                    if (InsideRavenloft  != null) DrawCascade(InsideRavenloft );
                    if (OutsideRavenloft != null) DrawCascade(OutsideRavenloft);

                    void DrawCascade(DomainAppearance domain)
                    {
                        Cascade.contents.Append($"<b class='darkred'>{Get.LinksOf(domain.Entity)}</b><hr class='darkred'/>");

                        var CharactersInDomain         = Characters        .Where(s => s.Entity.Domains.Any(c => c == domain.Entity));
                        var CharactersWithoutLocations = CharactersInDomain.Where(c => c.Entity.Locations.Count == 0                );
                        var LocationsInDomain          = Locations         .Where(s => s.Entity.Domains.Any(l => l == domain.Entity));
                        var ItemsInDomain              = Items             .Where(i => i.Entity.Domains.Any(i => i == domain.Entity));
                        var Languages = domain.Entity.Traits.Where(t => t.Type == nameof(Traits.Language));
                        var Groups    = domain.Entity.Traits.Where(t => t.Type == nameof(Traits.Status  ));
                        var Creatures = domain.Entity.Traits.Where(t => t.Type == nameof(Traits.Creature));

                        int sum = LocationsInDomain.Count() + CharactersWithoutLocations.Count();
                        sum += ItemsInDomain.Count() + Languages.Count() + Groups.Count() + Creatures.Count();

                        if (sum > 0)
                        {
                            using var outerlist = new UnorderedList(Cascade.contents);

                            foreach (var location in LocationsInDomain)
                            {
                                AddEntry<LocationAppearance, Location>(location);
                                var CharactersInLocation = CharactersInDomain.Where(c => c.Entity.Locations.Any(c => c == location.Entity));
                                if (CharactersInLocation.Count() == 0) continue;

                                CreateList<NPCAppearance, NPC>(CharactersInLocation);
                            }
                            if (CharactersWithoutLocations.Count() > 0)
                            {
                                Cascade.contents.Append($"<li><b>{nameof(Characters)} in non-specified location:</b></li>");
                                CreateList<NPCAppearance, NPC>(CharactersWithoutLocations);
                            }
                            if (ItemsInDomain.Count() > 0)
                            {
                                Cascade.contents.Append($"<li><b>{nameof(Items)}:</b></li>");
                                CreateList<ItemAppearance, Item>(ItemsInDomain);
                            }
                            CreateListOfTraits(Languages, nameof(Languages));
                            CreateListOfTraits(Groups, nameof(Groups));
                            CreateListOfTraits(Creatures, nameof(Creatures));

                            void CreateList<T, U>(IQueryable<T> list) where T : Appearance, IHasEntity<U> where U : UseVariableName
                            {
                                using var _ = new UnorderedList(Cascade.contents);
                                foreach (var instance in list) AddEntry<T, U>(instance);
                            }
                            void CreateListOfTraits(IEnumerable<Trait> traits, string title)
                            {
                                if (traits.Count() == 0) return;
                                Cascade.contents.Append($"<li><b>{title}:</b></li>");
                                using var _ = new UnorderedList(Cascade.contents);
                                foreach (var trait in traits) Cascade.contents.Append($"<li>{CreateLink(trait)}</li>");
                            }
                        }
                        Cascade.contents.AppendLine("<br/>");
                    }

                    //unsorted pile. To sort.
                    ListUnsorted<LocationAppearance, Location>(Locations.Where(x => x.Entity.Domains.Count() == 0), nameof(Locations));
                    ListUnsorted<NPCAppearance, NPC>(Characters.Where(x => x.Entity.Domains.Count() == 0), nameof(Characters));
                    ListUnsorted<ItemAppearance, Item>(Items.Where(x => x.Entity.Domains.Count() == 0), nameof(Items));
                    Cascade.contents.AppendLine("<br/>");

                    void ListUnsorted<T, U>(IQueryable<T> Unsorted, string title) where T : Appearance, IHasEntity<U> where U : UseVariableName
                    {
                        if (Unsorted.Count() == 0) return;
                        Cascade.contents.Append($"<b class='darkred'>Unsorted {title}, please alert site owner</b><hr class='darkred'/>");
                        foreach (var entity in Unsorted) AddEntry<T, U>(entity);
                    }
                    void AddEntry<T, U>(T entity) where T : Appearance, IHasEntity<U> where U : UseVariableName
                    {
                        Cascade.contents.Append("<li>").Append(Get.LinksOf(entity.Entity));
                        if (!string.IsNullOrEmpty(entity.PageNumbers)) Cascade.contents.Append($" (<i>{entity.PageNumbers}</i>)</li>");
                        else sb.Append("</li>");
                    }
                }
            }
            sb.AppendLine("</div></div><br/>");
            SaveHTML(nameof(Source) + "/" + source.Key);
        }
    }
    private static void CreateDomainPages()
    {
        return;
        var Domains = Get.AllOriginalsOf(typeof(Domain));
        foreach (var original in Domains)
        {
            var totalnames = Get.TotalNamesOf<Domain>(original);
            var Sources = Factory.db.domainAppearances.Where(i => i.Entity.OriginalName == original);
            foreach (var domain in totalnames)
            {
                CreateOfficialHeader(domain, 2);
                sb.AppendLine($"<h3>{domain}</h3><br/>");

                using (var subheader = new SubHeader())
                {
                    sb.AppendLine($"<b>Name:</b> {domain}<br/>");

                    if (totalnames.Length > 1) sb.AppendLine($"<b>Other Names:</b> {Get.LinksOf<Item>(original)}<br/>");

                    //Location, NPCs, Items, Groups, Languages, Creatures, Sources
                    var TotalSources = new HashSet<string>();
                    var Locations = new HashSet<string>();
                    var Characters = new HashSet<string>();
                    var Items = new HashSet<string>();
                    var Languages = new HashSet<string>();
                    var Groups = new HashSet<string>();
                    var Creatures = new HashSet<string>();
                    using (var SplitSources = subheader.CreatePage("Per Source"))
                    {
                        foreach (var source in Sources)
                        {
                            sb.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");

                            var SourceString = $"{CreateLink(source.Source)} (<i>{source.PageNumbers}</i>)";
                            TotalSources.Add(SourceString);
                            sb.AppendLine($"<b>Source:</b> {SourceString}<br/>");

                            SplitSources.AddSection(source.Entity.Locations, nameof(Locations), Locations);

                            var languages = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Language));
                            SplitSources.AddSection(languages, nameof(Languages), Languages);

                            var groups = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Status));
                            SplitSources.AddSection(groups, nameof(Groups), Groups);

                            var creatures = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Creature));
                            SplitSources.AddSection(creatures, nameof(Creatures), Creatures);

                            sb.AppendLine("</div></div><br/>");
                        }
                    }
                    using (var AllSources = subheader.CreatePage("All"))
                    {
                        sb.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                        AllSources.AddSection(Domains     , nameof(Domains  ));
                        AllSources.AddSection(Groups      , nameof(Groups   ));
                        AllSources.AddSection(Creatures   , nameof(Creatures));
                        AllSources.AddSection(TotalSources, nameof(Sources  ));
                        sb.AppendLine("</div></div><br/>");
                    }
                }
                SaveHTML(nameof(Domain) + "/" + domain);
            }
        }
    }
    private static void CreateItemPages()
    {
        var Items = Get.AllOriginalsOf(typeof(Item));
        foreach (var original in Items)
        {
            var totalnames = Get.TotalNamesOf<Item>(original);
            var Sources = Factory.db.itemAppearances.Where(i => i.Entity.OriginalName == original);
            foreach (var item in totalnames)
            {
                CreateOfficialHeader(item, 2);
                sb.AppendLine($"<h3>{item}</h3>");

                using (var subheader = new SubHeader())
                {
                    if (totalnames.Length > 1) sb.AppendLine($"<b>Other Names:</b> {Get.LinksOf<Item>(original)}<br/>");

                    //Domains, Groups, Creatures, Sources
                    var TotalSources = new HashSet<string>();
                    var Domains = new HashSet<string>();
                    var Groups = new HashSet<string>();
                    var Creatures = new HashSet<string>();
                    using (var SplitSources = subheader.CreatePage("Per Source"))
                    {
                        foreach (var source in Sources)
                        {
                            SplitSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");

                            var SourceString = $"{CreateLink(source.Source)} (<i>{source.PageNumbers}</i>)";
                            TotalSources.Add($"{CreateLink(source.Source)} (<i>{source.PageNumbers}</i>)");
                            SplitSources.contents.AppendLine($"<font style='font-size:19px'><b>Source:</b> {CreateLink(source.Source)}</font> <i style='font-size:13px'>({source.PageNumbers})</i><hr/>");

                            SplitSources.AddSection(source.Entity.Domains, nameof(Domains), Domains);

                            var groups = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Status));
                            SplitSources.AddSection(groups, nameof(Groups), Groups);

                            var creatures = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Creature));
                            SplitSources.AddSection(creatures, nameof(Creatures), Creatures);

                            SplitSources.contents.AppendLine("</div></div><br/>");
                        }
                    }
                    using (var AllSources = subheader.CreatePage("All"))
                    {
                        AllSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                        AllSources.AddSection(Domains     , nameof(Domains  ));
                        AllSources.AddSection(Groups      , nameof(Groups   ));
                        AllSources.AddSection(Creatures   , nameof(Creatures));
                        AllSources.AddSection(TotalSources, nameof(Sources ));
                        AllSources.contents.AppendLine("</div></div><br/>");
                    }
                }
                SaveHTML(nameof(Item) + "/" + item);
            }
        }
    }
    #endregion
}