using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveNames : MonoBehaviour
{
    public TMP_InputField playerField, enemyField;

    private void Start()
    {
        playerField.onValueChanged.AddListener(playerName);
        enemyField.onValueChanged.AddListener(enemyName);
    }


    public void playerName(string name)
    {
        SaveControler.Instance.playerName = name;
    }

    public void enemyName(string name) 
    {
        SaveControler.Instance.enemyName = name;
    
    }

    

}
