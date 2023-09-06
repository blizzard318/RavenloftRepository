internal class JsonObject
{
    public string Name { get; set; }
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
    public int[] Editions { get; set; } //Seperated by the editions.csv
}
internal class JsonCharacter : JsonObject
{

}
internal class JsonLocation : JsonObject
{

}
internal class JsonItem : JsonObject
{
    public string Domains { get; set; }
    public int[] Editions { get; set; }
}