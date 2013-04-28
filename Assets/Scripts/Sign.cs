using UnityEngine;
using System.Collections;

public enum SignType
{
    None, Stop, OneWayLeft, OneWayRight, Speed15, Speed30
}

public class Sign : MonoBehaviour {

    private GUISigns guiSignRef;
    public PathNode pathNodeRef;

    public SignType type = SignType.None;

	// Use this for initialization
	void Start () {
         guiSignRef = GameObject.Find("GameController").GetComponent<GUISigns>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown()
    {
        guiSignRef.updateSignReference(this);
    }

    public void updateSignType(SignType newType)
    {
        type = newType;
        string modelpath;
        GameObject go = null;

        switch (type)
        {
            case SignType.OneWayLeft:
                modelpath = "oneWaySign";
                go = Instantiate(Resources.Load(modelpath)) as GameObject;
                break;
        }
        MeshFilter mf1 = (MeshFilter)GameObject.Find("/oneWaySignPrefab/oneWay_cube_01").GetComponent("MeshFilter");
        Mesh m1 = (Mesh)Mesh.Instantiate(mf1.mesh);
        MeshFilter mf2 = (MeshFilter)GameObject.Find("/" + this.gameObject.name + "/stopSign_cube_01").GetComponent("MeshFilter");
        mf2.mesh = m1;

    }
}
