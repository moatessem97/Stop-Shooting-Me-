using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour {
    private GameObject targ;
    public GameObject partic;
    private Rigidbody rb;
    Vector3 lel;
	// Use this for initialization
	void Start () {
        targ = GameObject.Find("WhaleBossFinal");
        rb = gameObject.GetComponent<Rigidbody>();
        lel = targ.transform.position - gameObject.transform.position;
        //Debug.Log(lel);
        lel.Normalize();
        //rb.AddForce(lel * 100f);
        rb.velocity = (lel * 20f) + new Vector3(0f,35f,0f) ;
	}
	
	// Update is called once per frame
	void Update () {
        //lel = targ.transform.position - gameObject.transform.position;
        //lel.Normalize();
        ////rb.AddForce(lel * 1000f);
        //rb.velocity = lel * 10f;
    }

    //private void OnCollisionEnter(Collision collision)
    //{

    //    if(collision.transform.tag == "Enemy")
    //    {
    //        Debug.Log("hello");
    //        FindObjectOfType<dinoHealth>().health -= 25f;
    //        Instantiate(partic, transform.position,transform.rotation);
    //        Destroy(gameObject);    
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Debug.Log("hello");
            FindObjectOfType<dinoHealth>().health -= 25f;
            Instantiate(partic, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
