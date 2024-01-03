public partial class Factory : IDisposable
{
    internal static class GroupEnum
    {
        private static Group CreateGroup(params string[] names) => new Group(names);
    }
}