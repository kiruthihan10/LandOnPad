using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConsumedPowerUp
{
    public Action<Player_Controller> powerUpFunc;
    public Action<Player_Controller> resetPowerUpFunc;
    public Func<Player_Controller, bool> powerUpStartFunc;
    private float timeRemaining = 5;

    public ConsumedPowerUp(Action<Player_Controller> powerUpFunc, Action<Player_Controller> resetPowerUpFunc, Func<Player_Controller, bool> powerUpStartFunc) {
        this.powerUpFunc = powerUpFunc;
        this.resetPowerUpFunc = resetPowerUpFunc;
        this.powerUpStartFunc = powerUpStartFunc;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update(float dt)
    {
        this.timeRemaining -= dt;
    }

    public bool used() {
        return this.timeRemaining < 0;
    }
}
