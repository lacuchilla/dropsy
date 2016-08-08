using System.Collections.Generic;
using System.Linq;

namespace Dropsy
{
    internal class Board
    {
        private readonly List<Column> _columns;
        private readonly int _size;

        public Board(int size)
        {
            _size = size;
            _columns = new List<Column>();
            for (var i = 0; i < size; i += 1)
                _columns.Add(new Column());
        }

        public void AddToColumn(int column, string chip)
        {
            _columns[column - 1].Add(chip);

            //if chip is 1 on an empty board, chip should turn into an asterisk and disappear
            //
            //(chip needs to check its neighbors on the left, right, and above and below later)
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

        public bool ColumnIsFull(int column)
        {
            return _columns[column - 1].Data.Count >= _size;
        }

        public bool IsFull()
        {
            for (var col = 0; col < _size; col++)
            {
                if (!ColumnIsFull(col + 1))
                    return false;
            }
            return true;
        }

        public bool ColumnOverflowCheck()
        {
            foreach (var column in _columns)
            {
                if (column.Data.Count > _size)
                    return true;
            }
            return false;
        }


        public void ShiftColumnsUp()
        {
            foreach (var column in _columns)
                column.ShiftUp();
        }

        public bool AnythingToPop()
        {
            foreach (var column in _columns)
            {
                var poppableIndexes = GetPoppableIndexes(column.Data);
                if (poppableIndexes.Any())
                    return true;
            }

            //check the rows
            for (var r = 1; r <= _size; r++)
            {
                var row = new List<string>();
                for (var c = 1; c <= _size; c++)
                {
                    row.Add(GetCell(c, r));
                }

                var poppable = GetPoppableIndexes(row);
                if (poppable.Any())
                    return true;
            }
            return false;
        }


        public void ToAsterisks()
        {
            foreach (var column in _columns)
            {
                var poppable = GetPoppableIndexes(column.Data);
                foreach (var index in poppable)
                {
                    column.Data[index] = "*";
                }
            }

            for (var r = 1; r <= _size; r++)
            {
                var row = new List<string>();
                for (var c = 1; c <= _size; c++)
                {
                    row.Add(GetCell(c, r));
                }

                var poppable = GetPoppableIndexes(row);
                foreach (var index in poppable)
                {
                    _columns[index].Data[r - 1] = "*";
                }
            }
        }

        public void RemoveAsterisks()
        {
            foreach (var column in _columns)
            {
                if (column.Data.Count == 1 && column.Data[0] == "*")
                {
                    column.Data.Clear();
                }
            }
        }

        private List<int> GetPoppableIndexes(List<string> data)
        {
            var poppableIndexes = new List<int>();
            for (var targetNum = 1; targetNum <= _size; targetNum++)
            {
                var streak = 0;
                for (var current = 0; current < data.Count; current++)
                {
                    if (data[current] != " ")
                        streak++;
                    else
                    {
                        if (streak == targetNum)
                        {
                            for (var i = 0; i < streak; i++)
                            {
                                var index = current - 1 - i;
                                if (data[index] == streak.ToString())
                                    poppableIndexes.Add(index);
                            }
                        }
                        streak = 0;
                    }
                }
                if (streak == targetNum)
                {
                    for (var i = 0; i < streak; i++)
                    {
                        var index = data.Count - 1 - i;
                        if (data[index] == streak.ToString())
                            poppableIndexes.Add(index);
                    }
                }
            }
            return poppableIndexes;
        }

        private class Column
        {
            public readonly List<string> Data;

            public Column()
            {
                Data = new List<string>();
            }

            public void ShiftUp()
            {
                Data.Insert(0, "█");
            }

            public void Add(string chip)
            {
                Data.Add(chip);
            }
        }
    }
}