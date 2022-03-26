using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput m_PlayerInput { get; private set; }

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
        m_PlayerInput = GetComponent<PlayerInput>();
        SetupEvents();
    }
    
    void SetupEvents()
    {
        var actionEvents = m_PlayerInput.actionEvents;
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
