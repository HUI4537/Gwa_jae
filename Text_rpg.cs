// See https://aka.ms/new-console-template for more information

class Player //플레이어 
{
    int AT = 10;
    int HP = 50;
    int MAXHP = 100;

    public void PrintHp() //플레이어 HP 몇인지 출력하는 함수
    {
        Console.WriteLine("");
        Console.Write("현재 플레이어의 HP는 ");
        Console.Write(HP);
        Console.WriteLine("입니다.");
        Console.ReadKey();
    }
    public void MaxHeal() //체력 회복시키는 함수
    {
        if (HP >= MAXHP) // 체력이 맥스인지 확인하는 조건문
        {
            Console.WriteLine("");
            Console.WriteLine("체력이 모두 회복되어있어 회복할 필요가 없습니다.");
            Console.ReadKey();
        }
        else //맥스가 아니면 회복
        {
            HP = MAXHP;
            PrintHp();
        }
        return;
    }

    public void StatusRender() //스탯 알려주는 함수
    {
        Console.WriteLine("-------------------------------------------------");
        Console.Write("공격력 : ");
        Console.WriteLine(AT);

        Console.Write("체력 : ");
        Console.Write(HP);
        Console.Write("/");
        Console.WriteLine(MAXHP);
        Console.WriteLine("-------------------------------------------------");


    }
}
class Monster
{

}

enum STARTSELECT //시작 선택 목록 리턴값 범위를 정함
{
    SELECTTOWN,
    SELECTBATTLE,
    NONSELECT,
}


internal class Program //프로그램 클래스
{
    static STARTSELECT StartSelect() //게임 시작 함수
    {


        Console.Clear(); //실행되면 일단 안내문 띄움
        Console.WriteLine("1. 마을");
        Console.WriteLine("2. 배틀");
        Console.WriteLine("어디로 가시겠습니까?");

        ConsoleKeyInfo CKI = Console.ReadKey();  //사용자가 누른 키 가져오기

        Console.WriteLine("");

        switch (CKI.Key)  //1번이 눌렸을때 or 2번이 눌렸을때 조건문
        {
            case ConsoleKey.D1:
                Console.WriteLine("마을로 이동합니다.");
                Console.ReadKey();
                return STARTSELECT.SELECTTOWN;
            case ConsoleKey.D2:
                Console.WriteLine("배틀을 시작합니다.");
                Console.ReadKey();
                return STARTSELECT.SELECTBATTLE;
            default:
                Console.WriteLine("잘못된 선택입니다.");
                Console.ReadKey();
                return STARTSELECT.NONSELECT;
        }

    }

    static void Town(Player _Player) //마을 스태틱 함수
    {
        while (true)
        {
            Console.Clear();   //안내문을 적어서 보여줌
            _Player.StatusRender();
            Console.WriteLine("마을에서 무슨 일을 하시겠습니까?");
            Console.WriteLine("1. 체력을 회복한다.");
            Console.WriteLine("2. 무기를 강화한다.");
            Console.WriteLine("3. 마을을 나간다.");

            switch (Console.ReadKey().Key)  //키감지
            {
                case ConsoleKey.D1: //1 누르면 체력회복 함수 작동
                    _Player.MaxHeal();
                    break;
                case ConsoleKey.D2: //2 누르면 없음
                    break;
                case ConsoleKey.D3: //3 누르면 마을 함수를 끝냄
                    return;
            }
        }
    }

    static void Battle() //배틀함수
    {
        Console.WriteLine("");
        Console.WriteLine("아직 개장하지 않았습니다.");
        Console.ReadKey(); //글을 띄우고 아무 키나 클릭시 함수 종료
    }

    private static void Main(string[] args) //게임 실행
    {

        Player NewPlayer = new Player(); 
        //변수에 클래스 플레이어를 지정

        while (true)
        {

            STARTSELECT SelectCheck = StartSelect(); //시작 함수의 리턴값을 변수에 저장

            switch (SelectCheck)
            {
                case STARTSELECT.SELECTTOWN: //변수가 마을이면
                    Town(NewPlayer); //마을 실행
                    break;
                case STARTSELECT.SELECTBATTLE: //변수가 배틀이면 배틀 실행
                    Battle();
                    break;
            }
        }

    }
}