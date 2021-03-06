﻿using System;

namespace TetrisMain
{
    public class TetrisGameState
    {
        public TetrisGameState(int tetrisRows, int tetristCols)
        {
        this.HighScore = 0;
        this.Score = 0;
        this.Frame = 0;
        this.Level = 1;
        this.FramesToMoveFigure = 16;
        this.CurrentFigure = null;
        this.CurrentFigureRow = 0;
        this.CurrentFigureCol = 0;
            this.TetrisField = new bool[tetrisRows, tetristCols];
        }

        public  int HighScore { get; set; }
        public  int Score { get; set; }
        public  int Frame { get; set; }
        public  int Level { get; private set; }
        public  int FramesToMoveFigure { get; private set; }
        public  bool[,] CurrentFigure { get; set; }
        public  int CurrentFigureRow { get; set; }
        public  int CurrentFigureCol { get; set; }
        public  bool[,] TetrisField { get; private set; }

        public void UpdateLevel()
        {
            if (this.Score <= 0)
            {
                this.Level = 1;
                return;
            }

            this.Level = (int)Math.Log10(this.Score) - 1;
            if (this.Level < 1)
            {
                this.Level = 1;
            }

            if (this.Level > 10)
            {
                this.Level = 10;
            }
        }
    }
}
