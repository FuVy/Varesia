using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatform : MonoBehaviour
{
    [SerializeField] bool friendlyToTriangle = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (friendlyToTriangle)
        {
            collision.gameObject.GetComponent<Square>()?.HandleDeath();
        }
        else
        {
            collision.gameObject.GetComponent<Triangle>()?.HandleDeath();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (friendlyToTriangle)
        {
            collision.gameObject.GetComponent<Square>()?.HandleDeath();
        }
        else
        {
            collision.gameObject.GetComponent<Triangle>()?.HandleDeath();
        }
    }
}
