using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

    GetSpectrumScript a;
    float playbackSpeed;

    void Awake()
    {
        this.particleSystem.renderer.sortingLayerName = "stars";

        try
        {
            a = (GetSpectrumScript)GameObject.Find("audio").GetComponent("GetSpectrumScript");
        }
        catch
        {
            a = (GetSpectrumScript)GameObject.Find("audio_debug").GetComponent("GetSpectrumScript");
        }
        playbackSpeed = this.particleSystem.playbackSpeed;
    }

    void Update()
    {
        this.particleSystem.playbackSpeed = playbackSpeed + a.curValues[0];
    }
}
