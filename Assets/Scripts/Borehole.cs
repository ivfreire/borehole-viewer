using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borehole : MonoBehaviour {
    public float depth = 10.0f;
    public float innerRadius = 1.0f;
    public float outerRadius = 1.0f;
    public float wasteRadius = 0.75f;

    public GameObject container;

    void Start() {
        this.InstantiateStructure();
        this.InstantiateContainers();
    }

    void InstantiateStructure() {
        transform.Find("Casing").localScale = new Vector3(1.0f, 1.0f, this.depth);
        transform.Find("Bottom").localPosition = Vector3.down * this.depth;

        GameObject backfill = GameObject.Find("Backfill");
        backfill.transform.localScale = new Vector3(1.3f, 1.3f, this.depth);
        backfill.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1.0f, this.depth);
    }

    void InstantiateContainers() {
        for (int i = 0; i < 4; i++) {
            GameObject instance = Instantiate(this.container, Vector3.zero, Quaternion.Euler(-90, 0, 0));
            instance.transform.localScale *= this.wasteRadius;
            instance.transform.localPosition = Vector3.down * (-1f + this.depth - 2.9f * this.wasteRadius * i);
        }
    }

    void Update() {
        
    }
}
