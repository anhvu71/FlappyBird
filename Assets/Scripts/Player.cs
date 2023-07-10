using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float strength = 5f;

    public float gravity = -9.8f;
    private Rigidbody2D rb;
    private GameManager gameManager;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();  
    }

    private void Update() {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {
            rb.velocity = Vector3.up*strength;
        }
    }

    private void OnEnable() {
        Vector3 pos = transform.position;
        pos.y = 1f;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
            gameManager.GameOver();
        } else if (collision.gameObject.CompareTag("Scoring")) {
            gameManager.IncreaseScore();
        }
    }
}
