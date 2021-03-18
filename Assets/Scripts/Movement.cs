using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   // Start is called before the first frame update
   [SerializeField] float mainThurst = 0;
   [SerializeField] AudioClip mainEngine;
   [SerializeField] float rotationThurst = 100;
   [SerializeField] ParticleSystem mainEngineParticles;
   [SerializeField] ParticleSystem leftThrusterParticles;
   [SerializeField] ParticleSystem rightThrusterParticles;
   float minMainThrust = 0;
   float maxMainThrust = 1500;
   float acceleration = 1000;
   AudioSource audioSource;
   Rigidbody rb;

   void Start()
   {
      rb = GetComponent<Rigidbody>();
      audioSource = GetComponent<AudioSource>();
   }


   void Update()
   {
      ProcessThrust();
      ProcessRotation();
   }

   void ProcessThrust()
   {
      if (Input.GetKey(KeyCode.Space)) StartThrusting();
      else StopThrusting();

   }

   void ProcessRotation()
   {
      if (Input.GetKey(KeyCode.A)) RotateLeft();
      else if (Input.GetKey(KeyCode.D)) RotateRight();
      else StopRotating();
   }

   void StartThrusting()
   {
      mainThurst += acceleration * Time.deltaTime;
      rb.AddRelativeForce(Vector3.up * mainThurst * Time.deltaTime);
      if (!audioSource.isPlaying) audioSource.PlayOneShot(mainEngine);
      if (!mainEngineParticles.isPlaying) mainEngineParticles.Play();
      if (mainThurst > maxMainThrust)
         mainThurst = maxMainThrust;
   }

   void StopThrusting()
   {
      audioSource.Stop();
      mainEngineParticles.Stop();
      mainThurst -= acceleration * Time.deltaTime;
      if (mainThurst < minMainThrust)
         mainThurst = minMainThrust;
   }

   void RotateLeft()
   {
      if (!rightThrusterParticles.isPlaying) rightThrusterParticles.Play();
      ApplyRotation(rotationThurst);
   }

   void RotateRight()
   {
      if (!leftThrusterParticles.isPlaying) leftThrusterParticles.Play();
      ApplyRotation(-rotationThurst);
   }

   void ApplyRotation(float rotationThisFrame)
   {
      rb.freezeRotation = true; // freezing rotation so we can manually rotate;
      transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
      rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
   }

   void StopRotating()
   {
      rightThrusterParticles.Stop();
      leftThrusterParticles.Stop();
   }
}