using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    public int starCost;

    private StarsDisplay starsDisplay;
    

    // Use this for initialization
    void Start()
    {
        starsDisplay = GameObject.FindObjectOfType<StarsDisplay>();
    }

    public void AddStars(int amount)
    {
        starsDisplay.AddStars(amount);
    }

    public int getStarValue()
    {
        return starCost;
    }


}
