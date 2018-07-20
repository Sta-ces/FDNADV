using UnityEngine;

public class Controls : MonoBehaviour {

    public static float GetHorizontal
    {
        get {
            float result = 0;
            if (Input.GetButtonDown("Horizontal"))
            {
                if(Input.GetAxis("Horizontal") > 0)
                {
                    result = 1;
                }

                if(Input.GetAxis("Horizontal") < 0)
                {
                    result = -1;
                }
            }
            return result;
        }
    }

    public static bool IsLeftInput
    {
        get { return Input.GetAxis("Horizontal") < 0; }
    }

    public static bool IsRightInput
    {
        get { return Input.GetAxis("Horizontal") > 0; }
    }

    public static float LeftInput{
        get{ return (Input.GetAxis("Horizontal") < 0) ? -1 : 0; }
    }

    public static float RightInput {
        get { return (Input.GetAxis("Horizontal") > 0) ? 1 : 0; }
    }
}
