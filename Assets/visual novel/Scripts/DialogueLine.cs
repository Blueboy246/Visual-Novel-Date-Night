public struct DialogueLine
{
    public int ID;
    public string Text;
    public Characters Who;
    public Locations Where;
    public int Next;
    public int NextB;
    public int NextC;
    public string ChoiceA;
    public string ChoiceB;
    public string ChoiceC;

    public DialogueLine(int id,string txt,int next,Characters who=Characters.SameAsBefore,Locations where=Locations.None)
    {
        ID = id;
        Text = txt;
        Who = who;
        Where = where;
        Next = next;
        NextB = 0;
        NextC = 0;
        ChoiceA = "";
        ChoiceB = "";
        ChoiceC = "";
    }
    
    public DialogueLine(int id,string txt,string choiceA,int nextA,string choiceB,int nextB,Characters who=Characters.SameAsBefore,Locations where=Locations.None)
    {
        ID = id;
        Text = txt;
        Who = who;
        Where = where;
        Next = nextA;
        NextB = nextB;
        ChoiceA = choiceA;
        ChoiceB = choiceB;
        NextC = 0;
        ChoiceC = "";
    }
    public DialogueLine(int id, string txt, string choiceA, int nextA, string choiceB, int nextB, string choiceC, int nextC, Characters who = Characters.SameAsBefore, Locations where = Locations.None)
    {
        ID = id;
        Text = txt;
        Who = who;
        Where = where;
        Next = nextA;
        NextB = nextB;
        ChoiceA = choiceA;
        ChoiceB = choiceB;
        NextC = nextC;
        ChoiceC = choiceC;
    }
}

public enum Characters
{
    SameAsBefore,
    Player,
    MysteryGirl,
    Madscientist,
    None,
    Albert,
    Waitress1,
    Waitress2,
    Bodyguard,
    Willy,
    Rob,
    Sofaria
}

public enum Locations
{
    None,
    Diner,
    SpaceshipHallway,
    Explosion,
    DestroyedDiner,
    SpaceshipPrisoncell,
    SpaceshipGatedoor,
    SpaceshipControlroom,
    Grasslands,
    StrangePlanet,
    Ending2,
    Ending3,
    Ending4,
    MemeImage,
    BlackScreen
}