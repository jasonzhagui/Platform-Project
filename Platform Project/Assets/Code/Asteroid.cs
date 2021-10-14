using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float startY;
    float startX;
    float addY;
    float addX;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        addY = Mathf.PingPong(Time.time * 1, 2);
        addX = Mathf.PingPong(Time.time * 1, 2);
        transform.position = new Vector3(transform.position.x, startY + addY, transform.position.z);
        transform.position = new Vector3(startX + addX, transform.position.y, transform.position.z);
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 5),transform.position.y,transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 3), transform.position.z);

    }
}
*/