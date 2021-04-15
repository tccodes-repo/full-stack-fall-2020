using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;

namespace Emailer.Auth 
{

    public class JsonWebKeySetWrapper
    {
        [System.Text.Json.Serialization.JsonPropertyName("data")]
        [JsonProperty("data")]
        public JsonWebKeySet? Keys { get; set; }
    }

    public class JwksConfigurationRetriever : IConfigurationRetriever<OpenIdConnectConfiguration>
    {
        public async Task<OpenIdConnectConfiguration> GetConfigurationAsync(string address,
            IDocumentRetriever retriever, CancellationToken cancel)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw LogHelper.LogArgumentNullException(nameof(address));
            if (retriever == null)
                throw LogHelper.LogArgumentNullException(nameof(retriever));

            string jwks = "";
            try {
                jwks = await retriever.GetDocumentAsync(address, cancel).ConfigureAwait(false);
            } catch(System.Exception ex) {
                System.Console.WriteLine("Error: {0}", ex);
            }

            // If the keyset comes from Vault, it'll be under the data element in the response blob.
            // If it's from the auth service, it'll be a normal keyset.
            var keysetWrapper = JsonConvert.DeserializeObject<JsonWebKeySetWrapper>(jwks);
            var keyset = keysetWrapper?.Keys ?? JsonConvert.DeserializeObject<JsonWebKeySet>(jwks);

            var openIdConnectConfiguration =
                new OpenIdConnectConfiguration {JsonWebKeySet = keyset};
            foreach (var signingKey in openIdConnectConfiguration.JsonWebKeySet.GetSigningKeys())
                openIdConnectConfiguration.SigningKeys.Add(signingKey);
            return openIdConnectConfiguration;
        }
    }
}