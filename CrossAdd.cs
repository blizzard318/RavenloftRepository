using System.Collections.Generic;

internal static class Cross
{
    private static T Add<T,U>(this T entity, params U[] array) where T : UseVariableName where U : UseName
    {
        var list = GetSetFromArray(array);
        foreach (var set in list) set.Add(entity);

        var otherlist = GetSetFromEntity(entity);
        foreach (var instance in array) otherlist.Add(instance);

        return entity;

        static IEnumerable<HashSet<T>>? GetSetFromArray(U[] array)
        {
            var type = typeof(T);
            if (type == typeof(Location)) return ((IHasLocations[])array).Select(t => t.Locations) as IEnumerable<HashSet<T>>;
            if (type == typeof(Domain  )) return ((IHasDomains  [])array).Select(t => t.Domains  ) as IEnumerable<HashSet<T>>;
            if (type == typeof(NPC     )) return ((IHasNPCs     [])array).Select(t => t.NPCs     ) as IEnumerable<HashSet<T>>;
            if (type == typeof(Item    )) return ((IHasItems    [])array).Select(t => t.Items    ) as IEnumerable<HashSet<T>>;
            if (type == typeof(Group   )) return ((IHasGroups   [])array).Select(t => t.Groups   ) as IEnumerable<HashSet<T>>;
            throw new NotImplementedException();
        }
        static HashSet<U>? GetSetFromEntity (T entity) 
        {
            var type = typeof(U);
            if (type == typeof(Trait   )) return                 entity .Traits    as HashSet<U>;
            if (type == typeof(Location)) return ((IHasLocations)entity).Locations as HashSet<U>;
            if (type == typeof(Domain  )) return ((IHasDomains  )entity).Domains   as HashSet<U>;
            if (type == typeof(NPC     )) return ((IHasNPCs     )entity).NPCs      as HashSet<U>;
            if (type == typeof(Item    )) return ((IHasItems    )entity).Items     as HashSet<U>;
            if (type == typeof(Group   )) return ((IHasGroups   )entity).Groups    as HashSet<U>;
            throw new NotImplementedException();
        }
    }
    public static T    AddTraits   <T>(this T entity, params Trait   [] array) where T : UseVariableName                => entity.Add(array);
    public static void AddLocations<T>(this T entity, params Location[] array) where T : UseVariableName, IHasLocations => entity.Add(array);
    public static void AddDomains  <T>(this T entity, params Domain  [] array) where T : UseVariableName, IHasDomains   => entity.Add(array);
    public static void AddNPCs     <T>(this T entity, params NPC     [] array) where T : UseVariableName, IHasNPCs      => entity.Add(array);
    public static void AddItems    <T>(this T entity, params Item    [] array) where T : UseVariableName, IHasItems     => entity.Add(array);
    public static void AddGroups   <T>(this T entity, params Group   [] array) where T : UseVariableName, IHasGroups    => entity.Add(array);
    public static T    AddInfo     <T>(this T entity, string info) where T : UseName
    {
        entity.ExtraInfo += info;
        return entity;
    }
}
