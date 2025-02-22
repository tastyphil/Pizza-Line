using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Main : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.PlayMusic("menu");
    }

    // Update is called once per frame
    public void StartDay() {
        SceneManager.LoadScene("Game");
    }
}
