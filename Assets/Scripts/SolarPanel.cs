using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SolarPanel : MonoBehaviour
{
    public bool firstCompleted;
    public bool secondCompleted;
    public bool thirdCompleted;
    public bool fourthCompleted;

    //The event that happens on solving the puzzle
    public UnityEvent SolveEvent;


    //To-do: refactor into array-based check
    public void SolveCheck(float order)
    {
        switch (order)
        {
            case 1:
                firstCompleted = true;
                break;
            case 2:
                secondCompleted = true;
                break;
            case 3:
                thirdCompleted = true;
                break;
            case 4:
                fourthCompleted = true;
                break;
        }

        if (firstCompleted) 
        {
            if (secondCompleted)
            {
                if (thirdCompleted)
                {
                    if (fourthCompleted)
                    {
                        SolveEvent.Invoke();
                    }
                }
            }
            else if (thirdCompleted || fourthCompleted)
            {
                Reset();
            }
        }
        else if (secondCompleted || thirdCompleted || fourthCompleted)
        {
            Reset();
        }
    }

    public void Reset()
    {
        
        SolarPanelIndividual[] panels = GetComponentsInChildren<SolarPanelIndividual>();
        foreach (SolarPanelIndividual panel in panels)
        {

            panel.Reset();
        }
        firstCompleted = false;
        secondCompleted = false;
        thirdCompleted = false;
        fourthCompleted = false;
        
    }
}
