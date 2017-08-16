using UnityEngine;
using System.Collections;

public class PickupItem1 : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject particle;    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)            
                r.enabled = false;            

            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject, audioClip.length);
        }
    }
}