using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public GameObject testObject;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public GameObject spawnerObject;
    static public float floorHeight;

    private enum GameState { Setup, InGame};
    GameState gameState;

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
                if (hits.Count > 0) //pressed a plane
                {
                    //Floor height setup done
                    Instantiate(testObject, hits[0].pose.position, hits[0].pose.rotation);
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
                }
            }
        }

        else if (gameState == GameState.InGame)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began 
                || Input.GetMouseButtonDown(0))
            {
                Debug.DrawLine(Camera.main.transform.position, 
                    Camera.main.transform.position + (Camera.main.transform.forward * 30), Color.red, 5.0f);

                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
                {
                    if (hit.transform.gameObject.CompareTag("Enemy")
                        || hit.transform.gameObject.CompareTag("EnemyProjectile"))
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}
