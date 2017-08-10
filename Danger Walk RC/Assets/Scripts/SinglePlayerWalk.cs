using UnityEngine;
using System.Collections;

public class SinglePlayerWalk : MonoBehaviour {

    public float moveSpeed;
    private bool isWalking;
    private Animator anim;
    private float interval = 0.01f;
    private float nextTime = 0;
    private bool playerMoving;
    private Vector2 lastMove;
    public float timeZeroToMax = 2.5f;
    private float accelRatePerSec;
    private float forwardVelocity;
    private Rigidbody2D rigb2d;
    private decimal i = 0m;
    private bool holdingDown;
    private bool isRotate;
    private bool isHorizontal;
    private bool isVertical;
    private bool isLeader;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rigb2d = GetComponent<Rigidbody2D>();        
    }
    void acceleration()
    {
        if (isLeader)
        {
            if (Input.anyKey)
            {

                if (i < 0.5m)
                {
                    holdingDown = true;
                    i += 0.009m;
                    if (isHorizontal)
                    {
                        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime * (float)i, 0f, 0f));
                    }
                    if (isVertical)
                    {
                        transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime * (float)i, 0f));
                    }

                }

                if (!Input.anyKey && holdingDown)
                {
                    i = 0.0m;
                    holdingDown = false;
                }
            }

        }

    }
    void SetAnimation()
    {
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
    // Update is called once per frame
    void Walking()
    {

        playerMoving = false;
        isHorizontal = false;
        isVertical = false;
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {

            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

            isHorizontal = true;

        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {

            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;

            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            isVertical = true;
        }
        SetAnimation();
    }
  
    void Update()
    {
        Walking();
    }

}


