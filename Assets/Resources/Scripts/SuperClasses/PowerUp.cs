using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUp : MonoBehaviour
{
    protected float horizontalSpeed;
    protected Action<Player_Controller> powerUpFunc;
    protected Action<Player_Controller> resetPowerUpFunc;
    protected Func<Player_Controller, bool> startPowerUpFunc;

    public PowerUp(
        Func<Player_Controller, bool> startPowerUpFunc,
        Action<Player_Controller> powerUpFunc,
        Action<Player_Controller> resetPowerUpFunc = default(Action<Player_Controller>),
        float horizontalSpeed = 10
        ) {
        this.horizontalSpeed = horizontalSpeed;
        this.powerUpFunc= powerUpFunc;
        this.resetPowerUpFunc = resetPowerUpFunc;
        this.startPowerUpFunc = startPowerUpFunc;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        // destroy when past left edge of the screen (camera)
		if (transform.position.x < -25) {
			Destroy(gameObject);
		}
		else {

			// scroll based on SkyscraperSpawner static variable, speed
			transform.Translate(-this.horizontalSpeed * Time.deltaTime, 0, 0);
		}
    }

    public void OnTriggerEnter(Collider other) {
        Player_Controller player = other.gameObject.GetComponent<Player_Controller>();
        if (player != null) {
            
            player.addPowerUp(new ConsumedPowerUp(powerUpFunc, resetPowerUpFunc, startPowerUpFunc));
            Destroy(gameObject);
        }
    }
}
