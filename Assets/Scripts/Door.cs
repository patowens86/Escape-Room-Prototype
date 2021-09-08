using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //To-do: create door-opening animation
    public void OpenDoor()
    {
        this.gameObject.SetActive(false);
    }
}
