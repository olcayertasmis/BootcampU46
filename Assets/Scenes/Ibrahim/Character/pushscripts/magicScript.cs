using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicScript : MonoBehaviour
{
    public GameObject trail1,trail2,effect;
    public Transform magic, hand;
    float attackIndex;
    bool magicEquipp = false; //istafe
    bool canMagic = true;
    //public GameObject backWeapon;
    //public GameObject handWeapon;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        closeMagicTrail();
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
            //attackIndex = Random.Range(0f, 3f);
            animator.SetTrigger("magic");
            animator.SetInteger("anim", 7);

        }

        canMagic = !canMagic;

        
    }

    void magicF()
    {
        Instantiate(magic, hand);

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

