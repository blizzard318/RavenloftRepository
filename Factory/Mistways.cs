public partial class Factory : IDisposable
{
    internal static class MistwayEnum
    {
        private static Location CreateMistway(params string[] names)
        {
            var retval = new Location();
            retval.Names.UnionWith(names);
            return retval;
        }
    }
}
