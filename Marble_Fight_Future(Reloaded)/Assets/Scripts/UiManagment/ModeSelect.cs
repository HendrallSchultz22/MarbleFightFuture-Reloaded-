using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ModeSelect : MonoBehaviour
{
    protected int selectedModeIndex;
    private Color desiredColor;

    public GameObject LevelSelector;
    public GameObject ControlInfo;
    public GameObject Difficulty;
   

    public InputDevice p1Device;
    public Gamepad p1DevicePad;
 

    private bool HasSelectedMode = false;

    [Header("List of Characters")]
    [SerializeField] protected List<ModeSelectObject> ModeList = new List<ModeSelectObject>();

    [Header("UI References")]
    [SerializeField] protected TextMeshProUGUI ModeName;
    [SerializeField] protected Image ModeSplash;
    [SerializeField] protected Image backgroundColor;


    [Header("Options")]
    [SerializeField] protected float backgroundColorTransitionSpeed = 5f;


   
    public void Start()
    {
        LevelSelector.SetActive(false);
        ControlInfo.SetActive(false);
        Difficulty.SetActive(false);

        Gamepad[] pads = Gamepad.all.ToArray();
        if (pads.Length >= 1)
        {
            p1Device = pads[0].device;
            p1DevicePad = pads[0];
        }
        UpdateModeSelectionUI();
    }




    public void Update()
    {
        if (this.gameObject.tag == "ModeSelection")
        {
            backgroundColor.color = Color.Lerp(backgroundColor.color, desiredColor, Time.deltaTime * backgroundColorTransitionSpeed);
        }
        Gamepad[] pads = Gamepad.all.ToArray();
        if (pads.Length >= 1)
        {
            if (p1DevicePad.leftStick.left.wasPressedThisFrame)
            {
                LeftArrow();
            }
            if (p1DevicePad.leftStick.right.wasPressedThisFrame)
            {
                RightArrow();
            }
            if (p1DevicePad.buttonSouth.wasPressedThisFrame)
            {
                ConfirmSelection();
            }
        }

    }



    public void ConfirmSelection()
    {
      
        
           
           
            if(ModeList[selectedModeIndex].ModeName == "Quit Game")
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
            if(ModeList[selectedModeIndex].ModeName == "Play Game")
            {
                gameObject.SetActive(false);
                LevelSelector.SetActive(true);
            }
            if (ModeList[selectedModeIndex].ModeName == "Controls Info")
            {
                gameObject.SetActive(false);
                ControlInfo.SetActive(true);

            }
        
        

    }
    public void LeftArrow()
    {
        if (HasSelectedMode)
        {
            return;
        }
        selectedModeIndex--;
        if (selectedModeIndex < 0)
        {
            selectedModeIndex = ModeList.Count - 1;
        }
        UpdateModeSelectionUI();

    }
    public void RightArrow()
    {
        if (HasSelectedMode)
        {
            return;
        }
        selectedModeIndex++;
        if (selectedModeIndex == ModeList.Count)
        {
            selectedModeIndex = 0;
        }
        UpdateModeSelectionUI();
    }
    private void UpdateModeSelectionUI()
    {
        ModeSplash.sprite = ModeList[selectedModeIndex].splash;
        ModeName.text = ModeList[selectedModeIndex].ModeName;
        desiredColor = ModeList[selectedModeIndex].ModeColor;
    }

    [System.Serializable]
    public class ModeSelectObject
    {
        public Sprite splash;
        public string ModeName;
        public Color ModeColor;
        
        
    }
}
