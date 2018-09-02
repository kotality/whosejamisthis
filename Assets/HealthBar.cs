using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {
    public DamageReciever d;

	// Update is called once per frame
	void Update () {
       transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().fillAmount = (int)(d.currentHealth / d.maxHealth);
	}
}
