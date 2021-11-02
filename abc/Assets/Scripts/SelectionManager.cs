using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

	int numHanger = 0;
	public GameObject kimDongHo_1_Dai;

	public GameObject kimDongHo_1_Ngan;

	public GameObject kimDongHo_2_Dai;

	public GameObject kimDongHo_2_Ngan;

	//sai so(degree)
	public float saiSo = 10f;

	public float heSoTangGocHienThi = 2f;

	public float heSoChuyenDoiDonVi = 1f;

	public GameObject tayDon_1;
	public float gocXoayTayDon_1 = 0.5f;

	public GameObject tayDon_2;
	public float gocXoayTayDon_2 = 0.5f;

	public GameObject tayDon_3;
	public float gocXoayTayDon_3 = 0.2f;


	public GameObject tayDon_4;
	public float gocXoayTayDon_4 = 0.1f;


	//Chuyen Vi Day Treo
	public GameObject dayTreo_1;

	public GameObject dayTreo_2;

	public GameObject kim_1;

	public GameObject kim_2;


	//Bien Do sai so goc xoay



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
			selectionRenderer.material = defaultMaterial;
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
					selectionRenderer.material = highlightMaterial;
					if (Input.GetMouseButtonDown (2)) {
						print (selectionRenderer.transform.position.y.ToString ());
						if (selectionRenderer.transform.position.y > 0.6f && selectionRenderer.transform.position.y < 1.1f) {
							
							selectionRenderer.transform.position += new Vector3 (0, -0.40f, 0);
							numHanger++;
							print (numHanger);


							//Xoay tay Don;
							tayDon_1.transform.Rotate (new Vector3 (gocXoayTayDon_1*heSoTangGocHienThi, 0, 0));
							tayDon_2.transform.Rotate (new Vector3 (gocXoayTayDon_2*heSoTangGocHienThi, 0, 0));
							tayDon_3.transform.Rotate (new Vector3 (gocXoayTayDon_3*heSoTangGocHienThi, 0, 0));
							tayDon_4.transform.Rotate (new Vector3 (gocXoayTayDon_4*heSoTangGocHienThi, 0, 0));

							//Chuyen Vi phuong Y
							dayTreo_1.transform.position+= new Vector3(0, calV(tayDon_1, dayTreo_1,gocXoayTayDon_1)*heSoTangGocHienThi,0);
							dayTreo_2.transform.position+= new Vector3(0, calV(tayDon_2, dayTreo_2,gocXoayTayDon_2)*heSoTangGocHienThi,0);

							kim_1.transform.position+= new Vector3(0, calV(tayDon_3,kim_1 ,gocXoayTayDon_3)*heSoTangGocHienThi,0);

							kim_2.transform.position+= new Vector3(0, calV(tayDon_4, kim_2,gocXoayTayDon_4)*heSoTangGocHienThi,0);


							//Hien thi Kim Dong Ho
//							kimDongHo_1_Dai.transform.Rotate (new Vector3 (0, 0, 30));
//							kimDongHo_1_Ngan.transform.Rotate (new Vector3 (0, 0, 5));
//
//							kimDongHo_2_Dai.transform.Rotate (new Vector3 (0, 0, 20));
//							kimDongHo_2_Ngan.transform.Rotate (new Vector3 (0, 0, 3));
							float gocXoayDongHo_1_Dai = 1f*calV(tayDon_3,kim_1 ,gocXoayTayDon_3)*heSoChuyenDoiDonVi*360f+Random.Range(-1*saiSo, saiSo);
							kimDongHo_1_Dai.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_1_Dai));
							kimDongHo_1_Ngan.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_1_Dai/10));
								
							float gocXoayDongHo_2_Dai = 1f*calV(tayDon_4,kim_2 ,gocXoayTayDon_4)*heSoChuyenDoiDonVi*360f+Random.Range(-1*saiSo, saiSo);
							kimDongHo_2_Dai.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_2_Dai));
							kimDongHo_2_Ngan.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_2_Dai/10));



						}
						else
						{
							selectionRenderer.transform.position += new Vector3 (0, +0.90f, 0);
							numHanger--;


							//Xoay tay Don;
							tayDon_1.transform.Rotate (new Vector3 (-1*gocXoayTayDon_1*heSoTangGocHienThi, 0, 0));
							tayDon_2.transform.Rotate (new Vector3 (-1*gocXoayTayDon_2*heSoTangGocHienThi, 0, 0));
							tayDon_3.transform.Rotate (new Vector3 (-1*gocXoayTayDon_3*heSoTangGocHienThi, 0, 0));
							tayDon_4.transform.Rotate (new Vector3 (-1*gocXoayTayDon_4*heSoTangGocHienThi, 0, 0));


							//Chuyen Vi phuong Y
							dayTreo_1.transform.position+= new Vector3(0, -1*calV(tayDon_1, dayTreo_1,gocXoayTayDon_1)*heSoTangGocHienThi,0);
							dayTreo_2.transform.position+= new Vector3(0, -1*calV(tayDon_2, dayTreo_2,gocXoayTayDon_2)*heSoTangGocHienThi,0);
							kim_1.transform.position+= new Vector3(0, -1*calV(tayDon_3, kim_1,gocXoayTayDon_3)*heSoTangGocHienThi,0);
							kim_2.transform.position+= new Vector3(0, -1*calV(tayDon_4, kim_2,gocXoayTayDon_4)*heSoTangGocHienThi,0);



//							kimDongHo_1_Dai.transform.Rotate (new Vector3 (0, 0, -1*3.6f*gocXoayTayDon_3+Random.Range(-1*saiSo, saiSo)));
//							kimDongHo_1_Ngan.transform.Rotate (new Vector3 (0, 0, -1*0.36f*gocXoayTayDon_3+Random.Range(-1*saiSo, saiSo)));
//
//							kimDongHo_2_Dai.transform.Rotate (new Vector3 (0, 0, -1*3.6f*gocXoayTayDon_4+Random.Range(-1*saiSo, saiSo)));
//							kimDongHo_2_Ngan.transform.Rotate (new Vector3 (0, 0, -1*0.36f*gocXoayTayDon_4+Random.Range(-1*saiSo, saiSo)));

							float gocXoayDongHo_1_Dai = -1f*calV(tayDon_3,kim_1 ,gocXoayTayDon_3)*heSoChuyenDoiDonVi*360f+Random.Range(-1*saiSo, saiSo);
							kimDongHo_1_Dai.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_1_Dai));
							kimDongHo_1_Ngan.transform.Rotate (new Vector3 (0, 0, gocXoayDongHo_1_Dai/10));

							float gocXoayDongHo_2_Dai = -1f*calV(tayDon_4,kim_2 ,gocXoayTayDon_4)*heSoChuyenDoiDonVi*360f+Random.Range(-1*saiSo, saiSo);
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
