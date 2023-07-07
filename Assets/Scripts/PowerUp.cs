using System;
using System.Collections;
using System.Collections.Generic;
using Player_Scripts;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private float multiplier;
    [SerializeField] private float duration;

    [SerializeField] private GameObject pickUpEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) StartCoroutine(PickUp(other));
    }

    private IEnumerator PickUp(Collider player)
    {
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        Movement movement = player.GetComponent<Movement>();
        movement.speed *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        movement.speed /= multiplier;

        gameObject.SetActive(false);
    }
}