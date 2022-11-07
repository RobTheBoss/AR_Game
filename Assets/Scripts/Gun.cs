using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public ARController controller;
    public TextMeshProUGUI ammoText;
    public Animator anim;

    public int damage;
    public float reloadTime;
    public int totalAmmo;
    private int ammo;
    private bool reloading;

    // Start is called before the first frame update
    void Start()
    {
        ammo = totalAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo <= 0)
        {
            if (!reloading)
            {
                anim.SetTrigger("Reload");
                reloading = true;
            }
            Invoke("ReloadGun", reloadTime);
            return;
        }

        //tapped the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began
                || Input.GetMouseButtonDown(0))
        {
            ammo--;
            ammoText.text = "Ammo: " + ammo.ToString();

            Debug.DrawLine(Camera.main.transform.position,
                Camera.main.transform.position + (Camera.main.transform.forward * 30), Color.red, 5.0f);
            anim.SetTrigger("Shoot");

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                }
                else if (hit.transform.gameObject.CompareTag("EnemyProjectile"))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    void ReloadGun()
    {
        CancelInvoke();
        ammo = totalAmmo;
        reloading = false;
        ammoText.text = "Ammo: " + ammo.ToString();
    }
}
