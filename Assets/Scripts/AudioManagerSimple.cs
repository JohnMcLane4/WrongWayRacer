using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSimple : MonoBehaviour {

    public AudioSource gameMusic;    
    public AudioSource fsxAudio;
    public AudioSource carEngine;

    public static AudioManagerSimple instance = null;

    public float lowPitchRange = 0.9f;
    public float highPitchRange = 1.1f;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance != this)        
            Destroy(gameObject);
        

        DontDestroyOnLoad(gameObject);
    }

    public void PlayOnce(AudioClip clip)
    {
        fsxAudio.clip = clip;
        fsxAudio.Play();
    }    

    public void PlayOnDemand(params AudioClip [] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        fsxAudio.pitch = randomPitch;
        fsxAudio.clip = clips[randomIndex];
        fsxAudio.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
