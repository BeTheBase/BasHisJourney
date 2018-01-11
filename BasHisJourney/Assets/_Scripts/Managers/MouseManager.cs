using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject Prefab;
    public Camera MainCamera;
    public bool ObjectWeSelect = true;
    public string[] Walls;
    public int Timer = 0;

    private Color startColor;
    private bool prefabAlive = true;
    public static GameObject obj, prefab;

    // Use this for initialization
    public void Awake()
    {
        MainCamera = Camera.main;
        obj = GameObject.Find("Fake");
        prefab = Instantiate(Prefab, obj.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {          
            SetHudActive();
        }
    }

    //make the hud for object manipulation active and parent it on the right object
    private void SetHudActive()
    {
        obj = SelectObject();
        if (prefabAlive)
        {
            prefabAlive = false;
            prefab.transform.SetParent(obj.transform);
            prefab.transform.position = obj.transform.position;

            prefab.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            prefab.transform.SetParent(obj.transform);
            prefab.transform.position = obj.transform.position;
        }
    }

    //return the object that is selected by mouse using a raycast
    public GameObject SelectObject()
    {
            Vector2 rayPos = new Vector2(MainCamera.ScreenToWorldPoint(Input.mousePosition).x,
                MainCamera.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
            if (hit)
            {
                if (hit.transform.name == "Wall")
                {
                    return hit.transform.gameObject;
                }
                return null;
            }
            else
            {
                return null;
            }
    }

    IEnumerator OptionTime()
    {
        yield return new WaitForSeconds(10);
        ObjectWeSelect = true;
    }
}
