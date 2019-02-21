using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField]
    private bool keepInBounds;
    [SerializeField]
    private float deadZone;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private GameEvent proneEvent;
    [SerializeField]
    private GameEvent jumpEvent;

    private bool prone;
    private Vector3 velocity;
    private Vector3 defaultScale;
    private Rigidbody2D rigidBody;
    private BoundToScreen boundsController;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boundsController = GetComponent<BoundToScreen>();
        defaultScale = transform.localScale;
    }
    
    public void Shoot(object[] data)
    {
    }

    public void UpdateVelocity(object[] data)
    {
        var horizontalMovement = (float)data[0];
        if (Mathf.Abs(horizontalMovement) <= deadZone)
            return;

        if (boundsController && keepInBounds)
            if (boundsController.IsOutOfBounds(horizontalMovement < 0))
                return;

        velocity = Vector3.right * (horizontalMovement * speed * Time.deltaTime);
        
        if(!prone)
            transform.position += velocity;

        if (Mathf.Abs(horizontalMovement) > 0)
            ChangeDirection(horizontalMovement > 0 ? 1 : -1);
    }

    public void Jump()
    {
        if (prone || !Grounded())
            return;

        jumpEvent.Invoke();
        rigidBody.AddForce(Vector3.up * jumpForce);
    }

    public void Prone()
    {
        if (!Grounded())
            return;
        
        prone = !prone;
        proneEvent.Invoke(new object[] { prone });
    }

    bool Grounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, groundRadius, ground);
        return colliders.Length > 0;
    }

    void ChangeDirection(int direction)
    {
        transform.localScale = new Vector3(defaultScale.x * direction, defaultScale.y, defaultScale.z);
    }
}
