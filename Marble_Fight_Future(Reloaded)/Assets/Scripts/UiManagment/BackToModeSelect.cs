using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class BackToModeSelect : MonoBehaviour
{
    public ModeSelect Mode;

    public InputDevice p1Device;
    public Gamepad p1DevicePad;


    void Start()
    {
        Gamepad[] pads = Gamepad.all.ToArray();
        if (pads.Length >= 1)
        {
            p1Device = pads[0].device;
            p1DevicePad = pads[0];
        }
    }

    void Update()
    {
        Gamepad[] pads = Gamepad.all.ToArray();
        if (pads.Length >= 1)
        {
            if (p1DevicePad.buttonSouth.wasPressedThisFrame)
            {
                ConfirmSelection();
            }
        }
    }

    public void ConfirmSelection()
    {
        gameObject.SetActive(false);
        Mode.gameObject.SetActive(true);
    }
}
