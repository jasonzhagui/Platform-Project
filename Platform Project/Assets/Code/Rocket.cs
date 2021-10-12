using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    public int speed = 4;
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
    }

}
