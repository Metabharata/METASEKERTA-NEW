using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ulti : MonoBehaviour
{
    public AudioSource senjataAudioSource;
    private int direction; // -1 for left, 1 for right
    public float ultiSpeed;
    public GameObject impactEffect; // Assign the impact effect Prefab in the Inspector
    public float lifetime = 2.0f; // Set the lifetime of the arrow

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    public void SetDirection(int dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.Translate(Vector3.right * direction * ultiSpeed * Time.deltaTime);

        // ...
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            senjataAudioSource.Play();
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject); // Destroy the ulti when it hits an enemy
            Debug.Log("Hancur");
        }
    }


    // ...
}
