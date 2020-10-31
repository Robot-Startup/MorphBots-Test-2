using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public float rotationScale;

    private void Update()
    {
        if (Input.GetKey(forward))
        {
            this.transform.eulerAngles += new Vector3(rotationScale, 0, 0) * Time.deltaTime; 
        }
        else if (Input.GetKey(backward))
        {
            this.transform.eulerAngles -= new Vector3(rotationScale, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(right))
        {
            this.transform.eulerAngles += new Vector3(0, rotationScale, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(left))
        {
            this.transform.eulerAngles -= new Vector3(0, rotationScale, 0) * Time.deltaTime;
        }
    }
}
