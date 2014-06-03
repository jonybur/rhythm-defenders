using UnityEngine;
using System.Collections;

public class GetSpectrumScript : MonoBehaviour {

	private float[] samples = new float[512];
	public float[] curValues = new float[8];
	
	public Texture2D SampleImg;
	
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this.transform.gameObject);
		Application.targetFrameRate = 60;
	}
	
	string ss = "";
	// Update is called once per frame
	void Update () {
		
		int count = 0;
		float diff = 0;
		
		AudioListener.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
		ss = "";
		for (int i = 0; i < 8; ++i)
		{
			
			float average = 0;
			
			int sampleCount = (int)Mathf.Pow(2, i) * 2;
			
			for (int j = 0; j < sampleCount; ++j)
			{
				
				average += samples[count] * (count + 1);
				++count;
			}
			
			average /= count;
			
			diff = Mathf.Clamp(average * 10 - curValues[i], 0, 4);
			
			curValues[i] = average * 10;
			ss += curValues[i].ToString("0.000")+",";
		}
	}

	void OnGUI()
	{		
		//GUI.Label(new Rect(0, 0, 600, 500), ss);
		
		int ImageHeight = 20;
		
		/*for (int i = 0; i < 8; i++ )
		{
			float Height = ImageHeight * (1 - curValues[i]);
			//GUI.DrawTexture(new Rect(15+ i * 35, 500 + Height, 30, ImageHeight - Height), SampleImg); 
			//valorTest = curValues[0];
		}*/
		
	}
}
