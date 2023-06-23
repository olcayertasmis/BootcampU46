using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [Range(0,1)] public float time;
    public float startTime;
    public float dayLenght;
    private float timeRate;
    public Vector3 noon;

    private void Start()
    {
        timeRate = 1 / dayLenght;
        time = startTime;
    }
    private void Update()
    {
        time += timeRate * Time.deltaTime;
        if (time >= 1)
            time = 0;
        transform.eulerAngles =noon*((time - 0.25f) * 4);
        
    }
}
