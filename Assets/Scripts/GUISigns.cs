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
        var stopButton = GUI.Button(new Rect(900, 10, 110, 25), "STOP");
        var northButton = GUI.Button(new Rect(900, 40, 110, 25), "One way (north)");
        var southButton = GUI.Button(new Rect(900, 70, 110, 25), "One way (south)");
        var eastButton = GUI.Button(new Rect(900, 100, 110, 25), "One way (east)");
        var westButton = GUI.Button(new Rect(900, 130, 110, 25), "One way (west)");
        var speed15Button = GUI.Button(new Rect(900, 160, 110, 25), "Speed Limit(15)");
        var speed30Button = GUI.Button(new Rect(900, 190, 110, 25), "Speed Limit(30)");
        var removeButton = GUI.Button(new Rect(900, 220, 110, 25), "Remove Sign");

        if (stopButton)
        {
            selectedSign.updateSignType(SignType.Stop); 
        }

        if (selectedSign.pathNodeRef.north == null) { GUI.enabled = false; } else { GUI.enabled = true; }
        if (northButton)
        {
            selectedSign.updateSignType(SignType.OneWayNorth);
        }
        if (selectedSign.pathNodeRef.south == null) { GUI.enabled = false; } else { GUI.enabled = true; }
        if (southButton)
        {
            selectedSign.updateSignType(SignType.OneWaySouth);
        }
        if (selectedSign.pathNodeRef.east == null) { GUI.enabled = false; } else { GUI.enabled = true; }
        if (eastButton)
        {
            selectedSign.updateSignType(SignType.OneWayEast);
        }
        if (selectedSign.pathNodeRef.west == null) { GUI.enabled = false; } else { GUI.enabled = true; }
        if (westButton)
        {
            selectedSign.updateSignType(SignType.OneWayWest);
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
