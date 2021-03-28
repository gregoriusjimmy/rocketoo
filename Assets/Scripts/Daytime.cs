using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Daytime : MonoBehaviour
{
   [SerializeField] float initialExposure = 1.2f;
   [SerializeField] float initialRotation = 0f;
   int currentSceneIndex;

   void Start()
   {
      currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

      float newExposureValue = initialExposure - 0.2f * currentSceneIndex;
      float newRotationValue = initialRotation + 30f * currentSceneIndex;
      RenderSettings.skybox.SetFloat("_Exposure", newExposureValue);
      RenderSettings.skybox.SetFloat("_Rotation", newRotationValue);



   }

   // Update is called once per frame
   void Update()
   {

   }
}
