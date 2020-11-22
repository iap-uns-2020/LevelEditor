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
    private IPresentadorEditor presenter;
    private int row, column;

    public QRCodeGenerator qrCodeGeneartor;

    // Start is called before the first frame update
    void Start()
    {
        allButton = new List<GameObject>();
        typeElement = ' ';
        presenter = new PresentadorEditor(row, column);

        row = (int)numberRow.value;
        column = (int)numberColumn.value;
       
        foreach (Button button in bottonObject)
             button.onClick.AddListener(() => LlamadaDesdeBoton(button.GetComponent<ObjectSelector>(), button.GetComponent<Image>().sprite));

        LlamadaDesdeBoton(bottonObject[bottonObject.Length-1].GetComponent<ObjectSelector>(), bottonObject[4].GetComponent<Image>().sprite);
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

    public void LlamadaDesdeBoton(ObjectSelector o, Sprite s)
    {
        elementSelect = s;
        typeElement = o.ObjectType;
    }

    public void SetMap()
    {
        DeleteMap();
        CreateMap();
    }

    private void DeleteMap()
    {      
       foreach (GameObject lc in allButton)
            Destroy(lc);
          
       allButton.Clear();
    }

    private void CreateMap()
    {
        presenter.InicializarMapa(row, column);
        GridLayoutGroup gridLayoutMap = layoutMap.gameObject.GetComponent<GridLayoutGroup>();
        gridLayoutMap.cellSize = new Vector2(gridLayoutMap.GetComponent<RectTransform>().rect.width/column, gridLayoutMap.GetComponent<RectTransform>().rect.height / row);
        gridLayoutMap.constraintCount = row;
        elementSelect = bottonObject[4].GetComponent<Image>().sprite;


        for (int i = 0; i <row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                GameObject celdaMapa = Instantiate(cell, layoutMap);
                allButton.Add(celdaMapa);
                celdaMapa.GetComponent<ButtonInfo>().Row = i;
                celdaMapa.GetComponent<ButtonInfo>().Column = j;
                celdaMapa.GetComponent<Button>().GetComponent<Image>().sprite = elementSelect;
                celdaMapa.GetComponent<Button>().onClick.AddListener(() =>UnaFuncion(celdaMapa));
            }
        }

    }

    public void UnaFuncion(GameObject celdaMapa)
    {
        celdaMapa.GetComponent<Button>().GetComponent<Image>().sprite = elementSelect;
                           
        string posicionDelMapa = celdaMapa.GetComponentInChildren<Text>().text;

        int posFila = celdaMapa.GetComponent<ButtonInfo>().Row;
        int posColumna = celdaMapa.GetComponent<ButtonInfo>().Column;

        presenter.EstablecerElementoMatriz(posFila, posColumna, typeElement);       
    }

    public void ValidarMapa(){
        bool esValido = presenter.ValidoMapa();
        if(esValido)
            ObtenerCodificacionDelNivel();
        else
            Debug.Log("Nivel no valido");    
    }

    public void ObtenerCodificacionDelNivel(){
        string levelString = presenter.GenerarCadena();
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
