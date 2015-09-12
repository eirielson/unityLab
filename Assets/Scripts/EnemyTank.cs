using UnityEngine;
using System.Collections;

public class EnemyTank : MonoBehaviour {

	private Transform m_transform;

	public GameObject Player;
	public GameObject ProjectTile;
	public Transform ProjectRef;
	public float ProjectTileSpeed = 50;
	public Transform CannonBase;
	
	public int MoveSpeed = 40;
	public int RotateSpeed = 70;
	public float CoolDown;

	public float MaxCoolDownTime = 5;


	void Start ()
	{
		m_transform = transform;
		Player = GameObject.FindGameObjectWithTag ("Player");
		SetCoolDown ();
	}
	
	void Update ()
	{
		CoolDown -= Time.deltaTime;
		if(CoolDown <=0)
				Fire ();

			RotateCannon();
	}

	void RotateCannon(){
		Debug.DrawLine (m_transform.position, Player.transform.position, Color.cyan);

		Vector3 lookPosition = Player.transform.position - CannonBase.transform.position;
		lookPosition.x = 0;

		Quaternion rotation = Quaternion.LookRotation (lookPosition);
		CannonBase.transform.rotation = Quaternion.Slerp (CannonBase.transform.rotation, rotation, Time.deltaTime * 2.0f);
	}

	void SetCoolDown ()
	{
		CoolDown = Random.Range (0, MaxCoolDownTime);
	}

	void Fire(){
			
			GameObject go = (GameObject)GameObject.Instantiate (ProjectTile, ProjectRef.position, ProjectRef.rotation);
			go.rigidbody.velocity = ProjectRef.up * ProjectTileSpeed;
		SetCoolDown ();
	}
}
