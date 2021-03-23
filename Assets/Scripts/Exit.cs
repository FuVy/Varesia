using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] bool forSquare = true;
    bool inPosition = false;
    [SerializeField] Exit secondExit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Square>() && forSquare || collision.GetComponent<Triangle>() && !forSquare)
        {
            inPosition = true;
            HandleCompletionCondition();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Square>() && forSquare || collision.GetComponent<Triangle>() && !forSquare)
        {
            inPosition = false;
        }
    }

    void HandleCompletionCondition()
    {
        if (inPosition && secondExit.ReturnState())
        {
            FindObjectOfType<Fade>().HandleLevelCompletion();
        }
    }

    public bool ReturnState()
    {
        return inPosition;
    }
}
