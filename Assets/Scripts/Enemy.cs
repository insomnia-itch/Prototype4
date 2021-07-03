using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // The enemy has the power to bounce the player away, but only if the player approaches it.We must tell the enemy to follow the player’s position, chasing them around the island.
        Vector3 directionToPlayer= player.transform.position - transform.position;
        rb.AddForce(directionToPlayer.normalized * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
