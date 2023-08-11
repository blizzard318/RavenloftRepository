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
        public static void Add<T1, T2>(T1 Primary, params T2[] Secondary) //Borca(domain), Ivana,Ivan(darklord)
        {
            if (Secondary.Length == 1 && Primary is HasOne<T2>)
            {
                ((HasOne<T2>)Primary).Value = Secondary[0];
            }
            else if (Primary is HasMany<T2>)
            {
                ((HasMany<T2>)Primary).Values.AddRange(Secondary);
            }

            if (Secondary[0] is HasOne<T1>)
            {
                foreach (HasOne<T1> adder in Secondary) adder.Value = Primary;
            }
            else if (Secondary[0] is HasMany<T1>)
            {
                foreach (HasMany<T1> adder in Secondary) adder.Values.Add(Primary);
            }
        }
    }
}
