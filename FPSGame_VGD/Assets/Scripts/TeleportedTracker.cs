using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportedTracker : MonoBehaviour {

    private bool m_Teleported;

    public bool Teleported
    {
        get
        {
            return m_Teleported;
        }

        set
        {
            m_Teleported = value;
        }
    }

    // Use this for initialization
    void Start () {
        m_Teleported = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
