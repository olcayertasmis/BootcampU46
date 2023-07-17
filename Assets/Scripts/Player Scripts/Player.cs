using System;
using UnityEngine;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        [Header("Status")]
        [SerializeField] private int maxHealth;
        private int currentHealth;

        [SerializeField] private HealthBar healthBar;

        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("test");
                TakeDamage(10);
            }*/
        }

        public void TakeDamage(int damage)
        {
            if (currentHealth == 0) return;

            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
    }
}