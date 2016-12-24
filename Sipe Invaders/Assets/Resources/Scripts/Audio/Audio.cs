using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    private static AudioSource instance;

	void Awake()
    {
        if (!instance)
            instance = gameObject.GetComponent<AudioSource>();
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject.GetComponent<AudioSource>());
    }
}
