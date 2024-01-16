using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float pushForce = 800f;
    public float movement;
    [SerializeField]
    private float speed = 8f;
    public Vector3 respawnPoint;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = this.transform.position;
        gameManager = FindObjectOfType<GameManager>();
       
    }

    private void Update() 
    {
         movement = Input.GetAxis("Horizontal");

    }

    
    void FixedUpdate()
    {
        rb.AddForce(0, 0, pushForce * Time.fixedDeltaTime);
        rb.velocity = new Vector3(movement * speed, rb.velocity.y, rb.velocity.z);
        FallDetector(); 
    }

    public void OnCollisionEnter(Collision other) 
    {
        if(other.collider.CompareTag("Barrier"))
        {
            gameManager.RespawnPlayer();
        }
        
    }
    private void FallDetector()
    {
        if(rb.position.y < -2f)
        {
            gameManager.RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("EndTrigger"))
        gameManager.LevelUp();
    }
}
