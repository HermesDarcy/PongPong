using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public BallManager ballManager;
    public playerMove player;
    public enemyMove enemy;
    public TMP_Text textPlayer, textEnemy, textWin;
    public GameObject textStart;
    private int enemyPoint, playerPoint;
    private bool inGame = false;
    public int maxPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        
        maxPoints = 5;
        resetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(inGame)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
            }

            if (enemyPoint >= maxPoints)
            {
                if(SaveControler.Instance.twoPlayers)
                {
                    textWin.text = SaveControler.Instance.enemyName +  " WIN";
                }
                else
                {
                    textWin.text = "Enemy WIN";
                }
                
                textWin.gameObject.SetActive(true);
                Invoke("goMenu", 3f);
                
            }

            if (playerPoint >= maxPoints)
            {
                textWin.text = SaveControler.Instance.playerName +   " WIN";
                textWin.gameObject.SetActive(true);
                Invoke("goMenu", 3f);

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                textStart.SetActive(false);
                
               
                textWin.gameObject.SetActive(false);
                resetPos();
                ballManager.startGame();
                inGame = true;
            }

        }

        
        

    }


    private void resetGame()
    {
        ballManager.transform.position = new Vector3(0f,0f,0f);
        // busca dados no SaveControler
        player.myColor  =SaveControler.Instance.colorPlayer;
        enemy.myColor = SaveControler.Instance.colorEnemy;
        textPlayer.color = SaveControler.Instance.colorPlayer;
        textEnemy.color = SaveControler.Instance.colorEnemy;
        if (SaveControler.Instance.twoPlayers)
        {
            enemy.auto = false;
        }
        
        player.resetPos();
        enemyPoint = 0;
        playerPoint = 0;
        inGame = false;
       
        textStart.SetActive(true);
        placar();
    }

    private void resetPos()
    {
        enemy.resetPos();
        player.resetPos();
    }



    public void placar(string gg="")
    {
        if(gg=="")
        {
            textPlayer.text = "00";
            textEnemy.text = "00";
        }
        else if(gg =="P")
        {
            playerPoint++;
            resetPos();
        }
        else if(gg == "E")
        {
            enemyPoint++;
            resetPos();
        }
        textPlayer.text = playerPoint.ToString();
        textEnemy.text = enemyPoint.ToString();

    }


    private void goMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }





}
