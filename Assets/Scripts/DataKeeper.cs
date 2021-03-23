using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeeper : MonoBehaviour
{
    [SerializeField] int collectedStars = 0;
    [SerializeField] int totalStars = 0;
    void Awake()
    {
        var objs = FindObjectsOfType<DataKeeper>();
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        //audioSource = GetComponent<AudioSource>();
    }

    public void Count()
    {
        var frames = FindObjectsOfType<Frame>();
        if (frames.Length > 0)
        {
            foreach (Frame frame in frames)
            {
                totalStars++;
                if (frame.IsUsed())
                    collectedStars++;
            }
        }
    }

    public int GetCollectedStars()
    {
        return collectedStars;
    }

    public int GetTotalStars()
    {
        return totalStars;
    }
}
