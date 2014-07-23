using UnityEngine;
using System.Collections;
using System;

public class GetSpectrumScript : MonoBehaviour {

	private float[] samples = new float[512];
	public float[] curValues = new float[8];

    // promedio devuelve un promedio de los ultimos X (cantPromedio) de valores de curValues[0]
    const int cantPromedio = 10;
    private float[] ultimos = new float[cantPromedio];
    private int numero = 0;
    public float promedio;
	
	public Texture2D SampleImg;
	
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this.transform.gameObject);
		Application.targetFrameRate = 60;

        Array.Clear(ultimos, 0, ultimos.Length);
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

        if (numero < cantPromedio)
        {
            ultimos[numero] = curValues[0];
            numero++;
        }
        else { numero = 0; }

        for (int i = 0; i < cantPromedio; i++)
        {
            promedio += ultimos[i];
        }
        promedio /= cantPromedio;

        Debug.Log(promedio);
	}

	void OnGUI()
	{		
		GUI.Label(new Rect(0, 0, 600, 500), ss);
		
		int ImageHeight = 20;
		
		for (int i = 0; i < 8; i++ )
		{
			float Height = ImageHeight * (1 - curValues[i]);
			//GUI.DrawTexture(new Rect(15+ i * 35, 500 + Height, 30, ImageHeight - Height), SampleImg); 
		    //valorTest = curValues[0];
		}
		
	}
}
