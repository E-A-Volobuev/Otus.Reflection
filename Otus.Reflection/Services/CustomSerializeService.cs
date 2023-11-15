using System.Reflection;
using Otus.Reflection.Interfaces;
using Otus.Reflection.Models;

namespace Otus.Reflection.Services;

/// <summary>
/// кастомная сериализация
/// </summary>
public class CustomSerializeService: ICustomSerializeService
{
    public void PrintWithoutReflectionOrSerialize()
    {
        int i = 0;
        while (i < 10000)
        {
            Console.WriteLine("Вывод строки без рефлексии и сериализации");
            i++;
        }
    }
    public void PrintWithReflection(Type myType, ExampleTestClass testClass)
    {
        int j = 0;
        while (j < 10000)
        {
            Console.WriteLine("Вывод строки с рефлексией и сериализацией");
            Console.WriteLine("Properties:");
            Console.WriteLine(GetFieldsOrPropertiesToString(myType.GetProperties(), testClass));
            Console.WriteLine("Fields:");
            Console.WriteLine(GetFieldsOrPropertiesToString(myType.GetFields(), testClass));
            j++;
        }
    }
    /// <summary>
    /// сериализуем в строку либо свойства класса, либо его поля
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    /// <param name="testClass"></param>
    /// <returns></returns>
    string GetFieldsOrPropertiesToString<T>(T[] arr, ExampleTestClass testClass)
    {
        string result = string.Empty;
        if (arr.Length > 0)
        {
            if (arr is FieldInfo[] infoField)
            {
                foreach (var field in infoField)
                    result += ConcatTextHelper(field.Name, field.GetValue(testClass));
            }
            if (arr is PropertyInfo[] infoProp)
            {
                foreach (var prop in infoProp)
                    result += ConcatTextHelper(prop.Name, prop.GetValue(testClass));
            }

            return CreateTextHelper(result);
        }
        return result;
    }

    string ConcatTextHelper(string name, object val)
    {
        return string.Concat("\"", name, "\"", ":", val, ",");
    }
    string CreateTextHelper(string text)
    {
        if (text.EndsWith(","))
            text = text.Substring(0, text.Length - 1);

        return string.Concat("{", text, "}");
    }
}

