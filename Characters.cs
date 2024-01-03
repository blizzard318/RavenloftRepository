public partial class Factory : IDisposable
{
    internal static class CharacterEnum
    {
        private static NPC CreateCharacter(params string[] names)
        {
            var retval = new NPC();
            retval.Names.UnionWith(names);
            return retval;
        }
        public readonly static NPC Clarke = CreateCharacter("Clarke");
        public readonly static NPC Phillips = CreateCharacter("Phillips");
        public readonly static NPC DoctorAugustus = CreateCharacter("Doctor Augustus");
        public readonly static NPC NurseRoberts = CreateCharacter("Nurse Roberts");
        public readonly static NPC HowardAshton = CreateCharacter("Howard Ashton");
    }
}