using System;
using System.Collections;
using Player_Scripts;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy_Scripts
{
    public class Enemy : MonoBehaviour
    {
        [Header("Other Components")]
        private CharacterController _enemyController;
        private Transform _target;
        private Animator _anim;
        private BoxCollider _boxCollider;

        [Header("Features")]
        [SerializeField] private float followRange;
        [SerializeField] private int rotationSpeed;

        [Header("Status")]
        [SerializeField] private int health;
        [SerializeField] private float speed;
        [SerializeField] private int attackPower;

        [Header("Idle Movement")]
        [SerializeField] private float movementDuration;
        [SerializeField] private float movementDistance;
        private float _movementTimer;
        private Vector3 _originalPosition;
        private Vector3 _targetMovingAround;
        private Vector3 randomDirection;

        [Header("Control")]
        private bool isAttacking;
        private bool _isFollowing;
        private bool isMovingAround;
        private bool isDead;

        private void Awake()
        {
            _enemyController = GetComponent<CharacterController>();
            _anim = GetComponent<Animator>();
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            _target = FindObjectOfType<Player>().transform;
            _originalPosition = transform.position;
        }

        private void Update()
        {
            if (isDead) return;
            if (!_target) return;

            float distanceToTarget = Vector3.Distance(transform.position, _target.position);
            Debug.Log(distanceToTarget);

            if (!isAttacking && distanceToTarget < 2.75f) StartCoroutine(AttackCoroutine());

            if (!_isFollowing && distanceToTarget <= followRange && !isAttacking) StartFollowing();
            else if (_isFollowing && distanceToTarget > followRange && !isAttacking) StopFollowing();

            if (_isFollowing && !isAttacking && distanceToTarget >= 2.75f) FollowTarget();
            else if (!_isFollowing && !isAttacking)
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
            direction.y = 0.1f;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            _enemyController.Move(direction.normalized * (speed * Time.deltaTime));
            _anim.SetFloat("speed", 1.5f);
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

                Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

                _enemyController.Move(moveDirection * (speed * Time.deltaTime));
                _anim.SetFloat("speed", 0.5f);

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

        private IEnumerator AttackCoroutine()
        {
            isAttacking = true;
            StopFollowing();

            _anim.SetFloat("speed", 0f);
            _anim.SetTrigger("Attack");

            yield return new WaitForSeconds(2.5f);

            _target.GetComponent<Player>().TakeDamage(attackPower);

            isAttacking = false;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        private void Die()
        {
            _anim.SetTrigger("Death");
            StartCoroutine(SetDeath());
            isDead = true;
        }

        private IEnumerator SetDeath()
        {
            yield return new WaitForSeconds(1f);
            _boxCollider.enabled = false;
            _enemyController.enabled = false;
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0f, 0f, 90f, 0f), 1f);
            transform.position = new Vector3(transform.position.x, .5f, transform.position.z);
        }
    }
}