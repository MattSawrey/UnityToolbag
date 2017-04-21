using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 mouseDownPos { get; private set; }
    public Vector2 mousePressedPos { get; private set; }
    public Vector2 mouseReleasedPos { get; private set; }
    public Vector2 mouseDragDistance { get; private set; }

    public Vector2 leftJoystickInputValue { get; private set; }
    public Vector2 rightJoystickInputValue { get; private set; }

    public float leftJoystickInputAngle { get; private set; }
    public float rightJoystickInputAngle { get; private set; }

    public bool isScreenPressed { get; private set; }

    //Key
    public delegate void InputControl();
    public static event InputControl moveUp = delegate { };
    public static event InputControl moveDown = delegate { };
    public static event InputControl moveLeft = delegate { };
    public static event InputControl moveRight = delegate { };

    //Mouse
    public static event InputControl mouseDown = delegate { };
    public static event InputControl mousePressed = delegate { };
    public static event InputControl mouseReleased = delegate { };

    //Gamepad
    public static event InputControl aButtonPressed = delegate { };
    public static event InputControl bButtonPressed = delegate { };
    public static event InputControl xButtonPressed = delegate { };
    public static event InputControl yButtonPressed = delegate { };
    public static event InputControl lbButtonPressed = delegate { };
    public static event InputControl rbButtonPressed = delegate { };
    public static event InputControl backButtonPressed = delegate { };
    public static event InputControl startButtonPressed = delegate { };
    public static event InputControl lsButtonPressed = delegate { };
    public static event InputControl rsButtonPressed = delegate { };

    public static event InputControl dpadDownPressed = delegate { };
    public static event InputControl dpadUpPressed = delegate { };
    public static event InputControl dpadLeftPressed = delegate { };
    public static event InputControl dpadRightPressed = delegate { };

    void FixedUpdate()
    {
        #region - Keyboard Events
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDown();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveRight();
        }

        #endregion

        #region - Mouse Events

        //Mouse down
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Input.mousePosition;
            mouseDragDistance = Vector2.zero;
            mouseDown();
            isScreenPressed = true;
        }

        //Held down
        if (Input.GetMouseButton(0))
        {
            if (!isScreenPressed)
            {
                mouseDownPos = Input.mousePosition;
                mouseDown();
                isScreenPressed = true;
            }
            mousePressedPos = Input.mousePosition;
            mouseDragDistance = mouseDownPos - mousePressedPos;
            mousePressed();
        }
        else
        {
            if (isScreenPressed)
            {
                mouseReleasedPos = Input.mousePosition;
                mouseReleased();
                isScreenPressed = false;
            }
        }

        //Released event
        if (Input.GetMouseButtonUp(0))
        {
            mouseReleasedPos = Input.mousePosition;
            mouseReleased();
            isScreenPressed = false;
        }

        #endregion

        #region - Joystick Events

        leftJoystickInputValue = new Vector2(Input.GetAxis("Joy1_Horiz"), Input.GetAxis("Joy1_Vert"));
        rightJoystickInputValue = new Vector2(Input.GetAxis("Joy2_Horiz"), Input.GetAxis("Joy2_Vert"));

        leftJoystickInputAngle = Vector2.zero.AngleToInDegrees(leftJoystickInputValue);
        rightJoystickInputAngle = Vector2.zero.AngleToInDegrees(rightJoystickInputValue);
            
        #endregion
    }

    void Update()
    {
        if (Input.GetButtonDown("a"))
            aButtonPressed();
        if (Input.GetButtonDown("b"))
            bButtonPressed();
        if (Input.GetButtonDown("x"))
            xButtonPressed();
        if (Input.GetButtonDown("y"))
            yButtonPressed();
        if (Input.GetButtonDown("lb"))
            lbButtonPressed();
        if (Input.GetButtonDown("rb"))
            rbButtonPressed();
        if (Input.GetButtonDown("back"))
            backButtonPressed();
        if (Input.GetButtonDown("start"))
            startButtonPressed();
        if (Input.GetButtonDown("ls"))
            lsButtonPressed();
        if (Input.GetButtonDown("rs"))
            rsButtonPressed();
    }
}
