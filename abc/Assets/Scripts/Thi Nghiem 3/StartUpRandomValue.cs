using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpRandomValue : MonoBehaviour {
	public GameObject kimDaiDongHo_1;
	public GameObject kimNganDongHo_1;
	public GameObject kimDaiDongHo_2;
	public GameObject kimNganDongHo_2;



	// Use this for initialization
	void Start () {
		float randomGocXoayDongHo_1 = Random.Range (-1800, 0);
		float randomGocXoayDongHo_2 = Random.Range (-1800, 0);
		kimDaiDongHo_1.transform.Rotate (new Vector3 (0, 0, randomGocXoayDongHo_1));
		kimNganDongHo_1.transform.Rotate (new Vector3 (0, 0, randomGocXoayDongHo_1/10));

		kimDaiDongHo_2.transform.Rotate (new Vector3 (0, 0, randomGocXoayDongHo_2));
		kimNganDongHo_2.transform.Rotate (new Vector3 (0, 0, randomGocXoayDongHo_2/10));

	}

}
