using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Transform iniPos;
    public float speed;
    public Vector2 directions;
    private Rigidbody2D rb;
    public gameManager manager;

    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        speed = Random.Range(5f, 9f);
        int dir1 = Random.Range(-1, 2);
        while(dir1 == 0)
        {
            dir1 = Random.Range(-1, 2);
        }
        int dir2 = Random.Range(-1, 2);
        while (dir2 == 0)
        {
            dir2 = Random.Range(-1, 2);
        }
        //iniPos.position = transform.position;
        rb = GetComponent<Rigidbody2D>();
        directions = new Vector2(speed*dir1, speed*dir2);
        resetPos();
    }


    public void resetPos()
    {
        transform.position = new Vector3(0f,0f,0f);
        rb.velocity = directions;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("wall"))
        {

            rb.velocity = new Vector2(rb.velocityX, -rb.velocityY);

        }

        if (collision.gameObject.CompareTag("player")  || collision.gameObject.CompareTag("enemy"))
        {
            rb.velocity = new Vector2(-rb.velocityX, rb.velocityY);


        }

        if (collision.gameObject.CompareTag("goalPlayer"))
        {
            manager.placar("P");
            StartCoroutine(initPos());

        }
        else if (collision.gameObject.CompareTag("goalEnemy"))
        {
            manager.placar("E");
            StartCoroutine(initPos());
        }


        //Debug.Log(collision.gameObject.name);
    }

    IEnumerator initPos()
    {
        resetPos();
        rb.velocity = Vector2.zero;
        int t = 5;
        for(int i = 0; i < t; i++)
        {
            yield return new WaitForSeconds(.5f);
        }
        startGame();
    }

}
