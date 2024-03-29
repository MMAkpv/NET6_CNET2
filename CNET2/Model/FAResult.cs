﻿using System.Linq;

namespace Model
{
    /// <summary>
    /// Výsledek frekvenční analýzy pro jeden zdroj (soubor nebo url)
    /// </summary>
    public class FAResult
    {
        // konstruktor
        //public FAResult(string source, SourceType sourceType)
        //{
        //    Source = source;
        //    SourceType = sourceType;
        //    Words = new Dictionary<string, int>();
        //}


        /// <summary>
        /// Zdroj textu
        /// </summary>
        public string? Source { get; set; }

        public SourceType SourceType { get; set; }

        /// <summary>
        /// Výsledná frekvenční analýza slov
        /// </summary>
        public Dictionary<string, int> Words { get; set; } = new Dictionary<string, int>();

        public Dictionary<string, int> GetTop10() => Words.OrderByDescending(kv => kv.Value).Take(10).ToDictionary(kv => kv.Key, kv => kv.Value);

        //zkracene public override string ToString() =>  return $"{Source} {Words?.Count}";  
        public override string ToString()
        {
                return $"{Source} {Words?.Count}";   
        }

    }

    public enum SourceType
    {
        URL,
        FILE
    }
}