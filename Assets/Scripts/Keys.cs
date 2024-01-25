using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    private int count =0;
    [SerializeField] private AudioClip sound;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {

            count++;
            AudioSource.PlayClipAtPoint(sound, other.transform.position);
            Destroy(other.gameObject);
        }
    }
}
