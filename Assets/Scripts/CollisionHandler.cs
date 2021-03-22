using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float levelLoadDelay = 1.2f;
   [SerializeField] AudioClip crashSfx;
   [SerializeField] AudioClip successSfx;
   [SerializeField] ParticleSystem crashParticles;
   [SerializeField] ParticleSystem successParticles;

   AudioSource audioSource;
   Animator animator;

   bool isTransitioning = false;
   bool collisionDisable = false;

   void Start()
   {
      audioSource = GetComponent<AudioSource>();
      animator = gameObject.GetComponentInChildren<Animator>();
   }

   void Update()
   {
      RespondToDebugKeys();
   }

   void RespondToDebugKeys()
   {
      if (Input.GetKeyDown(KeyCode.L)) LoadNextLevel();
      else if (Input.GetKeyDown(KeyCode.C)) collisionDisable = !collisionDisable;

   }

   void OnCollisionEnter(Collision other)
   {
      if (isTransitioning || collisionDisable) return;
      switch (other.gameObject.tag)
      {
         case "Friendly":
            break;
         case "Finish":
            StartSuccessSequence();
            break;
         default:
            StartCrashSequence();
            break;
      }
   }

   void StartSuccessSequence()
   {
      isTransitioning = true;
      audioSource.Stop();
      audioSource.PlayOneShot(successSfx);
      successParticles.Play();
      GetComponent<Movement>().enabled = false;
      Invoke("LoadNextLevel", levelLoadDelay);
   }

   void StartCrashSequence()
   {
      isTransitioning = true;
      animator.SetBool("isCrashing", true);
      audioSource.Stop();
      audioSource.PlayOneShot(crashSfx);
      crashParticles.Play();
      GetComponent<Movement>().enabled = false;
      Invoke("ReloadLevel", levelLoadDelay);
   }
   void ReloadLevel()
   {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

      SceneManager.LoadScene(currentSceneIndex);
   }

   void LoadNextLevel()
   {

      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      int nextSceneIndex = currentSceneIndex + 1;
      if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
         nextSceneIndex = 0;
      SceneManager.LoadScene(nextSceneIndex);
   }
}
