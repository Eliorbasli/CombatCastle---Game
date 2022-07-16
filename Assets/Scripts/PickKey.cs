using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject KeyInBox;
    public GameObject Gate;
    static int pickedKeys = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            KeyInBox.SetActive(false);
            pickedKeys++;
            //gunInHand.SetActive(true);
        }
    }
}
