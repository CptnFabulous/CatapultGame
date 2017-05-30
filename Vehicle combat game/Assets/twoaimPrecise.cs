using UnityEngine;
using System.Collections;

public class twoaimPrecise : MonoBehaviour
{


    public GameObject Camera;
    public Vector3 startPos;
    public Vector3 endPos;
    Vector3 currentPos;
    public float lerpTime;
    float currentLerpTime;
    bool isReturning;

    protected void Start()
    {
        transform.localPosition = startPos;
        isReturning = true;
    }

    protected void Update()
    {
        //increment timer once per frame
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        //lerp!
        float perc = currentLerpTime / lerpTime;

        if (isReturning == true)
        {
            transform.localPosition = Vector3.Lerp(currentPos, startPos, perc);
        }

        // When the button is pressed, the 'isReturning' bool is disabled to prevent its attached Lerp from keeping the camera pinned in place. The lerp timer is reset to zero, and the camera's current position is saved as currentPos.
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            currentPos = transform.localPosition;
            print("");
            currentLerpTime = 0f;
            isReturning = false;

        }

        // While the button is held, the zoom-in Lerp is initiated. The currentPos position is used as a reference for the object's starting position instead of startPos so the camera does not immediately teleport back to startPos before moving.
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.localPosition = Vector3.Lerp(currentPos, endPos, perc);
        }

        // When the button is released, the current position is re-saved as the starting point for the return journey, and the isReturning bool is re-enabled to start its lerp and pull the camera back in.
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            currentPos = transform.localPosition;
            currentLerpTime = 0f;
            isReturning = true;
        }




    }
}