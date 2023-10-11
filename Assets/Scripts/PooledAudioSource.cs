using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public static class PooledAudioSource
{
    public static GameObject root;
    public static ObjectPool<AudioSource> audioSourcePool;
    public static readonly int INITIAL_POOL_SIZE = 10;
    public static readonly int MAX_POOL_SIZE = 20;

    public static AudioSource sourceInstance;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Initialize()
    {
        root = new GameObject("AudioSource Pool");

        audioSourcePool = new ObjectPool<AudioSource>(
            () => CreateAudioSource(),
            audioSource => audioSource.gameObject.SetActive(true),
            audioSource => audioSource.gameObject.SetActive(false),
            audioSource => Object.Destroy(audioSource.gameObject),
            false, INITIAL_POOL_SIZE, MAX_POOL_SIZE
        );

        sourceInstance = CreateAudioSource();

        Object.DontDestroyOnLoad(root);
        Object.DontDestroyOnLoad(sourceInstance.gameObject);
    }

    private static AudioSource CreateAudioSource()
    {
        GameObject pool = new GameObject("AudioSource Object");
        pool.transform.SetParent(root.transform);

        AudioSource source = pool.gameObject.AddComponent<AudioSource>();
        return source;
    }

    public static AudioSource PlayAudio(AudioClip clip, bool loop = false, float volume = 1.0f)
    {
        AudioSource source = audioSourcePool.Get();
        source.clip = clip;
        source.loop = loop;
        source.volume = volume;
        source.Play();
        return source;
    }

    public static void StopAudio(AudioSource source)
    {
        source.clip = null;
        source.loop = false;
        source.volume = 1.0f;
        source.Stop();
        audioSourcePool.Release(source);
    }

    public static void PlaySimpleAudio(AudioClip clip, bool loop = false, float volume = 1.0f)
    {
        sourceInstance.clip = clip;
        sourceInstance.loop = loop;
        sourceInstance.volume = volume;
        sourceInstance.Play();
    }

    public static void StopSimpleAudio(AudioSource source)
    {
        sourceInstance.clip = null;
        sourceInstance.loop = false;
        sourceInstance.volume = 1.0f;
        sourceInstance.Stop();
    }
}
