using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimated : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DoAnimation());
    }

    IEnumerator DoAnimation()
    {
        while(true)
        {
            animator.SetTrigger("Do");
            yield return new WaitForSeconds(2f);
        }
    }
}
