interface IHasEntity<T> {  T Entity { get; set; } }
interface IHasAppearances<T> { Dictionary<Source, InSource<T>> Appearances { get; set; }  }