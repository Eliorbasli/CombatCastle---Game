using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text Title;
    public Text pointsText;
    public void Setup(int score , bool winner)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
        if(winner)
            Title.text = "Team Winners";
        else
            Title.text = "Game Over ";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScence1");
    }

    public void ExitButton()
    {
        //SceneManager.LoadScene("MainMenu");
        //Application.Quit();
    }
}
