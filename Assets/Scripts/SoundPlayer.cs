using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : Singleton<SoundPlayer>
{
    private readonly Vector2 MinMaxRange = new Vector2(0.85f, 1.15f);

    private AudioSource _audioSource;

    protected override void OnAwake() => _audioSource = GetComponent<AudioSource>();

    public void Play(AudioClip clip)
    {
        _audioSource.pitch = GetRandomPitch();
        _audioSource.PlayOneShot(clip);
    }

    private float GetRandomPitch() => Random.Range(MinMaxRange.x, MinMaxRange.y);
}