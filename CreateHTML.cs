using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NUglify;
using NUglify.Html;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using static Domain;
using static Factory;

internal static class CreateHTML
{
    #region PREGENERATED DATA
    private const string WebsiteTitle = "Ravenloft Catalogue";
    private const string GroupTitle = "Groups/Titles";
    private const string IslandsOfTerror = "Islands of Terror";
    private static string InsideRavenloftLink  = CreateLink(nameof(Domain), DomainToString[DomainEnum.InsideRavenloft][0]);
    private static string OutsideRavenloftLink = CreateLink(nameof(Domain), DomainToString[DomainEnum.OutsideRavenloft][0]);

    private enum EntityType { Source, Domain, Character, Location, Item, Group, Mistway, Cluster, Canon, Language, Setting, Creature };
    private static string FixLink(string link) => link.Replace(":", string.Empty).Replace("'", string.Empty);
    private static string CreateLink(string subdomain, string name) => $"<a href='/{subdomain}/{FixLink(name)}'>{name}</a>";
    private static string CreateLink(EntityType type, string name) => CreateLink(type.ToString(), name);
    private static string CreateLink(EntityType type, IEnumerable<string> names)
    {
        int i = 0;
        var linkedNames = new string[names.Count()];
        foreach (var name in names) linkedNames[i++] = CreateLink(type, name);
        return string.Join("/", linkedNames);
    }
    private static string[] GetEditionsOf (Edition ToCheck)
    {
        var Editions = Enum.GetValues<Edition>();
        var retval = new string[Editions.Length];

        for (int i = 0; i < Editions.Length; i++)
            retval[i] = ToCheck.HasFlag(Editions[i]) ? "X" : string.Empty;

        return retval;
    }
    private static string CreateLink(Source entity) => CreateLink(nameof(Source), entity.Name);
    #endregion

    #region PAGE CREATOR
    private enum SortMethod { alphabet, date }
    private static void CreateOfficialHeader(this StringBuilder sb, string title, int depth = 0)
    {
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
        sb.Append("<a href='/home'>Official</a> | ");
        sb.AppendLine("<a href='../3rdParty'>3rd Party</a>");
        sb.AppendLine("</h2><hr />");

        sb.AppendLine("<h2>");
        sb.Append("<a href='").Append(db).Append("Domain'>Domains</a> | ");
        sb.Append("<a href='").Append(db).Append("Location'>Locations</a> | ");
        sb.Append("<a href='").Append(db).Append("Character'>Characters</a> | ");
        sb.Append("<a href='").Append(db).Append("Item'>Items</a> | ");
        sb.Append("<a href='").Append(db).Append("Group'>Groups</a>");

        sb.AppendLine("<br/>");
        sb.Append("<a href='").Append(db).Append("Creature'>Creatures</a> | ");
        sb.Append("<a href='").Append(db).Append("Setting'>Campaign Settings</a> | ");
        sb.Append("<a href='").Append(db).Append("Language'>Languages</a>");

        sb.AppendLine("<br/>");
        sb.Append("<a href='").Append(db).Append("Source'>Sources</a>");

        sb.AppendLine("</h2><hr />");
    }
    private async static Task SaveHTML(this StringBuilder sb, string DirectoryName)
    {
        Console.WriteLine($"Creating {DirectoryName} page");
        sb.AppendLine($"<br/><br/><br/><i style='font-size:10px;line-height:0'>Disclaimer: The registered trademarks and other intellectual property related to Ravenloft and owned by TSR, Arthaus, White Wolf SSI, Sony, Hasbro, Ral Partha, Paizo, and/or Wizards of the Coast are used for the purpose of identification only. {WebsiteTitle} is not affiliated with/or endorsed by these manufacturers.</i>");
        sb.AppendLine("</body>").AppendLine("<script>init();");
        Table.SortAllTablesOnPage(sb);
        sb.AppendLine("</script>").AppendLine("</html>");
        var html = sb.ToString();
        //html = Uglify.Html(html).Code; //Compression.

        string filepath = "index.html";
        if (!string.IsNullOrEmpty(DirectoryName))
        {
            var path = FixLink(DirectoryName);
            var dir = Directory.CreateDirectory(path).ToString();
            filepath = Path.Join(dir, filepath);
        }

        await File.WriteAllTextAsync(filepath, html);
    }
    private class Table : IDisposable
    {
        private static readonly Dictionary<string, (SortMethod method, int index)> TablesToSort = new Dictionary<string, (SortMethod, int)>();
        public static void SortAllTablesOnPage(StringBuilder sb)
        {
            if (TablesToSort.Count == 0) return;
            foreach (var table in TablesToSort)
            {
                var sort = string.Empty;
                switch (table.Value.method)
                {
                    case SortMethod.alphabet: sort = "sortTable"; break;
                    case SortMethod.date:     sort = "sortDate"; break;
                }
                sb.Append($"{sort}('{table.Key}',{table.Value.index});");
            }
            TablesToSort.Clear();
        }

        private readonly string TableID;
        private readonly StringBuilder sb;
        public Table(StringBuilder sb, string id, string title, string? caption = null)
        {
            this.sb = sb;
            var addon = TablesToSort.Count() == 0 ? " open" : string.Empty;
            TablesToSort.Add(TableID = FixLink(id), (SortMethod.alphabet, 0));
            sb.AppendLine($"<details{addon}><summary><b style='font-size:25px'>{title}</b></summary>");
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
                (sb = table.sb).AppendLine("<tr style='background-color:var(--header)'>");
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
                foreach (var edition in EditionToString)
                    sb.AppendLine($"<th scope='col'>").AppendLine($"<b>{edition.Key}</b>").AppendLine("</th>");
                col += EditionToString.Count;
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
        public void Dispose() => sb.AppendLine("</table></details><br/>");
    }
    private class SubHeader : IDisposable
    {
        private readonly List<Page> pages = new List<Page>();
        private readonly StringBuilder sb;
        public SubHeader(StringBuilder sb) => this.sb = sb;
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
            public Table CreateTable(string title, string? caption = null) => new Table(contents, ID + (TableInt++).ToString(), title, caption);
            public void SetTable<T>(string title, string? caption, HashSet<string> OriginalNames) where T : UseVariableName
            {
                if (OriginalNames == null || OriginalNames.Count == 0) return;
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

            public void AddSection<T>(IEnumerable<InSource<T>> list, string title, EntityType type) where T : UseVariableName
            {
                if (list.Count() == 0) return;

                int i = 0;
                string[] names = new string[list.Count()];
                foreach (var instance in list) names[i++] = CreateLink(type, instance.entity.Names);
                AddSection(names, title);
            }
            public void AddSection(IEnumerable<Trait> list, string title, EntityType type)
            {
                if (list.Count() == 0) return;

                int i = 0;
                string[] names = new string[list.Count()];
                foreach (var instance in list) names[i++] = CreateLink(type, instance.Name);
                AddSection(names, title);
            }
            public void AddSection (IEnumerable<string> list, string title)
            {
                if (list.Count() != 0)
                    contents.Append($"<b class='darkred'>{title}</b><hr class='darkred'/>").Append(string.Join(", ", list)).AppendLine("<br/><br/>");
            }
        }
    }
    private class UnorderedList : IDisposable
    {
        private readonly StringBuilder contents;
        public UnorderedList (StringBuilder contents) => (this.contents = contents).Append($"<ul>");
        public void Dispose() => contents.Append("</ul>");
    }
    private static void AddSection<T>(this StringBuilder sb, IEnumerable<InSource<T>> list, string title, EntityType type) where T : UseVariableName
        => sb.AddSection(list.Select(i => CreateLink(type, i.entity.Names)), title);
    private static void AddSection(this StringBuilder sb, IEnumerable<Trait> list, string title, EntityType type)
        => sb.AddSection(list.Select(i => CreateLink(type, i.Name)), title);
    private static void AddSection(this StringBuilder sb, IEnumerable<string> list, string title)
    {
        if (list.Count() != 0)
            sb.Append($"<b class='darkred'>{title}</b><hr class='darkred'/>").Append(string.Join(", ", list)).AppendLine("<br/><br/>");
    }
    private static string AddCanonAddOn(Canon? canon)
    {
        switch (canon)
        {
            case Canon.pc: return $" <b style='color:yellow'>({CanonToString[canon.Value]})</b>";
            case Canon.nc: return $" <b style='color:red'>({CanonToString[canon.Value]})</b>";
        }
        return string.Empty;
    }
    #endregion

    #region BASE PAGES
    public static async Task CreateHomepage()
    {
        var sb = new StringBuilder();
        sb.CreateOfficialHeader("Ravenloft");

        sb.AppendLine("<br/>");
        sb.AppendLine("Hi, this is a GM's reference website for the Ravenloft Campaign Setting.<br/><br/>");
        sb.AppendLine("I wanted a list of everything and I figured others would like having this too.<br/>");
        sb.AppendLine("Most things will have a listed source so you can read it further on your own.<br/>");
        sb.AppendLine("(I won't be listing sources outside of Ravenloft material, e.g. I won't link to the Bestiary entry for zombies)<br/>");
        sb.AppendLine("This is not meant to replace <a href='https://www.fraternityofshadows.com/wiki/'>Mistipedia</a> or anyone else's efforts,");
        sb.AppendLine("it is definitely inspired by the <a href='https://www.fraternityofshadows.com/rldb/'>Ravenloft Catalogue</a>.<br/>");

        await sb.SaveHTML(string.Empty);
    }

    public static async Task CreateSourcePage()
    {
        var sb = new StringBuilder();
        sb.CreateOfficialHeader("Source Materials", 1);

        using (var subheader = new SubHeader(sb))
        {
            using (var All = subheader.CreatePage("All Sources"))
            {
                using (var table = All.CreateTable("List of Media"))
                {
                    table.AdjustSort(SortMethod.date, 3);
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name").CreateSortHeader("Edition", "Media Type").CreateSortDateHeader("Release Date");

                    foreach (var source in Ravenloftdb.Sources)
                    {
                        string edition = EditionToString[source.editions];
                        string media = MediaToString[source.Media];
                        table.AddRows(new[] { CreateLink(source), edition, media, source.ReleaseDate });
                    }
                }
            }
            using (var Edition = subheader.CreatePage("By Edition"))
            {
                using (var table = Edition.CreateTable("Editions Breakdown"))
                {
                    using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Edition", "Source Materials");
                    foreach (var edition in Ravenloftdb.Editions)
                        table.AddRows(new[] { EditionToString[edition.Key], edition.Value.Count.ToString() });
                }
                foreach (var edition in Ravenloftdb.Editions)
                {
                    using (var table = Edition.CreateTable(EditionToString[edition.Key]))
                    {
                        table.AdjustSort(SortMethod.date, 3);
                        using (var headerRow = table.CreateHeaderRow())
                            headerRow.CreateHeader("Name").CreateSortHeader("Media Type").CreateSortDateHeader("Release Date");

                        foreach (var source in edition.Value)
                        {
                            string media = MediaToString[source.Media];
                            table.AddRows(new[] { CreateLink(source), media, source.ReleaseDate });
                        }
                    }
                }
            }
            using (var Media = subheader.CreatePage("By Media"))
            {
                using (var table = Media.CreateTable("Media Breakdown"))
                {
                    using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Type", "Source Materials");
                    foreach (var media in Ravenloftdb.Medias)
                        table.AddRows(new[] { MediaToString[media.Key], media.Value.Count.ToString() });
                }
                foreach (var media in Ravenloftdb.Medias)
                {
                    using (var table = Media.CreateTable(MediaToString[media.Key]))
                    {
                        table.AdjustSort(SortMethod.date, 3);
                        using (var headerRow = table.CreateHeaderRow())
                            headerRow.CreateHeader("Name").CreateSortHeader("Edition").CreateSortDateHeader("Release Date");

                        foreach (var source in media.Value)
                        {
                            string edition = EditionToString[source.editions];
                            table.AddRows(new[] { CreateLink(source), edition, source.ReleaseDate });
                        }
                    }
                }
            }
        }
        await sb.SaveHTML(nameof(Source));
    }

    public async static Task CreateDomainPage()
    {
        var sb = new StringBuilder();
        sb.CreateOfficialHeader("Domains of Ravenloft", 1);
        sb.AppendLine($"Quick-link for {InsideRavenloftLink} | {OutsideRavenloftLink}");

        using (var subheader = new SubHeader(sb))
        {
            using (var Domain = subheader.CreatePage("All Domain"))
            {
                using (var table = Domain.CreateTable("List of Domains"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)", "Darklord(s)").CreateEditionHeaders();

                    foreach (var kv in Ravenloftdb.Domains)
                    {
                        if (kv.Key == DomainEnum.InsideRavenloft || kv.Key == DomainEnum.OutsideRavenloft) continue;

                        var DomainNames = CreateLink(EntityType.Domain, kv.Value.Names.ToArray());
                        var Darklords = kv.Value.Darklords.SelectMany(d => d.Value.Select(d => d.Names)).Distinct();
                        int i = 0;
                        var Links = new string[Darklords.Count()];
                        foreach (var darklord in Darklords) Links[i++] = CreateLink(EntityType.Character, darklord);
                        var LinkedDarklordNames = string.Join(", ", Links);

                        var rowval = new List<string>() { DomainNames, LinkedDarklordNames };
                        rowval.AddRange(GetEditionsOf(kv.Value.editions));
                        table.AddRows(rowval.ToArray());
                    }
                }
            }
            using (var Group = subheader.CreatePage("By Cluster/Type"))
            {
                var IsolatedDomains = Ravenloftdb.Domains.Where(kv => kv.Value.Clusters.Count() == 0);

                using (var table = Group.CreateTable("Domains per Cluster"))
                {
                    using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Name", "Domains").CreateEditionHeaders();

                    var ClusteredDomains = new HashSet<string>();
                    foreach (var kv in Ravenloftdb.Clusters)
                    {
                        var ClusterName = kv.Key.ToString();
                        var DomainCount = kv.Value.Domains.Count();
                        if (kv.Key == ClusterEnum.IslandsOfTerror) DomainCount += IsolatedDomains.Count();

                        var rowval = new List<string>() { ClusterName, DomainCount.ToString() };
                        rowval.AddRange(GetEditionsOf(kv.Value.editions));
                        table.AddRows(rowval.ToArray());
                    }
                }
                foreach (var cluster in Ravenloftdb.Clusters)
                {
                    var ClusterNames = CreateLink(EntityType.Cluster, ClusterToString[cluster.Key]);
                    using (var table = Group.CreateTable(ClusterNames, null))
                    {
                        using (var headerRow = table.CreateHeaderRow())
                            headerRow.CreateHeader("Name(s)").CreateEditionHeaders();

                        var Domains = cluster.Value.Domains.SelectMany(kv => kv.Value).Distinct();
                        foreach (var domain in Domains)
                        {
                            var rowval = new List<string>() { CreateLink(EntityType.Domain, domain.Names) };
                            rowval.AddRange(GetEditionsOf(domain.editions));
                            table.AddRows(rowval.ToArray());
                        }
                    }
                }
            }
        }
        await sb.SaveHTML(nameof(Domain));
    }
    /*public static void CreateLocationPage()
    {
        CreateOfficialHeader("Locations of Ravenloft", 1);
        sb.AppendLine("I only track buildings, so individual rooms will not be listed.");

        using (var subheader = new SubHeader())
        {
            using (var AllPage = subheader.CreatePage("Domains"))
            {
                //Key is domain, entries are all location names
                var LocationsPerDomain = new Dictionary<string, HashSet<string>>();

                var AllLocations = Get.AllOriginalsOf(typeof(Location));
                var DomainlessLocations = new HashSet<string>(); //Stragglers, should not exist
                foreach (var location in AllLocations)
                {
                    var domains = Factory.db.Locations.Where(l => l.OriginalName == location).SelectMany(l => l.Domains);
                    if (domains.Count() == 0) DomainlessLocations.Add(location);
                    else foreach (var domain in domains)
                    {
                        if (domain.OriginalName == Factory.OutsideRavenloftOriginalName) continue;
                        LocationsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                        LocationsPerDomain[domain.OriginalName].Add(location);
                    }
                }

                var UnknownDomainLocations = LocationsPerDomain[Factory.InsideRavenloftOriginalName];
                LocationsPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table
                var DomainedLocations = LocationsPerDomain.SelectMany(l => l.Value).Distinct();
                UnknownDomainLocations = UnknownDomainLocations.Except(DomainedLocations).ToHashSet();

                var Keys = LocationsPerDomain.Keys.ToList();
                Keys.Sort();
                foreach (var DomainName in Keys)
                {
                    var link = Get.LinksOf<Domain>(DomainName);
                    AllPage.SetTable<Location>($"Locations of {link}", null, LocationsPerDomain[DomainName]);
                }
                AllPage.SetTable<Location>($"Locations {InsideRavenloftLink}", "The domain of the location is unknown.", UnknownDomainLocations);
                AllPage.SetTable<Location>("Unsorted Locations", "Please contact site owner to rectify", DomainlessLocations);
            }

            using (var SettlementPage = subheader.CreatePage("Settlements"))
            {
                var SettlementsPerDomain = new Dictionary<string, HashSet<string>>();

                var UnsortedSettlements = Factory.db.Groups.Where(s => s.Traits.Any(t => t == Traits.Location.Settlement)).Include(s => s.Domains);
                var AllSettlements = UnsortedSettlements.Select(s => s.OriginalName).Distinct();
                var DomainlessSettlements = new HashSet<string>(); //Stragglers, should not exist
                foreach (var settlement in AllSettlements)
                {
                    var domains = Factory.db.Groups.Where(l => l.OriginalName == settlement).SelectMany(l => l.Domains);
                    if (domains.Count() == 0) DomainlessSettlements.Add(settlement);
                    else foreach (var domain in domains)
                    {
                        if (domain.OriginalName == Factory.OutsideRavenloftOriginalName) continue;
                        SettlementsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                        SettlementsPerDomain[domain.OriginalName].Add(settlement);
                    }
                }

                var Inside = SettlementsPerDomain.TryGetValue(Factory.InsideRavenloftOriginalName, out var UnknownDomainSettlements);
                if (Inside)
                {
                    SettlementsPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table
                    var DomainedSettlements = SettlementsPerDomain.SelectMany(l => l.Value).Distinct();
                    UnknownDomainSettlements = UnknownDomainSettlements.Except(DomainedSettlements).ToHashSet();
                }

                var Keys = SettlementsPerDomain.Keys.ToList();
                Keys.Sort();
                foreach (var DomainName in Keys)
                {
                    var link = Get.LinksOf<Domain>(DomainName);
                    SettlementPage.SetTable<Group>($"Settlements of {link}", null, SettlementsPerDomain[DomainName]);
                }
                SettlementPage.SetTable<Group>($"Settlements {InsideRavenloftLink}", "The domain of the settlement is unknown.", UnknownDomainSettlements);
                SettlementPage.SetTable<Location>("Unsorted Locations", "Please contact site owner to rectify", DomainlessSettlements);
            }

            using (var LairPage = subheader.CreatePage("Darklord Lairs"))
            {
                using (var table = LairPage.CreateTable($"List of Darklord Lairs"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)", "Domain(s)", "Darklord").CreateEditionHeaders();

                    var DarkLordLairsCopies = Factory.db.Locations.Where(s => s.Traits.Any(s => s == Traits.Location.Darklord)).Include(s => s.Domains).Include(s => s.NPCs).ThenInclude(s => s.Traits).GroupBy(s => s.OriginalName);

                    foreach (var SingleSetOfLairCopies in DarkLordLairsCopies)
                    {
                        var TotalNamesofTotalDomains = new HashSet<string>();
                        var TotalNamesofTotalDarklords = new HashSet<string>();

                        foreach (var CopyOfLair in SingleSetOfLairCopies) //Different sources may have different darklords/domains for same location
                        {
                            foreach (var domain in CopyOfLair.Domains) TotalNamesofTotalDomains.Add(Get.LinksOf(domain));

                            var DomainDarklords = CopyOfLair.NPCs.Where(n => n.Traits.Contains(Traits.Location.Darklord));
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
        CreateLocationPages();
    }
    public static void CreateCharacterPage()
    {
        CreateOfficialHeader("Characters of Ravenloft", 1);

        using (var subheader = new SubHeader())
        {
            var CharactersPerDomain = new Dictionary<string, HashSet<string>>();
            var CharactersPerGroup = new Dictionary<string, HashSet<string>>();
            var CharactersPerCreature = new Dictionary<string, HashSet<string>>();

            var AllCharacters = Get.AllOriginalsOf(typeof(NPC));
            var DomainlessCharacters = new HashSet<string>(); //Catch stragglers
            foreach (var characterName in AllCharacters)
            {
                var SameCharacter = Factory.db.NPCs.Where(c => c.OriginalName == characterName);

                var Domains = SameCharacter.SelectMany(c => c.Domains).Distinct();
                if (Domains.Count() == 0) DomainlessCharacters.Add(characterName);
                else foreach (var domain in Domains)
                {
                    CharactersPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                    CharactersPerDomain[domain.OriginalName].Add(characterName);
                }

                var Groups = SameCharacter.SelectMany(c => c.Groups).Distinct();
                foreach (var group in Groups)
                {
                    CharactersPerGroup.TryAdd(group.OriginalName, new HashSet<string>());
                    CharactersPerGroup[group.OriginalName].Add(characterName);
                }

                var CreatureTraits = SameCharacter.SelectMany(c => c.Traits).Distinct().Where(c => c.Type.Contains(nameof(Traits.Creature)));
                foreach (var creatureTrait in CreatureTraits)
                {
                    if (creatureTrait == Traits.Creature.Human) continue; //For the sake of spam, I don't think anyone wants to see all humans.
                    CharactersPerCreature.TryAdd(creatureTrait.Key, new HashSet<string>());
                    CharactersPerCreature[creatureTrait.Key].Add(characterName);
                }
            }

            using (var Domain = subheader.CreatePage("By Domain"))
            {
                var OutsideCharacters = CharactersPerDomain[Factory.OutsideRavenloftOriginalName];
                CharactersPerDomain.Remove(Factory.OutsideRavenloftOriginalName); //Last table

                var InsideCharacters = CharactersPerDomain[Factory.InsideRavenloftOriginalName];
                CharactersPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table
                var DomainedCharacters = CharactersPerDomain.SelectMany(l => l.Value).Distinct();
                InsideCharacters = InsideCharacters.Except(DomainedCharacters).ToHashSet();

                var Domains = CharactersPerDomain.Keys.ToList();
                Domains.Sort();
                foreach (var domain in Domains)
                    Domain.SetTable<NPC>($"Characters of {Get.LinksOf<Domain>(domain)}", null, CharactersPerDomain[domain]);
                Domain.SetTable<NPC>($"Characters {InsideRavenloftLink}", "The domain of the character is unknown.", InsideCharacters);
                Domain.SetTable<NPC>($"Characters {OutsideRavenloftLink}", "They're related to Ravenloft somehow", OutsideCharacters);
                Domain.SetTable<NPC>("Unsorted Characters", "Please contact site owner to rectify", DomainlessCharacters);
            }
            using (var Group = subheader.CreatePage("By Group"))
            {
                var Groups = CharactersPerGroup.Keys.ToList();
                Groups.Sort();
                foreach (var group in Groups)
                    Group.SetTable<NPC>($"Characters of {CreateLink(nameof(Group), group)}", null, CharactersPerGroup[group]);
            }
            using (var Creature = subheader.CreatePage("By Creature Type"))
            {
                var CreatureTypes = CharactersPerCreature.Keys.ToList();
                CreatureTypes.Sort();
                foreach (var CreatureType in CreatureTypes)
                    Creature.SetTable<NPC>($"Characters associated with {CreateLink(nameof(Creature), CreatureType)}", null, CharactersPerCreature[CreatureType]);
            }
        }

        SaveHTML("Character");
        CreateCharacterPages();
    }
    public static void CreateItemPage()
    {
        CreateOfficialHeader("Items of Ravenloft", 1);
        sb.AppendLine("I track magic and significant mundane items.");

        using (var subheader = new SubHeader())
        {
            //Key is domain, entries are all location names
            var ItemsPerDomain = new Dictionary<string, HashSet<string>>();
            var ItemsPerGroup = new Dictionary<string, HashSet<string>>();
            var ItemsPerCreature = new Dictionary<string, HashSet<string>>();

            var AllItems = Get.AllOriginalsOf(typeof(Item));
            var DomainlessItems = new HashSet<string>(); //Catch stragglers
            foreach (var itemName in AllItems)
            {
                var SameItem = Factory.db.Items.Where(c => c.OriginalName == itemName);

                var Domains = SameItem.SelectMany(c => c.Domains).Distinct();
                if (Domains.Count() == 0) DomainlessItems.Add(itemName);
                else foreach (var domain in Domains)
                {
                    ItemsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                    ItemsPerDomain[domain.OriginalName].Add(itemName);
                }

                var Groups = SameItem.SelectMany(c => c.Groups).Distinct();
                foreach (var group in Groups)
                {
                    ItemsPerGroup.TryAdd(group.OriginalName, new HashSet<string>());
                    ItemsPerGroup[group.OriginalName].Add(itemName);
                }

                var CreatureTraits = SameItem.SelectMany(c => c.Traits).Distinct().Where(c => c.Type.Contains(nameof(Traits.Creature)));
                foreach (var creatureTrait in CreatureTraits)
                {
                    ItemsPerCreature.TryAdd(creatureTrait.Key, new HashSet<string>());
                    ItemsPerCreature[creatureTrait.Key].Add(itemName);
                }
            }

            using (var Domain = subheader.CreatePage("By Domain"))
            {
                var OutsideItems = ItemsPerDomain[Factory.OutsideRavenloftOriginalName];
                ItemsPerDomain.Remove(Factory.OutsideRavenloftOriginalName); //Last table

                var InsideItems = ItemsPerDomain[Factory.InsideRavenloftOriginalName];
                ItemsPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table
                var DomainedItems = ItemsPerDomain.SelectMany(l => l.Value).Distinct();
                InsideItems = InsideItems.Except(DomainedItems).ToHashSet();

                var Keys = ItemsPerDomain.Keys.ToList();
                Keys.Sort();
                foreach (var Key in Keys)
                    Domain.SetTable<Item>($"Items of {Get.LinksOf<Domain>(Key)}", null, ItemsPerDomain[Key]);
                Domain.SetTable<Item>($"Items {InsideRavenloftLink}", "The domain of the item is unknown.", InsideItems);
                Domain.SetTable<Item>($"Items {OutsideRavenloftLink}", "Related to Ravenloft.", OutsideItems);
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
                    Creature.SetTable<Item>($"Items associated with {CreateLink(nameof(Creature), Key)}", null, ItemsPerCreature[Key]);
            }
        }
        SaveHTML(nameof(Item));
        CreateItemPages();
    }
    public static void CreateGroupPage() //Fix this some day
    {
        CreateOfficialHeader($"{GroupTitle} of Ravenloft", 1);

        using (var subheader = new SubHeader())
        {
            var GroupsPerDomain = new Dictionary<string, HashSet<string>>(); //Domain Groups

            var Groups = Get.AllOriginalsOf(typeof(Group));
            var DomainlessGroups = new HashSet<string>(); //Catch stragglers

            using (var Total = subheader.CreatePage("Total")) 
            {
                using (var table = Total.CreateTable($"All {GroupTitle} in Ravenloft"))
                {
                    using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Name(s)", "Pop.").CreateEditionHeaders();
                    foreach (var groupName in Groups)
                    {
                        var SameGroup = Factory.db.Groups.Where(g => g.OriginalName == groupName);
                        if (SameGroup.Any(g => g.Traits.Any(t => t == Traits.Location.Settlement))) continue;

                        var Domains = SameGroup.SelectMany(c => c.Domains).Distinct();
                        if (Domains.Count() == 0) DomainlessGroups.Add(groupName);
                        else foreach (var domain in Domains)
                        {
                            GroupsPerDomain.TryAdd(domain.OriginalName, new HashSet<string>());
                            GroupsPerDomain[domain.OriginalName].Add(groupName);
                        }

                        var AllMemberNames = SameGroup.SelectMany(g => g.NPCs).Select(c => c.OriginalName);
                        var number = AllMemberNames.Distinct().Count().ToString();
                        var rowval = new List<string>() { Get.LinksOf<Group>(groupName), number };
                        rowval.AddRange(Get.EditionsOf<Group>(groupName));
                        table.AddRows(rowval.ToArray());
                    }
                }
            }
            using (var Domain = subheader.CreatePage("By Domain"))
            {
                var OutsideGroups = GroupsPerDomain[Factory.OutsideRavenloftOriginalName];
                GroupsPerDomain.Remove(Factory.OutsideRavenloftOriginalName); //Last table

                var InsideGroups = GroupsPerDomain[Factory.InsideRavenloftOriginalName];
                GroupsPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table
                var DomainedGroups = GroupsPerDomain.SelectMany(l => l.Value).Distinct();
                InsideGroups = InsideGroups.Except(DomainedGroups).ToHashSet();

                var Domains = GroupsPerDomain.Keys.ToList();
                Domains.Sort();
                foreach (var domain in Domains)
                    Domain.SetTable<Group>($"{GroupTitle} within {Get.LinksOf<Domain>(domain)}", null, GroupsPerDomain[domain]);
                Domain.SetTable<Group>($"Groups {InsideRavenloftLink}", "The domain of the item is unknown.", InsideGroups);
                Domain.SetTable<Group>($"Groups {OutsideRavenloftLink}", "Related to Ravenloft.", OutsideGroups);
                Domain.SetTable<Group>("Unsorted Groups", "Please contact site owner to rectify", DomainlessGroups);
            }
        }
        SaveHTML("Group");
        CreateGroupPages();
    }

    public static void CreateCreaturePage()
    {
        CreateOfficialHeader("Creatures of Ravenloft", 1);

        var AllDomains = Factory.db.domainAppearances.Include(d => d.Entity.Traits).Where(d => d.Entity.Traits.Any(t => t.Type == nameof(Traits.Creature)));
        var AllCreatures = new Dictionary<string, string[]>();
        var CreaturesPerDomain = new Dictionary<string, Dictionary<string, string[]>>();
        foreach (var domain in AllDomains)
        {
            var Edition = domain.Source.Traits.Single(t => t.Type == nameof(Traits.Edition));

            CreaturesPerDomain.TryAdd(domain.Entity.OriginalName, new Dictionary<string, string[]>());
            var creatures = domain.Entity.Traits.Where(t => t.Type == nameof(Traits.Creature)).Select(c => c.Key);
            foreach (var creature in creatures)
            {
                var EditionIndex = Traits.Edition.traits.IndexOf(Edition);

                AllCreatures.TryAdd(creature, new string[Traits.Edition.traits.Count]);
                AllCreatures[creature][EditionIndex] = "X";

                CreaturesPerDomain[domain.Entity.OriginalName].TryAdd(creature, new string[Traits.Edition.traits.Count]);
                CreaturesPerDomain[domain.Entity.OriginalName][creature][EditionIndex] = "X";
            }
        }

        using (var subheader = new SubHeader())
        {
            using (var Total = subheader.CreatePage("Total")) CreateCreatureTable(Total, "Creatures in Ravenloft", AllCreatures);
            using (var PerDomains = subheader.CreatePage("Per Domain"))
            {
                var InsideCreatures = CreaturesPerDomain[Factory.InsideRavenloftOriginalName];
                CreaturesPerDomain.Remove(Factory.InsideRavenloftOriginalName); //Last table
                var DomainedCreatures = CreaturesPerDomain.SelectMany(l => l.Value.Select(v => v.Key)).Distinct();
                foreach (var creature in DomainedCreatures) InsideCreatures.Remove(creature);

                var Domains = CreaturesPerDomain.Keys.ToList();
                Domains.Sort();
                foreach (var domain in Domains)
                    CreateCreatureTable(PerDomains, $"Creatures in {Get.LinksOf<Domain>(domain)}", CreaturesPerDomain[domain]);
                CreateCreatureTable(PerDomains, $"Creatures {Factory.InsideRavenloftOriginalName}", InsideCreatures);
            }
            static void CreateCreatureTable(SubHeader.Page page, string title, Dictionary<string, string[]> Creatures)
            {
                using (var table = page.CreateTable(title))
                {
                    using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Name").CreateEditionHeaders();
                    foreach (var creature in Creatures.Keys)
                    {
                        var rowval = new List<string>() { CreateLink(nameof(Traits.Creature), creature) };
                        rowval.AddRange(Creatures[creature]);
                        table.AddRows(rowval.ToArray());
                    }
                }
            }
        }
        SaveHTML(nameof(Traits.Creature));
        CreateCreaturePages();
    }
    public static void CreateCampaignSettingPage()
    {
        CreateOfficialHeader("Other Campaign Settings in Ravenloft", 1);

        using (var subheader = new SubHeader())
        {
            AddPage("Characters", Factory.db.NPCs, Factory.db.npcAppearances);
            AddPage("Items", Factory.db.Items, Factory.db.itemAppearances);
            AddPage("Groups", Factory.db.Groups, Factory.db.groupAppearances);

            void AddPage<T,U> (string PageTitle, DbSet<T> set, DbSet<U> appearances) where T : UseVariableName, IHasDomains where U : Appearance, IHasEntity<T>
            {
                using (var page = subheader.CreatePage(PageTitle))
                {
                    var All = set.Include(s => s.Domains).Include(s => s.Traits).Where(c => c.Traits.Any(t => t.Type == nameof(Traits.CampaignSetting)));
                    var EntitiesPerSetting = new Dictionary<string, HashSet<string>>();
                    foreach (var entity in All)
                    {
                        var setting = entity.Traits.Single(t => t.Type == nameof(Traits.CampaignSetting)).Key;

                        var Edition = appearances.Single(a => a.Entity.Key == entity.Key).Source.Traits.Single(t => t.Type == nameof(Traits.Edition));

                        EntitiesPerSetting.TryAdd(setting, new HashSet<string>());
                        EntitiesPerSetting[setting].Add(entity.OriginalName);
                    }
                    var Keys = EntitiesPerSetting.Keys.ToList();
                    Keys.Sort();
                    foreach (var Key in Keys)
                        page.SetTable<T>($"{PageTitle} of {CreateLink("Setting", Key)}", null, EntitiesPerSetting[Key]);
                }
            }
        }
        SaveHTML("Setting");
        CreateSettingPages();
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
        CreateLanguagePages();
    }*/
    #endregion

    #region CHILD PAGES
    public static Task[] CreateSourcePages()
    {
        var tasks = new List<Task>();
        foreach (var _source in Ravenloftdb.Sources)
        {
            var source = _source; //Important for closure something
            tasks.Add(Task.Run(async () =>
            {
                var sb = new StringBuilder();

                string canonaddon = AddCanonAddOn(source.Canon);

                var editiontrait = EditionToString[source.editions];

                sb.CreateOfficialHeader(source.Name, 2);
                sb.AppendLine($"<h3>{nameof(Source)}<br/>{source.Name}{canonaddon}</h3>");
                sb.AppendLine($"<h3><i style='color:grey'>{editiontrait}</i></h3><br/>");

                sb.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");

                sb.AppendLine($"<b>Name:</b> {source.Name}<br/>");

                sb.Append($"<b>Media Type(s):</b> {MediaToString[source.Media]}<br/>");

                sb.AppendLine($"<b>Edition:</b> {editiontrait}<br/>");

                if (!string.IsNullOrEmpty(canonaddon))
                    sb.AppendLine($"<b>Canon:</b> {canonaddon}<br/>");

                sb.AppendLine($"<b>Release Date:</b> {source.ReleaseDate}<br/>");

                if (!string.IsNullOrEmpty(source.ExtraInfo))
                    sb.AppendLine($"<b>Extra Info:</b> {source.ExtraInfo}");

                bool CheckName(InSource<Domain> d) => !d.entity.Names.Contains(DomainToString[DomainEnum.InsideRavenloft][0]) && !d.entity.Names.Contains(DomainToString[DomainEnum.OutsideRavenloft][0]);
                var Domains = source.Domains.Where(CheckName);

                sb.AddSection(Domains          , nameof(source.Domains   ), EntityType.Domain   );
                sb.AddSection(source.Locations , nameof(source.Locations ), EntityType.Location );
                sb.AddSection(source.Characters, nameof(source.Characters), EntityType.Character);
                sb.AddSection(source.Items     , nameof(source.Items     ), EntityType.Item     );
                sb.AddSection(source.Groups    , nameof(source.Groups    ), EntityType.Group    );
                sb.AddSection(source.Clusters  , nameof(source.Clusters  ), EntityType.Cluster  );
                sb.AddSection(source.Mistways  , nameof(source.Mistways  ), EntityType.Mistway  );
                sb.AddSection(source.Languages , nameof(source.Languages ), EntityType.Language );
                sb.AddSection(source.Creatures , nameof(source.Creatures ), EntityType.Creature );
                sb.AddSection(source.Settings  , nameof(source.Settings  ), EntityType.Setting  );

                sb.AppendLine("</div></div><br/>");
                await sb.SaveHTML($"{nameof(Source)}/{source.Name}");
            }));
        }
        return tasks.ToArray();
    }
    public static Task[] CreateDomainPages()
    {
        var tasks = new List<Task>();
        foreach (var _domain in Ravenloftdb.Domains)
        {
            var domain = _domain;
            tasks.Add(Task.Run(async () =>
            {
                string ClusterAppend;
                if (domain.Value.Names.Contains(DomainToString[DomainEnum.InsideRavenloft][0]))
                    ClusterAppend = "These never had a domain stated.<br/>";
                else if (domain.Value.Names.Contains(DomainToString[DomainEnum.OutsideRavenloft][0]))
                    ClusterAppend = "These exist outside of Ravenloft but have some relation to it.<br/>";
                else
                {
                    var clusters = domain.Value.Clusters.SelectMany(kv => kv.Value.SelectMany(c => c.Names)).Distinct();
                    if (clusters.Count() == 0) clusters = ClusterToString[ClusterEnum.IslandsOfTerror];
                    ClusterAppend = $"<b>Cluster:</b> {string.Join(",", clusters)}<br/>";

                    if (domain.Value.Names.Count() > 1)
                    {
                        var links = CreateLink(EntityType.Domain, domain.Value.Names);
                        ClusterAppend += $"<b>Other Names:</b> {string.Join("/", links)}<br/>";
                    }

                    var Darklords = domain.Value.Darklords.SelectMany(d => d.Value.Select(d => d.Names)).Distinct();
                    if (Darklords.Count() > 0)
                    {
                        int i = 0;
                        var Links = new string[Darklords.Count()];
                        foreach (var darklord in Darklords) Links[i++] = CreateLink(EntityType.Character, darklord);
                        var LinkedDarklordNames = string.Join(", ", Links);
                        ClusterAppend += $"<b>Darklord(s):</b> {LinkedDarklordNames}<br/>";
                    }
                }

                var sb = new StringBuilder();
                var Sources = domain.Value.Sources;
                foreach (var domain in domain.Value.Names)
                {
                    using (var subheader = new SubHeader(sb))
                    {
                        sb.CreateOfficialHeader(domain, 2);
                        sb.AppendLine($"<h3>{nameof(Domain)}<br/>{domain}</h3>");

                        sb.AppendLine(ClusterAppend);

                        //Sources, Location, NPCs, Items, Groups, Languages, Creatures, 
                        var TotalSources = new HashSet<string>();
                        var Locations = new HashSet<string>();
                        var Characters = new HashSet<string>();
                        var Items = new HashSet<string>();
                        var Groups = new HashSet<string>();
                        var Languages = new HashSet<string>();
                        var Creatures = new HashSet<string>();
                        var Settings = new HashSet<string>();

                        using (var SplitSources = subheader.CreatePage("Per Source"))
                        {
                            var tempsb = new StringBuilder(); //This is just for the InsideRavenloft page.
                            Console.WriteLine($"SplitSources page created");
                            foreach (var source in Sources) //All sources with the domain's original name
                            {
                                Console.WriteLine($"Going through source {source.Name}");
                                tempsb.Clear();

                                string canonaddon = AddCanonAddOn(source.Canon);
                                string editiontrait = EditionToString[source.editions];

                                tempsb.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                                tempsb.AppendLine($"<b>Source:</b> {CreateLink(source)}{canonaddon}<br/>");
                                tempsb.AppendLine($"<b>Edition:</b> {editiontrait}<br/>");
                                if (!string.IsNullOrEmpty(source.ExtraInfo))
                                    tempsb.AppendLine($"<b>Extra Info:</b> {source.ExtraInfo}<br/>");

                                var languages = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Language));
                                var creatures = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Creature));
                                var settings = source.Entity.Traits.Where(t => t.Type == nameof(Traits.CampaignSetting));
                                if (domain != Factory.InsideRavenloftOriginalName)
                                {
                                    SplitSources.contents.Append(tempsb);
                                    if (domain != Factory.OutsideRavenloftOriginalName) //It's a normal domain, meta-domains don't get source material.
                                    {
                                        SplitSources.contents.AppendLine($"<b>Location(s) in Source:</b> {source.PageNumbers}<br/>");
                                        TotalSources.Add($"{CreateLink(source.Source)} (<i>{source.PageNumbers}</i>)");
                                    }
                                    SplitSources.AddSection(source.Entity.Locations, nameof(Locations), Locations);
                                    SplitSources.AddSection(source.Entity.NPCs, nameof(Characters), Characters);
                                    SplitSources.AddSection(source.Entity.Items, nameof(Items), Items);
                                    SplitSources.AddSection(source.Entity.Groups, nameof(Groups), Groups);
                                    SplitSources.AddSection(languages, nameof(Languages), Languages);
                                    SplitSources.AddSection(creatures, nameof(Creatures), Creatures);
                                    SplitSources.AddSection(settings, nameof(Settings), Settings);
                                }
                                else //Remove anything that has references to another domain
                                {
                                    var locations = RemoveReferences(source.Entity.Locations, Factory.db.Locations);
                                    Locations.UnionWith(locations);

                                    var characters = RemoveReferences(source.Entity.NPCs, Factory.db.NPCs);
                                    Characters.UnionWith(characters);

                                    var items = RemoveReferences(source.Entity.Items, Factory.db.Items);
                                    Items.UnionWith(items);

                                    var groups = RemoveReferences(source.Entity.Groups, Factory.db.Groups);
                                    Groups.UnionWith(groups);

                                    var _languages = RemoveReferencesForTraits(languages);
                                    Languages.UnionWith(_languages);

                                    var _creatures = RemoveReferencesForTraits(creatures);
                                    Creatures.UnionWith(_creatures);

                                    var _settings = RemoveReferencesForTraits(settings);
                                    Settings.UnionWith(_settings);

                                    if (locations.Count() + characters.Count() + items.Count() + groups.Count() + _languages.Count() + _creatures.Count() + _settings.Count() == 0) continue;
                                    SplitSources.contents.Append(tempsb);
                                    SplitSources.AddSection(locations, nameof(Locations));
                                    SplitSources.AddSection(characters, nameof(Characters));
                                    SplitSources.AddSection(items, nameof(Items));
                                    SplitSources.AddSection(groups, nameof(Groups));
                                    SplitSources.AddSection(_languages, nameof(Languages));
                                    SplitSources.AddSection(_creatures, nameof(Creatures));
                                    SplitSources.AddSection(_settings, nameof(Settings));

                                    static HashSet<string> RemoveReferences<T>(IEnumerable<T> ToSift, HashSet<T> ToReference) where T : UseVariableName, IHasDomains
                                    {
                                        var WithoutDomains = new HashSet<string>();
                                        var Names = ToSift.Select(l => l.OriginalName);
                                        foreach (var Name in Names)
                                        {
                                            var domains = ToReference.Where(l => l.OriginalName == Name).SelectMany(l => l.Domains).Select(d => d.OriginalName).Distinct();
                                            if (domains.Count() <= 1 && domains.Contains(Factory.InsideRavenloftOriginalName)) WithoutDomains.Add(Get.LinksOf<T>(Name));
                                        }
                                        return WithoutDomains;
                                    }
                                    static HashSet<string> RemoveReferencesForTraits(IEnumerable<Trait> ToSift)
                                    {
                                        var WithoutDomains = new HashSet<string>();
                                        foreach (var trait in ToSift)
                                        {
                                            var domains = Factory.db.Traits.Where(t => t == trait).SelectMany(l => l.Domains).Select(d => d.OriginalName).Distinct();
                                            if (domains.Count() <= 1 && domains.Contains(Factory.InsideRavenloftOriginalName)) WithoutDomains.Add(CreateLink(trait));
                                        }
                                        return WithoutDomains;
                                    }
                                }
                                SplitSources.contents.AppendLine("</div></div><br/>");
                            }
                        }
                        using (var AllSources = subheader.CreatePage("Combined"))
                        {
                            AllSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                            AllSources.AddSection(Locations, nameof(Locations));
                            AllSources.AddSection(Characters, nameof(Characters));
                            AllSources.AddSection(Items, nameof(Items));
                            AllSources.AddSection(Groups, nameof(Groups));
                            AllSources.AddSection(Languages, nameof(Languages));
                            AllSources.AddSection(Creatures, nameof(Creatures));
                            AllSources.AddSection(Settings, nameof(Settings));
                            AllSources.AddSection(TotalSources, nameof(Sources));
                            AllSources.contents.AppendLine("</div></div><br/>");
                        }
                    }
                    await sb.SaveHTML($"{nameof(Domain)}/{domain}");
                }
            }));
        }
        return tasks.ToArray();
    }
    /*public static void CreateCharacterPages()
    {
        var Characters = Get.AllOriginalsOf(typeof(NPC));
        foreach (var original in Characters)
        {
            var totalnames = Get.TotalNamesOf<NPC>(original);
            var Sources = Factory.db.npcAppearances.Where(i => i.Entity.OriginalName == original).Include(i => i.Entity.Domains)
                .Include(i => i.Entity.Locations).Include(i => i.Entity.Items).Include(i => i.Entity.Groups).Include(i => i.Entity.Traits);
            var Settings = Sources.SelectMany(s => s.Entity.Traits.Where(t => t.Type == nameof(Traits.CampaignSetting))).Distinct().ToArray();
            var SettingNames = new string[Settings.Count()];
            for (int i = 0; i < Settings.Count(); i++) SettingNames[i] = CreateLink(Settings[i]);
            foreach (var character in totalnames)
            {
                CreateOfficialHeader(character, 2);
                sb.AppendLine($"<h3>Character<br/>{character}</h3>");

                using (var subheader = new SubHeader())
                {
                    if (totalnames.Length > 1) sb.AppendLine($"<b>Other Names:</b> {Get.LinksOf<NPC>(original)}<br/>");

                    if (Settings.Count() > 0) sb.AppendLine($"<b>Campaign Setting Origin:</b> {string.Join(", ", SettingNames)}<br/>");

                    //Domains, Locations, Characters, Groups, Creatures, Sources
                    var TotalSources = new HashSet<string>();
                    var Domains = new HashSet<string>();
                    var Locations = new HashSet<string>();
                    var Items = new HashSet<string>();
                    var Groups = new HashSet<string>();
                    var Creatures = new HashSet<string>();
                    var Languages = new HashSet<string>();
                    var Alignments = new HashSet<string>();

                    using (var SplitSources = subheader.CreatePage("Per Source"))
                    {
                        foreach (var source in Sources)
                        {
                            var canonaddon = string.Empty;
                            var canontrait = source.Source.Traits.SingleOrDefault(t => t.Type == nameof(Traits.Canon));
                            if (canontrait == Traits.Canon.PotentialCanon) canonaddon = $" <b style='color:yellow'>[{canontrait.Key}]</b>";
                            else if (canontrait == Traits.Canon.NotCanon) canonaddon = $" <b style='color:red'>[{canontrait.Key}]</b>";
                            var editiontrait = source.Source.Traits.Single(t => t.Type == nameof(Traits.Edition)).Key;

                            SplitSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                            SplitSources.contents.AppendLine($"<b>Source:</b> {CreateLink(source.Source)}{canonaddon}<br/>");
                            SplitSources.contents.AppendLine($"<b>Edition:</b> {editiontrait}<br/>");
                            SplitSources.contents.AppendLine($"<b>Location(s) in Source:</b> {source.PageNumbers}<br/>");
                            if (!string.IsNullOrEmpty(source.Entity.ExtraInfo)) 
                                SplitSources.contents.AppendLine($"<b>Extra Info:</b> {source.Entity.ExtraInfo}<br/>");
                            TotalSources.Add($"{CreateLink(source.Source)} (<i>{source.PageNumbers}</i>)");

                            var languages  = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Language ));
                            var creatures  = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Creature ));
                            var alignments = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Alignment)).Select(t => t.Key);
                            Alignments.UnionWith(alignments);
                            SplitSources.AddSection(source.Entity.Domains  , nameof(Domains)   , Domains  );
                            SplitSources.AddSection(source.Entity.Locations, nameof(Locations) , Locations);
                            SplitSources.AddSection(source.Entity.Items    , nameof(Items)     , Items    );
                            SplitSources.AddSection(source.Entity.Groups   , GroupTitle        , Groups   );
                            SplitSources.AddSection(languages              , nameof(Languages) , Languages);
                            SplitSources.AddSection(creatures              , nameof(Creatures) , Creatures);
                            SplitSources.AddSection(alignments             , nameof(Alignments));
                            SplitSources.contents.AppendLine("</div></div><br/>");
                        }
                    }
                    using (var AllSources = subheader.CreatePage("All"))
                    {
                        AllSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                        AllSources.AddSection(Domains     , nameof(Domains   ));
                        AllSources.AddSection(Locations   , nameof(Locations ));
                        AllSources.AddSection(Items       , nameof(Items     ));
                        AllSources.AddSection(Groups      , nameof(Groups    ));
                        AllSources.AddSection(Creatures   , nameof(Creatures ));
                        AllSources.AddSection(Languages   , nameof(Languages ));
                        AllSources.AddSection(Alignments  , nameof(Alignments));
                        AllSources.AddSection(TotalSources, nameof(Sources   ));
                        AllSources.contents.AppendLine("</div></div><br/>");
                    }
                }
                SaveHTML($"Character/{character}");
            }
        }
    }
    public static void CreateLocationPages()
    {
        var Locations = Get.AllOriginalsOf(typeof(Location));
        foreach (var original in Locations)
        {
            var totalnames = Get.TotalNamesOf<Location>(original);
            var Sources = Factory.db.locationAppearances.Where(i => i.Entity.OriginalName == original).Include(d => d.Entity.Traits)
                .Include(d => d.Entity.Domains).Include(d => d.Entity.NPCs).Include(d => d.Entity.Items).Include(d => d.Entity.Groups);
            foreach (var location in totalnames)
            {
                using (var subheader = new SubHeader())
                {
                    var locationType = string.Empty;
                    var totalTraits = Sources.SelectMany(s => s.Entity.Traits);
                         if (totalTraits.Contains(Traits.Location.Settlement)) locationType = $" ({nameof(Traits.Location.Settlement)})";
                    else if (totalTraits.Contains(Traits.Location.Mistway   )) locationType = $" ({nameof(Traits.Location.Mistway   )})";
                    else if (totalTraits.Contains(Traits.Location.Darklord  )) locationType = $" ({nameof(Traits.Location.Darklord  )} Lair)";

                    var domainNames = Sources.SelectMany(l => l.Entity.Domains).Select(d => d.OriginalName).Distinct().ToArray();
                    var domains = new string[domainNames.Count()];
                    for (int i = 0; i < domainNames.Count(); i++) domains[i] = Get.LinksOf<Domain>(domainNames[i]);

                    CreateOfficialHeader(location, 2);
                    sb.AppendLine($"<h3>{nameof(Location)}<br/>{location}{locationType}</h3>");
                    sb.AppendLine($"<b>Domain(s):</b> {string.Join(", ", domains)}<br/>");
                    if (totalnames.Length > 1) sb.AppendLine($"<b>Other Names:</b> {Get.LinksOf<Location>(original)}<br/>");

                    if (totalTraits.Contains(Traits.Location.Settlement))
                        sb.AppendLine($"<b>Related:</b> {Get.LinksOf<Group>(original)}<br/>");

                    //Domain, NPCs, Items, Groups, Languages, Creatures, Sources
                    var TotalSources = new HashSet<string>();
                    var Characters = new HashSet<string>();
                    var Domains = new HashSet<string>();
                    var Items = new HashSet<string>();
                    var Groups = new HashSet<string>();
                    var Creatures = new HashSet<string>();

                    using (var SplitSources = subheader.CreatePage("Per Source"))
                    {
                        foreach (var source in Sources)
                        {
                            var canonaddon = string.Empty;
                            var canontrait = source.Source.Traits.SingleOrDefault(t => t.Type == nameof(Traits.Canon));
                            if (canontrait == Traits.Canon.PotentialCanon) canonaddon = $" <b style='color:yellow'>[{canontrait.Key}]</b>";
                            else if (canontrait == Traits.Canon.NotCanon) canonaddon = $" <b style='color:red'>[{canontrait.Key}]</b>";
                            var editiontrait = source.Source.Traits.Single(t => t.Type == nameof(Traits.Edition)).Key;

                            SplitSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                            SplitSources.contents.AppendLine($"<b>Source:</b> {CreateLink(source.Source)}{canonaddon}<br/>");
                            SplitSources.contents.AppendLine($"<b>Edition:</b> {editiontrait}<br/>");
                            SplitSources.contents.AppendLine($"<b>Location(s) in Source:</b> {source.PageNumbers}<br/>");
                            if (!string.IsNullOrEmpty(source.Entity.ExtraInfo)) 
                                SplitSources.contents.AppendLine($"<b>Extra Info:</b> {source.Entity.ExtraInfo}<br/>");
                            TotalSources.Add($"{CreateLink(source.Source)} (<i>{source.PageNumbers}</i>)");

                            var groups = source.Entity.Groups.Where(g => !g.Traits.Contains(Traits.Location.Settlement));
                            var creatures = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Creature));

                            SplitSources.AddSection(source.Entity.Domains, nameof(Domains   ), Domains   );
                            SplitSources.AddSection(source.Entity.NPCs   , nameof(Characters), Characters);
                            SplitSources.AddSection(source.Entity.Items  , nameof(Items     ), Items     );
                            SplitSources.AddSection(groups               , nameof(Groups    ), Groups    );
                            SplitSources.AddSection(creatures            , nameof(Creatures ), Creatures );
                            SplitSources.contents.AppendLine("</div></div><br/>");
                        }
                    }
                    using (var AllSources = subheader.CreatePage("All"))
                    {
                        AllSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                        AllSources.AddSection(Locations   , nameof(Locations));
                        AllSources.AddSection(Characters  , nameof(Characters));
                        AllSources.AddSection(Items       , nameof(Items));
                        AllSources.AddSection(Groups      , nameof(Groups));
                        AllSources.AddSection(Creatures   , nameof(Creatures));
                        AllSources.AddSection(TotalSources, nameof(Sources));
                        AllSources.contents.AppendLine("</div></div><br/>");
                    }
                }
                SaveHTML($"{nameof(Location)}/{location}");
            }
        }
    }
    public static void CreateItemPages()
    {
        var Items = Get.AllOriginalsOf(typeof(Item));
        foreach (var original in Items)
        {
            var totalnames = Get.TotalNamesOf<Item>(original);
            var Sources = Factory.db.itemAppearances.Where(i => i.Entity.OriginalName == original).Include(i => i.Entity.Domains)
                .Include(i => i.Entity.Locations).Include(i => i.Entity.NPCs).Include(i => i.Entity.Groups).Include(i => i.Entity.Traits);
            var Settings = Sources.SelectMany(s => s.Entity.Traits.Where(t => t.Type == nameof(Traits.CampaignSetting))).Distinct().ToArray();
            var SettingNames = new string[Settings.Count()];
            for (int i = 0; i < Settings.Count(); i++) SettingNames[i] = CreateLink(Settings[i]);
            foreach (var item in totalnames)
            {
                CreateOfficialHeader(item, 2);
                sb.AppendLine($"<h3>{nameof(Item)}<br/>{item}</h3>");

                using (var subheader = new SubHeader())
                {
                    if (totalnames.Length > 1) sb.AppendLine($"<b>Other Names:</b> {Get.LinksOf<Item>(original)}<br/>");

                    if (Settings.Count() > 0) sb.AppendLine($"<b>Campaign Setting Origin:</b> {string.Join(", ", SettingNames)}<br/>");

                    //Domains, Locations, Characters, Groups, Creatures, Sources
                    var TotalSources = new HashSet<string>();
                    var Domains = new HashSet<string>();
                    var Locations = new HashSet<string>();
                    var Characters = new HashSet<string>();
                    var Groups = new HashSet<string>();
                    var Creatures = new HashSet<string>();
                    var Alignments = new HashSet<string>();

                    using (var SplitSources = subheader.CreatePage("Per Source"))
                    {
                        foreach (var source in Sources)
                        {
                            var canonaddon = string.Empty;
                            var canontrait = source.Source.Traits.SingleOrDefault(t => t.Type == nameof(Traits.Canon));
                            if (canontrait == Traits.Canon.PotentialCanon) canonaddon = $" <b style='color:yellow'>[{canontrait.Key}]</b>";
                            else if (canontrait == Traits.Canon.NotCanon) canonaddon = $" <b style='color:red'>[{canontrait.Key}]</b>";
                            var editiontrait = source.Source.Traits.Single(t => t.Type == nameof(Traits.Edition)).Key;

                            SplitSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                            SplitSources.contents.AppendLine($"<b>Source:</b> {CreateLink(source.Source)}{canonaddon}<br/>");
                            SplitSources.contents.AppendLine($"<b>Edition:</b> {editiontrait}<br/>");
                            SplitSources.contents.AppendLine($"<b>Location(s) in Source:</b> {source.PageNumbers}<br/>");
                            if (!string.IsNullOrEmpty(source.Entity.ExtraInfo))
                                SplitSources.contents.AppendLine($"<b>Extra Info:</b> {source.Entity.ExtraInfo}<br/>");
                            TotalSources.Add($"{CreateLink(source.Source)} (<i>{source.PageNumbers}</i>)");

                            var creatures  = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Creature));
                            var settings   = source.Entity.Traits.Where(t => t.Type == nameof(Traits.CampaignSetting));
                            var alignments = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Alignment)).Select(t => t.Key);
                            Alignments.UnionWith(alignments);
                            SplitSources.AddSection(source.Entity.Domains  , nameof(Domains   ), Domains   );
                            SplitSources.AddSection(source.Entity.Locations, nameof(Locations ), Locations );
                            SplitSources.AddSection(source.Entity.NPCs     , nameof(Characters), Characters);
                            SplitSources.AddSection(source.Entity.Groups   , GroupTitle        , Groups    );
                            SplitSources.AddSection(creatures              , nameof(Creatures ), Creatures );
                            SplitSources.AddSection(alignments             , nameof(Alignments)            );
                            SplitSources.contents.AppendLine("</div></div><br/>");
                        }
                    }
                    using (var AllSources = subheader.CreatePage("All"))
                    {
                        AllSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                        AllSources.AddSection(Domains     , nameof(Domains   ));
                        AllSources.AddSection(Locations   , nameof(Locations ));
                        AllSources.AddSection(Characters  , nameof(Characters));
                        AllSources.AddSection(Groups      , GroupTitle        );
                        AllSources.AddSection(Creatures   , nameof(Creatures ));
                        AllSources.AddSection(Alignments  , nameof(Alignments));
                        AllSources.AddSection(TotalSources, nameof(Sources   ));
                        AllSources.contents.AppendLine("</div></div><br/>");
                    }
                }
                SaveHTML($"{nameof(Item)}/{item}");
            }
        }
    }
    public static void CreateGroupPages()
    {
        var Groups = Get.AllOriginalsOf(typeof(Group));
        foreach (var original in Groups)
        {
            var totalnames = Get.TotalNamesOf<Group>(original);
            var Sources = Factory.db.groupAppearances.Where(i => i.Entity.OriginalName == original).Include(i => i.Entity.Domains)
                .Include(i => i.Entity.Locations).Include(i => i.Entity.Items).Include(i => i.Entity.NPCs).Include(i => i.Entity.Traits);
            var Settings = Sources.SelectMany(s => s.Entity.Traits.Where(t => t.Type == nameof(Traits.CampaignSetting))).Distinct().ToArray();
            var SettingNames = new string[Settings.Count()];
            for (int i = 0; i < Settings.Count(); i++) SettingNames[i] = CreateLink(Settings[i]);
            foreach (var group in totalnames)
            {
                CreateOfficialHeader(group, 2);
                sb.AppendLine($"<h3>{nameof(Group)}<br/>{group}</h3>");
                using (var subheader = new SubHeader())
                {
                    if (totalnames.Length > 1) sb.AppendLine($"<b>Other Names:</b> {Get.LinksOf<NPC>(original)}<br/>");
                    if (Settings.Count() > 0) sb.AppendLine($"<b>Campaign Setting Origin:</b> {string.Join(", ", SettingNames)}<br/>");
                    //Domains, Locations, Characters, Groups, Creatures, Sources
                    var TotalSources = new HashSet<string>();
                    var Domains = new HashSet<string>();
                    var Locations = new HashSet<string>();
                    var Items = new HashSet<string>();
                    var Characters = new HashSet<string>();
                    var Creatures = new HashSet<string>();
                    var Languages = new HashSet<string>();
                    var Alignments = new HashSet<string>();

                    using (var SplitSources = subheader.CreatePage("Per Source"))
                    {
                        foreach (var source in Sources)
                        {
                            var canonaddon = string.Empty;
                            var canontrait = source.Source.Traits.SingleOrDefault(t => t.Type == nameof(Traits.Canon));
                            if (canontrait == Traits.Canon.PotentialCanon) canonaddon = $" <b style='color:yellow'>[{canontrait.Key}]</b>";
                            else if (canontrait == Traits.Canon.NotCanon) canonaddon = $" <b style='color:red'>[{canontrait.Key}]</b>";
                            var editiontrait = source.Source.Traits.Single(t => t.Type == nameof(Traits.Edition)).Key;

                            SplitSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                            SplitSources.contents.AppendLine($"<b>Source:</b> {CreateLink(source.Source)}{canonaddon}<br/>");
                            SplitSources.contents.AppendLine($"<b>Edition:</b> {editiontrait}<br/>");
                            SplitSources.contents.AppendLine($"<b>Location(s) in Source:</b> {source.PageNumbers}<br/>");
                            if (!string.IsNullOrEmpty(source.Entity.ExtraInfo))
                                SplitSources.contents.AppendLine($"<b>Extra Info:</b> {source.Entity.ExtraInfo}<br/>");
                            TotalSources.Add($"{CreateLink(source.Source)} (<i>{source.PageNumbers}</i>)");

                            var languages  = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Language ));
                            var creatures  = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Creature ));
                            var alignments = source.Entity.Traits.Where(t => t.Type == nameof(Traits.Alignment)).Select(t => t.Key);
                            Alignments.UnionWith(alignments);
                            SplitSources.AddSection(source.Entity.Domains  , nameof(Domains   ), Domains   );
                            SplitSources.AddSection(source.Entity.Locations, nameof(Locations ), Locations );
                            SplitSources.AddSection(source.Entity.Items    , nameof(Items     ), Items     );
                            SplitSources.AddSection(source.Entity.NPCs     , nameof(Characters), Characters);
                            SplitSources.AddSection(languages              , nameof(Languages ), Languages );
                            SplitSources.AddSection(creatures              , nameof(Creatures ), Creatures );
                            SplitSources.AddSection(alignments             , nameof(Alignments)            );
                            SplitSources.contents.AppendLine("</div></div><br/>");
                        }
                    }
                    using (var AllSources = subheader.CreatePage("All"))
                    {
                        AllSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                        AllSources.AddSection(Domains     , nameof(Domains   ));
                        AllSources.AddSection(Locations   , nameof(Locations ));
                        AllSources.AddSection(Items       , nameof(Items     ));
                        AllSources.AddSection(Characters  , nameof(Characters));
                        AllSources.AddSection(Creatures   , nameof(Creatures ));
                        AllSources.AddSection(Languages   , nameof(Languages ));
                        AllSources.AddSection(Alignments  , nameof(Alignments));
                        AllSources.AddSection(TotalSources, nameof(Sources   ));
                        AllSources.contents.AppendLine("</div></div><br/>");
                    }
                }
                SaveHTML($"{nameof(Group)}/{group}");
            }
        }
    }

    public static void CreateCreaturePages() => CreateTraitPages(nameof(Traits.Creature));
    public static void CreateSettingPages()  => CreateTraitPages("Setting", nameof(Traits.CampaignSetting));
    public static void CreateLanguagePages() => CreateTraitPages(nameof(Traits.Language));
    private static void CreateTraitPages(string title, string? TraitType = null)
    {
        if (string.IsNullOrEmpty(TraitType)) TraitType = title;

        var Domains    = GetTraitsPerSource<DomainAppearance  , Domain  >(Factory.db.domainAppearances  );
        var Locations  = GetTraitsPerSource<LocationAppearance, Location>(Factory.db.locationAppearances);
        var Characters = GetTraitsPerSource<NPCAppearance     , NPC     >(Factory.db.npcAppearances     );
        var Items      = GetTraitsPerSource<ItemAppearance    , Item    >(Factory.db.itemAppearances    );
        var Groups     = GetTraitsPerSource<GroupAppearance   , Group   >(Factory.db.groupAppearances   );
        Dictionary<string, Dictionary<Source, HashSet<string>>> GetTraitsPerSource<T, U>(IQueryable<T> dbSet)
            where T : Appearance, IHasEntity<U> where U : UseVariableName
        {
            var retval = new Dictionary<string, Dictionary<Source, HashSet<string>>>();
            var Sources = dbSet.Where(d => d.Entity.Traits.Any(t => t.Type == TraitType)).GroupBy(d => d.Source);
            foreach (var source in Sources)
            {
                foreach (var appearance in source)
                {
                    var traits = appearance.Entity.Traits.Where(t => t.Type == TraitType);
                    foreach (var trait in traits)
                    {
                        retval.TryAdd(trait.Key, new Dictionary<Source, HashSet<string>>());
                        retval[trait.Key].TryAdd(appearance.Source, new HashSet<string>());
                        retval[trait.Key][appearance.Source].Add(Get.LinksOf<U>(appearance.Entity.OriginalName));
                    }
                }
            }
            return retval;
        }

        var traits = new HashSet<string>();
        traits.UnionWith(Domains   .Keys);
        traits.UnionWith(Locations .Keys);
        traits.UnionWith(Characters.Keys);
        traits.UnionWith(Items     .Keys);
        traits.UnionWith(Groups    .Keys);

        foreach (var trait in traits)
        {
            var ExtraInfo = Factory.db.Traits.Single(t => t.Type == TraitType && t.Key == trait).ExtraInfo;

            CreateOfficialHeader(trait, 2);
            sb.AppendLine($"<h3>{title}<br/>{trait}</h3>");
            if (!string.IsNullOrEmpty(ExtraInfo)) sb.AppendLine($"<b>Extra Info:</b> {ExtraInfo}<br/>");

            using (var subheader = new SubHeader())
            {
                bool HasContent = false;
                using (var SplitSources = subheader.CreatePage("Per Source"))
                {
                    var sources = new HashSet<Source>();
                    var iDomains    = AddKeys(Domains   );
                    var iLocations  = AddKeys(Locations );
                    var iCharacters = AddKeys(Characters);
                    var iItems      = AddKeys(Items     );
                    var iGroups     = AddKeys(Groups    );
                    Dictionary<Source, HashSet<string>> AddKeys (Dictionary<string, Dictionary<Source, HashSet<string>>> dict)
                    {
                        if (dict.TryGetValue(trait, out var idict)) sources.UnionWith(idict.Keys);
                        return idict;
                    }

                    foreach (var source in sources)
                    {
                        var canonaddon = string.Empty;
                        var canontrait = source.Traits.SingleOrDefault(t => t.Type == nameof(Traits.Canon));
                        if (canontrait == Traits.Canon.PotentialCanon) canonaddon = $" <b style='color:yellow'>[{canontrait.Key}]</b>";
                        else if (canontrait == Traits.Canon.NotCanon) canonaddon = $" <b style='color:red'>[{canontrait.Key}]</b>";
                        var editiontrait = source.Traits.Single(t => t.Type == nameof(Traits.Edition)).Key;

                        SplitSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                        SplitSources.contents.AppendLine($"<b>Source:</b> {CreateLink(source)}{canonaddon}<br/>");
                        SplitSources.contents.AppendLine($"<b>Edition:</b> {editiontrait}<br/>");
                        SplitSources.contents.AppendLine($"<b>Extra Info:</b> {source.ExtraInfo}<br/>");

                        if (iDomains?.ContainsKey(source) == true)
                        {
                            iDomains[source].Remove(Get.LinksOf<Domain>(Factory.InsideRavenloftOriginalName));
                            iDomains[source].Remove(Get.LinksOf<Domain>(Factory.OutsideRavenloftOriginalName));
                            AddSection(iDomains, nameof(Domains));
                        }
                        AddSection(iLocations , nameof(Locations ));
                        AddSection(iCharacters, nameof(Characters));
                        AddSection(iItems     , nameof(Items     ));
                        AddSection(iGroups    , nameof(Groups    ));
                        SplitSources.contents.AppendLine("</div></div><br/>");
                        void AddSection (Dictionary<Source, HashSet<string>> idict, string title)
                        {
                            if (idict?.TryGetValue(source, out var value) == true)
                            {
                                if (value.Count() > 0) HasContent = true;
                                SplitSources.AddSection(value, title);
                            }
                        }
                    }
                }
                if (HasContent)
                {
                    using var AllSources = subheader.CreatePage("All");
                    AllSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                    AddSection(Domains   , nameof(Domains   ));
                    AddSection(Locations , nameof(Locations ));
                    AddSection(Characters, nameof(Characters));
                    AddSection(Items     , nameof(Items     ));
                    AddSection(Groups    , nameof(Groups    ));
                    AllSources.contents.AppendLine("</div></div><br/>");
                    void AddSection(Dictionary<string, Dictionary<Source, HashSet<string>>> dict, string title)
                    {
                        if (dict.TryGetValue(trait, out var idict)) AllSources.AddSection(idict.SelectMany(e => e.Value).Distinct(), title);
                    }
                }
            }
            SaveHTML($"{title}/{trait}");
        }
    }*/
    #endregion
}