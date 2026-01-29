using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using SPACE_UTIL;

namespace SPACE_GAME
{
	public class DEBUG_ParticleLaunch : MonoBehaviour
	{
		[SerializeField] List<GameObject> OBJ_PARTICLE;
		[SerializeField] Button _launchButton;

		private void Start()
		{
			Debug.Log(C.method(this));
			// StopAllCoroutines();
			// this.StartCoroutine(STIMULATE());
			this._launchButton.onClick.AddListener(() =>
			{
				EnableNextObj();
			});
		}

		int currIndex = 0;
		void EnableNextObj()
		{
			foreach (GameObject obj in this.OBJ_PARTICLE)
				obj.SetActive(false);
			this.OBJ_PARTICLE[this.currIndex].SetActive(true);
			this.currIndex = (this.currIndex + 1) % this.OBJ_PARTICLE.Count;
		}

		IEnumerator STIMULATE()
		{
			while(true)
			{
				if(INPUT.M.InstantDown(0))
					EnableNextObj();
				yield return null;
			}

			yield return null;
		}
	} 
}
