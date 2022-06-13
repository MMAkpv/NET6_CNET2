using Data;
using Model;
using System.Linq;

Console.WriteLine("Hello, World!");

int[] numbers = { 11, 2, 13, 44, -5, 6, 127, -99, 0, 256 };

#region LINQ

//WHERE - filtrace
//vetsi nez 0
//var n = numbers.Where(n => n > 0).ToList();
//Console.WriteLine(String.Join(", ", n));

////vetsi nez 0 a mensi nez 100
////n = numbers.Where(n => n > 0 && n < 100).ToList(); //na jeden "průchod"
//n = numbers.Where(n => n > 0).Where(n => n < 100).ToList(); //na "2" operace
//Console.WriteLine(String.Join(", ", n));

////ORDERBY - řazení
//n = numbers.OrderBy(n => n).ToList();
//Console.WriteLine(String.Join(", ", n));

//AGREGACE
//var nn = numbers.Count();
//Console.WriteLine($"Count je {nn}");

//nn = numbers.Max();
//Console.WriteLine($"MAX je {nn}");

//nn = numbers.Min();
//Console.WriteLine($"Min je {nn}");

//nn = numbers.Sum();
//Console.WriteLine($"Sum je {nn}");

//var nnn = numbers.Average();
//Console.WriteLine($"Average je {nn}");

//TAKE SKIP
//var res = numbers.TakeWhile(n => n > 0);
//Console.WriteLine(String.Join(", ", res));

//SELECT
//var res = numbers.Select(n => Math.Abs(n));
//Console.WriteLine(String.Join(", ", res));


//UKOLY
//pocet kladnych cisel
//Console.WriteLine(numbers.Count(n => n > 0));

//ignorovat max a min cislo, ze zbytku pocitat prumer

//var v = (numbers.Sum() - numbers.Max() - numbers.Min()+0.0) / (numbers.Count() - 2);
//Console.WriteLine(v);

//var result = numbers.OrderBy(n => n).Skip(1).SkipLast(1).Average();
//Console.WriteLine(result);

//pocet lichych
//Console.WriteLine(numbers.Count(n => n % 2 != 0 && n != 0));

//pocet sudych
//Console.WriteLine(numbers.Count(n => n % 2 == 0 || n == 0));

//vypsat cisla slovy
//var numbers2 = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var strings = new[] { "zero", "one", "two", "three", "four",
//    "five", "six", "seven", "eight", "nine" };

//var l = numbers2.Select(n => strings[n]).ToArray();
//Console.WriteLine(String.Join(", ", l));

NewMethod();
#endregion

static void NewMethod()
{
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
}