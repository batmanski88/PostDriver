namespace PostDriver.Domain.Infrastructure
{
    public static class Helpers
    {
        public static bool Empty(this string value)
            => string.IsNullOrWhiteSpace(value);
    }
}