using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float playerSpeed = 6;
    public float speedIncreaseRate = 0.1f;
    public float maxSpeed = 15f;
    public float laneDistance = 3.0f;
    public float laneChangeDuration = 0.25f;

    [SerializeField] bool isRunning;
    [SerializeField] bool isMoving;
    [SerializeField] int lane = 2;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    [SerializeField] float swipeThreshold = 50f;

    void Update()
    {
        if (playerSpeed < maxSpeed)
        {
            playerSpeed += speedIncreaseRate * Time.deltaTime;
        }

        if (isRunning == false)
        {
            isRunning = true;
            StartCoroutine(AddDistance());
        }

        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryMoveLeft();
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryMoveRight();
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    startTouchPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    endTouchPosition = touch.position;
                    HandleSwipe();
                }
            }
        }
    }

    void HandleSwipe()
    {
        if (Vector2.Distance(startTouchPosition, endTouchPosition) >= swipeThreshold)
        {
            float xDiff = endTouchPosition.x - startTouchPosition.x;
            float yDiff = endTouchPosition.y - startTouchPosition.y;

            if (Mathf.Abs(xDiff) > Mathf.Abs(yDiff))
            {
                if (xDiff > 0)
                {
                    TryMoveRight();
                }
                else
                {
                    TryMoveLeft();
                }
            }
        }
    }

    void TryMoveLeft()
    {
        if (lane != 1)
        {
            StartCoroutine(MoveLane(-laneDistance));
            lane -= 1;
        }
    }

    void TryMoveRight()
    {
        if (lane != 3)
        {
            StartCoroutine(MoveLane(laneDistance));
            lane += 1;
        }
    }

    IEnumerator AddDistance()
    {
        yield return new WaitForSeconds(0.35f);
        MasterInfo.distanceRun += 1;
        isRunning = false;
    }

    IEnumerator MoveLane(float distance)
    {
        isMoving = true;
        float startX = transform.position.x;
        float targetX = startX + distance;
        float elapsedTime = 0;

        while (elapsedTime < laneChangeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / laneChangeDuration;
            float currentX = Mathf.Lerp(startX, targetX, t);
            transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
            yield return null;
        }
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        isMoving = false;
    }
}