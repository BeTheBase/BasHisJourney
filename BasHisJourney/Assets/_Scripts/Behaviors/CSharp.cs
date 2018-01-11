using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharp : MonoBehaviour
{
    public float Speed = 200f;

    void Update()
    {
        transform.Rotate(0, -Speed * Time.deltaTime, 0);
    }
}
