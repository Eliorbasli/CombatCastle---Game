using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeMotion : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject Explosion;
    public GameObject part1;
    public GameObject part2;
    private AudioSource sound;
    private Rigidbody rb ; // component of grenade
    private int gunNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // component of grenade
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.G) && Explosion) // throw grenade
        {
            Vector3 direction = aCamera.transform.forward;
            direction.y = 1;
            
            rb.AddForce(1.5f*direction, ForceMode.Impulse); // 10 * is the power of throwing
            rb.useGravity = true;
            StartCoroutine(Explode());
        
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.gameObject.SetActive(false);
            gunNumber = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.gameObject.SetActive(true);
            gunNumber = 2;
        }


    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3f);
        Explosion.SetActive(true);
        // part1.SetActive(false);
        // part2.SetActive(false);
        sound.Play();
        

        //add explosion influnce on other objects
        Collider[] objectsCollider = Physics.OverlapSphere(transform.position, 35);

        for(int i = 0; i <objectsCollider.Length; i++)
        {
            Rigidbody r = objectsCollider[i].GetComponent<Rigidbody>();
            if(r != null) // it has Rigidbody
            {
                r.AddExplosionForce(1000 , transform.position, 35);
            }
        }
    }
}
