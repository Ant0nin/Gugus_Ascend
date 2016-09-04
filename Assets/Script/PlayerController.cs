using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour {

    public float speed = 10, jumpVelocity = 10, maxSpeed = 20;
    public LayerMask playerMask;

    Transform tagGround;
    Rigidbody2D myBody;
    bool isGrounded = false;
    System.Random randomGen = new System.Random();

    public string[] actions = {"left", "up", "right"};

    void Start()
    {
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        myBody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetButton(actions[0])) // LEFT
        {
            if (myBody.velocity.x > 0)
                myBody.velocity = new Vector2(0, myBody.velocity.y);
            myBody.velocity += speed * Vector2.left;
        }

        if (Input.GetButton(actions[1])) // UP
        {
            Jump();
        }

        if(Input.GetButton(actions[2])) // RIGHT
        {
            if (myBody.velocity.x < 0)
                myBody.velocity = new Vector2(0, myBody.velocity.y);
            myBody.velocity += speed * Vector2.right;
        }
        
        isGrounded = Physics2D.Linecast(transform.position, tagGround.position, playerMask);        
    }

    private void Jump()
    {
        if (isGrounded) myBody.velocity += jumpVelocity * Vector2.up;
        EventManager.TriggerEvent("jump");
    }

    void OnEnable()
    {
        EventManager.StartListening("change", ControlsShuffle);
    }

    public void ControlsShuffle()
    {
        int n = actions.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(randomGen.NextDouble() * (n - i));
            string t = actions[r];
            actions[r] = actions[i];
            actions[i] = t;
        }
    }
    
}
