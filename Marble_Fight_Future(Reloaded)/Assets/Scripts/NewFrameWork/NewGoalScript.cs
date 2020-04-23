using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NewGoalScript : MonoBehaviour
{
    public AudioClip Bap;
    public AudioClip Pew;
    AudioSource source;
    AudioSource MusicSource;
    public CanvasControl Control;
    public static int GateOneCount = 0;
    public Text GateOneCountText;
    public GameObject Player;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NewMovement>())
        {
            if (this.gameObject.tag == "CheckPointOne")
            {
                Destroy(this.gameObject);
                GateOneCount += 1;
                if (GateOneCount < 4)
                {
                    source.PlayOneShot(Bap);
                }
                if (GateOneCount == 4)
                {
                    Control.UI.SetActive(false);
                    Control.Win.SetActive(true);
                    Destroy(Player.GetComponent<PlayerInput>());
                    Destroy(Player.GetComponent<NewMovement>());
                    source.PlayOneShot(Pew);
                    Debug.Log("You Win!");
                }
            }
            if (this.gameObject.tag == "CheckPointTwo")
            {
                Destroy(this.gameObject);
                GateOneCount += 1;
                if (GateOneCount < 4)
                {
                    source.PlayOneShot(Bap);
                }
                if (GateOneCount == 4)
                {
                    Control.UI.SetActive(false);
                    Control.Win.SetActive(true);
                    Destroy(Player.GetComponent<PlayerInput>());
                    Destroy(Player.GetComponent<NewMovement>());
                    source.PlayOneShot(Pew);
                    Debug.Log("You Win!");
                }
            }
            if (this.gameObject.tag == "CheckPointThree")
            {
                Destroy(this.gameObject);
                GateOneCount += 1;
                if (GateOneCount < 4)
                {
                    source.PlayOneShot(Bap);
                }
                if (GateOneCount == 4)
                {
                    Control.UI.SetActive(false);
                    Control.Win.SetActive(true);
                    Destroy(Player.GetComponent<PlayerInput>());
                    Destroy(Player.GetComponent<NewMovement>());
                    source.PlayOneShot(Pew);
                    Debug.Log("You Win!");
                }
            }
            if (this.gameObject.tag == "CheckPointFour")
            {
                Destroy(this.gameObject);
                GateOneCount += 1;
                if (GateOneCount < 4)
                {
                    source.PlayOneShot(Bap);
                }
                if (GateOneCount == 4)
                {
                    Control.UI.SetActive(false);
                    Control.Win.SetActive(true);
                    Destroy(Player.GetComponent<PlayerInput>());
                    Destroy(Player.GetComponent<NewMovement>());
                    source.PlayOneShot(Pew);
                    Debug.Log("You Win!");
                }
            }
        }
       
        
        
    }
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        GateOneCountText.text = "Player Goal Points: " + GateOneCount;
    }
}

