// https://github.com/Tranquilite0/FF12RNGHelper/blob/master/RNG2002.cs

/* C# Port of MT19937: Integer version (2002/1/26) algorithm used in the PS4?    */
/* More information, including original source can be found at the following     */
/* Link: http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/MT2002/emt19937ar.html  */

/* 
   A C-program for MT19937, with initialization improved 2002/1/26.
   Coded by Takuji Nishimura and Makoto Matsumoto.

   Before using, initialize the state by using init_genrand(seed)  
   or init_by_array(init_key, key_length).

   Copyright (C) 1997 - 2002, Makoto Matsumoto and Takuji Nishimura,
   All rights reserved.                          

   Redistribution and use in source and binary forms, with or without
   modification, are permitted provided that the following conditions
   are met:

     1. Redistributions of source code must retain the above copyright
        notice, this list of conditions and the following disclaimer.

     2. Redistributions in binary form must reproduce the above copyright
        notice, this list of conditions and the following disclaimer in the
        documentation and/or other materials provided with the distribution.

     3. The names of its contributors may not be used to endorse or promote 
        products derived from this software without specific prior written 
        permission.

   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
   A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE COPYRIGHT OWNER OR
   CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
   EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
   PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
   PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
   LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
   NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
   SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.


   Any feedback is very welcome.
   http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html
   email: m-mat @ math.sci.hiroshima-u.ac.jp (remove space)
*/

namespace FF12PCRNGHelper
{
    public class RNG2002
    {
        /// <summary>
        ///     This is the seed the PS4/FF12:ZA uses
        /// </summary>
        public const uint DEFAULT_SEED = 4537U; // 5489U is default seed. PS2 and PS4/FF12:ZA uses 4537.

        /* Period parameters */
        private const int N = 624;

        private const int M = 397;

        private const uint MATRIX_A = 0x9908b0dfU; /* constant vector a */

        private const uint UPPER_MASK = 0x80000000U; /* most significant w-r bits */

        private const uint LOWER_MASK = 0x7fffffffU; /* least significant r bits */

        private readonly uint[] mag01 = {0x0U, MATRIX_A}; //Moved out of below method.

        public RNG2002(uint seed)
        {
            this.Seed = seed;
            this.sgenrand(seed);
        }

        // Empty constructor for faster initialization, we don't care about seeding since we loadState.
        public RNG2002()
        {
        }

        public uint[] mt { get; set; } = new uint[N]; /* the array for the state vector  */

        public int mti { get; set; } = N + 1; /* mti==N+1 means mt[N] is not initialized */

        public uint Seed { get; set; }

        public void sgenrand()
        {
            this.sgenrand(DEFAULT_SEED);
        }

        /* initializes mt[N] with a seed */
        public void sgenrand(uint s) //init_genrand
        {
            this.mt[0] = s & 0xffffffff;
            for (this.mti = 1; this.mti < N; this.mti++)
            {
                this.mt[this.mti] = 1812433253U * (this.mt[this.mti - 1] ^ (this.mt[this.mti - 1] >> 30)) +
                                    (uint) this.mti;
                /* See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier. */
                /* In the previous versions, MSBs of the seed affect   */
                /* only MSBs of the array mt[].                        */
                /* 2002/01/09 modified by Makoto Matsumoto             */
                this.mt[this.mti] &= 0xffffffff;
                /* for >32 bit machines */
            }
        }
        /* mag01[x] = x * MATRIX_A  for x=0,1 */

        /* generates a random number on [0,0xffffffff]-interval */
        public uint genrand() //genrand_int32
        {
            uint y;
            //See above for what was moved out from here

            if (this.mti >= N)
            {
                /* generate N words at one time */
                int kk;

                if (this.mti == N + 1) /* if init_genrand() has not been called, */
                {
                    this.sgenrand(DEFAULT_SEED); /* a default initial seed is used */
                }

                for (kk = 0; kk < N - M; kk++)
                {
                    y = (this.mt[kk] & UPPER_MASK) | (this.mt[kk + 1] & LOWER_MASK);
                    this.mt[kk] = this.mt[kk + M] ^ (y >> 1) ^ this.mag01[y & 0x1UL];
                }

                for (; kk < N - 1; kk++)
                {
                    y = (this.mt[kk] & UPPER_MASK) | (this.mt[kk + 1] & LOWER_MASK);
                    this.mt[kk] = this.mt[kk + (M - N)] ^ (y >> 1) ^ this.mag01[y & 0x1U];
                }

                y = (this.mt[N - 1] & UPPER_MASK) | (this.mt[0] & LOWER_MASK);
                this.mt[N - 1] = this.mt[M - 1] ^ (y >> 1) ^ this.mag01[y & 0x1U];

                this.mti = 0;
            }

            y = this.mt[this.mti++];

            /* Tempering */
            y ^= y >> 11;
            y ^= (y << 7) & 0x9d2c5680U;
            y ^= (y << 15) & 0xefc60000U;
            y ^= y >> 18;

            return y;
        }

        /// <summary>
        ///     Saves the state of the RNG
        /// </summary>
        /// <param name="rng"></param>
        /// <returns>RNGState structure</returns>
        public RNGState saveState()
        {
            return new RNGState {mti = this.mti, mt = this.mt.Clone() as uint[]};
        }

        /// <summary>
        ///     Loads the state of the RNG
        /// </summary>
        /// <param name="inmti">Input mti</param>
        /// <param name="inmt">Input mt</param>
        public void loadState(int mti, uint[] mt)
        {
            this.mti = mti;
            mt.CopyTo(this.mt, 0);
        }

        /// <summary>
        ///     Loads the state of the RNG
        /// </summary>
        /// <param name="inputState">Tuple<Input mti, Input mt, Input mag01></param>
        public void loadState(RNGState inputState)
        {
            this.mti = inputState.mti;
            inputState.mt.CopyTo(this.mt, 0);
        }

        /// <summary>
        ///     Dumps random numbers.
        /// </summary>
        /// <param name="size">size of dump</param>
        /// <returns></returns>
        public uint[] Dump(int size)
        {
            var rtn = new uint[size];
            for (var i = 0; i < size; i++)
            {
                rtn[i] = this.genrand();
            }

            return rtn;
        }
    }
}