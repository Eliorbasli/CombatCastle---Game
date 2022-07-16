using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public int kills = 0;
    public int deads = 0; 
    // Start is called before the first frame update


    public void addKill()
    {
        kills ++; 
        if(kills >=3)
        {
            GameOverScreen.Setup(10, false); // Winner
        }
    }

    public void addDead()
    {
        deads++; 
    }

}
