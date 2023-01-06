using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadsSpawner : MonoBehaviour
{

  public GameObject[] prefabs;
  public static int positionY = -4;
  // Start is called before the first frame update
  void Start()
  {
      StartCoroutine(SpawnJumpPads());
  }

  // Update is called once per frame
  void Update()
  {
      
  }
  IEnumerator SpawnJumpPads() {
    while (true) {

      // instantiate a random airplane past the right egde of the screen, facing left
      if (Player_Controller.playing) {
        Instantiate(
          prefabs[Random.Range(0, prefabs.Length)],
          new Vector3(26, positionY, 0),
          Quaternion.Euler(-90f, -90f, 0f));
      }
      // pause this coroutine for 3-10 seconds and then repeat loop
      yield return new WaitForSeconds(Random.Range(0, 2));
      // yield return new WaitForSeconds(100);
    }
	}
}
