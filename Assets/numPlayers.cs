using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numPlayers : MonoBehaviour
{
    

    public void onePlayer()
    {
        SaveControler.Instance.twoPlayers = false;
        SaveControler.Instance.enemyName = "Enemy Name...";
    }

    public void twoPlayers()
    {
        SaveControler.Instance.twoPlayers = true;
        SaveControler.Instance.enemyName = "";
    }



}
