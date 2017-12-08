using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menutrigger : MonoBehaviour {

	public void TriggerMenu()
    {
        FindObjectOfType<menuManager>().OpenMenu();
    }
}
