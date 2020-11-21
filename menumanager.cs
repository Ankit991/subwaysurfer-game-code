using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System.Collections;
public class menumanager : MonoBehaviour
{
    public Text highscorepoint,cointext;
    public Text coinvalue;
    public AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        highscorepoint.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        cointext.text = PlayerPrefs.GetInt("Totalcoins", 0).ToString();
    }

    public void Playsound()
    {
        audiosrc.enabled = true;
    }
    public void Stopsound()
    {
        audiosrc.enabled = false;
    }
   
}
