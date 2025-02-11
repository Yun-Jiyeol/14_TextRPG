using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Skill
    {
        public string Name { get; set; } //스킬 이름
        public string Explain { get; set; } //스킬 설명
        public int UseMana { get; set; } //얼마나 많은 적을 때리는 가
        public int Damage { get; set; } //스킬 데미지
        public int HowMany {  get; set; } //얼마나 많은 적을 때리는 가
    }
}
