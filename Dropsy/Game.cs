namespace Dropsy
{
    public class Game
    {
        private readonly Board _board;
        private readonly string _middleConnector;
        private readonly int _size;
        private string _nextChip;
        private int _turns;
        private int _maxTurns;


        public Game(int size, int maxTurns = 0)
        {
            _maxTurns = maxTurns;
            _size = size;
            Screen = new ConsoleScreen();
            ChipGenerator = new RandomChipGenerator(_size);
            _middleConnector = Repeat("───");
            _board = new Board(size);
        }

        public IScreen Screen { get; set; }
        public IChipGenerator ChipGenerator { get; set; }

        public void Play()
        {
            bool needsNewChip = true;
            
            while(!GameIsOver())
            {
                if (needsNewChip)
                {
                    SetNextChipToDrop();
                    DrawBoard();
                }
                needsNewChip = DropChipIntoColumn(Screen.ReadKey());
                DrawBoard();
                _turns++;
            }
        }

        public bool GameIsOver()
        {
            if (_maxTurns != 0 && _turns > _maxTurns)
                return true;

            return _board.IsFull();
        }

        public void SetNextChipToDrop()
        {
            _nextChip = ChipGenerator.Next().ToString();
        }

        public bool DropChipIntoColumn(int column)
        {
            if (_board.ColumnIsFull(column))
                return false;

            _board.AddToColumn(column, _nextChip);
            _nextChip = " ";

            return true;
        }

        public void DrawBoard()
        {
            Screen.Clear();
            DrawChipToDrop();
            TopBorder();
            Field();
            BottomBorder();
            ColumnLabels();
        }

        private void DrawChipToDrop()
        {
            Screen.WriteLine(new string(' ', 3*_size/2 + 1) + _nextChip);
        }

        private void ColumnLabels()
        {
            var columnLabels = " ";
            for (var i = 1; i <= _size; i++)
                columnLabels += $" {i} ";
            columnLabels += " ";
            Screen.WriteLine(columnLabels);
        }

        private void BottomBorder()
        {
            Screen.WriteLine("└" + _middleConnector + "┘");
        }

        private void Field()
        {
            for (var row = _size; row > 0; row--)
                Screen.WriteLine("│" + CreateRow(row) + "│");
        }

        private string CreateRow(int row)
        {
            var columnSpace = "";
            for (var column = 1; column <= _size; column++)
            {
                var center = _board.GetCell(column, row);
                columnSpace += $" {center} ";
            }
            return columnSpace;
        }

        private void TopBorder()
        {
            Screen.WriteLine("┌" + _middleConnector + "┐");
        }

        private string Repeat(string s)
        {
            var output = "";
            for (var i = 0; i < _size; i++)
                output += s;
            return output;
        }
    }
}