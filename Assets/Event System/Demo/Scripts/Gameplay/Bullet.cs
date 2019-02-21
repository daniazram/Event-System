using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Animator animator;
    private BoundToScreen bound;

    public void SetupAndMove(Transform muzzle)
    {
        if (!animator)
            animator = GetComponent<Animator>();

        if (!bound)
            bound = GetComponent<BoundToScreen>();

        transform.position = muzzle.position;
        transform.rotation = muzzle.rotation;
        
        Move(muzzle.right);
    }

    void Move(Vector3 right)
    {
        StopAllCoroutines();
        StartCoroutine(KeepMoving(right));
    }

    IEnumerator KeepMoving(Vector3 right)
    {
        var velocity = right * speed * Time.deltaTime;

        while (true)
        {
            transform.localPosition += velocity;

            if (bound.IsOutOfBounds(right.x < 0))
            { StartCoroutine(DisableAfterTime()); break; }

            yield return null;
        }
    }
    
    IEnumerator DisableAfterTime()
    {
        animator.SetTrigger("Impact");
        yield return new WaitForSeconds(0.75f);
        gameObject.SetActive(false);
        animator.ResetTrigger("Impact");
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
