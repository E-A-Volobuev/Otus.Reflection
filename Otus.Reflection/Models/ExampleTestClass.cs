namespace Otus.Reflection.Models;

/// <summary>
/// пример класса для сериализации (был указан в домашнем задании)
/// </summary>
public class ExampleTestClass
{
    public int i1, i2, i3, i4, i5;
    public static ExampleTestClass Get() => new() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
}

