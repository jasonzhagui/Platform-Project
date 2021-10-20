using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeftRightOpposite : MonoBehaviour
{
    float speed = .5f;
    public float distance = 20;
    float startX;
    private void Start()
    {
        startX = transform.position.x;
    }
    private void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.SmoothStep(startX, startX - distance, Mathf.PingPong(Time.time * speed, 1));
        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}