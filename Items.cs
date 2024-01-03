public partial class Factory : IDisposable
{
    internal static class ItemEnum
    {
        private static Item CreateItem(params string[] names)
        {
            var retval = new Item();
            retval.Names.UnionWith(names);
            return retval;
        }
    }
}