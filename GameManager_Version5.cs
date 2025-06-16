using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<AnimalController> animals;
    public UIManager uiManager;

    public List<Adopter> adopters; // 입양 희망자 리스트
    private int currentAnimalIndex = 0;
    private int gold = 100;
    private int currentAdopterIndex = 0;

    [Header("후원 링크")]
    public string donationUrl = "https://www.animalrescuefund.org/donate";

    void Start()
    {
        if (animals.Count > 0 && uiManager != null)
        {
            uiManager.SetTargetAnimal(animals[currentAnimalIndex]);
            uiManager.SetGold(gold);

            if(adopters.Count > 0)
                uiManager.SetAdopterInfo(adopters[currentAdopterIndex]);
        }
    }

    public void NextAnimal()
    {
        if (animals.Count == 0) return;
        currentAnimalIndex = (currentAnimalIndex + 1) % animals.Count;
        uiManager.SetTargetAnimal(animals[currentAnimalIndex]);
    }

    public void PrevAnimal()
    {
        if (animals.Count == 0) return;
        currentAnimalIndex = (currentAnimalIndex - 1 + animals.Count) % animals.Count;
        uiManager.SetTargetAnimal(animals[currentAnimalIndex]);
    }

    public void OnFeedButtonClicked()
    {
        if (animals.Count > 0)
            animals[currentAnimalIndex].Feed(25f);
    }
    public void OnCleanButtonClicked()
    {
        if (animals.Count > 0)
            animals[currentAnimalIndex].Clean(40f);
    }
    public void OnPetButtonClicked()
    {
        if (animals.Count > 0)
            animals[currentAnimalIndex].Pet();
    }

    // --- 입양 관련 ---
    public void NextAdopter()
    {
        if (adopters.Count == 0) return;
        currentAdopterIndex = (currentAdopterIndex + 1) % adopters.Count;
        uiManager.SetAdopterInfo(adopters[currentAdopterIndex]);
    }

    public void PrevAdopter()
    {
        if (adopters.Count == 0) return;
        currentAdopterIndex = (currentAdopterIndex - 1 + adopters.Count) % adopters.Count;
        uiManager.SetAdopterInfo(adopters[currentAdopterIndex]);
    }

    public void OnAdoptButtonClicked()
    {
        if (animals.Count == 0 || adopters.Count == 0) return;

        var animal = animals[currentAnimalIndex];
        var adopter = adopters[currentAdopterIndex];

        if (animal.CanBeAdopted(adopter.preferredAffection))
        {
            gold += 50; // 입양 성공 보상
            uiManager.SetGold(gold);

            animals.RemoveAt(currentAnimalIndex);
            if (animals.Count == 0)
            {
                uiManager.SetTargetAnimal(null);
                return;
            }
            currentAnimalIndex %= animals.Count;
            uiManager.SetTargetAnimal(animals[currentAnimalIndex]);
            Debug.Log($"{animal.animalName}이(가) {adopter.name}에게 입양되었습니다!");
        }
        else
        {
            Debug.Log("입양 조건 미달입니다.");
        }
    }

    // --- 업그레이드 ---
    public void OnUpgradeShelterButtonClicked()
    {
        int upgradeCost = 100;
        if (gold >= upgradeCost)
        {
            gold -= upgradeCost;
            uiManager.SetGold(gold);
            // 업그레이드 효과 예시: 동물 수 증가 가능, 등
            Debug.Log("보호소 업그레이드 완료!");
        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }

    // --- 후원 ---
    public void OnDonateButtonClicked()
    {
        Application.OpenURL(donationUrl);
    }
}