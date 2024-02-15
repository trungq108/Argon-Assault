using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    MusicPlayer[] musicPlayer;
    private void Awake()
    {
        musicPlayer = FindObjectsOfType<MusicPlayer>();
        if(musicPlayer.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
