using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCinematic : MonoBehaviour {

    public Transform trans;
    public Transform boss;
    public bool hello;
    private AudioSource aud;
	void Start () {
        aud = GetComponent<AudioSource>();
        aud.PlayScheduled(1f);
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.transform.position == trans.position)
        {
            hello = true;
        }
        if (!hello)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, trans.position, 10f * Time.deltaTime);
        }
        Vector3 dir = boss.position - gameObject.transform.position;
        //dir = new Vector3(dir.x, 0, dir.z);
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, Time.deltaTime * 0.3f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);

    }
}
