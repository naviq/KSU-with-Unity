using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuManager : MonoBehaviour {

    public Animator animator;
    
	// Use this for initialization
	void Start () {
        animator.SetBool("isOpen", false);
    }
	
	// Update is called once per frame
	public void OpenMenu()
    {
        Debug.Log("start menu");
        animator.SetBool("isOpen", true);
    }
	
    public void CloseMenu()
    {
        animator.SetBool("isOpen", false);
    }
}
