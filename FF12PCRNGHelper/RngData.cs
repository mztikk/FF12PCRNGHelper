using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace FF12PCRNGHelper
{
    internal static class RngData
    {
        private static bool _finishedSearching;

        private static readonly Dictionary<uint, uint> PData = new Dictionary<uint, uint>
        {
            {0, 0},
            {1, 21},
            {2, 2},
            {3, 23},
            {4, 68},
            {5, 12},
            {6, 70},
            {7, 14},
            {8, 189},
            {9, 193},
            {10, 191},
            {11, 195},
            {12, 25},
            {13, 65},
            {14, 27},
            {15, 67},
            {16, 16},
            {17, 5},
            {18, 18},
            {19, 7},
            {20, 84},
            {21, 28},
            {22, 86},
            {23, 30},
            {24, 61},
            {25, 156},
            {26, 63},
            {27, 158},
            {28, 9},
            {29, 149},
            {30, 11},
            {31, 151},
            {32, 77},
            {33, 17},
            {34, 79},
            {35, 19},
            {36, 420},
            {37, 8},
            {38, 422},
            {39, 10},
            {40, 45},
            {41, 76},
            {42, 47},
            {43, 78},
            {44, 121},
            {45, 53},
            {46, 123},
            {47, 55},
            {48, 100},
            {49, 1},
            {50, 102},
            {51, 3},
            {52, 448},
            {53, 24},
            {54, 450},
            {55, 26},
            {56, 192},
            {57, 92},
            {58, 194},
            {59, 94},
            {60, 105},
            {61, 37},
            {62, 107},
            {63, 39},
            {64, 64},
            {65, 60},
            {66, 66},
            {67, 62},
            {68, 4},
            {69, 104},
            {70, 6},
            {71, 106},
            {72, 301},
            {73, 136},
            {74, 303},
            {75, 138},
            {76, 89},
            {77, 204},
            {78, 91},
            {79, 206},
            {80, 29},
            {81, 97},
            {82, 31},
            {83, 99},
            {84, 20},
            {85, 108},
            {86, 22},
            {87, 110},
            {88, 180},
            {89, 248},
            {90, 182},
            {91, 250},
            {92, 73},
            {93, 229},
            {94, 75},
            {95, 231},
            {96, 13},
            {97, 81},
            {98, 15},
            {99, 83}
        };

        internal static void GetMtForValue(uint value, uint workerAmount = 2)
        {
            _finishedSearching = false;

            for (uint i = 0; i < workerAmount; i++)
            {
                var bg = new BackgroundWorker();
                bg.DoWork += WorkerWork;
                bg.RunWorkerCompleted += WorkerCompleted;
                bg.RunWorkerAsync(new RngSearch(i, value, uint.MaxValue, workerAmount));
            }
        }

        internal static uint GetMtForPercentage(uint percentage)
        {
            if (percentage > 99)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage),
                    "Percentage has to be greater or equal to zero and lower than 100.");
            }

            return PData[percentage];
        }

        private static void WorkerCompleted(object o, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            if (!runWorkerCompletedEventArgs.Cancelled)
            {
                _finishedSearching = true;
                MessageBox.Show(runWorkerCompletedEventArgs.Result.ToString());
            }
        }

        private static void WorkerWork(object o, DoWorkEventArgs doWorkEventArgs)
        {
            var rngsearch = (RngSearch) doWorkEventArgs.Argument;
            var rng = new RNG2002();
            for (var i = rngsearch.StartIndex;
                i <= rngsearch.End;
                i += rngsearch.Step * (uint) (rngsearch.ReverseLoop ? -1 : 1))
            {
                if (_finishedSearching)
                {
                    doWorkEventArgs.Cancel = true;
                    return;
                }

                rng.mti = 1;
                rng.mt[1] = i;
                if (rng.genrand() == rngsearch.SearchValue)
                {
                    doWorkEventArgs.Result = i;
                    return;
                }
            }

            doWorkEventArgs.Cancel = true;
        }

        private struct RngSearch
        {
            public uint StartIndex { get; }

            public uint SearchValue { get; }

            public uint End { get; }

            public uint Step { get; }

            public bool ReverseLoop { get; }

            public RngSearch(uint startIndex, uint searchValue, uint end = uint.MaxValue, uint step = 2,
                bool reverseLoop = false)
            {
                this.StartIndex = startIndex;
                this.SearchValue = searchValue;
                this.End = end;
                this.Step = step;
                this.ReverseLoop = reverseLoop;
            }
        }
    }
}