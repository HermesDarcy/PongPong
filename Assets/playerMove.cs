using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Transform iniPos;
    public float speed;
    public Color myColor = Color.white;
    public SpriteRenderer myRenderer;


    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        resetPos();
    }

    // Update is called once per frame
    void Update()
    {
        moveKeys();
    }

    public void resetPos()
    {
        transform.position = new Vector3(7f, 0f, 0f);
        setColor(myColor);
    }

    private void moveKeys()
    {
        // Captura da entrada vertical (seta para cima, seta para baixo, teclas W e S)
        float moveInput = Input.GetAxis("Vertical");        
        // Calcula a nova posição da raquete baseada na entrada e na velocidade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;        
        // Limita a posição vertical da raquete para que ela não saia da tela
         newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);        
        // Atualiza a posição da raquete
        transform.position = newPosition;
    }

    public void setColor(Color color)
    {
        myRenderer.color = color;
    }



}
