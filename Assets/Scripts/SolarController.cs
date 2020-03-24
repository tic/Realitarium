using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarController : MonoBehaviour {

    private static readonly float obliquity = 23.43667F * Mathf.Deg2Rad;
    public GameObject TimeKeeper;

    private float lastRA, lastDec;

    // Use this for initialization
    void Start () {

        float ra, dec;
        SolarPosition(out ra, out dec);

        lastRA = ra;
        lastDec = dec;

        this.transform.Rotate(new Vector3(0, ra, dec));
    }
	
	// Update is called once per frame
	void Update () {
        // Calculate new position
        float ra, dec;
        SolarPosition(out ra, out dec);
        //Debug.Log(ra);
        //Debug.Log(dec);
        //Debug.Log("----");

        // Move the Sun
        this.transform.Rotate(new Vector3(0, ra - lastRA, dec - lastDec));

        // Save new position
        lastRA = ra;
        lastDec = dec;
    }

    void SolarPosition(out float rightAscension, out float declination) {
        // Solar position formula
        double n = (double) TimeKeeper.GetComponent<TimeManager>().SinceJ2000;
        double L = (280.46 + .9856474 * n) % 360; // Returns a value in DEGREES
        double g = ((357.528 + .9856003 * n) % 360) * Mathf.Deg2Rad; // Returns a value in RADIANS

        float lambda = ((float)L + 1.915F * Mathf.Sin((float)g) + 0.02F * Mathf.Sin((float)g * 2)) * Mathf.Deg2Rad; // Returns a value in RADIANS

        rightAscension = Mathf.Atan(Mathf.Cos(obliquity) * Mathf.Tan(lambda)) * Mathf.Rad2Deg;
        declination = Mathf.Asin(Mathf.Sin(obliquity) * Mathf.Sin(lambda)) * Mathf.Rad2Deg;
    }
}
