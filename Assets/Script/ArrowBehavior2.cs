using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {

    Vector3 initialPosition;

    public float distance = 1f;
    public float speed = 0.5f;

    float offsetX = 0f;
	
    void Start()
    {
        initialPosition = transform.position;
    }

	void Update ()
    {
        offsetX += speed;
        if (offsetX > distance)
            offsetX = 0;

        float x = initialPosition.x + offsetX;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
