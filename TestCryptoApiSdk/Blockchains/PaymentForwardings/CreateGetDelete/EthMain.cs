﻿using CryptoApisLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.PaymentForwardings.CreateGetDelete
{
    [TestClass]
    public class EthMain : BaseEthSimilarCoin
    {
        protected override NetworkCoin NetworkCoin { get; } = NetworkCoin.EthMainNet;
    }
}