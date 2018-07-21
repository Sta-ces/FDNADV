using UnityEngine;

public class Controls : MonoBehaviour {

    public static float GetAxis(string _axis)
    {
        float result = 0;
        if (Input.GetButtonDown(_axis))
        {
            if (Input.GetAxis(_axis) > 0)
            {
                result = 1;
            }

            if (Input.GetAxis(_axis) < 0)
            {
                result = -1;
            }
        }
        return result;
    }

    public static bool IsPositveInput(string _axis)
    {
        // IF positive = true
        return Input.GetAxis(_axis) > 0;
    }

    public static float LeftInput{
        get{ return (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < 0) ? -1 : 0; }
    }

    public static float RightInput {
        get { return (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0) ? 1 : 0; }
    }

    public static float DownInput
    {
        get { return (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") < 0) ? -1 : 0; }
    }

    public static float UpInput
    {
        get { return (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0) ? 1 : 0; }
    }
}
