using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Geology : MonoBehaviour {
    public Borehole borehole;
    private float currentDepth = 0.0f;

    void Start() {
        this.InstantiateLayers();
    }

    void InstantiateLayer(string name, float depth, Texture texture) {
        // Large outer layers
        GameObject outer = GameObject.Find("Outer");
        GameObject layerObject = GameObject.Find("Outer/Layer");

        GameObject instance = Instantiate(layerObject, outer.transform);
        instance.transform.localScale = new Vector3(1.0f, 1.0f, depth);
        instance.transform.localPosition = Vector3.down * this.currentDepth;
       

        Renderer renderer = instance.GetComponent<Renderer>();
        renderer.material.mainTextureScale = new Vector2(1.0f, depth);
        renderer.material.mainTexture = texture;

        // Cut layers
        GameObject cut = GameObject.Find("Cut");
        layerObject = GameObject.Find("Cut/Layer");

        // Final layer first


        instance = Instantiate(layerObject, cut.transform);
        instance.transform.localScale = new Vector3(1.0f, 1.0f, depth);
        instance.transform.localPosition = Vector3.down * this.currentDepth;

        renderer = instance.GetComponent<Renderer>();
        renderer.material.mainTextureScale = new Vector2(1.0f, depth);
        renderer.material.mainTexture = texture;

        this.currentDepth += depth;
    }

    void InstantiateLayers() {

        // TODO: Implement layer loading from a file.
        this.InstantiateLayer("Sandy Clay Fill", 4.0f, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/SandyClay.png", typeof(Texture)));
        this.InstantiateLayer("Silty Clay Organic Fill", 1.0f, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/SiltyClayOrganic.png", typeof(Texture)));
        this.InstantiateLayer("Silty Clay Fill", 5.0f, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/SiltyClay.png", typeof(Texture)));
        this.InstantiateLayer("Fine Sand Fill", 10.0f, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/FineSand.png", typeof(Texture)));
        this.InstantiateLayer("Silty Clay Fill", 10.0f, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/SiltyClay.png", typeof(Texture)));
        this.InstantiateLayer("Fine Sand Fill", 6.0f, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/FineSand.png", typeof(Texture)));
        this.InstantiateLayer("Silty Clay Fill V2", 17.0f, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/SiltyClayV2.png", typeof(Texture)));
        this.InstantiateLayer("Granite Gnaiss Fill", 30.0f, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/GraniteGnaiss.png", typeof(Texture)));

        // Remove original layer
        Destroy(GameObject.Find("Outer/Layer"));
        Destroy(GameObject.Find("Cut/Layer"));
    }

    void Toggle() {
        GameObject outer = GameObject.Find("Outer");
        outer.SetActive(!outer.activeSelf);
    }

    void Update() {
        
    }
}
