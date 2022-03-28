namespace ArdalisRating;

public abstract class Rater
{
    protected readonly IRatingContext Context;
    protected readonly ConsoleLogger Logger;

    protected Rater(IRatingContext context)
    {
        Context = context;
        Logger = context.Logger;
    }

    public abstract void Rate(Policy policy);
}