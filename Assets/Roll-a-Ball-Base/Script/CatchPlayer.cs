using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


public class CatchPlayer : MonoBehaviour {


    // Use this for initialization
	void Start () {

	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")) {

        }
    }

}
