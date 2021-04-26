using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;



public class AudioManager : MonoBehaviour
{
   public Sound[] sounds;
   public static AudioManager instance;

   void Awake()
   {
      if (instance == null) instance = this;
      else
      {

         Destroy(this.gameObject);
         return;
      }

      DontDestroyOnLoad(this.gameObject);
      foreach (Sound s in sounds)
      {
         s.source = gameObject.AddComponent<AudioSource>();
         s.source.clip = s.clip;

         s.source.volume = s.volume;
         s.source.pitch = s.pitch;
         s.source.loop = s.loop;
      }
   }

   void Start()
   {
      Play("SoundTrackRock");
   }

   public void Play(string name)
   {
      Sound s = Array.Find(sounds, sound => sound.name == name);
      if (s == null)
      {
         Debug.LogWarning("Sound: " + name + " not found");
         return;
      }
      s.source.Play();
   }
   public void StopPlaying(string sound)
   {
      Sound s = Array.Find(sounds, item => item.name == sound);
      if (s == null)
      {
         Debug.LogWarning("Sound: " + name + " not found!");
         return;
      }


      s.source.Stop();
   }
   public bool IsPlaying(string sound)
   {
      Sound s = Array.Find(sounds, item => item.name == sound);
      if (s == null)
      {
         Debug.LogWarning("Sound: " + name + " not found!");
         return false;
      }
      return s.source.isPlaying;
   }

}
