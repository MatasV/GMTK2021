using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    public enum Controls {Arrows, AWSD}

    public Controls controls;
    public Animator Animator;
    public float movementSpeed;
    private void Update()
    {
        switch (controls)
        {
            case Controls.Arrows:
                if (Input.GetKey(KeyCode.LeftArrow) && transform.localPosition.x > -0.9f)
                {
                    transform.localRotation = Quaternion.Euler(0, 180 ,0 );
                    Animator.SetBool("walking", true);
                    transform.localPosition += Vector3.left * movementSpeed;
                } else if (Input.GetKey(KeyCode.RightArrow) && transform.localPosition.x < 0.9f)
                {
                    transform.localRotation = Quaternion.Euler(0, 0 ,0 );
                    Animator.SetBool("walking", true);
                    transform.localPosition += Vector3.right * movementSpeed;
                }
                else
                {
                    Animator.SetBool("walking", false);
                }
                break;
            case Controls.AWSD:
                if (Input.GetKey(KeyCode.A)&& transform.localPosition.x > -0.9f)
                {
                    transform.localRotation = Quaternion.Euler(0, 180 ,0 );
                    Animator.SetBool("walking", true);
                    transform.localPosition += Vector3.left * movementSpeed;
                } else if (Input.GetKey(KeyCode.D) && transform.localPosition.x < 0.9f)
                {
                    transform.localRotation = Quaternion.Euler(0, 0 ,0 );
                    Animator.SetBool("walking", true);
                    transform.localPosition += Vector3.right * movementSpeed;
                }
                else
                {
                    Animator.SetBool("walking", false);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
