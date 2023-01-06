using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
        
    // destroy when past left edge of the screen (camera)
    if (transform.position.x < -25) {
      Destroy(gameObject);
    }
    else {

      // scroll based on SkyscraperSpawner static variable, speed
      transform.Translate(-DynamicComponent.speed * Time.deltaTime, 0, 0, Space.World);
    }
  }

  void OnTriggerEnter(Collider other) {
    Player_Controller player = other.gameObject.GetComponent<Player_Controller>();
    if (player != null) {
      player.bounce();
      Destroy(gameObject);
    }
    else{
      // Debug.Log(other.gameObject);
    }
    
  }
}
