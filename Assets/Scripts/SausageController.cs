using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SausageController : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField] private Rigidbody startRb;
    [SerializeField] private Rigidbody endRb;
    private Vector3 startForceVector = Vector3.zero;
    private Vector3 endForceVector = Vector3.zero;
    private bool applyStartForce = false;
    private bool applyEndForce = false;
    
    [SerializeField] private float moveForceScale = 1f;
    private void FixedUpdate()
    {
        if (_playerController.PlayerInput.currentActionMap.name != "Player") return;
        if (applyStartForce)
        {
            startRb.AddForce(new(startForceVector.x*moveForceScale, 0, startForceVector.y*moveForceScale));
        }
        
        if (applyEndForce)
        {
            endRb.AddForce(new(endForceVector.x*moveForceScale, 0, endForceVector.y*moveForceScale));
        }
    }
    // Start is called before the first frame update
    void SetPlayerController(PlayerController playerController)
    {
        _playerController = playerController;
        _playerController.PlayerJump.AddListener(Jump);
        _playerController.PlayerMoveA.AddListener(MoveStartRb);
        _playerController.PlayerMoveB.AddListener(MoveEndRb);
        _playerController.PlayerPause.AddListener(EnableUIActionMap);
    }
    
    void MoveStartRb(InputAction.CallbackContext callbackContext)
    {
        applyStartForce = callbackContext.performed;
        if (callbackContext.performed)
        {
            startForceVector = callbackContext.ReadValue<Vector2>();
        }
    }
    
    void MoveEndRb(InputAction.CallbackContext callbackContext)
    {
        applyEndForce = callbackContext.performed;
        if (callbackContext.performed)
        {
            endForceVector = callbackContext.ReadValue<Vector2>();
        }
    }
    void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {

        }
    }
    private void EnableUIActionMap(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _playerController.PlayerInput.SwitchCurrentActionMap("UI");
        }
    }
}
