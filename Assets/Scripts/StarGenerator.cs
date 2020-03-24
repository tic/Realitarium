using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {

    private static Dictionary<string, string> spectrumMap = new Dictionary<string, string>
    {
        {
            "O", "#92B5FF"
        },
        {
            "B", "#A2C0FF"
        },
        {
            "A", "#D5E0FF"
        },
        {
            "F", "#F9F5FF"
        },
        {
            "G", "#FFEDE3"
        },
        {
            "K", "#FFDAB5"
        },
        {
            "M", "#FFB56C"
        }
    };
    
    public GameObject StarTemplate;
    public string CatalogFile;

    // Based on viewing from Charlottesville
    public double lattitude = 38.0291667;
    public double longitude = -78.4769444;
    public double celestialRotationOffset = 10;

    // Control how fast time flows
    public GameObject TimeKeeper;
    private readonly decimal axialDegreesPerDay = 0.00007292115m * (180 / 3.14159265358979323846264338327950m) * 86400;//359m + 1m / 60m;

    private decimal lastDegree = 0;

    // Use this for initialization
    void Start () {
        // Show the stars
        LoadStarCatalog();

        // Align the sky
        SetSkyAlignment();
    }
	
	void Update () {
        // Calculate the new rotation of the sky based on the current Julian Date
        decimal degrees = axialDegreesPerDay * TimeKeeper.GetComponent<TimeManager>().SinceJ2000 % 360;
        float net = (float) (degrees - lastDegree);
        lastDegree = degrees;

        this.transform.Rotate(new Vector3(0, 1, 0), net);
	}

    void InstantiateStar(string name, string hexcolor, float rightAscension, float declination, double mag) {
        GameObject star = Instantiate(StarTemplate, this.transform, false);
        StarBuilder sb = star.GetComponent<StarBuilder>();
        sb.color = hexcolor;
        sb.magnitude = mag;
        star.name = name;
        star.transform.Rotate(new Vector3(0, rightAscension, declination));
    }

    void LoadStarCatalog()
    {
        // Right Ascension: convert from hours to degrees
        // Declination:     needs NO correction

        // Load star catalog
        TextAsset catfile = Resources.Load<TextAsset>(CatalogFile);
        string[] catalog = catfile.text.Split(new char[] { '\n' });

        foreach (string star in catalog)
        {
            string[] details = star.Split(new char[] { ',' });
            
            //if (details[6] != "Polaris" && details[6] != "Sirius") continue;

            double magnitude = double.Parse(details[10]);
            // Other stars can't be seen from Charlottesville because of light pollution
            if (magnitude < 4)
            {
                string hexcolor;

                if (!spectrumMap.TryGetValue(details[12].Substring(0, 1), out hexcolor)) continue;


                string name = details[6].Length > 1 ? details[6] : "HIP-" + details[1].Trim();
                InstantiateStar(name, hexcolor, 360F - float.Parse(details[7]) * 15, float.Parse(details[8]), magnitude);
            }
        }
    }

    void SetSkyAlignment() {
        // Orient the sky based on lattitude
        this.transform.Rotate(new Vector3((float)lattitude - 90, 0, 0));
        
        // Orient the sky to J2000
        this.transform.Rotate(new Vector3(0, 1, 0), (float)celestialRotationOffset);

        // Orient the sky based on longitude
        this.transform.Rotate(new Vector3(0, 1, 0), (float) longitude);
    }
}
