using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{

    public GenericWindow[] Windows;
    public int CurrentWindowID;
    public int DefaultWindowID;

    public GenericWindow GetWindow(int value)
    {
        return Windows[value];
    }

    private void ToggleVisability(int value)
    {
        var total = Windows.Length;

        for (int i = 0; i < total; i++)
        {
            var window = Windows[i];
            if(i == value)
                window.Open();
            else if(window.gameObject.activeSelf)
                window.Close();
        }
    }

    public GenericWindow Open(int value)
    {
        if (value < 0 || value >= Windows.Length)
            return null;

        CurrentWindowID = value;

        ToggleVisability(CurrentWindowID);

        return GetWindow(CurrentWindowID);
    }

    void Start()
    {
        GenericWindow.Manager = this;
        Open(DefaultWindowID);
    }
}
