using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Bigswing : Skill
    {
        public Bigswing() 
        {
            Name = "크게 배기";
            Explain = "크게 배어 적 전체를 휩쓴다";
            UseMana = 15;
            Damage = 80;
            HowMany = 4;
        }
    }
}
