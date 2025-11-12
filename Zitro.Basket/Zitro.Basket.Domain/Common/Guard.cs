namespace Zitro.Basket.Domain;

public static class Guard
{
    public static void AgainstNonNegative(int value, string name)
    {
        if (value <= 0) throw new ArgumentOutOfRangeException(name, $"{name} must be greater than 0");
    }

}
