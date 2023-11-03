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
    private ScoreManager scoreManager; // Reference to the ScoreManager script

    // Start is called before the first frame update
    void Start()
    {
        previousAccelerometerReading = Input.acceleration;
        SelectWeapon();
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager.GetScore() == 0)
        {
            foreach (Transform weapon in transform)
            {
                weapon.gameObject.SetActive(false);
            }
            //    transform.GetChild(selectedWeapon).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 currentAccelerometerReading = Input.acceleration;
        int prevousSelected = selectedWeapon;

    
        if (scoreManager.GetScore() == 1 && canChangeWeapon && currentAccelerometerReading.x > 0.6)
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
                

            //UpdateWeaponVisibility();
        }


    }
    private void SelectWeapon()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        transform.GetChild(selectedWeapon).gameObject.SetActive(true);
        
    }
    private IEnumerator WeaponCooldown()
    {
        yield return new WaitForSeconds(selectionCooldown);
        canChangeWeapon = true;
    }
}
