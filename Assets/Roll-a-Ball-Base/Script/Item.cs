using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Item : MonoBehaviour
{
    public float destroyDelayTime = 1.0f;
    private Animator animator;
    bool broken = false;
    private Transform innerLight; 


    private void Start()
    {
        animator = GetComponent<Animator>();
        innerLight = transform.GetChild(0);

    }

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {
        // 接触対象はPlayerタグですか？
        if (hit.CompareTag("Player")) {
            hit.gameObject.transform.GetComponentInChildren<PlayerRendererController>().SetAnimation();
            // このコンポーネントを持つGameObjectを破棄する
            GetComponent<AudioSource>().Play();
            GetComponent<Collider>().enabled = false;
            gameObject.transform.tag = "BrokenItem";
            animator.SetTrigger("broken");
            Destroy(GetComponent<Renderer>(),destroyDelayTime);
            innerLight.gameObject.SetActive(true);
            Destroy(gameObject,destroyDelayTime);
            broken = true;
        }
    }
    private void Update()
    {
        //if (broken && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f) {
        //    Destroy(gameObject,destroyDelayTime);
        //}
    }
}
