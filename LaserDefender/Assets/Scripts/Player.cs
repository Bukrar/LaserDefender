using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    float paddle = 1F;
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddle;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddle;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddle;
        yMax = camera.ViewportToWorldPoint(new Vector3(1, 1, 0)).y - paddle;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * 10F;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * 10F;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);
    }
}
