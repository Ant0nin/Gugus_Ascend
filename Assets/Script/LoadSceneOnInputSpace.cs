using UnityEngine;
using System.Collections;

public class LoadSceneOnInputSpace : MonoBehaviour {

    public string nextScene;
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("space"))
        {
            Application.LoadLevel(nextScene);
        }
	}
}
