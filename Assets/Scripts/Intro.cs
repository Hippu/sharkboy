using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("h");
        Application.LoadLevel("TestLevel2");
    }

}
