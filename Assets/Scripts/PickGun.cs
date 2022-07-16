using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    public GameObject gunInDrawer;
    public GameObject gunInHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.P) )
        {
            gunInDrawer.SetActive(false);
            gunInHand.SetActive(true);
        }
    }
        private void OnMouseOver()
        {
            gunInDrawer.SetActive(false);
            gunInHand.SetActive(true);
        }

}
