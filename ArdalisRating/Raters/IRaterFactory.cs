using ArdalisRating.Models;

namespace ArdalisRating.Raters;

public interface IRaterFactory
{
    Rater Create(Policy policy);
}