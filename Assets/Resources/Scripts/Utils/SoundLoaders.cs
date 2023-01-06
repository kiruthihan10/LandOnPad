using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoaders : MonoBehaviour
{
    
    public static AudioSource explosionAudio;
    public static AudioSource shootingAudio;
    // Start is called before the first frame update
    void Start()
    {
        explosionAudio = GetComponent<AudioSource>();
        shootingAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playExplosion() {
        explosionAudio.Play(0);
    }

    public static void playShoot() {
        shootingAudio.Play(0);
    }
}
