using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_AxisSineWave : MonoBehaviour
{
	[SerializeField] private float speed = 3;
	[SerializeField] private float magnitude = 3;
	void Update()
    {
		transform.localEulerAngles = new Vector3(0, 0, Mathf.Sin(Time.time * speed) * magnitude);
	}
}
