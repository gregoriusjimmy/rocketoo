using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   AudioManager audioManager;
   string currentSceneName;
   void Start()
   {
      audioManager = AudioManager.instance;
      currentSceneName = SceneManager.GetActiveScene().name;
      if (currentSceneName == "Rock1" && !audioManager.IsPlaying("SoundTrackRock"))
      {
         audioManager.StopPlaying("SoundTrackOrange");
         audioManager.Play("SoundTrackRock");
      }
      else if (currentSceneName == "Orange1")
      {
         audioManager.StopPlaying("SoundTrackRock");
         audioManager.Play("SoundTrackOrange");
      }
   }


}
