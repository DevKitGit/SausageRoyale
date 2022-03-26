using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActionAsset _asset;
    [SerializeField] private Rigidbody startRb;
    [SerializeField] private Rigidbody endRb;
    [SerializeField] private float moveForceScale = 1f;
    private PlayerInput _playerInput;
    private List<int> _inputIDs;

    private Vector3 startForceVector = Vector3.zero;
    private Vector3 endForceVector = Vector3.zero;
    private bool applyStartForce = false;
    private bool applyEndForce = false;
    public PlayerInput.ActionEvent
        UiNavigate,
        UISubmit,
        UiCancel,
        PlayerJump,
        PlayerMoveA,
        PlayerMoveB,
        PlayerGrabA,
        PlayerGrabB,
        PlayerPause;
    
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        SetupEvents();
    }
    
    private void FixedUpdate()
    {
        if (_playerInput.currentActionMap.name != "Player") return;
        if (applyStartForce)
        {
            startRb.AddForce(new(startForceVector.x*moveForceScale, 0, startForceVector.y*moveForceScale));
        }
        
        if (applyEndForce)
        {
            endRb.AddForce(new(endForceVector.x*moveForceScale, 0, endForceVector.y*moveForceScale));
        }
    }
    
    void SetupEvents()
    {
        var actionEvent = _playerInput.actionEvents;
        UiNavigate = actionEvent.First(e => e.actionName.Contains("UI/Navigate"));
        UISubmit = actionEvent.First(e => e.actionName.Contains("UI/Submit"));
        UiCancel = actionEvent.First(e => e.actionName.Contains("UI/Cancel"));
        PlayerJump = actionEvent.First(e => e.actionName.Contains("Player/Jump"));
        PlayerMoveA = actionEvent.First(e => e.actionName.Contains("Player/MoveA"));
        PlayerMoveB = actionEvent.First(e => e.actionName.Contains("Player/MoveB"));
        PlayerGrabA = actionEvent.First(e => e.actionName.Contains("Player/GrabA"));
        PlayerGrabB = actionEvent.First(e => e.actionName.Contains("Player/GrabB"));
        PlayerPause = actionEvent.First(e => e.actionName.Contains("Player/Pause"));
        PlayerJump.AddListener(Jump);
        PlayerMoveA.AddListener(MoveStartRb);
        PlayerMoveB.AddListener(MoveEndRb);
        PlayerPause.AddListener(EnableUIActionMap);
    }
    
    private void EnableUIActionMap(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _playerInput.SwitchCurrentActionMap("UI");
        }
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


}
