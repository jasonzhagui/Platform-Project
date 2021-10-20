using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int speed = 4;
    public int jumpForce = 1000;
    public float oxygen = 30f;
    public bool charged = false;
    public LayerMask GroundLayer;
    public AudioClip CollectEquipment;
    public AudioClip CollectMetal;
    AudioSource audioSource;
    public Transform feet;
    public bool grounded = false;
    public Text timeLeft;
    public bool death = false;

    public bool complete = false;
    public int goal = 0;
    GameObject Rocket;


    Rigidbody2D rb;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Rocket = GameObject.FindWithTag("Rocket");

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
            timeLeft.text = ((int)oxygen).ToString();
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
            oxygen+=10;
            Destroy(other.gameObject);
            audioSource.clip = CollectEquipment;
            audioSource.Play();

            if (goal!=3)
            {
                goal += 1;
            }
            else if (goal==3)
            {
                Rocket.GetComponent<BoxCollider2D>().isTrigger = true;
                
            }

            
        }
        else if (other.CompareTag("Battery")){
            charged=true;
            Destroy(other.gameObject);
            audioSource.clip = CollectEquipment;
            audioSource.Play();
            goal += 1;

            if (goal != 3)
            {
                goal += 1;
            }
            else if (goal == 3)
            {
                Rocket.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }

        else if (other.CompareTag("Rocket"))
        {
            SceneManager.LoadScene("Level6");
        }
         
    }
}

    
