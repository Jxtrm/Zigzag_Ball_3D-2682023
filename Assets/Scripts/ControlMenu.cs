using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    public void DirectionChange()
    {
        if (!PlayerControl.instance.startGame)
        {
            PlayerControl.instance.startGame = true;
        }

        PlayerControl.instance.rigthMove = !PlayerControl.instance.rigthMove;
    }
}
