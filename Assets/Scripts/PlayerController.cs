using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    private bool isOnGround = true;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            // ForceMode.Impulse make the jump immidiate
            // And we are adding force up to the RigidBody of the player
            // And we are relying on the Physics of Unity to handle the fall down because gravity is enabled on the character
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

             isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
