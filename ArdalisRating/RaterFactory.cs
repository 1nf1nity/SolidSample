namespace ArdalisRating;

internal class RaterFactory
{
    public Rater? Create(Policy policy, RatingEngine engine)
    {
        try
        {
            return (Rater) Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater")!,
                engine, engine.Logger)!;
        }
        catch
        {
            return null;
        }
    }
}