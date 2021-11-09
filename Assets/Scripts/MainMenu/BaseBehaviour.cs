using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseBehaviour : MonoBehaviour
{
	public Coroutine Invoke(Action action, float time)
	{
		return StartCoroutine(InvokeAfterTime(action, time));
	}

	private IEnumerator InvokeAfterTime(Action action, float time)
	{
		yield return new WaitForSeconds(time);

		action?.Invoke();
	}
}