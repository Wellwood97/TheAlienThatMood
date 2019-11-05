using UnityEngine;
using System.Collections;



public class Music : MonoBehaviour
{
    // the length of the music audio file
    public float loopLength;
    // selecting the audio file
    public AudioClip SoundClip1;


    // Use this for initialization
    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        // starts audio
        audio.Play();
        // wait for the audio to have finished
        yield return new WaitForSeconds(audio.clip.length);
        // assign the other clip and play it
        audio.clip = SoundClip1;
        audio.loop = true;
        audio.Play();
    }
}