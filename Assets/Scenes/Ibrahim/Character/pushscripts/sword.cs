using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public GameObject cube;
    public int dead = 50;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead <= 0)
        {
            Destroy(cube);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "cube")
        {
            dead--;
            if (dead <= 0)
            {
                Destroy(cube);
            }
            
        }
    }
}
