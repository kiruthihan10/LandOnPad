using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEvent : MonoBehaviour
{
    public Slider slider;
    public Jetpack jetpack;
    public Text text;
    // Start is called before the first frame update
    public void Start()
    {
        jetpack = new Jetpack();
        slider.value = Jetpack.getDamage()/Jetpack.getMaxDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange (float value) {
        float damage = slider.value*Jetpack.getMaxDamage();
        float jetFuelConsumptionRate = Jetpack.getFuelConsumptionForDamage(damage);
        // jetpack.updateDamage((float)damage);
        text.text = (int)jetFuelConsumptionRate + " FUEL / Bullet";
    }
}
