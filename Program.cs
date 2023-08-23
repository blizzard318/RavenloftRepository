using Microsoft.EntityFrameworkCore;
using System.Text;

string URL(string input) => string.Concat(input.Where(c => c != ':' && !char.IsWhiteSpace(c)));

//AddToDatabase.Add();
var db = Factory.db;

var Sources = db.Sources.Include(s => s.Traits).ToArray();
var DomainAppearances   = db.domainAppearances  .Include(a => a.Entity.Traits).ToHashSet();
var LocationAppearances = db.locationAppearances.Include(a => a.Entity.Domains).Include(a => a.Entity.Traits).ToHashSet();
var NPCAppearances      = db.npcAppearances     .Include(a => a.Entity.Domains).Include(a => a.Entity.Traits).ToHashSet();
NPCAppearances.RemoveWhere(a => a.Entity.Traits.Contains(Traits.NoLink));
var ItemAppearances     = db.itemAppearances    .Include(a => a.Entity.Domains).Include(a => a.Entity.Traits).ToHashSet();

foreach (var source in Sources)
{
    var sb = new StringBuilder();
    sb.Append("<!DOCTYPE html>");
    sb.Append("<html>");
    sb.Append("<head>");
    sb.Append("<meta charset='utf-8'>");
    sb.Append("<title>Ravenloft Repository</title>");
    sb.Append("<meta name='theme-color' content=''black'>");
    sb.Append("<meta name='viewport' content=''width=1050px, initial-scale=1''>");
    sb.Append("<meta name='description' content=''Ravenloft Repository'>");
    sb.Append("<link rel='shortcut icon'' href='favicon.ico''>");
    sb.Append("</head>");
    sb.Append("<body>");

    sb.Append($"<h1>{source.Key}");
    sb.Append(" (").Append(source.Traits.Single(t => t.Type == nameof(Traits.Edition)).Key).Append(")");
    var canon = source.Traits.Find(t => t.Type == nameof(Traits.Canon));
    if (canon != null)
        sb.Append(" [").Append(canon.Key).Append("]");
    sb.Append("</h1>");

    sb.Append("<b>Media Type</b>: ").Append(source.Traits.Single(t => t.Type == nameof(Traits.Media)).Key);
    sb.Append("<br/><u>Extra Information</u>:").Append(source.ExtraInfo);

    sb.Append("<br/><br/><b>Domains</b>:");

    var domains   = DomainAppearances  .Where(a => a.Source == source).ToArray();
    var locations = LocationAppearances.Where(a => a.Source == source).ToHashSet();
    var npcs      = NPCAppearances     .Where(a => a.Source == source).ToHashSet();
    var items     = ItemAppearances    .Where(a => a.Source == source).ToHashSet();

    foreach (var domain in domains)
    {
        DomainAppearances.Remove(domain);

        sb.Append("<br/>&emsp;<b><a href='").Append("").Append("'>").Append(domain.Entity.Name).Append("</a></b>");
        sb.Append(" (").Append(domain.PageNumbers).Append(")");
        sb.Append("<br/>&emsp;&emsp;<b>Settlements</b>: ");

        var locations_in_domain = locations.Where(a => a.Entity.Domains.Contains(domain.Entity)).ToHashSet();
        if (locations_in_domain.Count() > 0)
        {
            var settlements = locations_in_domain.Where(a => a.Entity.Traits.Contains(Traits.Location.Settlement)).ToArray();
            foreach (var settlement in settlements)
            {
                locations.Remove(settlement);
                locations_in_domain.Remove(settlement);

                var trait = settlement.Entity.Traits.Single(t => t.Type.Contains(nameof(Traits.Settlement)));
                sb.Append("<br/>&emsp;&emsp;&emsp;<u><a href='").Append("").Append("'>").Append(settlement.Entity.Name).Append("</a></u>");
                sb.Append(" (").Append(settlement.PageNumbers).Append("):");
                sb.Append("<br/>&emsp;&emsp;&emsp;&emsp;");

                var residences = locations_in_domain.Where(a => a.Entity.Traits.Contains(trait)).ToArray();
                foreach (var residence in residences)
                {
                    locations.Remove(residence);
                    locations_in_domain.Remove(residence);
                    sb.Append("<a href='").Append("").Append("'>").Append(residence.Entity.Name).Append("</a>");
                    sb.Append(" (").Append(residence.PageNumbers).Append("), ");
                }
                sb.Remove(sb.Length - 2, 2);
            }
            if (locations_in_domain.Count() > 0)
            {
                sb.Append("<br/>&emsp;&emsp;<b>Other Locations</b>:");
                sb.Append("<br/>&emsp;&emsp;&emsp;");
                foreach (var residence in locations_in_domain)
                {
                    locations.Remove(residence);
                    locations_in_domain.Remove(residence);
                    sb.Append("<a href='").Append("").Append("'>").Append(residence.Entity.Name).Append("</a>");
                    sb.Append(" (").Append(residence.PageNumbers).Append("), ");
                }
                sb.Remove(sb.Length - 2, 2);
            }
        }

        var npcs_in_domain = npcs.Where(a => a.Entity.Domains.Contains(domain.Entity)).ToArray();
        if (npcs_in_domain.Length > 0)
        {
            sb.Append("<br/>&emsp;&emsp;<b>Characters</b>: ");
            sb.Append("<br/>&emsp;&emsp;&emsp;");
            foreach (var npc in npcs_in_domain)
            {
                npcs.Remove(npc);
                NPCAppearances.Remove(npc);
                sb.Append("<a href='").Append("").Append("'>").Append(npc.Entity.Name).Append("</a>");
                sb.Append(" (").Append(npc.PageNumbers).Append("), ");
            }
            sb.Remove(sb.Length - 2, 2);
        }

        var items_in_domain = items.Where(a => a.Entity.Domains.Contains(domain.Entity)).ToArray();
        if (items_in_domain.Length > 0)
        {
            sb.Append("<br/>&emsp;&emsp;<b>Items</b>: ");
            sb.Append("<br/>&emsp;&emsp;&emsp;");
            foreach (var item in items_in_domain)
            {
                items.Remove(item);
                ItemAppearances.Remove(item);
                sb.Append("<a href='").Append("").Append("'>").Append(item.Entity.Name).Append("</a>");
                sb.Append(" (").Append(item.PageNumbers).Append("), ");
            }
            sb.Remove(sb.Length - 2, 2);
        }

        var languages = domain.Entity.Traits.Where(t => t.Type.Contains(nameof(Traits.Language)));
        if (languages.Count() > 0)
        {
            sb.Append("<br/>&emsp;&emsp;<b>Languages</b>: ");
            sb.Append("<br/>&emsp;&emsp;&emsp;");
            foreach (var language in languages)
                sb.Append("<a href='").Append("").Append("'>").Append(language.Key).Append("</a>, ");
            sb.Remove(sb.Length - 2, 2);
        }

        var creatures = domain.Entity.Traits.Where(t => t.Type.Contains(nameof(Traits.Creature)));
        if (creatures.Count() > 0)
        {
            sb.Append("<br/>&emsp;&emsp;<b>Creatures</b>: ");
            sb.Append("<br/>&emsp;&emsp;&emsp;");
            foreach (var creature in creatures)
                sb.Append("<a href='").Append("").Append("'>").Append(creature.Key).Append("</a>, ");
            sb.Remove(sb.Length - 2, 2);
        }
    }

    sb.Append("<script type='module'>");
    sb.Append("import mermaid from 'https://cdn.jsdelivr.net/npm/mermaid@10/dist/mermaid.esm.min.mjs';");
    sb.Append("mermaid.initialize({ startOnLoad: true });");
    sb.Append("</script>");

    sb.Append("</body>");
    sb.Append("</html>");

    string filepath = Path.Join(Directory.GetCurrentDirectory(), $"{URL(source.Key)}.html");
    File.WriteAllTextAsync(filepath, sb.ToString());
}