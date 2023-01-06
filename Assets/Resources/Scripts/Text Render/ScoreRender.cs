using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRender : MonoBehaviour
{

    public GameObject player;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            text.text = "Score: "+player.GetComponent<Player_Controller>().getCurrentScore();
        }
    }
}
