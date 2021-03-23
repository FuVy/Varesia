using UnityEngine;
using System.Collections;
public class Line : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    private LineRenderer line;

    void Start()
    {
        line = this.gameObject.GetComponent<LineRenderer>();
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;

        line.positionCount = 2;
        line.startColor = UnityEngine.Color.black;
        line.endColor = UnityEngine.Color.black;
    }

    void Update()
    {
        if (gameObject1 != null && gameObject2 != null)
        {
            line.SetPosition(0, gameObject1.transform.position);
            line.SetPosition(1, gameObject2.transform.position);
        }
    }

    public void HandleDeath()
    {
        line.enabled = false;
    }
}
