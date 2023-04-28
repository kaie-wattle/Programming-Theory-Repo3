using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TextMeshProUGUI highScoreInfo;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        Debug.Log("Score:"+ GameManager.instance.highScore);
        if (GameManager.instance != null)
        {
            if (!string.IsNullOrEmpty(GameManager.instance.highScorePlayerName))
            {
                highScoreInfo.SetText("HighScore:" + GameManager.instance.highScorePlayerName + ":" + GameManager.instance.highScore);
            }
        }
    }

    public void StartButtom()
    {
        if (string.IsNullOrEmpty(nameInput.text))
        {
            GameManager.instance.SetName();
        }
        else
        {
            GameManager.instance.SetName(nameInput.text);
        }
        SceneManager.LoadScene(1);
    }

    public void ExitButtom()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
