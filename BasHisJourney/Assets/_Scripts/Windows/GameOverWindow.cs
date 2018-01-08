using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWindow : GenericWindow
{
    public override void Close()
    {
        base.Close();

    }

    public void OnNext()
    {
        Manager.Open(0);
    }

}
