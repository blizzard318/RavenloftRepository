namespace Ravenloft
{
    internal static class Cross
    {
        //Canon
        //Cluster
        //Domain
        //Mistway
        //Edition
        //Source
        //IRLPerson
        //Location
        //Item
        //ItemTrait
        //Group
        //NPC
        //Creature
        //CreatureTrait
        static void Add<T1, T2>(T1 t1, T2 t2)
        {
            Add(t1, t2, false);

            void Add<T1, T2>(T1 t1, T2 t2, bool looped)
            {
                Type type1 = typeof(T1);
                Type type2 = typeof(T2);
                if (type1 is Canon)
                {
                    var canon = t1 as Canon;
                    if (type2 is HasCanon)
                    {
                        var cluster = t2 as HasCanon;
                        cluster.Canon = canon;
                    }
                }
                else if (type1 is Cluster)
                {

                }
                else if (looped) return;
                else Add(t2, t1, true);
            }
        }
    }
}
