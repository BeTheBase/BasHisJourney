using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public GameObject[] Blocks;
    public float BlockSpeed = 6f;
    public bool OnOff = false;

    public void MoveTheBlocks(GameObject[] blocks, bool value)
    {
        foreach (GameObject b in blocks)
        {
            b.GetComponent<MovingBlocks>().enabled = value;
        }
    }
    public void FixedUpdate()
    {
        MoveTheBlocks(Blocks, OnOff);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            OnOff = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            OnOff = false; 
        }
    }
}
