using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;

    public string pushedByName = "Self";
    public int placeOrder;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude < speed)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
            rb.AddForce(movement * speed);
        }
        
        if (transform.position.y < -5)
        {
            Dead();
        }
    }

    private void Dead()
    {
        placeOrder = Leaderboard.AddLeaderboard(gameObject.name);
        Destroy(gameObject);
        ScreenManager.instance.OpenScreen(ScreenNames.EndScreen);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate the direction of the collision
            Vector3 collisionDirection = transform.position - collision.contacts[0].point;
            collisionDirection.y = 0f;
            collisionDirection.Normalize();

            // Apply bounce force to both objects
            rb.AddForce(collisionDirection * speed, ForceMode.Impulse);
            collision.rigidbody.AddForce(-collisionDirection * speed, ForceMode.Impulse);

            pushedByName = collision.gameObject.name;
        }
    }
}