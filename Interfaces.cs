using static Factory;
public interface IHasAppearances<T> { Dictionary<Source, TrackPage<T>> Appearances { get; init; } }
public interface IHasAlignment { Dictionary<Source, Alignment> AlignmentPerSource { get; init; } }