using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator myDoorLeft = null;
    [SerializeField] private Animator myDoorRight = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    [SerializeField] private string doorOpen = "DoorOpen";
    [SerializeField] private string doorClose = "DoorClose";
    [SerializeField] private string doorOpenRight = "DoorOpenRight";
    [SerializeField] private string doorCloseRight = "DoorCloseRight";
    private bool isDoorOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                myDoorLeft.Play(doorOpen, 0, 0.0f);
                myDoorRight.Play(doorOpenRight, 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if (closeTrigger)
            {   
                myDoorRight.Play(doorCloseRight, 0, 0.0f);
                myDoorLeft.Play(doorClose, 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
   
}
