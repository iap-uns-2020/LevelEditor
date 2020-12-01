using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QRGenerator.View;
using ErrorManagement.View;
using Editor.Presenter;

namespace Editor.View
{
    public class ViewEditor : MonoBehaviour
    {
        private const string TEXTSLIDERROW = "Numero de filas: ";
        private const string TEXTSLIDERCOLUMN = "Numero de columnas: ";
        private const int FREESLOTSPRITEPOSITIONINARRAY = 4;
        public Button[] bottonObject;
        public GameObject cell;
        public Transform layoutMap;

        public Slider numberRow, numberColumn;
        public Text textNumberRow, textNumberColumn;

        public GameObject IViewErrorMessageHandler;
        private IViewErrorMessageHandler messagerErrorManager;
        private IQRCodeGenerator qrCodeGeneartor;
        public GameObject IQRCodeGenerator;

        private char typeElement;
        private Sprite elementSelect;
        private List<GameObject> allButton;
        private IPresenterEditor presenterEditor;
        private int row, column;


       
        // Start is called before the first frame update
        void Start()
        {
            allButton = new List<GameObject>();
            typeElement = ' ';
            presenterEditor = new PresenterEditor();

            row = (int)numberRow.value;
            column = (int)numberColumn.value;

            presenterEditor.SetColumn(column);
            presenterEditor.SetRow(row);
            presenterEditor.InitializeMap(row, column);

            messagerErrorManager = IViewErrorMessageHandler.GetComponent<IViewErrorMessageHandler>();
            qrCodeGeneartor = IQRCodeGenerator.GetComponent<IQRCodeGenerator>();
            foreach (Button button in bottonObject)
                button.onClick.AddListener(() => SetElement(button.GetComponent<ObjectInfo>(), button.GetComponent<Image>().sprite));

            SetElement(bottonObject[bottonObject.Length - 1].GetComponent<ObjectInfo>(), bottonObject[FREESLOTSPRITEPOSITIONINARRAY].GetComponent<Image>().sprite);
            SetGridLayoutMap();
            CreateMap();
            InvokeRepeating("SetSlider", 0, 0.1f);
        }

        public void SetElement(ObjectInfo selectorObject, Sprite spriteObject)
        {
            elementSelect = spriteObject;
            typeElement = selectorObject.ObjectType;
        }

        public void SetElementMatrix(GameObject cellMap)
        {
            cellMap.GetComponent<Button>().GetComponent<Image>().sprite = elementSelect;

            int positionRow = cellMap.GetComponent<ButtonInfo>().GetRow();
            int positionColumn = cellMap.GetComponent<ButtonInfo>().GetColumn();

            presenterEditor.SetElementMatrix(positionRow, positionColumn, typeElement);
            messagerErrorManager.SetElement(positionRow, positionColumn, typeElement);
        }

        public void ValidationMap()
        {
            if (messagerErrorManager.ErrorMessage())
                GetLevelCodification();
        }

        public void GetLevelCodification()
        {
            string levelString = presenterEditor.GenerationMap();
            ShowQRCode(levelString);
        }

        public void ShowQRCode(string qrData)
        {
            qrCodeGeneartor.GenerateQR(qrData);
        }

        public void SetMap()
        {
            DeleteMap();
            SetGridLayoutMap();
            CreateMap();
        }

        private void DeleteMap()
        {
            foreach (GameObject buttonCurrent in allButton)
                Destroy(buttonCurrent);
            allButton.Clear();
        }

        private void CreateMap()
        {
            presenterEditor.InitializeMap(row, column);
            elementSelect = bottonObject[FREESLOTSPRITEPOSITIONINARRAY].GetComponent<Image>().sprite;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    GameObject cellMap = Instantiate(cell, layoutMap);
                    allButton.Add(cellMap);
                    cellMap.GetComponent<ButtonInfo>().SetRow(i);
                    cellMap.GetComponent<ButtonInfo>().SetColumn(j);
                    cellMap.GetComponent<Button>().GetComponent<Image>().sprite = elementSelect;
                    cellMap.GetComponent<Button>().onClick.AddListener(() => SetElementMatrix(cellMap));
                }
            }
        }

        private void SetGridLayoutMap()
        {
            GridLayoutGroup gridLayoutMap = layoutMap.gameObject.GetComponent<GridLayoutGroup>();
            float width = gridLayoutMap.GetComponent<RectTransform>().rect.width / column;
            float heigth = gridLayoutMap.GetComponent<RectTransform>().rect.height / row;
            gridLayoutMap.cellSize = new Vector2(width, heigth);
            gridLayoutMap.constraintCount = row;
        }

        private void SetSlider()
        {
            row = (int)numberRow.value;
            textNumberRow.text = TEXTSLIDERROW + row;
            column = (int)numberColumn.value;
            textNumberColumn.text = TEXTSLIDERCOLUMN + column;
        }
    }
}