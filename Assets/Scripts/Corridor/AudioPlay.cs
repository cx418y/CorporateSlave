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
        // 确定合并后音频的采样率和通道数
        int frequency = clips[0].frequency;
        int channels = clips[0].channels;

        // 计算合并后音频的总长度
        int length = 0;
        foreach (AudioClip clip in clips)
        {
            length += clip.samples;
        }

        // 创建合并后音频的数据数组
        float[] data = new float[length];

        // 将所有音频片段复制到合并后的数据数组中
        int position = 0;
        foreach (AudioClip clip in clips)
        {
            // 确保采样率和通道数一致
            if (clip.frequency != frequency || clip.channels != channels)
            {
                Debug.LogError("All audio clips must have the same frequency and channels.");
                // return null;
            }

            float[] buffer = new float[clip.samples];
            clip.GetData(buffer, 0);
            buffer.CopyTo(data, position);
            position += clip.samples;
        }

        // 创建合并后的音频剪辑
        AudioClip mergedClip = AudioClip.Create("MergedClip", length, channels, frequency, false);
        mergedClip.SetData(data, 0);

        return mergedClip;
    }

}
