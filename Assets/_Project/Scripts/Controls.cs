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

    public static bool LeftInput{
        get{ return Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < 0; }
    }

    public static bool RightInput {
        get { return Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0; }
    }
}
