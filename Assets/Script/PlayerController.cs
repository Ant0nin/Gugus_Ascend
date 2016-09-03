using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour {

    public float speed = 10, jumpVelocity = 10;
    public LayerMask playerMask;

    Transform tagGround;
    Rigidbody2D myBody;
    bool isGrounded = false;

    void Start()
    {
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        myBody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetButton("left"))
        {
            myBody.velocity += speed * Vector2.left;
        }

        if (Input.GetButton("up"))
        {
            Jump();
        }

        if(Input.GetButton("right"))
        {
            myBody.velocity += speed * Vector2.right;
        }

        /*Vector2 startPoint = transform.position;
        Vector2 endPoint = new Vector2(transform.position.x, transform.position.y + 0.1f);

        Debug.DrawRay(new Vector3(startPoint.x, startPoint.y, 0), new Vector3(startPoint.x - endPoint.x, startPoint.y - endPoint.y, 0));*/
        isGrounded = Physics2D.Linecast(transform.position, tagGround.position, playerMask);

        Debug.Log(isGrounded);
        
    }

    public void Jump()
    {
        if (isGrounded) myBody.velocity += jumpVelocity * Vector2.up;
    }
    
}
