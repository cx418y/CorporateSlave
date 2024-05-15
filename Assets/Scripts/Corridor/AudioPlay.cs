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
        // ȷ���ϲ�����Ƶ�Ĳ����ʺ�ͨ����
        int frequency = clips[0].frequency;
        int channels = clips[0].channels;

        // ����ϲ�����Ƶ���ܳ���
        int length = 0;
        foreach (AudioClip clip in clips)
        {
            length += clip.samples;
        }

        // �����ϲ�����Ƶ����������
        float[] data = new float[length];

        // ��������ƵƬ�θ��Ƶ��ϲ��������������
        int position = 0;
        foreach (AudioClip clip in clips)
        {
            // ȷ�������ʺ�ͨ����һ��
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

        // �����ϲ������Ƶ����
        AudioClip mergedClip = AudioClip.Create("MergedClip", length, channels, frequency, false);
        mergedClip.SetData(data, 0);

        return mergedClip;
    }

}
