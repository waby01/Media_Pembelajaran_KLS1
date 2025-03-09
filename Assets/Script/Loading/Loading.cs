using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    public Scrollbar loadingBar;
    public TMP_Text tipText;
    public float loadTime = 3f;
    public string[] tips;

    private float progress = 0f;
    private static string targetScene;

    void Start()
    {
        if (tips.Length > 0)
        {
            tipText.text = tips[Random.Range(0, tips.Length)];
        }
        StartCoroutine(LoadProgress());
    }

    public static void SetTargetScene(string sceneName)
    {
        targetScene = "Kuis";
    }

    IEnumerator LoadProgress()
    {
        while (progress < 1f)
        {
            progress += Time.deltaTime / loadTime;
            loadingBar.size = progress;
            yield return null;
        }

        if (!string.IsNullOrEmpty(targetScene))
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}