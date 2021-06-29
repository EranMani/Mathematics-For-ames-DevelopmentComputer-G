﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject tank;
    public GameObject fuel;
    public Text tankPosition;
    public Text fuelPosition;
    public Text energyAmt;
    

    public void AddEnergy(string amt)
    {
        int n;
        if (int.TryParse(amt, out n))
        {
            energyAmt.text = amt;
        }
    }

    public void SetAngle(string amt)
    {
        float angleInput;
        if (float.TryParse(amt, out angleInput))
        {
            float angle = angleInput * Mathf.Deg2Rad;
            Coords rotateDirection = HolisticMath.Rotate(new Coords(tank.transform.up), angle, false);
            tank.transform.up = rotateDirection.ToVector();
        }
    }


    // Use this for initialization
    void Start () {
        tankPosition.text = tank.transform.position + "";
        fuelPosition.text = fuel.GetComponent<ObjectManager>().objPosition + "";
        fuel = GameObject.Find("fuel");
        AutoRotation();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void AutoRotation()
    {
        tank.transform.up = HolisticMath.LookAt2D(new Coords(fuel.transform.position),
                                                  new Coords(tank.transform.up),
                                                  new Coords(tank.transform.position)).ToVector();
    }
}
