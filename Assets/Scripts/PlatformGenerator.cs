using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public static PlatformGenerator instance;
    [SerializeField] private GameObject originalPlatform;
    [SerializeField] private Transform currentPlatform;
    [SerializeField] private int platformsNumber;
    [SerializeField] private GameObject diamond;
    private int randomDiamond;
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

        randomDiamond = Random.Range(0, 5);

        if (randomDiamond < 1)
        {
            Instantiate(diamond, currentPlatform.position + (Vector3.up / 2), diamond.transform.rotation);
        }
    }
}
