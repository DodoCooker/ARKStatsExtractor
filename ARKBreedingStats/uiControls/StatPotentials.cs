﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ARKBreedingStats.uiControls
{
    public partial class StatPotentials : UserControl
    {
        private readonly List<StatPotential> stats;
        public int speciesIndex;
        private readonly int[] oldLevels;

        public StatPotentials()
        {
            InitializeComponent();

            stats = new List<StatPotential>();
            for (int s = 0; s < 8; s++)
            {
                StatPotential stat = new StatPotential(s, Utils.precision(s) == 3);
                groupBox1.Controls.Add(stat);
                stat.Location = new Point(3, 58 + s * 30);
                stats.Add(stat);
            }
            oldLevels = new int[8];
        }

        public void setLevels(int[] levelsWild, bool forceUpdate)
        {
            SuspendLayout();
            for (int s = 0; s < 8; s++)
            {
                if (forceUpdate || oldLevels[s] != levelsWild[s])
                {
                    oldLevels[s] = levelsWild[s];
                    stats[s].setLevel(speciesIndex, levelsWild[s]);
                }
            }
            ResumeLayout();
        }

        public int levelDomMax
        {
            set
            {
                for (int s = 0; s < 8; s++)
                    stats[s].maxDomLevel = value;
            }
        }

        public int levelGraphMax
        {
            set
            {
                for (int s = 0; s < 8; s++)
                    stats[s].levelGraphMax = value;
            }
        }
    }
}
