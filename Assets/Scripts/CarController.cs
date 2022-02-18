using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    private Controls _controls;

    void Awake()
    {
        _controls = new Controls();
    }

    void OnEnable()
    {
        _controls.Enable();
    }

    void OnDisable()
    {
        _controls.Disable();
    }

    public void OnMove(InputAction.CallbackContext ctx) { MoveInput = ctx.ReadValue<Vector2>(); }
    
}
