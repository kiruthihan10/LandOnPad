using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicComponent : MonoBehaviour
{
    public static float speed = 10f;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    protected void Update()
    {
        if (transform.position.x < -15) {
            Destroy(gameObject);
        }
        else {

			// ensure coin moves at the same rate as the skyscrapers do
			transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
		}
    }
}
