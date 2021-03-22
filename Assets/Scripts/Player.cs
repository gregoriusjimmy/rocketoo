using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

   private Animator animator;
   private CharacterController controller;

   public float speed = 600.0f;
   public float turnSpeed = 400.0f;
   private Vector3 moveDirection = Vector3.zero;
   public float gravity = 20.0f;

   void Start()
   {
      // controller = GetComponent <CharacterController>();
      animator = gameObject.GetComponentInChildren<Animator>();
   }

   void Update()
   {
      if (Input.GetKey(KeyCode.D))
      {
         animator.SetBool("isRunning", true);
      }
      else
      {
         animator.SetBool("isRunning", false);
      }

      // if(controller.isGrounded){
      // 	moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
      // }

      // float turn = Input.GetAxis("Horizontal");
      // transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
      // controller.Move(moveDirection * Time.deltaTime);
      // moveDirection.y -= gravity * Time.deltaTime;
   }
}
