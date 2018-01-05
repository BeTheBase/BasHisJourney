using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameObject: MonoBehaviour
{

    private Color startColor;
    void OnMouseEnter()
    {
        startColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startColor;
    }
	
}
