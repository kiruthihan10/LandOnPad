using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using Random=UnityEngine.Random;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject playerobject;

    const float scale = 0.3f;

    void Start()
    {
        StartCoroutine(SpawnPlanes());
    }

    void Update()
    {
        
    }

    // private float expectedHeightAtTime(float time, Rigidbody rbparam) {
    //     Debug.Log("Called");
    //     double vSquared = Math.Pow(rbparam.velocity.y,2);
    //     // Debug.Log(vSquared);
    //     float heightDifference = rbparam.position.y - JumpPadsSpawner.positionY;
    //     // Debug.Log(heightDifference);
    //     double uSquared = vSquared - 2 * (-Jetpack.getAcceleration()) * (heightDifference);
    //     // Debug.Log(uSquared);
    //     float staringVerticalSpeed = (float)(Math.Sqrt( uSquared));
    //     // Debug.Log(staringVerticalSpeed);
    //     float timeForOneBounce = -2*staringVerticalSpeed/(-Jetpack.getAcceleration());
    //     float lastBounceTime = time%timeForOneBounce;
    //     return rbparam.velocity.y*(lastBounceTime) + JumpPadsSpawner.positionY + 1/2 * (-Jetpack.getAcceleration()) * (float)Math.Pow(lastBounceTime,2);
    // }

    // private float verticalSpeedCalculation(int staring_Height, int staring_x ) {
    //     Debug.Log(staring_Height);
    //     Player_Controller player = playerobject.GetComponent<Player_Controller>();
    //     Rigidbody rb = playerobject.GetComponent<Rigidbody>();
    //     float horizontalDistance = staring_x-(-8);
    //     float timeForCollision = horizontalDistance/Plane.horizontalSpeed;
    //     float heightAtCollision = this.expectedHeightAtTime(timeForCollision, rb);
    //     Debug.Log(heightAtCollision);
    //     return (staring_Height-heightAtCollision)/timeForCollision;
    // }

    // IEnumerator SpawnPlanes() {
	// 	while (true) {
    //         if (Player_Controller.playing) {

    //             // instantiate a random airplane past the right egde of the screen, facing left
    //             // int staring_Height = Random.Range(6, -6);
    //             int staring_Height = 0;
    //             int staring_x = 26;
    //             GameObject gameObject = Instantiate(
    //                 prefabs[Random.Range(0, prefabs.Length)],
    //                 new Vector3(staring_x, staring_Height, 0),
    //                 Quaternion.Euler(-90f, -90f, 0f));
    //             gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale , new Vector3(0.3f, 0.3f, 0.3f));
    //             Plane plane = gameObject.GetComponent<Plane>();
    //             plane.setVerticalSpeed(this.verticalSpeedCalculation(staring_Height, staring_x));
    //         }
	// 		// pause this coroutine for 3-10 seconds and then repeat loop
	// 		yield return new WaitForSeconds(Random.Range(3,6));
    //   // yield return new WaitForSeconds(100);
    //     }
    // }

    IEnumerator SpawnPlanes() {
        const int starting_x = 26;
        float horizontalSpeed = Plane.horizontalSpeed;
        float verticalSpeed = Plane.horizontalSpeed;
        float horizontalDistance = starting_x - (-8);
        float timeForImpact = horizontalDistance/horizontalSpeed;
        float verticalDisplacement = verticalSpeed*timeForImpact;
        Rigidbody rb = playerobject.GetComponent<Rigidbody>();
        bool Done = true;
        while (Done)  {
            if (Player_Controller.playing) {
                GameObject gameObject = Instantiate(
                    prefabs[Random.Range(0, prefabs.Length)],
                    new Vector3(starting_x, rb.position.y - verticalDisplacement , 0),
                    Quaternion.Euler(-90f, -90f, 0f));
                Plane plane = gameObject.GetComponent<Plane>();
                plane.transform.localScale = new Vector3(scale,scale,scale);
                // plane.setVerticalSpeed(verticalSpeed);
                Done = false;
            }
            yield return new WaitForSeconds(Random.Range(5,10));
        }
    }
}
