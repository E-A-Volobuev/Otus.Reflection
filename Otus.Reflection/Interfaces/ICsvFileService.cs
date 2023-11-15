namespace Otus.Reflection.Interfaces;

public interface ICsvFileService
{
    /// <summary>
    /// чтение данных из csv файла
    /// </summary>
    /// <returns></returns>
    Task<List<string>> ReadTextFromCSVAsync();
}

