using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

    [Header("かかる時間"),Range(0.0625f,30)]
    public float duration = 1.0f;
    [Header("移動する距離"), Range(0, 30)]
    public float distance= 1.0f;
    float pastTime=0;
    Vector3 homePosition;
    Vector3 targetPosition;


    // Use this for initialization
    void Start () {
		homePosition = transform.localPosition;
        targetPosition = transform.localPosition + transform.forward * distance;
	}
	
	// Update is called once per frame
	void Update () {
        pastTime += Time.deltaTime;
        Vector3 newPosition = Vector3.Lerp(homePosition, targetPosition, Mathf.PingPong(pastTime, duration)/duration);
        transform.localPosition = newPosition;
		
	}

}
