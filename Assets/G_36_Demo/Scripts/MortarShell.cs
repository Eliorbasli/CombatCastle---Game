using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarShell : MonoBehaviour {

    private Rigidbody mortarRigidbody;
    public GameObject explosionPrefab;
    public GameObject explosionNoCrater;
    // Use this for initialization
	void Start () {
        mortarRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.forward =
        Vector3.Slerp(this.transform.forward, mortarRigidbody.velocity.normalized, Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Terrain"))
        {
        Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
        
        }
        else
        {
            Instantiate(explosionNoCrater, this.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

    }
}
