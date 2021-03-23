using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] [Range(-100f,100f)] float horizontalBoost = 5f;
    [SerializeField] [Range(0, 100f)] float verticalBoost = 5f;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalBoost, verticalBoost);
        //Debug.Log(collision.GetComponent<Rigidbody2D>());
        animator.SetBool("isUsed", true);
    }

    void SetUnUsedState()
    {
        animator.SetBool("isUsed", false);
    }
}
