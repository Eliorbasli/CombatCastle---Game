using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateMotion : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator animator;
    private AudioSource sound;
    public GameObject KeyInBox;
    public Text ScreenText;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        //have a key
        if (!KeyInBox.active)
        {
            //animator.SetBool("haveKey", true);
            //sound.PlayDelayed(0.8f);
            StartCoroutine(OpenCloseDoor());

        }
        else
        {
            //ScreenText.text = "You need a key to open this door";
            //animator.SetBool("haveKey", false);
            //ScreenText.gameObject.SetActive(true);
            StartCoroutine(TextOnOff());
        }
    }



    //change text only after animation played
    IEnumerator TextOnOff()
    {

        //DrawerText.gameObject.SetActive(drawerClosed);
       // ScreenText.text = "You need a key to open this door";
       // ScreenText.gameObject.SetActive(true);

        animator.SetBool("haveKey", false);

        yield return new WaitForSeconds(3);

        ScreenText.gameObject.SetActive(false);
        
    }


    IEnumerator OpenCloseDoor()
    {

        //DrawerText.gameObject.SetActive(drawerClosed);
        animator.SetBool("haveKey", true);
        //sound.PlayDelayed(0.8f);

        yield return new WaitForSeconds(4);
        animator.SetBool("haveKey", false);

        

    }





}
