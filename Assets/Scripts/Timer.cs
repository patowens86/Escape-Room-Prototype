using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;



public class Timer : MonoBehaviour
{
    [SerializeField]
    private float initialTime = 300;

    float timeRemaining;

    public TMP_Text countdownText;

    public UnityEvent OnTimerFinish;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            countdownText.text = (Mathf.FloorToInt(timeRemaining / 60)).ToString("00") + ":" + (Mathf.FloorToInt(timeRemaining % 60)).ToString("00");
        } else
        {
            Cursor.lockState = CursorLockMode.None;
            OnTimerFinish.Invoke();
        }

    }
}
