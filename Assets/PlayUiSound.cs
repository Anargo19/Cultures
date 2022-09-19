using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUiSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(Object sound)
    {
        if (sound.GetType() != typeof(AudioClip))
            return;
        AudioClip clip = (AudioClip)sound;
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

}
