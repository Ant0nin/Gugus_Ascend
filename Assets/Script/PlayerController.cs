using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour {

    public float speed = 10;
    public float jumpVelocity = 10;
    public float bumpForce = 2f;
    public float minVelocityBump = 0.2f;

    public LayerMask playerMask;

    Transform tagGround;
    Rigidbody2D myBody;
    AnimatorController myAnim;

    System.Random randomGen = new System.Random();

    bool isGrounded = false;
    bool isOnWall = false;
    bool wallOnLeft = false;

    public string[] actions = {"left", "up", "right"};

    void Start()
    {
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myAnim = AnimatorController.instance;
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
        myAnim.UpdateIsGround(isGrounded);
        myAnim.UpdateSpeed(myBody.velocity.x);
    }

    private void Jump()
    {
        if (isGrounded)
            myBody.velocity += jumpVelocity * Vector2.up;
        else if(isOnWall)
        {
            float x = wallOnLeft ? 1f : -1f;
            myBody.velocity += jumpVelocity * bumpForce * new Vector2(x, 1f);
        }

        EventManager.TriggerEvent("jump");
    }

    void OnEnable()
    {
        EventManager.StartListening("change", ControlsShuffle);
    }

    void ControlsShuffle()
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "wall")
        {
            isOnWall = true;
            wallOnLeft = (other.transform.position.x < transform.position.x);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            isOnWall = false;
        }
    }

}
