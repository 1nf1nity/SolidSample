namespace ArdalisRating;

public class RaterFactory : IRaterFactory
{
    private readonly ILogger _logger;

    public RaterFactory(ILogger logger)
    {
        _logger = logger;
    }

    public Rater Create(Policy policy)
    {
        try
        {
            return (Rater) Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater")!,
                _logger)!;
        }
        catch
        {
            return new UnknownPolicyRater(_logger);
        }
    }
}