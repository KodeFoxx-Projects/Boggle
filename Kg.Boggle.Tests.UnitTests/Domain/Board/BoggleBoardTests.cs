using Kf.Boggle.Domain.Board;
using System;
using Xunit;

namespace Kg.Boggle.Tests.UnitTests.Domain.Board
{
    public sealed class BoggleBoardTests
    {
        [Fact]
        public void Empty_board_has_zero_width_and_height()
        {
            Assert.Equal(0, BoggleBoard.Empty.Width);
            Assert.Equal(0, BoggleBoard.Empty.Height);
        }

        [Fact]
        public void Empty_board_property_index_returns_empty_string()
        {
            var sut = BoggleBoard.Empty;

            Assert.Equal(String.Empty, sut[1, 1]);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        public void IsHeightInRange_returns_true_when_in_range_false_when_not(
            int height, bool expected)
        {
            var sut = BoggleBoard.Create(GetPremadeBoard_4x4());

            Assert.Equal(expected, sut.IsHeightInRange(height));
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        public void IsWidthInRange_returns_true_when_in_range_false_when_not(
            int width, bool expected)
        {
            var sut = BoggleBoard.Create(GetPremadeBoard_4x4());

            Assert.Equal(expected, sut.IsWidthInRange(width));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 5)]
        [InlineData(-1, 1)]
        [InlineData(20, 20)]
        public void Index_out_of_bounds_on_property_index_returns_empty_string(
            int width, int height)
        {
            var sut = BoggleBoard.Create(GetPremadeBoard_4x4());

            Assert.Equal(String.Empty, sut[width, height]);
        }

        [Fact]
        public void Board_translates_with_and_height_correctly()
        {
            var width = 4;
            var height = 8;

            var sut = BoggleBoard.Create(width, height);

            Assert.Equal(width, sut.Width);
            Assert.Equal(height, sut.Height);
        }

        [Fact]
        public void Create_board_from_matrix_width_and_height_match()
        {
            var matrix = GetPremadeBoard_4x4();

            var sut = BoggleBoard.Create(matrix);

            Assert.Equal(4, sut.Height);
            Assert.Equal(4, sut.Width);
        }

        [Fact]
        public void Property_indexer_for_full_board_is_not_zero_based()
        {
            var matrix = GetPremadeBoard_4x4();

            var sut = BoggleBoard.Create(matrix);

            Assert.Equal("d", sut[1, 1]);
            Assert.Equal("l", sut[2, 2]);
            Assert.Equal("e", sut[2, 3]);
            Assert.Equal("p", sut[3, 2]);
            Assert.Equal("n", sut[4, 4]);

            Assert.Equal(
                "rups",
                String.Join(
                    "", new[] {
                        sut[3, 4],
                        sut[3, 3],
                        sut[3, 2],
                        sut[4, 2],
                    })
                );
        }

        [Theory]
        [InlineData("x", false)]
        [InlineData("d", true)]
        [InlineData("l", true)]
        [InlineData("e", true)]
        [InlineData("t", true)]
        [InlineData("o", true)]
        [InlineData("q", false)]
        [InlineData("a", false)]
        public void ContainsLetter_returns_true_when_letter_is_board(
            string letter, bool expected)
        {
            var sut = BoggleBoard.Create(GetPremadeBoard_4x4());

            Assert.Equal(expected, sut.ContainsLetter(letter));
        }

        [Theory]
        [InlineData("matrix", false)]
        [InlineData("super", true)]
        [InlineData("rups", true)]
        [InlineData("sip", true)]
        [InlineData("hips", true)]
        [InlineData("hi", false)]
        [InlineData("nroe", true)]
        [InlineData("nr", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("     ", false)]
        public void ContainsWord_returns_true_when_letter_is_board(
            string letter, bool expected)
        {
            var sut = BoggleBoard.Create(GetPremadeBoard_4x4());

            Assert.Equal(expected, sut.ContainsWord(letter));
        }

        private static string[,] GetPremadeBoard_4x4()
            => new[,] {
                { "d", "g", "h", "i" },
                { "k", "l", "p", "s" },
                { "y", "e", "u", "t" },
                { "e", "o", "r", "n" },
            };
    }
}
