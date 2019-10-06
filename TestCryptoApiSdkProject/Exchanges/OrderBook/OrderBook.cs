﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Exchanges.OrderBook
{
    [TestClass]
    public class OrderBook : BaseTest
    {
        [TestMethod]
        public void TestSimple()
        {
            var response = Manager.Exchanges.OrderBook.Get(Exchange, BaseAsset, QuoteAsset);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.OrderBook);
            Assert.IsNotNull(response.OrderBook.Depth);
            Assert.IsTrue(response.OrderBook.Depth.Asks.Any() || response.OrderBook.Depth.Bids.Any());
        }

        [TestMethod]
        public void TestSameAsset()
        {
            var response = Manager.Exchanges.OrderBook.Get(Exchange, BaseAsset, BaseAsset);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("error Record is not found", response.ErrorMessage);
            Assert.IsNull(response.OrderBook);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset of null was inappropriately allowed.")]
        public void TestNullBaseAsset()
        {
            Manager.Exchanges.OrderBook.Get(Exchange, baseAsset: null, quoteAsset: QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Quote of null was inappropriately allowed.")]
        public void TestNullQuoteAsset()
        {
            Manager.Exchanges.OrderBook.Get(Exchange, BaseAsset, quoteAsset: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange of null was inappropriately allowed.")]
        public void TestNullExchange()
        {
            Manager.Exchanges.OrderBook.Get(exchange: null, baseAsset: BaseAsset, quoteAsset: QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A BaseAsset.Id of null was inappropriately allowed.")]
        public void TestNullBaseAssetId()
        {
            Manager.Exchanges.OrderBook.Get(Exchange, new Asset(), QuoteAsset);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A QuoteAsset.Id of null was inappropriately allowed.")]
        public void TestNullQuoteAssetId()
        {
            Manager.Exchanges.OrderBook.Get(Exchange, BaseAsset, new Asset());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Exchange.Id of null was inappropriately allowed.")]
        public void TestNullExchangeId()
        {
            Manager.Exchanges.OrderBook.Get(new Exchange(), BaseAsset, QuoteAsset);
        }

        [TestMethod]
        public void TestIncorrectBaseAsset()
        {
            var baseAsset = new Asset { AssetId = "QWE'EWQ1" };
            var response = Manager.Exchanges.OrderBook.Get(Exchange, baseAsset, QuoteAsset);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.AreEqual("error Record is not found", response.ErrorMessage);
                Assert.IsNull(response.OrderBook);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestIncorrectQuoteAsset()
        {
            var quoteAsset = new Asset { AssetId = "QWE'EWQ1" };
            var response = Manager.Exchanges.OrderBook.Get(Exchange, BaseAsset, quoteAsset);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.AreEqual("error Record is not found", response.ErrorMessage);
                Assert.IsNull(response.OrderBook);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var exchange = new Exchange { ExchangeId = "QWE'EWQ1" };
            var response = Manager.Exchanges.OrderBook.Get(exchange, BaseAsset, QuoteAsset);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.AreEqual("error Record is not found", response.ErrorMessage);
                Assert.IsNull(response.OrderBook);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        private Exchange Exchange { get; } = new Exchange("5b1ea9d21090c200146f7362") { ExchangeId = "BITFINEX" };
        private Asset BaseAsset { get; } = new Asset("5b1ea92e584bf50020130612") { AssetId = "EOS" };
        private Asset QuoteAsset { get; } = new Asset("5b1ea92e584bf50020130615") { AssetId = "BTC" };
    }
}