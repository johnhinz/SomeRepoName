// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


    Stopwatch sw = new Stopwatch();
    sw.Start();
    int result = AddSomeNumbersAsync().Result;
    sw.Stop();

    Console.WriteLine($"{result} took {sw.Elapsed} time");

    async Task<int> AddSomeNumbersAsync()
    {
        Task<int> a = SomeLongRunningMethodAAsync();
        Task<int> b = SomeOtherLongRunningMethodBAsync();

        return await a + await b;
    }


    Task<int> SomeLongRunningMethodAAsync()
    {
        return Task.Run<int>(() =>
        {
            Thread.Sleep(3000);
            return 3000;
        });
    }

    Task<int> SomeOtherLongRunningMethodBAsync()
    {
        return Task.Run<int>(() =>
        {
            Thread.Sleep(5000);
            return 5000;
        });
    }
