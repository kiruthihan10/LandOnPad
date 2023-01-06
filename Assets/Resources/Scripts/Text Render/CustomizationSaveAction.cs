using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationSaveAction : MonoBehaviour
{
    public Slider acceleartion;
    public Slider damage;
    public GameObject button;
    public Jetpack jetpack;
    // Start is called before the first frame update
    void Start()
    {
        jetpack = new Jetpack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick() {
        jetpack.updateAcceleration((float)acceleartion.value*Jetpack.getMaxAcceleration());
        jetpack.updateDamage((float)damage.value*Jetpack.getMaxDamage());
        SceneChanger.ChangeScene("SampleScene");
    }
}
