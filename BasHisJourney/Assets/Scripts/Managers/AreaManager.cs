using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public GameObject[] BlocksLeft, BlocksRight;
    public GameObject left, right;
    public Vector3[] StartPosition;
    public float BlockSpeed = 6f;
    public bool OnOff = false;

    public void Awake()
    {
//         for (int i = 0; i < StartPosition.Length; i++)
//         {
//                StartPosition[i] = BlocksLeft[i].transform.position;
//         }

    }

    public void MoveTheBlocks(GameObject[] blocks, bool _left)
    {
        foreach (GameObject b in blocks)
        {
            if (_left)
            {
                b.transform.position = Vector3.Lerp(new Vector3(left.transform.position.x, b.transform.position.y, 0),
                    new Vector3(right.transform.position.x, b.transform.position.y, 0),
                    Mathf.SmoothStep(0f, 1f,
                        Mathf.PingPong(Time.time / BlockSpeed, 1f)
                    ));
            }
            else
            {
                b.transform.position = Vector3.Lerp(new Vector3(right.transform.position.x, b.transform.position.y, 0),
                    new Vector3(left.transform.position.x, b.transform.position.y, 0),
                    Mathf.SmoothStep(0f, 1f,
                        Mathf.PingPong(Time.time / BlockSpeed, 1f)
                    ));
            }
        }
    }
    public void FixedUpdate()
    {
        if (OnOff)
        {
            MoveTheBlocks(BlocksLeft, true);
            MoveTheBlocks(BlocksRight, false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            OnOff = true;
            foreach (GameObject b in BlocksLeft)
            {
                b.SetActive(true);
            }
            foreach (GameObject b in BlocksRight)
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
            foreach (GameObject b in BlocksLeft)
            {
                b.SetActive(false);
            }
            foreach (GameObject b in BlocksRight)
            {
                b.SetActive(false);
            }
        }
    }
}
