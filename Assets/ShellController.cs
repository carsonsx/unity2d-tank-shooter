using UnityEngine;
using System.Collections;

public class ShellController : MonoBehaviour {

    private bool visible = false;

    private void OnWillRenderObject()
    {
        visible = true;
    }

    private void Update()
    {
        if (!visible)
        {
            Destroy(gameObject);
        }
        visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("~~~~~~~~~~~~~OnTriggerEnter~~~~~~~~~~~~~~~~~~~~" + other.gameObject.name);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
