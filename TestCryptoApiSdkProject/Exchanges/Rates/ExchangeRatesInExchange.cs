﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges.Rates
{
    [TestClass]
    public class ExchangeRatesInExchange : BaseCollectionTest
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange);
        }

        protected override ICollectionResponse GetSkipList(int skip)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, skip: skip);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, limit: limit);
        }

        protected override ICollectionResponse GetSkipAndLimitList(int skip, int limit)
        {
            return Manager.Exchanges.Rates.GetAny(BaseAsset, Exchange, skip, limit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset of null was inappropriately allowed.")]
        public void TestNullAsset()
        {
            Manager.Exchanges.Rates.GetAny(baseAsset: null, exchange: Exchange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Asset.Id of null was inappropriately allowed.")]
        public void TestNullAssetId()
        {
            Manager.Exchanges.Rates.GetAny(new Asset(), Exchange);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var timeStamp = new DateTime(2019, 02, 03);
            var response = Manager.Exchanges.Rates.GetAny(new Asset("QWEE'WQ"), Exchange, timeStamp);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Asset not found", response.ErrorMessage);
            Assert.IsNotNull(response.Rates);
            Assert.IsFalse(response.Rates.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Manager.Exchanges.Rates.GetAny(BaseAsset, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            Manager.Exchanges.Rates.GetAny(BaseAsset, new Exchange());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var response = Manager.Exchanges.Rates.GetAny(BaseAsset, new Exchange("QWE'EWQ"));

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Asset not found", response.ErrorMessage);
            Assert.IsNotNull(response.Rates);
            Assert.IsFalse(response.Rates.Any());
        }

        private Asset BaseAsset { get; } = new Asset("5b755dacd5dd99000b3d92b2");
        private Exchange Exchange { get; } = new Exchange("5b1ea9d21090c200146f7366");
    }
}