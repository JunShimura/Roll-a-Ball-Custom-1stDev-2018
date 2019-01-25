using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CatchRigidBody2 : MonoBehaviour
{

    public string targetTag;

    public class ContactObject
    {
        public Collision collision;
        public Rigidbody rigidbody;
        public ContactObject(Collision col, Rigidbody rb)
        {
            collision = col;
            rigidbody = rb;
        }
    }
    private List<ContactObject> contactObject = new List<ContactObject>();

    private List<Rigidbody> contactRigidbody = new List<Rigidbody>();
    private new Rigidbody catchRigidbody;
    private Vector3 currentVelocity;
    public Vector3 fixedPosition;
    private TurnPhysical turnPhysical;

    public delegate void EventHandler1<TParam>(TParam param);
    public event EventHandler1<Collision> OnCollisionEnterEvent = collision => { };
    public event EventHandler1<Collision> OnCollisionStayEvent = collision => { };

    // Use this for initialization
    void Start()
    {
        catchRigidbody = gameObject.GetComponent<Rigidbody>();
        turnPhysical = gameObject.GetComponent<TurnPhysical>();
        OnCollisionEnterEvent += CatchContact;
        OnCollisionStayEvent += CatchContact;
    }

    private void CatchContact(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && !contactObject.Exists(contactObject => contactObject.collision.gameObject.GetInstanceID() == collision.gameObject.GetInstanceID()))
        {
            contactObject.Add(new ContactObject(collision, collision.gameObject.GetComponent<Rigidbody>()));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            int index = contactRigidbody.FindIndex(rigidbody => rigidbody.gameObject.GetInstanceID() == collision.gameObject.GetInstanceID());
            if (index != -1)
            {
                contactRigidbody.RemoveAt(index);
            }
        }

    }
    private void FixedUpdate()
    {
        currentVelocity = transform.position - fixedPosition;
        fixedPosition = transform.position;
        if (contactRigidbody.Capacity != 0)
        {
            contactRigidbody.ForEach(
                delegate (Rigidbody rigidbody)
                {
                    if (rigidbody != null)
                    {
                        rigidbody.MovePosition(rigidbody.gameObject.transform.position + currentVelocity);
                        //gameObject.GetComponent<Rigidbody>().AddForce(currentVelocity,ForceMode.VelocityChange);
                    }
                }
             );
        }
    }
}
