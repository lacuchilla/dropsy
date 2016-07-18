﻿using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace Dropsy
{
    internal class Board
    {
        private readonly List<Column> _columns;
        private int _size;

        public Board(int size)
        {
            _size = size;
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

            public void ShiftUp()
            {
                Data.Insert(0, "█");
            }
        }

        public bool ColumnIsFull(int column)
        {
            return _columns[column - 1].Data.Count >= _size;
        }

        public bool IsFull()
        {
            for (var col = 0; col < _size; col++ )
            {
                if (!ColumnIsFull(col+1))
                    return false;
            }
            return true;
        }

        public void ShiftColumnsUp()
        {
            foreach (var column in _columns)
                column.ShiftUp();
        }
    }
}