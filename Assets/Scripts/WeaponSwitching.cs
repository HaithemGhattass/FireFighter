 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    private Vector3 previousAccelerometerReading; // Store the previous accelerometer reading
    private float selectionCooldown = 1.0f; // 1 second cooldown
    private bool canChangeWeapon = true;
    public ScoreManager scoreManager; // Reference to the ScoreManager script
    public CrosshairManager crosshairManager;
    // Start is called before the first frame update
    void Start()
    {
        previousAccelerometerReading = Input.acceleration;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        scoreManager = FindObjectOfType<ScoreManager>();
        crosshairManager = FindObjectOfType<CrosshairManager>(); // Find the CrosshairManager script

    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 currentAccelerometerReading = Input.acceleration;
        int prevousSelected = selectedWeapon;
       


        if (scoreManager.GetScore() > 0 && canChangeWeapon && currentAccelerometerReading.x > 0.6)
        {
            // Phone has rotated beyond the threshold, switch weapons
            previousAccelerometerReading = currentAccelerometerReading;
            

            if (selectedWeapon == 0)
            {
                selectedWeapon = 1;
            }
            else
            {
                selectedWeapon = 0;
            }
            if (prevousSelected != selectedWeapon)
            {
                SelectWeapon();
                canChangeWeapon = false;
                StartCoroutine(WeaponCooldown());

            }
                

        }


    }
    private void SelectWeapon()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        if (scoreManager.GetScore() == 1)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(selectedWeapon).gameObject.SetActive(true);
        }

        crosshairManager.crosshair.SetActive(scoreManager.GetScore() > 0);

    }
    private IEnumerator WeaponCooldown()
    {
        yield return new WaitForSeconds(selectionCooldown);
        canChangeWeapon = true;
    }
}
