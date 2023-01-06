using UnityEngine;
using System.Collections;

public class Skyscraper : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// destroy when past left edge of the screen (camera)
		if (transform.position.x < -25) {
			Destroy(gameObject);
		}
		else {

			// scroll based on SkyscraperSpawner static variable, speed
			transform.Translate(-DynamicComponent.speed * Time.deltaTime, 0, 0);
		}
	}

	void OnTriggerEnter(Collider other) {
	}
}
