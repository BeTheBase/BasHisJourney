using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CSharpPickup : MonoBehaviour
{
    public GameObject ScriptPanel;
    public Image RightScriptImage;
    public Sprite[] ScriptImages;
    public int SceneIndex;

    private int sceneIndex;

    void Awake()
    {
        ScriptPanel.SetActive(false);
    }

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneIndex = sceneIndex;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "CSharp")
        {
            ScriptPanel.SetActive(true);
            ShowRightScript();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "CSharp")
        {
            ScriptPanel.SetActive(false);
        }
    }

    public void ShowRightScript()
    {
        RightScriptImage.sprite = ScriptImages[SceneIndex];
    }
}
