public partial class Factory : IDisposable
{
    internal static class LocationEnum
    {
        private static Location CreateLocation(params string[] names) => new Location(names);
    }
}