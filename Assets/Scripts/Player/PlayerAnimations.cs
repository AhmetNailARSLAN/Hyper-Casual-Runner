using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public static PlayerAnimations Instance;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RunAnimation();
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
