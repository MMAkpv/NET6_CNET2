using Data;
using Model;
using System.Linq;

Console.WriteLine("Hello, World!");




#region 3denAPS
//var dataset = Data.Serialization.LoadFromXML();

//Console.WriteLine(dataset.Count());

// kolik lidi ma nejakou smlouvu
//var resultSmlouva = dataset.Where(p => p.Contracts.Any()).Count();
//Console.WriteLine(resultSmlouva);

// kolik lidi je z Brna
//var resultBrno = dataset.Count(p => p.HomeAddress.City == "Brno");
//Console.WriteLine(resultBrno);

// spocitejte a vypiste lidi z Brna

//var resultBrnoCol = dataset.Where(p => p.HomeAddress.City == "Brno").ToList();
//Console.WriteLine(resultBrnoCol.Count);

//foreach (var item in resultBrnoCol)
//{
//    Console.WriteLine(item.FullName);
//}

//// nejstarší a nejmladší, jméno a věk

//var serazenyDataset = dataset.OrderBy(p => p.DateOfBirth);
//var nejstarsi = serazenyDataset.First();
//var nejmladsti = serazenyDataset.Last();

//Console.WriteLine(nejstarsi.LastName + " " + nejstarsi.Age());
//Console.WriteLine(nejmladsti.LastName + " " + nejmladsti.Age());


//anonymni typ
//var result = dataset.Select(p => new { p.FullName, Age = p.Age() });

//foreach (var item in result)
//{
//    Console.WriteLine(item.FullName + " " + item.Age);
//}

//anonymni typ jako tuple
//var resTuple = dataset.Select(p => (Name: p.FullName, Age: p.Age() ));

//foreach (var item in resTuple)
//{
//    Console.WriteLine(item.Name + " " + item.Age);
//}


//GROUPBY podle měst s počtem
//var datasetGroupByMesto = dataset.GroupBy(p => p.HomeAddress.City);

//foreach (var item in datasetGroupByMesto)
//{
//    Console.WriteLine($"Město: {item.Key}\tPočet lidí: {item.Count()}");
//}

//vypsat lidi podle měst


//select many (v některých jazycích flatten), ziskat vsechny smlouvy
//var result = dataset.SelectMany(p => p.Contracts);
//Console.WriteLine(result.Count());

//kdo s nami uzavrel posledni smlouvu

//moje řešení, porovnávám cíle"pointerů", záleží na implementaci... v tomto případě funguje
//Contract con = dataset.SelectMany(c => c.Contracts).OrderBy(c => c.Signed).Last();

//var per = dataset.Where(p => p.Contracts.Contains(con));

//foreach (var item in per)
//{
//    Console.WriteLine(item.LastName);
//}

//řešení ostatních, seřadim lidi podle poslední smlouvy

//var seSmlouvou = dataset.Where(p => p.Contracts.Any());

//var result = seSmlouvou.OrderByDescending(p => p.Contracts.OrderByDescending(c => c.Signed).First().Signed).First();
//Console.WriteLine(result.LastName);


#endregion

#region LINQ

//int[] numbers = { 11, 2, 13, 44, -5, 6, 127, -99, 0, 256 };

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

#endregion

#region Interface
//Client client1 = new Client() { Name = "Petr" };
//Client client2 = new Client() { Name = "Alena" };
//VIPClient client3 = new VIPClient() { Name = "Monika", Status = "GOLD" };

//List<IGreetable> clients = new List<IGreetable>();
//clients.Add(client1);
//clients.Add(client2);
//clients.Add(client3);

//foreach (var client in clients)
//{
//    Console.WriteLine(client.SayHello());
//}

//static void GreetClient(IGreetable client)
//{
//    Console.WriteLine(client.SayHello());
//}

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