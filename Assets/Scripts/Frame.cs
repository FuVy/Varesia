using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    bool isUsed = false;
    void Start()
    {
        isUsed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().SetBool("isUsed", true);
        isUsed = true;
    }
    
    public bool IsUsed()
    {
        return isUsed;
    }
}
