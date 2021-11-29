using UnityEngine;
using System.Collections;

public class csTransactionStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		UILabel transactionStatus = this.gameObject.GetComponent<UILabel>();
		transactionStatus.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		UILabel transactionStatus = this.gameObject.GetComponent<UILabel>();
		
		csHangerScreen grGlobals = GameObject.Find("HangerScreen").GetComponent<csHangerScreen>();	
		if(grGlobals != null)
		{
			if(grGlobals.sk_canMakePayments)
			{
				if(grGlobals.sk_transactionInProgress)
				{
					transactionStatus.color = Color.white;
					transactionStatus.text = "Transaction in Progress";
				}	
				else if(grGlobals.sk_transactionSucessful)
				{
					transactionStatus.color = Color.green;
					transactionStatus.text = "Transaction Sucessful";
				}
				else if(grGlobals.sk_transactionCancelled)
				{
					transactionStatus.color = Color.yellow;
					transactionStatus.text = "Transaction Cancelled";
				}
				else if(grGlobals.sk_transactionFailed)
				{
					transactionStatus.text = "Transaction Declined";
					transactionStatus.color = Color.red;
				}
				else if(grGlobals.sk_transactionInProgressError)
				{
					transactionStatus.color = Color.red;
					transactionStatus.text = "Transacton Already in Progress";
				}
				else
				{
					transactionStatus.color = Color.white;
					transactionStatus.text = "Shop Available";
				}
			}
			else
			{
				transactionStatus.text = "Cannot Make Payments";
				transactionStatus.color = Color.red;
			}
		}
	}
}
