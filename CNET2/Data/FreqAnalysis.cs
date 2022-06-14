using Model;

namespace Data
{
    public class FreqAnalysis
    {
        public static Dictionary<string, int> FreqAnalysisFromString(string input)
        {
            // moje reseni
            //Dictionary<string, int> result = new Dictionary<string, int>();
            //List<string> words = input.Split(new string[] { " ", ",", ".", ";", ":", Environment.NewLine }, StringSplitOptions.None).ToList();

            //foreach (var item in words)
            //{
            //    if (!result.ContainsKey(item))
            //    {
            //        result.Add(item, words.Count(s => s == item));
            //    }
            //}

            // rychlejsi reseni, podle prednasejiciho
            var result = new Dictionary<string, int>();

            //var words = input.Split(new String[] { " ", ",", ".", ";", ":", Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            //var words = input.Replace("."," ").Replace(","," ").Split(new String[] { " "}, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            //var words = input.Replace(Environment.NewLine, " ")
            //    .Replace(".", " ")
            //    .Replace(",", " ")
            //    .Replace(":"," ")
            //    .Replace("("," ")
            //    .Replace(")"," ")
            //    .Replace("  ", " ")
            //    .Replace("\"", " ")
            //    .Replace("\'", " ")
            //    .Replace("!", " ")
            //    .Replace("?", " ")
            //    .Replace("...", " ")
            //    .Split(" ", (StringSplitOptions)3); //flagy z nápovědy 1 a 2, já chci obojí, tak to sečtu a dám 3

            var words = input.Split(Environment.NewLine); //úprava pro nové soubory

            foreach (var word in words)
            {
                if (result.ContainsKey(word))
                {
                    result[word] += 1;
                }
                else
                {
                    result.Add(word,1);
                }
            }

            return result;
        }

        public static async Task<FAResult> FreqAnalysisFromUrl(string url)
        {
        
            HttpClient httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(url);
            var dict = FreqAnalysisFromString(content);

            return new FAResult()
            {
                Source = url,
                SourceType = SourceType.URL,
                Words = dict
            };
        
        }


        public static FAResult FreqAnalysisFromFile(string file)
        {

            var content = File.ReadAllText(file);
            var dict = FreqAnalysisFromString(content);

            return new FAResult()
            {
                Source = file,
                SourceType = SourceType.FILE,
                Words = dict
            };

        }
    }
}