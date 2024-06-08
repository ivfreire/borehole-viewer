using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour {
    void Start() {

    }

    void Toggle() {
        Renderer renderer = this.GetComponent<Renderer>();
        renderer.enabled = !renderer.enabled;
    }

    void Update() {
        
    }
}
