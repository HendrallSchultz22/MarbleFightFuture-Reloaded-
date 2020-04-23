using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelSelect : MonoBehaviour
{
    protected int selectedLevelIndex;
    private Color desiredColor;

    public ModeSelect Mode;
    public DifficultySelect Difficulty;
    public GameObject Canvas;
    public GameObject player;
    public GameObject Difficulty1;
    public GameObject Difficulty2;
    public GameObject Difficulty3;
    public GameObject Difficulty4;

    public CanvasControl control;

    public GameObject SpawnPoint;

    public InputDevice p1Device;
    public Gamepad p1DevicePad;


    private bool HasSelectedLevel = false;

    [Header("List of Characters")]
    [SerializeField] public List<LevelSelectObject> LevelList = new List<LevelSelectObject>();

    [Header("UI References")]
    [SerializeField] protected TextMeshProUGUI LevelName;
    [SerializeField] protected Image LevelSplash;
    [SerializeField] protected Image backgroundColor;


    [Header("Options")]
    [SerializeField] protected float backgroundColorTransitionSpeed = 5f;



    public void Start()
    {
        Gamepad[] pads = Gamepad.all.ToArray();
        if (pads.Length >= 1)
        {
            p1Device = pads[0].device;
            p1DevicePad = pads[0];
        }
        UpdateLevelSelectionUI();
    }




    public void Update()
    {
        if (this.gameObject.tag == "LevelSelection")
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
        Instantiate(LevelList[selectedLevelIndex].SelectedLevel, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        player = GameObject.Find("Player");
        control = player.GetComponent<CanvasControl>();
        control.DestroyWorld = LevelList[selectedLevelIndex].SelectedLevel;
        Difficulty1 = GameObject.Find("TrailerOne");
        Difficulty2 = GameObject.Find("TrailerTwo");
        Difficulty3 = GameObject.Find("TrailerThree");
        Difficulty4 = GameObject.Find("TrailerFour");
        player.SetActive(false);
        Difficulty1.SetActive(false);
        Difficulty2.SetActive(false);
        Difficulty3.SetActive(false);
        Difficulty4.SetActive(false);
        gameObject.SetActive(false);
        Mode.Difficulty.gameObject.SetActive(true);
        
    }
    public void LeftArrow()
    {
        if (HasSelectedLevel)
        {
            return;
        }
        selectedLevelIndex--;
        if (selectedLevelIndex < 0)
        {
            selectedLevelIndex = LevelList.Count - 1;
        }
        UpdateLevelSelectionUI();

    }
    public void RightArrow()
    {
        if (HasSelectedLevel)
        {
            return;
        }
        selectedLevelIndex++;
        if (selectedLevelIndex == LevelList.Count)
        {
            selectedLevelIndex = 0;
        }
        UpdateLevelSelectionUI();
    }
    private void UpdateLevelSelectionUI()
    {
        LevelSplash.sprite = LevelList[selectedLevelIndex].splash;
        LevelName.text = LevelList[selectedLevelIndex].LevelName;
        desiredColor = LevelList[selectedLevelIndex].LevelColor;
    }

    [System.Serializable]
    public class LevelSelectObject
    {
        public Sprite splash;
        public string LevelName;
        public Color LevelColor;
        public GameObject SelectedLevel;

    }
}
