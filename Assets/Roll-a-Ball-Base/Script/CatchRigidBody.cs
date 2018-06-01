using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CatchRigidBody : MonoBehaviour {

    public string targetTag;

    private List<GameObject> contactObject = new List<GameObject>();
    private new Rigidbody catchRigidbody;
    private Vector3 currentVelocity;
    public Vector3 fixedPosition;
    private TurnPhysical turnPhysical;
    private Turn turn;


    // Use this for initialization
    void Start () {
        catchRigidbody = gameObject.GetComponent<Rigidbody>();
        turnPhysical = gameObject.GetComponent<TurnPhysical>();
        turn = gameObject.GetComponent<Turn>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && !contactObject.Exists(  gameObject => gameObject.GetInstanceID() == collision.gameObject.GetInstanceID())) {
            contactObject.Add(collision.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && !contactObject.Exists(gameObject => gameObject.GetInstanceID() == collision.gameObject.GetInstanceID())) {
            contactObject.Add(collision.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag)) {
            int index = contactObject.FindIndex(gameObject => gameObject.GetInstanceID() == collision.gameObject.GetInstanceID());
            if (index != -1) {
                contactObject.RemoveAt(index);
            }
        }

    }
    private void FixedUpdate()
    {
        currentVelocity = transform.position - fixedPosition;
        fixedPosition = transform.position;

        if ( contactObject.Capacity!=0) {
            contactObject.ForEach(
                delegate (GameObject gameObject) {
                    gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.transform.position+currentVelocity);
                });
            
        }
    }
}
