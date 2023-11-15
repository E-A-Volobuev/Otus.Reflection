namespace Otus.Reflection.Models;

/// <summary>
/// класс , в который выполняем десереализацию из файла csv
/// </summary>
public sealed class ObjectForDeserialize
{
    public string LastName { get; set; }
    public string SecondName { get; set; }
    public string FirstName { get; set; }
}

