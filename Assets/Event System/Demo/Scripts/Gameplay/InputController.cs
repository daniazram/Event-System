using UnityEngine;

public class InputController : MonoBehaviour 
{
    [SerializeField]
    private GameEvent moveEvent;
    [SerializeField]
    private GameEvent JumpButtonPressedEvent;
    [SerializeField]
    private GameEvent proneButtonPressedEvent;
    [SerializeField]
    private GameEvent shootEvent;

    void Update()
    {
        moveEvent.Invoke(new object[] { Input.GetAxis("Horizontal") });
        
        if (Input.GetKeyDown(KeyCode.C))
            proneButtonPressedEvent.Invoke();

        if (Input.GetButtonDown("Jump"))
            JumpButtonPressedEvent.Invoke();

        if (Input.GetKey(KeyCode.LeftShift))
            shootEvent.Invoke(new object[] { true });

        else if (Input.GetKeyUp(KeyCode.LeftShift))
            shootEvent.Invoke(new object[] { false });
    }
}
