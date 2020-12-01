using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.View
{
    public class ButtonInfo : MonoBehaviour, IButtonInfo
    {
        private int row, column;

        public int GetRow()
        {
            return row;
        }

        public void SetRow(int row)
        {
            this.row = row;
        }

        public int GetColumn()
        {
            return column;
        }

        public void SetColumn(int column)
        {
            this.column = column;
        }
    }
}