using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
  public static AudioClip Playerhitsound, coincollectsound, jumpsound;
  static  AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        Playerhitsound = Resources.Load<AudioClip>("Playerhit");
       coincollectsound = Resources.Load<AudioClip>("coin");
        jumpsound = Resources.Load<AudioClip>("Jumping");
        audiosrc = GetComponent<AudioSource>();
        audiosrc.volume = 0.1f;
    }
    public static void  Playsound(string clip)
    {
        switch (clip)
        {
            case "Playerhit":
                audiosrc.PlayOneShot(Playerhitsound);
                break;
            case "coin":
                audiosrc.PlayOneShot(coincollectsound);
                break;
            case "Jumping":
                audiosrc.PlayOneShot(jumpsound);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
