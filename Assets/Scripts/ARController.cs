using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public GameObject gun;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public GameObject spawnerObject;
    static public float floorHeight;

    public enum GameState { Setup, InGame};
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Setup;
        floorHeight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Setup)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();

                Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
                raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                if (hits.Count > 0) //hit a plane
                {
                    //Floor height setup done
                    floorHeight = hits[0].pose.position.y;

                    //hides all planes and stops creating more
                    planeManager.enabled = false;
                    foreach (var plane in planeManager.trackables)
                    {
                        plane.gameObject.SetActive(false);
                    }

                    //enemies now spawn and state of game changes
                    spawnerObject.SetActive(true);
                    gameState = GameState.InGame;
                    gun.SetActive(true);
                }
            }
        }
    }
}
