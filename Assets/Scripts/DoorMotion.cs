using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("DoorIsOpen" , true);
        sound.PlayDelayed(0.8f);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorIsOpen", false);
        sound.PlayDelayed(0.8f);
    }
}
