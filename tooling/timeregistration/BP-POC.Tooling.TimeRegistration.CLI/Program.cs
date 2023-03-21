using BP_POC.Tooling.TimeRegistration.CLI;
using BP_POC.Tooling.TimeRegistration.CLI.Services;

HttpService httpService = new("https://localhost:7057", "api/printer");
CSVService csvService = new();
Random random = new Random();

List<Reading> readings = new();

int amountOfRequests = 10_000;
//int amountOfRequests = 10;

for (int i = 0; i < amountOfRequests; i++)
{
    TimeSpan difference;
    DateTime startOfClick = DateTime.Now;

    Console.WriteLine($"Start of click: {startOfClick}");

    int printerId = random.Next(1, 3);

    DateTime? endOfClick = await httpService.CallRegisterPrinterClick(printerId);

    if (endOfClick is null)
    {
        difference = TimeSpan.Parse("0");
    }
    else
    {
        difference = (DateTime)endOfClick - startOfClick;
    }

    readings.Add(new Reading
    {
        TimeDifferenceInMilliseconds = difference.TotalMilliseconds
    });

    Console.WriteLine($"End of click: {endOfClick}");
    Console.WriteLine($"{i}. Timespan: {difference.TotalMilliseconds}");
    Console.WriteLine();

    Thread.Sleep(1000);
}

csvService.WriteToCsv(readings);

Console.ReadKey();