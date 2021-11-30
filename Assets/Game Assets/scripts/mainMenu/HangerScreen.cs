using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31;

public class HangerScreen : MonoBehaviour {
	
	//Check Internet
	public bool m_isConnectedtoInternet = false;
	
	public GameObject ShoppingSubGUI;
	public GameObject StorePopUpGUI;
	
	// StoreKit Setup
	//private List<StoreKitProduct> _products;
	public bool sk_canMakePayments = false;
	public bool sk_purchase = false;
	public bool sk_transactionStatus = false;
	public bool sk_transactionInProgress = false;
	public bool sk_transactionFailed = false;
	public bool sk_transactionSucessful = false;
	public bool sk_transactionCancelled = false;
	public bool sk_transactionInProgressError = false;
	public string sk_product = string.Empty;
	public int sk_transactionProgressStatus = 0;
	public int sk_number = 0;
	public int sk_upgradeType = 0;

	// array of product ID's from iTunesConnect.  Will add more later....
	private string[] productIdentifiers = new string[] { "credits1", "credits2","credits4", "credits8", "credits16" };
		
	// Use this for initialization
	void Start () {
		//sk_canMakePayments = false;
		//InitializeStoreKit(); 
		//StorePopUpGUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		/*CheckNetworkConnection();
		
		if(m_isConnectedtoInternet)
		{
			ShoppingSubGUI.SetActive(StoreKitBinding.canMakePayments());
			sk_canMakePayments = StoreKitBinding.canMakePayments();
		}
		else
		{
			sk_canMakePayments = false;
			ShoppingSubGUI.SetActive(false);
		}    */
	}
	
	private void CheckNetworkConnection()
	{
		/*if (Application.internetReachability == NetworkReachability.NotReachable)
   		{
        	m_isConnectedtoInternet = false;
   		}
		else
		{
			m_isConnectedtoInternet = true;
		}*/
	}
	
	// StoreKit Test
	private void InitializeStoreKit()
	{
		// you cannot make any purchases until you have retrieved the products from the server with the requestProductData method
		// we will store the products locally so that we will know what is purchaseable and when we can purchase the products
		/*StoreKitBinding.requestProductData( productIdentifiers );
		sk_canMakePayments = StoreKitBinding.canMakePayments(); */
	}
	
	public void OnShopBuy1()
	{
		OnShopBuy(1);
	}
	
	public void OnShopBuy2()
	{
		OnShopBuy(2);
	}
	
	public void OnShopBuy3()
	{
		OnShopBuy(3);
	}
	
	public void OnShopBuy4()
	{
		OnShopBuy(4);
	}
	
	public void OnShopBuy5()
	{
		OnShopBuy(5);
	}
	
	private void OnShopBuy(int purchase)
	{
		sk_upgradeType = purchase;
		if (!sk_canMakePayments)
		{
			Debug.LogError("Cannot Make Payment");
		}
		else
		{
			if(!sk_transactionInProgress)
			{
				OnShopBuyItem(purchase - 1);	
			}
			else
			{
				sk_transactionInProgressError = true;
			}
		}
	}
	
	public void OnTransactionSwipe()
	{
		sk_transactionInProgress = false;
		sk_transactionInProgressError = false;
	}
	
	private void OnShopBuyItem(int itemNr)
	{
		/*var product = _products[itemNr];
		sk_transactionInProgress = true;
		Debug.Log( "preparing to purchase product: " + product.productIdentifier );
		StoreKitBinding.purchaseProduct( product.productIdentifier, 1 );    */
	}
	
	private void OnValidateReciept()
	{
		//List<StoreKitTransaction> transactionList = StoreKitBinding.getAllSavedTransactions();
	}
	
	public void UnloadHangerScreen()
	{
		MainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
		if(GameObject.Find("HangerScreen")) 
		{
			GameObject SScreenGO = GameObject.Find("HangerScreen");
			Destroy(SScreenGO);
		}
		if(GameObject.Find("PlayButtonGUI")) 
		{
			GameObject playButton = GameObject.Find("PlayButtonGUI");
			playButton.SetActive(true);
		}
		
		if(GameObject.Find("TitleGUI")) 
		{
			GameObject titleGUIMM = GameObject.Find("TitleGUI");
			titleGUIMM.transform.localPosition = new Vector3(-120.0f, 280.0f, 0.0f);
		}
		
		if(GameObject.Find("MissionObjectivesGUI")) 
		{
			GameObject missobjGUIMM = GameObject.Find("MissionObjectivesGUI");
			missobjGUIMM.transform.localPosition = new Vector3(100.0f, 160.0f, 0.0f);
		}
		
		if(GameObject.Find("PlayButtonGUI")) 
		{
			GameObject playButton = GameObject.Find("PlayButtonGUI");
			playButton.transform.localPosition = new Vector3(187.5f, -285.0f, 0.0f);
		}
		
		if(GameObject.Find("SettingsButton")) 
		{
			GameObject menuButtonA = GameObject.Find("SettingsButton");
			menuButtonA.transform.localPosition = new Vector3(200.0f, -150.0f, 0.0f);
		}
		
		if(GameObject.Find("ProfileButton")) 
		{
			GameObject menuButtonB = GameObject.Find("ProfileButton");
			menuButtonB.transform.localPosition = new Vector3(200.0f, -90.0f, 0.0f);
		}
		
		if(GameObject.Find("AboutButton")) 
		{
			GameObject menuButtonB = GameObject.Find("AboutButton");
			menuButtonB.transform.localPosition = new Vector3(200.0f, 30.0f, 0.0f);
		}
		
		if(GameObject.Find("HangerButton")) 
		{
			GameObject menuButtonC = GameObject.Find("HangerButton");
			menuButtonC.transform.localPosition = new Vector3(200.0f, -30.0f, 0.0f);
		}
		grGlobals.reanimateMenu = true;
		grGlobals.reanimateMissionObj = true;
	}
	
	public void SetShieldType()
	{

	}
}
