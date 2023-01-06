using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Render : MonoBehaviour
{
    public GameObject player;
    private Text text;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if( player != null ) {
            health = player.GetComponent<Player_Controller>().getRemainingHealth();
        }
        text.text = "Health: " + health;
    }
}
