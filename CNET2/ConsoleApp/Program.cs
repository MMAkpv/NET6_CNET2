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

    var v = result.OrderByDescending(x => x.Value).Take(10);

    foreach (var item in v)
    {
        Console.WriteLine($"{item.Key}\t{item.Value}");
    }
}