using Model;

Console.WriteLine("Hello, World!");

//inicializator - nahrada využití konstruktoru
FAResult fAResult = new FAResult()
{
    Source = "file",
    SourceType = SourceType.FILE
};

//fAResult.Source = "file";
//fAResult.SourceType = SourceType.FILE;

//Console.WriteLine(fAResult);

//fAResult.Words = new Dictionary<string, int>();

Console.WriteLine(fAResult);