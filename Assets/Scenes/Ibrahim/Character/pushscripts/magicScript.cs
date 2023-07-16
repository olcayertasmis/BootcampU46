using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicScript : MonoBehaviour
{
    public GameObject trail1,trail2,effect,Cube,Magic;
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

        if (Input.GetKeyUp("2"))
        {
            animator.SetInteger("anim", 6);
            magicEquipp = !magicEquipp;
        }

        if (Input.GetMouseButton(0) && canMagic==true && magicEquipp)
        {

            canMagic = !canMagic;
            magicIndex = Random.Range(0f, 5f);
            
            animator.SetTrigger("magic");
            animator.SetInteger("anim", 7);
            magic4.SetActive(true);
            Invoke("stopMagic", 2);
          
        }
        

        canMagic = !canMagic;

        
    }
    void ShootParticles()
    {
        switch (magicIndex)
        {
            case 0:
                magic1.SetActive(true);
                Invoke("stopMagic", 17);
                break;
            case 1:
                magic2.SetActive(true);
                Invoke("stopMagic", 17);
                break;
            case 2:
                magic3.SetActive(true);
                Invoke("stopMagic", 71);
                break;
            case 3:
                magic4.SetActive(true);
                Invoke("stopMagic", 17);
                break;
            case 4:
                magic5.SetActive(true);
                Invoke("stopMagic", 4);
                break;
            default:
                break;

        }

    }

    void stopMagic()
    {
        magic1.SetActive(false);
        magic2.SetActive(false);
        magic3.SetActive(false);
        magic4.SetActive(false);
        magic5.SetActive(false);
        
    }

    void magicF()
    {
        Instantiate(magic, hand);
        magic.transform.position = Vector3.MoveTowards(magic.transform.position, Cube.transform.position, magicSpeed);

    }

    void equip()
    {
        //backWeapon.SetActive(false);
        //handWeapon.SetActive(true);
    }

    void unequip()
    {
        //backWeapon.SetActive(true);
        //handWeapon.SetActive(false);
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

