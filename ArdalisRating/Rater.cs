namespace ArdalisRating;

public abstract class Rater
{
    protected readonly IRatingContext Context;
    public ILogger Logger { get; set; } = new ConsoleLogger();

    protected Rater(IRatingContext context)
    {
        Context = context;
    }

    public abstract void Rate(Policy policy);
}