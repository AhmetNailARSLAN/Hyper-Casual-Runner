using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void WinAnimation()
    {
        animator.SetTrigger("win");
    }
    public void LoseAnimation()
    {
        animator.SetTrigger("die");
    }
    public void RunAnimation()
    {
        animator.SetBool("run", true);
    }
    public void KickAnimaiton()
    {
        animator.SetTrigger("kick");
    }
}
