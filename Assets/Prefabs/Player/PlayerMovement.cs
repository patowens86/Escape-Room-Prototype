using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    //Sensitivity settings for both horizontal and vertical MouseLook, for more comfortable experience
    public float lookVerticalSensitivity = 100f;
    public float lookHorizontalSensitivity = 100f;

    public Transform playerCamera;

    //Look variables
    float xRotation = 0f;
    float yRotation = 0f;

    public CharacterController controller;

    //Axis variables for player movement
    float x;
    float z;

    public float speed = 5f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        //to-do: refactor If statement
        if (x != 0 || z != 0)
        {
            Move();
        }
    }

    //Get input data from new input system
    void OnMove(InputValue input)
    {
        Vector2 axisValue = input.Get<Vector2>();

        x = axisValue.x;
        z = axisValue.y;
    }

    //Translate input data into basic forward/backwards and strafe movements
    void Move()
    {
        Vector3 move = transform.right * x + transform.forward * z;
        //controller.Move(move * speed * Time.deltaTime);
        controller.Move(move * speed * Time.fixedDeltaTime);
    }

    //Get input data for Look from new input system
    void OnLook(InputValue input)
    {
        Vector2 axisValue = input.Get<Vector2>();
        Look(axisValue);
    }

    //Translate input data, so player can look up/down/left/right
    void Look(Vector2 axisValue)
    {
        //float mouseX = axisValue.x * lookHorizontalSensitivity * Time.deltaTime;
        float mouseX = axisValue.x * lookHorizontalSensitivity * Time.fixedDeltaTime;
        //float mouseY = axisValue.y * lookVerticalSensitivity * Time.deltaTime;
        float mouseY = axisValue.y * lookVerticalSensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX; 

        transform.localRotation = Quaternion.Euler(0, yRotation, 0f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0, 0f);

    }


}
