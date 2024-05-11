namespace practice_sr;

public static class DelegatesTest
{
    private delegate void MathCalculation(float value1, float value2);

    private static void AddNumbers(float value1, float value2)
    {
        Console.WriteLine($"{value1 + value2} ");
    }

    private static void SubtractNumbers(float value1, float value2)
    {
        Console.WriteLine($"{value1 - value2} ");
    }

    private static void MultiplyNumbers(float value1, float value2)
    {
        Console.WriteLine($"{value1 * value2} ");
    }

    private static void DivideNumbers(float value1, float value2)
    {
        Console.WriteLine($"{value1 / value2} ");
    }

    public static void ExecuteDelegate()
    {
        MathCalculation calculations = AddNumbers;
        calculations += SubtractNumbers;
        calculations += MultiplyNumbers;
        calculations += DivideNumbers;

        calculations(4, 2);
        Console.Read();
    }
}