using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetFlash : MonoBehaviour {

    Image Flash;

    void Start()
    {
       Flash = gameObject.GetComponent<Image>();
    }

	public void FlashColour()
    {
        Color temp = Flash.color;
        temp.a = 0.5f;
        Flash.color = temp;
    }

    public void Reset()
    {
        Color temp = Flash.color;
        temp.a = 0;
        Flash.color = temp;
    }
	
	
}
