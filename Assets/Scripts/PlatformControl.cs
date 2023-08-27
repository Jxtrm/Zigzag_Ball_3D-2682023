using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    private bool onPlatform;
    private Rigidbody rbPlatform;
    private Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        rbPlatform = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onPlatform && rbPlatform.isKinematic)
        {
             if(Vector3.Distance(transform.position, playerPosition.position) > 2f)
            {
                rbPlatform.isKinematic = false;
            }
        }

        if (transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerPosition = collision.transform;
            if (!onPlatform)
            {
                PlatformGenerator.instance.NextPlatform();
                onPlatform = true;
            }
        }
    }
}
