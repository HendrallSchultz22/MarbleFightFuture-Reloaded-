using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalOneScript : MonoBehaviour
{
    public AudioClip Bap;
    public AudioClip Pew;
    AudioSource source;
    AudioSource MusicSource;
    public static int GateOneCount = 0;
    public Text GateOneCountText;
    string MainMenuScene = "Main Menu";
    void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "CheckOnePointOne")
        {
            Destroy(this.gameObject);
            GateOneCount += 1;
        }
        if (this.gameObject.tag == "CheckOnePointTwo")
        {
            Destroy(this.gameObject);
            GateOneCount += 1;
        }
        if (this.gameObject.tag == "CheckOnePointThree")
        {
            Destroy(this.gameObject);
            GateOneCount += 1;
        }
        if (this.gameObject.tag == "CheckOnePointFour")
        {
            Destroy(this.gameObject);
            GateOneCount += 1;
        }
        if (this.gameObject.tag == "CheckOnePointFive")
        {
            Destroy(this.gameObject);
            GateOneCount += 1;
        }
        if (this.gameObject.tag == "GoalOneGate")
        {
            if (GateOneCount < 5)
            {
                source.PlayOneShot(Bap);
            }
            if (GateOneCount == 5)
            {
                source.PlayOneShot(Pew);
                SceneManager.LoadScene(MainMenuScene);
            }
        }
    }
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        GateOneCountText.text = "Player Gate One Count: " + GateOneCount;
    }
}

