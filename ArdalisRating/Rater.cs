namespace ArdalisRating;

internal abstract class Rater
{
    protected readonly RatingEngine Engine;
    protected readonly ConsoleLogger Logger;

    protected Rater(RatingEngine engine, ConsoleLogger logger)
    {
        Engine = engine;
        Logger = logger;
    }

    public abstract void Rate(Policy policy);
}