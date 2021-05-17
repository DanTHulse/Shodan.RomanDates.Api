namespace Shodan.RomanDates.Common.Helpers
{
    public static class MathHelpers
    {
        public static int Modulo(int a, int n)
            => (a % n + n) % n;
    }
}
