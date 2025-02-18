using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gols : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "Bola")
        {
            string wallName = transform.name;
            Juiz.Pontuar(wallName);
            hitInfo.gameObject.SendMessage("ReJogo", null, SendMessageOptions.RequireReceiver);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
