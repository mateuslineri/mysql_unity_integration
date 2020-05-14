using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin() 
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest request = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form);
        request.downloadHandler = new DownloadHandlerBuffer();
        
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError) {
            Debug.LogError("Erro na requisição de LogIn: " + request.error);
        } 
        else {
            string[] playerData = request.downloadHandler.text.Split('\t');

            DBManager.username = playerData[0];
            DBManager.score = int.Parse(playerData[1]);
            DBManager.level = int.Parse(playerData[2]);

            SceneManager.LoadScene(0);
        }
    }

    public void VerifyFields()
    {
        submitButton.interactable = (usernameField.text.Length > 0 && passwordField.text.Length > 0);
    }

    void Update()
    {
        VerifyFields();
    }
}
