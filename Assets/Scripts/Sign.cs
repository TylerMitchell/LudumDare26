using UnityEngine;
using System.Collections;

public enum SignType
{
    None, Stop, OneWayNorth, OneWaySouth, OneWayEast, OneWayWest, Speed15, Speed30
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
        string modelpath = string.Empty;
        string texturepath = string.Empty;
        int yRotation = 0;

        switch (type) 
        {
            case SignType.OneWayNorth:
                modelpath = "/oneWaySign_v3/oneWay_cube_01";
                texturepath = "Textures/oneWaySign_text";
                yRotation = 270;
                break;
            case SignType.OneWaySouth:
                modelpath = "/oneWaySign_v3/oneWay_cube_01";
                texturepath = "Textures/oneWaySign_text";
                yRotation = 90;
                break;
            case SignType.OneWayEast:
                modelpath = "/oneWaySign_v3/oneWay_cube_01";
                texturepath = "Textures/oneWaySign_text";
                yRotation = 360;
                break;
            case SignType.OneWayWest:
                modelpath = "/oneWaySign_v3/oneWay_cube_01";
                texturepath = "Textures/oneWaySign_text";
                yRotation = 180;
                break;
            case SignType.Speed15:
                modelpath = "/speedLimitSign_v3/speedLimit_cube_01";
                texturepath = "Textures/speedLimitSign_text";
                yRotation = 180;
                break;
            case SignType.Speed30:
                modelpath = "/speedLimitSign_v3/speedLimit_cube_01";
                texturepath = "Textures/speedLimitSign_text";
                yRotation = 180;
                break;
            case SignType.Stop:
                modelpath = "/stopSign_v3/stopSign_cube_01";
                texturepath = "Textures/stopSignCubeText";
                yRotation = 180;
                break;
            case SignType.None:
                modelpath = "/defaultSignDupe/stopSign_cube_01";
                texturepath = null;
                yRotation = 180;
                break;
        }
        this.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        MeshFilter mf1 = (MeshFilter)GameObject.Find(modelpath).GetComponent("MeshFilter");
        Mesh m1 = (Mesh)Mesh.Instantiate(mf1.mesh);
        MeshFilter mf2 = (MeshFilter)GameObject.Find("/" + this.gameObject.name + "/stopSign_cube_01").GetComponent("MeshFilter");
        mf2.mesh = m1;
        Texture newTexture = (Texture)Resources.Load(texturepath);
        print(newTexture);
        //All signs MUST have different names in the hierarchy view, or else this will just apply to the first one in the list
        print(GameObject.Find("/" + this.gameObject.name + "/stopSign_cube_01").renderer.material);
        GameObject.Find("/" + this.gameObject.name + "/stopSign_cube_01").renderer.material.mainTexture = newTexture;

    }
}
