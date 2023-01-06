using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class Player_Controller : MonoBehaviour
{

    //Deafult Values
    private const float defaultAccelaration = 10.0f;
    private const float defaultFuel = 100;
    private const float defaultJetFuelConsumptionRate = 70;
    private const float defaultJetFuelRefillRate = 40;
    private const int defaultHealth = 100;
    private const int MaxBounceSpeed = 20;
    private const float defaultBulletFuelCost = 20;

    //Static Variables
    private float acceleration = defaultAccelaration;
    public static bool playing = false;
    public static HighScore highscore;

    private int killCount;
    private Rigidbody rb;
    public ParticleSystem explosion;
    public AudioSource explosionSound;
    private float horizontalSpeed;
    private float verticalSpeed; 
    private bool usingJetPack;
    private float fuel;
    private float jetFuelConsumptionRate;
    private float jetFuelRefillRate;
    private int health;
    private float score;
    private float bulletFuelCost;
    // private Gun gun;
    public GameObject[] prefabs;
    private Queue<ConsumedPowerUp> powerUps = new Queue<ConsumedPowerUp>();
    private Jetpack jetpack;

    public AudioSource shootingAudio;

    // Start is called before the first frame update
    public void Start() {
        shootingAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        highscore = new HighScore();
        jetpack  = new Jetpack();
        reset();
    }

    public float expectedHeightAtTime(float time) {
        double vSquared = Math.Pow(rb.velocity.y,2);
        float staringVerticalSpeed = (float)(Math.Sqrt( vSquared - 2 * acceleration * (rb.position.y - JumpPadsSpawner.positionY)));
        float timeForOneBounce = 2*staringVerticalSpeed/acceleration;
        return rb.velocity.y*(time%timeForOneBounce);
    }

    public Rigidbody getRB() {
        return rb;
    }

    private float fuelUpdate() {
        return jetFuelConsumptionRate * Time.deltaTime;
    }

    private void forceUpdate() {
        Vector3 gravity;
        if (usingJetPack & (fuel > 0))
        {
            gravity = acceleration * Vector3.up;
            fuel -= jetFuelConsumptionRate * Time.deltaTime;
        }
        else
        {
            gravity = acceleration * Vector3.down;
            fuel += jetFuelRefillRate * Time.deltaTime;
            fuel = Math.Min(fuel , defaultFuel);
        }
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    private void shootGun() {
        if (fuel > bulletFuelCost) {
            Instantiate(
                prefabs[Random.Range(0, prefabs.Length)],
                rb.position,
                Quaternion.Euler(0, 0, 90)
            );
            shootingAudio.Play(0);
            fuel -= bulletFuelCost;
        }
    }

    void powerUpUpdate() {
        if (this.powerUps.Count > 0) {
            foreach (ConsumedPowerUp powerup in this.powerUps.ToArray())
            {
                powerup.powerUpFunc(this);
                powerup.Update(Time.deltaTime);
            }
            ConsumedPowerUp currentPowerup = this.powerUps.Peek();
            while (currentPowerup.used() && this.powerUps.Count > 0) {
                // Debug.Log(this);
                // Debug.Log(currentPowerup);
                currentPowerup.resetPowerUpFunc(this);
                this.powerUps.Dequeue();
                if (this.powerUps.Count == 0) {
                    break;
                }
                currentPowerup = this.powerUps.Peek();
            }
        }
    }

    public void fuelReset() {
        this.fuel = 100;
    }

    // Update is called once per frame
    void Update() {
        if (playing) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                usingJetPack = true;
            }
            else if(Input.GetKeyUp(KeyCode.Space))
            {
                usingJetPack = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                shootGun();
            }
            forceUpdate();
            powerUpUpdate();
            if (rb.position.y < -6) {
                // playing = false;
                gameOver();
            } else if (rb.position.y > 5) {
                rb.position = new Vector3(rb.position.x, 5, rb.position.z);
            }
            if(health<=0) {
                gameOver();
            }
            score += Time.deltaTime;
        }
        
        
    }

    public int getRemainingFuel() {
        // Debug.Log(fuel);
        return Convert.ToInt32(fuel);
    }

    public int getRemainingHealth() {
        return health;
    }

    public void bounce() {
        // rb.velocity.Set(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
        if (rb.velocity.y < 0) {
            rb.velocity = new Vector3(rb.velocity.x, Math.Min(-rb.velocity.y, MaxBounceSpeed), rb.velocity.z);
        }
        else {
            rb.velocity = new Vector3(rb.velocity.x, Math.Min(2 * rb.velocity.y, MaxBounceSpeed), rb.velocity.z);
        }
        
    }

    public void damage(int damage) {
        this.health -= damage;
    }

    public void addPowerUp(ConsumedPowerUp powerUp) {
        if (playing) {
            if (!powerUp.powerUpStartFunc(this)) {
                this.powerUps.Enqueue(powerUp);
            }
        } 
    }

    public void setJetFuelConsumptionRate(float jetFuelConsumptionRate) {
        this.jetFuelConsumptionRate = jetFuelConsumptionRate;
    }

    public void resetJetFuelConsumptionRate() {
        jetFuelConsumptionRate = defaultJetFuelConsumptionRate;
    }

    public void freezeFuel() {
        this.jetFuelConsumptionRate = 0;
        this.jetFuelRefillRate = 0;
    }

    public void unFreezeFuel() {
        jetFuelConsumptionRate = defaultJetFuelConsumptionRate;
        jetFuelRefillRate = defaultJetFuelRefillRate;
    }
    
    public void setHealth(int health = defaultHealth) {
        this.health = health;
    }

    public void positionReset() {
        rb.position = new Vector3(-8,0,0);
    }
    
    public void reset() {
        rb.position = new Vector3(-8,0,0);
        rb.velocity = new Vector3(0,0,0);
        horizontalSpeed = 0;
        verticalSpeed = 0;
        usingJetPack = false;
        fuel = defaultFuel;
        // jetFuelConsumptionRate = defaultJetFuelConsumptionRate;
        jetFuelConsumptionRate = jetpack.getCurrentFuelConsumptionForAcceleration();
        jetFuelRefillRate = defaultJetFuelRefillRate;
        health = defaultHealth;
        killCount = 0;
        score = 0;
        // bulletFuelCost = defaultBulletFuelCost;
        bulletFuelCost = jetpack.getCurrentFuelConsumptionForDamage();
        acceleration = Jetpack.getAcceleration();
    }

    public int getCurrentScore() {
        return (int)score;
    }

    private void gameOver() {
        int[] highScores = HighScore.getHighScores();
        highscore.addScore(getCurrentScore());
        playing = false;
    }

    public static float getDefaultAccelaration () {
        return defaultAccelaration;
    }

    public static float defaultAccelarationPerFuel () {
        return defaultAccelaration/defaultJetFuelConsumptionRate;
    }

    public static float defaultBulletPerFuel () {
        return Bullet.getDefaultDamage()/defaultBulletFuelCost;
    }
}