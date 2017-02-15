using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarsDisplay : MonoBehaviour {
    private Text text;
    private int stars;
    
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        stars = 500;
        text.text = stars.ToString() ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddStars(int amount)
    {
        print(stars + " stars added to display");
        stars += amount;
        text.text = stars.ToString();
    }

    public void UseStars(int cost)
    {
        stars -= cost;
        text.text = stars.ToString();
    }

    public bool CheckIfCanSpendStars(int cost){
        return stars - cost >= 0;
    }
}
