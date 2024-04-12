using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;
    private float amplitudeGain;
    private float frequencyGain;
    void Start()
    {
        noise = cinemachineVirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    public void SetAmplitudeGain(float val)
    {
        amplitudeGain = val;
    }
    public void SetFrequencyGain(float val)
    {
        frequencyGain = val;
    }
    public void Shake(float time)
    {
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;
        StartCoroutine(Shaking(time));
    }
    IEnumerator Shaking(float t)
    {
        yield return new WaitForSeconds(t);
        noise.m_AmplitudeGain = 0f;
    }
}
