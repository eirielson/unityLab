using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{

	int initialLife = 100;
	int initialArmor = 200;
	int initialSpeed = 1;
	int initialWeaponDamage = 10;
	public int str = 10;
	public int cons = 10;
	public int agi = 10;

	public int life { get; set; }

	public int armor {
		get;
		set;
	}

	public int weaponDamage {
		get;
		set;
	}

	public int speed {
		get;
		set;
	}

	// Use this for initialization
	void Start ()
	{
		life = initialLife * cons;
		speed = initialSpeed * agi;
		weaponDamage = initialWeaponDamage * str;
	}


	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ApplyDamage(int dmg){
		int partialDamage = 0;

		Debug.Log ("Dagame");

		if (armor > 0) {
			if (dmg > armor) {
				partialDamage = dmg - armor;
				armor = 0;
			}
			else{
				armor -= dmg;
			}
			life -= partialDamage;
		} else {
			life -= dmg;
		}

		if (life <= 0) {
			if(gameObject.tag == "Enemy"){
				Debug.Log("Enemy Die");
			}
		}
	}

}
