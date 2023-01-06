using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreButton : MonoBehaviour
{
    public GameObject button;

    void Start()
    {
    }

    public void Update () {
        button.SetActive(!Player_Controller.playing);
    }

    public void OnButtonPress(){
        SceneChanger.ChangeScene("HighScoreScene");
    }
}
