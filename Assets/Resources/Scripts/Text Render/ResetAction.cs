using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAction : MonoBehaviour
{
    private Jetpack jetpack;
    public GameObject acclerationManager;
    public GameObject damageManager;
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
        jetpack.reset();
        acclerationManager.GetComponent<AcceleartionEvent>().Start();
        damageManager.GetComponent<DamageEvent>().Start();
        // Debug.Log(acclerationManager.GetComponent<AcceleartionEvent>());
    }
}
