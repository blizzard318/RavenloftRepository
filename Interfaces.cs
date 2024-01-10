using static Factory;
public interface IHasAppearances<T> where T : UseVariableName { Dictionary<Source, TrackPage<T>> Appearances { get; init; } }
public interface IHasAlignment { Dictionary<Source, Alignment> AlignmentPerSource { get; init; } }