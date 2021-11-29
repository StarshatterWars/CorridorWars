using UnityEngine;
using System.Collections;

public class csMissionLoading : MonoBehaviour {
	public GameObject warpEffectPrefab;
	public GameObject warpGatePrefab;
	
	public GameObject shipPrefab;
	//public GameObject missionPrefab;
	
	private float waitTime;
	public GameObject[] ship;
	private int shipNumber = 6;
	public Vector3[] shipLocation; 
	public float[] shipSpeed;
		
	// Use this for initialization
	IEnumerator Start () {
		
		////MakeStarfieldEffect();
		//MakeWarpGateEffect();
		for (int i = 0; i < shipNumber; i++)
		{
			MakeShip(i);
		}
		yield return new WaitForSeconds(5);
		Application.LoadLevelAsync("RangerWars");
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Make the camera follow the player (if active)
		csSmoothFollowTrans sF = (csSmoothFollowTrans)Camera.main.GetComponent(typeof(csSmoothFollowTrans));
		sF.target = ship[0].transform;		
	}
	
	private void MakeWarpGateEffect()
	{
		GameObject warpgate = (GameObject) Instantiate (warpGatePrefab, transform.position, Quaternion.identity);
		warpgate.transform.name = "warpgate";
	}
	
	private void MakeStarfieldEffect()
	{
		GameObject warp = (GameObject) Instantiate (warpEffectPrefab, transform.position, Quaternion.identity);
		warp.transform.name = "warpfield";
	}
	
	/*private void MakeMissionLoadingBar()
	{
		GameObject mlGUI = (GameObject) Instantiate (missionPrefab, transform.position, Quaternion.identity);
		mlGUI.transform.name = "missionLoading";
	}*/
	
	private void MakeShip(int shipNumber)
	{
		ship[shipNumber] = (GameObject) Instantiate (shipPrefab, shipLocation[shipNumber], Quaternion.identity);
		ship[shipNumber].transform.localScale = new Vector3(0.0075f, 0.0075f, 0.0075f);
		ship[shipNumber].transform.name = (shipNumber + 1).ToString();
	}
}
