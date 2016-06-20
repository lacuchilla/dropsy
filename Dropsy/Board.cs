using System;
using System.Collections;
using System.Collections.Generic;

namespace Dropsy
{
    class Board
    {
        private class Column
        {
            public readonly List<string> Data;

            public Column()
            {
                Data = new List<string>();
            }
        }

        private readonly List<Column> _columns;

        public Board(int size)
        {
            _columns = new List<Column>();
            for(var i = 0; i < size; i+=1)
                _columns.Add(new Column());
        }

        public void AddToColumn(int column, string chip)
        {
            _columns[column-1].Data.Add(chip);  // TODO trainwreck :(
        }

        public string GetCell(int column, int row)
        {
            // TODO using exceptions for flow control is bad :(
            try
            {
                return _columns[column - 1].Data[row - 1];
            }
            catch (Exception)
            {
                return " ";
            }
        }
    }
}