using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class loadImg : MonoBehaviour
{
    public string imageURL;
    private Renderer renderer;
    // Start is called before the first frame update

    //static string name = "wcs.jpeg";

    static string service_endpoint = "https://ows.rasdaman.org/rasdaman/ows";

    static string base_wcs_url = service_endpoint + "?service=WCS&version=2.0.1";

    static string request = "&REQUEST=GetCoverage";

    static string cov_id = "&COVERAGEID=S2_L2A_32631_TCI_60m";

    static string subset_time = "&SUBSET=ansi(\"2021-04-09\")";

    static string subset_e = "&SUBSET=E(669960,729960)";

    static string subset_n = "&SUBSET=N(4990200,5015220)";

    static string encode_format = "&FORMAT=image/jpeg";

    static string url = base_wcs_url + request + cov_id + subset_time + subset_e + subset_n + encode_format;




    void Start()
    {

        renderer = GetComponent<Renderer>();
        StartCoroutine(LoadFromRemote());
    }

    

    IEnumerator LoadFromRemote()
    {
        UnityWebRequest getImage = UnityWebRequestTexture.GetTexture(url);

        //UnityWebRequest getImage = UnityWebRequestTexture.GetTexture("https://datacubes.eecs.jacobs-university.de/rasdaman/ows?service=WMS&version=1.3.0&request=GetMap&layers=BlueMarbleCov&bbox=-90,-180,90,180&width=800&height=600&crs=EPSG:4326&format=image/png&transparent=true&styles=");
        //UnityWebRequest getImage = UnityWebRequestTexture.GetTexture("https://ows.rasdaman.org/rasdaman/ows?service=WCS&version=2.0.1&request=ProcessCoverage=&query= for $c in (mean_summer_airtemp) return encode($c, \"png\")");
        //UnityWebRequest getImage = UnityWebRequestTexture.GetTexture("https://ows.rasdaman.org/rasdaman/ows?service=WCS&version=2.0.1&request=ProcessCoverage=&query=for $c in (S2_L2A_32631_B01_60m) return encode( ( 0.20 * ( 35.0 + ( (float) $c[ ansi( \"2021-04-09\" ) ] ) ) )[ E( 669960:729960 ), N( 4990200:5015220 ) ] , \"image/jpeg\")");

        yield return getImage.SendWebRequest();
        if (!string.IsNullOrEmpty(getImage.error))
        {
            Debug.Log("Error " + getImage.error);
        }
        else
        {
            renderer.material.mainTexture = DownloadHandlerTexture.GetContent(getImage);
        }
    }

    
}
