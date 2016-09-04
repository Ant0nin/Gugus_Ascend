using UnityEngine;
using System.Collections;

public class PlatformAnimator : MonoBehaviour {

    public float speed = 0.5F;

    public Transform transform1;
    public Transform transform2;

    Vector3 position1;
    Vector3 position2;

    Rigidbody2D myBody;

    void Start()
    {
        position1 = transform1.position;
        position2 = transform2.position;
        myBody = GetComponent<Rigidbody2D>();
        myBody.velocity = new Vector2(+speed, 0);
    }

    void Update ()
    {

        float x = transform.position.x;

        if (x > position2.x)
        {
            myBody.velocity = new Vector2(-speed, 0);
        }
        else if(x < position1.x)
        {
            myBody.velocity = new Vector2(+speed, 0);
        }
    }
}
