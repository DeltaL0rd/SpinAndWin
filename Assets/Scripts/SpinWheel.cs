using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpinWheel : MonoBehaviour
{
	public List<int> prize;
	public List<AnimationCurve> animationCurves;
	
	private bool spinning;	
	private float anglePerItem;	
	private int randomTime;
	private int itemNumber;
	private bool hitSpin = false;
	public Text winText;
	void Start(){
		spinning = false;
		anglePerItem = 360/prize.Count;		
	}

	public void StartSpin()
	{
		hitSpin = true;
	}
	
	void  Update ()
	{
		if (hitSpin && !spinning) {
		
			randomTime = Random.Range (1, 4);
			itemNumber = Random.Range (0, prize.Count);
			float maxAngle = 360 * randomTime + (itemNumber * anglePerItem);
			
			StartCoroutine (SpinTheWheel (5 * randomTime, maxAngle));
			hitSpin = false;
		}
	}
	
	IEnumerator SpinTheWheel (float time, float maxAngle)
	{
		spinning = true;
		
		float timer = 0.0f;		
		float startAngle = transform.eulerAngles.z;		
		maxAngle = maxAngle - startAngle;
		
		int animationCurveNumber = Random.Range (0, animationCurves.Count);

		while (timer < time) {
			float angle = maxAngle * animationCurves [animationCurveNumber].Evaluate (timer / time) ;
			transform.eulerAngles = new Vector3 (0.0f, 0.0f, angle + startAngle);
			timer += Time.deltaTime;
			yield return 0;
		}
		
		transform.eulerAngles = new Vector3 (0.0f, 0.0f, maxAngle + startAngle);
		spinning = false;
			
		Debug.Log ("Prize: " + prize [itemNumber]);//use prize[itemNumnber] as per requirement
		switch (prize[itemNumber])
		{
			case 110:
				winText.text = "Player 1 Won";
				break;
			case 70:
				winText.text = "Player 2 Won";
				break;
			case 20:
				winText.text = "Player 3 Won";
				break;
			case 50:
				winText.text = "Player 4 Won";
				break;
			case 10:
				winText.text = "Player 5 Won";
				break;
			case 40:
				winText.text = "Player 6 Won";
				break;
			case 100:
				winText.text = "Player 7 Won";
				break;
			case 60:
				winText.text = "Player 8 Won";
				break;
			default:
				winText.text = "NO Player Won";
				break;
		}
	}	
}
