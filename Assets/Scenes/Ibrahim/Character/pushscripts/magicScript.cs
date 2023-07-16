using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicScript : MonoBehaviour
{
    public GameObject trail1,trail2,effect,Cube,Magic,healthB,cubeHealth;
    public GameObject magic1,magic2,magic3,magic4,magic5;
    public Transform magic, hand;
    float magicIndex;
    bool magicEquipp = false; //istafe
    bool canMagic = true;
    //public GameObject backWeapon;
    //public GameObject handWeapon;
    Animator animator;
    public float magicSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        closeMagicTrail();
        stopMagic();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetInteger("anim", 6);
            magicEquipp = !magicEquipp;
            healthB.GetComponent<charController>().health = 100;
        }
       

        if (Input.GetKeyUp("1"))
        {
            //animator.SetTrigger("magic");
            //animator.SetInteger("anim", 7);
            magic1.SetActive(true);
            Invoke("stopMagic", 5);
            cubeHealth.GetComponent<sword>().dead -= 5;
        }
        else if(Input.GetKeyUp("2"))
        {
            magic2.SetActive(true);
            Invoke("stopMagic", 4);
            cubeHealth.GetComponent<sword>().dead -= 5;

        }
        else if(Input.GetKeyUp("3"))
        {
            magic3.SetActive(true);
            Invoke("stopMagic", 5);
            cubeHealth.GetComponent<sword>().dead -= 5;
        }
        else if (Input.GetKeyUp("4"))
        {
            magic4.SetActive(true);
            Invoke("stopMagic", 5);
            cubeHealth.GetComponent<sword>().dead -= 5;
        }
        else if (Input.GetKeyUp("5"))
        {
            magic5.SetActive(true);
            Invoke("stopMagic", 5);
            cubeHealth.GetComponent<sword>().dead -= 5;
        }
       
    }

    void stopMagic()
    {
        magic1.SetActive(false);
        magic2.SetActive(false);
        magic3.SetActive(false);
        magic4.SetActive(false);
        magic5.SetActive(false);
        if (cubeHealth.GetComponent<sword>().dead <= 0)
        {
            Destroy(Cube);
        }
    }

    public void openMagicTrail()
    {
      
            //trail1.gameObject.GetComponent<TrailRenderer>().emitting = true;
            trail1.SetActive(true);
            trail2.SetActive(true);
            effect.SetActive(true);
      
    }
    public void closeMagicTrail()
    {
        
            //trail1.gameObject.GetComponent<TrailRenderer>().emitting = false;
            trail1.SetActive(false);
            trail2.SetActive(false);
            effect.SetActive(false);
       
    }
}

