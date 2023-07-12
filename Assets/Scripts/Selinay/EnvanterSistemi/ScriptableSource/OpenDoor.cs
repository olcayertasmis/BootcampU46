using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject rightDoor;
    public GameObject leftDoor;

    private Vector3 initialRightDoorPosition;
    private Vector3 initialLeftDoorPosition;

    private float moveAmount = 1.0f; // Kapýlarýn kaç birim kaydýrýlacaðý

    private void Start()
    {
        // Ýlk pozisyonlarý kaydet
        initialRightDoorPosition = rightDoor.transform.position;
        initialLeftDoorPosition = leftDoor.transform.position;
    }

    public void MoveRight()
    {
        // Sað kapýyý saða kaydýr
        rightDoor.transform.Translate(Vector3.right * moveAmount);
    }

    public void MoveLeft()
    {
        // Sol kapýyý sola kaydýr
        leftDoor.transform.Translate(Vector3.left * moveAmount);
    }

    
}
