using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {
    private Animator anim;
	public Transform target;
	public float speed;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if(transform.position == target.position)
        {
            anim.SetBool("done", true);
        }
	}
}