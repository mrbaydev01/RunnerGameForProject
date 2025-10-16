using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneYonetimi : MonoBehaviour
{
    // Başla butonuna basıldığında çağrılacak
    public void Basla()
    {
        // "Game" sahnesine geç
        SceneManager.LoadScene("SampleScene");
    }

    // Çıkış butonuna basıldığında çağrılacak
    public void Cikis()
    {
        Debug.Log("Oyun kapatildi."); // Editörde test için
        Application.Quit(); // Oyunu kapatır
    }

    // Oyuncu öldüğünde çağrılacak
    public void OyuncuOlum()
    {
        // MainMenu sahnesine dön
        SceneManager.LoadScene("MainMenüScene");
    }
}
