using UnityEngine;

public class MusicaFundo : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip musica; // Arraste a música no Inspector

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musica;
        audioSource.loop = true; // Repete a música
        audioSource.playOnAwake = true; // Toca automaticamente
        audioSource.volume = 0.5f; // Ajuste o volume se necessário
        audioSource.Play();
    }
}