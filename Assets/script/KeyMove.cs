using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove : MonoBehaviour {

    public static Color defaultColor;
    public static Color selectedColor;
    public static Material mat;

    float speed = 10.0f;
    float rotSpeed = 1.0f;

    // 화면비 고정, 테스트 필요
    //void Awake()
    //{
    //    Screen.SetResolution(720, 1280, true);
    //}

    // Use this for initialization
    void Start () {
        mat = GetComponent<Renderer>().material;
        defaultColor = mat.color;
        selectedColor = new Color32(255, 0, 0, 255);

        mat.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        moveObject();
    }

    void moveObject()
    {
        //float keyHorizontal = Input.GetAxis("Horizontal");
        //float keyVertical = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
        //transform.Translate(Vector3.forward * speed * Time.smoothDeltaTime * keyVertical, Space.World);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.forward * v);


        float MouseX = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * rotSpeed * MouseX);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "around")
        {
            mat.color = selectedColor;
        }
       
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "around")
        {
            mat.color = defaultColor;
        }
    }
}
