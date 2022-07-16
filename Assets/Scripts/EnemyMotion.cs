using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class EnemyMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject Player;

    public GameObject gunInHand;
    private LineRenderer line;
    public int Health = 100;
    private float NextTimeToAttack = 2f;
    private AudioSource shootingSound;
    public ParticleSystem muzzleFlash;
    private bool StartGame = false;
    private string targetTag;
    private bool targetLive1;
    private bool targetLive2;
    private bool targetLive3;

    public Text consoleText;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();
        shootingSound = gunInHand.GetComponent<AudioSource>();
        agent.enabled = false;

        gunInHand.SetActive(false);

        if (this.tag == "Team1")
            targetTag = "Team2";
        else
            targetTag = "Team1";
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit1;

        // Start the game with press Q
        if (Input.GetKeyDown(KeyCode.Q) && animator.GetInteger("Status") != 2)
        {
            animator.SetInteger("Status", 4); // 4 is walking animation
            StartGame = true;
            agent.enabled = true;
            lookingNewTarget();
        }

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit1) && StartGame && animator.GetInteger("Status") != 2)
        {
            //If the target is the player
            if(hit1.transform.gameObject.tag == targetTag && hit1.transform.gameObject.name == "Player")
            {
               // Debug.Log("the target is the player");
                agent.enabled = false;
                animator.SetInteger("Status", 7);   // 7 is atack animation
                gunInHand.SetActive(true);

                NextTimeToAttack -= Time.deltaTime;
                if (NextTimeToAttack < 0)
                {
                    muzzleFlash.Play();
                    shootingSound.Play();
                    NextTimeToAttack = 2f;

                    hit1.transform.gameObject.GetComponent<PlayerMotion>().TakeDamage(2);
                }
            }

            //If the target is the NPC from enemy team
            if ((hit1.transform.gameObject.tag == targetTag)  && hit1.distance < 55 )
            {
                if (hit1.transform.gameObject.GetComponent<EnemyMotion>().isLive())
                {
                    
                    agent.enabled = false;
                    animator.SetInteger("Status", 7);   // 7 is Atack animation
                    gunInHand.SetActive(true);

                     NextTimeToAttack -= Time.deltaTime;
                    if (NextTimeToAttack < 0)
                     {
                        muzzleFlash.Play();
                        shootingSound.Play();
                        NextTimeToAttack = 2f;

                        reduceLifeTotarget(hit1);
                     }
                }
            }
            else
            {
                agent.enabled = true;
                gunInHand.SetActive(false);
                animator.SetInteger("Status", 4);

                if (!lookingNewTarget())
                {
                    agent.enabled = false;
                    StartGame = false;
                    
                }
            }
        }
    }
    public bool lookingNewTarget()
    {
            targetLive1 = target1.gameObject.GetComponent<EnemyMotion>().isLive();
            targetLive2 = target2.gameObject.GetComponent<EnemyMotion>().isLive();
            targetLive3 = target3.gameObject.GetComponent<EnemyMotion>().isLive();
            
            if (!targetLive1 && !targetLive2 && !targetLive3)
                return false;

           if (agent.enabled && (targetLive1 || targetLive2 || targetLive3))
           {
               if(targetLive1)
                   agent.SetDestination(target1.transform.position); // Here A* is used to get path to target
               if (targetLive2)
                   agent.SetDestination(target2.transform.position);
               if (targetLive3)
                   agent.SetDestination(target3.transform.position);
               if(Player.tag == targetTag)
                    agent.SetDestination(Player.transform.position);

            //showing the path
            line.positionCount = agent.path.corners.Length;
               line.SetPositions(agent.path.corners);
               return true;
           }
           return false;
    }

    public int updateHelath(int x)
    {
        this.Health = this.Health - x;
        return this.Health;
    }

    public bool isLive()
    {
        if (this.Health <= 0)
        {
            this.gunInHand.SetActive(false);
            return false;
        }
        return true;
    }

    public void reduceLifeTotarget(RaycastHit hit1)
    {
        hit1.transform.gameObject.GetComponent<EnemyMotion>().updateHelath(Random.Range(30, 60));

        if (!hit1.transform.gameObject.GetComponent<EnemyMotion>().isLive())
        {
            //update NPC animator
            hit1.transform.gameObject.GetComponent<Animator>().SetInteger("Status", 2);

            hit1.transform.GetComponent<NavMeshAgent>().enabled = false;
            consoleText.text = this.name + " kill " + hit1.transform.name + "\n";
        }
    }


}
