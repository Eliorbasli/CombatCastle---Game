using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Mortar_80mm : MonoBehaviour {

  
    public AudioClip explosionSound;
    private AudioSource myAudio;
    public float lowPitchRange = .75F;
    public float highPitchRange = 1.5F;
    public GameObject crater;
    public Transform craterLocation;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        Destroy(gameObject, 8f);
    }

    // Use this for initialization
    void Start () {

        if(crater != null)
        {
            Invoke("PlaceCrater", .3f);
        }
        
        myAudio.clip = explosionSound;
        myAudio.pitch = Random.Range(lowPitchRange, highPitchRange);
        myAudio.Play();
	}
	
    private void PlaceCrater()
    {
        Instantiate(crater, craterLocation.position, Quaternion.identity);
    }
	
}
