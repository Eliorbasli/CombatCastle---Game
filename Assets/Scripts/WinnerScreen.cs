using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerScreen : MonoBehaviour
{
   // public Text pointsTitle;
    public Text pointsText;

    public void Setup(int score, bool lwinner)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "POINTS";
    }

    public void RestartButton()
    {
        //SceneManager.LoadScene("SampleScence1");
    }

}
