using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TurnPhysical : MonoBehaviour
{

    [Header("かかる時間"), Range(0.0625f, 30)]
    public float duration = 1.0f;
    [Header("移動する距離"), Range(0, 30)]
    public float distance = 1.0f;

    float pastTime = 0;
    Vector3 homePosition;
    public Vector3 targetPosition;
    public Vector3 nextPosition;
    Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        homePosition = transform.position;
        targetPosition = transform.position + transform.forward * distance;
        rigidBody = GetComponent<Rigidbody>();
    }
  
    private void FixedUpdate()
    {
        pastTime += Time.fixedDeltaTime;
        nextPosition = Vector3.Lerp(homePosition, targetPosition, Mathf.PingPong(pastTime, duration)/duration );
        //rigidBody.MovePosition(
        //    Vector3.Lerp(homePosition, targetPosition, Mathf.PingPong(pastTime, duration) / duration));

        rigidBody.AddForce(nextPosition-transform.position-rigidBody.velocity,ForceMode.VelocityChange);
    }
}
