namespace Ravenloft
{
    public interface HasOne<T>
    {
        T Value { get; set; }
    }
    public interface HasMany<T>
    {
        List<T> Values { get; set; }
    }

    internal static class Cross
    {
        public static void Add<T1, T2>(T1 t1, T2 t2)
        {
            _Add(t1, t2);
            _Add(t2, t1);
            static void _Add<iT1,iT2>(iT1 Adder, iT2 ToAdd)
            {
                Type type = typeof(iT1);
                if (type is HasOne<iT2>)
                {
                    var adder = Adder as HasOne<iT2>;
                    adder.Value = ToAdd;
                }
                else if (type is HasMany<iT2>)
                {
                    var adder = Adder as HasMany<iT2>;
                    if (adder.Values == null)
                        adder.Values = new List<iT2>();
                    adder.Values.Add(ToAdd);
                }
            }
        }
    }
}
