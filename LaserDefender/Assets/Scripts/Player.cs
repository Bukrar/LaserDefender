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
    Coroutine fireCoroutine;

    [SerializeField] float moveSpeed = 10F;
    [SerializeField] float paddle = .5F;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projecttileSpeed = 10F;
    void Start()
    {
        SetUpMoveBoundaries();
    }
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject laser = Instantiate(
                laserPrefab,
                transform.position,
                Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projecttileSpeed);
            yield return new WaitForSeconds(0.05F);
        }
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);
    }
    private void SetUpMoveBoundaries()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddle;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddle;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddle;
        yMax = camera.ViewportToWorldPoint(new Vector3(1, 1, 0)).y - paddle;
    }
}
