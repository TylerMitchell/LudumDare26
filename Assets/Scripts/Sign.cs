using UnityEngine;
using System.Collections;

public enum SignType
{
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
        int yRotation = 0;

        {
                modelpath = "/oneWaySign_v3/oneWay_cube_01";
                texturepath = "Textures/oneWaySign_text";
                break;
            case SignType.Stop:
                modelpath = "/stopSign_v3/stopSign_cube_01";
                texturepath = "Textures/stopSignCubeText";
                break;
            case SignType.None:
                modelpath = "/defaultSignDupe/stopSign_cube_01";
                texturepath = null;
                break;
        }
        Mesh m1 = (Mesh)Mesh.Instantiate(mf1.mesh);
        MeshFilter mf2 = (MeshFilter)GameObject.Find("/" + this.gameObject.name + "/stopSign_cube_01").GetComponent("MeshFilter");
        mf2.mesh = m1;
        //All signs MUST have different names in the hierarchy view, or else this will just apply to the first one in the list
        print(GameObject.Find("/" + this.gameObject.name + "/stopSign_cube_01").renderer.material);
        GameObject.Find("/" + this.gameObject.name + "/stopSign_cube_01").renderer.material.mainTexture = newTexture;

    }
}
