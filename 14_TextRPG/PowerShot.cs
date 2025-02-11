using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace _14_TextRPG
{
    public class PowerShot : Skill
    {
        public PowerShot()
        {
            Name = "쌔게 배기";
            Explain = "쌔게 배어 적 하나를 강하게 친다";
            UseMana = 10;
            Damage = 130;
            HowMany = 1;
        }
    }
}
