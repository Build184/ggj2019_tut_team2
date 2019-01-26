﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGunEffect : MonoBehaviour
{
	public LineRenderer ThunderPrefab;
	public GameObject TargetPoint;
	public float VertexPerLength;
	public float RandomRange;
	public float UpdateTime;

	float time_;
	LineRenderer[] thunders_;

    // Start is called before the first frame update
    void Start()
    {
		for( int i = 0; i < 2; ++i )
		{
			Instantiate(ThunderPrefab, this.transform);
		}
		thunders_ = GetComponentsInChildren<LineRenderer>();
	}

    // Update is called once per frame
    void Update()
	{
		time_ += Time.deltaTime;
		if( time_ > UpdateTime )
		{
			Vector3 direction = TargetPoint.transform.position - this.transform.position;
			float length = direction.magnitude;
			int numVertex = (int)(VertexPerLength * length);
			for( int i = 0; i < thunders_.Length; ++i )
			{
				thunders_[i].positionCount = numVertex;
				for( int pi = 0; pi < numVertex; ++pi )
				{
					Vector3 linePosition = direction * ((float)pi / (numVertex - 1));
					if( pi != 0 & pi != numVertex - 1 )
					{
						linePosition += Random.insideUnitSphere * RandomRange;
					}
					thunders_[i].SetPosition(pi, linePosition);
				}
			}
		}
	}
}