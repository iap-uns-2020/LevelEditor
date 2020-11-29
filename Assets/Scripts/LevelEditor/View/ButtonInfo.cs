using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInfo : MonoBehaviour
{
    private int fila, columna;

    public int Row { get => fila; set => fila = value; }
    public int Column { get => columna; set => columna = value; }
}
