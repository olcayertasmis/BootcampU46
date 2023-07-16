using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public GameObject cube;
    public int dead = 0;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "cube")
        {
            //if()
            dead++;
            if (dead == 50)
            {
                Destroy(cube);
            }
            
        }
    }
}
