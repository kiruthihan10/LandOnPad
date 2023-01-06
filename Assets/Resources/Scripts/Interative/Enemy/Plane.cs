using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Enemy
{
    public static int horizontalSpeed = 10;
    public static int verticalSpeed = 10;
    public Plane(): base(40, 50, horizontalSpeed, verticalSpeed) {

    }

    void Update() {
        base.Update();
        // if (transform.position.y > 6 || transform.position.y < -6) {
        //     Destroy(gameObject);
        // }
        // Debug.Log(transform.position.y);
    }

    public void setVerticalSpeed(float verticalSpeed) {
        base.setVerticalSpeed(verticalSpeed);
    }
}
