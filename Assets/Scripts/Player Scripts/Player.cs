using System;
using UnityEngine;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        [Header("Status")]
        [SerializeField] private int maxHealth;
        private int currentHealth;

        private HealthBar _healthBar;

        private void Awake()
        {
            //foreach (Canvas canvas in GetComponentsInChildren<Canvas>())
            //{
            //    if (canvas.CompareTag("HealthBarCanvas")) _healthBar = canvas.GetComponentInChildren<HealthBar>();
            //}
        }

        private void Start()
        {
            currentHealth = maxHealth;
            //_healthBar.SetMaxHealth(maxHealth);
        }

        public void TakeDamage(int damage)
        {
            if (currentHealth == 0) return;

            currentHealth -= damage;

            _healthBar.SetHealth(currentHealth);
        }
    }
}