using System;

namespace Kf.Boggle.Domain.Board
{
    public sealed class BoggleBoard
    {
        public static BoggleBoard Empty
            => new BoggleBoard();

        public static BoggleBoard Create(int width, int height)
            => new BoggleBoard(width, height);
        public static BoggleBoard Create(string[,] matrix)
            => new BoggleBoard(matrix);

        private BoggleBoard(int width, int height)
        {
            _random = new Random();
            _matrix = CreateMatrix(width, height);
        }
        private BoggleBoard(string[,] matrix)
            => _matrix = matrix;

        private BoggleBoard()
            : this(0, 0)
        { }

        private readonly string[,] _matrix;
        private readonly Random _random;

        public string this[int width, int height] {
            get {
                if (this == BoggleBoard.Empty)
                    return String.Empty;

                return _matrix[height - 1, width - 1];
            }
        }

        public int Width
            => _matrix.GetLength(1);
        public int Height
            => _matrix.GetLength(0);

        private string[,] CreateMatrix(int width, int height)
        {
            var matrix = new string[height, width];
            var characters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (var h = 0; h < height; h++)
            {
                for (var w = 0; w < width; w++)
                    matrix[h, w] = characters[_random.Next(0, characters.Length)].ToString();
            }

            return matrix;
        }
    }
}
