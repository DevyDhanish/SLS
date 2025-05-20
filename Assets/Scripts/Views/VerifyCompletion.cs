using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VerifyCompletion : MonoBehaviour, View
{
    public TextMeshProUGUI taskText;
    public TextMeshProUGUI variationText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI calorieText;
    public Button startStopButton;
    public TextMeshProUGUI buttonText;

    public int totalSeconds = 60;
    private float caloriesPerSecond = 0.12f;

    private Coroutine burnRoutine;
    private bool isRunning = false;
    private int timeLeft;
    private float calories;

    public void goBack()
    {
        UISystem.instance.goBack();
    }

    public void Disable()
    {
        if (burnRoutine != null) StopCoroutine(burnRoutine);
        gameObject.SetActive(false);
        isRunning = false;
        buttonText.text = "Start";
    }

    public void Enable()
    {
        Task curTask = TaskSystem.instance.getTaskById(TaskSystem.instance.currentActiveTaskId);
        taskText.text = curTask.description;
        variationText.text = curTask.variation;

        if (curTask.count >= 0) { totalSeconds = curTask.count; }

        gameObject.SetActive(true);

        timeLeft = totalSeconds;
        calories = 0f;
        UpdateUI();
        buttonText.text = "Start";
    }

    public void OnStartStopPressed()
    {
        if (!isRunning)
        {
            burnRoutine = StartCoroutine(BurnCaloriesCountdown());
            isRunning = true;
            buttonText.text = "Stop";
        }
        else
        {
            StopCoroutine(burnRoutine);
            isRunning = false;
            buttonText.text = "Start";
        }
    }

    private IEnumerator BurnCaloriesCountdown()
    {
        while (timeLeft > 0)
        {
            UpdateUI();
            yield return new WaitForSeconds(1f);
            timeLeft--;
            calories += caloriesPerSecond;
        }

        timeLeft = 0;
        UpdateUI();
        buttonText.text = "Start";
        isRunning = false;

        // do something on complete?
    }

    private void UpdateUI()
    {
        timeText.text = $"Time Left: {timeLeft}s";
        calorieText.text = $"Calories Burned: {calories:F2}";
    }
}
















// old code
//using TMPro;
//using UnityEngine;
//using System.Collections;

//public class VerifyCompletion : MonoBehaviour, View
//{
//    public TextMeshProUGUI taskText;
//    public TextMeshProUGUI variationText;
//    public TextMeshProUGUI timeText;
//    public TextMeshProUGUI calorieText;

//    public int totalSeconds = 60; // set default time for task
//    private float caloriesPerSecond = 0.12f; // tweak this for realism
//    private Coroutine burnRoutine;

//    public void goBack()
//    {
//        UISystem.instance.goBack();
//    }

//    public void Disable()
//    {
//        if (burnRoutine != null) StopCoroutine(burnRoutine);
//        gameObject.SetActive(false);
//    }

//    public void Enable()
//    {
//        Task curTask = TaskSystem.instance.getTaskById(TaskSystem.instance.currentActiveTaskId);
//        taskText.text = curTask.description;
//        variationText.text = curTask.variation;

//        if(curTask.count >= 0) { totalSeconds = curTask.count; }

//        gameObject.SetActive(true);

//        burnRoutine = StartCoroutine(BurnCaloriesCountdown(totalSeconds));
//    }

//    private IEnumerator BurnCaloriesCountdown(int seconds)
//    {
//        float calories = 0;
//        int timeLeft = seconds;

//        while (timeLeft > 0)
//        {
//            timeText.text = $"Time Left: {timeLeft}s";
//            calorieText.text = $"Calories Burned: {calories:F2}";

//            yield return new WaitForSeconds(1f);

//            timeLeft--;
//            calories += caloriesPerSecond;
//        }

//        timeText.text = $"Time Left: 0s";
//        calorieText.text = $"Calories Burned: {calories:F2}";

//        // do something on complete?
//    }
//}
