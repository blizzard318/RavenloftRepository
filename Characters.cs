public partial class Factory : IDisposable
{
    internal static class CharacterEnum
    {
        private static NPC CreateCharacter(params string[] names) => new NPC(names);
    }
}