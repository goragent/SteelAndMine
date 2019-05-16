﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script using for optimiztion all AI to finding each opposit
// in a few loop of FindGameObjectsWithTag call
// because FindGameObjectsWithTag eat too much perf if it call in every AI
// so we create this pool to collect all target. so all ai can finding their
// opposit in here.

namespace AirStrikeKit
{
	public class AIFinderPool : MonoBehaviour
	{
		public Dictionary<string,TargetCollector> TargetList = new Dictionary<string,TargetCollector> ();
		public int TargetTypeCount = 0;

		void Start ()
		{
			AirStrike.AIPool = this;
		}

		public TargetCollector FindTargetTag (string tag)
		{

			if (TargetList.ContainsKey (tag)) {
				TargetCollector targetcollector;
				if (TargetList.TryGetValue (tag, out targetcollector)) {
					targetcollector.IsActive = true;
					return targetcollector;
				} else {
					return null;
				}
			} else {
				TargetList.Add (tag, new TargetCollector (tag)); 
			}
			return null;
		}

		void Update ()
		{
			int count = 0;
			foreach (var target in TargetList) {
				if (target.Value != null) {
					if (target.Value.IsActive) {
						target.Value.SetTarget (target.Key);
						target.Value.IsActive = false;
						count += 1;
					}
				}
			}
			//Debug.Log ("finding count " + count);
			if(count > TargetTypeCount)
			TargetTypeCount = count;
		}
	}


	public static class AirStrike
	{
		public static AIFinderPool AIPool;
	}

	public class TargetCollector
	{
		public GameObject[] Targets;
		public bool IsActive;

		public TargetCollector (string tag)
		{
			SetTarget (tag);
		}

		public void SetTarget (string tag)
		{
			Targets = (GameObject[])GameObject.FindGameObjectsWithTag (tag);
		}

	}

}