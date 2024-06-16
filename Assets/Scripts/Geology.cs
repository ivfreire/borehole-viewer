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

    void InstantiateLayer(float depth, GameObject parent, Texture texture) {
        GameObject layerObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Layer.prefab", typeof(GameObject));

        GameObject instance = Instantiate(layerObject, parent.transform);
        instance.transform.localScale = new Vector3(1.0f, 1.0f, depth);
        instance.transform.localPosition = Vector3.down * this.currentDepth;


        Renderer renderer = instance.GetComponent<Renderer>();
        renderer.material.mainTextureScale = new Vector2(1.0f, depth);
        renderer.material.mainTexture = texture;

        this.currentDepth += depth;
    }

    void InstantiateLayers() {
        GameObject layers = GameObject.Find("Layers");

        this.InstantiateLayer(4.0f,  layers, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/SandyClay.png", typeof(Texture)));
        this.InstantiateLayer(1.0f,  layers, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/SiltyClayOrganic.png", typeof(Texture)));
        this.InstantiateLayer(5.0f,  layers, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/SiltyClay.png", typeof(Texture)));
        this.InstantiateLayer(10.0f, layers, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/FineSand.png", typeof(Texture)));
        this.InstantiateLayer(10.0f, layers, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/SiltyClay.png", typeof(Texture)));
        this.InstantiateLayer(6.0f,  layers, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/FineSand.png", typeof(Texture)));
        this.InstantiateLayer(17.0f, layers, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/SiltyClayV2.png", typeof(Texture)));
        this.InstantiateLayer(30.0f, layers, (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Geology/GraniteGnaiss.png", typeof(Texture)));
    }

    void Toggle() {
        GameObject outer = GameObject.Find("Outer");
        outer.SetActive(!outer.activeSelf);
    }

    void Update() {
        
    }
}
