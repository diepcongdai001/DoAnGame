using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesCTL
{
    private static ResourcesCTL _instance;

    public static ResourcesCTL Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ResourcesCTL();
            return _instance;
        }
    }

    
    private Material _blackCellMaterial = null;
    public Material BlackCellMaterial
    {
        get
        {
            if (_blackCellMaterial == null)
                _blackCellMaterial = Resources.Load<Material>("Materials/Black");
            return _blackCellMaterial;
        }
    }

    private Material _whiteCellMaterial = null;
    public Material WhiteCellMaterial
    {
        get
        {
            if (_whiteCellMaterial == null)
                _whiteCellMaterial = Resources.Load<Material>("Materials/White");
            return _whiteCellMaterial;
        }
    }

    private ResourcesCTL() { }

    private Dictionary<string, GameObject> _dict = new Dictionary<string, GameObject>();
    
    public GameObject GetGameObject(string path)
    {
        if (_dict.ContainsKey(path) == false)
            _dict.Add(path, Resources.Load<GameObject>(path));
        return _dict[path];
    }
}
