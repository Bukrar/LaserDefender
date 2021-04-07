using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> wayPoints;
    [SerializeField] float moveSpeed = 2f;
    int wayPointIndex = 0;
    void Start()
    {
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (wayPointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[wayPointIndex].position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
