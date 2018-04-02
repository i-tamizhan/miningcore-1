/* 
Copyright 2017 Coin Foundry (coinfoundry.org)
Authors: Oliver Weichhold (oliver@weichhold.com)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial 
portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using Newtonsoft.Json;
using System.Collections.Generic;

namespace MiningCore.Blockchain.Bitcoin.DaemonResponses
{
    public class MiningInfo
    {
        public int Blocks { get; set; }
        public int CurrentBlockSize { get; set; }
        public int CurrentBlockWeight { get; set; }
        public double Difficulty { get; set; }
        public double NetworkHashps { get; set; }
        public string Chain { get; set; }
    }

    public class IgnitionCoinMiningInfo
    {
        public int Blocks { get; set; }
        public int CurrentBlockSize { get; set; }
        public int CurrentBlockWeight { get; set; }
        public Dictionary<string, double> Difficulty { get; set; }
        public double NetworkHashps { get; set; }
        public bool TestNet { get; set; }
        [JsonExtensionData]
        public IDictionary<string, object> Extra { get; set; }

        public MiningInfo ToMiningInfo()
        {
            var mInfo = new MiningInfo();
            mInfo.Blocks = Blocks;
            mInfo.CurrentBlockSize = CurrentBlockSize;
            mInfo.CurrentBlockWeight = CurrentBlockWeight;
            mInfo.Difficulty = Difficulty["proof-of-work"];
            mInfo.NetworkHashps = NetworkHashps;
            if (!TestNet)
                mInfo.Chain = "main";
            else
                mInfo.Chain = "test";
            return mInfo;
        }
    }
}
