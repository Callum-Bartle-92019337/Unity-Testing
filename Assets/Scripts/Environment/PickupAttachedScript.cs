using UnityEngine;

public class PickupAttachedScript : MonoBehaviour, IpooledObject
{

    public AudioClip createSound;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnObjectSpawn()
    {
        source.PlayOneShot(createSound, 1f);
    }
}
