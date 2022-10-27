using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCameraAnimation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    // Use this for initialization
    void Start()
	{
        
	}

	// Update is called once per frame
	void Update()
	{

    }

    public void StartAnim()
    {
        anim.SetTrigger("Start");
    }

}
