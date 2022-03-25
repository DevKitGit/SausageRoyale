using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody startRb;
    [SerializeField] private Rigidbody endRb;
    [SerializeField] private float moveForceScale = 1f;
    private SausageInputActions _sausageInputActions;
    private bool _inputActive;
    // Start is called before the first frame update
    void Start()
    {
        _inputActive = false;
        _sausageInputActions = new SausageInputActions();
    }

    private void AssignSausage(Rigidbody start, Rigidbody end)
    {
        _inputActive = true;
        startRb = start;
        endRb = end;
    }

    private void SetInputActive(bool inputActive)
    {
        _inputActive = inputActive;
        if (inputActive)
        {
            _sausageInputActions.Player.MoveA.performed += MoveStartRB;
            _sausageInputActions.Player.MoveB.performed += MoveEndRB;
            _sausageInputActions.Player.Jump.performed += Jump;
            return;
        }
        _sausageInputActions.Player.MoveA.performed -= MoveStartRB;
        _sausageInputActions.Player.MoveB.performed -= MoveEndRB;
        _sausageInputActions.Player.Jump.performed -= Jump;
    }
    private void Jump(InputAction.CallbackContext callbackContext)
    {
        //Future do stuff
        Debug.Log("jump");
    }

    private void OnDisable()
    {
        SetInputActive(false);
    }

    private void MoveStartRB(InputAction.CallbackContext callbackContext)
    {
        var moveDirection = callbackContext.ReadValue<Vector2>() * moveForceScale;
        startRb.AddForce(new Vector3(moveDirection.x, 0, moveDirection.y));
    }
    
    private void MoveEndRB(InputAction.CallbackContext callbackContext)
    {
        var moveDirection = callbackContext.ReadValue<Vector2>() * moveForceScale;
        endRb.AddForce(new Vector3(moveDirection.x, 0, moveDirection.y));
    }
    // Update is called once per frame

}
