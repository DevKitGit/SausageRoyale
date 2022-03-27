using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerController : MonoBehaviour
{
    public Sausage Sausage { get;  set; }
    public PlayerInput PlayerInput { get; private set; }

    public ReadOnlyArray<InputDevice> Devices => PlayerInput.devices;
    
    public PlayerInput.ActionEvent UiNavigate;
    public PlayerInput.ActionEvent UISubmit;
    public PlayerInput.ActionEvent UiCancel;
    public PlayerInput.ActionEvent PlayerJump;
    public PlayerInput.ActionEvent PlayerMoveA;
    public PlayerInput.ActionEvent PlayerMoveB;
    public PlayerInput.ActionEvent PlayerGrabA;
    public PlayerInput.ActionEvent PlayerGrabB;
    public PlayerInput.ActionEvent PlayerPause;
    
    private InputMode _inputMode;

    public InputMode InputMode
    {
        get => _inputMode;
        set
        {
            _inputMode = value;
            PlayerInput.SwitchCurrentActionMap(InputMode.ToString());
        }
    }

    void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();
        SetupEvents();
        InputManager.AddPlayer(this);
        PlayerInput.neverAutoSwitchControlSchemes = true;
    }
    
    void SetupEvents()
    {
        var actionEvents = PlayerInput.actionEvents;
        UiNavigate = actionEvents.First(e => e.actionName.Contains("UI/Navigate"));
        UISubmit = actionEvents.First(e => e.actionName.Contains("UI/Submit"));
        UiCancel = actionEvents.First(e => e.actionName.Contains("UI/Cancel"));
        PlayerJump = actionEvents.First(e => e.actionName.Contains("Player/Jump"));
        PlayerMoveA = actionEvents.First(e => e.actionName.Contains("Player/MoveA"));
        PlayerMoveB = actionEvents.First(e => e.actionName.Contains("Player/MoveB"));
        PlayerGrabA = actionEvents.First(e => e.actionName.Contains("Player/GrabA"));
        PlayerGrabB = actionEvents.First(e => e.actionName.Contains("Player/GrabB"));
        PlayerPause = actionEvents.First(e => e.actionName.Contains("Player/Pause"));
    }
}
