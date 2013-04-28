using UnityEngine;
using System.Collections;

public class GUISigns : MonoBehaviour {

    public Sign selectedSign;

    private bool GUIenabled = false;
    
	// Use this for initialization
	void Start () {
        //GUIenabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnGUI()
    {
        GUI.enabled = GUIenabled;
        var stopButton = GUI.Button(new Rect(900, 10, 100, 25), "STOP");
        var leftButton = GUI.Button(new Rect(900, 40, 100, 25), "One way (left)");
        var rightButton = GUI.Button(new Rect(900, 70, 100, 25), "One way (right)");
        var speed15Button = GUI.Button(new Rect(900, 100, 100, 25), "Speed Limit(15)");
        var speed30Button = GUI.Button(new Rect(900, 130, 100, 25), "Speed Limit(30)");
        var removeButton = GUI.Button(new Rect(900, 160, 100, 25), "Remove Sign");

        GUI.enabled = false;
        if (stopButton)
        {
            selectedSign.updateSignType(SignType.Stop);
        }

        if (leftButton)
        {
            selectedSign.updateSignType(SignType.OneWayLeft);
        }

        if (rightButton)
        {
            selectedSign.updateSignType(SignType.OneWayRight);
        }

        if (speed15Button)
        {
            selectedSign.updateSignType(SignType.Speed15);
        }

        if (speed30Button)
        {
            selectedSign.updateSignType(SignType.Speed30);
        }

        if (removeButton)
        {
            selectedSign.updateSignType(SignType.None);
        }
    }

    public void updateSignReference(Sign sign)
    {
        selectedSign = sign;
        GUIenabled = true;
    }
}
