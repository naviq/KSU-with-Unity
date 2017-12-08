using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
    private GameObject btn;
   
    public void Start()
    {
        btn = GameObject.Find("loadLevel");
    }

    public void onClick()
    {
        btn.SetActive(false);
    }

	public void Quit() {
		Debug.Log ("EXIT");
		Application.Quit ();

	}
}
