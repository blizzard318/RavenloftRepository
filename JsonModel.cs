internal class JsonEdition
{
    public string Name { get; set; }
    public string ExtraInfo { get; set; }
    public List<Source> Sources { get; set; }

    public class Source
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string MediaType { get; set; }
    }
}

internal class JsonMedia
{
    public string Name { get; set; }
    public string ExtraInfo { get; set; }
    public List<Source> Sources { get; set; }

    public class Source
    {
        public string Name { get; set; }
        public string Edition { get; set; }
        public string ReleaseDate { get; set; }
    }
}
internal class JsonCluster
{
    public string Name { get; set; }
    public List<string> Domains { get; set; }
}
internal class JsonSource
{
    public string Name { get; set; }
    public string Edition { get; set; }
    public string ReleaseDate { get; set; }
    public string MediaType { get; set; }
}