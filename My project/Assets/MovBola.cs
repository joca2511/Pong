using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBola : MonoBehaviour
{
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Bola(){
        float rand = Random.Range(0,2);
        if (rand<1){
            rb2d.AddForce(new Vector2(20,-15));
        }
        else{
            rb2d.AddForce(new Vector2(-20,-15));
        }
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Bola",2);
    }
    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }
    void ReBola(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void ReJogo(){
        ReBola();
        Invoke("Bola", 1);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
