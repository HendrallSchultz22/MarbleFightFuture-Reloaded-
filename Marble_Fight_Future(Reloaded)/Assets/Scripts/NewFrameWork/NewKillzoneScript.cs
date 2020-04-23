using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewKillzoneScript : MonoBehaviour
{
    public CanvasControl Control;
    void OnCollisionEnter(Collision collision)
    {
        NewMovement mms = collision.collider.gameObject.GetComponentInParent<NewMovement>();
        if (mms)
        {
            Control.UI.SetActive(false);
            Control.Loss.SetActive(true);
            Destroy(collision.gameObject.GetComponentInChildren<NewCameraScript>());
            Destroy(collision.gameObject.GetComponent<PlayerInput>());
            Destroy(collision.gameObject.GetComponentInParent<NewMovement>());
           
            Debug.Log("Dead!!");
        }

    }
}
