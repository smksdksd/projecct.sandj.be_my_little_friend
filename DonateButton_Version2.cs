using UnityEngine;

public class DonateButton : MonoBehaviour
{
    public string donationUrl = "https://www.animalrescuefund.org/donate";

    public void OnClickDonate()
    {
        Application.OpenURL(donationUrl);
    }
}