using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DifficultySelect : MonoBehaviour
{
    protected int selectedDifficultyIndex;
    private Color desiredColor;

    public LevelSelect Level;

    public GameObject Maincamera;

    public InputDevice p1Device;
    public Gamepad p1DevicePad;

    private bool HasSelectedDifficulty = false;

    [Header("List of Characters")]
    [SerializeField] protected List<DifficultySelectObject> DifficultyList = new List<DifficultySelectObject>();

    [Header("UI References")]
    [SerializeField] protected TextMeshProUGUI DifficultyName;
    [SerializeField] protected Image DifficultySplash;
    [SerializeField] protected Image backgroundColor;


    [Header("Options")]
    [SerializeField] protected float backgroundColorTransitionSpeed = 5f;



    public void Start()
    {
        Maincamera = Camera.main.gameObject;
        Gamepad[] pads = Gamepad.all.ToArray();
        if (pads.Length >= 1)
        {
            p1Device = pads[0].device;
            p1DevicePad = pads[0];
        }
        UpdateDifficultySelectionUI();
    }




    public void Update()
    {
        if (this.gameObject.tag == "DifficultySelection")
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
        if (!HasSelectedDifficulty)
        {
            
            if (DifficultyList[selectedDifficultyIndex].DifficultyName == "CakeWalk(Very Easy)")
            {
                
                Level.player.SetActive(true);
                Maincamera.SetActive(false);
            }
            if (DifficultyList[selectedDifficultyIndex].DifficultyName == "You'll Be Fine(Easy)")
            {
                Level.Difficulty1.gameObject.SetActive(true);
                Level.player.SetActive(true);
                Maincamera.SetActive(false);
            }
            if (DifficultyList[selectedDifficultyIndex].DifficultyName == "Watch your 6(Intermediate)")
            {
                Level.Difficulty1.gameObject.SetActive(true);
                Level.Difficulty2.gameObject.SetActive(true);
                Level.player.SetActive(true);
                Maincamera.SetActive(false);
            }
            if (DifficultyList[selectedDifficultyIndex].DifficultyName == "Move Wisely(Hard)")
            {
                Level.Difficulty1.gameObject.SetActive(true);
                Level.Difficulty2.gameObject.SetActive(true);
                Level.Difficulty3.gameObject.SetActive(true);
                Level.player.SetActive(true);
                Maincamera.SetActive(false);
            }
            if (DifficultyList[selectedDifficultyIndex].DifficultyName == "Try Not Dying(Death)")
            {
                Level.Difficulty1.gameObject.SetActive(true);
                Level.Difficulty2.gameObject.SetActive(true);
                Level.Difficulty3.gameObject.SetActive(true);
                Level.Difficulty4.gameObject.SetActive(true);
                Level.player.SetActive(true);
                Maincamera.SetActive(false);
            } 
        }
       
    }
    public void LeftArrow()
    {
        if (HasSelectedDifficulty)
        {
            return;
        }
        selectedDifficultyIndex--;
        if (selectedDifficultyIndex < 0)
        {
            selectedDifficultyIndex = DifficultyList.Count - 1;
        }
        UpdateDifficultySelectionUI();

    }
    public void RightArrow()
    {
        if (HasSelectedDifficulty)
        {
            return;
        }
        selectedDifficultyIndex++;
        if (selectedDifficultyIndex == DifficultyList.Count)
        {
            selectedDifficultyIndex = 0;
        }
        UpdateDifficultySelectionUI();
    }
    private void UpdateDifficultySelectionUI()
    {
        DifficultySplash.sprite = DifficultyList[selectedDifficultyIndex].splash;
        DifficultyName.text = DifficultyList[selectedDifficultyIndex].DifficultyName;
        desiredColor = DifficultyList[selectedDifficultyIndex].DifficultyColor;
    }

    [System.Serializable]
    public class DifficultySelectObject
    {
        public Sprite splash;
        public string DifficultyName;
        public Color DifficultyColor;

    }
}
