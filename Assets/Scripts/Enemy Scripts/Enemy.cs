using System;
using Player_Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy_Scripts
{
    public class Enemy : MonoBehaviour
    {
        [Header("Other Components")]
        private CharacterController _enemyController;
        private Transform _target;
        private Rigidbody _rb;
        private Animator _anim;

        [Header("Features")]
        [SerializeField] private float followRange;

        [Header("Status")]
        [SerializeField] private int health;
        [SerializeField] private float speed;

        [Header("Idle Movement")]
        [SerializeField] private float movementDuration;
        [SerializeField] private float movementDistance;
        private float _movementTimer;
        private Vector3 _originalPosition;
        private Vector3 _targetMovingAround;
        private Vector3 randomDirection;

        private bool meleeAttack;
        private bool _isFollowing;
        private bool isMovingAround;

        private void Awake()
        {
            _enemyController = GetComponent<CharacterController>();
            //_rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _target = FindObjectOfType<Player>().transform;
            _originalPosition = transform.position;
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!_target) return;

            float distanceToTarget = Vector3.Distance(transform.position, _target.position);

            if (!_isFollowing && distanceToTarget <= followRange) StartFollowing();
            else if (_isFollowing && distanceToTarget > followRange) StopFollowing();

            if (_isFollowing) FollowTarget();
            else
            {
                MoveAround();
                CheckAroundPos();
            }

            if (health <= 0) Die();
        }

        private void StartFollowing()
        {
            _isFollowing = true;
        }

        private void StopFollowing()
        {
            _isFollowing = false;
        }

        private void FollowTarget()
        {
            Vector3 direction = _target.position - transform.position;

            _enemyController.Move(direction.normalized * (speed * Time.deltaTime));
        }

        private void MoveAround()
        {
            _movementTimer += Time.deltaTime;

            if (_movementTimer >= movementDuration)
            {
                if (!isMovingAround)
                {
                    randomDirection = Random.insideUnitSphere;
                    randomDirection.y = 0f;
                    randomDirection.Normalize();
                }

                _targetMovingAround = _originalPosition + randomDirection * movementDistance;

                Vector3 moveDirection = (_targetMovingAround - transform.position).normalized;
                _enemyController.Move(moveDirection * (speed * Time.deltaTime));

                isMovingAround = true;
            }
        }

        private void CheckAroundPos()
        {
            if (Vector3.Distance(transform.position, _targetMovingAround) <= .1f && isMovingAround)
            {
                isMovingAround = false;
                _movementTimer = 0;
            }
        }
        private void Attack()
        {
            
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        private void Die()
        {
            // Düşmanın yok edilmesi ve aniamsyon
        }
    }
}