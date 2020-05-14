using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Text playerDisplay;
    public Text levelDisplay;
    public Text scoreDisplay;

    private void Awake()
    {
        if (DBManager.username == null)
        {
            SceneManager.LoadScene(0);
        }
        playerDisplay.text = "Usuário: " + DBManager.username;
        levelDisplay.text = "Nível: " + DBManager.level;
        scoreDisplay.text = "Pontos: " + DBManager.score;
    }

    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("level", DBManager.level);
        form.AddField("score", DBManager.score);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/savedata.php", form);
        yield return www.SendWebRequest();

        if (www.isHttpError || www.isNetworkError) {
            Debug.Log("Erro no envio de dados do usuário. " + www.error);
        }
        else {
            Debug.Log("Dados salvos com sucesso.");
            DBManager.LogOut();
            SceneManager.LoadScene(0);
        }
    }

    public void IncreaseLevel() 
    {
        DBManager.level++;
        levelDisplay.text = "Nível: " + DBManager.level;
    }

    public void IncreaseScore()
    {
        DBManager.score++;
        scoreDisplay.text = "Pontos: " + DBManager.score;
    }
}
