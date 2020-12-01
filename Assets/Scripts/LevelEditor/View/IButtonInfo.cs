using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.View
{
    public interface IButtonInfo
    {
        int GetRow();
        void SetRow(int row);
        int GetColumn();
        void SetColumn(int column);
    }
}