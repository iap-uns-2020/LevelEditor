using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QR;

public class VistaEditor : MonoBehaviour
{
    public GameObject panelPrincipal;
    public GameObject panelQR;

    public Button[] bottonObject;
    public GameObject cell;
    public Transform layoutMap;

    public Slider numberRow, numberColumn;
    public Text textNumberRow, textNumberColumn;

    private char typeElement;

    private Sprite elementSelect;

    private List<GameObject> allButton;
    private IPresenterEditor presenter;
    
    private int row, column;

    public ErrorMessageHandler message;


    public QRCodeGenerator qrCodeGeneartor;

    // Start is called before the first frame update
    void Start()
    {
        allButton = new List<GameObject>();
        typeElement = ' ';
        //presenter = new PresenterEditor(row, column);


       



        presenter = new PresenterEditor();

        //message = new ErrorMessageHandler();


        row = (int)numberRow.value;
        column = (int)numberColumn.value;

        presenter.SetColumn(column);
        presenter.SetRow(row);
        presenter.InitializeMap(row, column);

        foreach (Button button in bottonObject)
            button.onClick.AddListener(() => SetElement(button.GetComponent<ObjectSelector>(), button.GetComponent<Image>().sprite));

        SetElement(bottonObject[bottonObject.Length - 1].GetComponent<ObjectSelector>(), bottonObject[4].GetComponent<Image>().sprite);
        SetGridLayoutMap();
        message.CreatePreseterErrorMesaage();
        CreateMap();
        InvokeRepeating("SetSlider", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetSlider()
    {
        row = (int)numberRow.value;
        textNumberRow.text = "Numero de filas: " + row;
        column = (int)numberColumn.value;
        textNumberColumn.text = "Numero de columnas: " + column;
    }
    public void SetElement(ObjectSelector selectorObject, Sprite spriteObject)
    {
        elementSelect = spriteObject;
        typeElement = selectorObject.ObjectType;
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

        presenter.InitializeMap(row, column);
        message.InitializeMapErrorMessage(row,column);

        elementSelect = bottonObject[4].GetComponent<Image>().sprite;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                GameObject cellMap = Instantiate(cell, layoutMap);
                allButton.Add(cellMap);
                cellMap.GetComponent<ButtonInfo>().Row = i;
                cellMap.GetComponent<ButtonInfo>().Column = j;
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

    public void SetElementMatrix(GameObject cellMap)
    {
        cellMap.GetComponent<Button>().GetComponent<Image>().sprite = elementSelect;

        int positionRow = cellMap.GetComponent<ButtonInfo>().Row;
        int positionColumn = cellMap.GetComponent<ButtonInfo>().Column;

        presenter.SetElementMatrix(positionRow, positionColumn, typeElement);

        message.SetElement(positionRow, positionColumn, typeElement);
    }

    public void ValidarMapa() {

        if (message.ErrorMessage())
            ObtenerCodificacionDelNivel();
    }

    public void ObtenerCodificacionDelNivel() {
        string levelString = presenter.GenerationMap();
        MostrarCodigoQR(levelString);
    }

    public void MostrarPanelQR() {
        panelPrincipal.SetActive(false);
        panelQR.SetActive(true);
    }

    public void MostrarPanelPrincipal() {
        panelPrincipal.SetActive(true);
        panelQR.SetActive(false);
    }

    public void MostrarCodigoQR(string qrData) {
        Debug.Log(qrData);
        qrCodeGeneartor.GenerateQR(qrData);
    }



    public int GetRows()
    {
        return row;
    }

    public int GetColumns()
    {
        return column;
    }

    public char[,] GetMatrix()
    {
        return presenter.GetMatrix();
    }
   
}
