using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static float moveSpeed = 20f;

    private Rigidbody2D rb;

    Vector2 Movement;

    public GameObject player;

    Building building;

    private float SoundTimer = 0.5f;

    public SoundManager soundManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = 20f;
    }

    private void Update()
    {
        SoundTimer -= Time.deltaTime;

        Movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Movement.Normalize();

        if (rb.velocity.magnitude >= 0.01)
        {
            if (SoundTimer <= 0)
            {
                soundManager.WalkSound();
                SoundTimer = 0.5f;
            }
        }

        if (player.transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(Movement);
    }

    private void MoveCharacter(Vector2 direction)
    {
        rb.AddForce(direction * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            building = other.GetComponentInParent<Building>();
            if (building.GeneratedLevel == false)
            {
                building.Trigger();
                building.GeneratedLevel = true;
            }
        }
    }
}