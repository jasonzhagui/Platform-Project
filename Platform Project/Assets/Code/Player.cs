using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int speed = 4;
    public int jumpForce = 700;
    public float oxygen = 60f;
    public bool charged = false;
    public LayerMask GroundLayer;
    public Transform feet;
    public bool grounded = false;
    public Text timeLeft;
    public bool death = false;
    

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {

        if (charged==true){
            speed=7;
        }
        float xSpeed = Input.GetAxis("Horizontal")* speed;
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);

    }

    void Update()
    {
        
        grounded = Physics2D.OverlapCircle(feet.position, .3f, GroundLayer);
        if (Input.GetButtonDown("Jump") && grounded){
            rb.AddForce(new Vector2(0,jumpForce));
        }

        
        if (oxygen>-30){
            oxygen-=Time.deltaTime;
            timeLeft.text=oxygen.ToString();
        }
        
        
        if (oxygen<0){
            speed=2;
        }

        if (oxygen<-30){
            death = true;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GasTank")){
            oxygen+=30;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Battery")){
            charged=true;
            Destroy(other.gameObject);
        }
         
    }
}

    
