using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const int defaultDamage = 100;
    private float speed = -10f;
    private int damage = defaultDamage;
    // Start is called before the first frame update
    void Start()
    {
        damage = (int)Jetpack.getDamage();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 15) {
            Destroy(gameObject);
        }
        else {
			// ensure coin moves at the same rate as the skyscrapers do
			transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
		}
    }

    public int getDamage() {
        return damage;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Player_Controller>() == null) {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.Hurt(damage);
                Destroy(gameObject);
            }
            else {
                Baloon baloon = other.gameObject.GetComponent<Baloon>();
                if (baloon != null) {
                    baloon.Hurt(damage);
                    Destroy(gameObject);
                }
                else {
                    Plane plane = other.gameObject.GetComponent<Plane>();
                    if (plane != null) {
                        plane.Hurt(damage);
                        Destroy(gameObject);
                    }
                }
            }
        }
        
        
    }

    public static float getDefaultDamage () {
        return defaultDamage;
    }
}
