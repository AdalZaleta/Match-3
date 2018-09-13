using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItem : MonoBehaviour {

	public int Element;

	void Awake()
	{
		Element = Random.Range(0,3);
	}
}
