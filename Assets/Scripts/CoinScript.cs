using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public ParticleSystem particleEffect;

    [SerializeField] private float rotateSpeed;

    private GameManager gameManager;
    
    private void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, rotateSpeed, 0);
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.IncrementCoinCount();
            gameManager.IncrementScoreByAmount(100);
            Destroy(gameObject);
        }
    }
}
