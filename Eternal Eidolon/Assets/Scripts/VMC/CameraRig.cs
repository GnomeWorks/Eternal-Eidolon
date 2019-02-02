using UnityEngine;
using System.Collections;
public class CameraRig : MonoBehaviour 
{
	public float speed = 3f;
	public Transform follow;
	Transform _transform;

	Vector3 targetVec;
	Quaternion targetRot;
	Quaternion originRot;
	
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
		{
			targetVec = _transform.eulerAngles;
			targetVec.y += 90f;

			originRot = _transform.rotation;
			targetRot = _transform.rotation;
			targetRot.y += 90f;

			rotatingMapQ = true;
		}
		else if(Input.GetKeyDown(KeyCode.E) && !rotatingMapQ && !rotatingMapE /*&& curLerpTime == 0f*/)
		{
			targetVec = _transform.eulerAngles;
			targetVec.y -= 90f;

			originRot = _transform.rotation;
			targetRot = _transform.rotation;
			targetRot.y -= 90f;

			rotatingMapE = true;
		}
		else if (follow)
			_transform.position = Vector3.Lerp(_transform.position, follow.position, speed * Time.deltaTime);

		if(rotatingMapQ || rotatingMapE)
		{
			Vector3 newAngle = _transform.eulerAngles;

			if(rotatingMapQ)
				newAngle.y += speed;
			else if(rotatingMapE)
				newAngle.y -= speed;

			distRemain -= speed;

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