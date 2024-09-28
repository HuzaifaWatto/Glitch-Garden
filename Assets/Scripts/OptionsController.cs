using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FYP
{
    public class OptionsController : MonoBehaviour
    {
        [SerializeField] Slider volumeSlider;
        [SerializeField] float defaultVolume = 0.08f;

        [SerializeField] Slider difficultySlider;
        [SerializeField] float defaultDifficulty = 0.08f;


        // Start is called before the first frame update
        void Start()
        {
            volumeSlider.value = PlayerPrefsController.GetMasterVolume();
            difficultySlider.value = PlayerPrefsController.GetDifficulty();


        }

        // Update is called once per frame
        void Update()
        {
            var musicPlayer = FindObjectOfType<MusicPlayer>();
            if (musicPlayer)
            {
                musicPlayer.SetVolume(volumeSlider.value);
            }
            else
            {
                Debug.Log("No music player found.. did u start from splash screen!");
            }

        }
        public void SaveAndExit()
        {
            PlayerPrefsController.SetMasterVolume(volumeSlider.value);
            PlayerPrefsController.SetDifficulty(difficultySlider.value);


            FindObjectOfType<LevelLoader>().LoadMainMenu();
        }

        public void SetDefaults()
        {
            volumeSlider.value = defaultVolume;
            difficultySlider.value = defaultDifficulty;


        }
    }
}