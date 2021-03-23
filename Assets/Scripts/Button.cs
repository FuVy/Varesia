using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool isPressed;
    Animator animator;
    Rigidbody2D squarerb;
    DistanceJoint2D joint;
    Line line;
    bool connected = true;
    [SerializeField] LayerMask whatIsBox;
    [SerializeField] Transform boxCheck;
    bool isBoxed = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        squarerb = FindObjectOfType<Square>().GetComponent<Rigidbody2D>();
        joint = FindObjectOfType<Square>().GetComponent<DistanceJoint2D>();
        line = FindObjectOfType<Line>();
        connected = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("isPressed", true);
        isPressed = true;
        if ((isBoxed && !collision.gameObject.GetComponent<Square>()) || !isBoxed)
            HandleConnection();
    }

    private void FixedUpdate()
    {
        isBoxed = Physics2D.OverlapCircle(boxCheck.position, 0.2f, whatIsBox);
    }

    private void HandleConnection()
    {
        //Debug.Log(joint.connectedBody);
        //Debug.Log(squarerb);
        if (joint.connectedBody == squarerb)
        {
            joint.connectedBody = FindObjectOfType<Triangle>()?.GetComponent<Rigidbody2D>();
            line.GetComponent<LineRenderer>().enabled = true;
            connected = true;
        }
        else //if(joint.connectedBody == squarerb)
        {
            joint.connectedBody = squarerb;
            line.GetComponent<LineRenderer>().enabled = false;
            connected = false;
        }
        /*
        if (connected)
        {
            UnConnect();
        }
        else
        {
            Connect();
        }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((isBoxed && !collision.gameObject.GetComponent<Square>()) || !isBoxed)
        {
            animator.SetBool("isPressed", false);
            isPressed = false;
        }
    }
    /*
    public void Connect()
    {
        joint.connectedBody = FindObjectOfType<Triangle>()?.GetComponent<Rigidbody2D>();
        line.GetComponent<LineRenderer>().enabled = true;
        connected = true;
    }
    public void UnConnect()
    {
        joint.connectedBody = null;//FindObjectOfType<Triangle>()?.GetComponent<Rigidbody2D>();
        line.GetComponent<LineRenderer>().enabled = false;
        connected = false;
    }
    */
}
