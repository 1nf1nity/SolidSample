namespace ArdalisRating;

public abstract class Rater
{
    protected readonly IRatingUpdater RatingUpdater;
    public ILogger Logger { get; set; } = new ConsoleLogger();

    protected Rater(IRatingUpdater ratingUpdater)
    {
        RatingUpdater = ratingUpdater;
    }

    public abstract void Rate(Policy policy);
}