using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationButtonClick : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        button.SetActive(!Player_Controller.playing);
    }

    public void OnButtonPress(){
        SceneChanger.ChangeScene("JetPackCustomization");
    }
}
