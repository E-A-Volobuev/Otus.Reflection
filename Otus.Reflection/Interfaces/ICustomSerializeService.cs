using Otus.Reflection.Models;

namespace Otus.Reflection.Interfaces;

public interface ICustomSerializeService
{
    void PrintWithoutReflectionOrSerialize();
    void PrintWithReflection(Type myType, ExampleTestClass testClass);
}

