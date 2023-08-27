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
    private bool alive = true;
    private int diamondValue = 3;
    [SerializeField] private GameObject particle;

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
        if (startGame && alive)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathZone")
        {
            alive = false;
            rbPlayer.velocity = Physics.gravity;
            ControlMenu.instance.GameOver();
        }

        if (other.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, other.gameObject.transform.position, Quaternion.LookRotation(new Vector3(0, 1, 0)));
            Destroy(other.gameObject);
            Destroy(part, 1.0f);
            ControlMenu.instance.AddScore(diamondValue);
        }
    }
}
