using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DigerOyun : MonoBehaviour
{
    public Text puan;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        puan.text = "Puanýnýz: " + PlayerPrefs.GetInt("Puan");
    }

    // Update is called once per frame
    public void YenidenOyna()
    {
        SceneManager.LoadScene("Bolum1");
    }
    public void SonrakiBolum()
    {
        SceneManager.LoadScene("Bolum2");
    }
}
