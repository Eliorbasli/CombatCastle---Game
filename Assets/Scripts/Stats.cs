using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    //public TextMeshProUGUI hpText;
   // public TextMeshProUGUI firstAidCountText;
    //public TextMeshProUGUI hpPotionsCountText;
    //public GameObject usingFirstAidText;
    //public GameObject firstAidSound;
    //public GameObject profile;
    public GameObject target;
    public GameObject weaponsInHand;
    //public GameObject weaponsInField;

    private Animator anim;
    private float hp;
    private int numOfFirstAids;
    private int numOfHPPotion;
    private bool dead;
    private float firstAidTextDelay;
    private NavMeshAgent nma;

    void Start()
    {
        anim = GetComponent<Animator>();
        hp = 100f;
        numOfFirstAids = 0;
        numOfHPPotion = 0;
        dead = false;
        firstAidTextDelay = 0f;

        if (this.gameObject.tag == "NPC")
            nma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (this.gameObject.GetComponent<Stats>().GetHP() < 40f)
            UseHPPotion();

        if (this.tag == "Player")
        {
           // if (Input.GetButtonDown("FirstAid"))
            //    UseFirstAid();

            if (firstAidTextDelay >= 3f)
            {
      //          usingFirstAidText.SetActive(false);
                firstAidTextDelay = 0f;
            }
            else if (firstAidTextDelay > 0f)
                firstAidTextDelay += Time.deltaTime;
        }
        //else if (this.gameObject.GetComponent<Stats>().GetHP() < 50f)
         //   UseFirstAid();
    }

    public float GetHP()
    {
        return this.hp;
    }

    public void SetHP(float hp)
    {
        if (hp >= 100f)
        {
            this.hp = 100f;
        }
        else if (hp < 0f)
        {
            this.hp = 0f;
            SetDead(true);
        }
        else
        {
            this.hp = hp;
        }

        //if (this.tag == "Player")
          //  hpText.GetComponent<TextMeshProUGUI>().text = this.hp.ToString();
    }

    public int GetNumOfFirstAid()
    {
        return this.numOfFirstAids;
    }

    public void setNumOfFirstAid(int numOfFirstAids)
    {
        this.numOfFirstAids = numOfFirstAids;

        //if (this.tag == "Player")
        //    firstAidCountText.GetComponent<TextMeshProUGUI>().text = this.numOfFirstAids.ToString();
    }

    public int GetNumOfHPPotion()
    {
        return this.numOfHPPotion;
    }

    public void setNumOfHPPotion(int numOfHPPotion)
    {
        this.numOfHPPotion = numOfHPPotion;

        //if (this.tag == "Player")
          //  hpPotionsCountText.GetComponent<TextMeshProUGUI>().text = this.numOfHPPotion.ToString();
    }

    public bool IsDead()
    {
        anim.SetInteger("Status", 7);
        return this.dead;
    }

    public void SetDead(bool dead)
    {
        if (dead)
        {
            anim.SetInteger("Status", 2); // Dead
          //  profile.GetComponent<RawImage>().color = new Color32(0, 0, 0, 120);
           // DropWeapon();

            if (this.gameObject.tag == "Player")
                target.SetActive(false);
            else if (this.gameObject.tag == "Team1")
                nma.enabled = false;
        }

        this.dead = dead;
    }

    public void AddFirstAid()
    {
        setNumOfFirstAid(this.numOfFirstAids + 1);
    }

    public void AddHPPotion()
    {
        setNumOfHPPotion(this.numOfHPPotion + 1);
    }

    /*public void UseFirstAid()
    {
        if (this.numOfFirstAids > 0)
        {
            firstAidSound.GetComponent<AudioSource>().Play();
            IncreaseHP(Random.Range(40, 60));
            setNumOfFirstAid(this.numOfFirstAids - 1);
        }
        else if (this.gameObject.name == "Player")
        {
            usingFirstAidText.SetActive(true);
            firstAidTextDelay = 0.1f;
        }
    }
    */
    public void UseHPPotion()
    {
        if (this.numOfHPPotion > 0)
        {
            IncreaseHP(Random.Range(10, 30));
            setNumOfHPPotion(this.numOfHPPotion - 1);
        }
    }

    public void Shot(string shooter)
    {
        Debug.Log("check2, in Shot function");
        anim.SetInteger("Status", 2);
        DicreaseHP(Random.Range(20, 60), shooter);
    }

    public void HurtFromGrenade()
    {
        DicreaseHP(Random.Range(60, 80), "Grenade");
    }

    private void IncreaseHP(float hp)
    {
        SetHP(this.hp + hp);
    }

    private void DicreaseHP(float hp, string shooter)
    {
        if (!dead)
            SetHP(this.hp - hp);
    }

    /*private void DropWeapon()
    {
        for (int i = 0; i < weaponsInHand.transform.childCount; i++)
        {
            if (weaponsInHand.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                for (int j = 0; j < weaponsInField.transform.childCount; j++)
                {
                    if (weaponsInHand.transform.GetChild(i).gameObject.name == weaponsInField.transform.GetChild(j).gameObject.name)
                    {
                        weaponsInHand.transform.GetChild(i).gameObject.SetActive(false);
                        weaponsInField.transform.GetChild(j).gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
                        weaponsInField.transform.GetChild(j).gameObject.SetActive(true);
                        return;
                    }
                }

            }
        }
    }

    */
}