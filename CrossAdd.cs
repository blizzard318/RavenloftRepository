namespace Ravenloft
{
    public interface HasMany<T>
    {
        public List<T> Values { get; set; }
    }
    internal static class Cross
    {
        public static void Add<T1, T2>(T1 Primary, params T2[] Secondary) //Borca(domain), Ivana,Ivan(darklord)
        {
            var primary = Primary as HasMany<T2>;
            if (primary != null)
            {
                if (primary.Values == null) primary.Values = new();
                primary.Values.AddRange(Secondary);
            }

            if (Secondary is HasMany<T1>[])
            {
                foreach (HasMany<T1> adder in Secondary) adder.Values.Add(Primary);
            }
        }
        
        public static void Add<T1, T2>(T1[] Primary, T2[] Secondary) //Ivana,Ivan(darklord), {NPCs...}
        {
            if (Primary is HasMany<T2>[])
            {
                foreach (HasMany<T2> adder in Primary) 
                    foreach(var ToAdd in Secondary)
                        adder.Values.Add(ToAdd);
            }

            if (Secondary is HasMany<T1>[])
            {
                foreach (HasMany<T1> adder in Secondary) 
                    foreach (var ToAdd in Primary)
                        adder.Values.Add(ToAdd);
            }
        }
    }
}
