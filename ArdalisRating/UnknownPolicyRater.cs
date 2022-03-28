namespace ArdalisRating;

internal class UnknownPolicyRater : Rater
{
    public UnknownPolicyRater(IRatingContext context) : base(context)
    {
    }

    public override void Rate(Policy policy)
    {
        Context.Log("Unknown policy type");
    }
}