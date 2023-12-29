using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NUglify;
using NUglify.Html;
using System;
using System.Text;
using System.Xml.Linq;
using static Factory;
using static Traits;

internal static class CreateHTML
{
    #region PREGENERATED DATA
    private const string WebsiteTitle = "Ravenloft Catalogue";
    private const string GroupTitle = "Groups/Titles";
    private const string IslandsOfTerror = "Islands of Terror";
    private static string InsideRavenloftLink  = CreateLink(DomainEnum.InsideRavenloft );
    private static string OutsideRavenloftLink = CreateLink(DomainEnum.OutsideRavenloft);

    private enum EntityType { Source, Domain, Character, Location, Item, Group, Canon, Language, Setting, Creature };
    private static string FixLink(string link) => link.Replace(":", string.Empty).Replace("'", string.Empty);
    private static string CreateLink(string subdomain, params string[] names)
    {
        int i = 0;
        var linkedNames = new string[names.Count()];
        foreach (var name in names) linkedNames[i++] = $"<a href='/{subdomain}/{FixLink(name)}'>{name}</a>";
        return string.Join("/", linkedNames);
    }
    private static string CreateLink(string subdomain, IEnumerable<string> names) => CreateLink(subdomain, names.ToArray());
    private static string CreateLink(EntityType type, params string[] names) => CreateLink(type.ToString(), names);
    private static string CreateLink(EntityType type, IEnumerable<string> names) => CreateLink(type.ToString(), names);
    private static string CreateLink(Source entity) => CreateLink(nameof(Source), entity.Name);
    private static string CreateLink<T>(T entity) where T : UseVariableName => CreateLink(typeof(T).ToString(), entity.Names);
    private static string CreateLink(DomainEnum domain) => CreateLink(EntityType.Domain, Ravenloftdb.Domains[domain].Names);
    private static string CreateLink(ClusterEnum cluster) => CreateLink(EntityType.Group, Ravenloftdb.Clusters[cluster].Names);
    private static string CreateLink(MistwayEnum mistway) => CreateLink(EntityType.Location, Ravenloftdb.Mistways[mistway].Names);
    private static string[] GetEditionsOf(Edition ToCheck)
    {
        var Editions = Enum.GetValues<Edition>();
        var retval = new string[Editions.Length];

        for (int i = 0; i < Editions.Length; i++)
            retval[i] = ToCheck.HasFlag(Editions[i]) ? "X" : string.Empty;

        return retval;
    }
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
                foreach (var edition in Enum.GetValues<Edition>())
                    sb.AppendLine($"<th scope='col'>").AppendLine($"<b>{EditionToString(edition)}</b>").AppendLine("</th>");
                col += Enum.GetValues<Edition>().Length;
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
            public void SetTable<T>(string title, string? caption, SortedSet<T> Entities) where T : UseVariableName
            {
                if (Entities == null || Entities.Count == 0) return;
                using (var table = CreateTable(title, caption))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)").CreateEditionHeaders();

                    foreach (var entity in Entities)
                    {
                        var rowval = new List<string>() { CreateLink(entity) };
                        rowval.AddRange(GetEditionsOf(entity.editions));
                        table.AddRows(rowval.ToArray());
                    }
                }
            }
            public void Dispose() => contents.AppendLine("</div>");

            public void AddSection<T>(IEnumerable<TrackPage<T>> list, string title, EntityType type) where T : UseVariableName
            {
                if (list.Count() == 0) return;

                int i = 0;
                string[] names = new string[list.Count()];
                foreach (var instance in list) names[i++] = CreateLink(type, instance.entity.Names);
                AddSection(names, title);
            }
            public void AddSection<T>(IEnumerable<T> list, string title, EntityType type) where T : UseVariableName
            {
                if (list.Count() == 0) return;

                int i = 0;
                string[] names = new string[list.Count()];
                foreach (var instance in list) names[i++] = CreateLink(type, instance.Names);
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
    private static void AddSection<T>(this StringBuilder sb, IEnumerable<TrackPage<T>> list, string title, EntityType type) where T : UseVariableName
        => sb.AddSection(list.Select(i => CreateLink(type, i.entity.Names)), title);
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
                        string edition = EditionToString(source.editions);
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
                        table.AddRows(new[] { EditionToString(edition.Key), edition.Value.Count.ToString() });
                }
                foreach (var edition in Ravenloftdb.Editions)
                {
                    using (var table = Edition.CreateTable(EditionToString(edition.Key)))
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
                            string edition = EditionToString(source.editions);
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

                        int i = 0;
                        var Links = new string[kv.Value.Darklords.Total.Count()];
                        foreach (var darklord in kv.Value.Darklords.Total) Links[i++] = CreateLink(darklord);
                        var LinkedDarklordNames = string.Join(", ", Links);

                        var rowval = new List<string>() { CreateLink(kv.Key), LinkedDarklordNames };
                        rowval.AddRange(GetEditionsOf(kv.Value.editions));
                        table.AddRows(rowval.ToArray());
                    }
                }
            }
            using (var Group = subheader.CreatePage("By Cluster/Type"))
            {
                var IsolatedDomains = Ravenloftdb.Domains.Where(kv => kv.Value.Clusters.Total.Count() == 0);

                using (var table = Group.CreateTable("Domains per Cluster"))
                {
                    using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Name", "Domains").CreateEditionHeaders();

                    var ClusteredDomains = new HashSet<string>();
                    foreach (var kv in Ravenloftdb.Clusters)
                    {
                        var ClusterName = kv.Key.ToString();
                        var DomainCount = kv.Value.Domains.Total.Count();
                        if (kv.Key == ClusterEnum.IslandsOfTerror) DomainCount += IsolatedDomains.Count();

                        var rowval = new List<string>() { ClusterName, DomainCount.ToString() };
                        rowval.AddRange(GetEditionsOf(kv.Value.editions));
                        table.AddRows(rowval.ToArray());
                    }
                }
                foreach (var cluster in Ravenloftdb.Clusters)
                {
                    var ClusterNames = CreateLink(cluster.Key);
                    using (var table = Group.CreateTable(ClusterNames, null))
                    {
                        using (var headerRow = table.CreateHeaderRow())
                            headerRow.CreateHeader("Name(s)").CreateEditionHeaders();

                        foreach (var domain in cluster.Value.Domains.Total)
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
    public async static Task CreateLocationPage()
    {
        var sb = new StringBuilder();
        sb.CreateOfficialHeader("Locations of Ravenloft", 1);
        sb.AppendLine("I only track buildings, so individual rooms will not be listed.");

        using (var subheader = new SubHeader(sb))
        {
            using (var AllPage = subheader.CreatePage("Domains")) //Consider filtering for Inside Ravenloft somewhere before here.
            {
                foreach (var kv in Ravenloftdb.LocationsPerDomain)
                {
                    if (kv.Key == DomainEnum.InsideRavenloft) continue;
                    AllPage.SetTable($"Locations of {CreateLink(kv.Key)}", null, kv.Value);
                }
                AllPage.SetTable($"Locations {InsideRavenloftLink}", null, Ravenloftdb.LocationsPerDomain[DomainEnum.InsideRavenloft]);
                //It shouldn't show outside ravenloft cause I don't track outside locations.
            }
            using (var SettlementPage = subheader.CreatePage("Settlements"))
            {
                foreach (var kv in Ravenloftdb.SettlementsPerDomain)
                {
                    if (kv.Key == DomainEnum.InsideRavenloft) continue;
                    SettlementPage.SetTable($"Locations of {CreateLink(kv.Key)}", null, kv.Value);
                }            
                SettlementPage.SetTable($"Locations {InsideRavenloftLink}", null, Ravenloftdb.SettlementsPerDomain[DomainEnum.InsideRavenloft]);
                //It shouldn't show outside ravenloft cause I don't track outside settlements.
            }
            using (var LairPage = subheader.CreatePage("Darklord Lairs"))
            {
                using (var table = LairPage.CreateTable($"List of Darklord Lairs"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)", "Domain(s)", "Darklord").CreateEditionHeaders();

                    foreach (var kv in Ravenloftdb.Domains)
                    {
                        foreach (var darklord in kv.Value.Darklords.Total)
                        {
                            if (darklord.DarklordLair == null) continue; //No lair, no entry

                            var rowval = new List<string>()
                            {
                                CreateLink(darklord.DarklordLair),
                                CreateLink(kv.Key),
                                CreateLink(darklord),
                            };
                            rowval.AddRange(GetEditionsOf(darklord.DarklordLair.editions));

                            table.AddRows(rowval.ToArray());
                        }
                    }
                }
            }
            using (var MistwayPage = subheader.CreatePage("Mistways"))
            {
                using (var table = MistwayPage.CreateTable($"List of Mistways"))
                {
                    using (var headerRow = table.CreateHeaderRow())
                        headerRow.CreateHeader("Name(s)", "Domain", "Domain").CreateEditionHeaders();

                    foreach (var kv in Ravenloftdb.Mistways)
                    {
                        var domains = kv.Value.Domains.Total.ToArray();
                        var rowval = new List<string>() { CreateLink(kv.Key), CreateLink(domains[0]), CreateLink(domains[1]) };
                        rowval.AddRange(GetEditionsOf(kv.Value.editions));

                        table.AddRows(rowval.ToArray());
                    }
                }
            } 
        }
        await sb.SaveHTML(nameof(Location));
    }
    public async static Task CreateCharacterPage()
    {
        var sb = new StringBuilder();
        sb.CreateOfficialHeader("Characters of Ravenloft", 1);

        using (var subheader = new SubHeader(sb))
        {
            using (var Domain = subheader.CreatePage("By Domain"))
            {
                foreach (var kv in Ravenloftdb.CharactersPerDomain)
                {
                    if (kv.Key == DomainEnum.InsideRavenloft || kv.Key == DomainEnum.OutsideRavenloft) continue;
                    Domain.SetTable($"Characters of {CreateLink(kv.Key)}", null, kv.Value);
                }
                Domain.SetTable($"Characters {InsideRavenloftLink }", null, Ravenloftdb.CharactersPerDomain[DomainEnum.InsideRavenloft ]);
                Domain.SetTable($"Characters {OutsideRavenloftLink}", null, Ravenloftdb.CharactersPerDomain[DomainEnum.OutsideRavenloft]);
            }
            using (var Group = subheader.CreatePage("By Group"))
            {
                foreach (var kv in Ravenloftdb.CharactersPerGroup)
                    Group.SetTable($"Characters of {CreateLink(kv.Key)}", null, kv.Value);
            }
            using (var Creature = subheader.CreatePage("By Creature Type"))
            {
                foreach (var kv in Ravenloftdb.CharactersPerCreature)
                    Creature.SetTable($"Characters of {CreateLink(EntityType.Creature, kv.Key.Names)}", null, kv.Value);
            }
        }

        await sb.SaveHTML("Character");
    }
    public async static Task CreateItemPage()
    {
        var sb = new StringBuilder();
        sb.CreateOfficialHeader("Items of Ravenloft", 1);
        sb.AppendLine("I track magic and significant mundane items.");

        using (var subheader = new SubHeader(sb))
        {
            using (var Domain = subheader.CreatePage("By Domain"))
            {
                foreach (var kv in Ravenloftdb.ItemsPerDomain)
                {
                    if (kv.Key == DomainEnum.InsideRavenloft || kv.Key == DomainEnum.OutsideRavenloft) continue;
                    Domain.SetTable($"Items of {CreateLink(kv.Key)}", null, kv.Value);
                }
                Domain.SetTable($"Items {InsideRavenloftLink}", null, Ravenloftdb.ItemsPerDomain[DomainEnum.InsideRavenloft]);
                Domain.SetTable($"Items {OutsideRavenloftLink}", null, Ravenloftdb.ItemsPerDomain[DomainEnum.OutsideRavenloft]);
            }
            using (var Group = subheader.CreatePage("By Group")) //Status Traits
            {
                foreach (var kv in Ravenloftdb.ItemsPerGroup)
                    Group.SetTable($"Items of {CreateLink(kv.Key)}", null, kv.Value);
            }
            using (var Creature = subheader.CreatePage("By Creature")) //Creature Traits
            {
                foreach (var kv in Ravenloftdb.ItemsPerCreature)
                    Creature.SetTable($"Items of {CreateLink(EntityType.Creature, kv.Key.Names)}", null, kv.Value);
            }
        }
        await sb.SaveHTML(nameof(Item));
    }
    public async static Task CreateGroupPage() //Fix this some day
    {
        var sb = new StringBuilder();
        sb.CreateOfficialHeader($"{GroupTitle} of Ravenloft", 1);

        using (var subheader = new SubHeader(sb))
        {
            using (var Total = subheader.CreatePage("Total")) 
            {
                using (var table = Total.CreateTable($"All {GroupTitle} in Ravenloft"))
                {
                    using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Name(s)", "Pop.").CreateEditionHeaders();
                    foreach (var kv in Ravenloftdb.Groups)
                    {
                        var links = CreateLink(EntityType.Group, kv.Value.Names);
                        var population = kv.Value.Characters.Total.Count().ToString();

                        var rowval = new List<string>() { links, population };
                        rowval.AddRange(GetEditionsOf(kv.Value.editions));
                        table.AddRows(rowval.ToArray());
                    }
                }
            }
            using (var Domain = subheader.CreatePage("By Domain"))
            {
                foreach (var kv in Ravenloftdb.GroupsPerDomain)
                {
                    if (kv.Key == DomainEnum.InsideRavenloft || kv.Key == DomainEnum.OutsideRavenloft) continue;
                    Domain.SetTable($"Groups of {CreateLink(kv.Key)}", null, kv.Value);
                }
                Domain.SetTable($"Groups {InsideRavenloftLink }", null, Ravenloftdb.GroupsPerDomain[DomainEnum.InsideRavenloft ]);
                Domain.SetTable($"Groups {OutsideRavenloftLink}", null, Ravenloftdb.GroupsPerDomain[DomainEnum.OutsideRavenloft]);
            }
        }
        await sb.SaveHTML("Group");
    }

    public async static Task CreateCreaturePage()
    {
        var sb = new StringBuilder();
        sb.CreateOfficialHeader("Creatures of Ravenloft", 1);

        using (var subheader = new SubHeader(sb))
        {
            using (var Domain = subheader.CreatePage("Per Domain"))
            {
                int i = 0;
                foreach (var kv in Ravenloftdb.CreaturesPerDomain)
                {
                    if (kv.Key == DomainEnum.InsideRavenloft) continue;
                    CreateTable($"Creatures of {CreateLink(kv.Key)}", EntityType.Creature, kv.Value);
                }
                CreateTable($"Creatures {InsideRavenloftLink}", EntityType.Creature, Ravenloftdb.CreaturesPerDomain[DomainEnum.InsideRavenloft]);

                void CreateTable(string title, EntityType type, SortedSet<Trait> Creatures)
                {
                    using (var table = new Table(sb, (i++).ToString(), title))
                    {
                        using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Name").CreateEditionHeaders();
                        foreach (var creature in Creatures)
                        {
                            var rowval = new List<string>() { CreateLink(EntityType.Creature, creature.Names) };
                            rowval.AddRange(GetEditionsOf(creature.editions));
                            table.AddRows(rowval.ToArray());
                        }
                    }
                }
            }
            using (var Creature = subheader.CreatePage("Per Creature"))
            {
                int i = 0;
                foreach (var kv in Ravenloftdb.DomainsPerCreature)
                {
                    var title = $"Domains with {CreateLink(EntityType.Creature, kv.Key.Names)}";
                    using (var table = new Table(sb, (i++).ToString(), title))
                    {
                        using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Name").CreateEditionHeaders();
                        foreach (var domain in kv.Value)
                        {
                            var rowval = new List<string>() { CreateLink(domain) };
                            rowval.AddRange(GetEditionsOf(Ravenloftdb.Domains[domain].editions));
                            table.AddRows(rowval.ToArray());
                        }
                    }
                }
            }
        }
        await sb.SaveHTML(nameof(Traits.Creature));
    }
    public async static Task CreateCampaignSettingPage()
    {
        var sb = new StringBuilder();
        sb.CreateOfficialHeader("Other Campaign Settings in Ravenloft", 1);

        int i = 0;
        foreach (var kv in Ravenloftdb.CampaignSettings)
        {
            var link = CreateLink(EntityType.Setting, Ravenloftdb.CampaignSettings[kv.Key].Names);
            sb.Append($"<details><summary><b style='font-size:25px'>{link}</b></summary>");
            AddTable($"Characters of {link}", kv.Value.Characters.Total);
            AddTable($"Items of {link     }", kv.Value.Items     .Total);
            AddTable($"Groups of {link    }", kv.Value.Groups    .Total);
            sb.Append("</details>");
        }

        void AddTable<T>(string title, SortedSet<T> entities) where T : UseVariableName
        {
            using (var table = new Table(sb, (i++).ToString(), title))
            {
                using (var headerRow = table.CreateHeaderRow()) headerRow.CreateHeader("Name(s)").CreateEditionHeaders();
                foreach (var entity in entities)
                {
                    var rowval = new List<string>() { CreateLink(entity) };
                    rowval.AddRange(GetEditionsOf(entity.editions));
                    table.AddRows(rowval.ToArray());
                }
            }
        }
        await sb.SaveHTML("Setting");
    }
    public async static Task CreateLanguagesPage()
    {
        var sb = new StringBuilder();
        sb.CreateOfficialHeader("Languages of Ravenloft", 1);

        using (var subheader = new SubHeader(sb))
        {
            using (var Domain = subheader.CreatePage("Per Domain"))
            {
                foreach (var kv in Ravenloftdb.LanguagesPerDomain)
                {
                    if (kv.Key == DomainEnum.InsideRavenloft) continue;
                    Domain.SetTable($"Languages of {CreateLink(kv.Key)}", null, kv.Value);
                }
                Domain.SetTable($"Languages {InsideRavenloftLink}", null, Ravenloftdb.LanguagesPerDomain[DomainEnum.InsideRavenloft]);
            }
            using (var Language = subheader.CreatePage("Per Language"))
            {
                foreach (var kv in Ravenloftdb.DomainsPerLanguage)
                {
                    Language.SetTable($"Domains that speak {CreateLink(EntityType.Language, kv.Key.Names)}", null, kv.Value);

                    using (var table = Language.CreateTable(title, caption))
                    {
                        using (var headerRow = table.CreateHeaderRow())
                            headerRow.CreateHeader("Name(s)").CreateEditionHeaders();

                        foreach (var entity in Entities)
                        {
                            var rowval = new List<string>() { CreateLink(entity) };
                            rowval.AddRange(GetEditionsOf(entity.editions));
                            table.AddRows(rowval.ToArray());
                        }
                    }
                }
            }
            using (var Character = subheader.CreatePage("Per Character"))
            {

            }
        }

        await sb.SaveHTML(nameof(Traits.Language));
    }
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
        foreach (var _original in Ravenloftdb.Domains)
        {
            var original = _original;
            tasks.Add(Task.Run(async () =>
            {
                string ExtraAppend = string.Empty;
                if (original.Value.Names.Contains(DomainToString[DomainEnum.InsideRavenloft][0]))
                    ExtraAppend += "These never had a domain stated.<br/>";
                else if (original.Value.Names.Contains(DomainToString[DomainEnum.OutsideRavenloft][0]))
                    ExtraAppend += "These exist outside of Ravenloft but have some relation to it.<br/>";
                else
                {
                    var Darklords = original.Value.Darklords;
                    if (Darklords.Count() > 0)
                    {
                        int i = 0;
                        var Links = new string[Darklords.Count()];
                        foreach (var darklord in Darklords) Links[i++] = CreateLink(EntityType.Character, darklord.Names);
                        var LinkedDarklordNames = string.Join(", ", Links);
                        ExtraAppend += $"<b>Darklord(s):</b> {LinkedDarklordNames}<br/>";
                    }

                    var MistTalismans = 

                    var clusters = original.Value.Clusters.SelectMany(c => c.Names).ToArray();
                    if (clusters.Count() == 0) clusters = ClusterToString[ClusterEnum.IslandsOfTerror];
                    ExtraAppend += $"<b>Cluster:</b> {string.Join(",", clusters)}<br/>";

                    if (original.Value.Names.Count() > 1)
                    {
                        var links = CreateLink(EntityType.Domain, original.Value.Names);
                        ExtraAppend += $"<b>Other Names:</b> {string.Join("/", links)}<br/>";
                    }
                }

                var sb = new StringBuilder();
                foreach (var domain in original.Value.Names)
                {
                    using (var subheader = new SubHeader(sb))
                    {
                        sb.CreateOfficialHeader(domain, 2);
                        sb.AppendLine($"<h3>{nameof(Domain)}<br/>{domain}</h3>");

                        sb.AppendLine(ExtraAppend);

                        //Sources, Location, NPCs, Items, Groups, Languages, Creatures, 
                        var TotalSources = new HashSet<string>();

                        using (var SplitSources = subheader.CreatePage("Per Source"))
                        {
                            foreach (var source in original.Value.Sources) //All sources with the domain's original name
                            {
                                string canonaddon = AddCanonAddOn(source.Canon);
                                string editiontrait = EditionToString[source.editions];

                                SplitSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                                SplitSources.contents.AppendLine($"<b>Source:</b> {CreateLink(source)}{canonaddon}<br/>");
                                SplitSources.contents.AppendLine($"<b>Edition:</b> {editiontrait}<br/>");
                                if (!string.IsNullOrEmpty(source.ExtraInfo))
                                    SplitSources.contents.AppendLine($"<b>Extra Info:</b> {source.ExtraInfo}<br/>");

                                if (domain != DomainToString[DomainEnum.InsideRavenloft ][0] &&
                                    domain != DomainToString[DomainEnum.OutsideRavenloft][0]) //Meta-domains don't get source material.
                                {
                                    var PageNumbers = source.Domains.Single(e => e.entity == original.Value).PageNumbers;
                                    SplitSources.contents.AppendLine($"<b>Location(s) in Source:</b> {PageNumbers}<br/>");
                                    TotalSources.Add($"{CreateLink(source)} (<i>{PageNumbers}</i>)");
                                }

                                SplitSources.AddSection(original.Value.LocationsPerSource [source], nameof(source.Locations ), EntityType.Location);
                                SplitSources.AddSection(original.Value.CharactersPerSource[source], nameof(source.Characters), EntityType.Character);
                                SplitSources.AddSection(original.Value.ItemsPerSource     [source], nameof(source.Items     ), EntityType.Item);
                                SplitSources.AddSection(original.Value.GroupsPerSource    [source], nameof(source.Groups    ), EntityType.Group);
                                SplitSources.AddSection(original.Value.ClustersPerSource  [source], nameof(source.Clusters  ), EntityType.Cluster);
                                SplitSources.AddSection(original.Value.MistwaysPerSource  [source], nameof(source.Mistways  ), EntityType.Mistway);
                                SplitSources.AddSection(original.Value.Languages                  , nameof(source.Languages ), EntityType.Language);
                                SplitSources.AddSection(original.Value.Creatures                  , nameof(source.Creatures ), EntityType.Creature);
                                SplitSources.AddSection(original.Value.Settings                   , nameof(source.Settings  ), EntityType.Setting);
                                SplitSources.contents.AppendLine("</div></div><br/>");
                            }
                        }
                        using (var AllSources = subheader.CreatePage("Combined"))
                        {
                            AllSources.contents.AppendLine("<div class='container'>").AppendLine("<div class='textbox'>");
                            AllSources.AddSection(original.Value.Locations , nameof(original.Value.Locations ), EntityType.Location );
                            AllSources.AddSection(original.Value.Characters, nameof(original.Value.Characters), EntityType.Character);
                            AllSources.AddSection(original.Value.Items     , nameof(original.Value.Items     ), EntityType.Item     );
                            AllSources.AddSection(original.Value.Groups    , nameof(original.Value.Groups    ), EntityType.Group    );
                            AllSources.AddSection(original.Value.Languages , nameof(original.Value.Languages ), EntityType.Language );
                            AllSources.AddSection(original.Value.Creatures , nameof(original.Value.Creatures ), EntityType.Creature );
                            AllSources.AddSection(original.Value.Settings  , nameof(original.Value.Settings  ), EntityType.Setting  );
                            AllSources.AddSection(TotalSources             , nameof(original.Value.Sources   )                      );
                            AllSources.contents.AppendLine("</div></div><br/>");
                        }
                    }
                    await sb.SaveHTML($"{nameof(Domain)}/{domain}");
                }
            }));
        }
        return tasks.ToArray();
    }
    public static void CreateCharacterPages()
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
    }
    #endregion
}