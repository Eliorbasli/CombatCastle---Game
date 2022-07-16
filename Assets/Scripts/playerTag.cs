using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTag : MonoBehaviour
{

    GameObject Player; 
    // Start is called before the first frame update
    public void ChangePlayerTag()
    {
        //Player.transform.Gameobject.tag = <tag>
        Player.transform.gameObject.tag = "ddddd";
    }

}
