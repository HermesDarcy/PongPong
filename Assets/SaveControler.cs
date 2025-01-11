using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveControler : MonoBehaviour
{

    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;
    public string playerName = string.Empty;
    public string enemyName = "Enemy";
    public bool twoPlayers = false;

    private static SaveControler _instance;
    
    
    // Propriedade estática para acessar a instância
    
    public static SaveControler Instance
    {
        get
        {
            if (_instance == null)
            {
                // Procure a instância na cena
                _instance = FindObjectOfType<SaveControler>();
                // Se não encontrar, crie uma nova instância
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveControler).Name);
                    _instance = singletonObject.AddComponent<SaveControler>();
                }
            }
            return _instance;
        }
    }



    private void Awake()
    {
        // Garanta que apenas uma instância do Singleton exista
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        // Mantenha o Singleton vivo entre as cenas
        DontDestroyOnLoad(this.gameObject);
    }


    



}
