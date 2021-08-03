using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using System.IO;

[RequireComponent(typeof(ARPlaneManager))]
public class ButtonPlace : MonoBehaviour
{
    public GameObject jersey;
    private GameObject spawnedObject;

    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private ARPlaneManager _arPlaneManager;
    // Start is called before the first frame update

    [SerializeField]
    private ARPlane arPlane;

    public TextAsset jsonFile;
    [Serializable]
    public class ModelInfo
    {
        public Model_Transform model;
    }
    [Serializable]
    public class Model_Transform
    {
        public Vector3 scale=new Vector3(2.0f,2.0f,2.0f);
        public Vector3 rotation=new Vector3(10.0f,10.0f,10.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/jerseyinfo.json");
        Debug.Log(json);
        ModelInfo loadedModelTransform = JsonUtility.FromJson<ModelInfo>(jsonFile.text);
        Debug.Log("Scale:" + loadedModelTransform.model.scale);
        //jersey.transform.localScale = new Vector3(loadedModelTransform.model.scale.x,loadedModelTransform.model.scale.y,loadedModelTransform.model.scale.z);
        //jersey.transform.rotation = new Quaternion(loadedModelTransform.model.rotation.x, loadedModelTransform.model.rotation.y, loadedModelTransform.model.rotation.z, 0.0f);
    }
    private void Awake()
    {
        _arPlaneManager = GetComponent<ARPlaneManager>();
        _arPlaneManager.planesChanged += PlaneChanged;
       
    }
    
    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null)
        {
          arPlane = args.added[0];
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateObject()
    {
        spawnedObject = Instantiate(jersey, arPlane.transform.position ,jersey.transform.rotation);
    }
}
