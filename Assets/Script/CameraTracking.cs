using UnityEngine;
using System.Collections;

public class CameraTracking : MonoBehaviour {

    public Transform character;
	
	void Update () {
        transform.position = new Vector3(character.position.x, character.position.y, -10);
	}
}
