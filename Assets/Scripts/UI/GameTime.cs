using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameTime : MonoBehaviour
{
    [SerializeField] private float levelTimeInSeconds = 10;
    [SerializeField] private float timeAfterWin = 3;
    [SerializeField] private AudioClip victorySound;
    private int numberOfAttackers;
    private bool endTime;
    private bool IsDone;
    
    void Update()
    {
        LevelTimeCounter();
        LastAttackersTracker();
        Victroy();
    }

    private void LevelTimeCounter()
    {
        
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimeInSeconds;
        endTime = (Time.timeSinceLevelLoad > levelTimeInSeconds);
        if (endTime)
        {
            Destroy(FindObjectOfType<AttackerSpawner>());
            

        }
    }
    void LastAttackersTracker()
    { 
        
        numberOfAttackers = FindObjectsOfType<Attacker>().Length;
        
        
    }

    void Victroy()
    {
        if (IsDone) {return;}
        if (endTime  && numberOfAttackers <= 0)
        {
            StartCoroutine(VictoryProcess());
            IsDone = true;
        }
    }
    IEnumerator VictoryProcess()
    {
        VictorySFX();
        FindObjectOfType<GameFinishCanvas>().WinLabelOn();
        yield return new WaitForSeconds(timeAfterWin);
        FindObjectOfType<LevelLoader>().LoadVictoryScene();
    }

    private void VictorySFX()
    {
        
        FindObjectOfType<MenuMusicScript>().StopMusic();
        AudioSource.PlayClipAtPoint(victorySound, Camera.main.transform.position);
    }
}