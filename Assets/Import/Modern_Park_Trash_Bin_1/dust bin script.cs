using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DustbinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "webview moveable")
        //{
            Destroy(other.gameObject);
        //}
        
    }
}
