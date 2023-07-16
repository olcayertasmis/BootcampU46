using System.Collections;
using System.Collections.Generic;
using Enemy_Scripts;
using UnityEngine;

namespace Player_Scripts
{
    public class MagicScript : MonoBehaviour
    {
        [SerializeField] private GameObject healthB;
        private bool _magicEquip;
        private bool _canMagic;
        private Animator animator;


        [SerializeField] private float raycastDistance = 10f;
        [SerializeField] private float raycastHeight = 0.5f;

        private void Start()
        {
            animator = GetComponent<Animator>();
            _canMagic = true;
        }

        private void Update()
        {
            RaycastHit hit;
            Vector3 raycastStart = transform.position + Vector3.up * raycastHeight;
            if (Physics.Raycast(raycastStart, transform.forward, out hit, raycastDistance))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null && _canMagic)
                {
                    //if (Input.GetKeyDown(KeyCode.E))
                    //{
                    //    animator.SetInteger("anim", 6);
                    //    _magicEquip = !_magicEquip;
                    //    healthB.GetComponent<charController>().health = 100;
                    //}

                    if (Input.GetKeyUp("1"))
                    {
                        _canMagic = false;
                        enemy.transform.GetChild(0).gameObject.SetActive(true);
                        StartCoroutine(Timer(enemy.transform.GetChild(0).gameObject));
                        enemy.TakeDamage(5);
                    }
                    else if (Input.GetKeyUp("2"))
                    {
                        _canMagic = false;
                        enemy.transform.GetChild(1).gameObject.SetActive(true);
                        StartCoroutine(Timer(enemy.transform.GetChild(1).gameObject));
                        enemy.TakeDamage(5);
                    }
                    else if (Input.GetKeyUp("3"))
                    {
                        _canMagic = false;
                        enemy.transform.GetChild(2).gameObject.SetActive(true);
                        StartCoroutine(Timer(enemy.transform.GetChild(2).gameObject));
                        enemy.TakeDamage(5);
                    }
                    else if (Input.GetKeyUp("4"))
                    {
                        _canMagic = false;
                        enemy.transform.GetChild(3).gameObject.SetActive(true);
                        StartCoroutine(Timer(enemy.transform.GetChild(3).gameObject));
                        enemy.TakeDamage(5);
                    }
                    else if (Input.GetKeyUp("5"))
                    {
                        _canMagic = false;
                        enemy.transform.GetChild(4).gameObject.SetActive(true);
                        StartCoroutine(Timer(enemy.transform.GetChild(4).gameObject));
                        enemy.TakeDamage(5);
                    }
                }
            }

            Debug.DrawLine(raycastStart, raycastStart + transform.forward * raycastDistance, Color.red);
        }

        private IEnumerator Timer(GameObject obj)
        {
            yield return new WaitForSeconds(5f);
            obj.SetActive(false);
            _canMagic = true;
        }
    }
}