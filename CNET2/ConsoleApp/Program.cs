using Data;
using Model;

Console.WriteLine("Hello, World!");

var booksdir = @"C:\Users\PC\source\repos\CNET2\Books";

var files = Directory.EnumerateFiles(booksdir, "*.txt");

foreach (var file in files)
{
    
    var result = FreqAnalysis.FreqAnalysisFromFile(file);

    var fileInfo = new FileInfo(file);
    Console.WriteLine(fileInfo.Name);

    var orderedTop10 = result.Words.OrderByDescending(x => x.Value).Take(10);

    foreach (var item in orderedTop10)
    {
        Console.WriteLine($"{item.Key}\t{item.Value}");
    }
    
    Console.WriteLine();
}