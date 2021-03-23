using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRope : MonoBehaviour
{
    [SerializeField] float changeSize = 2f;
    [SerializeField] float waitTime = 5f;
    [SerializeField] bool fixedSize = false;
    float defaultSize;
    private void Start()
    {
        defaultSize = FindObjectOfType<Square>().GetComponent<DistanceJoint2D>().distance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FullChange());
    }

    void ChangeSize(float size)
    {
        var check = FindObjectsOfType<Square>().Length; //небольшой багфикс, чтобы игра не вылетала при попытке взять увеличение размера после смерти квадрата
        if (check > 0 && !fixedSize)
            FindObjectOfType<Square>().GetComponent<DistanceJoint2D>().distance += size;
        else if (check > 0 && fixedSize)
            FindObjectOfType<Square>().GetComponent<DistanceJoint2D>().distance = size;
    }

    IEnumerator FullChange()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        GetComponent<Collider2D>().enabled = false;
        if (!fixedSize)
        {
            ChangeSize(changeSize);
            yield return new WaitForSeconds(waitTime);
            ChangeSize(changeSize * -1);
        }
        else
        {
            ChangeSize(changeSize);
            yield return new WaitForSeconds(waitTime);
            ChangeSize(defaultSize);
        }
        Destroy(this.gameObject);
    }
}
