using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



//To-do: refactor
public class InteractionArea : MonoBehaviour
{

    public Camera playerCamera;
    GameObject player;

    //Has the puzzle been solved?
    bool isCompleted;

    //On trigger enter, focus the camera on the keycode entry pad, so player can use mouse
    private void OnTriggerEnter(Collider other)
    {
        if (!isCompleted)
        {
            if (other.CompareTag("Player"))
            {
                player = other.gameObject;
                if (player == null)
                {
                    player = FindObjectOfType<PlayerMovement>().gameObject;
                }
                playerCamera.transform.parent = transform;
                playerCamera.transform.localPosition = Vector3.zero;
                playerCamera.transform.rotation = Quaternion.identity;
                Cursor.lockState = CursorLockMode.Confined;
                FindObjectOfType<PlayerMovement>().enabled = false;
            }
        }
    }

    //On trigger exit, bring the camera back to the player
    private void OnTriggerExit(Collider other)
    {
        if (!isCompleted)
        {
            if (other.CompareTag("Player"))
            {
                RemoveCamera(player);
            }
        }
    }

    public void RemoveCamera(GameObject player)
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerMovement>().gameObject;
        }
        playerCamera.transform.parent = player.transform.parent;
        playerCamera.transform.localPosition = Vector3.zero;
        playerCamera.transform.rotation = Quaternion.Euler(0f, -270, 0f);
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<PlayerMovement>().enabled = true;


    }

    //Once the puzzle is solved, remove this script so player can freely go through door
    public void RemoveInteractionArea()
    {
        isCompleted = true;
        RemoveCamera(player);
    }

    public void OnLeave()
    {
        RemoveCamera(player);
    }
}
