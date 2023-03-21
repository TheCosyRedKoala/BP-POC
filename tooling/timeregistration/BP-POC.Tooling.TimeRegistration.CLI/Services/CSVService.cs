using CsvHelper;
using System.Globalization;

namespace BP_POC.Tooling.TimeRegistration.CLI.Services;

public class CSVService
{
    private readonly string _filePath = $"C:\\Development\\Projects\\HG - BP - Proof of Concept\\BP-POC\\data\\datareading.csv";
    private CsvWriter _writer;

    public CSVService()
    {
        StreamWriter writer = new(_filePath);
        _writer = new(writer, CultureInfo.InvariantCulture);
    }

    public void WriteToCsv(List<Reading> readings)
    {
        _writer.WriteRecords(readings);
    }
}
