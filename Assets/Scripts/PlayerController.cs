using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody playerRb;
    private float zBound = 3;
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();

        
    }

    // Moves the player based on arrow key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput * Time.deltaTime);
        playerRb.AddForce(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }

    //Prevent  the player from leaving the top or bottom of the screen
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            playerRb.transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        else if (transform.position.z > zBound + 5)
        {
            playerRb.transform.position = new Vector3(transform.position.x, transform.position.y, zBound + 5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has a collided with enemy ");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }





}
