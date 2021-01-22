using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip doubleJumpSFX;
    [SerializeField] AudioClip gameOverHitSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip landSFX;
    [SerializeField] AudioClip powerupDoubleJumpSFX;
    [SerializeField] AudioClip powerupShieldSFX;
    [SerializeField] AudioClip shieldBreakSFX;

    public void PlaySFX(string clipToPlay)
    {
        switch(clipToPlay)
        {
            case "Coin":
                audioSource.clip = coinSFX;
                break;
            case "Jump":
                audioSource.clip = jumpSFX;
                break;
            case "DoubleJump":
                audioSource.clip = doubleJumpSFX;
                break;
            case "Land":
                audioSource.clip = landSFX;
                break;
            case "PowerupDoubleJump":
                audioSource.clip = powerupDoubleJumpSFX;
                break;
            case "PowerupShield":
                audioSource.clip = powerupShieldSFX;
                break;
            case "GameOverHit":
                audioSource.clip = gameOverHitSFX;
                break;
            case "ShieldBreak":
                audioSource.clip = shieldBreakSFX;
                break;
        }

        /*if(clipToPlay == "Coin")
        {
            audioSource.clip = coinSFX;
        }

        if (clipToPlay == "DoubleJump")
        {
            audioSource.clip = doubleJumpSFX;
        }

        if (clipToPlay == "GameOverHit")
        {
            audioSource.clip = gameOverHitSFX;
        }

        if (clipToPlay == "Jump")
        {
            audioSource.clip = jumpSFX;
        }

        if (clipToPlay == "Land")
        {
            audioSource.clip = landSFX;
        }

        if (clipToPlay == "PowerupDoubleJump")
        {
            audioSource.clip = powerupDoubleJumpSFX;
        }

        if (clipToPlay == "PowerupShield")
        {
            audioSource.clip = powerupShieldSFX;
        }

        if (clipToPlay == "ShieldBreak")
        {
            audioSource.clip = shieldBreakSFX;
        }*/

        audioSource.Play();
    }

}
