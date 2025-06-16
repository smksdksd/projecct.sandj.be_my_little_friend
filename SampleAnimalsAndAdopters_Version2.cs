using UnityEngine;
using System.Collections.Generic;

public class SampleAnimalsAndAdopters : MonoBehaviour
{
    public GameManager gameManager;

    void Awake()
    {
        // 샘플 동물 생성
        var animal1 = new GameObject("Coco").AddComponent<AnimalController>();
        animal1.animalName = "코코";
        animal1.story = "비 오는 날 상자 안에서 발견됨";
        animal1.personality = "사람을 약간 경계함";
        animal1.hunger = 80;
        animal1.cleanliness = 90;
        animal1.affection = 60;

        var animal2 = new GameObject("Nabi").AddComponent<AnimalController>();
        animal2.animalName = "나비";
        animal2.story = "공원 벤치 밑에서 구조";
        animal2.personality = "호기심 많고 장난꾸러기";
        animal2.hunger = 70;
        animal2.cleanliness = 80;
        animal2.affection = 40;

        gameManager.animals = new List<AnimalController> { animal1, animal2 };

        // 샘플 입양자 생성
        gameManager.adopters = new List<Adopter>
        {
            new Adopter("홍길동", "강아지를 키워본 경험이 많음", 60),
            new Adopter("김영희", "고양이를 좋아하는 대학생", 50)
        };
    }
}