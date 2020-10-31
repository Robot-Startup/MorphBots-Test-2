using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapCubeToGrid : MonoBehaviour
{
    // Initialize variables to be assigned in the editor
    public GameObject refMorphBot;
    public LayerMask platformMask;
    public float maxDistance;
    public Vector3 startingPosition;

    // Initialize variables to be assigned in-game
    GameObject morphBot;
    Ray gridRay;
    RaycastHit gridRayHit;
    bool didRayHit;
    Vector3 mousePosition;
    Vector3 truePosition;

    private void Start()
    {
        // Spawns GameObject refMorphBot at startingPosition with a rotatation of (0, 0, 0)
        morphBot = Instantiate(refMorphBot, startingPosition, Quaternion.identity);
    }

    private void Update()
    {
        // Creates a line gridRay from the player's camera to mouse pointer
        gridRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Checks to see if the line hit any in-game object with the platformMask layer
        didRayHit = Physics.Raycast(gridRay, out gridRayHit, maxDistance, platformMask);

        // Runs a series of commands if didRayHit is true
        if (didRayHit)
        {
            // Assigns the point of collision to mousePosition
            mousePosition = gridRayHit.point;

            // Runs a series of floor functions to snap morphBot to grid in the x, y, and z
            if (mousePosition.x > 0)
            {
                truePosition.x = Mathf.Floor(mousePosition.x) + 0.5f;
            }
            else if (mousePosition.x < 0)
            {
                truePosition.x = (Mathf.Floor(mousePosition.x * -1) + 0.5f) * -1;
            }
            if (mousePosition.y > 0)
            {
                truePosition.y = Mathf.Floor(mousePosition.y + 0.5f);
            }
            else if (mousePosition.y < 0)
            {
                truePosition.y = Mathf.Floor(mousePosition.y * -1 + 0.5f) * -1;
            }
            if (mousePosition.z > 0)
            {
                truePosition.z = Mathf.Floor(mousePosition.z) + 0.5f;
            }
            else if (mousePosition.z < 0)
            {
                truePosition.z = (Mathf.Floor(mousePosition.z * -1) + 0.5f) * -1;
            }

            // Sets the position of morphBot to truePosition, which was derived from floor functions
            morphBot.transform.position = truePosition;
            Debug.Log(mousePosition);

            // Assigns morphBot to a new instance of refMorphBot and gives it the platformMask layer if left click is pressed
            if (Input.GetMouseButtonDown(0))
            {
                morphBot.layer = 8;
                morphBot = Instantiate(refMorphBot, morphBot.transform.position, Quaternion.identity);

            }
        }
    }
}
