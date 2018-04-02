using MiningCore.Blockchain.Bitcoin.DaemonResponses;
using MiningCore.DaemonInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningCore.Extensions
{
    public static class DaemonResponseExtensions
    {
        public static DaemonInfo ToDaemonInfo(this DoubleDifficultyDaemonInfo dddi)
        {
            var dInfo = new DaemonInfo();
            dInfo.Balance = dddi.Balance;
            dInfo.Blocks = dddi.Blocks;
            dInfo.Connections = dddi.Connections;
            dInfo.Difficulty = dddi.Difficulty["proof-of-work"];
            dInfo.ProtocolVersion = dddi.ProtocolVersion;
            dInfo.Testnet = dddi.Testnet;
            dInfo.Version = dddi.Version;
            dInfo.WalletVersion = dddi.WalletVersion;
            return dInfo;
        }
    }
}
