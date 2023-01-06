using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonClick : MonoBehaviour
{
    public GameObject button;
    public GameObject player;

    public void Update () {
        button.SetActive(!Player_Controller.playing);
    }
    public void OnButtonPress(){
        Player_Controller.playing = true;
        player.gameObject.GetComponent<Player_Controller>().reset();
    }
}
