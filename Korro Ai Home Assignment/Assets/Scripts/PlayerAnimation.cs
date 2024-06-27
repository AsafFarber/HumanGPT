using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void MoveAnimation(float direction)
    {
        animator.SetFloat("direction", direction);
    }
    public void Jump()
    {
        animator.SetTrigger("jump");
    }
    public void CarryAnimation(bool apply)
    {
        if (apply)
            animator.SetLayerWeight(1, 1);
        else
            animator.SetLayerWeight(1, 0);
    }
    public void HitAnimation()
    {
        animator.SetLayerWeight(2, 1);
        animator.SetTrigger("hit");
        IEnumerator coroutine = DisableHitLayer();
        StartCoroutine(coroutine);
    }
    IEnumerator DisableHitLayer()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetLayerWeight(2, 0);
    }

}
