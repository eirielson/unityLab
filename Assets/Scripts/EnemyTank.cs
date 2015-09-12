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
		Fire ();
		RotateCannon();
		Move ();
	}

	void RotateCannon(){
		Debug.DrawLine (m_transform.position, Player.transform.position, Color.cyan);

		Vector3 lookPosition = Player.transform.position - CannonBase.position;
		lookPosition.y = 0;

		Quaternion rotation = Quaternion.LookRotation (lookPosition);
		CannonBase.transform.rotation = Quaternion.Slerp (rotation,CannonBase.transform.rotation, Time.deltaTime * 2.0f);
	}

	void SetCoolDown ()
	{
		CoolDown = Random.Range (0, MaxCoolDownTime);
	}

	void Move(){
		Vector3 pos = Player.transform.position - CannonBase.position;
		pos.y = 0;
		Quaternion rotation = Quaternion.LookRotation (pos);
		m_transform.rotation = Quaternion.Slerp (m_transform.rotation, rotation, Time.deltaTime * 1.0f);

		float distance = Vector3.Distance (m_transform.position, Player.transform.position);

		if (distance > 30) {
			m_transform.position += m_transform.forward * MoveSpeed * Time.deltaTime;
			}
	}

	void Fire(){
		return;
		CoolDown -= Time.deltaTime;
		if (CoolDown > 0)
			return;

		GameObject go = (GameObject)GameObject.Instantiate (ProjectTile, ProjectRef.position, ProjectRef.rotation);
		go.rigidbody.velocity = ProjectRef.up * ProjectTileSpeed;
		SetCoolDown ();
	}
}
