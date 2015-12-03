using UnityEngine;
using System.Collections;

public class EasterMiniGame : MonoBehaviour {
	
	public int size = 4;
	public GameObject particles;
	
	int[,] cards;
	int prevRow;
	int prevCol;
	bool firstCard = true;
	int cardsRemoved = 0;
	
	// Use this for initialization
	void Start () {
		cards = new int[size,size];
		for(int i = 0; i < size; i = i+1)
			for(int j = 0; j < size; j = j + 2)
				cards[i,j] = cards[i,j+1] = Random.Range (0,4);
		
		for(int i = 0; i < size*size; i++)
		{
			int row1 = Random.Range(0,size);
			int row2 = Random.Range(0,size);
			int col1 = Random.Range(0,size);
			int col2 = Random.Range(0,size);
			
			int dummy = cards[row1,col1];
			cards[row1,col1] = cards[row2,col2];
			cards[row2,col2] = dummy;
		}
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.BeginGroup(new Rect(50,50,size*50,size*50));
		for(int i = 0; i < size; i = i+1)
			for(int j = 0; j < size; j = j + 1)
				if(cards[i,j] != -1)
				if(GUI.Button(new Rect(i*50,j*50,50,50), cards[i,j].ToString()))
				{
					if(firstCard) {prevRow = i; prevCol = j;}
					else if(cards[i,j] == cards[prevRow,prevCol] &&
						!(i == prevRow && j== prevCol)) 
						{ 
						cards[i,j] = cards[prevRow,prevCol] = -1;
						cardsRemoved += 2;
						}
					firstCard = !firstCard;
					if(cardsRemoved >= size*size)
					{
						Instantiate (particles,transform.position,transform.rotation);
						Destroy (this);
						Controller.score += size*size;
					}
				}
		GUI.EndGroup();
	
	}
}
