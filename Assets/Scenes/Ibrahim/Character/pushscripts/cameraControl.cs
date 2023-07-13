using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform target; 
    public float mouseSpeed;
    float xRot, yRot;
    public float minX, maxX,camSpeed=0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        yRot += Input.GetAxis("Mouse X")*Time.deltaTime*mouseSpeed;
        xRot += Input.GetAxis("Mouse Y")*Time.deltaTime*mouseSpeed;
        xRot = Mathf.Clamp(xRot, minX, maxX);
        transform.GetChild(0).localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.localRotation= Quaternion.Euler(0, yRot,0);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position =Vector3.Lerp(transform.position,target.transform.position,camSpeed);

    }
}
