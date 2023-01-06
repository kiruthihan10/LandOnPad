using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMainMenu : MonoBehaviour
{
    public void OnButtonPress(){
        SceneChanger.ChangeScene("SampleScene");
    }
}
