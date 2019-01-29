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
			_transform.eulerAngles = targetVec;
			rotatingMapQ = false;
			rotatingMapE = false;

			/*
			curLerpTime += Time.deltaTime;
			_transform.eulerAngles = Vector3.Lerp(_transform.eulerAngles, targetVec, curLerpTime / lerpTime);
			//_transform.rotation = Quaternion.Slerp(_transform.rotation, targetRot, curLerpTime / lerpTime);
			//_transform.rotation = Quaternion.Lerp(_transform.rotation, targetRot, curLerpTime / lerpTime);
			//_transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRot, speed * Time.deltaTime);

			//Debug.Log(_transform.eulerAngles.y + ", " + targetVec.y);

			if(curLerpTime >= lerpTime)
			{
				curLerpTime = 0f;
				rotatingMapQ = false;
				rotatingMapE = false;

				Debug.Log("friggin done spinning");
			}
			*/
		}
	}
}