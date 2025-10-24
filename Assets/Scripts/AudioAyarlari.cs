using UnityEngine;
using UnityEngine.Audio; // AudioMixer için gerekli
using UnityEngine.UI;    // UI elemanları için gerekli (şimdilik opsiyonel)

public class AudioAyarlari : MonoBehaviour
{
    // Inspector'dan atayacağımız AnaMixer referansı
    public AudioMixer anaMixer;

    // Müzik sesini Slider ile ayarlayan fonksiyon
    public void SetMusicVolume(float volume)
    {
        // Kontrol: Eğer Slider 0'a çekilirse (volume <= 0.0001f), ses tamamen kapatılır (-80dB).
        // Aksi takdirde, doğrusal Slider değerini logaritmik dB değerine dönüştürür.
        if (volume <= 0.0001f)
        {
            anaMixer.SetFloat("MuzikVolume", -80f); // Parametre adı: MuzikVolume (Adım 1.3'teki ile aynı olmalı!)
        }
        else
        {
            // Logaritmik dönüşüm: 20 * log10(volume)
            anaMixer.SetFloat("MuzikVolume", Mathf.Log10(volume) * 20f);
        }
    }

    // SFX sesini Slider ile ayarlayan fonksiyon
    public void SetSFXVolume(float volume)
    {
        if (volume <= 0.0001f)
        {
            anaMixer.SetFloat("SFXVolume", -80f); // Parametre adı: SFXVolume
        }
        else
        {
            anaMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20f);
        }
    }
}