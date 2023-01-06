using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleText : MonoBehaviour
{
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.SetActive(!Player_Controller.playing);
    }
}
