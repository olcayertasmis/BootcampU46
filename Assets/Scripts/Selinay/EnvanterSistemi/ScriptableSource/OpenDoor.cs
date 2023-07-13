using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject rightDoor;
    public GameObject leftDoor;

    private Vector3 initialRightDoorPosition;
    private Vector3 initialLeftDoorPosition;

    private float moveAmount = 1.0f; // Kap�lar�n ka� birim kayd�r�laca��

    private void Start()
    {
        // �lk pozisyonlar� kaydet
        initialRightDoorPosition = rightDoor.transform.position;
        initialLeftDoorPosition = leftDoor.transform.position;
    }

    public void MoveRight()
    {
        // Sa� kap�y� sa�a kayd�r
        rightDoor.transform.Translate(Vector3.right * moveAmount);
    }

    public void MoveLeft()
    {
        // Sol kap�y� sola kayd�r
        leftDoor.transform.Translate(Vector3.left * moveAmount);
    }

    
}
