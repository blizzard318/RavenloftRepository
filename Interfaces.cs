interface IHasEntity<T> {  T Entity { get; set; } }
interface IHasAppearances<T> { Dictionary<Source, TrackPage<T>> Appearances { get; init; } }