using UnityEngine;

public class AudioSourceGroup : MonoBehaviour
{
    public AudioSource[] typingSources;
    private int nextTypeSource = 0;

    public void PlayFromNextSource(AudioClip clip) {
        AudioSource nextSource = typingSources[nextTypeSource];
        nextSource.clip = clip;
        nextSource.volume = PlayerPrefs.GetFloat("SfxVolume") * PlayerPrefs.GetFloat("MasterVolume");
        nextSource.pitch = Random.Range(0.9f, 1.1f);
        nextSource.Play();
        nextTypeSource = (nextTypeSource + 1) % typingSources.Length;
    }
}
