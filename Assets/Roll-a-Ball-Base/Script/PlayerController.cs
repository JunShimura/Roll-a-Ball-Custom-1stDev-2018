using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    // speedを制御する
    public float speed = 10;
    public float upForce = 20.0f;
    public KeyCode jumpKey = KeyCode.Space;
    private Vector3 force = new Vector3();
    private new Rigidbody rigidbody;
    [SerializeField]
    GameObject brokenParticle;
    [SerializeField]
    float brokenTime = 0.5f;
    [SerializeField]
    GameObject gameController;
    public float animationFrameRate = 10f;
    public float animationRate = 10.0f;

    bool collisionFlag = false;
    List<int> contactGameObjectID = new List<int>();

    private void Start()
    {
        force = Vector3.zero;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

#if UNITY_ANDROID
        force.x= CrossPlatformInputManager.GetAxisRaw("Horizontal");
        force.z= CrossPlatformInputManager.GetAxisRaw("Vertical");
        if (CrossPlatformInputManager.GetButton("Jump")&& collisionFlag) {
            force.y = upForce;
        }
        else {
            force.y = 0.0f;
        }
#else

        force.x = Input.GetAxis("Horizontal") * speed;
        force.z = Input.GetAxis("Vertical") * speed;

        if (Input.GetKeyDown(jumpKey) || Input.GetButtonDown("Jump")) {
            Debug.Log("input JUMP");
            if (collisionFlag) {
                force.y = upForce;
                Debug.Log("JUMPED!");
            }
        }
        else {
            force.y = 0.0f;
        }
#endif
        if (force.magnitude != 0.0f) {
            gameController.GetComponent<GameController>().isStarted = true;
        }


    }

    void FixedUpdate()
    {
        if (force != Vector3.zero & rigidbody != null) {
            Debug.Log("ADDFORCE");
            rigidbody.AddForce(force * speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        collisionFlag = true;
        if (!contactGameObjectID.Contains(collision.gameObject.GetInstanceID())) {
            contactGameObjectID.Add(collision.gameObject.GetInstanceID());
            Debug.Log("Enter" + collision.gameObject.name);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        collisionFlag = true;
        if (!contactGameObjectID.Contains(collision.gameObject.GetInstanceID())) {
            contactGameObjectID.Add(collision.gameObject.GetInstanceID());
            Debug.Log("Stay" + collision.gameObject.name);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (contactGameObjectID.Contains(collision.gameObject.GetInstanceID())) {
            contactGameObjectID.Remove(collision.gameObject.GetInstanceID());
            Debug.Log("Exit" + collision.gameObject.name);
        }
        if (contactGameObjectID.Count == 0) {
            collisionFlag = false;
        }
    }
    public void SetBroken()
    {
        GameObject particleInstance = GameObject.Instantiate(brokenParticle, transform.position, Quaternion.identity);
        gameController.GetComponent<GameController>().ResetScene(brokenTime);
        Destroy(particleInstance, brokenTime);
        rigidbody.velocity = Vector3.zero;
        Destroy(rigidbody);

        Destroy(gameObject, brokenTime);
    }
    public void SetClear()
    {
        Destroy(rigidbody);
        transform.LookAt(GameObject.Find("Main Camera").transform);
        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        for (;;) {
            transform.Rotate(Vector3.forward * animationRate);
            yield return new WaitForSeconds(1 / animationFrameRate);
        }

    }
}
