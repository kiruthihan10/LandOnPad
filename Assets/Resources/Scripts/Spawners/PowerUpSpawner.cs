using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPowerUps() {
		while (true) {
            if (Player_Controller.playing) {
                // instantiate a random airplane past the right egde of the screen, facing left
                GameObject gameObject = Instantiate(
                    prefabs[Random.Range(0, prefabs.Length)],
                    new Vector3(26, player.transform.position.y, 0),
                    Quaternion.Euler(0, 0, 0f));
            }
			// pause this coroutine for 3-10 seconds and then repeat loop
			// yield return new WaitForSeconds(Random.Range(0, 2));
            yield return new WaitForSeconds(Random.Range(10, 15));
        }
    }
}
