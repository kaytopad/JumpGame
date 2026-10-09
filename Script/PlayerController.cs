using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Collision collision;
    float jumpForce = 380.0f;
    float maxWalkSpeed = 2.0f;
    public Sprite[] walkSprites;
    float time = 0;
    int index = 0;

    bool isGrounded = true;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.collision = GetComponent<Collision>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && collision.IsGrounded) 
        {
            Vector2 forece = transform.up * jumpForce;
            rigid2D.AddForce(forece);
        
        }


        this.time += Time.deltaTime;
        if (isGrounded)
        { 
            if (this.time > 0.1f) 
            { 
                this.time = 0;
                this.spriteRenderer.sprite = this.walkSprites[this.index];
                this.index = 1 - this.index;
            }
        
        }
        
    }

}
