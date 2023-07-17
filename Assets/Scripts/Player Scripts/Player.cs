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
            //_healthBar.SetMaxHealth(maxHealth);
        }

        public void TakeDamage(int damage)
        {
            if (currentHealth == 0) return;

            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
    }
}