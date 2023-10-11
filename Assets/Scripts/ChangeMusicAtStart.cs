using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicAtStart : MonoBehaviour
{
    public AudioClip clip;
    public bool loop = false;
    [Range(0.0f, 1.0f)] public float volume = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        PooledAudioSource.PlaySimpleAudio(clip, loop, volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
