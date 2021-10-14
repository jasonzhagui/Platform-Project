using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float startY;
    float startX;
    float addY;
    float addX;
    int random1;
    int random2;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        startX = transform.position.x;
        random1 = Random.Range(1, 4);
        random2 = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        addY = Mathf.PingPong(Time.time * 1, random1);
        addX = Mathf.PingPong(Time.time * 1, random2);
        transform.position = new Vector3(transform.position.x, startY + addY, transform.position.z);
        transform.position = new Vector3(startX + addX, transform.position.y, transform.position.z);
    }
}
