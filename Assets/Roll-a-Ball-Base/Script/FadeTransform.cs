using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTransform : MonoBehaviour {
    [SerializeField]
    GameObject[] gameObjects;
    Transform[] transforms;

    int currentId=0;

    [SerializeField]
    float timeSpan;

    [SerializeField]
    float offsetTime = 0;

    float time=0;
    Transform tempTransform;
    
    // Use this for initialization
    void Start () {
        transforms = new Transform[gameObjects.Length];
        for(int i=0;i< transforms.Length; i++) {
            transforms[i] = gameObjects[i].transform;
        }
        time = offsetTime;
	}

    // Update is called once per frame
    float ratio;
    void Update () {
        time += Time.deltaTime;
        if (time > timeSpan) {
            time -= timeSpan;
            currentId = (currentId + 1) % transforms.Length;
        }
        ratio = Mathf.Cos((time / timeSpan - 1) * Mathf.PI / 2.0f);
        transform.localPosition = Vector3.Lerp(transforms[currentId].position, transforms[(currentId + 1) % transforms.Length].position, ratio);
        transform.localScale = Vector3.Lerp(transforms[currentId].localScale, transforms[(currentId + 1) % transforms.Length].localScale, ratio);
        transform.rotation = Quaternion.Lerp(transforms[currentId].rotation, transforms[(currentId + 1) % transforms.Length].rotation, ratio);

    }
}
