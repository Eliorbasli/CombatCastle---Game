using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairChangeOnBox : MonoBehaviour
{
    public GameObject aCamera1;
    public GameObject SeeThroughCrossHair1;
    public GameObject TouchCrossHair1;
    public GameObject Box;
    public GameObject Key;
    public Text DrawerText1;
    
    //public GameObject Box;
    private bool boxClosed1 = true;
    //private bool drawerClosed = true;
    private Animator animator1;
    // Start is called before the first frame update
    void Start()
    {
        animator1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(aCamera1.transform.position, aCamera1.transform.forward, out hit))
        {
            // THIS is the chest. So we want to check if the hit object is the chest
            if ((hit.transform.gameObject == this.gameObject || hit.transform.gameObject == Box.gameObject)
                 && hit.distance < 20)
            {
                // change crosshair
                if (!TouchCrossHair1.active)
                {
                    SeeThroughCrossHair1.SetActive(false);

                    TouchCrossHair1.SetActive(true);
                }
            }
            else
            {
                // change crosshair
                if (TouchCrossHair1.active)
                {
                    SeeThroughCrossHair1.SetActive(true);
                    TouchCrossHair1.SetActive(false);
                }

            }
            // check if we hit the drawer
            if (hit.transform.gameObject == Box.gameObject)
            {
                if (Input.GetKeyDown(KeyCode.V))
                {
                    StartCoroutine(BoxOpenClose());
                    if (Key.active)
                    {
                        DrawerText1.text = "Press F to get a Key";
                    }
                }
                if (!DrawerText1.IsActive())
                {
                   
                    DrawerText1.gameObject.SetActive(true);
                }
                
            }
            else
            {
                if (DrawerText1.IsActive())
                {
                    DrawerText1.gameObject.SetActive(false);
                }

            }
        }

    }


    //change text only after animation played
    IEnumerator BoxOpenClose()
        {

            animator1.SetBool("Open1", boxClosed1);
            boxClosed1 = !boxClosed1;
            //DrawerText1.gameObject.SetActive(boxClosed1);


            yield return new WaitForSeconds(2);

        if (boxClosed1)
            DrawerText1.text = "Press [Space] to OPEN";

        else // box open
        {
            DrawerText1.text = "Press [Space] to CLOSE";
            if (Key.active)
            {
                DrawerText1.text = "Press G to get a Key";
                
            }
        }
        }

    }

  
