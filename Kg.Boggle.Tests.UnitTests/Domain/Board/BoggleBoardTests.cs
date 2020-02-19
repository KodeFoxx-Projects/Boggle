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

        private static string[,] GetPremadeBoard_4x4()
            => new[,] {
                { "d", "g", "h", "i" },
                { "k", "l", "p", "s" },
                { "y", "e", "u", "t" },
                { "e", "o", "r", "n" },
            };
    }
}
