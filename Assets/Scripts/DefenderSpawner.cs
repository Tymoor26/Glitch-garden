using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
    public Camera myCamera;
    private GameObject defenderParent;
    private StarsDisplay starsDisplay;

    void Start()
    {
        starsDisplay = GameObject.FindObjectOfType<StarsDisplay>();
        defenderParent = GameObject.Find("Defenders");

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        Vector2 clickedPoint = SnapToGrid(CalculateWorldPointOfMouseClick());
        print(clickedPoint);
        if (Button.selectedDefender)
        {
            GameObject defender = Button.selectedDefender;
            int starValue = defender.GetComponent<Defender>().getStarValue();
            if (starsDisplay.CheckIfCanSpendStars(starValue))
            {
                Quaternion zeroRot = Quaternion.identity;
                GameObject newDef = Instantiate(defender, clickedPoint, zeroRot) as GameObject;
                newDef.transform.parent = defenderParent.transform;
                starsDisplay.UseStars(starValue);
            }
        }
    }

    Vector2 SnapToGrid (Vector2 rawWorldPos)
    {
        float newX = Mathf.Round(rawWorldPos.x);
        float newY = Mathf.Round(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    }
}
