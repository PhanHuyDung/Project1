using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobieInput : MonoSingleton<MobieInput>
{
    private const float DEADZONE = 100.0f;
    private bool tap, left, right, up, down;
    private Vector2 delta, startTouch;

    public bool Tap
    {
        get
        {
            return tap;
        }
        set
        {
            tap = value;
        }
    }

    public Vector2 Delta
    {
        get
        {
            return delta;
        }

        set
        {
            delta = value;
        }
    }

    public bool Left
    {
        get
        {
            return left;
        }

        set
        {
            left = value;
        }
    }

    public bool Right
    {
        get
        {
            return right;
        }

        set
        {
            right = value;
        }
    }

    public bool Up
    {
        get
        {
            return up;
        }

        set
        {
            up = value;
        }
    }

    public bool Down
    {
        get
        {
            return down;
        }

        set
        {
            down = value;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region Stand input
        if (Input.GetMouseButtonDown(0))
        {
            Tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = Delta = Vector2.zero;
        }
        #endregion

        #region Mobie Input
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Tap = true;
                    startTouch = Input.mousePosition;
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    startTouch = Delta = Vector2.zero;
                }
            }
        }
        #endregion

        // Calculator Distance

        Delta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            // Check wwith mobile
            if (Input.touches.Length != 0)
            {
                delta = Input.touches[0].position - startTouch;
            }
            // check stand input
            else if (Input.GetMouseButton(0))
            {
                delta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        // 

        if (delta.magnitude > DEADZONE)
        {
            float x = delta.x;
            float y = delta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or right
                if (x < 0) Left = true;
                else Right = true;
            }
            else
            {
                // up or down
                if (y < 0) Down = true;
                else Up = true;
            }

            startTouch = Delta = Vector2.zero;
        }
    }
}
