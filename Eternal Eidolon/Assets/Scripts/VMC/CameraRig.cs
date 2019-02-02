using UnityEngine;
using System.Collections;
public class CameraRig : MonoBehaviour 
{
	public float speed = 3f;
	public Transform follow;
	Transform _transform;

	Vector3 targetVec;
	
	//float lerpTime = .5f;
	//float curLerpTime = 0f;
	bool rotatingMapQ = false;
	bool rotatingMapE = false;
	float distRemain = 90f;

	void Awake ()
	{
		_transform = transform;
	}
	
	void Update ()
	{
		// want to handle camera rotation... looking to use "q" and "e" for this, for now

		if(Input.GetKeyDown(KeyCode.Q) && !rotatingMapQ && !rotatingMapE /*&& curLerpTime == 0f*/)
			rotatingMapQ = true;
		else if(Input.GetKeyDown(KeyCode.E) && !rotatingMapQ && !rotatingMapE /*&& curLerpTime == 0f*/)
			rotatingMapE = true;
		else if (follow)
			_transform.position = Vector3.Lerp(_transform.position, follow.position, speed * Time.deltaTime);

		if(rotatingMapQ || rotatingMapE)
		{
			Vector3 newAngle = _transform.eulerAngles;

			if(rotatingMapQ)
				newAngle.y += 3f;
			else if(rotatingMapE)
				newAngle.y -= 3f;

			distRemain -= 3f;

			_transform.eulerAngles = newAngle;

			if(distRemain <= 0f)
			{
				rotatingMapQ = false;
				rotatingMapE = false;
				distRemain = 90f;
			}
		}
	}
}