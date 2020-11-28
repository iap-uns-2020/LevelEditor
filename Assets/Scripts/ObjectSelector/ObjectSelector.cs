using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public abstract class ObjectSelector : MonoBehaviour
    {
        private char objectType;

        public char ObjectType { get => objectType; set => objectType = value; }
    }
