using UnityEngine;
using System.Collections;

public class SkyTurnover : MonoBehaviour {

	void OnEnable()
    {
        EventManager.StartListening("change", ChangeSkyTexture);
    }
	
	void ChangeSkyTexture()
    {
        // TODO : use an animator
	}
}
