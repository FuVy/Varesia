using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] Text starsText;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        var totalStars = FindObjectOfType<DataKeeper>().GetTotalStars();
        var collectedStars = FindObjectOfType<DataKeeper>().GetCollectedStars();
        starsText.text = "Количество активированных светильников - " + collectedStars + "/" + totalStars + "\nAmount of activated lanterns - " + collectedStars + "/" + totalStars; 
    }
}
