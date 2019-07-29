﻿using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateNewBlockBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;
      var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateNewBlock(
          coin, network, url);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateNewBlockBch executed successfully, HookId is \"" +
          $"{response.Payload.Id}\""
        : $"CreateNewBlockBch error: {response.ErrorMessage}");
    }
  }
}