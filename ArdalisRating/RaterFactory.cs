namespace ArdalisRating;

internal class RaterFactory
{
    public Rater Create(Policy policy, IRatingContext context)
    {
        try
        {
            return (Rater) Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater")!,
                context)!;
        }
        catch
        {
            return new UnknownPolicyRater(context);
        }
    }
}