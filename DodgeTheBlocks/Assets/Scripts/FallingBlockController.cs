﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class FallingBlockController : MonoBehaviour
{
    public float fallingSpeed = 10f;

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

        if (IsOffScreen())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOffScreen()
    {
        return transform.position.y < -screenHalfHeightInWorldUnits * 2;
    }
}
