using System;
using UnityEngine;
using UnityEngine.Events;

public class CoolGame : MonoBehaviour
{
	public CoolGame()
	{
	}

	private void Start()
	{
		this.TestEvent();
		this.TestGraphicsEvents();
		this.freecamCamera = new GameObject();
		this.freecamCamera.AddComponent<Camera>().enabled = false;
		this.freecamSpeed = 4f;
		this.freecamLook = 100f;
		this.freecamRotationX = 0f;
		this.freecamRotationY = 0f;
	}

	public void SetPlayed()
	{
		PlayerPrefs.SetInt("Played", 1);
	}

	public void TestEvent()
	{
		if (PlayerPrefs.GetInt("Played", 0) == 1)
		{
			this.SecondRun.Invoke();
		}
	}

	public void TestGraphicsEvents()
	{
		if (QualitySettings.GetQualityLevel() > 1)
		{
			this.GraphicalQualityHigh.Invoke();
			Debug.Log("High Quality");
			return;
		}
		this.GraphicalQualityLow.Invoke();
		Debug.Log("Low Quality");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F5))
		{
			this.freecamMode = !this.freecamMode;
			if (this.freecamMode)
			{
				this.freecamCamera.transform.position = Camera.main.gameObject.transform.position;
				this.freecamCamera.transform.eulerAngles = Camera.main.transform.eulerAngles;
				this.freecamMainCamera = Camera.main;
				Camera.main.enabled = false;
				this.freecamCamera.GetComponent<Camera>().enabled = true;
			}
			else
			{
				GameObject.Find("AdvancedPlayer").transform.position = this.freecamCamera.transform.position;
				this.freecamMainCamera.enabled = true;
				this.freecamCamera.GetComponent<Camera>().enabled = false;
			}
		}
		if (this.freecamMode)
		{
			float mouseX = Input.GetAxis("Mouse X") * this.freecamLook * Time.deltaTime;
			float mouseY = Input.GetAxis("Mouse Y") * this.freecamLook * Time.deltaTime;
			this.freecamRotationX -= mouseY;
			this.freecamRotationX = Mathf.Clamp(this.freecamRotationX, -90f, 90f);
			this.freecamRotationY += mouseX;
			this.freecamCamera.transform.rotation = Quaternion.Euler(this.freecamRotationX, this.freecamRotationY, 0f);
			Vector3 p_Velocity = default(Vector3);
			if (Input.GetKey(KeyCode.I))
			{
				p_Velocity += new Vector3(0f, 0f, 1f);
			}
			if (Input.GetKey(KeyCode.K))
			{
				p_Velocity += new Vector3(0f, 0f, -1f);
			}
			if (Input.GetKey(KeyCode.J))
			{
				p_Velocity += new Vector3(-1f, 0f, 0f);
			}
			if (Input.GetKey(KeyCode.L))
			{
				p_Velocity += new Vector3(1f, 0f, 0f);
			}
			if (Input.GetKey(KeyCode.U))
			{
				p_Velocity += new Vector3(0f, 1f, 0f);
			}
			if (Input.GetKey(KeyCode.O))
			{
				p_Velocity += new Vector3(0f, -1f, 0f);
			}
			p_Velocity = p_Velocity * Time.deltaTime * this.freecamSpeed;
			this.freecamCamera.transform.Translate(p_Velocity);
		}
	}

	public UnityEvent SecondRun;

	[Header("Graphics")]
	public int GraphicalBar = 1;

	public UnityEvent GraphicalQualityLow;

	public UnityEvent GraphicalQualityHigh;

	public bool freecamMode;

	public float freecamSpeed;

	public GameObject freecamCamera;

	public Camera freecamMainCamera;

	private float freecamLook;

	public float freecamRotationX;

	public float freecamRotationY;
}
