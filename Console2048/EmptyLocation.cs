using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    struct EmptyLocation
    {
        private int lineIndex;
        public int LineIndex
        {
            get
            {
                return lineIndex;
            }
            set
            {
                this.lineIndex = value;
            }
        }
        private int rowIndex;
        public int RowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                this.rowIndex = value;
            }
        }
        public EmptyLocation(int lineIndex,int rowIndex):this()
        {
            LineIndex = lineIndex;
            RowIndex = rowIndex;
        }
    }
}
