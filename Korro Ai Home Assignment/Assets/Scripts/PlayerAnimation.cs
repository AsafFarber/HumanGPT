using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

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
        animator.SetLayerWeight(1, apply ? 1 : 0);
    }

    public void HitAnimation()
    {
        animator.SetLayerWeight(2, 1);
        animator.SetTrigger("hit");
        StartCoroutine(DisableHitLayer());
    }

    private IEnumerator DisableHitLayer()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetLayerWeight(2, 0);
    }
}
