using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcceleartionEvent : MonoBehaviour
{
    public Slider slider;
    public Jetpack jetpack;
    public Text text;
    // Start is called before the first frame update
    public void Start()
    {
        jetpack = new Jetpack();
        slider.value = Jetpack.getAcceleration()/Jetpack.getMaxAcceleration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange (float value) {
        float acceleartion = slider.value*Jetpack.getMaxAcceleration();
        float jetFuelConsumptionRate = Jetpack.getFuelConsumptionForAcceleration(acceleartion);
        // jetpack.updateAcceleration((float)acceleartion);
        text.text = (int)jetFuelConsumptionRate + " FUEL / SEC";
    }
}
