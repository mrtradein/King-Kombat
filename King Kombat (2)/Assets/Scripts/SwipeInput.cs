using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{

    public GameObject gameController;
    public GameController GameControllerScript;

    private bool tap;
    private bool swipeLeft;
    private bool swipeRight;
    private bool swipeUp;
    private bool swipeDown;
    private bool isDraging;

    private Vector2 startTouch;
    private Vector2 swipeDelta;

    // gets
    public Vector2 SwipeDelta {get{return swipeDelta;}}
    public bool Tap { get { return tap; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

    void Start()
    {
        gameController = GameObject.Find("Game Controller");
        GameControllerScript = gameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
        PlayerInput();
    }
    
    void CheckForInput()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        //-------------------------------------------
        // mouse inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }

        //--------------------------------------
        // mobile inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }

        //-------------------------------------
        // calculate distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;

            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        // did we cross dead zone? 125 = pixels
        if (swipeDelta.magnitude > 125)
        {
            // which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // left or right
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                // up or down
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }

            }

            Reset();
        }
    }

    private void PlayerInput()
    {
        if (tap)
        {
            Debug.Log("tap");
            GameControllerScript.Faint();

        }

        if (swipeLeft)
        {
            Debug.Log("left");
            GameControllerScript.Player_1_SwipeLeftRight();

        }

        if (swipeRight)
        {
            Debug.Log("right");
            GameControllerScript.Player_1_SwipeLeftRight();
        }

        if (swipeUp)
        {
            Debug.Log("up");
            GameControllerScript.Player_1_SwipeUp();

        }

        if (swipeDown)
        {
            Debug.Log("down");
            GameControllerScript.Player_1_SwipeDown();
        }


    }
    void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
