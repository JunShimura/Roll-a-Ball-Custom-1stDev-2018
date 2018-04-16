using UnityEngine;
using System.Collections;

public class OuterSphereControl : MonoBehaviour {

    public float distortionRatio = 0.1f; //歪む波長
    private float r = 0.0f;     //回転角
    public float decline = 0.9f;//減退率
    private Vector3 originLocalScale = Vector3.one;
    private Vector3 originLossyScale = Vector3.one;
    private float maxRatio = 1;
    private Rigidbody parentRigidbody=null;
    enum Status { normal,touched,release};
    private Status status=Status.normal;
    GameObject outerSphereVisible = null;
            
    // Use this for initialization
	void Start () {
        parentRigidbody = transform.parent.GetComponent<Rigidbody>();
        outerSphereVisible = transform.Find("OuterSphereVisible").gameObject;
        originLocalScale = outerSphereVisible.transform.localScale;
        originLossyScale = outerSphereVisible.transform.lossyScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(status);
    }

    void FixedUpdate()
    {
        if (status == Status.release)
        {
            maxRatio *= decline;
            if (maxRatio <= 1.0f)
            {
                status = Status.normal;
                maxRatio = 1.0f;
                outerSphereVisible.transform.localScale = originLocalScale;
            }
            else
            {
                r += distortionRatio;
                float currentRatio = ((Mathf.Cos(r) + 2) / 2) * maxRatio;
                float currentWidthRatio = Mathf.Sqrt(currentRatio);
                outerSphereVisible.transform.localScale
                    = new Vector3(originLocalScale.x * currentWidthRatio, originLocalScale.y * currentWidthRatio, originLocalScale.z * (1 / currentRatio));
            }
        }
    }




    void OnTriggerEnter(Collider collider )
    {
        SetScaleAtTrigger();
        status = Status.touched;
    }
    void OnTriggerStay(Collider collider)
    {
        SetScaleAtTrigger();
 
    }
    void OnTriggerExit(Collider collider)
    {
        //SetScaleAtTrigger();
        status = Status.release;
        r = 1.0f;

    }
    void SetScaleAtTrigger()
    {
        RaycastHit raycasthit;
        Physics.Raycast(transform.parent.transform.position, parentRigidbody.velocity, out raycasthit);
        Vector3 toHitPoint = raycasthit.point - transform.parent.transform.position;
        float ratio = (originLossyScale.y / 2) / toHitPoint.magnitude;
        if (maxRatio < ratio)
        {
            maxRatio = ratio;
             //outerSphereVisible.transform.LookAt(raycasthit.point);
            outerSphereVisible.transform.forward = -raycasthit.normal;
        }
        float widthRatio = Mathf.Sqrt(ratio);
        outerSphereVisible.transform.localScale
            = new Vector3(originLocalScale.x * widthRatio, originLocalScale.y * widthRatio, originLocalScale.z * (1 / ratio));
        
    }

}
