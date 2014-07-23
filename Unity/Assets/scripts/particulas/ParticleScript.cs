using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {
    GetSpectrumScript a;
    float playbackSpeed;
    float velocityScale;
    
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
        velocityScale = (this.particleSystem.renderer as ParticleSystemRenderer).velocityScale;
    }

    void Update()
    {
        this.particleSystem.playbackSpeed = playbackSpeed + a.curValues[0];
		// nota: el "/ 7" es a ojo, con el iphone de referencia
        (this.particleSystem.renderer as ParticleSystemRenderer).velocityScale = velocityScale + a.curValues[0] / 7;
    }
}
 