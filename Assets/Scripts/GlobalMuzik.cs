using UnityEngine;

public class GlobalMuzik : MonoBehaviour
{
    // Singleton deseni: Bu script'in sadece bir kopyasının var olmasını sağlar
    public static GlobalMuzik instance;

    void Awake()
    {
        // Eğer sahnede bu objeden zaten varsa (önceki sahnelerden geldiği için)
        if (instance != null)
        {
            // Bu yeni kopyayı yok et
            Destroy(gameObject);
        }
        else
        {
            // İlk kopyaysa, instance'ı bu objeye ata
            instance = this;
            
            // SAHNELER ARASINDA YOK EDİLMESİN!
            DontDestroyOnLoad(gameObject);
            
            // Sesi çalmaya başla (Eğer AudioSource üzerinde Play On Awake işaretli değilse)
            // GetComponent<AudioSource>().Play(); 
        }
    }
}