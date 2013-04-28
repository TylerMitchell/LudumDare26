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

        switch (type)
        {
            case SignType.OneWayLeft:
                break;
        }
        Mesh m1 = (Mesh)Mesh.Instantiate(mf1.mesh);
        mf2.mesh = m1;

    }
}
