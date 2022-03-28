namespace ArdalisRating;

public abstract class Rater
{
    public ILogger Logger { get; set; }

    protected Rater(ILogger logger)
    {
        Logger = logger;
    }

    public abstract decimal Rate(Policy policy);
}