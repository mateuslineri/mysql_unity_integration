using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebTest : MonoBehaviour
{
    IEnumerator Start()
    {
        UnityWebRequest request = new UnityWebRequest("http://localhost/sqlconnect/webtest.php");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        string[] webResults = request.downloadHandler.text.Split('\t');
        // Debug.Log(webResults[0]);

        int webNumber = int.Parse(webResults[1]);
        webNumber += 20;
        // Debug.Log(webNumber);
    }
}
