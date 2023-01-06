using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int damage;
    private int life;
    private float horizontalSpeed;
    private float verticalSpeed;

    public Enemy(int damage, int life = 100, float horizontalSpeed = 0, float verticalSpeed = 0) {
        this.damage = damage;
        this.life = life;
        this.horizontalSpeed = horizontalSpeed;
        this.verticalSpeed = verticalSpeed;
    }

    public void setVerticalSpeed(float verticalSpeed) {
        this.verticalSpeed = verticalSpeed;
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
			transform.Translate(0, -horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime);
		}
    }

    public void OnTriggerEnter(Collider other) {
        Player_Controller player = other.gameObject.GetComponent<Player_Controller>();
        if (player != null) {
            player.damage(damage);
            Destroy(gameObject);
        }
    }

    public void Hurt(int damage) {
        this.life -= damage;
        if (this.life <= 0) {
            Destroy(gameObject);
            // explosionAudio.Play(0);
            SoundLoaders.playExplosion();
        }
    }
}
