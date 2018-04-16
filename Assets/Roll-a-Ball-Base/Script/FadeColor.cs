using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeColor : MonoBehaviour {
    [SerializeField]
    Color[] colors;

    int currentId=0;

    [SerializeField]
    float timeSpan;

    [SerializeField]
    float offsetTime = 0;

     Renderer renderer;

    float time=0;
    Color tempColor;
    
    // Use this for initialization
    void Start () {
        renderer = gameObject.GetComponent<Renderer>();
        time = offsetTime;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > timeSpan) {
            time -= timeSpan;
            currentId = (currentId + 1) % colors.Length;
        }
        float ratio = Mathf.Sin(time / timeSpan * Mathf.PI/2);
        tempColor = Color.Lerp(colors[currentId], colors[(currentId + 1) % colors.Length], ratio);
        renderer.material.SetColor("_Color", tempColor);

    }
}
