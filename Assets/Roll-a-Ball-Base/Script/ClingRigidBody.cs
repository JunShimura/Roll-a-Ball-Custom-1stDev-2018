﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ClingRigidBody : MonoBehaviour
{

    public List<string> targetTag = new List<string>();

    public class ContactObject
    {
        public Collision collision
        {
            get;
        }
        public Rigidbody rigidbody
        {
            get;
        }
        public int instanceID
        {
            get;
        }

        public ContactObject(Collision col)
        {
            collision = col;
            rigidbody = collision.rigidbody;
            instanceID = collision.gameObject.GetInstanceID();
        }
        public void MoveRelativePosition(Vector3 pos)
        {
            if (rigidbody != null)
            {
                rigidbody.MovePosition(rigidbody.gameObject.transform.position + pos);
            }
        }
    }
    private List<ContactObject> contactObject = new List<ContactObject>();

    private new Rigidbody catchRigidbody;
    private Vector3 currentVelocity;
    private Vector3 fixedPosition;

    // Use this for initialization
    void Awake()
    {
        catchRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        CatchContact(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        CatchContact(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        int index = SearchContact(collision);
        if (index != -1)
        {
            contactObject.RemoveAt(index);
        }
    }

    private void FixedUpdate()
    {
        currentVelocity = transform.position - fixedPosition;
        fixedPosition = transform.position;
        if (currentVelocity != Vector3.zero && contactObject.Capacity != 0)
        {
            contactObject.ForEach(
                delegate (ContactObject contactObject)
                {
                    contactObject.MoveRelativePosition(currentVelocity);
                }
             );
            // contactObject.ForEach(MoveRerativePosition(currentVelocity)) ;
        }
    }


    private int SearchContact(Collision collision)
    {
        return contactObject.FindIndex(
            contactObject =>
                contactObject.instanceID == collision.gameObject.GetInstanceID());
    }

    private void CatchContact(Collision collision)
    {
        if (targetTag.Count == 0 || targetTag.Contains(collision.gameObject.tag))
        {
            if (SearchContact(collision) == -1)
            {
                contactObject.Add(new ContactObject(collision));
            }
        }
    }
}
