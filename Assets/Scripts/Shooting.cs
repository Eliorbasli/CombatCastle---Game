using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject aTarget;
   
    //public GameObject eagle;
   
    //public Animator animatorEagle;
    public GameObject gun;
    public GameObject gunMuzzle;
    private AudioSource shootingSound;
    private LineRenderer line;
    public ParticleSystem muzzleFlash;
    private int kills;
    public int score; 
    private int gunNumber = 1;
    public Text consoleText;
    private string targetTag;

    //public TeamManager teamManager;
    public GameOverScreen GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        kills = 0; 
      //  animatorEagle = eagle.GetComponent<Animator>();

        shootingSound = gun.GetComponent<AudioSource>();
        line = gun.GetComponent<LineRenderer>();

        if (this.tag == "Team1")
            targetTag = "Team2";
        else
            targetTag = "Team1";

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.SetActive(true);
            gunNumber = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun.SetActive(false);
            gunNumber = 2;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootingSound.Play();
            muzzleFlash.Play();
            
            if(Physics.Raycast(aCamera.transform.position , aCamera.transform.forward , out hit) && gunNumber == 1)
            {
                aTarget.transform.position = hit.point;
                //draw shooting for a moment
                StartCoroutine(DrawFlash());

                // if (hit.transform.gameObject == enemy.transform.gameObject)
                //if(hit.transform.tag =="Team1")
                if (hit.transform.tag == targetTag)
                {
                    NavMeshAgent agent = hit.transform.GetComponent<NavMeshAgent>();

                    //stop enemy motion
                    agent.enabled = false;
                    hit.transform.gameObject.GetComponent<EnemyMotion>().updateHelath(Random.Range(50, 80));

                    if (!hit.transform.gameObject.GetComponent<EnemyMotion>().isLive()) // Enemy is dead
                    {
                        score += 2;
                        hit.transform.gameObject.GetComponent<Animator>().SetInteger("Status", 2);
                        kills++;
                        if(kills == 6 )
                          GameOverScreen.Setup(10, true);
                        consoleText.text = this.name + "kill " + hit.transform.name;


                    }
                }
            }
        }
      
    }

    IEnumerator DrawFlash()
    {
        //1.draw shooting line
        line.SetPosition(0, gunMuzzle.transform.position);
        line.SetPosition(1, aTarget.transform.position);

        //2.delay
        yield return new WaitForSeconds(0.1f);

        //3.erase shooting line
        line.SetPosition(0, gunMuzzle.transform.position);
        line.SetPosition(1, gunMuzzle.transform.position);
    }


    IEnumerator ShowShot()
    {
        muzzleFlash.Play();
        //.Play();
        yield return new WaitForSeconds(0.1f);
    }
}
