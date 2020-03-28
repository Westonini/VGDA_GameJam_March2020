using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;

    public Collider2D collider;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayWalkAnim()
    {
        anim.SetBool("Walking", true);
    }

    public void StopWalkAnim()
    {
        anim.SetBool("Walking", false);
    }

    public void PlayJumpAnim()
    {
        StartCoroutine(ToggleCollider(0.2f, 0.583f));
        StartCoroutine(PlayShortAnim("Jumping", 0.583f));

    }

    private IEnumerator PlayShortAnim(string animName, float animEndTime)
    {
        anim.SetBool(animName, true);
        yield return new WaitForSeconds(animEndTime);
        anim.SetBool(animName, false);

    }

    private IEnumerator ToggleCollider(float startDisableCollider, float endDisableCollider)
    {
        yield return new WaitForSeconds(startDisableCollider);
        collider.enabled = false;
        yield return new WaitForSeconds(endDisableCollider);
        collider.enabled = true;
    }

}
