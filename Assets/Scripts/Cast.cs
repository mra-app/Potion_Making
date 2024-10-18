using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cast : MonoBehaviour
{
    public GameObject head;
    public event Action ThingHappened;

    public void Accio(){
        ThingHappened?.Invoke();
    }

}
