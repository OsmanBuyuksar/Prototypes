using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    const string walk_param_name = "running";
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateAnimationState(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }
}
