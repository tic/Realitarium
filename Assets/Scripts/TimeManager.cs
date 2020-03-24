using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public decimal JulianDay;
    public decimal J2000 = 2451545m;
    public decimal SinceJ2000;

    public double TimeMultiplier = 1;

    private decimal JDPerSecond = 1m / 86400m;

	// Use this for initialization
	void Start () {
        System.DateTime x = System.DateTime.UtcNow;
        JulianDay = (decimal) x.ToOADate() + 2415018.5m;
        //JulianDay = 2458910;
        SinceJ2000 = JulianDay - J2000;
    }
	
	// Update is called once per frame
	void Update () {

        // Advance the current day at the proper rate
        decimal adv = JDPerSecond * (decimal)Time.deltaTime * (decimal)TimeMultiplier;
        JulianDay += adv;
        SinceJ2000 += adv;
	}
}
