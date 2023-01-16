using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{

    public GameObject player;
    private Vector2 mousemovement;
    private float xRotation, yRotation;
    private float mouseSensitivity = 40;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        
        transform.position = pos;
        
        mousemovement = Mouse.current.delta.ReadValue();
        
        xRotation -= mousemovement.y * Time.deltaTime * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        yRotation += mousemovement.x * Time.deltaTime * mouseSensitivity;
        
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
