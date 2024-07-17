using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasDisplay : MonoBehaviour
{
	//Initialise Variable
    public TextMeshProUGUI textmesh;
    // Start is called before the first frame update
    void Start()
    {
		//Reference through GetComponent
        textmesh = GetComponentInChildren<TextMeshProUGUI>();
    }
}
