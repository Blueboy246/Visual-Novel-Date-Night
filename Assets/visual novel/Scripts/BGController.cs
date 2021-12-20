using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    public SpriteRenderer SR;
    public AudioSource AS;

    public Sprite Diner;
    public Sprite Explosion;
    public Sprite DestroyedDiner;
    public Sprite SpaceshipHallway;
    public Sprite SpaceshipPrisoncell;
    public Sprite SpaceshipGatedoor;
    public Sprite SpaceshipControlroom;
    public Sprite Grasslands;
    public Sprite StrangePlanet;
    public Sprite Ending2;
    public Sprite Ending3;
    public Sprite Ending4;
    public Sprite MemeImage;
    public Sprite BlackScreen;

    public AudioClip DinerMusic;
    public AudioClip SpaceshipHallwayMusic;
    public AudioClip Explosionclip;
    public AudioClip MadScientistThemesong;
    public AudioClip SpaceshipPrisoncellMusic;
    public AudioClip SpaceshipGatedoorMusic;
    public AudioClip SpaceshipControlroomMusic;
    public AudioClip GrasslandsMusic;
    public AudioClip StrangePlanetMusic;
    public AudioClip Ending2Music;
    public AudioClip Ending3Music;
    public AudioClip Ending4Music;
    public AudioClip BlackScreenClip;
    public void Imprint(DialogueLine dl)
    {
        if (dl.Where == Locations.Diner)
        {
            SR.sprite = Diner;
            AS.clip = DinerMusic;
            AS.Play();
        }
        if (dl.Where == Locations.SpaceshipHallway)
        {
            SR.sprite = SpaceshipHallway;
            AS.clip = SpaceshipHallwayMusic;
            AS.Play();
        }
        if (dl.Where == Locations.Explosion)
        {
            SR.sprite = Explosion;
            AS.clip = Explosionclip;
            AS.PlayOneShot(AS.clip);
        }
        if (dl.Where == Locations.DestroyedDiner)
        {
            SR.sprite = DestroyedDiner;
            AS.clip = MadScientistThemesong;
            AS.Play();
        }
        if (dl.Where == Locations.SpaceshipPrisoncell)
        {
            SR.sprite = SpaceshipPrisoncell;
            AS.clip = SpaceshipPrisoncellMusic;
            AS.Play();
        }
        if (dl.Where == Locations.SpaceshipGatedoor)
        {
            SR.sprite = SpaceshipGatedoor;
            AS.clip = SpaceshipGatedoorMusic;
            AS.Play();
        }
        if (dl.Where == Locations.SpaceshipControlroom)
        {
            SR.sprite = SpaceshipControlroom;
            AS.clip = SpaceshipControlroomMusic;
            AS.Play();
        }
        if (dl.Where == Locations.Grasslands)
        {
            SR.sprite = Grasslands;
            AS.clip = GrasslandsMusic;
            AS.Play();
        }
        if (dl.Where == Locations.StrangePlanet)
        {
            SR.sprite = StrangePlanet;
            AS.clip = StrangePlanetMusic;
            AS.Play();
        }
        if (dl.Where == Locations.Ending2)
        {
            SR.sprite = Ending2;
            AS.clip = Ending2Music;
            AS.Play();
        }
        if (dl.Where == Locations.Ending3)
        {
            SR.sprite = Ending3;
            AS.clip = Ending3Music;
            AS.Play();
        }
        if (dl.Where == Locations.Ending4)
        {
            SR.sprite = Ending4;
            AS.clip = Ending4Music;
            AS.Play();
        }
        if (dl.Where == Locations.BlackScreen)
        {
            SR.sprite = BlackScreen;
            AS.clip = BlackScreenClip;
            AS.PlayOneShot(AS.clip);
        }
        if (dl.Where == Locations.MemeImage)
        {
            SR.sprite = MemeImage;
        }
    }
}
