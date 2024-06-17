using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour {
    void Start() {

    }

    void Toggle() {
        Debug.Log("Toggling surface");
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    void Update() {
        
    }
}
