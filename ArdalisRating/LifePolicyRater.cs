namespace ArdalisRating;

internal class LifePolicyRater : Rater
{
    public LifePolicyRater(IRatingContext context) : base(context)
    {
    }

    public override void Rate(Policy policy)
    {
        Context.Log("Rating LIFE policy...");
        Context.Log("Validating policy.");

        if (policy.DateOfBirth == DateTime.MinValue)
        {
            Context.Log("Life policy must include Date of Birth.");
            return;
        }

        if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
        {
            Context.Log("Centenarians are not eligible for coverage.");
            return;
        }

        if (policy.Amount == 0)
        {
            Context.Log("Life policy must include an Amount.");
            return;
        }

        int age = DateTime.Today.Year - policy.DateOfBirth.Year;
        if (policy.DateOfBirth.Month == DateTime.Today.Month &&
            DateTime.Today.Day < policy.DateOfBirth.Day ||
            DateTime.Today.Month < policy.DateOfBirth.Month)
        {
            age--;
        }

        decimal baseRate = policy.Amount * age / 200;
        if (policy.IsSmoker)
        {
            Context.UpdateRating(baseRate * 2);
            return;
        }

        Context.UpdateRating(baseRate);
    }
}