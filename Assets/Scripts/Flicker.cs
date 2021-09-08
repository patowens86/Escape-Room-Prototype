using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Flicker : MonoBehaviour
{
    public float minOnTime;
    public float maxOnTime;

    public float minOffTime;
    public float maxOffTime;

    public FlickeringObject[] flickeringLightbulbs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flickering());
    }

    //Turn on/off objects at random intervals, giving enough time to see the key code written on the wall
    IEnumerator Flickering()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minOnTime, maxOnTime));
            foreach(FlickeringObject flickeringLightbulb in flickeringLightbulbs)
            {
                flickeringLightbulb.gameObject.SetActive(!flickeringLightbulb.gameObject.activeInHierarchy);
            }
            yield return new WaitForSeconds(Random.Range(minOffTime, maxOffTime));
            foreach (FlickeringObject flickeringLightbulb in flickeringLightbulbs)
            {
                flickeringLightbulb.gameObject.SetActive(!flickeringLightbulb.gameObject.activeInHierarchy);
            }
        }
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

}
