using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juiz : MonoBehaviour
{
    public static int Pont1 = 0; // Pontuação do player 1
    public static int Pont2 = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar
    GameObject bola;                 // Referência ao objeto bola

    // Start is called before the first frame update
    void Start()
    {
        bola = GameObject.FindGameObjectWithTag("Bola");
        

    }
    public static void Pontuar (string parede) {
        if (parede == "ParedeDir")
        {
            Pont1++;
        } else
        {
            Pont2++;
        }
    }
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + Pont1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + Pont2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "REINICIAR"))
        {
            Pont1 = 0;
            Pont2 = 0;
            bola.SendMessage("ReJogo", null, SendMessageOptions.RequireReceiver);
        }
        if (Pont1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "P1 Ganha!");
            bola.SendMessage("ReBola", null, SendMessageOptions.RequireReceiver);
        } else if (Pont2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "P2 Ganha");
            bola.SendMessage("ReBola", null, SendMessageOptions.RequireReceiver);
        } 
}



    // Update is called once per frame
    void Update()
    {
        
    }
}
