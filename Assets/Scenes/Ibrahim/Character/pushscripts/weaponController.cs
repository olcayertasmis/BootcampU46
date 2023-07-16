using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject trails;
    float attackIndex;
    bool equipp=false; //istafe
    bool canAttack=true;
    bool blocking = false;
    public GameObject backWeapon;
    public GameObject handWeapon;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        closeTrail();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            equipp=!equipp;
            animator.SetBool("equip", equipp);
        }

        if (Input.GetMouseButton(0) && equipp==true && canAttack==true)
        {
           
            canAttack = !canAttack;
            attackIndex= Random.Range(0f, 3f);
            animator.SetFloat("attackIndex", attackIndex);
            animator.SetTrigger("saldýr");
            
           
            
        }

        canAttack = !canAttack;

        if(Input.GetMouseButton(1) && equipp==true)
        {
            blocking=!blocking;
            animator.SetTrigger("saldýr");
            animator.SetBool("blocking", blocking);
            attackIndex =3;
        }
        
        blocking = !blocking;
    }

    void equip()
    {
        backWeapon.SetActive(false);
        handWeapon.SetActive(true);
    }

    void unequip()
    {
        backWeapon.SetActive(true);
        handWeapon.SetActive(false);
    }

    public void openTrail()
    {
        for (int i = 0; i < trails.transform.childCount; i++)
        {
            trails.transform.GetChild(i).gameObject.GetComponent<TrailRenderer>().emitting = true;
        }
    }
    public void closeTrail()
    {
        for (int i = 0; i < trails.transform.childCount; i++)
        {
            trails.transform.GetChild(i).gameObject.GetComponent<TrailRenderer>().emitting = false;
        }
    }
}
