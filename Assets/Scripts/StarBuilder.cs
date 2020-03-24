using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBuilder : MonoBehaviour {

    public string color;
    public double magnitude;

	// Use this for initialization
	void Start () {
        Light light = this.gameObject.transform.GetChild(0).GetComponent<Light>();
        Color starCol = Color.white;
        if(ColorUtility.TryParseHtmlString(color, out starCol)) light.color = starCol;
        light.transform.localPosition = new Vector3(MagnitudeToTransform(magnitude), 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    float MagnitudeToTransform(double mag) {
        // Old linear magnitude scale
        //return (float) (.21636 * mag + .87273);

        // New exponential magnitude scales
        return 5 / (Mathf.Exp((float) (mag / -5.1)) * 5.7F); // V1
        //return 6 / Mathf.Exp((float) (mag + 1.5F) / -3.5F) * 10;// V2
    }
}
