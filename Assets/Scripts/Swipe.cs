using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    private readonly float swipeThreshold = 10f;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (Settings.isSwipeEnabled)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerUp = touch.position;
                    fingerDown = touch.position;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;
                    CheckSwipe();
                }
            }
        }
    }

    void CheckSwipe()
    {
        if (HorizontalValMove() > swipeThreshold && HorizontalValMove() > VerticalMove())
        {
            if (fingerDown.x - fingerUp.x > 0) //Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0) //Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }
    }

    float VerticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float HorizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    void OnSwipeLeft()
    {
        Logic.Instance.Skip();
    }

    void OnSwipeRight()
    {
        Logic.Instance.SkipBack();
    }
}