using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitController : MonoBehaviour
{
    public SpriteRenderer SR;
    public AudioSource AS;

    //public Sprite Player; 
    //public Sprite MysteryGirl;
    //public Sprite Madscientist;

    public GameObject Player;
    public GameObject MysteryGirl;
    public GameObject MadScientist;
    public GameObject Albert;
    public GameObject Waitress1;
    public GameObject Waitress2;
    public GameObject Bodyguard;
    public GameObject Willy;
    public GameObject Rob;
    public GameObject Sofaria;

    public AudioClip PlayerClip;
    public AudioClip MysteryGirlClip;
    public AudioClip MadScientistClip; // test
    public AudioClip textClip;
    public AudioClip AlbertClip;
    public AudioClip Waitress1Clip;
    public AudioClip Waitress2Clip;
    public AudioClip BodyguardClip;
    public AudioClip WillyClip;
    public AudioClip RobClip;
    
    public void Imprint(DialogueLine dl)
    {
        Player.SetActive(false);
        MysteryGirl.SetActive(false);
        MadScientist.SetActive(false);
        Albert.SetActive(false);
        Waitress1.SetActive(false);
        Waitress2.SetActive(false);
        Bodyguard.SetActive(false);
        Willy.SetActive(false);
        Rob.SetActive(false);
        Sofaria.SetActive(false);

        if (dl.Who == Characters.Player)
            Player.SetActive(true);
        if (dl.Who == Characters.MysteryGirl)
            MysteryGirl.SetActive(true);
        if (dl.Who == Characters.Madscientist)
            MadScientist.SetActive(true);
        if (dl.Who == Characters.Albert)
            Albert.SetActive(true);
        if (dl.Who == Characters.Waitress1)
            Waitress1.SetActive(true);
        if (dl.Who == Characters.Waitress2)
            Waitress2.SetActive(true);
        if (dl.Who == Characters.Bodyguard)
            Bodyguard.SetActive(true);
        if (dl.Who == Characters.Willy)
            Willy.SetActive(true);
        if (dl.Who == Characters.Rob)
            Rob.SetActive(true);
        if (dl.Who == Characters.Sofaria)
            Sofaria.SetActive(true);
    }

    public void PlayVoice(DialogueLine dl)
    {
        // Skip if AudioSource component is not set
        if(AS == null && AS.isPlaying)
        {
            return;
        }

        AS.volume = 1;

        // Check if AudioClip is not null and play AudioClip and play it for current speaker
        if (dl.Who == Characters.Player && PlayerClip != null)
            AS.PlayOneShot(PlayerClip);
        if ((dl.Who == Characters.MysteryGirl || dl.Who == Characters.Sofaria) && MysteryGirlClip != null)
            AS.PlayOneShot(MysteryGirlClip);
        if (dl.Who == Characters.Madscientist && MadScientistClip != null)
            AS.PlayOneShot(MadScientistClip);
        if (dl.Who == Characters.Albert && AlbertClip != null)
            AS.PlayOneShot(AlbertClip);
        if (dl.Who == Characters.Waitress1 && Waitress1Clip != null)
            AS.PlayOneShot(Waitress1Clip);
        if (dl.Who == Characters.Waitress2 && Waitress2Clip != null)
            AS.PlayOneShot(Waitress2Clip);
        if (dl.Who == Characters.Bodyguard && BodyguardClip != null)
            AS.PlayOneShot(BodyguardClip);
        if (dl.Who == Characters.Willy && WillyClip != null)
            AS.PlayOneShot(WillyClip);
        if (dl.Who == Characters.Rob && RobClip != null)
            AS.PlayOneShot(RobClip);
        if (dl.Who == Characters.None && textClip != null)
        {
            AS.volume = .3f;
            AS.PlayOneShot(textClip);
        }
    }
}
