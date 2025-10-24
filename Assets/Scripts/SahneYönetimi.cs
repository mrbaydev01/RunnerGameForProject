using UnityEngine;
using UnityEngine.SceneManagement; // Sahne geçişleri için
using UnityEngine.Audio;         // Ses mixer'ı için (eğer mute/unmute burada olacaksa)
using UnityEngine.UI;            // Toggle için (eğer mute/unmute burada olacaksa)


public class SahneYonetimi : MonoBehaviour
{
    // Inspector'dan atanacak ayarlar paneli objesi
    public GameObject ayarlarPaneli; 

    // OYNA butonuna basıldığında çağrılacak
    public void Basla()
    {
        // "Game" sahnesine geç
        // Not: Unity'de varsayılan yeni sahne adı "SampleScene"dir. 
        // Eğer oyun sahnenin adını "Game" yaptıysan "Game" olarak değiştirmelisin.
        SceneManager.LoadScene("SampleScene"); 
    }

    // ÇIKIŞ butonuna basıldığında çağrılacak
    public void Cikis()
    {
        Debug.Log("Oyun kapatildi."); // Editörde test için
        Application.Quit(); // Oyunu kapatır
    }

    // Oyuncu öldüğünde çağrılacak (veya oyun bittiğinde Main Menüye dönüş)
    public void OyuncuOlum()
    {
        // Ana Menü sahnesine dön
        // Not: Main menü sahnesinin adı "MainMenüScene" ise bu şekilde kalır, 
        // farklıysa adını güncellemeyi unutma.
        SceneManager.LoadScene("MainMenüScene"); 
    }

    // AYARLAR butonuna basıldığında ayarlar panelini açar
    public void AyarlarAc()
    {
        if (ayarlarPaneli != null) // Panel atandıysa kontrol et
        {
            ayarlarPaneli.SetActive(true); // Ayarlar panelini görünür yap
        }
        else
        {
            Debug.LogWarning("Ayarlar Paneli atanmamış! Lütfen Inspector'dan atama yapın.");
        }
    }

    // Ayarlar panelindeki GERİ butonuna basıldığında ayarlar panelini kapatır
    public void AyarlarKapat()
    {
        if (ayarlarPaneli != null) // Panel atandıysa kontrol et
        {
            ayarlarPaneli.SetActive(false); // Ayarlar panelini gizle
        }
    }

    // ---------- Ses Ayarları Fonksiyonları (İsteğe bağlı, eğer buraya taşımak istersen) ----------
    // Eğer AudioSettingsManager script'ini ayrı tutmak istiyorsan bu kısmı kopyalamana gerek yok.
    // Ancak her şeyi tek bir yerden yönetmek istersen kullanışlı olabilir.

    // Inspector'dan atamak için AudioMixer referansı
    public AudioMixer mainMixer; 

    // Müzik sesini ayarlayan fonksiyon
    public void SetMusicVolume(float volume)
    {
        if (mainMixer != null)
        {
            if (volume <= 0) 
            {
                mainMixer.SetFloat("MusicVolume", -80f); 
            }
            else
            {
                mainMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20f);
            }
        }
    }

    // Efekt sesini ayarlayan fonksiyon
    public void SetSFXVolume(float volume)
    {
        if (mainMixer != null)
        {
            if (volume <= 0)
            {
                mainMixer.SetFloat("SFXVolume", -80f);
            }
            else
            {
                mainMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20f);
            }
        }
    }

    // Sesin tamamen kapatılıp açılmasını (Mute) sağlayan fonksiyon
    public void SetMasterMute(bool isMuted)
    {
        if (mainMixer != null)
        {
            if (isMuted)
            {
                mainMixer.SetFloat("MasterVolume", -80f);
            }
            else
            {
                mainMixer.SetFloat("MasterVolume", 0f);
            }
        }
    }
}