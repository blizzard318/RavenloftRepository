namespace Ravenloft
{
    public interface HasOne<T>
    {
        public T Value { get; set; }
    }
    public interface HasMany<T>
    {
        public List<T> Values { get; set; }
    }
    internal static class Cross
    {
        public static void Add<T1, T2>(T1 t1, T2 t2)
        {
            _Add(t1, t2);
            _Add(t2, t1);
            static void _Add<iT1,iT2>(iT1 Adder, iT2 ToAdd)
            {
                if (Adder is HasOne<iT2>)
                {
                    ((HasOne<iT2>)Adder).Value = ToAdd;
                }
                else if (Adder is HasMany<iT2>)
                {
                    ((HasMany<iT2>)Adder).Values.Add(ToAdd);
                }
            }
        }
    }
}
