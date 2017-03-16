using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {
	public UnityEngine.UI.Text MoneyAmount;
	public UnityEngine.UI.Text HPAmount;
	public UnityEngine.UI.Text WeaponsAmount;
	public UnityEngine.UI.Text KeyAmount;
	public int[] items = {0,0,1,0};
	public Slider curHP;

	// Use this for initialization
	void Start () {
		this.MoneyAmount.text = items[0] + "";
		this.HPAmount.text = items[1] + "";
		this.WeaponsAmount.text = "1";
		this.KeyAmount.text = items[3] + "";
	}
	
	// Update is called once per frame
	void Update () {
		//inventoryText.GetComponent<GUIText>().text = "Money " + "[" + items[0] + "]" + "\n" + "Health Potion " 
		//	+ "[" + items[1] + "]" + "\n" + "Weapon " + "[" + items[2] + "]";

		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			removeItem (1, 1);
			//add hp to player
		}

	}

	public void addItem(int item, int amount){
		if(item == 0){
			items[0] += amount;
			this.MoneyAmount.text = items[0] + "";
		}
		else if(item == 1){
			items[1]++;
			this.HPAmount.text = items[1] + "";
		}
		else if(item == 2){
			items[2]++;
			this.WeaponsAmount.text = items[2] + "";
		}
		else if(item == 3){
			items[3]++;
			this.KeyAmount.text = items[3] + "";
		}
	}

	public bool removeItem(int itemToRemove, int amount){
		if (itemToRemove == 0) {
			if (items [0] >= amount) {
				items [0] -= amount;
				this.MoneyAmount.text = items [0] + "";
				return true;
			}
		} else if (itemToRemove == 1) {
			if (items [1] > 0) {
				items [1]--;
				this.HPAmount.text = items [1] + "";
				curHP.value += 10;
				return true;
			}
		} else if (itemToRemove == 2) {
			if (items [2] > 0) {
				items [2]--;
				this.WeaponsAmount.text = items[2] + "";
				return true;
			}
		} else if (itemToRemove == 3) {
			if (items [3] > 0) {
				items [3]--;
				this.KeyAmount.text = items[3] + "";
				return true;
			}
		}
		return false;
	}
}
