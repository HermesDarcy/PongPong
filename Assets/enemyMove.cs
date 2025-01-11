using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float speed;
    public bool auto=true;
    private Rigidbody2D rb;
    private GameObject ball;
    public Color myColor = Color.white;
    public SpriteRenderer myRenderer;



    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        ball = GameObject.Find("BallManager");
        resetPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(auto) 
        {
            if (ball != null)
            {
                float targetY = Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f); // Limita a posição Y
                Vector2 targetPosition = new Vector2(transform.position.x, targetY);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed); // Move gradualmente para a posição Y da bola
            }
            else
            {
                Debug.Log("não achou ball");
            }

        }
        else
        {
            moveKeys();
        }
            


    }

    public void resetPos()
    {
        transform.position = new Vector3(-7f,0f,0f);
        setColor(myColor);
    }

    private void moveKeys()
    {
        float moveInput = 0f;
        // Captura da entrada vertical (seta para cima, seta para baixo, teclas W e S)
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = 1f;
        }
        else if(Input.GetKey(KeyCode.Z))
        {
            moveInput = -1f;
        }
        //float moveInput = Input.GetAxis("Vertical");
        // Calcula a nova posição da raquete baseada na entrada e na velocidade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        // Limita a posição vertical da raquete para que ela não saia da tela
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);
        // Atualiza a posição da raquete
        transform.position = newPosition;
    }


    public void isNotAuto()
    {
        auto = false;
    }
    public void isAuto()
    {
        auto = true;
    }


    public void setColor(Color color)
    {
        myRenderer.color = color;
    }


}
