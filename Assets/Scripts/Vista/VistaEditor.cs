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

    public QRCodeGenerator qrCodeGeneartor;

    // Start is called before the first frame update
    void Start()
    {
        allButton = new List<GameObject>();
        typeElement = ' ';
        presenter = new PresenterEditor(row, column);

        row = (int)numberRow.value;
        column = (int)numberColumn.value;
       
        foreach (Button button in bottonObject)
             button.onClick.AddListener(() => SetElement(button.GetComponent<ObjectSelector>(), button.GetComponent<Image>().sprite));

        SetElement(bottonObject[bottonObject.Length-1].GetComponent<ObjectSelector>(), bottonObject[4].GetComponent<Image>().sprite);
        CreateMap();
    }

    // Update is called once per frame
    void Update()
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
        GridLayoutGroup gridLayoutMap = layoutMap.gameObject.GetComponent<GridLayoutGroup>();
        float width = gridLayoutMap.GetComponent<RectTransform>().rect.width / column;
        float heigth = gridLayoutMap.GetComponent<RectTransform>().rect.height / row;
        gridLayoutMap.cellSize = new Vector2(width, heigth);
        gridLayoutMap.constraintCount = row;
        elementSelect = bottonObject[4].GetComponent<Image>().sprite;


        for (int i = 0; i <row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                GameObject cellMap = Instantiate(cell, layoutMap);
                allButton.Add(cellMap);
                cellMap.GetComponent<ButtonInfo>().Row = i;
                cellMap.GetComponent<ButtonInfo>().Column = j;
                cellMap.GetComponent<Button>().GetComponent<Image>().sprite = elementSelect;
                cellMap.GetComponent<Button>().onClick.AddListener(() =>SetElementMatrix(cellMap));
            }
        }

    }

    public void SetElementMatrix(GameObject cellMap)
    {
        cellMap.GetComponent<Button>().GetComponent<Image>().sprite = elementSelect;
                           
        int positionWall = cellMap.GetComponent<ButtonInfo>().Row;
        int positionCopumn = cellMap.GetComponent<ButtonInfo>().Column;

        presenter.SetElementMatrix(positionWall, positionCopumn, typeElement);       
    }

    public void ValidarMapa(){
        bool esValido = presenter.ValidationMap();
        if(esValido)
            ObtenerCodificacionDelNivel();
        else
            Debug.Log("Nivel no valido");    
    }

    public void ObtenerCodificacionDelNivel(){
        string levelString = presenter.GenerationMap();
        MostrarCodigoQR(levelString);
    }

    public void MostrarPanelQR(){
        panelPrincipal.SetActive(false);
        panelQR.SetActive(true);    
    }

    public void MostrarPanelPrincipal(){
        panelPrincipal.SetActive(true);
        panelQR.SetActive(false);    
    }

    public void MostrarCodigoQR(string qrData){
        Debug.Log(qrData);
        qrCodeGeneartor.GenerateQR(qrData);
    }
}
