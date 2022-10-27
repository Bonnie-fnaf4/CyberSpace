using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMainCamera : MonoBehaviour
{
    public Animator anim;
    public void RightRotate(bool b)
    {
        anim.SetBool("Right", b);
    }
    public void LeftRotate(bool b)
    {
        anim.SetBool("Left", b);
    }
    public void UpRotate(bool b)
    {
        anim.SetBool("Up", b);
    }
    public void DownRotate(bool b)
    {
        anim.SetBool("Down", b);
    }
}
