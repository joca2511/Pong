using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovJogador : MonoBehaviour
{
    public KeyCode acima = KeyCode.W;
    public KeyCode abaixo = KeyCode.S;
    public float velocidade = 10.0f;
    public float limiteY = 2.25f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity; 
        var pos = transform.position;
        if (gameObject.CompareTag("Player")){
                          
            if (Input.GetKey(acima)) {             
                vel.y = velocidade;
            }
            else if (Input.GetKey(abaixo)) {      
                vel.y = -velocidade;                    
            }
            else {
                vel.y = 0;                          
            }
                                

                       
            if (pos.y > limiteY) {                  
                pos.y = limiteY;                     
            }
            else if (pos.y < -limiteY) {
                pos.y = -limiteY;                    
            }
                           

        }
        else{
            var bolas = GameObject.FindGameObjectsWithTag("Bola"); //deve retornar 2 bolas
            var maisproxima = bolas[0];
            if (bolas[1].transform.position.x>bolas[0].transform.position.x){
                maisproxima = bolas[1];
            }
            if (maisproxima.transform.position.y > gameObject.transform.position.y){
                vel.y = velocidade;
            }
            else if (maisproxima.transform.position.y < gameObject.transform.position.y){
                vel.y = -velocidade;
            }
            else{
                vel.y = 0;
            }
        }
        rb2d.velocity = vel;
        transform.position = pos;
        
    }
}
