using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    public void ReturnToMainMenu()
    {
        // Останавливаем музыку
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }
        
        // Загружаем сцену
        SceneManager.LoadScene("MainMenu");
    }
}