﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.View
{
    public abstract class ObjectTypeSettersAndGettersAsociation : MonoBehaviour
    {
        private char objectType;

        public char ObjectType { get => objectType; set => objectType = value; }
    }
}