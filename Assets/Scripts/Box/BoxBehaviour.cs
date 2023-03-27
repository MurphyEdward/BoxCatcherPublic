using UnityEngine;

public abstract class BoxBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip _soundOnGroundCollision;
    [SerializeField] private AudioClip _soundOnPlayerCollision;
    [SerializeField] private string _soundSystemName;
    [SerializeField] private float _damage;
    private AudioSource _audioSource;

    public float Damage => _damage;

    private void Awake()
    {
        _audioSource = GameObject.Find(_soundSystemName).GetComponent<AudioSource>();
    }

    public void DestroyBox()
    {
        Destroy(gameObject);
        ApplyDestroyEffect();
    }

    public void PlayGroundCollisionSound()
    {
        _audioSource.clip = _soundOnGroundCollision;
        _audioSource.Play();
    }

    public void PlayPlayerCollisionSound()
    {
        _audioSource.clip = _soundOnPlayerCollision;
        _audioSource.Play();
    }

    protected abstract void ApplyDestroyEffect();
}
