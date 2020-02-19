using Kf.Boggle.Domain.Board;
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
    }
}
