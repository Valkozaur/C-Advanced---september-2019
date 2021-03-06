﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TetrisMain
{
    public class ScoreManager
    {
        private string highScoreFile;

        public ScoreManager(string highScoreFile)
        {
            this.highScoreFile = highScoreFile;
        }

        public int GetHighScore()
        {
            var highScore = 0;
            if (File.Exists(this.highScoreFile))
            {
                var allScores = File.ReadAllLines(this.highScoreFile);
                foreach (var score in allScores)
                {
                    var match = Regex.Match(score, @" => (?<Score>[0-9]+)");
                    highScore = Math.Max(highScore, int.Parse(match.Groups["Score"].Value));
                }
            }

            return highScore;
        }

        public void Add(int score)
        {
            File.AppendAllLines(this.highScoreFile, new List<string>
            {
                $"[{DateTime.Now.ToString()}] {Environment.UserName} => {score}"
            });
        }
    }
}
