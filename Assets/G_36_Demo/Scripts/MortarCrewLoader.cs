using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarCrewLoader : MonoBehaviour {

    public MortarAction myMortar;
    private Animator myAnim;
    public bool flipIdle = false;

    private void Start()
    {
        myAnim = GetComponent<Animator>();   
    }

    public void FIRE_Mortar()
    {
        myMortar.Fire();
    }

    public void EnableFireMortar()
    {
        myAnim.SetTrigger("fire");
        flipIdle = !flipIdle;
        myAnim.SetBool("flipIdle", flipIdle);
    }
}
