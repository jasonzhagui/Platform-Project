using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    public int speed = 4;
    public int level = PublicVars.level;
    float xSpeed = 0;
    float ySpeed = 0;

    Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PublicVars.level == 7)
        {
            PublicVars.level = 1;
            SceneManager.LoadScene("Level1");
        }   
    }

    void FixedUpdate()
    {
        xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);

        ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, ySpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.CompareTag("Next"))
        {
            PublicVars.level++;
            SceneManager.LoadScene("Level"+ PublicVars.level.ToString());
        }
        if (other.CompareTag("Home"))
        {
            SceneManager.LoadScene("Level1");
        }
        if (other.CompareTag("Back"))
        {
            PublicVars.level--;
            SceneManager.LoadScene("Level" + PublicVars.level.ToString());
        }
    }

}
