using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    [SerializeField]
    private GameObject punchSlasher;
    private GameObject activeSlashEffect; // Menyimpan referensi efek slash yang aktif
    private PlayerController GetPlayer;

    private void Awake()
    {
        GetPlayer = GameObject.FindGameObjectWithTag(Tags.Player_Tags).GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioControler.audioControler.PlaySound("Pukul");
            if (!GetPlayer.isDefense)
            {
                activeSlashEffect = Instantiate(punchSlasher, new Vector3(transform.position.x, transform.position.y, -4.0f), Quaternion.identity);
            }
        }
        else if (collision.CompareTag("Enemy"))
        {
            AudioControler.audioControler.PlaySound("Pukul");
            activeSlashEffect = Instantiate(punchSlasher, new Vector3(transform.position.x, transform.position.y, -4.0f), Quaternion.identity);
        }
    }

    public void StopActiveSlashEffect()
    {
        if (activeSlashEffect != null)
        {
            Destroy(activeSlashEffect);
        }
    }
    // [SerializeField]
    // private GameObject punchSlasher;
    // private PlayerController GetPlayer;

    // void Awake()
    // {
    //     GetPlayer = GameObject.FindGameObjectWithTag(Tags.Player_Tags).GetComponent<PlayerController>();
    // }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Player") && !GetPlayer.isDefense)
    //     {
    //         Instantiate(punchSlasher, new Vector3(transform.position.x, transform.position.y, -4.0f), Quaternion.identity);
    //     }
    //     else if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
    //     {
    //         Instantiate(punchSlasher, new Vector3(transform.position.x, transform.position.y, -4.0f), Quaternion.identity);
    //     }
    // }

}
