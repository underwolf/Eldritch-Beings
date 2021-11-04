using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
           //
        }
    }

    [Header("Transition")]
    public FadeInOut m_Fader;

    [Header("Loading")]
    public GameObject m_LoadingPanel;
    public float m_DelayAfterLoading = 2.0f;

    public void LoadLevel(string nextSceneName)
    {
        StartCoroutine(ChangeScene(nextSceneName, false));
    }

    public void LoadLevelLoading(string nextSceneName)
    {
        StartCoroutine(ChangeScene(nextSceneName, true));
    }

    public void StartLevelCultist(string nextSceneName)
    {
        PlayerPrefs.SetInt("LibrarySeal", 1);
        PlayerPrefs.SetInt("CourtyardSeal", 1);
        PlayerPrefs.SetInt("WineCellarSeal", 1);
        PlayerPrefs.SetInt("AtticSeal", 1);
        StartCoroutine(ChangeScene(nextSceneName, false));
    }
    public void StartLevelInvestigador(string nextSceneName)
    {
        PlayerPrefs.SetInt("LibrarySeal", 0);
        PlayerPrefs.SetInt("CourtyardSeal", 0);
        PlayerPrefs.SetInt("WineCellarSeal", 0);
        PlayerPrefs.SetInt("AtticSeal", 0);
        StartCoroutine(ChangeScene(nextSceneName, false));
    }

    private IEnumerator ChangeScene(string nextSceneName, bool loading)
    {
        List<BehaviorUI> list = Helper.FindAll<BehaviorUI>();
        foreach (BehaviorUI ui in list)
            ui.Disable();

        m_Fader.Show();
        yield return new WaitForSeconds(m_Fader.m_Time);

        if (nextSceneName.Equals("Quit"))
        {
            Application.Quit();
        }
        else
        {
            if (loading)
            {
                m_LoadingPanel.SetActive(true);

                m_Fader.Hide();
                yield return new WaitForSeconds(m_Fader.m_Time);
            }

            AsyncOperation asyncScene = SceneManager.LoadSceneAsync(nextSceneName);
            asyncScene.allowSceneActivation = false;


            while (!asyncScene.isDone)
            {
                if (asyncScene.progress >= 0.9f)
                {
                    if (loading)
                    {
                        yield return new WaitForSeconds(m_DelayAfterLoading);

                        m_Fader.Show();
                        yield return new WaitForSeconds(m_Fader.m_Time);

                        m_LoadingPanel.SetActive(false);
                    }

                    asyncScene.allowSceneActivation = true;
  
                }

                yield return null;
            }
        }
    }
}