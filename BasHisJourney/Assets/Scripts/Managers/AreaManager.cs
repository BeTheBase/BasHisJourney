using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public GameObject[] BlocksLeft, BlocksRight;
    public GameObject left, right;
    public Vector3 NewPositionLeft, NewPositionRight;
    public Vector3[] StartPosition;
    public float BlockSpeed = 6f;
    public bool OnOff = false;

    public string currentStateLeft, currentStateRight;

    public void Awake()
    {
//         for (int i = 0; i < StartPosition.Length; i++)
//         {
//                StartPosition[i] = BlocksLeft[i].transform.position;
//         }

    }

    public void Start()
    {
        ChangeTarget();
    }

    public void ChangeTarget()
    {

        if (currentStateLeft == "Moving To Position 1")
        {
            currentStateLeft = "Moving To Position 2";
            NewPositionLeft.x = right.transform.position.x;
        }
        else if (currentStateLeft == "Moving To Position 2")
        {
            currentStateLeft = "Moving To Position 1";
            NewPositionLeft.x = left.transform.position.x;
        }
        else if (currentStateLeft == "")
        {
            currentStateLeft = "Moving To Position 2";
            NewPositionLeft.x = right.transform.position.x;
        }

        if (currentStateRight == "Moving To Position 1")
        {
            currentStateRight = "Moving To Position 2";
            NewPositionRight.x = right.transform.position.x;
        }
        else if (currentStateRight == "Moving To Position 2")
        {
            currentStateRight = "Moving To Position 1";
            NewPositionRight.x = left.transform.position.x;
        }
        else if (currentStateRight == "")
        {
            currentStateRight = "Moving To Position 2";
            NewPositionRight.x = right.transform.position.x;
        }

        Invoke("ChangeTarget", 2f);


    }

   /* IEnumerator ChangePosition(GameObject[] blocks)
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].transform.position.x >= right.transform.position.x)
            {
                NewPosition[i].x = left.transform.position.x;
            }
            if (blocks[i].transform.position.x <= left.transform.position.x)
            {
                NewPosition[i].x = right.transform.position.x;
            }
            
        }
    }*/

    public void MoveTheBlocks(GameObject[] blocks, bool value)
    {
        foreach (GameObject b in blocks)
        {
            if (value)
            {

                    b.transform.position = Vector3.Lerp(new Vector3(b.transform.position.x, b.transform.position.y, 0),
                        new Vector3(NewPositionLeft.x, b.transform.position.y, 0),
                        Mathf.SmoothStep(0f, 1f,
                            BlockSpeed * Time.deltaTime
                        ));
                Debug.Log(NewPositionLeft);

            }
            else
            {

                    b.transform.position = Vector3.Lerp(new Vector3(b.transform.position.x, b.transform.position.y, 0),
                        new Vector3(NewPositionRight.x, b.transform.position.y, 0),
                        Mathf.SmoothStep(0f, 1f,
                            BlockSpeed * Time.deltaTime
                        ));

                Debug.Log(NewPositionRight);

            }

        }
    }
    public void FixedUpdate()
    {
        if (OnOff)
        {
            MoveTheBlocks(BlocksLeft, true);
            MoveTheBlocks(BlocksLeft, false);
        }
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
