using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.View
{
    public interface IViewEditor
    {
        void SetElement(ObjectSelector selectorObject, Sprite spriteObject);
        void SetElementMatrix(GameObject cellMap);
        void ValidationMap();
        void GetLevelCodification();
        void ShowQRCode(string qrData);
        void SetMap();
    }
}