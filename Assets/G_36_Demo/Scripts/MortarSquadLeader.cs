using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarSquadLeader : MonoBehaviour {
    // All of the crewmembers for the mortar team should have this script component "MortarCrewLoader"
    public MortarCrewLoader[] myLoader;
    private Animator myAnim;
    public float fireChance3outof5 = 2f;
    public int salvoCount = 5;
    public int roundsFired = 0;
    private float chanceResult = 0f;

	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
	}
	
    // This function is called from the Leader's animation and is used to tell all of the crew members to switch to the "Fire" animation
    public void FireMortar()
    {
        foreach(MortarCrewLoader crew in myLoader)
        {
            crew.EnableFireMortar();
        }
    }

    // This function is called from the Leader's Idle animation and it decides to fire or not fire randomly
    public void DecidetoFire()
    {
        chanceResult = Random.Range(0, 5);
        if (chanceResult < fireChance3outof5)
        {
            myAnim.SetTrigger("fire");
        }
    }

    // This function is called from the leader's fire animation and it keeps triggering the fire mode until all rounds are fired.
    public void UpdateSalvoCount()
    {
        roundsFired = roundsFired + 1;
        if(roundsFired < salvoCount)
        {
            myAnim.SetTrigger("fire");
        } else
        {
            roundsFired = 0;
            myAnim.ResetTrigger("fire");
        }
    } 

}
