using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Dictionary<int,DialogueLine> Dialogue = new Dictionary<int, DialogueLine>();
    public DialogueLine Current;
    public DialogueBoxController DBox;
    public PortraitController Portrait;
    public BGController BG;

    //How many letters we're showing at a moment
    public int CurrentText = 0;
    //Our timer system
    private float Timer;
    public float MaxTimer = 0.1f;
    bool finishedAnimating = false;
    bool pressedSpace = false;

    public int[] EndingDialogueLines;

    public string TitleSceneName;

    private void Awake()
    {
        BuildScript();
        SetLine(1);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            pressedSpace = false;
        }

        if (Current.NextB > 0)
        {
            if (CurrentText >= Current.Text.Length && !finishedAnimating && Input.GetKeyDown(KeyCode.Space) && !pressedSpace)
            {
                CurrentText = Current.Text.Length;
                finishedAnimating = true;
                pressedSpace = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SetLine(Current.Next);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                SetLine(Current.NextB);
            if (Current.NextC > 0 && Input.GetKeyDown(KeyCode.Alpha3))
                SetLine(Current.NextC);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !pressedSpace)
            {
                pressedSpace = true;

                if (Array.IndexOf(EndingDialogueLines, Current.ID) > -1)
                {
                    SceneManager.LoadScene(TitleSceneName);
                }

                if (CurrentText >= Current.Text.Length && !finishedAnimating)
                {
                    CurrentText = Current.Text.Length;
                }
                else
                {
                    SetLine(Current.Next);
                }
            }
        }

        Timer += Time.deltaTime;
        //Every 0.1 seconds reveal a new letter
        if (Timer >= MaxTimer && !finishedAnimating)
        {
            Timer = 0;
            //Reveal one more letter
            CurrentText++;
            //Make sure we aren't going over the size of the text
            CurrentText = Mathf.Min(CurrentText, Current.Text.Length);
            //Set the shown text on the TextMesh
            DBox.Dialogue.text = Current.Text.Substring(0, CurrentText);

            if(CurrentText < Current.Text.Length)
            {
                Portrait.PlayVoice(Current);
            }
        }


        if (CurrentText >= Current.Text.Length && !finishedAnimating)
        {
            DBox.Imprint(Current);
            finishedAnimating = true;
        }
    }

    public void SetLine(int line)
    {
        Current = Dialogue[line];
        DBox.Imprint(Current);
        BG.Imprint(Current);
        Portrait.Imprint(Current);
        Debug.Log(Current.Text);
        CurrentText = 0;
        finishedAnimating = false;
    }

    void BuildScript()
    {
        /*Add(new DialogueLine(1,"Funny meeting you here",2,Characters.Player,Locations.Diner));
        Add(new DialogueLine(2,"I'm Goblin, a goblin",3));
        Add(new DialogueLine(3,"Want to hang out at the library?","Go to the library",4,"Don't",5));
        Add(new DialogueLine(4,"We are at the library",8,Characters.Player,Locations.SpaceshipHallway));
        Add(new DialogueLine(5,"Okay Bye",6));
        Add(new DialogueLine(6,"I'm Kobold",7,Characters.MysteryGirl));
        Add(new DialogueLine(7,"Let's dance",8));
        Add(new DialogueLine(8,"You Win",1,Characters.None));*/

        Add(new DialogueLine(1, "today was a tuesday on a starry night.", 2, Characters.None));
        Add(new DialogueLine(2, "You entered a restaurant that has enough room of a auditorium, fill with many riches and shiny objects", 3, Characters.None, Locations.Diner));
        Add(new DialogueLine(3, "It feels like you have entered to a place that you can't even afford.", 4, Characters.None));
        Add(new DialogueLine(4, "...", 5, Characters.Player));
        Add(new DialogueLine(5, "Luckly, someone has already paid for two seats.", 6, Characters.None));
        Add(new DialogueLine(6, "Your table was next to the glass window, where people on the sidewalk are strolling by.", 7, Characters.None));
        Add(new DialogueLine(7, "You sat on your chair figitly; looking at the opposite side of the table.", 8, Characters.None));
        Add(new DialogueLine(8, "The empty chair was standing right in front of your view.", 9, Characters.None));
        Add(new DialogueLine(9, "As time was moving forward, the looming presence of that chair was judging you.", 10, Characters.None));
        Add(new DialogueLine(10, "Suddenly, the door open and it so happens to be the person that you been waiting for.", 11, Characters.None));
        Add(new DialogueLine(11, "Today is the day.", 12, Characters.None));
        Add(new DialogueLine(12, "...", 13, Characters.MysteryGirl));
        Add(new DialogueLine(13, "So you're the person I'm supposed to meet?", 14, Characters.MysteryGirl));
        Add(new DialogueLine(14, "Well...the email was a little vague about your profile.", 15, Characters.Player));
        Add(new DialogueLine(15, "Also...it so happens that you were the only profile I can find on that website.", 16, Characters.Player));
        Add(new DialogueLine(16, "Yes. It was the only website I am aware of, since I rarley used the internet.", 17, Characters.MysteryGirl));
        Add(new DialogueLine(17, "And the only place I can find no disturbance.", 18, Characters.MysteryGirl));
        Add(new DialogueLine(18, "What?", 19, Characters.Player));
        Add(new DialogueLine(19, "Anyways, my time is short.", 20, Characters.MysteryGirl));
        Add(new DialogueLine(20, "So let's use this time very seriously.", 21, Characters.MysteryGirl));
        Add(new DialogueLine(21, "Ok...?", 22, Characters.Player));
        Add(new DialogueLine(22, "The lady sat right in front of you. Both you and the women's eyes are lock on with one another.", 23, Characters.None));
        Add(new DialogueLine(23, "You decided to asks one of these questions:", "Any relatives living in the city?", 24, "Is this has something to do with your job?", 28, Characters.None));
        Add(new DialogueLine(24, "No. Not really.", 25, Characters.MysteryGirl));
        Add(new DialogueLine(25, "My family lives far away from here, and we rarley talk to one another from time to time.", 26, Characters.MysteryGirl));
        Add(new DialogueLine(26, "But they are doing alright. Thank you for asking me that.", 27, Characters.MysteryGirl));
        Add(new DialogueLine(27, "The lady suspicion of you reduces, and was flattered by you asking about the state of her family.", 40, Characters.None));
        Add(new DialogueLine(28, "Why are you asking me that?", 29, Characters.MysteryGirl));
        Add(new DialogueLine(29, "Well, I thought that you feel stress out about something.", 30, Characters.Player));
        Add(new DialogueLine(30, "But do you have the right to look into my personal life?", 31, Characters.MysteryGirl));
        Add(new DialogueLine(31, "No...I didn't mean to-", 32, Characters.Player));
        Add(new DialogueLine(32, "My job as a whole is to inspect cities, like this one.", 33, Characters.MysteryGirl));
        Add(new DialogueLine(33, "To see if they are functioning the way that are supposed to.", 34, Characters.MysteryGirl));
        Add(new DialogueLine(34, "And if their is something out of line; something that doesn't fit in with the crowd...", 35, Characters.MysteryGirl));
        Add(new DialogueLine(35, "It is my job that I need to deal with it personally.", 36, Characters.MysteryGirl));
        Add(new DialogueLine(36, "...Sorry I asked.", 37, Characters.Player));
        Add(new DialogueLine(37, "No, it's fine. I got alittle passionate for a moment...", 38, Characters.MysteryGirl));
        Add(new DialogueLine(38, "You and the lady were slient for a few seconds after that discussion.", 39, Characters.None));
        Add(new DialogueLine(39, "This resulted her to be suspicious that you asked about that particular question.", 40, Characters.None));
        Add(new DialogueLine(40, "Anywho, let me ask you this.", 41, Characters.MysteryGirl));

        Add(new DialogueLine(41, "BOOOOOOOOOOOOM", 42, Characters.None, Locations.Explosion));
        Add(new DialogueLine(42, "AAAAHHAHAHAHAHAHAHAHAHAHA", 43, Characters.Madscientist, Locations.DestroyedDiner));
        Add(new DialogueLine(43, "So after all this time, you were hiding right here, Sofaria.", 44, Characters.Madscientist));
        Add(new DialogueLine(44, "How did you find me! I had removed all traces of my whereabouts?", 45, Characters.Sofaria));
        Add(new DialogueLine(45, "OF COURSE YOU DID!", 46, Characters.Madscientist));
        Add(new DialogueLine(46, "It took me quite some time to find you. But little did you know...", 47, Characters.Madscientist));
        Add(new DialogueLine(47, "IT WAS I WHO CREATED THE WEBSITE THAT YOU USED FOR THIS DATE!!!", 48, Characters.Madscientist));
        Add(new DialogueLine(48, "What!?", 49, Characters.Sofaria));
        Add(new DialogueLine(49, "OH, it was'nt hard. I just happen to hack into this internet, program a mere webpage,", 50, Characters.Madscientist));
        Add(new DialogueLine(50, "and wait patient, until you finally show yourself to me.", 51, Characters.Madscientist));
        Add(new DialogueLine(51, "Dammit!", 52, Characters.Sofaria));
        Add(new DialogueLine(52, "I figure that you would be smarter than this...", 53, Characters.Madscientist));
        Add(new DialogueLine(53, "BUT MAN! I'M SHOCKED THAT YOUR FOOLISH ENOUGH TO FALL FOR THAT!! ", 54, Characters.Madscientist));
        Add(new DialogueLine(54, "AANND... Quite lucky enough to bring yourself a boyfriend. ", 55, Characters.Madscientist));
        Add(new DialogueLine(55, "!!", 56, Characters.Player));
        Add(new DialogueLine(56, "The Mad Scientist, immediately walks towards you in a calm manner.", 57, Characters.None));
        Add(new DialogueLine(57, "His tall appearance looms over you, as he smiles with malice intent.", 58, Characters.None));
        Add(new DialogueLine(58, "Listen here boy and listen well... ", 59, Characters.Madscientist));
        Add(new DialogueLine(59, "This is between me and your blind date over here.", 60, Characters.Madscientist));
        Add(new DialogueLine(60, "You can either live another day, searching for that special someone again", 61, Characters.Madscientist));
        Add(new DialogueLine(61, "OR you can join in for the fun!", 62, Characters.Madscientist));
        Add(new DialogueLine(62, "What will it be?", "Run away?", 63, "Help Sofaria?", 67, Characters.Madscientist));
        Add(new DialogueLine(63, "sure.", 64, Characters.Player));
        Add(new DialogueLine(64, ".........", 65, Characters.Sofaria));
        Add(new DialogueLine(65, "GOOD CHOICE KID!! AAAHAHAHAHAHAHA!!!!", 66, Characters.Madscientist));
        Add(new DialogueLine(66, "ENDING 1: You leave Sofaria to deal with her problems, while you leave without a scratch.", 1, Characters.None, Locations.BlackScreen));
        Add(new DialogueLine(67, "...", 68, Characters.Player));
        Add(new DialogueLine(68, "No.", 69, Characters.Player));
        Add(new DialogueLine(69, "...!", 70, Characters.Sofaria));
        Add(new DialogueLine(70, "No?", 71, Characters.Madscientist));
        Add(new DialogueLine(71, "I'm sorry but...", 72, Characters.Player));
        Add(new DialogueLine(72, "The person that she's dating is me!", 73, Characters.Player));
        Add(new DialogueLine(73, "If you have a problem with her, then you have to talk to me first!", 74, Characters.Player));
        Add(new DialogueLine(74, "!", 75, Characters.Sofaria));
        Add(new DialogueLine(75, "...Wow. I'm actually impressed!", 76, Characters.Madscientist));
        Add(new DialogueLine(76, "When facing against a choice of life or death, you manage to stand your ground for her...", 77, Characters.Madscientist));
        Add(new DialogueLine(77, "Oh how bold of you...", 78, Characters.Madscientist));
        Add(new DialogueLine(78, "Hope you don't if you can stay alittle longer with me!", 79, Characters.Madscientist));
        Add(new DialogueLine(79, "Wha-", 80, Characters.Player));
        Add(new DialogueLine(80, " As you were about to complete a single word, you were instantly gutpushed by the mad scientist.", 81, Characters.None, Locations.BlackScreen));
        Add(new DialogueLine(81, "As your mind slowly shuts down, you can hear the voice of Sofaria calling out to you.", 82, Characters.None));
        Add(new DialogueLine(82, " You now see complete darkness.", 83, Characters.None));
        Add(new DialogueLine(83, "Seconds later, you gain consciouses.", 84, Characters.None, Locations.SpaceshipPrisoncell));
        Add(new DialogueLine(84, " As you got on your feet, you so happen to be in a neon room.", 85, Characters.None));
        Add(new DialogueLine(85, " The size of the room is like a prison cell for inmates, which techniqically that's what happening.", 86, Characters.None));
        Add(new DialogueLine(86, " In front of you are high fahenheit lazers that blocks your way to escape.", 87, Characters.None));
        Add(new DialogueLine(87, " The only thing you can do is wait for some miracle.", 88, Characters.None));
        Add(new DialogueLine(88, " As you sat on the bench, you ponder on the choice that you made was the right one.", 89, Characters.None));
        Add(new DialogueLine(89, " You wonder on how will you get out of this mess, OR more importantly...", 90, Characters.None));
        Add(new DialogueLine(90, " What is even happening?", 91, Characters.None));
        Add(new DialogueLine(91, " As your mind is processing all your questions you can hear footsteps entering the hallway.", 92, Characters.None));
        Add(new DialogueLine(92, " As the footsteps gets louder, the heart beats rapidly, on who was coming.", 93, Characters.None));
        Add(new DialogueLine(93, " The footsteps stops before you were about to see the person.", 94, Characters.None));
        Add(new DialogueLine(94, " You then here clicking sounds on a keypad.", 95, Characters.None));
        Add(new DialogueLine(95, " The lazers of your cell disapper. Leaving the exit wide open.", 96, Characters.None));
        Add(new DialogueLine(96, " The person that freed you was none other than Sofaria.", 97, Characters.None));
        Add(new DialogueLine(97, " She stood outside of the prison,looking at you in a concern but confused expression.", 98, Characters.None));
        Add(new DialogueLine(98, " I'm surprised that you stay.", 99, Characters.Sofaria));
        Add(new DialogueLine(99, " What?", 100, Characters.Player));
        Add(new DialogueLine(100, " It would've been wise for you to not be apart of this.", 101, Characters.Sofaria));
        Add(new DialogueLine(101, " Yet, you chose me. Why?", 102, Characters.Sofaria));
        Add(new DialogueLine(102, " Well... because...", 103, Characters.Player));
        Add(new DialogueLine(103, " We just started dating.", 104, Characters.Player));
        Add(new DialogueLine(104, "The moment was silent for a few seconds, as Sofaria's eyes looks down. .", 105, Characters.None));
        Add(new DialogueLine(105, "I'm sorry.", 106, Characters.Sofaria));
        Add(new DialogueLine(106, " For...?", 107, Characters.Player));
        Add(new DialogueLine(107, "For bringing you into this.", 108, Characters.Sofaria));
        Add(new DialogueLine(108, "Its my fault that he captured you to begin with.", 109, Characters.Sofaria));
        Add(new DialogueLine(109, "I didn't want anyone to be involve with What I'm doing.", 110, Characters.Sofaria));
        Add(new DialogueLine(110, "I thought maybe I would have a break for once.", 111, Characters.Sofaria));
        Add(new DialogueLine(111, " It's not a big deal, really.", 112, Characters.Player));
        Add(new DialogueLine(112, "well its my responsibility.", 113, Characters.Sofaria));
        Add(new DialogueLine(113, "And now, it's my job to fix this mess.", 114, Characters.Sofaria));
        Add(new DialogueLine(114, "Luckly, I dealt with this scenario countless of times when confronting him.", 115, Characters.Sofaria));
        Add(new DialogueLine(115, "And with your help, we can scout those this entire ship to find the control room.", 116, Characters.Sofaria));
        Add(new DialogueLine(116, "And if we can find the control room, you can go back home.", 117, Characters.Sofaria));
        Add(new DialogueLine(117, " Go home?", 118, Characters.Player));
        Add(new DialogueLine(118, "Yes you have been knock out for a few hours. Right now we are in space.", 119, Characters.Sofaria));
        Add(new DialogueLine(119, "Wait seriously?!!", 120, Characters.Player));
        Add(new DialogueLine(120, "If we can the control room quickly, you can get back home before midnight.", 121, Characters.Sofaria));
        Add(new DialogueLine(121, "What do you say?","yes", 122,"No",123, Characters.Sofaria));
        Add(new DialogueLine(122, " Of course I want to go home!", 126, Characters.Player));
        Add(new DialogueLine(123, " Acutally Being in this cell is pretty nice you know? ", 124, Characters.Player));
        Add(new DialogueLine(124, "Seriously?", 125, Characters.Sofaria));
        Add(new DialogueLine(125, " Of Course I want to get out of here! Why would I?!", 126, Characters.Player));
        Add(new DialogueLine(126, "Good Answer.", 127, Characters.Sofaria));
        Add(new DialogueLine(127, "Now let's go.", 128, Characters.Sofaria));
        Add(new DialogueLine(128, "You exit your cell, you have just started this unexpectated journey.", 129, Characters.None));
        Add(new DialogueLine(129, "Immedately you here someone calling you and Sofaria from 2 cells at the right.", 130, Characters.None));
        Add(new DialogueLine(130, "Hey mister, lady. Can you get me out of this cell too.", 131, Characters.Waitress1));
        Add(new DialogueLine(131, " Wait? are you one of the waitresses from the diner?", 132, Characters.Player));
        Add(new DialogueLine(132, "Yep, I work at that place.", 133, Characters.Waitress1));
        Add(new DialogueLine(133, "If you free me, I'll give you 50% off on all the main courses!", 134, Characters.Waitress1));
        Add(new DialogueLine(134, "Also I can help you guys search for that control room.", 135, Characters.Waitress1));
        Add(new DialogueLine(135, "I don't think it's a good idea.", 136, Characters.Sofaria));
        Add(new DialogueLine(136, "It's best for them to stay there, so they don't get hurt.", 137, Characters.Sofaria));
        Add(new DialogueLine(137, "After we get back to the city, I'll free them later.", 138, Characters.Sofaria));
        Add(new DialogueLine(138, "But overall it's your choice.", 139, Characters.Sofaria));
        Add(new DialogueLine(139, "When facing a situation like this you:","Leave her here", 140,"Free her",144, Characters.None));
        Add(new DialogueLine(140, "I'm sorry, but I think it's better for you to stay here for the time being.", 141, Characters.Player));
        Add(new DialogueLine(141, "Oh maaaaaaan!", 142, Characters.Waitress1));
        Add(new DialogueLine(142, "It may be tough decision, but you made the right one.", 143, Characters.Sofaria));
        Add(new DialogueLine(143, "Sofaria was somewhat proud of the decision that you made, when looking into eyes.", 157, Characters.None));
        Add(new DialogueLine(144, "Maybe she can come along with us. You know just for extra help.", 145, Characters.Player));
        Add(new DialogueLine(145, "Sofaria stares at you emotionlessly. Giving the impression that your choice won't even matter at all.", 146, Characters.None));
        Add(new DialogueLine(146, "Well it's your choice afterall.", 147, Characters.Sofaria));
        Add(new DialogueLine(147, "Sofaria type on the keypad for the waitress's door;freeing her from her cell.", 148, Characters.None));
        Add(new DialogueLine(148, "HOORAY!! I'M FREEEE!!!", 149, Characters.Waitress1));
        Add(new DialogueLine(149, "Hey what about me? Can you open my cell aswell?", 150, Characters.Waitress2));
        Add(new DialogueLine(150, "No! You can rot in that room for all I care!!", 151, Characters.Waitress1));
        Add(new DialogueLine(151, ":(", 152, Characters.Waitress2));
        Add(new DialogueLine(152, "NOW THEN, TIME TO USE WHAT FREEDOM I HAVE LEFT!!!", 153, Characters.Waitress1));
        Add(new DialogueLine(153, "The waitress ran as fast a racecar, leaving both you and Sofaria speechless.", 154, Characters.None));
        Add(new DialogueLine(154, "...", 155, Characters.Player));
        Add(new DialogueLine(155, "Well...that was pointless.", 156, Characters.Player));
        Add(new DialogueLine(156, "Yes...Yes it was...", 157, Characters.Sofaria));
        Add(new DialogueLine(157, "Now's that out of the way, can we start our search.", 158, Characters.Sofaria));
        Add(new DialogueLine(158, "Yes of course.", 159, Characters.Player));
        Add(new DialogueLine(159, "You and Sofaria finally started to move forward as You both sprint ahead.", 160, Characters.None));
        Add(new DialogueLine(160, "As you and Sofaria ran through the hallways, you came across a crossroad.", 161, Characters.None, Locations.SpaceshipHallway));
        Add(new DialogueLine(161, "There are two paths in front of you.", 162, Characters.None));
        Add(new DialogueLine(162, "The left side leads to a dark tunnel that is always expanded as you look at the immense void.", 163, Characters.None));
        Add(new DialogueLine(163, "While on the right side is a curve and bendable hallway where there are many twist and turns along the way.", 164, Characters.None));
        Add(new DialogueLine(164, "So it seems we're at a crossroads", 165, Characters.Sofaria));
        Add(new DialogueLine(165, "It seems like it.", 166, Characters.Player));
        Add(new DialogueLine(166, "You want to spilt up to scout the place or you want me to handle this?", 167, Characters.Sofaria));
        Add(new DialogueLine(167, "well...", "You can handle this", 168, "Let's split up",500, Characters.Player));
        Add(new DialogueLine(168, "Since you have experience this before, Maybe the best option is for you to lead.", 169, Characters.Player));
        Add(new DialogueLine(169, "well your not wrong.", 170, Characters.Sofaria));
        Add(new DialogueLine(170, "I just hope that we're going the right way.", 171, Characters.Sofaria));
        Add(new DialogueLine(171, "Yeah. Me too.", 172, Characters.Player));
        Add(new DialogueLine(172, "Sofaria decided to go the the left side, where the immediate darkness awaits for the duo.", 173, Characters.None));
        Add(new DialogueLine(173, "You and Sofaria walk towards the black tunnel, hoping that this is the right path.", 174, Characters.None));
        Add(new DialogueLine(174, "As you continue moving, the darkness consumes them completly;removing their sight.", 175, Characters.None));
        Add(new DialogueLine(175, "Hey! Sofaria! Where did you go?!", 176, Characters.Player));
        Add(new DialogueLine(176, "You move your head around to find a little bit of opacity. ", 177, Characters.None));
        Add(new DialogueLine(177, "But you were as blind as a bat, and didn't know what to do. ", 178, Characters.None));
        Add(new DialogueLine(178, "seconds later, someone grabs your hand. ", 179, Characters.None));
        Add(new DialogueLine(179, "calmdown. It's me.", 180, Characters.Sofaria));
        Add(new DialogueLine(180, "Oh, sorry about that.", 181, Characters.Player));
        Add(new DialogueLine(181, "The sound of her voice gave you relief in this abysmal tunnel. ", 182, Characters.None));
        Add(new DialogueLine(182, "Come on. Let's us continue moving forward.", 183, Characters.Sofaria));
        Add(new DialogueLine(183, "Ok...", 184, Characters.Player));
        Add(new DialogueLine(184, "You and Sofaria hold hands for the entire tunnel. ", 185, Characters.None));
        Add(new DialogueLine(185, "As you both proceed more and more into the darkness, You can here whispers of several people. ", 186, Characters.None));
        Add(new DialogueLine(186, "It sounds like they are speaking in a different language. ", 187, Characters.None));
        Add(new DialogueLine(187, "Eventually, you and sofaria made it out of the dark tunnel. ", 188, Characters.None));
        Add(new DialogueLine(188, "As you sigh in relief that it was over, Sofaria looks at there hands still holding. ", 189, Characters.None));
        Add(new DialogueLine(189, "You immediately blushed, and release sofaria hand. ", 190, Characters.None));
        Add(new DialogueLine(190, "As you were about to say something to her, you realize that there was something big right in front of you. ", 191, Characters.None));
        Add(new DialogueLine(191, "As you look in front of you, You realized that you and sofaria are right infront of a giant gate door. ", 192, Characters.None));
        Add(new DialogueLine(192, "You and Sofia walk towards the looming gatedoor; like it's enchanting them to go in. ", 193, Characters.None, Locations.SpaceshipGatedoor));
        Add(new DialogueLine(193, "As You and sofaria continue any farther, another looming figure immediately came out of nowhere and block the duo from entering. ", 194, Characters.None));
        Add(new DialogueLine(194, "What the...?", 195, Characters.Player));
        Add(new DialogueLine(195, "well I guess you must be new here huh.", 196, Characters.Sofaria));
        Add(new DialogueLine(196, "...", 197, Characters.Bodyguard));
        Add(new DialogueLine(197, "How did you know?", 198, Characters.Bodyguard));
        Add(new DialogueLine(198, "His previous minions were all fodder compared to you.", 199, Characters.Sofaria));
        Add(new DialogueLine(199, "There's something different about you when comparing the rest.", 200, Characters.Sofaria));
        Add(new DialogueLine(200, "When were you hired?", 201, Characters.Sofaria));
        Add(new DialogueLine(201, "Last month.", 202, Characters.Bodyguard));
        Add(new DialogueLine(202, "Strange...", 203, Characters.Sofaria));
        Add(new DialogueLine(203, "Anyway, I'm afraid this conversation ends now.", 204, Characters.Sofaria));
        Add(new DialogueLine(204, "Move aside, or you'll end up like one of your master's failed experiments.", 205, Characters.Sofaria));
        Add(new DialogueLine(205, "...", 206, Characters.Bodyguard));
        Add(new DialogueLine(206, "I'm afraid your making the mistake.", 207, Characters.Bodyguard));
        Add(new DialogueLine(207, "My boss didn't hired any mere minion.", 208, Characters.Bodyguard));
        Add(new DialogueLine(208, "My role here, is I'm the BODYGUARD.", 209, Characters.Bodyguard));
        Add(new DialogueLine(209, "Im order to guard the controlroom 24/7, and I cannot let anyone inside...", 210, Characters.Bodyguard));
        Add(new DialogueLine(210, "Especcialy you two humans.", 211, Characters.Bodyguard));
        Add(new DialogueLine(211, "...", 212, Characters.Sofaria));
        Add(new DialogueLine(212, "We got to fight our way in, in order for you to get home!", 213, Characters.Sofaria));
        Add(new DialogueLine(213, "Are you with me?","Yeah! Let's fight!", 214,"Talk to the bodyguard",350, Characters.Sofaria)); //CHECK THIS OUT AFTER YOU"RE DONE WITH GATE DOOR
        Add(new DialogueLine(214, "Alright! Let's do this!", 215, Characters.Player));
        Add(new DialogueLine(215, "You and Sofaria charge at the hulking monster, But you were both defeated with a single smack of his arm.", 216, Characters.None));
        Add(new DialogueLine(216, "You can try all you want, But you'll never get pass me.", 217, Characters.Bodyguard));
        Add(new DialogueLine(217, "So just kindly go away and find a different room instead.", 218, Characters.Bodyguard));
        Add(new DialogueLine(218, "Dammit! there has to be some other way to get inside.", 219, Characters.Sofaria));
        Add(new DialogueLine(219, ".....", "Show him a meme", 220,"Talk to the bodyguard",350, Characters.Player));              //CHECK THIS AS WELL
        Add(new DialogueLine(220, "How about I try something else...", 221, Characters.Player));
        Add(new DialogueLine(221, "?", 222, Characters.Sofaria));
        Add(new DialogueLine(222, "You walk towards the monster, as he's in a fighting position.", 223, Characters.None));
        Add(new DialogueLine(223, "How about we make a bet!", 224, Characters.Player));
        Add(new DialogueLine(224, "Okay?", 225, Characters.Bodyguard));
        Add(new DialogueLine(225, "If I can show you good a meme, you will let us pass.", 226, Characters.Player));
        Add(new DialogueLine(226, "If not, then we will leave.", 227, Characters.Player));
        Add(new DialogueLine(227, "That seems fair.", 228, Characters.Bodyguard));
        Add(new DialogueLine(228, "What are you even-", 229, Characters.Sofaria));
        Add(new DialogueLine(229, "Ok! Check this out!.", 230, Characters.Player));
        Add(new DialogueLine(230, ".....................................", 231, Characters.None, Locations.MemeImage));
        Add(new DialogueLine(231, "............", 232, Characters.Bodyguard));
        Add(new DialogueLine(232, "hhmmmm...", 233, Characters.Bodyguard));
        Add(new DialogueLine(233, "Looking at this image seems very relatable to me...", 234, Characters.Bodyguard));
        Add(new DialogueLine(234, "So...Its a good meme.", 235, Characters.Player));
        Add(new DialogueLine(235, "...", 236, Characters.Bodyguard));
        Add(new DialogueLine(236, "Yeah it's a pretty good meme.", 237, Characters.Bodyguard));
        Add(new DialogueLine(237, "The bodyguard move from the side, reavealing the small door to enter.", 238, Characters.None, Locations.SpaceshipGatedoor));
        Add(new DialogueLine(238, "..........", 239, Characters.Sofaria));
        Add(new DialogueLine(239, "what just happen?", 240, Characters.Sofaria));
        Add(new DialogueLine(240, "Oh, I just showed him a meme, in order for him to let us pass.", 241, Characters.Player));
        Add(new DialogueLine(241, "what?", 242, Characters.Sofaria));
        Add(new DialogueLine(242, "Yeah. I'm surprised that it work.", 243, Characters.Player));
        Add(new DialogueLine(243, "Come on lets go.", 244, Characters.Player));
        Add(new DialogueLine(244, "wait...What's a meme?", 245, Characters.Sofaria));
        Add(new DialogueLine(245, "You never heard one before?", 246, Characters.Player));
        Add(new DialogueLine(246, "No.", 247, Characters.Sofaria));
        Add(new DialogueLine(247, "Oh ok! once we get back home, I'll explain everything about it.", 248, Characters.Player));
        Add(new DialogueLine(248, "Ok...?", 249, Characters.Sofaria));
        Add(new DialogueLine(249, "You and Sofaria walks towards the door.", 250, Characters.None));
        Add(new DialogueLine(250, "As you both enter the room, you knew that this is the end of your journey.", 251, Characters.None));
        Add(new DialogueLine(251, "You finally made to the controlroom.", 252, Characters.None, Locations.SpaceshipControlroom));
        Add(new DialogueLine(252, "Inside, there are big computers on the far side of the room. In between them, is the wheel of the entire spaceship.", 253, Characters.None));
        Add(new DialogueLine(253, "Right in the center of the room is the Mad Scientist himself. Who glares at you and Sofaria with the intent to kill.", 254, Characters.None));
        Add(new DialogueLine(254, "Well, well, well. I knew you and your boyfriend will show up here.", 255, Characters.Madscientist));
        Add(new DialogueLine(255, "But there's one thing that's bothering me...", 256, Characters.Madscientist));
        Add(new DialogueLine(256, "HOW THE LIVING HELL DID YOU EVEN GET HERE!!!", 257, Characters.Madscientist));
        Add(new DialogueLine(257, "YOU WEREN'T SUPPOSE TO GET PAST BY MY NEW HENCHMAN!!!", 258, Characters.Madscientist));
        Add(new DialogueLine(258, "Of course. That bodyguard was quite tough. But little did you know...", 259, Characters.Sofaria));
        Add(new DialogueLine(259, "HE got us here.", 260, Characters.Sofaria));
        Add(new DialogueLine(260, "...", 261, Characters.Player));
        Add(new DialogueLine(261, "Well! I guess you really are something after all!", 262, Characters.Madscientist));
        Add(new DialogueLine(262, "Perhaps I should kill you first!!", 263, Characters.Madscientist));
        Add(new DialogueLine(263, "You are not going to hurt him!", 264, Characters.Sofaria));
        Add(new DialogueLine(264, "Sofaria's scurf glows in a orange aura.", 265, Characters.None));
        Add(new DialogueLine(265, "The scurf ignites itself in flames, covering sofaria as a shiled in someway.", 266, Characters.None));
        Add(new DialogueLine(266, "This maddness ends now.", 267, Characters.Sofaria));
        Add(new DialogueLine(267, "INDEED!!!", 268, Characters.Madscientist));
        Add(new DialogueLine(268, "They both trade blow for blow, for every punch, kick, and even headbutt.", 269, Characters.None));
        Add(new DialogueLine(269, "Suddenly the green eye on top of the scientist's forehead, flashed Sofaria; which the scientist used this moment as an advantage.", 270, Characters.None));
        Add(new DialogueLine(270, "The mad scientist pinned Sofaria on the floor, as he steps on her throat; slowly sovicating her.", 271, Characters.None));
        Add(new DialogueLine(271, "What's the matter Sofaria. I thought you had alot more fight in you?!", 272, Characters.Madscientist));
        Add(new DialogueLine(272, "Are you really going to croke infront of your little botfriend?!", 273, Characters.Madscientist));
        Add(new DialogueLine(273, "As you look across the room, the only thing you can do is:", "Spin the wheel",274,"Fight him.",500, Characters.None));
        Add(new DialogueLine(274, "You ran towards the ship's wheel.", 275, Characters.None));
        Add(new DialogueLine(275, "HEY! WHAT ARE YOU DOING OVER THERE!!!", 276, Characters.Madscientist));
        Add(new DialogueLine(276, "You pull the wheel so hard, that it turn the ship upside down.", 277, Characters.None));
        Add(new DialogueLine(277, "As everyone was flying around the room like balls in a pinball machine, You hit yourself on one of the walls, Knocking you out.", 278, Characters.None));
        Add(new DialogueLine(278, "You are now experiencing total darkness.", 279, Characters.None, Locations.BlackScreen));
        Add(new DialogueLine(279, "Suddenly, you hear a voice calls out to.", 280, Characters.None));
        Add(new DialogueLine(280, "-As you fight through this darkness, You finally open your eyes, witnessing your end of the journey.", 281, Characters.None));
        Add(new DialogueLine(281, "So you want to get some fries?", 282, Characters.Sofaria, Locations.Grasslands));
        Add(new DialogueLine(282, "Uhmm...Sure!", 283, Characters.Player));
        Add(new DialogueLine(283, "ENDING 3: You and Sofaria walk away from the chaos, both eager to start the second date.", 284, Characters.None, Locations.Ending3));

        Add(new DialogueLine(350, "Wait let me talk to him.", 352, Characters.Player));
        Add(new DialogueLine(352, "You walk towards the 9 foot giant, as he looks down at you.", 353, Characters.None));
        Add(new DialogueLine(353, "Hey, Uhhh...So you got here last month right?", 354, Characters.Player));
        Add(new DialogueLine(354, "Yes.", 355, Characters.Bodyguard));
        Add(new DialogueLine(355, "My boss found me a deserted planet, in the middle of a decaying cosmos.", 356, Characters.Bodyguard));
        Add(new DialogueLine(356, "I couldn't remeber my name or where I'm from.", 357, Characters.Bodyguard));
        Add(new DialogueLine(357, "But ever since he found me, I promise me myself to return the favor by being his bodyguard and protect him from any harm.", 358, Characters.Bodyguard));
        Add(new DialogueLine(358, "But we are not here to hurt your boss.", 359, Characters.Player));
        Add(new DialogueLine(359, "what?", 360, Characters.Bodyguard));
        Add(new DialogueLine(360, "I got here by accident, and all I wanted was to go back home.", 361, Characters.Player));
        Add(new DialogueLine(361, "And Sofaria has no personal grudge against your boss.", 362, Characters.Player));
        Add(new DialogueLine(362, "If we can get to the controlroom, and just move the ship back to my home, me and Sofaria will leave and you will never see us again.", 363, Characters.Player));
        Add(new DialogueLine(363, "So what do you think?", 364, Characters.Player));
        Add(new DialogueLine(364, "well...If you're not going to cause any harm to my boss...", 365, Characters.Bodyguard));
        Add(new DialogueLine(365, "Can you please just do it quick!", 366, Characters.Bodyguard));
        Add(new DialogueLine(366, "Yes. I promise.", 367, Characters.Player));
        Add(new DialogueLine(367, "Thank you!", 368, Characters.Bodyguard));
        Add(new DialogueLine(368, "The bodyguard  move from the side, revealing a smaller door of the giant gatedoor right behind him.", 369, Characters.None));
        Add(new DialogueLine(369, "huh. I'm actually impressed.", 370, Characters.Sofaria));
        Add(new DialogueLine(370, "I didn't you have such a way with words.", 371, Characters.Sofaria));
        Add(new DialogueLine(371, "well, I used to be a Kindergarten teacher.", 372, Characters.Player));
        Add(new DialogueLine(372, "Now that explains it.", 249, Characters.Sofaria));
        



        Add(new DialogueLine(500, "I think it's a good idea we both split up, in order to have a better chance on finding the control room.", 501, Characters.Player));
        Add(new DialogueLine(501, "You make a good point.", 502, Characters.Sofaria));
        Add(new DialogueLine(502, "I'll take left.", 503, Characters.Sofaria));
        Add(new DialogueLine(503, "and I'll go right.", 504, Characters.Player));
        Add(new DialogueLine(504, "Wait.Before you go, I need to tell you something?", 505, Characters.Sofaria));
        Add(new DialogueLine(505, "Yeah?", 506, Characters.Player));
        Add(new DialogueLine(506, "...", 507, Characters.Sofaria));
        Add(new DialogueLine(507, "Becareful out there.", 508, Characters.Sofaria));
        Add(new DialogueLine(508, "...", 509, Characters.Player));
        Add(new DialogueLine(509, "Yeah. You too.", 510, Characters.Player));
        Add(new DialogueLine(510, "As you were about to proceed on your coosen path, Sofaria immediately ran into the tunnel of darkness.", 511, Characters.None));
        Add(new DialogueLine(511, "Leaving you all alone, ungarded.", 512, Characters.None));
        Add(new DialogueLine(512, "But through your determination, you proceeded on the wunky path, hoping that you can find the controlroom soon.", 513, Characters.None));
        Add(new DialogueLine(513, "On the wunky path, you experience many twist and turns that you would have died to.", 514, Characters.None));
        Add(new DialogueLine(514, "Such as the many steep cliffs that are 30 ft high, tight space that you have to force your big body to proceed forward, and having the feeling that you are being watched by something.", 515, Characters.None));
        Add(new DialogueLine(515, "As you continue moving forward. You hear--", 516, Characters.None));
        Add(new DialogueLine(516, "BAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA", 517, Characters.Willy, Locations.StrangePlanet));
        Add(new DialogueLine(517, "I-I-I-I'm sorry about that.", 518, Characters.Willy));
        Add(new DialogueLine(518, "It-It-It just that....HA.HA.HAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.", 519, Characters.Willy));
        Add(new DialogueLine(519, "Sorry...", 520, Characters.Willy));
        Add(new DialogueLine(520, "...", 521, Characters.Willy));
        Add(new DialogueLine(521, "So you must be confuse of what just happen!", 522, Characters.Willy));
        Add(new DialogueLine(522, "What you are experiencing is a term I like to call...", 523, Characters.Willy));
        Add(new DialogueLine(523, "A Road block.", 524, Characters.Willy));
        Add(new DialogueLine(524, "Sadley yes. This route that you have chose is still under construction.", 525, Characters.Willy));
        Add(new DialogueLine(525, "As of this moment, me and mi amigos are facing some techniqual difficulties...", 526, Characters.Willy));
        Add(new DialogueLine(526, "No it's that we are clueless of how and where we will put this road.", 527, Characters.Willy));
        Add(new DialogueLine(527, "We are facing the most common problem that every living being in this universe has experience...", 528, Characters.Willy));
        Add(new DialogueLine(528, "Time!", 529, Characters.Willy));
        Add(new DialogueLine(529, "All you have to do is give us alittle time!", 530, Characters.Willy));
        Add(new DialogueLine(530, "If you can fulfill our promises, surely we will be able to finish this road in no time!", 531, Characters.Willy));
        Add(new DialogueLine(531, "...", 532, Characters.Willy));
        Add(new DialogueLine(532, "Or not.", 533, Characters.Willy));
        Add(new DialogueLine(533, "Personally, I'm not really good at making promises.", 534, Characters.Willy));
        Add(new DialogueLine(534, "I'm also not employed!", 535, Characters.Willy));
        Add(new DialogueLine(535, "I'm a cowboy, not a contruction worker!", 536, Characters.Willy));
        Add(new DialogueLine(536, "BAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA", 537, Characters.Willy));
        Add(new DialogueLine(537, "...", 538, Characters.Willy));
        Add(new DialogueLine(538, "Overall, you must be dissappointed that you came all this way for nothin.", 539, Characters.Willy));
        Add(new DialogueLine(539, "NOT TO WORRY AMIGO!!", 540, Characters.Willy));
        Add(new DialogueLine(540, "We got a special ending just for you!", 541, Characters.Willy));
        Add(new DialogueLine(541, "TAKE IT AWAY ROB!!", 542, Characters.Willy));
        Add(new DialogueLine(542, "ENDING[?]:https://www.youtube.com/watch?v=dQw4w9WgXcQ&t=2s", 543, Characters.Rob));
        Add(new DialogueLine(543, "...", 544, Characters.Rob));
        Add(new DialogueLine(544, "...", 545, Characters.Rob));
        Add(new DialogueLine(545, "That's it.", 546, Characters.Rob));
        Add(new DialogueLine(546, "...", 547, Characters.Rob));
        Add(new DialogueLine(547, "...", 548, Characters.Rob));
        Add(new DialogueLine(548, "Go away.", 549, Characters.Rob));

    }

    void Add(DialogueLine dl)
    {
        Dialogue.Add(dl.ID,dl);
    }
}
