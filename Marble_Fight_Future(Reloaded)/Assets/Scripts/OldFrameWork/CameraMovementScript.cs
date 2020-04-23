using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour {
    public GameObject Player;
    private Vector3 offset;
    public float speedH = 5.0f;
    public float speedV = 5.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
	void Start () {
        Cursor.visible = false;
        offset = transform.position - Player.transform.position;
	}
	void LateUpdate () {
        transform.position = Player.transform.position + offset;
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 2.0f);
    }
}
