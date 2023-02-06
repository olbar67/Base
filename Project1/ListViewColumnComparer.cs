using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    class ListViewColumnComparer : IComparer
    {
        public int ColumnIndex { get; set; }
        public ListViewColumnComparer(int columnIndex)
        {
            ColumnIndex = columnIndex;
        }

        public int Compare(object x, object y)
        {
            try
            {
                return String.Compare(((ListViewItem)x).SubItems[ColumnIndex].Text, ((ListViewItem)y).SubItems[ColumnIndex].Text);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
