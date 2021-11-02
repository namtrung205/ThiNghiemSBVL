using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMoreWeightMainFunc : MonoBehaviour {

	int numHanger = 0;
	public GameObject kimDongHo_1_Dai;

	public GameObject kimDongHo_1_Ngan;

	public GameObject kimDongHo_2_Dai;

	public GameObject kimDongHo_2_Ngan;

	//sai so(degree)
	public float saiSo = 10f;

	public float heSoTangGocHienThi = 2f;

	public float heSoChuyenDoiDonVi = 1f;

	// Animation
	public GameObject tayDon_1;
	public float gocXoayTayDon_1 = 0.5f;

	public GameObject dayTreo;



	private float calV(GameObject tayDon, GameObject kim, float gocXoay){
		float chieuDaiTayDon = (tayDon.transform.position.z - kim.transform.position.z);
		//		print ("Chieu Dai Tay Don mm: " + chieuDaiTayDon*heSoChuyenDoiDonVi);
		float v = gocXoay / (180f / Mathf.PI) * chieuDaiTayDon;
		return v;
	}


	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMaterial;
	[SerializeField] private string selectableTag = "Selectable";

	private Transform _selection;

	// Update is called once per frame
	void Update ()
	{

		if (_selection != null) {

			var selectionRenderer = _selection.GetComponent<Renderer> ();
//			selectionRenderer.material = defaultMaterial;
			_selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) 
		{
			var selection = hit.transform;

			if (selection.CompareTag (selectableTag)) 
			{
				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
//					selectionRenderer.material = highlightMaterial;
					if (Input.GetMouseButtonDown (2)) {
						print (selectionRenderer.transform.position.y.ToString ());
						if (selectionRenderer.transform.position.y > 0.5f && selectionRenderer.transform.position.y < 1.0f) {

							selectionRenderer.transform.position += new Vector3 (0, -0.40f, 0);
							numHanger++;
							print (numHanger);

							//Xoay tay Don;
							tayDon_1.transform.Rotate (new Vector3 (0,gocXoayTayDon_1*heSoTangGocHienThi,0));
							//Tut day Treo
							dayTreo.transform.position = new Vector3 (dayTreo.transform.position.x,
								dayTreo.transform.position.y + 0.0003f,
								dayTreo.transform.position.z);



							float gocXoayDongHo_1_Dai = 50.06f+Random.Range(-1*saiSo, saiSo);

							kimDongHo_1_Dai.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_1_Dai));
							kimDongHo_1_Ngan.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_1_Dai/10));

//							float gocXoayDongHo_2_Dai = 1f*calV(tayDon_4,kim_2 ,gocXoayTayDon_4)*heSoChuyenDoiDonVi*360f+Random.Range(-1*saiSo, saiSo);

							float gocXoayDongHo_2_Dai = 97.2f+Random.Range(-1*saiSo, saiSo);
							kimDongHo_2_Dai.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_2_Dai));
							kimDongHo_2_Ngan.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_2_Dai/10));

						}
						else
						{
							selectionRenderer.transform.position += new Vector3 (0, +0.80f, 0);
							numHanger--;


							//Xoay tay Don;
							tayDon_1.transform.Rotate (new Vector3 (0,-gocXoayTayDon_1*heSoTangGocHienThi,0));
							//Ha Day Treo
							dayTreo.transform.position = new Vector3 (dayTreo.transform.position.x,
								dayTreo.transform.position.y - 0.0003f,
								dayTreo.transform.position.z);


							float gocXoayDongHo_1_Dai = -50.06f+Random.Range(-1*saiSo, saiSo);
							kimDongHo_1_Dai.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_1_Dai));
							kimDongHo_1_Ngan.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_1_Dai/10));


							float gocXoayDongHo_2_Dai = -97.2f+Random.Range(-1*saiSo, saiSo);
							kimDongHo_2_Dai.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_2_Dai));
							kimDongHo_2_Ngan.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_2_Dai/10));
						}
					}
				}

				_selection = selection;
			}
		}	
	}


}
