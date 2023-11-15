using Newtonsoft.Json;
using Otus.Reflection.Interfaces;
using Otus.Reflection.Models;

namespace Otus.Reflection.Services;
/// <summary>
/// сериализация и десериализация с помощью библиотеки Newtonsoft
/// </summary>
public class SerializeByNewtonsoftJsonService: ISerializeByNewtonsoftJsonService
{
    /// <summary>
    /// сериализуем класс
    /// </summary>
    /// <param name="testClass"></param>
    public void SerializeObj(ExampleTestClass testClass)
    {
        int j = 0;
        while (j < 10000)
        {
            Console.WriteLine("Вывод строки с сериализацией");
            string result = JsonConvert.SerializeObject(testClass);
            Console.WriteLine(result);
            j++;
        }
    }
    /// <summary>
    /// десиреализуем список json, который считали в csv файле
    /// </summary>
    /// <param name="jsonList"></param>
    /// <returns></returns>
    public List<ObjectForDeserialize> GetListDeserializesObjects(List<string> jsonList)
    {
        List<ObjectForDeserialize> listObjects = new();
        jsonList.ForEach(x => listObjects.Add(JsonConvert.DeserializeObject<ObjectForDeserialize>(x)));
        return listObjects;
    }
}

