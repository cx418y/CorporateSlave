using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{

    public AudioClip[] clips;
    public AudioSource alarmBGM;

    // Start is called before the first frame update
    void Start()
    {
        alarmBGM.clip = Combine();
        alarmBGM.Play();
        alarmBGM.loop = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip Combine()
    {
        int length = 0;
        foreach (AudioClip clip in clips)
        {
            length += clip.samples;
        }

        float[] data = new float[length];

        int position = 0;
        foreach (AudioClip clip in clips)
        {
            float[] buffer = new float[clip.samples];
            clip.GetData(buffer, 0);
            buffer.CopyTo(data, position);
            position += clip.samples;
        }

        AudioClip mergedClip = AudioClip.Create("MergedClip", length, 1, 44100, false);
        mergedClip.SetData(data, 0);

        return mergedClip;
    }

}
