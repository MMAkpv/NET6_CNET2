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

            var words = input.Split(new String[] { " ", ",", ".", ";", ":", Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

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

        public static async Task<Dictionary<string, int>> FreqAnalysisFromUrl(string url)
        {
            // todo get content from url
            //throw new NotImplementedException();
        
            HttpClient httpClient = new HttpClient();


            var content = await httpClient.GetStringAsync(url);

            return FreqAnalysisFromString(content);
        
        }


        public static Dictionary<string, int> FreqAnalysisFromFile(string file)
        {
            // todo get content from file
            //throw new NotImplementedException();

            var content = File.ReadAllText(file);

            return FreqAnalysisFromString(content);

        }
    }
}