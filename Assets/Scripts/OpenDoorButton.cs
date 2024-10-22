using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour
{
    [SerializeField] private Animator myDoorLeft = null;
    [SerializeField] private Animator myDoorRight = null;
    [SerializeField] private string doorOpen = "DoorOpen";
    [SerializeField] private string doorClose = "DoorClose";
    [SerializeField] private string doorOpenRight = "DoorOpenRight";
    [SerializeField] private string doorCloseRight = "DoorCloseRight";
    private bool isDoorOpen = false;
    // Start is called before the first frame update
    private void Update()
    {
        // Check for key press C to open the door
        if (Input.GetKeyDown(KeyCode.C) && !isDoorOpen)
        {
            OpenDoor1();
        }
        // Check for key press V to close the door
        else if (Input.GetKeyDown(KeyCode.V) && isDoorOpen)
        {
            CloseDoor();
        }
    }

    private void OpenDoor1()
    {
        myDoorLeft.Play(doorOpen, 0, 0.0f);
        myDoorRight.Play(doorOpenRight, 0, 0.0f);
        isDoorOpen = true; // Set the door status to open
    }

    private void CloseDoor()
    {
        myDoorLeft.Play(doorClose, 0, 0.0f);
        myDoorRight.Play(doorCloseRight, 0, 0.0f);
        isDoorOpen = false; // Set the door status to closed
    }
}
