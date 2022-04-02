using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
	private int counter = 5;
	private float timePassed = 0f;
	public Button addBtn;
	public Button subBtn;
	public Button resetBtn;
	public Button pauseBtn;
	public TMPro.TextMeshProUGUI countdownLabel;
	private TMPro.TextMeshProUGUI toggleButtonText;
	private bool isTimerPlaying = true;

	// Start is called before the first frame update
	void Start()
	{
		addBtn.onClick.AddListener(addCounter);
		subBtn.onClick.AddListener(subtractCounter);
		resetBtn.onClick.AddListener(resetTimer);
		pauseBtn.onClick.AddListener(toggleTimer);
		toggleButtonText = pauseBtn.gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		if (isTimerPlaying) { timePassed += Time.deltaTime; }

		if (timePassed > 1f && counter > 0)
		{
			subtractCounter();
		}
	}

	void toggleTimer()
	{
		if (isTimerPlaying)
		{
			isTimerPlaying = false;
			toggleButtonText.SetText("Continue");
		}
		else
		{
			isTimerPlaying = true;
			toggleButtonText.SetText("Pause");
		}
	}

	void setCounter(int num)
	{
		counter = num;
		timePassed = 0;
		countdownLabel.SetText(counter.ToString());

	}

	void resetTimer() => setCounter(5);


	void incrementDecrementCounter(int num)
	{
		counter += num;
		timePassed = 0;
		countdownLabel.SetText(counter.ToString());
	}

	void addCounter() => incrementDecrementCounter(1);
	void subtractCounter() => incrementDecrementCounter(-1);
}

