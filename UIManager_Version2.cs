using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Text animalNameText;
    public Text storyText;
    public Text personalityText;
    public Slider hungerSlider;
    public Slider cleanlinessSlider;
    public Slider affectionSlider;

    public Text goldText;
    public Text adopterInfoText;

    private AnimalController targetAnimal;
    private int gold = 0;

    void OnEnable()
    {
        AnimalController.OnStatsChanged += UpdateUI;
    }

    void OnDisable()
    {
        AnimalController.OnStatsChanged -= UpdateUI;
    }

    public void SetTargetAnimal(AnimalController animal)
    {
        targetAnimal = animal;
        UpdateUI();
    }

    public void SetGold(int amount)
    {
        gold = amount;
        if (goldText != null)
            goldText.text = "Gold: " + gold.ToString();
    }

    public void SetAdopterInfo(Adopter adopter)
    {
        if (adopterInfoText != null && adopter != null)
        {
            adopterInfoText.text = $"희망자: {adopter.name}\n설명: {adopter.description}\n필요 애정도: {adopter.preferredAffection}";
        }
        else if(adopterInfoText != null)
        {
            adopterInfoText.text = "";
        }
    }

    void UpdateUI()
    {
        if (targetAnimal != null)
        {
            animalNameText.text = targetAnimal.animalName;
            storyText.text = targetAnimal.story;
            personalityText.text = targetAnimal.personality;
            hungerSlider.value = targetAnimal.hunger / 100f;
            cleanlinessSlider.value = targetAnimal.cleanliness / 100f;
            affectionSlider.value = targetAnimal.affection / 100f;
        }
    }
}