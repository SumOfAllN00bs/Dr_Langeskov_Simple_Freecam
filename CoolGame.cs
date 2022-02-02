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
		this.freecamSpeed = 5f;
		this.freecamLook = 150f;
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
		// Toggle the freecam
		if (Input.GetKeyDown(KeyCode.F5))
		{
			this.freecamMode = !this.freecamMode;
			if (this.freecamMode)
			{
				this.freecamCamera.transform.position = Camera.main.gameObject.transform.position;
				this.freecamCamera.transform.eulerAngles = Camera.main.gameObject.transform.eulerAngles;
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
		// Enable all the rooms
		if (Input.GetKeyDown(KeyCode.F6))
		{
			foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
			{
				if (gameObject.name.Contains("ITS THE"))
				{
					gameObject.SetActive(true);
				}
			}
		}
		if (this.freecamMode)
		{
			float num = Input.GetAxis("Mouse X") * this.freecamLook * Time.deltaTime;
			float num2 = Input.GetAxis("Mouse Y") * this.freecamLook * Time.deltaTime;
			this.freecamRotationX -= num2;
			this.freecamRotationX = Mathf.Clamp(this.freecamRotationX, -90f, 90f);
			this.freecamRotationY += num;
			this.freecamCamera.transform.rotation = Quaternion.Euler(this.freecamRotationX, this.freecamRotationY, 0f);
			Vector3 vector = default(Vector3);
			if (Input.GetKey(KeyCode.I))
			{
				vector += new Vector3(0f, 0f, 1f);
			}
			if (Input.GetKey(KeyCode.K))
			{
				vector += new Vector3(0f, 0f, -1f);
			}
			if (Input.GetKey(KeyCode.J))
			{
				vector += new Vector3(-1f, 0f, 0f);
			}
			if (Input.GetKey(KeyCode.L))
			{
				vector += new Vector3(1f, 0f, 0f);
			}
			if (Input.GetKey(KeyCode.U))
			{
				vector += new Vector3(0f, 1f, 0f);
			}
			if (Input.GetKey(KeyCode.O))
			{
				vector += new Vector3(0f, -1f, 0f);
			}
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				vector = vector * Time.deltaTime * this.freecamSpeed * 3f;
			}
			else
			{
				vector = vector * Time.deltaTime * this.freecamSpeed;
			}
			this.freecamCamera.transform.Translate(vector);
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
