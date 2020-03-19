using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class VersiyonKontrol : MonoBehaviour
{
    public Text int_kontrol, versiyon;
    public GameObject button;
    public bool esitlik;
    string guncelversiyon;

    /*  
      © EpicSocial TR (YouTube)
      Abone olmak isterseniz link :  https://www.youtube.com/channel/UCUxJbw8UMHgdEsQRAohzu2w?sub_confirmation=1
      Whatsapp Grubu: https://chat.whatsapp.com/FtTv3g4kI1N09BriI2ybJY
    */

    void Start()
    {
        Debug.Log("Application Version : " + Application.version);
        // versiyon.text = ("Version : " + Application.version);

        StartCoroutine(GetRequest("https://denemevideo1231.blogspot.com/"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                /* Eğer bağlantı kurulamaz ise */
                // int_kontrol.text = "İnternet bağlantısı yok.";
            }
            else
            {
                string uzunluk = "<epicsocial>";
                int baslangic = webRequest.downloadHandler.text.IndexOf("<epicsocial>") + uzunluk.Length;
                int bitis = webRequest.downloadHandler.text.IndexOf("</epicsocial>");
                string versiyonal = webRequest.downloadHandler.text.Substring(baslangic, bitis - baslangic);

                guncelversiyon = "";
                string[] a = versiyonal.Split(' ');

                for (int i = 0; i < a.Length; i++)
                { guncelversiyon += a[i]; }

                if (guncelversiyon == Application.version)
                {
                    print("Versiyonlar eşit");
                    esitlik = true;
                 //   int_kontrol.text = "Versiyonlar Eşit";
                  //  button.SetActive(false);
                }
                else
                {
                    esitlik = false;
                    print("Eşit değil");
                   // int_kontrol.text="Versiyonlar Eşit Değil";
                   // button.SetActive(true);
                }
            }
        }
    }

    public void guncelle()
    {
        Application.OpenURL("market://details?id=com.test.test");
    }
}
