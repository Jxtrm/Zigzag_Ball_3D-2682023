using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public static PlatformGenerator instance;
    [SerializeField] private GameObject originalPlatform;
    [SerializeField] private Transform currentPlatform;
    [SerializeField] private int platformsNumber;
    private int direction;
    
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        PlatformsGenerator();
    }
    
    void PlatformsGenerator()
    {
        for(int i = 0; i<platformsNumber; i++)
        {
            NextPlatform();
        }
    }

    public void NextPlatform()
    {
        direction = Random.Range(0, 2);
        if (direction == 1)
        {
            currentPlatform = Instantiate(originalPlatform, currentPlatform.position + Vector3.right * 2, Quaternion.identity).transform;
        }
        else
        {
            currentPlatform = Instantiate(originalPlatform, currentPlatform.position + Vector3.forward * 2, Quaternion.identity).transform;
        }
    }
}
