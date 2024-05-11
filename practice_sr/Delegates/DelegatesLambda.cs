namespace practice_sr.Delegates;

public static class DelegatesLambda
{
    public static void ActionDelegateTest()
    {
        Action line = () => Console.WriteLine("Action delegate execution");
        line();

        Func<int, int> cube = (int x) => x * x * x;
        Console.WriteLine(cube(2));

        Func<int, int, bool> testForEquality = (x, y) => x == y;
        Console.WriteLine(testForEquality(1 , 2));

        Func<int, string, bool> isToLong = (int i, string s) => s.Length > i;
        Console.WriteLine(isToLong(5, "Miguel Vargas"));
    }
}