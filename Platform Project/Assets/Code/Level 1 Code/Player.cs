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
    public bool carry=false;
    public int rocketMetal=0;
    public bool Need=false;
    public Sprite CarryMode;
    public Sprite Oldsprite;
    public SpriteRenderer spriteRenderer;
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

        if ((xSpeed <0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0)){
            transform.localScale *= new Vector2(-1,1);
        }

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

        if (oxygen<-10){
            death = true;
        }

        if (carry==true){
            spriteRenderer.sprite = CarryMode;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Metal") && carry==false){
            carry=true;
            Destroy(other.gameObject);

        }
        if (other.CompareTag("GasTank")){
            oxygen+=10;
            Destroy(other.gameObject);
            //audioSource.clip = CollectEquipment;
            //audioSource.Play();


            
        }
        else if (other.CompareTag("Battery")){
            charged=true;
            Destroy(other.gameObject);
            //audioSource.clip = CollectEquipment;
            //audioSource.Play();
           
        }

        else if (other.CompareTag("Rocket"))
        {
            if (carry==true){
                carry=false;
                spriteRenderer.sprite = Oldsprite;
                rocketMetal++;
                Need=true;
            }
            if (Need==false){
                SceneManager.LoadScene("Level6");
            }
            else {
                if (rocketMetal==2){
                    SceneManager.LoadScene("Level6");
                }
            }
        }
         
    }
}

    
