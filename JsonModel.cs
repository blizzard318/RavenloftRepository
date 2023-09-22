internal class JsonObject
{
    public string Name { get; set; }
}
internal class JsonLanguage : JsonObject
{
    public string Domains { get; set; }
}
internal class JsonGroup : JsonObject
{
    public string Domains { get; set; }
    public bool[] Editions { get; set; }
}
internal class JsonCreature: JsonObject
{
    public string Domains { get; set; }
    public string Groups { get; set; } //Groups they belong/associated with
}
internal class JsonSource : JsonObject
{
    public string Edition { get; set; }
    public string MediaType { get; set; }
    public string ReleaseDate { get; set; }
}
internal class JsonDomain : JsonObject
{
    public string Darklords { get; set; }
    public string Clusters { get; set; }
    public bool[] Editions { get; set; } //Seperated by the editions.csv
}
internal class JsonCharacter : JsonObject
{
    public string Domains { get; set; }
    public string Types { get; set; } //Vistani, Darklord, Raunie
    public bool[] Editions { get; set; }
}
internal class JsonLocation : JsonObject
{
    public string Domains { get; set; }
    public string Types { get; set; } //Lair,Settlement,Mistway,<null>
    public bool[] Editions { get; set; }
}
internal class JsonItem : JsonObject
{
    public string Domains { get; set; }
    public string Groups { get; set; } //Groups they belong/associated with
    public bool[] Editions { get; set; }
}