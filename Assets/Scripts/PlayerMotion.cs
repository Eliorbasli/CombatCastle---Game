using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotion : MonoBehaviour
{
    private CharacterController controller; //variable defintion
    private float speed = 10;
    private float angularSpeed = 140;
    private float rotationAboutY = 0;
    private float rotationAboutX = 0; //degree
    public GameObject aCamera;  //public must be connected to external object
    private AudioSource steps;

    public int maxHealth = 100;
    public int currentHealth;
    public int score;

    public GameOverScreen GameOverScreen; 
    // Start is called before the first frame update

    public HealthBar1 healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        //connect controller to the corresponding component in player
        controller = GetComponent <CharacterController>();
        steps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))  // Shooting
            GameOver();
        if (Input.GetKeyDown(KeyCode.P))
            Winner();
            
        


        if (Input.GetKey(KeyCode.LeftShift)) // Running with LeftShift
            speed = 30;
        else
            speed = 10;

        float dx = 0;
       float dy = -0.5f; // gravity
       float dz = 0;
       

        //set the rotation angles
        rotationAboutY += Input.GetAxis("Mouse X") * angularSpeed*Time.deltaTime;
        Vector3 rotation = new Vector3(0, rotationAboutY, 0);
        transform.localEulerAngles = rotation;      //set the rotation angles of THIS
        //set the rotation angles abot X axis
        rotationAboutX -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        if(Mathf.Abs(rotationAboutX) >60)
        {
            rotationAboutX = 0;
        }else { 
            Vector3 rotation_x = new Vector3( rotationAboutX, 0,0);
            aCamera.transform.localEulerAngles = rotation_x;
        }

        //add motion using Character Controller
        //Vectoer3 motion = new Vectoer3(0.1f, , 0, 0);

        dx = Input.GetAxis("Horizontal"); // can be -1, 0, 1 i.e left , none , right
        dx *= speed * Time.deltaTime; // Time.deltaTime is the time lapse between frames
        dz = Input.GetAxis("Vertical"); // can be -1, 0, 1
        dz *= speed * Time.deltaTime;     // can be -1, 0, 1 i.e forward , none ,backward
        //add motion using Character Controller
        Vector3 motion = new Vector3(dx ,dy ,dz);   //dx , dy ,dz are Local coordinates

        motion = transform.TransformDirection(motion);
        controller.Move(motion); // The vector motion must be in Global coordinates
        
        if(Mathf.Abs(dz)> 0.01 || Mathf.Abs(dx) > 0.01)
        { 
            if(!steps.isPlaying)
                steps.Play();
        }
    }

    public void TakeDamage ( int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOverScreen.Setup(Random.Range(16, 80), false);
    }

    public void Winner()
    {
        GameOverScreen.Setup(Random.Range(70, 80), true);
    }

    public bool GetcurrentHealthPlayer()
    {
        if (currentHealth < 0)
            return false;
        return true;
    }

   

}


