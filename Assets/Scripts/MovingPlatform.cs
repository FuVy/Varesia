using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    //bool comingFromFirstPosition = true;
    Vector2 targetPosition;
    
    void Start()
    {
        targetPosition = target2.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * 0.01f);
        
        
        if (transform.position == target2.position)
        {
            targetPosition = target1.position;
        }
        else if (transform.position == target1.position)
        {
            targetPosition = target2.position;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(this.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
