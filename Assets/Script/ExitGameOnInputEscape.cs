using UnityEngine;
using System.Collections;

public class ExitGameOnInputEscape : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("escape"))
        {
            Application.Quit();
        }
	}
}
