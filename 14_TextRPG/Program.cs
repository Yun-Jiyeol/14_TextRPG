namespace _14_TextRPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            string filePath = "SaveGame.json";

            //처음 실행 했을때 간단한 설명
            if (File.Exists(filePath)) //저장된 플레이어 정보가 존재한다면
            {
                gm.LoadPlayer();
            }
            else
            {
                gm.SettingPlayerName();
            }
        }
    }
}
