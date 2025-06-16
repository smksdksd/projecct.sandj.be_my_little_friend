using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [Header("Animal Stats")]
    public string animalName = "멍멍이";
    public string story = "비 오는 날 상자 안에서 발견됨";
    public string personality = "사람을 약간 경계함";
    [Range(0, 100)] public float hunger = 80f;
    [Range(0, 100)] public float cleanliness = 70f;
    [Range(0, 100)] public float affection = 50f;

    [Header("Decay Rates (per second)")]
    public float hungerDecayRate = 0.5f;
    public float cleanlinessDecayRate = 0.2f;

    public static event System.Action OnStatsChanged;

    void Update()
    {
        hunger -= hungerDecayRate * Time.deltaTime;
        cleanliness -= cleanlinessDecayRate * Time.deltaTime;

        hunger = Mathf.Clamp(hunger, 0, 100);
        cleanliness = Mathf.Clamp(cleanliness, 0, 100);

        if (Time.frameCount % 10 == 0)
        {
            OnStatsChanged?.Invoke();
        }
    }

    public void Feed(float amount)
    {
        hunger += amount;
        affection += 5f;
        hunger = Mathf.Clamp(hunger, 0, 100);
        OnStatsChanged?.Invoke();
    }

    public void Clean(float amount)
    {
        cleanliness += amount;
        affection += 2f;
        cleanliness = Mathf.Clamp(cleanliness, 0, 100);
        OnStatsChanged?.Invoke();
    }

    public void Pet()
    {
        affection += 10f;
        affection = Mathf.Clamp(affection, 0, 100);
        OnStatsChanged?.Invoke();
    }

    public bool CanBeAdopted(float affectionThreshold)
    {
        return affection >= affectionThreshold && hunger > 60 && cleanliness > 60;
    }
}