using UnityEngine;
using System.Collections;

public class TriggerAutoChange : MonoBehaviour {

    public float delay = 5f;

    void Start()
    {
        StartCoroutine("DoCheck");
    }

    IEnumerator DoCheck()
    {
        for (;;)
        {
            EventManager.TriggerEvent("change");
            yield return new WaitForSeconds(delay);
        }
    }
}
