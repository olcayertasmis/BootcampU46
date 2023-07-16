using System;
using Enemy_Scripts;
using UnityEngine;

namespace Player_Scripts
{
    public class Sword : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("test");
                other.GetComponent<Enemy>().TakeDamage(10);
            }
        }
    }
}