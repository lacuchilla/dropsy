using System.Collections.Generic;

namespace Dropsy
{
    internal class Board
    {
        private readonly List<Column> _columns;

        public Board(int size)
        {
            _columns = new List<Column>();
            for (var i = 0; i < size; i += 1)
                _columns.Add(new Column());
        }

        public void AddToColumn(int column, string chip)
        {
            _columns[column - 1].Data.Add(chip); // TODO trainwreck :(
        }

        public string GetCell(int column, int row)
        {
            if (!InRange(column, row))
                return " ";

            return _columns[column - 1].Data[row - 1];
        }

        private bool InRange(int column, int row)
        {
            if (column > _columns.Count || column < 1)
                return false;

            if (row > _columns[column - 1].Data.Count || row < 1)
                return false;

            return true;
        }

        private class Column
        {
            public readonly List<string> Data;

            public Column()
            {
                Data = new List<string>();
            }
        }
    }
}