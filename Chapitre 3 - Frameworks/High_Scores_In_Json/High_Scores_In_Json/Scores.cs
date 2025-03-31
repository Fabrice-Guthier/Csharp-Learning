using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;



namespace High_Scores_In_Json
{
    public class Scores
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Scores(string name = "", int score = 0)
        {
            Name = name;
            Score = score;
        }
    }
}
