using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class charController : MonoBehaviour
{
    AudioSource m_AudioSource;
    AudioSource jumpaudio;
    public GameObject cek;
    Animator animator;
    public Transform Cam;
    public Rigidbody rb;
    public float speed=2;
    Vector3 move= Vector3.zero;
    float x, z;
    public float jumpSpeed;
    bool walk=false;
    bool push=false;
    bool pull = false;
    public float health = 100;

    
    public ScInventory playerInventory;//Selinay
    public Inventory inventory;//Selinay
    //public Item item;//Selinay
    void Start()
    {
        animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        
        inventory.OnItemUse += Inventory_OnItemUse;//Selinay

    }
    
    private void Inventory_OnItemUse(object sender, Inventory.OnUseItemEventArgs e)//Selinay
    {
        if (e.sCitem.itemName == "Jump")
        {
            jumpSpeed++;
        }
        if (e.sCitem.itemName == "Speed")
        {
            speed++;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        
        rb.angularVelocity=Vector3.zero;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Cam.transform.rotation, 0.1f);
        }

        move = new Vector3(x, 0, z) * Time.deltaTime * speed;
        rb.MovePosition(transform.position + transform.TransformDirection(move));


        if (Input.GetKey(KeyCode.LeftShift))
        {
            walk = true;
        }


        if (Input.GetKey(KeyCode.W))
        {
            if (walk)
            {
                
                animator.SetInteger("anim", 5);
                speed = 9;
                walk = false;
            }
            else
            {
                speed = 4;
                animator.SetInteger("anim", 1);
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            //speed = 2;
            //animator.SetInteger("anim", 2);

            if (walk)
            {

                animator.SetInteger("anim", 8);
                speed = 9;
                walk = false;
            }
            else
            {
                speed = 4;
                animator.SetInteger("anim", 2);
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            //animator.SetInteger("anim", 3);

            if (walk)
            {

                animator.SetInteger("anim", 9);
                speed = 9;
                walk = false;
            }
            else
            {
                speed = 4;
                animator.SetInteger("anim", 3);
            }
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.Q) == true && pull == true)
            {
                speed = 0.5f;
            }
            else
            {
                if (walk)
                {

                    animator.SetInteger("anim", 10);
                    speed = 9;
                    walk = false;
                }
                else
                {
                    speed = 4;
                    animator.SetInteger("anim", 4);
                }
                
            }
            
            animator.SetInteger("anim", 4);
        }
        else if (Input.GetKey(KeyCode.R) && push == true)
        {
            animator.SetBool("push", true);
            speed = 0.1f;
            cek.GetComponent<cube>().mass = 50;
        }
        else
        {
          
          animator.SetInteger("anim", 0);
          animator.SetBool("pull", false);
          animator.SetBool("push", false);
          //cek.GetComponent<cube>().mass = 500;  hata veriyor akþam bakarýz diye yorum satýrý yaptým
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            rb.velocity=Vector3.up*Time.deltaTime*jumpSpeed;
            animator.SetBool("jump", true);
            animator.SetBool("walkjump", true);
            jumpaudio.Play();
        }
        else
        {
            animator.SetBool("jump", false);
            animator.SetBool("walkjump", false);
            
        }

        if (other.gameObject.tag == "cube")
        {
            health--;

            if(health < 0)
            {
                animator.SetBool("dead", true);
            }
        }

        if (other.gameObject.tag == "cube")
        {
            push = true;
            pull = true;
        }
    }

    void walkAudio()
    {
        m_AudioSource.Play();
    }

    void jumpAudio()
    {
        jumpaudio.Play();
    }



    //private void OnTriggerEnter(Collider other)
    //{
       
        
    //}
    
   
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cube")
        {
            push = false;
            pull = false;
        }
        
    }

    

  
}
