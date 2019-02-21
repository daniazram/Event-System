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
        //shootEvent.Invoke(new object[] { Input.GetMouseButton(0) });
        moveEvent.Invoke(new object[] { Input.GetAxis("Horizontal") });
        
        if (Input.GetKeyDown(KeyCode.C))
            proneButtonPressedEvent.Invoke();

        if (Input.GetButtonDown("Jump"))
            JumpButtonPressedEvent.Invoke();

        if (Input.GetMouseButton(0))
            shootEvent.Invoke(new object[] { true });

        else if (Input.GetMouseButtonUp(0))
            shootEvent.Invoke(new object[] { false });
    }
}
