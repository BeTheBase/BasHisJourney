using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public GameObject[] Blocks;
    public GameObject left, right;
    public Vector3[] StartPosition;
    public float BlockSpeed = 6f;
    public bool OnOff = false;

    public void Awake()
    {
        foreach (GameObject b in Blocks)
        {
            for (int i = 0; i < StartPosition.Length; i++)
            {
                StartPosition[i] = b.transform.position;
            }

        }
    }

    public void MoveTheBlocks(GameObject[] blocks)
    {
        foreach (GameObject b in blocks)
        {
            b.transform.position = Vector3.Lerp(new Vector3(left.transform.position.x, b.transform.position.y,0),new Vector3(right.transform.position.x, b.transform.position.y, 0),
                Mathf.SmoothStep(0f, 1f,
                    Mathf.PingPong(Time.time / BlockSpeed, 1f)
                ));
        }
    }

    public void FixedUpdate()
    {
        if(OnOff)
            MoveTheBlocks(Blocks);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            OnOff = true;
            foreach (GameObject b in Blocks)
            {
                b.SetActive(true);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            OnOff = false;
            foreach (GameObject b in Blocks)
            {
                b.SetActive(false);
            }
        }
    }
}
