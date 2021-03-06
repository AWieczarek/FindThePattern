using UnityEngine;
using System.Collections;

public class SwipeManager : MonoBehaviour
{

    #region Instance
    private static SwipeManager instance;
    public static SwipeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SwipeManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned SwipeInput", typeof(SwipeManager)).GetComponent<SwipeManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion
    public PlatformManager platformManager;
    public Transform player;
    public Animator animator;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;

    private bool tap, doubleTap, swipeLeft, swipeRight, swipeUp, swipeDown;

    public Score score;

    public bool Tap { get { return tap; } }
    public bool DubleTap { get { return doubleTap; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

	void Update()
    {
        tap = doubleTap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        UpdateMobile();
        if (swipeUp)
		{
            transform.position += new Vector3(0,0,1.5f);
            score._score++;
        }
        else if (swipeLeft)
        {
            transform.position += new Vector3(-1.5f, 0, 0);
        }else if (swipeRight)
        {
            transform.position += new Vector3(1.5f, 0, 0);
        }
        
    }

    private void UpdateMobile()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;

            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }

    void checkSwipe()
    {
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            if (fingerDown.y - fingerUp.y > 0)
            {
                swipeUp = true;
            }
            else if (fingerDown.y - fingerUp.y < 0)
            {
                swipeDown = true;
            }
            fingerUp = fingerDown;
        }

        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            if (fingerDown.x - fingerUp.x > 0)
            {
                swipeRight = true;
            }
            else if (fingerDown.x - fingerUp.x < 0)
            {
                swipeLeft = true;
            }
            fingerUp = fingerDown;
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }
}
