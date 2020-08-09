using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlockController : MonoBehaviour
{
    public float fallingSpeed = 10;

    float screenHalfHeightInWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        float blockHeight = transform.localScale.y;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize + blockHeight;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime);

        if (transform.position.y < -screenHalfHeightInWorldUnits * 2)
        {
            Destroy(gameObject);
        }
    }
}
