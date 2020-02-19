namespace Kf.Boggle.Domain.Board
{
    public sealed class BoggleBoard
    {
        public static BoggleBoard Empty
            => new BoggleBoard();

        public static BoggleBoard Create(int width, int height)
            => new BoggleBoard(width, height);

        private BoggleBoard(int width, int height)
            => _matrix = new string[width, height];
        private BoggleBoard()
            : this(0, 0)
        { }

        private readonly string[,] _matrix;

        public int Width
            => _matrix.GetLength(0);
        public int Height
            => _matrix.GetLength(1);
    }
}
