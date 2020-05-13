using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{
    public InputField usernameField;
    public InputField emailField;
    public InputField passwordField;
    public InputField confirmPasswordField;
    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("email", emailField.text);
        form.AddField("password", passwordField.text);


        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log("Erro no registro" + www.error);
        }
        else {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Registro Efetuado com Sucesso!");
            SceneManager.LoadScene(0);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (usernameField.text.Length >= 3 && passwordField.text.Length >= 8 && confirmPasswordField.text == passwordField.text);
    }

    void Update()
    {
        VerifyInputs();
    }
}
