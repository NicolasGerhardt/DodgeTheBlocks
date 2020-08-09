 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;

    float screenHalfWidthInWorldUnits = 1f;

    // Start is called before the first frame update
    void Start()
    {
        float playerHalfWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + playerHalfWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);


        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Falling Block")
        {
            Destroy(gameObject);
        }
    }
}
