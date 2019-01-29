using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RoundPhysical : MonoBehaviour
{

    [Header("かかる時間"), Range(0.0625f, 100)]
    public float duration = 1.0f;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //rigidbody.MoveRotation( transform.rotation*Quaternion.Euler(0, 360 / duration * Time.fixedDeltaTime, 0));
        rigidbody.AddTorque(new Vector3(0, Mathf.PI*2 / duration * Time.fixedDeltaTime, 0), ForceMode.VelocityChange);
    }
}
