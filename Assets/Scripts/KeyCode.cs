using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class KeyCode : MonoBehaviour
{
    //To-do: refactor to randomized code, matching the code displayed in the room
    [SerializeField]
    public string code = "589";

    int digitInt = 0;

    public TMP_Text[] codeEntry;

    public UnityEvent SolveEvent;



    //If the code on the keypad matches the answer, call the solve event
    public void CheckCode()
    {
        string entry = "";

        for (int i = 0; i < codeEntry.Length; i++)
        {

            entry += codeEntry[i].text;
            
        }
        if (entry == code)
        {
            SolveEvent.Invoke();
            Debug.Log("Correct code!");
        }
    }

    //Increase keypad digit on interaction
    public void IncreaseDigit(GameObject button)
    {
        TMP_Text digitText = button.GetComponentInChildren<TMP_Text>();
        digitInt = int.Parse(digitText.text);

        if (digitInt < 9)
        {
            digitInt++;
        } else
        {
            digitInt = 0;
        }
        digitText.text = digitInt.ToString();
        CheckCode();
    }

}
