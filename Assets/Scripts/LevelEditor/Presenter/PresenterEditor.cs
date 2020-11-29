using Editor.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.Presenter
{
    public class PresenterEditor : IPresenterEditor
    {
        private ILogicEditor logicEditor;

        public PresenterEditor()
        {
            logicEditor = new LogicEditor();
        }

        public void InitializeMap(int row, int column)
        {
            logicEditor.InitializeMap(row, column);
        }

        public void SetElementMatrix(int positionRow, int positionColumn, char typeElement)
        {
            logicEditor.SetElementMatrix(positionRow, positionColumn, typeElement);
        }

        public string GenerationMap()
        {
            return logicEditor.GenerationMap();
        }

        public void SetColumn(int column)
        {
            logicEditor.SetColumn(column);
        }

        public void SetRow(int row)
        {
            logicEditor.SetRow(row);
        }
    }
}