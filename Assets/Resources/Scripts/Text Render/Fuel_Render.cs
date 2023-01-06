using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Fuel_Render : MonoBehaviour
{

    public GameObject player;
    private Text text;
    private int fuel;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        if( player != null ) {
            fuel = player.GetComponent<Player_Controller>().getRemainingFuel();
        }
        text.text = "Fuel: " + fuel;
    }
}
