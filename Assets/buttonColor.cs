using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonColor : MonoBehaviour
{
    public Button button;
    public Image image;
    public bool isplayer;


    public void OnButtonClick()
    {
        image.color = button.colors.normalColor;
        
        if (isplayer )
        {
            SaveControler.Instance.colorPlayer = image.color;
        }
        else
        {
            SaveControler.Instance.colorEnemy = image.color;
        }
    }






}
