using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Transform target;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerControl.instance.transform;
        initialPosition = this.transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Following();
    }

    void Following()
    {
        this.transform.position = new Vector3(target.position.x + initialPosition.x, initialPosition.y, target.position.z + initialPosition.z);
    }
}
