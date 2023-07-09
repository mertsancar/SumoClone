using UnityEngine;

public class NPC : MonoBehaviour
{
    public float moveSpeed = 3f;

    private GameObject closestNPC;
    private GameObject farthestNPC;
    private GameObject randomNPC;

    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        FindFarthestNPC();

        if (transform.position.y < -5)
        {
            Dead();
        }
    }

    private void Dead()
    {
        var username = gameObject.name;
        Leaderboard.AddLeaderboard(username);
        Destroy(gameObject);
    }

    private void FindRandomNPC()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("Player");
        randomNPC = npcs[Random.Range(0, npcs.Length - 1)];
        
        if (randomNPC != null)
        {
            // Calculate direction towards the closest NPC
            Vector3 direction = randomNPC.transform.position - transform.position;
            direction.Normalize();

            // Move towards the closest NPC
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
    
    private void FindFarthestNPC()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("Player");
        float farthestDistance = 0f;

        foreach (GameObject npc in npcs)
        {
            if (npc != gameObject)
            {
                float distance = Vector3.Distance(transform.position, npc.transform.position);
                if (distance > farthestDistance)
                {
                    farthestDistance = distance;
                    farthestNPC = npc;
                }
            }
        }
        
        if (farthestNPC != null)
        {
            // Calculate direction towards the closest NPC
            Vector3 direction = farthestNPC.transform.position - transform.position;
            direction.Normalize();

            // Move towards the closest NPC
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
    
    private void FindClosestNPC()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("Player");
        float farthestDistance = 0f;

        foreach (GameObject npc in npcs)
        {
            if (npc != gameObject)
            {
                float distance = Vector3.Distance(transform.position, npc.transform.position);
                if (distance > farthestDistance)
                {
                    farthestDistance = distance;
                    farthestNPC = npc;
                }
            }
        }
        
        if (closestNPC != null)
        {
            // Calculate direction towards the closest NPC
            Vector3 direction = closestNPC.transform.position - transform.position;
            direction.Normalize();

            // Move towards the closest NPC
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
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
            rb.AddForce(collisionDirection * (moveSpeed + Random.Range(0, 3)), ForceMode.Impulse);
            collision.rigidbody.AddForce(-collisionDirection * (moveSpeed + Random.Range(0, 3)), ForceMode.Impulse);
        }
    }
}