using Otus.Reflection.Interfaces;

namespace Otus.Reflection.Services;
public class CsvFileService: ICsvFileService
{
    /// <summary>
    /// чтение данных из csv файла
    /// </summary>
    /// <returns></returns>
    public async Task<List<string>> ReadTextFromCSVAsync()
    {
        string path = @"C:\\Users\\evgeniy.volobuev\\Desktop\\test.csv";
        using StreamReader reader = new StreamReader(path);
        List<string> jsonList = new();
        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
            jsonList.Add(GetJsonByLine(line));
        return jsonList;
    }
    /// <summary>
    /// из строки csv файла получаем json
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    string GetJsonByLine(string line)
    {
        string lastName = line.Substring(0, line.IndexOf(';'));
        int indexStartFirsName = line.IndexOf(';') + 1;
        int indexEndFirstName = line.LastIndexOf(';') - indexStartFirsName;
        string firstName = line.Substring(indexStartFirsName, indexEndFirstName);
        int indexStartSecondName = line.LastIndexOf(';') + 1;
        int indexEndSecondName = line.Length - line.LastIndexOf(';') - 1;
        string secondName = line.Substring(indexStartSecondName, indexEndSecondName);

        return string.Concat("{", "\"", "lastName", "\"", ":", "\"", lastName, "\",",
            "\"", "firstName", "\"", ":", "\"", firstName, "\",",
            "\"", "secondName", "\"", ":", "\"", secondName, "\"",
            "}");
    }
}

