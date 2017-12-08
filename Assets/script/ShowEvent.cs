using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEvent : MonoBehaviour {
    GameObject target, target1;
    GameObject tempObj;
    // Use this for initialization
    void Start () {
        //target = GameObject.FindWithTag("building");
        //tempObj = GameObject.Find("around").transform.FindChild("Build").gameObject;

        target = transform.Find("Build").gameObject;
        target.SetActive(false);
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target.SetActive(true);
            Debug.Log("들어옴");
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target.SetActive(false);
            Debug.Log("나감");
        }
    }
}
