using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem smokeParticles;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool gameOver = false;

    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudioSource;

    private float sfxVolume = 1.0f;
    private bool isOnGround = true;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // ForceMode.Impulse make the jump immidiate
            // And we are adding force up to the RigidBody of the player
            // And we are relying on the Physics of Unity to handle the fall down because gravity is enabled on the character
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticles.Stop();
            playerAudioSource.PlayOneShot(jumpSound, sfxVolume);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        } else if (collision.collider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAudioSource.PlayOneShot(crashSound, sfxVolume);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over !");
            smokeParticles.Play();
            dirtParticles.Stop();

        }    
    }
}
