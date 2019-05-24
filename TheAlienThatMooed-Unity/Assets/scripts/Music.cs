using UnityEngine;
using System.Collections;




public class Music : MonoBehaviour
{

    public AudioClip SoundClip1;


    // Use this for initialization
    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();


        audio.Play();
        // Wait for the audio to have finished
        yield return new WaitForSeconds(audio.clip.length);
        // Assign the other clip and play its
        audio.clip = SoundClip1;
        audio.Play();
    }
}
