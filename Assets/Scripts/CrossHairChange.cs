using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairChange : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject SeeThroughCrossHair;
    public GameObject TouchCrossHair;
    public GameObject Drawer4;
    public Text DrawerText;
    private bool drawerClosed = true;
    //private bool drawerClosed = true;
    private Animator animator;
    private AudioSource drawerSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        drawerSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit;

        if(Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
        {
            // THIS is the chest . So we want to check if the hit object is the chest
            if((hit.transform.gameObject == this.gameObject || hit.transform.gameObject == Drawer4.gameObject )
                && hit.distance<20)
            {
                // change crosshair
                if (!TouchCrossHair.active)
                {
                    SeeThroughCrossHair.SetActive(false);
                    TouchCrossHair.SetActive(true);
                }

            }
            else
            {
                // change crosshair
                if (TouchCrossHair.active)
                {
                    SeeThroughCrossHair.SetActive(true);
                    TouchCrossHair.SetActive(false);
                }
            }
            // check if we hit the drawer
            if (hit.transform.gameObject == Drawer4.gameObject)
            {
                if (!DrawerText.IsActive())
                {
                  
                    DrawerText.gameObject.SetActive(true);
              
                }
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(DrawerOpenClose());
                }
               
            }
            else
            {
                if (DrawerText.IsActive())
                {
                    DrawerText.gameObject.SetActive(false);

                }
            }
        }

    }

    //change text only after animation played
    IEnumerator DrawerOpenClose()
    {
        

        animator.SetBool("Open", drawerClosed);
        drawerClosed = !drawerClosed;
        drawerSound.PlayDelayed(0.8f);
        //DrawerText.gameObject.SetActive(drawerClosed);
     

        yield return new WaitForSeconds(2);

        if (drawerClosed)
            DrawerText.text = "Press [E] to OPEN";
        else
            DrawerText.text = "Press [E] to CLOSE";
    }
}
