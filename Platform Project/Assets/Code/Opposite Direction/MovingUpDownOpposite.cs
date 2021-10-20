using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpDownOpposite : MonoBehaviour
{
    float speed = .5f;
    public float distance = 20;
    float startY;
    private void Start()
    {
        startY = transform.position.y;
    }
    private void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.y = Mathf.SmoothStep(startY, startY - distance, Mathf.PingPong(Time.time * speed, 1));
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
