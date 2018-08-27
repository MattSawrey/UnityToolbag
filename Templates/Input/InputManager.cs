using UnityEngine;

/// <summary>
/// Processes raw unity Input data into input events and variables
/// </summary>
public class InputManager : Singleton<InputManager>
{
    public bool showInputDebug;
    [Range(0.02f, 1f)]
    public float joystickDetectionLimit;

    public delegate void InputManagement();

    #region - Mouse Input Vars

    //Clicks
    public Vector2 mouseDownPos { get; private set; }
    public Vector2 mousePressedPos { get; private set; }
    public Vector2 mouseReleasedPos { get; private set; }
    public Vector2 mouseDragDistance { get; private set; }

    public bool isScreenPressed { get; private set; }

    public static event InputManagement mouseDown = delegate { };
    public static event InputManagement mousePressed = delegate { };
    public static event InputManagement mouseReleased = delegate { };

    #endregion

    #region - Gamepad Input Vars

    //Gamepad - Joystick
    public static event InputManagement leftJoystickActive = delegate { };
    public static event InputManagement leftJoystickStoppedActive = delegate { };
    public static event InputManagement leftJoystickNotActive = delegate { };
    private bool isLeftJoystickActive = false;
    public static event InputManagement leftJoystickUpPressed = delegate { };
    public static event InputManagement leftJoystickDownPressed = delegate { };
    public static event InputManagement leftJoystickLeftPressed = delegate { };
    public static event InputManagement leftJoystickRightPressed = delegate { };

    public static event InputManagement rightJoystickActive = delegate { };
    public static event InputManagement rightJoystickStoppedActive = delegate { };
    public static event InputManagement rightJoystickNotActive = delegate { };
    private bool isRightJoystickActive = false;

    private Vector2 previousLeftJoystickInputValue;
    public Vector2 leftJoystickInputValue { get; private set; }
    public Vector2 rightJoystickInputValue { get; private set; }
    public float leftJoystickInputAngle { get; private set; }
    public float rightJoystickInputAngle { get; private set; }

    //Gamepad - Dpad
    private Vector2 previousDpadInput;
    public Vector2 dPadInput { get; private set; }
    public static event InputManagement dpadActive = delegate { };
    public static event InputManagement dpadStoppedActive = delegate { };
    public static event InputManagement dpadNotActive = delegate { };
    private bool isDpadActive = false;

    public static event InputManagement dpadDownPressed = delegate { };
    public static event InputManagement dpadUpPressed = delegate { };
    public static event InputManagement dpadLeftPressed = delegate { };
    public static event InputManagement dpadRightPressed = delegate { };

    //Gamepad - Triggers
    public static event InputManagement leftTriggerActive = delegate { };
    public static event InputManagement rightTriggerActive = delegate { };

    public float leftTriggerInputValue { get; private set; }
    public float rightTriggerInputValue { get; private set; }

    //Gamepad - Buttons
    public static event InputManagement aButtonPressed = delegate { };
    public static event InputManagement bButtonPressed = delegate { };
    public static event InputManagement xButtonPressed = delegate { };
    public static event InputManagement yButtonPressed = delegate { };
    public static event InputManagement lbButtonPressed = delegate { };
    public static event InputManagement rbButtonPressed = delegate { };
    public static event InputManagement backButtonPressed = delegate { };
    public static event InputManagement startButtonPressed = delegate { };
    public static event InputManagement lsButtonPressed = delegate { };
    public static event InputManagement rsButtonPressed = delegate { };

    public static event InputManagement aButtonUp = delegate { };
    public static event InputManagement bButtonUp = delegate { };
    public static event InputManagement xButtonUp = delegate { };
    public static event InputManagement yButtonUp = delegate { };
    public static event InputManagement lbButtonUp = delegate { };
    public static event InputManagement rbButtonUp = delegate { };
    public static event InputManagement backButtonUp = delegate { };
    public static event InputManagement startButtonUp = delegate { };
    public static event InputManagement lsButtonUp = delegate { };
    public static event InputManagement rsButtonUp = delegate { };

    #endregion

    #region - Keyboard Input Vars

    public Vector2 keyboardArrowInput;
    private Vector2 previousKeyboardArrowInput;

    public static event InputManagement arrowKeysActive = delegate { };
    public static event InputManagement arrowKeysStoppedActive = delegate { };

    public static event InputManagement wKeyPressed = delegate { };
    public static event InputManagement aKeyPressed = delegate { };
    public static event InputManagement sKeyPressed = delegate { };
    public static event InputManagement dKeyPressed = delegate { };
    public static event InputManagement eKeyPressed = delegate { };
    public static event InputManagement upKeyPressed = delegate { };
    public static event InputManagement leftKeyPressed = delegate { };
    public static event InputManagement rightKeyPressed = delegate { };
    public static event InputManagement downKeyPressed = delegate { };
    public static event InputManagement spaceKeyPressed = delegate { };
    public static event InputManagement enterKeyPressed = delegate { };
    public static event InputManagement lShiftKeyPressed = delegate { };
    public static event InputManagement rShiftKeyPressed = delegate { };
    public static event InputManagement escKeyPressed = delegate { };
    public static event InputManagement delKeyPressed = delegate { };

    public static event InputManagement wKeyHeld = delegate { };
    public static event InputManagement aKeyHeld = delegate { };
    public static event InputManagement sKeyHeld = delegate { };
    public static event InputManagement dKeyHeld = delegate { };
    public static event InputManagement upKeyHeld = delegate { };
    public static event InputManagement leftKeyHeld = delegate { };
    public static event InputManagement rightKeyHeld = delegate { };
    public static event InputManagement downKeyHeld = delegate { };
    public static event InputManagement spaceKeyHeld = delegate { };
    public static event InputManagement enterKeyHeld = delegate { };
    public static event InputManagement lShiftKeyHeld = delegate { };
    public static event InputManagement rShiftKeyHeld = delegate { };
    public static event InputManagement escKeyHeld = delegate { };
    public static event InputManagement delKeyHeld = delegate { };

    public static event InputManagement wKeyUp = delegate { };
    public static event InputManagement aKeyUp = delegate { };
    public static event InputManagement sKeyUp = delegate { };
    public static event InputManagement dKeyUp = delegate { };
    public static event InputManagement upKeyUp = delegate { };
    public static event InputManagement leftKeyUp = delegate { };
    public static event InputManagement rightKeyUp = delegate { };
    public static event InputManagement downKeyUp = delegate { };
    public static event InputManagement spaceKeyUp = delegate { };
    public static event InputManagement enterKeyUp = delegate { };
    public static event InputManagement lShiftKeyUp = delegate { };
    public static event InputManagement rShiftKeyUp = delegate { };
    public static event InputManagement escKeyUp = delegate { };
    public static event InputManagement delKeyUp = delegate { };

    #endregion

    #region - Debug Function

    private void DebugInputs()
    {
        //Gamepad Input
        aButtonPressed += () => Debug.Log("A Button Pressed");
        bButtonPressed += () => Debug.Log("B Button Pressed");
        xButtonPressed += () => Debug.Log("X Button Pressed");
        yButtonPressed += () => Debug.Log("Y Button Pressed");
        rbButtonPressed += () => Debug.Log("R Button Pressed");
        lbButtonPressed += () => Debug.Log("L Button Pressed");
        lsButtonPressed += () => Debug.Log("L Stick Pressed");
        rsButtonPressed += () => Debug.Log("R Stick Pressed");
        startButtonPressed += () => Debug.Log("Start Button Pressed");
        backButtonPressed += () => Debug.Log("Back Button Pressed");
        leftJoystickActive += () => Debug.Log("Left Joystick: Input- " + leftJoystickInputValue + ", Angle- " + leftJoystickInputAngle);
        rightJoystickActive += () => Debug.Log("Right Joystick: Input- " + rightJoystickInputValue + ", Angle- " + rightJoystickInputAngle);
        leftTriggerActive += () => Debug.Log("Left Trigger Input: " + leftTriggerInputValue);
        rightTriggerActive += () => Debug.Log("Right Trigger Input: " + rightTriggerInputValue);
        dpadActive += () => Debug.Log("Dpad Input: " + dPadInput);
        leftJoystickUpPressed += () => Debug.Log("Up Joystick Left");
        leftJoystickDownPressed += () => Debug.Log("Down Joystick Left");
        leftJoystickLeftPressed += () => Debug.Log("Left Joystick Left");
        leftJoystickRightPressed += () => Debug.Log("Right Joystick Left");
    }

    #endregion

    private void ProcessGamepadInput()
    {
        #region - Gamepad Joystick, Dpad and Triggers

        //Dpad Buttons
        dPadInput = new Vector2(Input.GetAxis("dpad_X"), Input.GetAxis("dpad_Y"));

        if (previousDpadInput == Vector2.zero)
        {
            if (dPadInput.y > 0f)
                dpadUpPressed();
            if (dPadInput.y < 0f)
                dpadDownPressed();
            if (dPadInput.x < 0f)
                dpadLeftPressed();
            if (dPadInput.x > 0f)
                dpadRightPressed();
        }

        if (dPadInput != Vector2.zero)
        {
            dpadActive();
            if (!isDpadActive)
                isDpadActive = true;
        }
        else
        {
            if (isDpadActive)
            {
                dpadStoppedActive();
                isDpadActive = false;
            }
            else
                dpadNotActive();
        }

        previousDpadInput = dPadInput;

        //Joysticks
        leftJoystickInputValue = new Vector2(Input.GetAxis("Joy_Left_X"), Input.GetAxis("Joy_Left_Y"));
        rightJoystickInputValue = new Vector2(Input.GetAxis("Joy_Right_X"), Input.GetAxis("Joy_Right_X"));

        leftJoystickInputAngle = Vector2.zero.AngleToInDegrees(leftJoystickInputValue);
        rightJoystickInputAngle = Vector2.zero.AngleToInDegrees(rightJoystickInputValue);

        //Left Joystick Events
        if (leftJoystickInputValue.magnitude > joystickDetectionLimit)
        {
            leftJoystickActive();
            if (!isLeftJoystickActive)
                isLeftJoystickActive = true;

            if (previousLeftJoystickInputValue == Vector2.zero)
            {
                if (leftJoystickInputValue.y > joystickDetectionLimit)
                    leftJoystickUpPressed();
                if (leftJoystickInputValue.y < -joystickDetectionLimit)
                    leftJoystickDownPressed();
                if (leftJoystickInputValue.x < -joystickDetectionLimit)
                    leftJoystickLeftPressed();
                if (leftJoystickInputValue.x > joystickDetectionLimit)
                    leftJoystickRightPressed();
            }
            previousLeftJoystickInputValue = leftJoystickInputValue;
        }
        else
        {
            if (isLeftJoystickActive)
            {
                leftJoystickStoppedActive();
                isLeftJoystickActive = false;
            }
            else
                leftJoystickNotActive();

            previousLeftJoystickInputValue = Vector2.zero;
        }

        //Right Joystick Events
        if (rightJoystickInputValue.magnitude > joystickDetectionLimit)
        {
            rightJoystickActive();
            if (!isRightJoystickActive)
                isRightJoystickActive = true;
        }
        else
        {
            if (isRightJoystickActive)
            {
                rightJoystickStoppedActive();
                isRightJoystickActive = false;
            }
            else
                rightJoystickNotActive();
        }

        //Triggers
        leftTriggerInputValue = Input.GetAxis("lt");
        rightTriggerInputValue = Input.GetAxis("rt");

        if (leftTriggerInputValue != 0)
            leftTriggerActive();
        if (rightTriggerInputValue != 0)
            rightTriggerActive();

        #endregion
    }

    void Awake()
    {
        if (showInputDebug)
            DebugInputs();
    }

    void FixedUpdate()
    {
        #region - Keyboard Events

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upKeyPressed();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            downKeyPressed();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftKeyPressed();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightKeyPressed();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            wKeyPressed();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            aKeyPressed();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sKeyPressed();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dKeyPressed();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            eKeyPressed();
        }

        keyboardArrowInput = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            keyboardArrowInput += new Vector2(0f, 1f);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            keyboardArrowInput += new Vector2(-1f, 0f);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            keyboardArrowInput += new Vector2(0f, -1f);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            keyboardArrowInput += new Vector2(1f, 0f);

        if (keyboardArrowInput != Vector2.zero)
            arrowKeysActive();
        else
        {
            if (previousKeyboardArrowInput != Vector2.zero)
            {
                arrowKeysStoppedActive();
            }
        }

        previousKeyboardArrowInput = keyboardArrowInput;

        if (Input.GetKeyDown(KeyCode.W))
            wKeyPressed();
        if (Input.GetKeyDown(KeyCode.A))
            aKeyPressed();
        if (Input.GetKeyDown(KeyCode.S))
            sKeyPressed();
        if (Input.GetKeyDown(KeyCode.D))
            dKeyPressed();
        if (Input.GetKeyDown(KeyCode.Space))
            spaceKeyPressed();
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            enterKeyPressed();

        if (Input.GetKey(KeyCode.UpArrow))
            upKeyHeld();
        if (Input.GetKey(KeyCode.DownArrow))
            downKeyHeld();
        if (Input.GetKey(KeyCode.LeftArrow))
            leftKeyHeld();
        if (Input.GetKey(KeyCode.RightArrow))
            rightKeyHeld();
        if (Input.GetKey(KeyCode.W))
            wKeyHeld();
        if (Input.GetKey(KeyCode.A))
            aKeyHeld();
        if (Input.GetKey(KeyCode.S))
            sKeyHeld();
        if (Input.GetKey(KeyCode.D))
            dKeyHeld();
        if (Input.GetKey(KeyCode.Space))
            spaceKeyHeld();
        if (Input.GetKey(KeyCode.KeypadEnter))
            enterKeyHeld();

        #endregion

        #region - Mouse Events

        //Right button down
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Input.mousePosition;
            mouseDragDistance = Vector2.zero;
            mouseDown();
            isScreenPressed = true;
        }

        //Right button held
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

        //Right button released
        if (Input.GetMouseButtonUp(0))
        {
            mouseReleasedPos = Input.mousePosition;
            mouseReleased();
            isScreenPressed = false;
        }

        #endregion

        ProcessGamepadInput();
    }

    void Update()
    {
        //Done to subvert game pausing
        if (GameStateManager.Instance.currentState == GameStates.InGame)
            if (GameStateManager.Instance.currentInGameState == InGameStates.InInventory)
                ProcessGamepadInput();

        #region - Gamepad Buttons

        if (Input.GetButtonDown("a"))
            aButtonPressed();
        if (Input.GetButtonDown("b"))
            bButtonPressed();
        if (Input.GetButtonDown("x"))
            xButtonPressed();
        if (Input.GetButtonUp("x"))
            xButtonUp();
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
        if (Input.GetButtonDown("back"))
            backButtonPressed();

        #endregion
    }
}
