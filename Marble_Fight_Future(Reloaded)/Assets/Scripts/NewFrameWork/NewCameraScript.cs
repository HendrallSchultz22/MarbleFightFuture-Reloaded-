using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewCameraScript : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;
    public Vector2 Cammove;
    private Player1 Controls = null;
    Gamepad P1;
    void Start()
    {
        Controls = new Player1();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void LateUpdate()
    {
        CameraMove();  
    }

    void CameraMove()
    {
        Gamepad[] pads = Gamepad.all.ToArray();
        if (pads.Length < 1)
        {
            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);

            transform.LookAt(Target);

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
        else
        {
            P1 = pads[0];
            mouseX += P1.rightStick.x.ReadValue() * RotationSpeed;
            mouseY -= P1.rightStick.y.ReadValue() * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);
            
            transform.LookAt(Target);

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
        
    }

    public void OnCameraMove(InputValue value)
    {
        Cammove = value.Get<Vector2>();
    }
}
