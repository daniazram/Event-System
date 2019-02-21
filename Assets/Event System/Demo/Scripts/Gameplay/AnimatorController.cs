using UnityEngine;

public class AnimatorController : MonoBehaviour 
{
    private Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Shoot(object[] data)
    {
        animator.SetBool("Shooting", (bool)data[0]);
    }

    public void Move(object[] data)
    {
        var horizontalMovement = (float)data[0];
        animator.SetFloat("Blend", Mathf.Abs(horizontalMovement));
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    public void Prone(object[] data)
    {
        var prone = (bool)data[0];
        animator.SetBool("Crouch", prone);
    }
}
