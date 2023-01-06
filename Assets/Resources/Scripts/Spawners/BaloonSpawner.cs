using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBaloons());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBaloons() {
		while (true) {

			// instantiate a random airplane past the right egde of the screen, facing left
      if (Player_Controller.playing) {
        Instantiate(
                prefabs[Random.Range(0, prefabs.Length)],
                new Vector3(26, player.transform.position.y, 0),
				Quaternion.Euler(-90f, -90f, 0f));
      }
			// pause this coroutine for 3-10 seconds and then repeat loop
			// yield return new WaitForSeconds(Random.Range(0, 2));
      yield return new WaitForSeconds(Random.Range(1.5f, 2));
      // yield return new WaitForSeconds(100);
        }
    }
}
