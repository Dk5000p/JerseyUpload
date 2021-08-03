using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    [Serializable]
    public class ModelInfo
    {
        public Model_Transform model;
    }
    [Serializable]
    public class Model_Transform
    {
        public Vector3 scale;
        public Vector3 rotation;
    }
 
    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/jerseyinfo.json");
        Debug.Log(json);
        ModelInfo loadedModelTransform = JsonUtility.FromJson<ModelInfo>(jsonFile.text);
        Debug.Log("Scale:"+loadedModelTransform.model.scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
