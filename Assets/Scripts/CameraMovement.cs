using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform square;
    Transform triangle;
    Transform cameraPosition;
    float cameraX;
    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = GetComponent<Transform>();
        square = FindObjectOfType<Square>().GetComponent<Transform>();
        triangle = FindObjectOfType<Triangle>().GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        cameraX = (square.position.x + triangle.position.x) / 2f;
        cameraPosition.position = new Vector3(cameraX, 0, -10);
    }
}
