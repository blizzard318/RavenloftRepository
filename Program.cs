using System.Text;

using var db = new RavenloftContext();
AddToDatabase.Add(db);

foreach (var source in db.Sources)
{
    var sb = new StringBuilder();
    sb.AppendLine("<!DOCTYPE html>");
    sb.AppendLine("<html>");
    sb.AppendLine("<head>");
        sb.AppendLine("<meta charset='utf-8'>");
        sb.AppendLine("<title>Ravenloft Repository</title>");
        sb.AppendLine("<meta name='theme-color' content=''black'>");
        sb.AppendLine("<meta name='viewport' content=''width=1050px, initial-scale=1''>");
        sb.AppendLine("<meta name='description' content=''Ravenloft Repository'>");
        sb.AppendLine("<link rel='shortcut icon'' href='favicon.ico''>");
    sb.AppendLine("</head>");
    sb.AppendLine("<body>");
        sb.AppendLine("<details>");
        sb.AppendLine($"<summary><b>{source.Name}</b></summary>");
        sb.Append("Domains: ");
        foreach (var domain in source.Domains) sb.Append("From Source:" + domain.Name);
        foreach (var domain in db.Domains) sb.Append("From db: " + domain.Name);
    sb.AppendLine("</details>");
    sb.AppendLine("</body>");
    sb.AppendLine("</html>");

    string filepath = Path.Join(Directory.GetCurrentDirectory(), $"{source.URL}.html");
    File.WriteAllText(filepath, sb.ToString());
    Console.WriteLine(source.Name);
}

/*var dom = db.Domains.Find("Barovia");
Console.WriteLine(dom != null);*/