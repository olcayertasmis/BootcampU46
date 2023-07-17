using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActivate : MonoBehaviour
{
    
    public static int cubeCount = 0;
    public static bool doorOpen = false;
    public static int hedefSayi = 2;
    public GameObject door;
    private Vector3 oldLocation;
    private Vector3 newLocation;

    void Start()
    {
        oldLocation = door.gameObject.transform.position;
        newLocation = new Vector3(oldLocation.x + 6f, oldLocation.y, oldLocation.z + 5.5f);
    }

    void Update()
    {
        if ((cubeCount == hedefSayi) && (doorOpen == false))
        {
            //Debug.Log("kapi acildi");
            doorOpen = true;
            OpenDoor();
        }

        else if ((cubeCount != hedefSayi) && (doorOpen == true))
        {
            //Debug.Log("kapi kapandi");
            doorOpen = false;
            CloseDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cube1")
        {
            //Debug.Log("kup girdi");
            cubeCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cube1")
        {
            //Debug.Log("kup cikti");
            cubeCount--;
        }
    }

    private void OpenDoor()
    {
        door.gameObject.transform.position = newLocation;
    }

    private void CloseDoor()
    {
        door.gameObject.transform.position = oldLocation;
    }
}
