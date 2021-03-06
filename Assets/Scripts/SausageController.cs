using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SausageController : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] private Rigidbody startRb;
    [SerializeField] private Rigidbody endRb;
    [SerializeField] private bool hasPlayerController = false;
    [SerializeField] private float moveForceScale = 1f;
    [SerializeField] private bool applyStartForce = false;
    [SerializeField] private bool applyEndForce = false;
    private Vector3 startForceVector = Vector3.zero;
    private Vector3 endForceVector = Vector3.zero;

    [Header("Sausage stats")] 
    [SerializeField] public float hyggeWinCondition = 100f;

    [SerializeField, Range(0f, 1000f)] public float hyggeAmount = 0f;
    [SerializeField] private float secondsPerHygge = 1;
    [SerializeField] private float hyggePerTick = 1;
    [SerializeField] public bool applyFrying = false, doneFrying = false;
    
    [SerializeField] public bool inHotspot = false;
    [SerializeField,Range(1f,4f)] public float HotspotMultiplier = 1f;
    private float time;
    private PlayerController _playerController;

    [SerializeField] public Transform canvasFollowTransform;
    [SerializeField] public Canvas canvas;
    [SerializeField] public Slider _slider;
    [SerializeField] public Image sliderImage, sliderBackgroundImage;
    
    private void Start()
    {
        if (_slider != null)
        {
            _slider.maxValue = hyggeWinCondition;
            _slider.value = hyggeAmount;
        }
        
    }

    private void FixedUpdate()
    {
        if (!applyFrying || doneFrying || !hasPlayerController /*_playerController.m_PlayerInput.currentActionMap.name != "Player"*/) return;

        if (applyStartForce)
        {
            startRb.AddForce(new(startForceVector.x*moveForceScale, 0, startForceVector.y*moveForceScale));
        }
        
        if (applyEndForce)
        {
            endRb.AddForce(new(endForceVector.x*moveForceScale, 0, endForceVector.y*moveForceScale));
        }
    }

    private void Update()
    {
        if (canvas != null)
        {
            canvas.transform.position = canvasFollowTransform.transform.position;
        }
        if (hyggeAmount >= hyggeWinCondition)
        {
            inHotspot = false;
            applyFrying = false;
            doneFrying = true;
            return;
        }
        if (applyFrying && hasPlayerController /*_playerController.m_PlayerInput.currentActionMap.name != "Player"*/)
        {
            time += Time.deltaTime;
            if (time >= secondsPerHygge) {
                time = time - secondsPerHygge;
                hyggeAmount += inHotspot ? hyggePerTick * HotspotMultiplier : hyggePerTick;
                _slider.value = hyggeAmount;

                if (sliderImage != null)
                {
                    var sliderImageColor = sliderImage.color;
                    sliderImageColor.a = _slider.normalizedValue;
                    sliderImage.color = sliderImageColor;
                }

                if (sliderBackgroundImage != null)
                {
                    var sliderBackgroundImageColor = sliderBackgroundImage.color;
                    sliderBackgroundImageColor.a = _slider.normalizedValue;
                    sliderBackgroundImage.color = sliderBackgroundImageColor;
                }
                inHotspot = false;
            }
        }

    }

    // Start is called before the first frame update
    public void SetPlayerController(PlayerInput playerInput)
    {
        hasPlayerController = true;
        _playerController = playerInput.gameObject.GetComponent<PlayerController>();
        _playerController.PlayerJump.AddListener(Jump);
        _playerController.PlayerMoveA.AddListener(MoveStartRb);
        _playerController.PlayerMoveB.AddListener(MoveEndRb);
        _playerController.PlayerPause.AddListener(EnableUIActionMap);
    }

    public void SetCanvas(Canvas canvas)
    {
        this.canvas = canvas;
        _slider = canvas.GetComponentInChildren<Slider>();
        sliderBackgroundImage = _slider.GetComponentsInChildren<Image>()[0];
        sliderImage = _slider.GetComponentsInChildren<Image>()[1];
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
