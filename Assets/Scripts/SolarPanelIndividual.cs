using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SolarPanelIndividual : MonoBehaviour
{
    //Which order this piece should be solved in
    public int solveOrder;
    
    //Timer
    public float initialTime = 5;
    public float timeRemaining;
    bool isTimerOn;

    //Is the puzzle complete?
    bool isComplete;

    public UnityEvent chargeStartedEvent;
    public UnityEvent chargeStoppedEvent;
    public UnityEvent chargeCompleteEvent;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerOn)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log("Counting down: " + timeRemaining);
            } else
            {
                isTimerOn = false;
                isComplete = true;
                chargeCompleteEvent.Invoke();
            }
        } else if (isComplete)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    //Start charging when pointing the flashlight at the panel
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Flashlight>())
        {
            isTimerOn = true;
            chargeStartedEvent.Invoke();
        }
    }

    //Stop charging when pointing the flashlight at the panel, before timer is up
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Flashlight>())
        {
            timeRemaining = initialTime;
            isTimerOn = false;
            if (!isComplete)
            {
                chargeStoppedEvent.Invoke();
            }
        }
    }

    public void Reset()
    {
        Debug.Log("resetting!");
        timeRemaining = initialTime;
        isTimerOn = false;
        isComplete = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
}
