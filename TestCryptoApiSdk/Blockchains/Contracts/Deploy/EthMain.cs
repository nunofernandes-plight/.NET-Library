﻿using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Contracts.Deploy
{
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthMainNet;
        protected override string FromAddress { get; } = "0xe7cc96ba0562dfba61a55c8dd2e162a30942f402";
    }
}