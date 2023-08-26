using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;
    public float playerSpeed;
    public bool rigthMove;
    public bool startGame;
    private Rigidbody rbPlayer;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            PlayerMovement();
        }
    }

    void PlayerMovement()
    {
        if (rigthMove)
        {
            rbPlayer.velocity = (Vector3.right * playerSpeed) + Physics.gravity;
        }
        else
        {
            rbPlayer.velocity = (Vector3.forward * playerSpeed) + Physics.gravity;
        }
    }
}
