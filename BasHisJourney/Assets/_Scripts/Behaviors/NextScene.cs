using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int Scene;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Door")
        {
            GotoNextScene(Scene);
        }
    }

    public void GotoNextScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
