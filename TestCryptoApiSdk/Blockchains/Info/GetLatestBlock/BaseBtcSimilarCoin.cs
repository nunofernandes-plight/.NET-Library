﻿using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Info.GetLatestBlock
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Info.GetLatestBlock<GetBtcHashInfoResponse>(NetworkCoin);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.HashInfo.Chainwork),
                $"'{nameof(response.HashInfo.Chainwork)}' must not be null");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}