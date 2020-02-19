using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kf.Boggle.Domain.Dictionary
{
    public sealed class BoggleDictionary
    {
        public static BoggleDictionary Empty
            => new BoggleDictionary();

        public static async Task<BoggleDictionary> LoadFrom(FileInfo dictionaryFile)
        {
            if (!dictionaryFile.Exists)
                return await Task.FromResult(Empty);

            var lines = await File.ReadAllLinesAsync(dictionaryFile.FullName);
            var dictionary = new Dictionary<string, List<string>>();
            foreach (var line in lines.Select(l => l.ToLowerInvariant()))
            {
                if (line.Length >= 3)
                {
                    var key = line.Substring(0, 3);

                    if (!dictionary.ContainsKey(key))
                        dictionary.Add(key, new List<string>());

                    dictionary[key].Add(line);
                }
            }

            return await Task.FromResult(new BoggleDictionary(dictionary));
        }
        public static Task<BoggleDictionary> LoadFrom(string dictionaryPath)
            => LoadFrom(new FileInfo(dictionaryPath));

        public readonly Dictionary<string, List<string>> _dictionary;

        private BoggleDictionary(Dictionary<string, List<string>> dictionary)
            => _dictionary = dictionary;
        private BoggleDictionary()
            : this(new Dictionary<string, List<string>>())
        { }

        public bool Contains(string word)
        {
            if (String.IsNullOrWhiteSpace(word))
                return false;

            if (word.Length < 3)
                return false;

            var key = word.Substring(0, 3);

            if (!_dictionary.ContainsKey(key))
                return false;

            return _dictionary[key].Contains(word);
        }

        public IEnumerable<string> Words
            => _dictionary.Values
                .SelectMany(words => words)
                .AsEnumerable();
    }
}
