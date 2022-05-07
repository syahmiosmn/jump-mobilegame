using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody rb;
    GameObject player;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public float gravity = -9.81f;
    public float jumpHeight = 5.5f;
  

    public void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            Debug.Log(" Ground ");
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Fire1") && isGrounded)
        {
            Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);

            FindObjectOfType<AudioManager>().Play("jump");
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (velocity.y < -3f)
        {
            player = GameObject.Find("Player");
            Destroy(player);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("death");
        }


    }

}
