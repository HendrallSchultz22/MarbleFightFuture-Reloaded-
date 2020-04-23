using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasControl : MonoBehaviour
{
    public GameObject link;
    public DifficultySelect select;

    public GameObject UI;

    public GameObject Loss;

    public GameObject DestroyWorld;

    public GameObject WorldToDie;
    
    public GameObject Win;

    public InputDevice p1Device;
    public Gamepad p1DevicePad;
    public void Awake()
    {
        UI.SetActive(true);
        Loss.SetActive(false);
        Win.SetActive(false);
    }
    public void Start()
    {
        
        Gamepad[] pads = Gamepad.all.ToArray();
        if (pads.Length >= 1)
        {
            p1Device = pads[0].device;
            p1DevicePad = pads[0];
        }
       
    }
    public void Update()
    {
        link = GameObject.Find("DifficultySelector");
        select = link.GetComponent<DifficultySelect>();
        WorldToDie = GameObject.Find(DestroyWorld.name + "(Clone)");
        Gamepad[] pads = Gamepad.all.ToArray();
        if (pads.Length >= 1)
        {
            if (Loss.activeSelf == true && p1DevicePad.buttonEast.wasPressedThisFrame || Win.activeSelf == true && p1DevicePad.buttonEast.wasPressedThisFrame)
            {
                QuitGame();
            }
            if (Loss.activeSelf == true && p1DevicePad.buttonWest.wasPressedThisFrame || Win.activeSelf == true && p1DevicePad.buttonWest.wasPressedThisFrame)
            {
                ReturntoSelect();
            }
        }
    }
    public void ReturntoSelect()
    {

        
        select.Level.Mode.gameObject.SetActive(true);
        select.Maincamera.SetActive(true);
        Destroy(WorldToDie);
        link.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Applicaiton");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#endif

        Application.Quit();
    }
}
