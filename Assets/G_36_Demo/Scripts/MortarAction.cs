using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarAction : MonoBehaviour {
    private AudioSource myAudio;
    public ParticleSystem[] gunFx;
    public AudioClip fireSound;
    public Rigidbody mortarPrefab;
    public Transform mortarBarrelEnd;
    public float shellVelocity = 1000f;
    public float azmuthSlop = 10f;
    private Quaternion originalBarrelEndRot;
    public float velocitySlop = 1f;

    // Use this for initialization
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        originalBarrelEndRot = mortarBarrelEnd.rotation;
    }

   


    public void Fire()
    {
       
        myAudio.clip = fireSound;
        myAudio.loop = false;
        myAudio.Play();
        foreach (ParticleSystem fire in gunFx)
        {
            fire.Play();

        }

        ShootMortarRound();
    }

    public void ShootMortarRound()
    {
        shellVelocity = shellVelocity + (Random.Range(-velocitySlop, velocitySlop));
        float randomSlop = Random.Range(-azmuthSlop, azmuthSlop);
        Quaternion slop = Quaternion.Euler(randomSlop, Random.Range(-azmuthSlop, azmuthSlop), 0);
        mortarBarrelEnd.rotation = mortarBarrelEnd.rotation * slop;
        Rigidbody emptyShellInstance;
        emptyShellInstance = Instantiate(mortarPrefab, mortarBarrelEnd.position, (mortarBarrelEnd.rotation)) as Rigidbody;
        emptyShellInstance.AddForce(mortarBarrelEnd.forward * shellVelocity);
        mortarBarrelEnd.rotation = originalBarrelEndRot;
    }


   
}
