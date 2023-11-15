using Otus.Reflection.Models;

namespace Otus.Reflection.Interfaces;

public interface ISerializeByNewtonsoftJsonService
{
    /// <summary>
    /// сериализуем класс
    /// </summary>
    /// <param name="testClass"></param>
    void SerializeObj(ExampleTestClass testClass);

    /// <summary>
    /// десиреализуем список json, который считали в csv файле
    /// </summary>
    /// <param name="jsonList"></param>
    /// <returns></returns>
    List<ObjectForDeserialize> GetListDeserializesObjects(List<string> jsonList);
}

