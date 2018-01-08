using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject Prefab;
    public Camera MainCamera;
    public bool objectWeSelect = true;
    public string[] Walls;
    public int Timer = 0;

    private Color startColor;
    private bool prefabAlive = true;
    public static GameObject obj, prefab;

    // Use this for initialization
    public void Awake()
    {
        MainCamera = Camera.main;
        obj = GameObject.Find("Wall");
        prefab = Instantiate(Prefab, obj.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var objectRenderer = SelectObject().GetComponent<Renderer>();
            startColor = objectRenderer.material.color;            
            SetHudActive();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            var objectRenderer = SelectObject().GetComponent<Renderer>();
            objectRenderer.material.color = startColor;
        }


    }

    private void SetHudActive()
    {
        
            obj = SelectObject();
            if (prefabAlive)
            {
                prefabAlive = false;
                prefab.transform.SetParent(obj.transform);
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                prefab.transform.SetParent(obj.transform);
                prefab.transform.position = obj.transform.position;
            }


    }

    //Function for returning the object that is selected by mouse
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
        objectWeSelect = true;
    }
}
