using Microsoft.Extensions.Hosting;
using Otus.Reflection.Interfaces;
using Otus.Reflection.Models;
using System.Diagnostics;


namespace Otus.Reflection;

public class StartApp : BackgroundService
{
    private readonly ICsvFileService _csvService;
    private readonly ICustomSerializeService _customService;
    private readonly ISerializeByNewtonsoftJsonService _newtonService;

    public StartApp(ICsvFileService csvService, ICustomSerializeService customService,
                    ISerializeByNewtonsoftJsonService newtonService)
    {
        _csvService = csvService ?? throw new ArgumentNullException(nameof(csvService));
        _customService = customService ?? throw new ArgumentNullException(nameof(customService));
        _newtonService = newtonService ?? throw new ArgumentNullException(nameof(newtonService));
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        ExampleTestClass testClass = ExampleTestClass.Get();
        Type myType = testClass.GetType();
      
        //PrintTimeByCustomSerialize(testClass,myType); // пункты д.з. 1-6
        //PrintTimeBySerializeOtherSoft(testClass); // пункты д.з. 6-8 
        await GetDesirializeTimeWithNewtonsoftJsonAsync(testClass); // пункты д.з. 9-11
    }
    // Пункты дз 1-6:
    // Написать сериализацию свойств или полей класса в строку
    // Проверить на классе: ExampleTest
    // Замерить время до и после вызова функции (для большей точности можно сериализацию сделать в цикле 100-100000 раз)
    // Вывести в консоль полученную строку и разницу времен
    void PrintTimeByCustomSerialize(ExampleTestClass testClass, Type myType)
    {
        int timeWithoutSerialize = GetTimeWithoutSerialize();
        int timeWithCustomSerialize = GetTimeByCustomSerialize(myType, testClass);
        PrintResult(timeWithoutSerialize, timeWithCustomSerialize);
        Console.ReadLine();
    }
    // Пункты дз 7-8:
    // Провести сериализацию с помощью каких-нибудь стандартных механизмов (например в JSON)
    // И тоже посчитать время и прислать результат сравнения
    void PrintTimeBySerializeOtherSoft(ExampleTestClass testClass)
    {
        int timeWithoutSerialize = GetTimeWithoutSerialize();
        int timeWithNewtonsoftJson = GetTimeWithoutNewtonsoftJson(testClass);
        PrintResult(timeWithoutSerialize, timeWithNewtonsoftJson);
        Console.ReadLine();
    }

    void PrintResult(int timeWithoutSerialize, int timeWithCustomSerialize)
    {
        string resultReport = string.Concat("Без сериализации: ", timeWithoutSerialize,
            " C сериализацией:", timeWithCustomSerialize);
        Console.WriteLine(resultReport);
        int timeDifference = timeWithCustomSerialize - timeWithoutSerialize;
        Console.WriteLine(string.Concat("Разница по времени составляет: ", timeDifference));
    }
    // замер времени вывода текста в консоль без сериализации
    int GetTimeWithoutSerialize()
    {
        Stopwatch watch = new();
        watch.Start();
        _customService.PrintWithoutReflectionOrSerialize();
        watch.Stop();
        return watch.Elapsed.Milliseconds;
    }
    // замер времени вывода текста в консоль c кастомной сериализацией
    int GetTimeByCustomSerialize(Type myType, ExampleTestClass testClass)
    {
        Stopwatch watch = new();
        watch.Start();
        _customService.PrintWithReflection(myType, testClass);
        watch.Stop();
        return watch.Elapsed.Milliseconds;
    }
    // замер времени вывода текста в консоль c сериализацией NewtonsoftJson
    int GetTimeWithoutNewtonsoftJson(ExampleTestClass testClass)
    {
        Stopwatch watch = new();
        watch.Start();
        _newtonService.SerializeObj(testClass);
        watch.Stop();
        return watch.Elapsed.Milliseconds;
    }

    // замер времени десериализации с NewtonsoftJson, при чтении из csv файла
    async Task GetDesirializeTimeWithNewtonsoftJsonAsync(ExampleTestClass testClass)
    {
        Stopwatch watch = new();
        watch.Start();
        var jsonList = await _csvService.ReadTextFromCSVAsync();
        var objList = _newtonService.GetListDeserializesObjects(jsonList);
        watch.Stop();
        Console.WriteLine(string.Concat("Десериализация заняла: ", watch.Elapsed.Milliseconds," мс"));
    }
}

