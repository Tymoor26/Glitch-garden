using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

    public LevelManager levelManager;
    public int timeOfLevel;
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private GameObject winLabel;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        slider.value = 0;
        audioSource = GetComponent<AudioSource>();
        winLabel = GameObject.Find("Win Text");
        if (!winLabel) { Debug.LogWarning("Create you win label"); }
        winLabel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        slider.value = Time.timeSinceLevelLoad / timeOfLevel;
        if(Time.timeSinceLevelLoad > timeOfLevel && !isEndOfLevel)
        {
            isEndOfLevel = true;
            GameObject loseCollider = GameObject.Find("Lose Collider");
            loseCollider.SetActive(false);
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);     
        }
	}

    void LoadNextLevel()
    {
        levelManager.LoadLevel("03a Win");
    }
}
