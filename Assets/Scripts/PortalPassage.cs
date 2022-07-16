using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalPassage : MonoBehaviour
{
   // public GameObject canvas;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
   //     animator = canvas.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        StartCoroutine(PlayDelay());
    
    }

    IEnumerator PlayDelay()
    {
        int numScene;
        //Play fade in animation
        animator.SetTrigger("StartFadeIn");
        //delay
        
        yield return new WaitForSeconds(2);

        numScene = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene((numScene + 1) % 2);
    }
}
