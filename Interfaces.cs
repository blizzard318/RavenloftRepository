interface IHasEntity<T> {  T Entity { get; set; } }
interface IHasEntities<T> { Dictionary<string, List<T>> Domains { get; set; } };