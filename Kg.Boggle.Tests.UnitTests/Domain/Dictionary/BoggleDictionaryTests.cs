using Kf.Boggle.Domain.Dictionary;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Kg.Boggle.Tests.UnitTests.Domain.Dictionary
{
    public sealed class BoggleDictionaryTests
    {
        [Fact]
        public async void Loads_from_file()
        {
            var dictionaryPath = Path.Combine(
                Environment.CurrentDirectory,
                "Dictionary", "english.txt");

            var sut = await BoggleDictionary.LoadFrom(dictionaryPath);

            Assert.NotNull(sut);
            Assert.True(sut.Contains("word"));
        }

        [Fact]
        public async void Returns_false_if_key_not_present()
        {
            var dictionaryPath = Path.Combine(
                Environment.CurrentDirectory,
                "Dictionary", "english.txt");

            var sut = await BoggleDictionary.LoadFrom(dictionaryPath);

            Assert.False(sut.Contains("XXX"));
        }

        [Fact]
        public async void Words_are_three_or_more_characters_long()
        {
            var dictionaryPath = Path.Combine(
                Environment.CurrentDirectory,
                "Dictionary", "english.txt");

            var sut = await BoggleDictionary.LoadFrom(dictionaryPath);
            var words = sut.Words.ToList();

            Assert.DoesNotContain(words, word => word.Length < 3);
        }
    }
}
