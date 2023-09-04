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
    //public string Clusters { get; set; }
    public string Editions { get; set; }
    public int Sources { get; set; }
}
internal class JsonLocation : JsonObject
{

}
internal class JsonItem : JsonObject
{

}
internal class JsonCharacter : JsonObject
{

}