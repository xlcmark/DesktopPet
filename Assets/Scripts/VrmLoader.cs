using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniVRM10;
using UniGLTF;
using System.IO;

public class VrmLoader : MonoBehaviour
{
    public VRM10Object vRM10Object;
    public string _vrmName;
    // Start is called before the first frame update
    void Start()
    {
        LoadModel(_vrmName);
    }

    public async void LoadModel(string _modelName)
    {
        string path= Path.Combine(Application.streamingAssetsPath, _modelName+".vrm");
        var Instance = await Vrm10.LoadPathAsync(path);


        //Instance.Vrm=vRM10Object;

        Instance.gameObject.AddComponent<VrmExpressionChanger>();
        

    }
    


    


}
